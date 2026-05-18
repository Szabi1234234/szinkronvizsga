using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace homerseklet
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*
             * MM - Hőmérséklet szorgalmi
             */
            Random rnd = new Random();

            Console.WriteLine("Hőmérséklet szorgalmi\nMolnár Maxim - 2025.10.09\n---------------------");
            int homerseklet = rnd.Next(-2, 19);
            int[] homersekletek = new int[24];
            int elso_ho = homerseklet;
            int atlag_ho = 0;
            int[] ora = new int[24];
            for (int i = 1; i < ora.Length; i++)
            {
                ora[i] = i;
            }
            for (int i = 0; i < 16; i++)
            {
                homerseklet = homerseklet + rnd.Next(0,4);
                homersekletek[i] = homerseklet;
                Console.WriteLine($"{ora[i]}:00 - {homerseklet}°C");
                atlag_ho = homerseklet + atlag_ho;

            }
            for (int i = 16; i < ora.Length; i++)
            {
                homerseklet = homerseklet - rnd.Next(0,4);
                homersekletek[i] = homerseklet;
                Console.WriteLine($"{ora[i]}:00 - {homerseklet}°C");
                atlag_ho = homerseklet + atlag_ho;
                
            }

            Console.WriteLine($"\n\nNapi első hőmérséklet: {elso_ho}°C");
            Console.WriteLine($"Napi legutolsó hőmérséklet: {homerseklet}°C");
            Console.WriteLine($"Napi átlaghőmérséklet: {atlag_ho/24}°C");
            Console.WriteLine($"Napi csúcshőmérséklet: {homersekletek.Max()}°C");


        }
    }
}
