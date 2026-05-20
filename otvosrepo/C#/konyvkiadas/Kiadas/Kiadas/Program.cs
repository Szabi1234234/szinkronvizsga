using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // A fájlkezelő műveletekhez (File, StreamWriter) szükséges

namespace fajlbeolvasas
{
    internal class Program
    {
        // 1. OBJEKTUMOSZTÁLY: Ez a sablon, ami leírja, hogyan néz ki egy könyv adata
        class Konyv
        {
            // Tulajdonságok (Properties) - az adatszerkezet oszlopai
            public int Ev { get; set; }
            public int NEv { get; set; }
            public string Orsz { get; set; }
            public string LeIras { get; set; }
            public int Peldany { get; set; }

            // Konstruktor: Ez dolgozza fel a fájl egyetlen sorát
            public Konyv(string sor) 
            {
                // A sort pontosvessző mentén feldaraboljuk egy tömbbe
                string[] d = sor.Split(';');
                
                // Az adatokat a megfelelő típusra alakítva rendeljük a tulajdonságokhoz
                Ev = int.Parse(d[0]);      // Egész szám: Kiadás éve
                NEv = int.Parse(d[1]);     // Egész szám: Azonosító vagy egyéb szám
                Orsz = d[2];               // Szöveg: Ország
                LeIras = d[3];             // Szöveg: Szerző és cím
                Peldany = int.Parse(d[4]); // Egész szám: Példányszám
            }

            // Metódus az adatok szép megjelenítéséhez a konzolon
            public void KiIr()
            {
                // A -113 a szöveg szélességét (formázását) jelenti
                Console.WriteLine($"{Ev}|{NEv}| {Orsz}|{LeIras, -113}|{Peldany} ");
            }
        }

        static void Main(string[] args)
        {
            // 2. BEOLVASÁS
            // Lista létrehozása, amiben a Konyv típusú objektumokat tároljuk
            List<Konyv> konyvek = new List<Konyv>();

            // Az összes sor beolvasása egy tömbbe (Encoding.Default az ékezetek miatt)
            string[] sorok = File.ReadAllLines("kiadas.txt", Encoding.Default);

            // Ciklus a sorokon: i = 1-től indul, hogy a fejlécet ÁTUGRÓDJA
            for (int i = 1; i < sorok.Length; i++)
            {
                // Csak akkor dolgozzuk fel, ha a sor nem üres
                if (!string.IsNullOrWhiteSpace(sorok[i]))
                {
                    Konyv k = new Konyv(sorok[i]); // Létrehozunk egy könyv objektumot
                    konyvek.Add(k);               // Hozzáadjuk a listához
                    k.KiIr();                      // Megjelenítjük (opcionális)
                }
            }

            // 3. MEGSZÁMLÁLÁS: Szerző keresése
            Console.WriteLine("\nÍrja be egy szerző nevét: ");
            string szerzo = Console.ReadLine();

            int db = 0;
            foreach (var k in konyvek)
            {
                // Megnézzük, hogy a leírás tartalmazza-e a beírt szöveget
                if (k.LeIras.Contains(szerzo)) 
                {
                    db++;
                }
            }
            
            if (db > 0)
                Console.WriteLine($"A szerzőnek {db} konyvét adták ki.");
            else
                Console.WriteLine("Nincs ilyen szerző a listában.");

            // 4. MAXIMUM KERESÉS: A legtöbb példányszám megtalálása
            Konyv max = konyvek[0]; // Feltételezzük, hogy az első a legnagyobb
            foreach (var k in konyvek)
            {
                if (k.Peldany > max.Peldany)
                {
                    max = k; // Ha találunk nagyobbat, lecseréljük a referenciát
                }
            }
            Console.WriteLine("\nA legnagyobb példányszámú kiadvány:");
            max.KiIr();

            // 5. STATISZTIKA (Évenkénti összesítés)
            // HashSet-be gyűjtjük az egyedi éveket (ebben nem lehet ismétlődés)
            HashSet<int> evek = new HashSet<int>();
            foreach (var k in konyvek)
            {
                evek.Add(k.Ev);
            }

            Console.WriteLine("\nÉv | Kiadott könyv db | Össz példányszám");
            foreach (var e in evek)
            {
                int evesDb = 0;
                int osszeg = 0;
                foreach (var k in konyvek)
                {
                    if(k.Ev == e)
                    {
                        evesDb++;
                        osszeg += k.Peldany;
                    }
                }
                Console.WriteLine($"{e}|{evesDb, -14}|{osszeg}");
            }

            // 6. FÁJLBA ÍRÁS (Markdown formátumban)
            // A 'using' biztosítja, hogy a fájl a folyamat végén lezáruljon
            using (StreamWriter sw = new StreamWriter("bartos.md", false, Encoding.UTF8))
            {
                // Táblázat fejléce
                sw.WriteLine("|Év|Leírás|Példány|");
                sw.WriteLine("|:---|:---|---:|");
                
                foreach (var k in konyvek)
                {
                    // Szűrés egy konkrét szerzőre
                    if(k.LeIras.Contains("Bartos Erika"))
                    {
                        sw.WriteLine($"|{k.Ev}|{k.LeIras}|{k.Peldany}|");
                    }
                }
            } // Itt automatikusan lezárul a fájl
            
            Console.WriteLine("\nA fájlba írás befejeződött.");
            Console.ReadKey(); // Megállítja a programot, hogy lásd az eredményt
        }
    }
}