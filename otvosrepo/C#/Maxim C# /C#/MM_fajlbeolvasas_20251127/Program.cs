using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace MM_fajlbeolvasas_20251127
{
    internal class Program
    {
        /*
         * MM_fajlbeolvasas_20251127
         * 2025.11.27
         */
        static void Main(string[] args)
        {
            Console.WriteLine("MM - Fájlbeolvasás\n2025.11.27\n----------");

            StreamReader be = new StreamReader("igeny.txt", Encoding.UTF8);
            string sor;
            string[] reszek;

            int szintek_szama = Convert.ToInt32(be.ReadLine());
            int csapatok_szama = Convert.ToInt32(be.ReadLine());
            int igenyek_szama = Convert.ToInt32(be.ReadLine());

           // Console.WriteLine($"Szintek száma: {szintek_szama} | Csapatok száma: {csapatok_szama} | Igények száma: {igenyek_szama}");

            for ( int sorszam = 1; sorszam <= igenyek_szama; sorszam++ )
            {
                //Console.WriteLine($"{sorszam} × {be.ReadLine()}");
                sor = be.ReadLine();
                reszek = sor.Split(' ');
                // 9 3 14 3 10 17 -> 3. csapat - 10. szint, érkezik: 17. szint, 9 óra 3 perc 14 másodperc
                Console.WriteLine($"{reszek[3],2}. csapat - {reszek[4],2}. szint, érkezik: {reszek[5],2}. szint, {reszek[0],2} óra {reszek[1],2} perc {reszek[2],2} másodperc");

                be.Close();
            }
        }
    }
}
