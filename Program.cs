using System;
using System.Collections.Generic;

namespace Adressboken
{
    class Program
    {
        //Variablar
        static int antalNamn = 0;
        static string message = "";
        static List<string> contacts = new();
        static void Main(string[] args)
        {

            while (true)
            {
                Meny();
            }
        }

        static void Meny()
        {
            //Meny 
            Console.Clear();
            Console.WriteLine($" --: Adressboken :--- Antal namn: {contacts.Count} Antal Tecken: {((char)contacts.Count)}");
            Console.WriteLine("[A] Visa alla namn i adressboken: ");
            Console.WriteLine("[B] Lägg till namn: ");
            Console.WriteLine("[C] Töm adressboken: ");
            Console.WriteLine("[Q] Stäng program");
            Console.WriteLine(message);
            Console.Write("Vad vill du göra? ");
            string mySelection = Console.ReadLine().ToLower();

            if (mySelection == "a")
            {

                if (antalNamn == 0)
                {
                    message = "Inga namn i adressboken.";
                }
                else
                {
                    int j = 1;
                    foreach (var name in contacts)
                    {
                        Console.WriteLine($"{j}. {name}");
                        j++;
                    }
                    Console.ReadLine();

                }
            }
            else if (mySelection == "b")
            {
                Console.WriteLine("Vad är namnet? ");
                addToContacts(Console.ReadLine());
                antalNamn++;
                message = "Nytt namn tillagt.";
            }
            else if (mySelection == "c")
            {
                ClearContacts();
                antalNamn = 0;
            }
            else if (mySelection == "q")
            {
                Environment.Exit(0);
            }
            else
            {
                message = "Ogilltligt val!";
            }

        }
        static void addToContacts(string name)
        {
            contacts.Add(name);
        }
        static void ClearContacts()
        {
            contacts.Clear();
        }
    }
}