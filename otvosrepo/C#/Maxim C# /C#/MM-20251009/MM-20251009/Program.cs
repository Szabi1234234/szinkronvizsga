using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MM_20251009
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * MM - 2025.10.09
             * Dolgozat
             */
            Console.WriteLine("MM - 2025.10.09\nDolgozat\n--------");


            //1. Üdvözlés
            Console.WriteLine("1 - Üdvözlés");
            Console.Write("Add meg a keresztnevet: ");
            string keresztnev = Console.ReadLine();
            Console.Write("Add meg a vezetéknevet: ");
            string vezeteknev = Console.ReadLine();
            Console.WriteLine($"Üdv, {vezeteknev} {keresztnev}!");

            //2. 5 random szám
            Console.WriteLine("\n2 - 5 random szám");
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                int gen_szam = rnd.Next(1, 90 + 1);
                Console.Write(gen_szam + ", ");
            }
            //3. 15 termék
            Console.WriteLine("\n\n3 - 15 termék");
            int ossz_mennyiseg = 0;
            for (int i = 1; i < 16; i++)
            {
                int generalt_mennyiseg = rnd.Next(1, 100 + 1);
                ossz_mennyiseg = ossz_mennyiseg + generalt_mennyiseg;
                Console.WriteLine($"{i}. termék: {generalt_mennyiseg} db");
            }
            Console.WriteLine($"Összesen: {ossz_mennyiseg} db");

            //4. Gumiabroncsok
            Console.WriteLine("\n4 - Gumiabroncsok");
            int mennyi = 0;
            int atlag_szam = 0;
            Console.Write("Mennyi gumiabroncsot szeretne megjeleníteni? ");
            mennyi = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i < mennyi + 1; i++)
            {
                int meret = rnd.Next(14, 21 + 1);
                int ar = rnd.Next(15800, 50341);
                Console.WriteLine($"{i}. {meret} col {ar} Ft");
                atlag_szam = atlag_szam + ar;

            }
            int atlag = atlag_szam / mennyi;
            Console.WriteLine($"Átlagár: {atlag} Ft");

            System.Threading.Thread.Sleep(2000);

            //5. Halak - tömbök
            Console.WriteLine("\n5 - Halak");
            double atlag_suly = 0;
            double[] suly = new double[20];
            string[] halak = new string[19] {"keszeg", "ponty", "csuka", "harcsa", "süllő", "kárász", "angolna", "márna", "fogasponty", "sügér", "amur", "menyhal", "domolykó", "keszeg", "garda", "paduc", "compó", "bodorka", "nyúldomolykó"};
            for (int i = 0; i < suly.Length; i++)
            {
                suly[i] = 0.5 + (rnd.NextDouble() * 11);
                Console.WriteLine($"{i}. hal - {halak[rnd.Next(1, 19)]} --> {suly[i]:N3} kg");
                atlag_suly += suly[i];
            }
            Console.WriteLine($"Legkönnyebb hal: {suly.Min():N3} kg");
            Console.WriteLine($"Legnehezebb hal: {suly.Max():N3} kg");
            Console.WriteLine($"Átlag súly: {(atlag_suly/suly.Length):N3} kg");



        }   


    }
}
