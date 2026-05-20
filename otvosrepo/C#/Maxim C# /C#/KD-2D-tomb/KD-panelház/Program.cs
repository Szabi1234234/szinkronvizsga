using System;

namespace KD_panelház
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MM - Lakók\n2026.02.19\n----------");

            int[,] lakas = new int[10, 3];
            Random lakok = new Random();

            int ossz_lakok = 0;
            int ures_lakasok = 0;

            int max_lakok = -1;
            int max_emelet = 0;
            int min_lakok = int.MaxValue;
            int min_emelet = 0;

            for (int i = 0; i < lakas.GetLength(0); i++)
            {
                int emelet_lakok = 0; 
                for (int j = 0; j < lakas.GetLength(1); j++)
                {
                    lakas[i, j] = lakok.Next(0, 6);
                    Console.WriteLine($"{i + 1}. emelet {j + 1}. lakás: {lakas[i, j]} lakó");

                    ossz_lakok += lakas[i, j];
                    emelet_lakok += lakas[i, j];
                    if (lakas[i, j] == 0) { ures_lakasok++; }
                }

                if (emelet_lakok > max_lakok)
                {
                    max_lakok = emelet_lakok;
                    max_emelet = i + 1;
                }
                if (emelet_lakok < min_lakok)
                {
                    min_lakok = emelet_lakok;
                    min_emelet = i + 1;
                }

                Console.WriteLine($"{i + 1}. emelet összesen: {emelet_lakok} lakó\n");
            }

            double atlag_lako_per_szint = (double)ossz_lakok / lakas.GetLength(0);

            Console.WriteLine($"Összesen: {ossz_lakok} lakó lakja az épületet.");
            Console.WriteLine($"Átlagosan {atlag_lako_per_szint:F1} lakó lakik egy szinten.");
            Console.WriteLine($"A legkevesebben a {min_emelet}. emeleten laknak ({min_lakok} fő).");
            Console.WriteLine($"A legtöbben a {max_emelet}. emeleten laknak ({max_lakok} fő).");
            Console.WriteLine($"Az épületben {ures_lakasok} db lakás üres.");

            Console.WriteLine("\n--- Módosítás ---");
            Console.Write("Adja meg az emelet számát (1-10): ");
            int e_szam = Convert.ToInt32(Console.ReadLine());
            Console.Write("Adja meg a lakás számát (1-3): ");
            int l_szam = Convert.ToInt32(Console.ReadLine());
            Console.Write("Adja meg az új lakószámot (0-5): ");
            int uj_lakok = Convert.ToInt32(Console.ReadLine());

            if (uj_lakok < 0 || uj_lakok > 5)
            {
                Console.WriteLine("Hiba: 0 és 5 közötti számot adj meg!");
            }
            else
            {
                lakas[e_szam - 1, l_szam - 1] = uj_lakok;
                Console.WriteLine("Adatok frissítve.\n");

                int v_ossz = 0;
                int v_max = -1, v_min = int.MaxValue;
                int v_max_em = 0, v_min_em = 0;
                int v_ures = 0;

                for (int i = 0; i < lakas.GetLength(0); i++)
                {
                    int v_em_osszesen = 0;
                    for (int j = 0; j < lakas.GetLength(1); j++)
                    {
                        v_ossz += lakas[i, j];
                        v_em_osszesen += lakas[i, j];
                        if (lakas[i, j] == 0) v_ures++;
                    }

                    if (v_em_osszesen > v_max) { v_max = v_em_osszesen; v_max_em = i + 1; }
                    if (v_em_osszesen < v_min) { v_min = v_em_osszesen; v_min_em = i + 1; }
                }

                Console.WriteLine($"Új összesített lakószám: {v_ossz}");
                Console.WriteLine($"Új legnépesebb emelet: {v_max_em}. szint ({v_max} fő)");
                Console.WriteLine($"Új legüresebb emelet: {v_min_em}. szint ({v_min} fő)");
                Console.WriteLine($"Üres lakások száma: {v_ures}");
            }

            Console.ReadKey();
        }
    }
}