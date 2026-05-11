using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace csapadek_statisztika
{
    internal class Program
    {
        // 1. eljárás: kiírja az adatok számát
        static void AdatokSzama(int[] csapadek)
        {
            Console.WriteLine("A beolvasott adatok száma: " + csapadek.Length);
        }

        // 2. eljárás: kiírja az adatokat egy sorban, vesszővel elválasztva
        static void AdatokKiirasa(int[] csapadek)
        {
            string sor = "";
            for (int i = 0; i < csapadek.Length; i++)
            {
                if (i > 0) sor += ", ";
                sor += csapadek[i];
            }
            Console.WriteLine(sor);
        }

        // 3. függvény: visszaadja az átlagos csapadékmennyiséget
        static double Atlag(int[] csapadek)
        {
            int osszeg = 0;
            for (int i = 0; i < csapadek.Length; i++)
            {
                osszeg += csapadek[i];
            }
            return (double)osszeg / csapadek.Length;
        }

        // 4. függvény: visszaadja a legnagyobb csapadékértéket
        static int Maximum(int[] csapadek)
        {
            int max = csapadek[0];
            for (int i = 1; i < csapadek.Length; i++)
            {
                if (csapadek[i] > max)
                    max = csapadek[i];
            }
            return max;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Csapadék-statisztika");

            // Fájl beolvasása tömbbe
            string[] sorok = File.ReadAllLines("csapadek.txt");
            int[] csapadek = new int[sorok.Length];
            for (int i = 0; i < sorok.Length; i++)
            {
                csapadek[i] = int.Parse(sorok[i]);
            }

            AdatokSzama(csapadek);
            AdatokKiirasa(csapadek);
            Console.WriteLine("Az átlagos csapadék-mennyiség: " + Atlag(csapadek));
            Console.WriteLine("A legnagyobb érték: " + Maximum(csapadek));

            Console.ReadLine();
        }
    }
    
}
