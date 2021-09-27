using System;

namespace Adressboken
{
    class Program
    {
        //Variablar
        static ContactBook myContacts = new();

        static void Main(string[] args)
        {
            myContacts.Testdata(10);
            while (true)
            {
                Execute(UI.mainMenu());
            }
        }
        public static void Execute(string command, string name = "")
        {
            if (command == "ClearContacts")
            {
                myContacts.ClearContacts();
                Console.WriteLine("Contactlist is now empty! Press any key to continue...");
                Console.ReadLine();
            }
            else if (command == "print")
            {
                Console.WriteLine(name);
                System.Console.WriteLine(myContacts.ListAllContacts());
                Console.ReadLine();
            }
            else if (command.Contains("AddContact"))
            {
                int startIndex = command.IndexOf("fn:");
                int endIndex = command.IndexOf(":ln");
                string tmpFirst = command.Substring(startIndex + 3, endIndex - startIndex - 3);

                startIndex = command.IndexOf("ln:");
                endIndex = command.IndexOf(":a");
                string tmpLast = command.Substring(startIndex + 3, endIndex - startIndex - 3);

                startIndex = command.IndexOf(":a");
                endIndex = command.IndexOf(":pn");
                int.TryParse(command.Substring(startIndex + 3, endIndex - startIndex - 3), out int tmpAge);

                startIndex = command.IndexOf("pn:");
                endIndex = command.IndexOf(":end");
                string tmpNumber = command.Substring(startIndex + 3, endIndex - startIndex - 3);

                myContacts.AddContact(tmpFirst, tmpLast, tmpAge, tmpNumber);
            }
            else if (command.Contains("search"))
            {
                int startIndex = command.IndexOf(":search:");
                string searchedName = command.Substring(8);
                System.Console.WriteLine(myContacts.Search(searchedName.ToLower()));
                Console.ReadLine();
            }
            else if (command == "RemoveContact")
            {
                System.Console.WriteLine("Där");
                string choosen = ConsoleUtils.ReadString("Who do you want to delete?");

                bool sucess = myContacts.DeleteContact(choosen.ToLower());
                if (sucess)
                {
                    Console.WriteLine("Contact has been deleted!");
                }
                else
                {
                    Console.WriteLine("Contact not deleted.");
                }
                Console.ReadLine();
            }

        }
    }
}
