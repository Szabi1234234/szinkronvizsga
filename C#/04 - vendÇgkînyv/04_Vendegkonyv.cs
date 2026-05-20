// =============================================================
//  4. FELADAT MEGOLDÁSA – Vendégkönyv
//  Írási mód:      StreamWriter append: true módban
//  Beolvasási mód: File.ReadAllLines (tömbbe)
// =============================================================

using System;
using System.IO;

class Program
{
    static void Main()
    {
        string fajl = "vendegkonyv.txt";

        // ============================================
        // 1. RÉSZ – ADATBEKÉRÉS ÉS ÍRÁS A FÁJL VÉGÉRE
        // ============================================

        Console.WriteLine("=== Vendégkönyv – új bejegyzések ===");
        Console.WriteLine("Adj meg 5 vendég nevét, mindegyiket Enter-rel zárva.");
        Console.WriteLine();

        // A "append: true" jelentése: NEM írja felül a fájlt,
        // hanem a VÉGÉRE fűzi az új tartalmat. Ha a fájl még
        // nem létezik, létrehozza.
        using (StreamWriter sw = new StreamWriter(fajl, append: true))
        {
            // Pontosan 5-ször kérünk be nevet.
            for (int i = 1; i <= 5; i++)
            {
                // Felszólítás kiírása (Write – sortörés NÉLKÜL).
                Console.Write(i + ". vendég neve: ");

                // Beolvasás: a felhasználó begépeli + Enter.
                // A ReadLine null-t is adhat (pl. ha bezárják a konzolt),
                // ezért a ?? operátorral üres stringre cseréljük.
                string nev = Console.ReadLine() ?? "";

                // Az aktuális dátum és idő.
                // "yyyy-MM-dd HH:mm:ss" -> pl. "2025-03-15 14:23:07"
                string idobelyeg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                // Kiírjuk a fájlba: "időbélyeg | név"
                sw.WriteLine(idobelyeg + " | " + nev);
            }
        }   // <-- fájl bezárása és mentése

        Console.WriteLine();
        Console.WriteLine("Bejegyzések elmentve.");
        Console.WriteLine();

        // ============================================
        // 2. RÉSZ – VISSZAOLVASÁS ÉS STATISZTIKA
        // ============================================

        // Az egész fájlt sorokra bontva tömbbe olvassuk.
        // Most már a régebbi bejegyzéseket is olvassuk –
        // ezért lehet, hogy 5-nél több sor van!
        string[] sorok = File.ReadAllLines(fajl);

        // Bejegyzések száma = sorok száma.
        int bejegyzesekSzama = sorok.Length;

        // Leghosszabb név keresése.
        // A sor felépítése: "időbélyeg | név"
        // A nevet a " | " utáni rész tartalmazza.
        int leghosszabbHossz = 0;     // a leghosszabb név hossza
        string leghosszabbNev = "";   // maga a leghosszabb név

        for (int i = 0; i < sorok.Length; i++)
        {
            // A " | " elválasztó pozícióját megkeressük.
            // IndexOf: visszaadja az első előfordulás indexét,
            // vagy -1-et, ha nincs benne.
            int helyzet = sorok[i].IndexOf(" | ");

            // Csak akkor dolgozzuk fel a sort, ha tényleg található
            // benne az elválasztó (különben hibás sor).
            if (helyzet >= 0)
            {
                // Substring(kezdo): a string adott pozíciójától a végéig.
                // A " | " hossza 3 karakter, ezért +3.
                string nev = sorok[i].Substring(helyzet + 3);

                // Trim: levágja a vezető és záró szóközöket.
                nev = nev.Trim();

                // Ha hosszabb az eddig találtnál, frissítünk.
                if (nev.Length > leghosszabbHossz)
                {
                    leghosszabbHossz = nev.Length;
                    leghosszabbNev = nev;
                }
            }
        }

        // ------------------------------------------------------
        // 3) KIÍRÁS – konzolra.
        // ------------------------------------------------------
        Console.WriteLine("=== Vendégkönyv statisztika ===");
        Console.WriteLine("Bejegyzések száma összesen: " + bejegyzesekSzama);
        Console.WriteLine("Leghosszabb név:            "
            + leghosszabbNev + " (" + leghosszabbHossz + " karakter)");

        Console.WriteLine();
        Console.WriteLine("A vendégkönyv jelenlegi tartalma:");
        for (int i = 0; i < sorok.Length; i++)
        {
            // Sorszámozzuk a kiírást (1-től, nem 0-tól, ezért i+1).
            Console.WriteLine("  " + (i + 1) + ". " + sorok[i]);
        }
    }
}
