// =============================================================
//  5. FELADAT MEGOLDÁSA – Dolgozat eredmények és osztályzás
//  Beolvasási mód: StreamReader + while ciklus + Split (CSV)
//  Írási mód:      StreamWriter (új CSV fájlba)
// =============================================================

using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Bemeneti és kimeneti fájl nevek.
        string bemenetiFajl = "dolgozat.csv";
        string kimenetiFajl = "jegyek.csv";

        // Ellenőrzés.
        if (!File.Exists(bemenetiFajl))
        {
            Console.WriteLine("Hiba: a(z) " + bemenetiFajl + " fájl nem található!");
            return;
        }

        // ============================================
        // 1) Először MEGSZÁMOLJUK, hány adatsor van a fájlban,
        //    hogy tudjuk, mekkora tömböt készítsünk.
        //    (Ehhez egyszer végigolvassuk a fájlt.)
        // ============================================
        int sorokSzama = 0;
        using (StreamReader sr = new StreamReader(bemenetiFajl))
        {
            string? sor;
            while ((sor = sr.ReadLine()) != null)
            {
                sorokSzama++;   // minden olvasott sornál növelünk
            }
        }

        // Az ELSŐ sor a fejléc, nem adat – ezért -1.
        int diakokSzama = sorokSzama - 1;

        // Tömbök az adatoknak.
        string[] nevek      = new string[diakokSzama];
        int[]    pontszamok = new int[diakokSzama];
        int[]    jegyek     = new int[diakokSzama];

        // ============================================
        // 2) Beolvasás StreamReader-rel, sorról sorra
        //    (memóriabarát módszer).
        // ============================================
        using (StreamReader sr = new StreamReader(bemenetiFajl))
        {
            // Egy számláló, amely jelzi, hányadik adatsornál tartunk.
            // (A fejlécet kihagyjuk, így az index 0-tól indul.)
            int aktualis = 0;

            // Egy logikai változó, amely jelzi, hogy az első
            // (fejléc) sort már kihagytuk-e.
            bool elsoSorKihagyva = false;

            string? sor;
            while ((sor = sr.ReadLine()) != null)
            {
                // Az ELSŐ sort átugorjuk (fejléc: Nev;Pontszam).
                if (!elsoSorKihagyva)
                {
                    elsoSorKihagyva = true;
                    continue;   // ugrás a ciklus következő iterációjára
                }

                // A sort pontosvessző mentén feldaraboljuk.
                // pl. "Kovacs Anna;87" -> ["Kovacs Anna", "87"]
                string[] mezok = sor.Split(';');

                // Elmentjük a tömbökbe.
                nevek[aktualis]      = mezok[0];
                pontszamok[aktualis] = int.Parse(mezok[1]);

                // JEGYSZÁMÍTÁS pontszám alapján.
                int pont = pontszamok[aktualis];
                int jegy;

                if (pont >= 85)
                {
                    jegy = 5;     // jeles
                }
                else if (pont >= 70)
                {
                    jegy = 4;     // jó
                }
                else if (pont >= 55)
                {
                    jegy = 3;     // közepes
                }
                else if (pont >= 40)
                {
                    jegy = 2;     // elégséges
                }
                else
                {
                    jegy = 1;     // elégtelen
                }

                jegyek[aktualis] = jegy;

                aktualis++;   // a következő diákhoz lépünk
            }
        }

        // ============================================
        // 3) Eredmények ÍRÁSA új CSV fájlba.
        // ============================================
        using (StreamWriter sw = new StreamWriter(kimenetiFajl))
        {
            // Fejléc.
            sw.WriteLine("Nev;Pontszam;Jegy");

            // Diákok adatai.
            for (int i = 0; i < diakokSzama; i++)
            {
                // Egy sor: "Kovacs Anna;87;5"
                sw.WriteLine(nevek[i] + ";" + pontszamok[i] + ";" + jegyek[i]);
            }
        }   // <-- fájl bezárása

        // ============================================
        // 4) STATISZTIKA – jegyek eloszlása.
        //    Egy 6 elemű tömb (indexek 0-5). A 0-s indexet nem
        //    használjuk; jegyDarabok[3] = hány hármast adtunk.
        // ============================================
        int[] jegyDarabok = new int[6];

        // Az osztály összesített pontszámának kiszámolása az átlaghoz.
        int pontOsszeg = 0;

        for (int i = 0; i < diakokSzama; i++)
        {
            int j = jegyek[i];     // az aktuális diák jegye
            jegyDarabok[j]++;      // növeljük az adott jegy számlálóját
            pontOsszeg = pontOsszeg + pontszamok[i];
        }

        // Az osztály átlagpontszáma.
        double atlagPont = (double)pontOsszeg / diakokSzama;

        // ------------------------------------------------------
        // 5) KIÍRÁS – konzolra.
        // ------------------------------------------------------
        Console.WriteLine("=== Dolgozat eredmények ===");
        Console.WriteLine("Diákok száma:        " + diakokSzama);
        Console.WriteLine("Átlagpontszám:       " + atlagPont.ToString("F2"));
        Console.WriteLine();
        Console.WriteLine("Jegyek eloszlása:");
        Console.WriteLine("  Jeles  (5):  " + jegyDarabok[5] + " fő");
        Console.WriteLine("  Jó     (4):  " + jegyDarabok[4] + " fő");
        Console.WriteLine("  Közepes(3):  " + jegyDarabok[3] + " fő");
        Console.WriteLine("  Elégs. (2):  " + jegyDarabok[2] + " fő");
        Console.WriteLine("  Elégt. (1):  " + jegyDarabok[1] + " fő");
        Console.WriteLine();
        Console.WriteLine("Az eredményeket kiírtuk ide: " + kimenetiFajl);
    }
}
