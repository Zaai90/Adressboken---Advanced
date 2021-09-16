using System;

namespace Adressboken
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variablar
            int antalNamn = 0;
            string[] adressbok = new string[0];

            while (true)
            { //Meny           
                Console.WriteLine("[A] Visa alla namn i adressboken: ");
                Console.WriteLine("[B] Lägg till namn: ");
                Console.WriteLine("[C] Töm adressboken: ");
                Console.WriteLine("[Q] Stäng program");
                Console.Write("Vad vill du göra? ");
                string mySelection = Console.ReadLine().ToLower();

                if (mySelection == "a")
                {
                    Console.WriteLine("Adressboken:");
                    if (antalNamn == 0)
                    {
                        Console.WriteLine("Inga namn i adressboken.");
                    }
                    else
                    {
                        for (int i = 0; i < adressbok.Length; i++)
                        {
                            Console.WriteLine(i + 1 + ". " + adressbok[i]);
                        }
                    }
                }
                else if (mySelection == "b")
                {
                    Console.WriteLine("Vad är namnet? ");
                    string nyttNamn = Console.ReadLine();
                    Array.Resize(ref adressbok, adressbok.Length + 1);
                    adressbok[adressbok.Length - 1] = nyttNamn;
                    antalNamn++;
                    Console.WriteLine("Nytt namn tillagt.");
                }
                else if (mySelection == "c")
                {
                    Array.Clear(adressbok, antalNamn - 1, antalNamn - 1);
                    Array.Resize(ref adressbok, adressbok.Length - antalNamn);
                    antalNamn = 0;
                }
                else if (mySelection == "q")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ogilltligt val!");
                }
            }
        }
    }
}