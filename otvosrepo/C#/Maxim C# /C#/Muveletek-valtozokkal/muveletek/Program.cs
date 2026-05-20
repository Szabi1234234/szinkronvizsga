using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muveletek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * MM - Alapmuveletek
             * 2025.09.18.
             */
            Console.WriteLine("MM - Alapműveletek\n2025.09.18.\n-----------");


            /*
            int a = 7;
            int b = 3;
            */
            Random rnd = new Random();
            int a = rnd.Next(1, 90 + 1);
            int b = rnd.Next(1, 90 +1);
            int c;

            //Összeadás
            c = a + b;
            Console.WriteLine($"Összeadás: {a} + {b} = {c}");
            
            //Kivonás
            c = a - b;
            Console.WriteLine($"Kivonás: {a} - {b} = {c}");
        
            c = a * b;
            Console.WriteLine($"Szorzás: {a} * {b} = {c}");
        
            //Maradéktalan osztás
            c = a / b;
            Console.WriteLine($"Osztás: {a} / {b} = {c}");

            //Maradékos osztás
            c = a % b;
            Console.WriteLine($"Maradékos osztás: {a} % {b} = {c}");

            //Értéknövelés
            a += 2;
            b += 5;

            Console.WriteLine($"a = {a} | b = {b}");

            //Értékcsökkentés
            c--; // c = c-1
            Console.WriteLine($"c = {c}");


        
        }
    }
}
