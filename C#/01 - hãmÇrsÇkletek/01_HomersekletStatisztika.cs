// =============================================================
//  1. FELADAT MEGOLDÁSA – Hőmérséklet statisztika
//  Beolvasási mód: File.ReadAllLines (tömbbe)
//  Írási mód:      File.WriteAllText (eredmény fájlba)
// =============================================================

using System;                  // Console, kivételek alaposztályai
using System.IO;               // File osztály – a fájlműveletekhez

class Program
{
    static void Main()
    {
        // Az olvasandó fájl neve. Relatív útvonal: a program futási
        // könyvtárában keresi (rendszerint a bin/Debug/netX.X mappában).
        string bemenetiFajl = "homerseklet.txt";

        // Az írandó (eredmény-) fájl neve.
        string kimenetiFajl = "osszesites.txt";

        // ------------------------------------------------------
        // 1) Ellenőrizzük, hogy létezik-e a bemeneti fájl.
        //    Ha nem, megszakítjuk a programot egy üzenettel.
        // ------------------------------------------------------
        if (!File.Exists(bemenetiFajl))
        {
            Console.WriteLine("Hiba: a(z) " + bemenetiFajl + " fájl nem található!");
            return;   // kilépünk a Main metódusból, vége a programnak
        }

        // ------------------------------------------------------
        // 2) BEOLVASÁS – az egész fájlt sorokra bontva tömbbe.
        //    A tömb minden eleme egy sor a fájlból.
        // ------------------------------------------------------
        string[] sorok = File.ReadAllLines(bemenetiFajl);

        // Ha a fájl üres volt, a tömbnek 0 eleme van – ezt is kezeljük.
        if (sorok.Length == 0)
        {
            Console.WriteLine("A fájl üres, nincs mit feldolgozni.");
            return;
        }

        // ------------------------------------------------------
        // 3) FELDOLGOZÁS – az értékek átalakítása int-é,
        //    közben számoljuk a statisztikákat.
        // ------------------------------------------------------

        // Készítünk egy ugyanolyan méretű int tömböt, amibe
        // a beolvasott szövegeket számként eltároljuk.
        int[] homersekletek = new int[sorok.Length];

        // Inicializáljuk a min/max változókat az ELSŐ értékkel,
        // így biztosan helyes lesz az eredmény. (Ha 0-val kezdenénk,
        // és csak negatív értékek lennének, hibás eredményt kapnánk.)
        int min = int.Parse(sorok[0]);   // pillanatnyi minimum
        int max = int.Parse(sorok[0]);   // pillanatnyi maximum
        int osszeg = 0;                  // összeghez gyűjtjük
        int fagyosNapok = 0;             // számláló: hány nap volt 0 °C alatt

        // Végigmegyünk az összes soron egy hagyományos for ciklussal.
        for (int i = 0; i < sorok.Length; i++)
        {
            // A sor szövegét int-é alakítjuk (pl. "-3" -> -3).
            int ertek = int.Parse(sorok[i]);

            // Letároljuk a számtömbbe (ha később még kellene).
            homersekletek[i] = ertek;

            // Hozzáadjuk az összeghez.
            osszeg = osszeg + ertek;

            // Ha a jelenlegi érték kisebb az eddigi minimumnál,
            // frissítjük a minimumot.
            if (ertek < min)
            {
                min = ertek;
            }

            // Ha a jelenlegi érték nagyobb az eddigi maximumnál,
            // frissítjük a maximumot.
            if (ertek > max)
            {
                max = ertek;
            }

            // Fagyos nap = a hőmérséklet 0 alá ment.
            if (ertek < 0)
            {
                fagyosNapok++;   // növeljük a számlálót 1-gyel
            }
        }

        // Az átlag kiszámítása: az összeg osztva a darabszámmal.
        // FONTOS: ha int / int, akkor egész osztás lenne (csonkít).
        // Ezért legalább az egyik operandust double-re alakítjuk.
        double atlag = (double)osszeg / sorok.Length;

        // ------------------------------------------------------
        // 4) KIÍRÁS – konzolra is és FÁJLBA is.
        // ------------------------------------------------------

        // Konzolra:
        Console.WriteLine("=== Hőmérséklet-statisztika ===");
        Console.WriteLine("Napok száma:    " + sorok.Length);
        Console.WriteLine("Átlag:          " + atlag.ToString("F2") + " °C");
        Console.WriteLine("Minimum:        " + min + " °C");
        Console.WriteLine("Maximum:        " + max + " °C");
        Console.WriteLine("Fagyos napok:   " + fagyosNapok + " db");

        // Az eredmény szövegét egy stringben összeállítjuk.
        // Environment.NewLine = az adott rendszer sortörése
        // (Windows-on \r\n, Linux-on \n).
        string eredmeny =
            "=== Hőmérséklet-statisztika ===" + Environment.NewLine +
            "Napok száma:  " + sorok.Length + Environment.NewLine +
            "Átlag:        " + atlag.ToString("F2") + " °C" + Environment.NewLine +
            "Minimum:      " + min + " °C" + Environment.NewLine +
            "Maximum:      " + max + " °C" + Environment.NewLine +
            "Fagyos napok: " + fagyosNapok + " db" + Environment.NewLine;

        // Az összeállított szöveget egyszerre kiírjuk a fájlba.
        // Ha a fájl már létezik, FELÜLÍRJA!
        File.WriteAllText(kimenetiFajl, eredmeny);

        Console.WriteLine();
        Console.WriteLine("Az eredményt kiírtuk ide: " + kimenetiFajl);
    }
}
