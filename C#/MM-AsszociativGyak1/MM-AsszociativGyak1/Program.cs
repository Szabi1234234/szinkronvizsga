using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MM_AsszociativGyak1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * MM - Pizza 
             */

            Hashtable pizza = new Hashtable() { 
            {"Margaréta", new string[] {"1", "paradicsomos alap", "sajt", "2240"} },
            {"Kukoricás", new string[] {"2", "paradicsomos alap", "kukorica", "sajt", "2290" } },
            {"Gonbá$", new string[] {"3", "paradicsomos alap", "gomba", "sajt", "2290" } },
            {"Sonkás", new string[] {"4", "paradicsomos alap", "sonka", "sajt", "2340" } },
            {"Sonkás-kukoricás", new string[] {"5", "paradicsomos alap", "sonka", "kukorica", "sajt", "2390" } },
            {"Tarjás", new string[] {"6", "paradicsomos alap", "tarja", "sajt", "2450" } }
            };

            bool folytat = true;
            int vegosszeg = 0;


            Console.WriteLine($"{"Pizza neve",-18} | {"Feltétek",-50} | {"Ár"}");
            foreach (DictionaryEntry item in pizza)
            {
                string[] pizzaAdatok = (string[])item.Value;
                string feltetek = string.Join(", ", pizzaAdatok.Take(pizzaAdatok.Length - 1));
                int ar = int.Parse(pizzaAdatok.Last());


                Console.WriteLine($"{item.Key, -18} | {feltetek, -50} | {ar, -5} Ft");
            }

            while (folytat)
            {
                Console.Write("Kérem a pizza azonosítóját (1-6): ");
                string azonosito = Console.ReadLine();

                if(azonosito == "0")
                {
                    Console.WriteLine("Végösszeg: " +  vegosszeg + "Ft");
                    folytat = false;
                    continue;
                }

                foreach (DictionaryEntry item in pizza)
                {
                    string pizzaNev = (string)item.Key;
                    string[] pizzaAdatok = (string[])item.Value;
                    int ar = int.Parse(pizzaAdatok.Last());
                    string feltetek = string.Join(", ", pizzaAdatok.Take(pizzaAdatok.Length - 1));

                    if (pizzaAdatok[0] == azonosito)

                    {
                        Console.WriteLine($"{pizzaNev, -25} | {pizzaAdatok[1], -20} | {feltetek, -20} | {ar, -5}");
                        vegosszeg += ar;
                        
                    }

                }

                Random rnd = 
            }

        }
    }
}
