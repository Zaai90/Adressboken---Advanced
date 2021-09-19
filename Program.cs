using System;
using System.Collections.Generic;

namespace Adressboken
{
    class Program
    {
        //Variablar
        static List<string> contacts = new();
        static int totalChars = 0;
        static string message = "";


        static void Main(string[] args)

        {
            addToContacts("Erik Jansson");
            addToContacts("David Josefsson");
            addToContacts("Emil Grune");
            addToContacts("Erik Grune");
            addToContacts("Johan Grune");
            addToContacts("Erik Danielsson");
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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($" --- § Contacts § --- \n Number of names: {contacts.Count} Number of characters: {totalChars}");
            Console.WriteLine("[V]iew contacts");
            Console.WriteLine("[A]dd name");
            Console.WriteLine("[E]mpty contacts");
            Console.WriteLine("[S]earch name");
            Console.WriteLine("[Q]uit program");
            Console.WriteLine(message);
            Console.Write("Choose action: ");

            string mySelection = Console.ReadKey(true).Key.ToString().ToLower();
            Console.WriteLine();

            if (mySelection == "v")
            {
                WriteNames();
            }
            else if (mySelection == "a")
            {
                Console.WriteLine("What name do you want to add? ");
                addToContacts(Console.ReadLine());

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


        static void addToContacts(string name)
        {

            contacts.Add(name);

            int total = 0;
            foreach (var name2 in contacts)
            {
                int i = name2.Length;
                total = total += i;
            }
            totalChars = total;
            message = "New name added.";
        }


        static void ClearContacts()
        {
            contacts.Clear();
            totalChars = 0;
            message = "Contacts in now empty!";
        }


        static void SearchName()
        {
            Console.WriteLine("What name whould you like to search for?");
            string searchName = Console.ReadLine();

            foreach (var name in contacts)
            {
                if (name.Contains(searchName))
                {
                    Console.WriteLine($"{name} exists in contacts!");
                }
            }
            Console.ReadLine();
            message = "";
        }


        static void WriteNames()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No names in contacts.");
            }
            else
            {
                int j = 1;
                foreach (var name in contacts)
                {
                    Console.WriteLine($"{j}. {name}");
                    j++;
                }


            }
            Console.ReadLine();
        }
    }
}