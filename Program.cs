using System;
using System.Collections.Generic;
using System.Linq;

namespace Adressboken
{
    class Program
    {
        //Variablar
        static int hoverIndex = 0;
        static int menuIndex = 0;
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
            Console.Clear();

            List<string> menuItems = new()
            {
                "View contacts",
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
                if (menuIndex == 0)
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
                        // System.Console.WriteLine("Testing testing!");
                        // Console.ReadLine();
                        DeleteContact();
                    }
                    else if (selectedMenuItem == "Empty contact")
                    {
                        ClearContacts();
                    }
                    else if (selectedMenuItem == "Back")
                    {
                        hoverIndex = 3;
                        menuIndex = 0;
                    }
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
            string tmpName;
            string tmpNumber;
            Console.WriteLine("What's the persons name? ");
            tmpName = Console.ReadLine();
            while (true)
            {
                if (string.IsNullOrWhiteSpace(tmpName))
                {
                    Console.WriteLine("You need to enter a name:");
                    tmpName = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Add the person's phone number: ");
            tmpNumber = CheckPhoneNr(Console.ReadLine());

            AddContact(tmpName, tmpNumber);


        }
        static void AddContact(string tmpName, string tmpNumber)
        {
            contactNames.Add(tmpName);
            phoneNumbers.Add(tmpNumber);

            int total = 0;
            foreach (var name in contactNames)
            {
                int i = name.Length;
                total = total += i;
            }
            totalChars = total;
            Console.WriteLine("New name and phonenumber added. Press any key to continue...");
            Console.ReadLine();

        }
        static void AddContact(string tmpName, string tmpNumber, string type = "automatic")
        {
            contactNames.Add(tmpName);
            phoneNumbers.Add(tmpNumber);

            int total = 0;
            foreach (var name in contactNames)
            {
                int i = name.Length;
                total = total += i;
            }
            totalChars = total;

        }

        static void DeleteContact()
        {
            int nr = 0;
            string choosen = "";
            bool exists = false;
            Console.WriteLine("Who do you want to delete from contacts?");
            ConsoleKeyInfo ckey = Console.ReadKey(true);



            while (ckey.Key != ConsoleKey.Escape)
            {
                //Funkar inte att avbryta när man börjat skriva

                //System.Console.WriteLine("CHECK!");
                choosen = Console.ReadLine().ToLower();
                ckey = Console.ReadKey();
                foreach (var name in contactNames)
                {
                    if (name.ToLower() == choosen)
                    {
                        contactNames.Remove(name);
                        phoneNumbers.Remove(phoneNumbers[nr]);
                        Console.WriteLine("Contact deleted!");
                        Console.ReadLine();
                        break;
                    }

                    else if (!exists && name == contactNames.Last())
                    {
                        Console.WriteLine("Could not find that name.");
                        Console.ReadLine();
                        break;


                    }
                    nr++;
                }

                break;

            }

        }
        static void ClearContacts()
        {
            contactNames.Clear();
            phoneNumbers.Clear();
            totalChars = 0;
            Console.WriteLine("Contacts in now empty! Press any key to continue...");
            Console.ReadLine();
        }
        static void SearchName()
        {
            //Note to self: Lägg till nummer känslighet
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
                "Maria",
                "Daniel",
                "Lisa",
                "Gustav",
                "Elin",
                "Martin",
                "Tina",
                "Alfons",
                "Klara",
                "Kent",
                "Albert",
                "Frida",
                "Victoria"
            };
            List<string> LastName = new()
            {
                "Eriksson",
                "Johansson",
                "Frisk",
                "Larsdotter",
                "Lönn",
                "Åberg",
                "Jakobsson",
                "Frankenstein",
                "Einstein",
                "Grune",
                "Larsson",
                "Morzart",
                "Fredriksson",
                "Thulin",
                "Jansson",
                "Alm"
            };
            for (int i = 0; i < nameCount; i++)
            {
                int index = rand.Next(0, 18);
                String tmpContact = $"{firstName[index]} ";
                index = rand.Next(0, 16);
                tmpContact = tmpContact + LastName[index];
                int randNr = rand.Next(1000000, 9999999);
                AddContact(tmpContact, $"070{randNr}", "");

            }


        }//Slutet på klassen
    }
}