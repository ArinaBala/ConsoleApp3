using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            EnglishFrenchDictionary dict = new EnglishFrenchDictionary();

            dict.AddWord("hello", new string[] { "bonjour", "salut" });
            dict.AddWord("pug", new string[] { "pomme" });
            dict.AddWord("Diana", new string[] { "diana" });

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nОберіть дію:");
                Console.WriteLine("1. Додати слово та варіанти перекладу");
                Console.WriteLine("2. Видалити слово");
                Console.WriteLine("3. Видалити варіант перекладу");
                Console.WriteLine("4. Змінити слово");
                Console.WriteLine("5. Змінити варіант перекладу");
                Console.WriteLine("6. Пошук перекладу слова");
                Console.WriteLine("7. Показати весь словник");
                Console.WriteLine("0. Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "1")
                {
                    Console.Write("Введіть англійське слово: ");
                    string wordToAdd = Console.ReadLine();
                    Console.Write("Введіть варіанти перекладу (через кому): ");
                    string rawTranslations = Console.ReadLine();
                    string[] trArray = rawTranslations.Split(',');
                    dict.AddWord(wordToAdd, trArray);
                }
                else if (choice == "2")
                {
                    Console.Write("Введіть англійське слово для видалення: ");
                    string wordToRemove = Console.ReadLine();
                    dict.RemoveWord(wordToRemove);
                }
                else if (choice == "3")
                {
                    Console.Write("Введіть англійське слово: ");
                    string wordForTrDel = Console.ReadLine();
                    Console.Write("Введіть варіант перекладу для видалення: ");
                    string trToRemove = Console.ReadLine();
                    dict.RemoveTranslation(wordForTrDel, trToRemove);
                }
                else if (choice == "4")
                {
                    Console.Write("Введіть старе англійське слово: ");
                    string oldWord = Console.ReadLine();
                    Console.Write("Введіть нове англійське слово: ");
                    string newWord = Console.ReadLine();
                    dict.UpdateWord(oldWord, newWord);
                }
                else if (choice == "5")
                {
                    Console.Write("Введіть англійське слово: ");
                    string wordForTrUpdate = Console.ReadLine();
                    Console.Write("Введіть старий варіант перекладу: ");
                    string oldTr = Console.ReadLine();
                    Console.Write("Введіть новий варіант перекладу: ");
                    string newTr = Console.ReadLine();
                    dict.UpdateTranslation(wordForTrUpdate, oldTr, newTr);
                }
                else if (choice == "6")
                {
                    Console.Write("Введіть слово для пошуку: ");
                    string searchWord = Console.ReadLine();
                    List<string> results = dict.SearchTranslation(searchWord);
                    if (results != null && results.Count > 0)
                    {
                        Console.Write("Переклад для '" + searchWord + "': ");
                        for (int i = 0; i < results.Count; i++)
                        {
                            Console.Write(results[i]);
                            if (i < results.Count - 1)
                            {
                                Console.Write(", ");
                            }
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Переклад для слова '" + searchWord + "' не знайдено.");
                    }
                }
                else if (choice == "7")
                {
                    Dictionary<string, List<string>> all = dict.GetAll();
                    if (all.Count == 0)
                    {
                        Console.WriteLine("Словник порожній.");
                    }
                    else
                    {
                        foreach (KeyValuePair<string, List<string>> pair in all)
                        {
                            Console.Write(pair.Key + " -> ");
                            for (int i = 0; i < pair.Value.Count; i++)
                            {
                                Console.Write(pair.Value[i]);
                                if (i < pair.Value.Count - 1)
                                {
                                    Console.Write(", ");
                                }
                            }
                            Console.WriteLine();
                        }
                    }
                }
                else if (choice == "0")
                {
                    running = false;
                }
                else
                {
                    Console.WriteLine("Некоректний вибір.");
                }
            }
        }
    }
}