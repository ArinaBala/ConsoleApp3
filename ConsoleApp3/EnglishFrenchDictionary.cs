using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    public class EnglishFrenchDictionary
    {
        private Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

        public void AddWord(string englishWord, string[] translations)
        {
            if (string.IsNullOrEmpty(englishWord))
                return;

            string key = englishWord.ToLower().Trim();

            List<string> cleanTranslations = new List<string>();
            foreach (string tr in translations)
            {
                string t = tr.Trim();
                if (t != "")
                {
                    cleanTranslations.Add(t);
                }
            }

            if (cleanTranslations.Count == 0)
                return;

            if (dictionary.ContainsKey(key))
            {
                foreach (string tr in cleanTranslations)
                {
                    bool exists = false;
                    foreach (string item in dictionary[key])
                    {
                        if (item.ToLower() == tr.ToLower())
                        {
                            exists = true;
                            break;
                        }
                    }

                    if (!exists)
                    {
                        dictionary[key].Add(tr);
                    }
                }
            }
            else
            {
                dictionary[key] = cleanTranslations;
            }
        }

        public bool RemoveWord(string englishWord)
        {
            string key = englishWord.ToLower().Trim();
            if (dictionary.ContainsKey(key))
            {
                dictionary.Remove(key);
                return true;
            }
            return false;
        }

        public bool RemoveTranslation(string englishWord, string translation)
        {
            string key = englishWord.ToLower().Trim();
            string trToRemove = translation.ToLower().Trim();

            if (!dictionary.ContainsKey(key))
                return false;

            List<string> list = dictionary[key];
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ToLower() == trToRemove)
                {
                    list.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public bool UpdateWord(string oldWord, string newWord)
        {
            string oldKey = oldWord.ToLower().Trim();
            string newKey = newWord.ToLower().Trim();

            if (string.IsNullOrEmpty(newKey) || !dictionary.ContainsKey(oldKey))
                return false;

            if (dictionary.ContainsKey(newKey) && oldKey != newKey)
                return false;

            List<string> translations = dictionary[oldKey];
            dictionary.Remove(oldKey);
            dictionary[newKey] = translations;

            return true;
        }

        public bool UpdateTranslation(string englishWord, string oldTranslation, string newTranslation)
        {
            string key = englishWord.ToLower().Trim();
            string oldTr = oldTranslation.ToLower().Trim();
            string newTr = newTranslation.Trim();

            if (string.IsNullOrEmpty(newTr) || !dictionary.ContainsKey(key))
                return false;

            List<string> list = dictionary[key];
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ToLower() == oldTr)
                {
                    list[i] = newTr;
                    return true;
                }
            }

            return false;
        }

        public List<string> SearchTranslation(string englishWord)
        {
            string key = englishWord.ToLower().Trim();
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key];
            }
            return null;
        }

        public Dictionary<string, List<string>> GetAll()
        {
            return dictionary;
        }
    }
}