using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM_csapadek
{
    class Program
    {
        // MM - Csapadék
        // 2026.01.29
        static void Main(string[] args)
        {
            Console.WriteLine("MM - Csapadék\n2026.01.29\n-----------");
            StreamReader be = new StreamReader("csapadek.txt");
            List<int> lista = new List<int>();

            while (!be.EndOfStream)
            {
                string sor = be.ReadLine();
                lista.Add(int.Parse(sor));
            }
            be.Close();

            int[] adatok = lista.ToArray();

            Console.WriteLine("Csapadék-statisztika");

            Console.WriteLine($"A beolvasott adatok száma: {adatok.Length}");

            for (int i = 0; i < adatok.Length; i++)
            {
                Console.Write(adatok[i]);
                if (i < adatok.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();

            double osszeg = 0;
            int legnagyobb = adatok[0];

            for (int i = 0; i < adatok.Length; i++)
            {
                osszeg += adatok[i];
                if (adatok[i] > legnagyobb)
                {
                    legnagyobb = adatok[i];
                }
            }

            double atlag = osszeg / adatok.Length;

            Console.WriteLine($"Az átlagos csapadék-mennyiség: {atlag:0.0}");
            Console.WriteLine($"A legnagyobb érték: {legnagyobb}");

        }
    }
}