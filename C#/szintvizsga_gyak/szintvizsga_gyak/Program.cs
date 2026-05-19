using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;


namespace szintvizsga_gyak
{
    class Autok
    {
        public string Modell { get; set; }
        public string Gyarto { get; set; }
        public int GyartasiEv { get; set; }
        public int Hatotav { get; set; }
        public double Fogyasztas { get; set; }

        public Autok(string sor)
        {
            string[] d = sor.Split('#');
            Modell = d[0];
            Gyarto = d[1];
            GyartasiEv = int.Parse(d[2]);
            Hatotav = int.Parse(d[3]);
            Fogyasztas = double.Parse(d[4].Replace('.', ','));
        }

        public string Kiir()
        {
            return $"[{Gyarto}] {Modell} ({GyartasiEv}) - Hatotáv: {Hatotav} km"; 
        }
     }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Autok> autok = new List<Autok>();
            string[] sorok = File.ReadAllLines("villanyautok.txt");
            foreach (var sor in sorok)
            {
                autok.Add(new Autok(sor));
            }

            Console.Write("Modellnév vagy részlet: ");
            string keresett = Console.ReadLine().ToLower();
            var talalatok = autok.Where(a => a.Modell.ToLower().Contains(keresett)).ToList();

            if (talalatok.Any())
            {
                foreach (var a in talalatok)
                {
                    Console.WriteLine(a.Kiir());
                }
            }
            else
            {
                Console.WriteLine("\tNincs ilyen modell");
            }

            if (talalatok.Count > 0)
            {
                Autok maxAuto = autok[0];

                for (int i = 1; i < autok.Count; i++)
                {
                    if (autok[i].Hatotav > maxAuto.Hatotav)
                    {
                        maxAuto = autok[i];
                    }
                }
                Console.WriteLine("A legnagyobb hatótávú autó adatai: ");
                Console.WriteLine(maxAuto.Kiir());

            }

            Console.WriteLine("Gyártói statisztika (Modellszám és generációs megoszlás):");
            Console.WriteLine($"\t{"Gyártó",-20} | {"Összesen",-10} | {"2020 utáni modell"}");
            Console.WriteLine("\t" + new string('-', 60));

            var stat = autok.GroupBy(a => a.Gyarto);

            foreach (var csoport in stat)
            {
                int osszes = csoport.Count();
                int ujgeneracio = 0;

                foreach (var auto in csoport)
                {
                    if (auto.GyartasiEv >= 2020)
                    {
                        ujgeneracio++;
                    }
                }
                Console.WriteLine($"\t{csoport.Key,-20} | Összesen: {osszes,2} db | Új (2020+): {ujgeneracio,2} db");

            }
            try
            {
                using (StreamWriter sw = new StreamWriter("hatekony.md", false, Encoding.UTF8))
                {
                    sw.WriteLine("| Modell | Gyártó | Fogyasztás |");
                    sw.WriteLine("| :--- | :---: | :---: |");

                    // Szűrés a 15.0 alatti fogyasztású ("hatékony") autókra
                    var hatekonyak = autok.Where(a => a.Fogyasztas < 15.0);
                    foreach (var a in hatekonyak)
                    {
                        sw.WriteLine($"| {a.Modell} | {a.Gyarto} | {a.Fogyasztas:0.1} |");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("HIba!");
            }

            Console.ReadKey();
            }
    
        }
    }

