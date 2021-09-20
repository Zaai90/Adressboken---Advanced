using System;
using System.Collections.Generic;
using System.Linq;

namespace Adressboken
{
    class Program
    {
        //Variablar
        static List<string> contactNames = new();
        static List<string> phoneNumbers = new();
        static int totalChars = 0;
        static string message = "";


        static void Main(string[] args)

        {
            addToContacts("Dav", "0707070707");
            addToContacts("Erik Jansson", "0707070707");
            addToContacts("Nina Larsdotter", "0707070707");
            addToContacts("David Josefsson", "0707070707");
            addToContacts("Sara Andersson", "0707070707");
            addToContacts("Emil Grune", "0707070707");
            addToContacts("Elin Grune", "0707070707");
            addToContacts("Erik Grune", "0707070707");
            addToContacts("Johan Grune", "0707070707");
            addToContacts("Erik Danielsson", "0707070707");
            message = "";

            while (true)
            {
                ShowMenu();
            }
        }
        static void ShowMenu()
        {
            //Menu
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($" --- § Contacts § --- \n Number of names: {contactNames.Count} Number of characters: {totalChars}");
            Console.WriteLine("[V]iew contacts");
            Console.WriteLine("[A]dd name");
            Console.WriteLine("[E]mpty contacts");
            Console.WriteLine("[S]earch name");
            Console.WriteLine("[Q]uit program");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Choose action: ");

            string mySelection = Console.ReadKey(true).Key.ToString().ToLower();
            Console.WriteLine();

            if (mySelection == "v")
            {
                WriteNames();
            }
            else if (mySelection == "a")
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("What name do you want to add? ");
                string tmpName = Console.ReadLine();
                Console.WriteLine("Add the persons phonenumber: ");
                string tmpNumber = CheckPhoneNr(Console.ReadLine());

                addToContacts(tmpName, tmpNumber);

            }
            else if (mySelection == "e")
            {
                ClearContacts();

            }
            else if (mySelection == "s")
            {
                SearchName();

            }
            else if (mySelection == "q")
            {
                Environment.Exit(0);
            }
            else
            {
                message = "Invalid selection!";
            }

        }

        static string CheckPhoneNr(string number)
        {
            while (true)
            {
                if (int.TryParse(number, out int result))
                {
                    if (number.Length == 10)
                    {
                        return Convert.ToString(result);

                    }
                    else
                    {
                        return "0707070707";

                    }
                }
                else
                {
                    Console.WriteLine();
                }

            }
        }
        static void addToContacts(string name, string number)
        {

            contactNames.Add(name);
            phoneNumbers.Add(number);

            int total = 0;
            foreach (var name2 in contactNames)
            {
                int i = name2.Length;
                total = total += i;
            }
            totalChars = total;
            message = "New name and phonenumber added.";
        }


        static void ClearContacts()
        {
            contactNames.Clear();
            totalChars = 0;
            message = "Contacts in now empty!";
        }


        static void SearchName()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("What name whould you like to search for?");
            string searchName2 = "";
            bool nameExist = false;
            message = "";

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

        static void WriteNames()
        {
            if (contactNames.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No names in contacts.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                int j = 1;
                foreach (var name in contactNames)
                {
                    Console.WriteLine($"{j}. {name}");
                    j++;
                }
            }
            Console.ReadLine();
        }
    }
}