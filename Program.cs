﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Adressboken
{
    class Program
    {
        //Variablar
        static int indexMainMenu = 0;
        static List<string> contactNames = new();
        static List<string> phoneNumbers = new();
        static int totalChars = 0;


        static void Main(string[] args)

        {
            Testdata();
            mainMenu();

        }



        public static void mainMenu()
        {
            // Console.Clear();

            List<string> menuItems = new List<string>()
    {
        "View contacts",
        "Add contact",
        "Search contact",
        "Empty contact",
        "Exit"
    };

            Console.CursorVisible = false;
            while (true)
            {
                string selectedMenuItem = drawMainMenu(menuItems);
                if (selectedMenuItem == "View contacts")
                {
                    WriteOutContacts();
                }
                else if (selectedMenuItem == "Add contact")
                {
                    AddContact();
                }
                else if (selectedMenuItem == "Search contact")
                {
                    SearchName();
                }
                else if (selectedMenuItem == "Empty contact")
                {
                    ClearContacts();
                }
                else if (selectedMenuItem == "Exit")
                {
                    Environment.Exit(0);
                }
            }
        }

        public static string drawMainMenu(List<string> items)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("----: Contacts :----");
            Console.WriteLine($"Number of persons: {contactNames.Count}");
            Console.WriteLine($"Number of characters: {totalChars}");
            Console.WriteLine("--------------------");
            Console.ResetColor();
            for (int i = 0; i < items.Count; i++)
            {
                if (i == indexMainMenu)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(items[i]);
                }
                else
                {
                    Console.WriteLine(items[i]);
                }
                Console.ResetColor();
            }

            ConsoleKeyInfo ckey = Console.ReadKey();
            if (ckey.Key == ConsoleKey.DownArrow)
            {
                if (indexMainMenu == items.Count - 1) { }
                else { indexMainMenu++; }
            }
            else if (ckey.Key == ConsoleKey.UpArrow)
            {
                if (indexMainMenu <= 0) { }
                else { indexMainMenu--; }
            }
            else if (ckey.Key == ConsoleKey.LeftArrow)
            {
                Console.Clear();
            }
            else if (ckey.Key == ConsoleKey.RightArrow)
            {
                Console.Clear();
            }
            else if (ckey.Key == ConsoleKey.Enter)
            {
                return items[indexMainMenu];
            }
            else
            {
                return "";
            }

            Console.Clear();
            return "";
        }

        static string CheckPhoneNr(string number)
        {
            while (true)
            {
                if (int.TryParse(number, out int result))
                {

                    if (number.Length == 10)
                    {
                        return number;
                    }
                    else
                    {
                        Console.WriteLine("Only 10 numbers, try again: ");
                        number = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Only numbers, try again: ");
                    number = Console.ReadLine();
                }
            }
        }
        static void AddContact()
        {
            Console.WriteLine("What's the persons name? ");
            string tmpName = Console.ReadLine();
            Console.WriteLine("Add the person's phone number: ");
            string tmpNumber = CheckPhoneNr(Console.ReadLine());

            contactNames.Add(tmpName);
            phoneNumbers.Add(tmpNumber);

            int total = 0;
            foreach (var name2 in contactNames)
            {
                int i = name2.Length;
                total = total += i;
            }
            totalChars = total;
            Console.WriteLine("New name and phonenumber added. Press any key to continue...");
            Console.ReadLine();
        }

        static void ClearContacts()
        {
            contactNames.Clear();
            totalChars = 0;
            Console.WriteLine("Contacts in now empty! Press any key to continue...");
            Console.ReadLine();
        }

        static void SearchName()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("What name whould you like to search for?");
            string searchName2 = "";
            bool nameExist = false;

            while (true)
            {
                if (string.IsNullOrWhiteSpace(searchName2))
                {
                    searchName2 = Console.ReadLine().ToLower();

                }
                else
                {
                    break;
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            foreach (var name in contactNames)
            {
                if (name.ToLower() == searchName2)
                {
                    nameExist = true;
                }
                if (name.ToLower().Contains(searchName2))
                {
                    Console.WriteLine($"{name} exists in contacts!");

                }
                if (name.ToLower() != searchName2 && name == contactNames.Last() && !nameExist)
                {
                    Console.WriteLine($"{Char.ToUpper(searchName2[0]) + searchName2.Substring(1)} did not exists in contacts!");
                }
            }
            Console.ReadLine();
        }

        static void WriteOutContacts()
        {
            if (contactNames.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your contacts are empty.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                int j = 1;
                foreach (var name in contactNames)
                {
                    Console.Write($"{j}. {name} ---");

                    for (int i = 0; i < phoneNumbers.Count; i++)
                    {
                        if (i == j - 1)
                        {
                            Console.WriteLine($" {phoneNumbers[i]}");
                        }
                    }
                    j++;
                }
            }
            Console.ReadLine();
        }
        static void Testdata(int nameCount = 10)
        {
            Random rand = new Random();

            List<string> firstName = new()
            {
                "Erik",
                "John",
                "Eva",
                "Jessica",
                "Tobias",
                "Maria"
            };
            List<string> LastName = new()
            {
                "Eriksson",
                "Johansson",
                "Frisk",
                "Larsdotter",
                "Lönn",
                "Alm"
            };
            for (int i = 0; i < nameCount; i++)
            {
                int index = rand.Next(1, 6);
                String tmpContact = $"{firstName[index]} ";
                index = rand.Next(1, 6);
                tmpContact = tmpContact + LastName[index];
                contactNames.Add(tmpContact);
                phoneNumbers.Add("0707070707");
            }


        }//Slutet på klassen

    }
}