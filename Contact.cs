using System;

namespace Adressboken
{
    class Contact
    {
        private string firstName;
        private string lastName;
        private DateTime birthdate;
        private string phoneNumber;

        public string FirstName { get { return firstName; } }
        public string LastName { get { return lastName; } }
        public int Age { get { int age = DateTime.Today.Year - birthdate.Year; return age; } }
        public string PhoneNumber { get { return phoneNumber; } }
        public string FullName { get { return firstName + " " + lastName; } }

        public Contact(string firstName, string lastName, int age, string phoneNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            birthdate = DateTime.Now.AddYears(-age);
            this.phoneNumber = phoneNumber;
        }
        public string print(int i)
        {
            string output = "";
            output = ($"\n {i}. {FullName} - {Age} år - {phoneNumber}");
            return output;
        }

    }
}