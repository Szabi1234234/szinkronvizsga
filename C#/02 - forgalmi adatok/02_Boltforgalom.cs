// =============================================================
//  2. FELADAT MEGOLDÁSA – Boltforgalom (CSV)
//  Beolvasási mód: File.ReadAllText (egész fájl egy stringbe)
//                  + Split (sorokra és mezőkre bontás)
//  Írási mód:      konzol (Console.WriteLine)
// =============================================================

using System;
using System.IO;

class Program
{
    static void Main()
    {
        // A CSV fájl neve.
        string fajl = "eladasok.csv";

        // Ellenőrzés: létezik-e a fájl?
        if (!File.Exists(fajl))
        {
            Console.WriteLine("A fájl nem található: " + fajl);
            return;
        }

        // ------------------------------------------------------
        // 1) BEOLVASÁS – az EGÉSZ fájl tartalmát egyetlen
        //    string-be olvassuk be.
        // ------------------------------------------------------
        string tartalom = File.ReadAllText(fajl);

        // Most felbontjuk a szöveget sorokra a sortörés mentén.
        // A '\n' a Unix-féle sortörés.
        // A StringSplitOptions.RemoveEmptyEntries gondoskodik arról,
        // hogy ha a fájl végén üres sor van, azt KIHAGYJUK.
        string[] sorok = tartalom.Split(
            new char[] { '\n', '\r' },                 // több elválasztó is lehet
            StringSplitOptions.RemoveEmptyEntries      // üres sorokat kihagy
        );

        // Az első sor a fejléc (Termek;Darab;EgysegAr), ezzel nem
        // foglalkozunk; az adatok a 2. sortól (index 1) kezdődnek.
        // Ezért a feldolgozandó sorok száma sorok.Length - 1.
        int termekekSzama = sorok.Length - 1;

        // ------------------------------------------------------
        // 2) Tömbök az adatoknak (LINQ helyett klasszikus tömbök).
        // ------------------------------------------------------
        string[] nevek    = new string[termekekSzama];
        int[]    darabok  = new int[termekekSzama];
        int[]    arak     = new int[termekekSzama];

        // ------------------------------------------------------
        // 3) FELDOLGOZÁS – minden adatsort feldarabolunk.
        // ------------------------------------------------------
        // i = 1, mert a 0. sor a fejléc, azt átugorjuk.
        for (int i = 1; i < sorok.Length; i++)
        {
            // A sort pontosvessző mentén feldaraboljuk.
            // pl. "Kenyer;25;450" -> ["Kenyer", "25", "450"]
            string[] mezok = sorok[i].Split(';');

            // A "céltömb" indexe i-1, mert a 0-s sorral (fejléc)
            // nem foglalkoztunk.
            int index = i - 1;

            nevek[index]   = mezok[0];                 // 1. mező: terméknév
            darabok[index] = int.Parse(mezok[1]);      // 2. mező: darabszám
            arak[index]    = int.Parse(mezok[2]);      // 3. mező: egységár
        }

        // ------------------------------------------------------
        // 4) STATISZTIKÁK számítása klasszikus ciklusokkal.
        // ------------------------------------------------------

        int teljesBevetel = 0;          // a teljes bevétel összesítve
        int legtobbDarab = darabok[0];  // a legtöbbet eladott darabszám
        int legtobbIndex = 0;           // melyik termékből adtak el legtöbbet
        int legdragabbAr = arak[0];     // a legdrágább termék ára
        int legdragabbIndex = 0;        // melyik a legdrágább termék

        for (int i = 0; i < termekekSzama; i++)
        {
            // Egy termékre eső bevétel = darab × egységár
            int bevetel = darabok[i] * arak[i];

            // Hozzáadjuk a teljes bevételhez.
            teljesBevetel = teljesBevetel + bevetel;

            // Ha ebből a termékből többet adtak el, mint az eddigi
            // rekorderből, frissítjük az adatokat.
            if (darabok[i] > legtobbDarab)
            {
                legtobbDarab = darabok[i];
                legtobbIndex = i;        // megjegyezzük a tömbbeli indexét
            }

            // Ha ez a termék drágább az eddigi legdrágábbnál:
            if (arak[i] > legdragabbAr)
            {
                legdragabbAr = arak[i];
                legdragabbIndex = i;
            }
        }

        // ------------------------------------------------------
        // 5) KIÍRÁS – konzolra szépen tagolva.
        // ------------------------------------------------------
        Console.WriteLine("=== Napi forgalom kimutatása ===");
        Console.WriteLine("Termékek száma:        " + termekekSzama);
        Console.WriteLine("Teljes bevétel:        " + teljesBevetel + " Ft");
        Console.WriteLine();
        Console.WriteLine("Legtöbbet eladott:     "
            + nevek[legtobbIndex] + " (" + legtobbDarab + " db)");
        Console.WriteLine("Legdrágább termék:     "
            + nevek[legdragabbIndex] + " (" + legdragabbAr + " Ft)");

        // Bónusz: termékenkénti részletes kiírás.
        Console.WriteLine();
        Console.WriteLine("Részletes bontás:");
        for (int i = 0; i < termekekSzama; i++)
        {
            int sorBevetel = darabok[i] * arak[i];
            // PadRight: jobbra üres karakterekkel tölti a szöveget
            // megadott hosszúságúra (szép tabláshoz).
            Console.WriteLine("  " + nevek[i].PadRight(10)
                + " " + darabok[i].ToString().PadLeft(3) + " db × "
                + arak[i].ToString().PadLeft(5) + " Ft = "
                + sorBevetel + " Ft");
        }
    }
}
