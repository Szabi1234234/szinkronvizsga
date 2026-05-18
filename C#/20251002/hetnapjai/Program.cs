using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hetnapjai
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*
             * MM - Hét napjai 
             * 2025.10.02
             */
            Console.WriteLine("MM - Hét napjai\n2025.10.02\n----------");

            string[] napok = { "hétfő", "kedd", "szerda", "csütörtök", "péntek", "szombat", "vasárnap"};
            Console.WriteLine($"A 0. indexű nap: {napok[0]}");
            Console.WriteLine($"A 3. napja a hétnek: {napok[2]}");
            Console.WriteLine($"A szombat a hét: {napok[5]}");

            Console.Write("Kérlek adj meg egy számot 1-7 között: ");
            int bekertSzam = Convert.ToInt32(Console.ReadLine());
            if (bekertSzam < 1 || bekertSzam > 7)
            {
                Console.WriteLine("Hibás adat! Csak 1-7 közötti számot adhatsz meg!");
                return;
            }
            Console.WriteLine($"A hét {bekertSzam}. napja: {napok[bekertSzam-1]}");
        }
    }
}
