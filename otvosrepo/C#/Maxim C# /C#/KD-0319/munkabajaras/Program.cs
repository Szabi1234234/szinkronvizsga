using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace munkabajaras
{
    internal class Program
    {
        // ELJÁRÁS: kiírja a tömb elemeit mértékegységgel
        static void KiirUtazasiIdo(string[] napok, int[] utazasiIdo)
        {
            Console.WriteLine("A heti utazási idő");
            for (int i = 0; i < napok.Length; i++)
            {
                Console.WriteLine($"{napok[i],-12}: {utazasiIdo[i]} perc");
            }
        }

        // FÜGGVÉNY: kiszámítja és visszaadja az átlagos utazási időt
        static double AtlagSzamitas(int[] utazasiIdo)
        {
            double osszeg = 0;
            foreach (int ido in utazasiIdo)
            {
                osszeg += ido;
            }
            return osszeg / utazasiIdo.Length;
        }


        static void Main(string[] args)
        {
            string[] napok = { "Hétfő", "Kedd", "Szerda", "Csütörtök", "Péntek" };
            int[] utazasiIdo = new int[5];

            // a) Párbeszédes adatbekérés és tömbben tárolás
            for (int i = 0; i < napok.Length; i++)
            {
                Console.Write($"Az utazási idő {napok[i]} (percben): ");
                utazasiIdo[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine();

            // b) Kiírás eljárással
            KiirUtazasiIdo(napok, utazasiIdo);

            // c) Átlag kiszámítása függvénnyel és kiírása
            double atlag = AtlagSzamitas(utazasiIdo);
            Console.WriteLine($"\nAz átlagos utazási idő: {atlag} perc.");

            Console.ReadLine();
        }
    }
}
