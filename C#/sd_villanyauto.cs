using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2026._05._20_gyakorlas_2_sajat_feladat
{
    class autok
    {
        public string modell { get; set; }
        public string gyarto { get; set; }
        public int ev { get; set; }
        public int hatotav { get; set; }
        public double fogyasztas { get; set; }
        public autok(string sor)
        {
            string[] d = sor.Split('#');
            modell = d[0];
            gyarto = d[1];
            ev = int.Parse(d[2]);
            hatotav = int.Parse(d[3]);
            fogyasztas = double.Parse(d[4].Replace('.', ','));
        }
        public string bemutat()
        {
            return $"[{gyarto}] {modell} - Megjelenés: ({ev}) - Fogyasztás: {fogyasztas:F1} kWh/ 100km";
        }


    }

    class main_program
    {
        static void Main(string[] args)
        {
            List<autok> fasza_lista = new List<autok>();
            string[] sorok = File.ReadAllLines("villanyautok.txt", Encoding.UTF8);

            foreach (var sor in sorok)
            {
                fasza_lista.Add(new autok(sor));
            }

            Console.WriteLine($"Sikeresen betöltve ({fasza_lista.Count}db autó)");




            int legregebbi_id = 0;

            for (int i = 0; i < fasza_lista.Count; i++)
            {
                if (fasza_lista[i].ev < fasza_lista[legregebbi_id].ev)
                {
                    legregebbi_id = i;
                }
            }
            Console.WriteLine();
            Console.WriteLine($"A legrégebbi autó: {fasza_lista[legregebbi_id].bemutat()}");


            Console.WriteLine("Adjon meg egy minimum hatótáv értéket a kereséshez:");
            int min_hatotav = int.Parse(Console.ReadLine());
            Boolean van_e = false;

            for (int i = 0; i < fasza_lista.Count; i++)
            {
                if (fasza_lista[i].hatotav >= min_hatotav)
                {
                    Console.WriteLine(fasza_lista[i].bemutat());
                    van_e = true;
                }
            }
            if (!van_e)
            {
                Console.WriteLine("Nincs a feltételnek megfelelő autó a listában.");
            }



            HashSet<int> egyedi_evjarat = new HashSet<int>();

            foreach (var item in fasza_lista)
            {
                egyedi_evjarat.Add(item.ev);
            }
            Console.WriteLine("\nA listában szereplő egyedi évjáratok:");

            foreach (var ev in egyedi_evjarat)
            {
                int darab = 0; // Számláló az adott évhez

                // 3. lépés: Megszámoljuk a listában az ehhez az évhez tartozó autókat
                for (int i = 0; i < fasza_lista.Count; i++)
                {
                    if (fasza_lista[i].ev == ev)
                    {
                        darab++;
                    }
                }

                // 4. lépés: Kiírjuk az eredményt
                Console.WriteLine($"\t{ev}: {darab} db autó");
            }
        }
    }
}