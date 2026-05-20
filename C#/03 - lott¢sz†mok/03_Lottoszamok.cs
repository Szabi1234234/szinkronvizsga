// =============================================================
//  3. FELADAT MEGOLDÁSA – Lottószám statisztika
//  Írási mód:      StreamWriter (using blokkban)
//  Beolvasási mód: StreamReader + while ciklus (sorról sorra)
// =============================================================

using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Fájlnév, ahova írunk és ahonnan olvasunk.
        string fajl = "lotto.txt";

        // Hány számot generáljunk.
        int szamokCount = 200;

        // ============================================
        // 1. RÉSZ – VÉLETLENSZÁMOK GENERÁLÁSA ÉS ÍRÁSA
        // ============================================

        // A Random osztály álvéletlen számokat generál.
        // FONTOS: egyszer példányosítjuk, és ezt használjuk
        // minden generáláshoz! (Ha gyors egymásutánban hoznánk
        // létre több Random-ot, ugyanazt a számot adhatnák.)
        Random rnd = new Random();

        // A "using" blokk biztosítja, hogy a fájl bezáruljon
        // a blokk végén, akkor is, ha hiba történne közben.
        // A StreamWriter konstruktor létrehozza vagy felülírja a fájlt.
        using (StreamWriter sw = new StreamWriter(fajl))
        {
            // 200 véletlen lottószám írása (1-90 közötti egészek).
            for (int i = 0; i < szamokCount; i++)
            {
                // rnd.Next(1, 91): véletlenszám 1 és 90 között
                // (a felső határ, 91, már NEM benne van).
                int szam = rnd.Next(1, 91);

                // sw.WriteLine: kiír egy sort és sortörést tesz utána.
                sw.WriteLine(szam);
            }
        }   // <-- itt a "using" lezárja a fájlt automatikusan

        Console.WriteLine("Generálva: " + szamokCount + " véletlen lottószám.");
        Console.WriteLine("Fájl: " + fajl);
        Console.WriteLine();

        // ============================================
        // 2. RÉSZ – VISSZAOLVASÁS ÉS STATISZTIKA
        // ============================================

        // Egy 91 elemű tömböt készítünk (indexek 0-tól 90-ig).
        // A 0-s indexet nem fogjuk használni, így a szám maga
        // egyenesen az indexe lehet: pl. eloFordul[42] = 42-es
        // számból hány darab fordult elő.
        int[] eloFordul = new int[91];

        // Megnyitjuk a fájlt olvasásra StreamReader-rel.
        // (Memóriabarát módszer: nem tölti be egészben a fájlt.)
        using (StreamReader sr = new StreamReader(fajl))
        {
            // A "string?" jelentése: lehet null is.
            string? sor;

            // ReadLine() egy sort olvas; ha vége a fájlnak, null-t ad.
            // Az értékadás zárójelben van, így a while feltétele
            // a beolvasott érték null-tól való különbözősége.
            while ((sor = sr.ReadLine()) != null)
            {
                // A beolvasott szöveget int-é alakítjuk.
                int szam = int.Parse(sor);

                // Növeljük az adott számhoz tartozó számlálót.
                // (Pl. ha a fájlban "42" volt, akkor
                // eloFordul[42] eggyel nő.)
                eloFordul[szam]++;
            }
        }   // <-- fájl bezárása

        // ------------------------------------------------------
        // 3) Statisztika: melyik szám fordult elő a legtöbbször?
        // ------------------------------------------------------
        int maxElofordulas = 0;       // a legnagyobb előfordulás
        int maxSzam = 0;              // melyik szám az?

        // Végigmegyünk az 1-90 indexeken.
        for (int i = 1; i <= 90; i++)
        {
            if (eloFordul[i] > maxElofordulas)
            {
                maxElofordulas = eloFordul[i];
                maxSzam = i;
            }
        }

        // Hány különböző szám fordult elő egyáltalán?
        int kulonbozoSzamok = 0;
        for (int i = 1; i <= 90; i++)
        {
            if (eloFordul[i] > 0)
            {
                kulonbozoSzamok++;
            }
        }

        // Hány szám NEM jött ki egyszer sem?
        int kihagyottak = 90 - kulonbozoSzamok;

        // ------------------------------------------------------
        // 4) KIÍRÁS – konzolra.
        // ------------------------------------------------------
        Console.WriteLine("=== Lottószám statisztika ===");
        Console.WriteLine("Generált számok:           " + szamokCount);
        Console.WriteLine("Különböző számok:          " + kulonbozoSzamok);
        Console.WriteLine("Egyszer sem húzott számok: " + kihagyottak);
        Console.WriteLine("Leggyakoribb szám:         " + maxSzam
            + " (" + maxElofordulas + " alkalommal)");

        // Bónusz: a TOP 5 leggyakoribb szám kiírása.
        // Ehhez "kimaszkoljuk" a már megtaláltakat.
        Console.WriteLine();
        Console.WriteLine("TOP 5 leggyakoribb szám:");

        // Másoljuk át egy ideiglenes tömbbe, hogy ne rontsuk el az eredetit.
        int[] masolat = new int[91];
        for (int i = 0; i < 91; i++)
        {
            masolat[i] = eloFordul[i];
        }

        // 5 menetben mindig kiválasztjuk a legnagyobbat,
        // majd "kinullázzuk" a másolatban.
        for (int n = 1; n <= 5; n++)
        {
            int legjobb = 0;
            int legjobbHely = 0;
            for (int i = 1; i <= 90; i++)
            {
                if (masolat[i] > legjobb)
                {
                    legjobb = masolat[i];
                    legjobbHely = i;
                }
            }
            Console.WriteLine("  " + n + ". hely: "
                + legjobbHely + " szám – " + legjobb + " db");
            masolat[legjobbHely] = 0;   // hogy ne találjuk meg újra
        }
    }
}
