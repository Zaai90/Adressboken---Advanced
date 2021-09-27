using System;
using System.Collections.Generic;
using System.Linq;


namespace Adressboken
{
    public class ContactBook
    {
        private List<Contact> contactList = new();

        public void AddContact(string tmpFirstName, string tmpLastName, int tmpAge, string tmpNumber)
        {
            Contact newContact = new(tmpFirstName, tmpLastName, tmpAge, tmpNumber);
            contactList.Add(newContact);
        }
        public bool DeleteContact(string choosen)
        {
            int index = 0;
            bool exists = false;
            foreach (var name in contactList)
            {
                if (name.FullName.ToLower() == choosen)
                {
                    contactList.Remove(contactList[index]);
                    return true;
                }

                else if (!exists && name == contactList.Last())
                {
                    return false;
                }
                index++;
            }
            return false;

        }
        public void ClearContacts()
        {
            contactList.Clear();
        }
        public string Search(string searchName)
        {
            bool nameExist = false;
            string output = "";

            if (string.IsNullOrWhiteSpace(searchName))
            {
                System.Console.WriteLine("Crash!");
                //VAD SKA HÄNDA OM DET AVBRYTS!
            }

            //contactList.Where(c => c.FullName.Contains(searchName)).ToList().ForEach(a => Console.WriteLine(a));


            foreach (var name in contactList)
            {
                if (name.FullName.ToLower() == searchName)
                {
                    nameExist = true;
                }
                if (name.FullName.ToLower().Contains(searchName))
                {
                    output += name.FullName + " exists in contacts!\n";
                }
                if (name.FullName.ToLower() != searchName && name == contactList.Last() && !nameExist)
                {
                    output += $"{Char.ToUpper(searchName[0]) + searchName.Substring(1)} did not exists in contacts!";
                }
            }
            return output;
        }
        public string ListAllContacts()
        {
            string output = "";
            int i = 1;
            foreach (var contact in contactList)
            {
                output += contact.print(i);
                i++;
            }
            return output;


        }
        public void Testdata(int nameCount = 10)
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
                int index = rand.Next(0, firstName.Count);
                string tmpFirstName = firstName[index];
                index = rand.Next(0, LastName.Count);
                string tmpLastName = LastName[index];
                int randNr = rand.Next(1000000, 9999999);
                int randAge = rand.Next(18, 100);
                AddContact(tmpFirstName, tmpLastName, randAge, $"070{randNr}");

            }

        }

    }
}