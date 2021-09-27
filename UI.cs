using System;
using System.Collections.Generic;

namespace Adressboken
{
    class UI
    {
        static int hoverIndex = 0;
        static int menuIndex = 0;
        static string output = "";

        public static string mainMenu()
        {
            Console.Clear();

            List<string> menuItems = new()
            {
                "List all contacts",
                "Add contact",
                "Search contact",
                "Delete contact",
                "Exit"
            };
            List<string> subMenuItems = new()
            {
                "Delete contact",
                "Empty contact",
                "Back"
            };

            Console.CursorVisible = false;
            while (true)
            {
                output = "";
                if (menuIndex == 0)
                {

                    string selectedMenuItem = drawMainMenu(menuItems);
                    if (selectedMenuItem == "List all contacts")
                    {
                        output = "print";
                    }
                    else if (selectedMenuItem == "Add contact")
                    {
                        string tmpFirst = ConsoleUtils.ReadString("Enter first name: ");
                        string tmpLast = ConsoleUtils.ReadString("Enter last name: ");
                        int tmpAge = ConsoleUtils.ReadInt("Enter age: ");
                        string tmpNumber = ConsoleUtils.ReadString("Enter phone number: ");
                        output = $"AddContact:fn:{tmpFirst}:ln:{tmpLast}:a:{tmpAge}:pn:{tmpNumber}:end";
                    }
                    else if (selectedMenuItem == "Search contact")
                    {
                        SearchName();
                    }
                    else if (selectedMenuItem == "Delete contact")
                    {
                        hoverIndex = 0;
                        menuIndex = 1;
                    }
                    else if (selectedMenuItem == "Exit")
                    {
                        Environment.Exit(0);
                    }
                }
                else if (menuIndex == 1)
                {
                    string selectedMenuItem = drawMainMenu(subMenuItems);
                    if (selectedMenuItem == "Delete contact")
                    {
                        output = DeleteContact();
                    }
                    else if (selectedMenuItem == "Empty contact")
                    {
                        output = "ClearContacts";
                    }
                    else if (selectedMenuItem == "Back")
                    {
                        hoverIndex = 3;
                        menuIndex = 0;
                    }
                }
                return output;
            }

        }
        private static string drawMainMenu(List<string> items)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("----: Contacts :----");
            //Console.WriteLine($"Number of persons: {ContactList.contactList.Count}");
            //Console.WriteLine($"Number of characters: {totalChars}");
            //Console.WriteLine("--------------------");
            Console.ResetColor();
            for (int i = 0; i < items.Count; i++)
            {
                if (i == hoverIndex)
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
                if (hoverIndex == items.Count - 1) { }
                else { hoverIndex++; }
            }
            else if (ckey.Key == ConsoleKey.UpArrow)
            {
                if (hoverIndex <= 0) { }
                else { hoverIndex--; }
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
                return items[hoverIndex];
            }
            else
            {
                return "";
            }
            Console.Clear();
            return "";
        }
        static void SearchName()
        {
            //  Note to self: Lägg till nummer känslighet
            Console.ForegroundColor = ConsoleColor.White;
            string searchedName = ConsoleUtils.ReadString("What name whould you like to search for?");
            output = $":search:{searchedName}";
        }
        static string DeleteContact()
        {
            System.Console.WriteLine("Här!");
            return "RemoveContact";
        }

    }
}