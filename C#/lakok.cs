using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KD_panelház
{
    internal class Program
    {
        /*
         * MM- panelház a
         */

        static void Main(string[] args)
        {
            Console.WriteLine("MM - Lakók\n2026.02.12\n----------");

            int[,] lakas = new int[10, 3];

            Random lakok = new Random();

            int ossz_lakok = 0;
            int emelet_lakok = 0;
            int atlag_lako_per_szint = 0;
            int ures_lakasok = 0;

            int legtobb = 15;
            int legtobb_lako_per_szint = 0;
            int legkevesebb = 0;
            int legkevesebb_lako_per_szint = 0;

            for (int i = 0; i < lakas.GetLength(0); i++)
            {
                for (int j = 0; j < lakas.GetLength(1); j++)
                {



                    lakas[i, j] = lakok.Next(0, 6);

                    Console.WriteLine($"{i + 1}. emelet {j + 1}. lakás: {lakas[i, j]} lakó");

                    ossz_lakok += lakas[i, j];
                    emelet_lakok += lakas[i, j];
                    atlag_lako_per_szint = ossz_lakok / (i + 1);

                   
                    if (legkevesebb > emelet_lakok || legkevesebb == 0)
                    {
                        legkevesebb = emelet_lakok;
                        legkevesebb_lako_per_szint = i + 1;
                    }

                    if (legtobb > emelet_lakok)
                    {
                        legtobb = emelet_lakok;
                        legtobb_lako_per_szint = i + 1;
                    }


                    if (lakas[i, j] == 0) { ures_lakasok++; }

                }
                Console.WriteLine($"\n{i + 1}. emelet: {emelet_lakok} lakó\n");
                emelet_lakok = 0;
            }
            Console.WriteLine($"Összesen: {ossz_lakok} lakó lakja az épületet.");
            Console.WriteLine($"Átlagosan {atlag_lako_per_szint} lakó lakik egy szinten.");
            Console.WriteLine($"A legkevesebben a {legkevesebb_lako_per_szint} emeleten laknak.");
            Console.WriteLine($"A legtöbben a {legtobb_lako_per_szint}. emeleten laknak.");
            Console.WriteLine($"Az épületben {ures_lakasok} db lakás üres.");

            Console.Write("Adja meg a változtatandó emeletszámot: ");
            int emelet_szama = Convert.ToInt32(Console.ReadLine());
            Console.Write("Adja meg a változtatandó lakásszámot: ");
            int lakas_szama = Convert.ToInt32(Console.ReadLine());

            Console.Write("Adja meg a változtatandó lakók számát: ");
            int lakok_szama = Convert.ToInt32(Console.ReadLine());

            if (lakok_szama < 5 || lakok_szama >= 0)
            {
                Console.WriteLine("Nem lakhatnak többen egy lakásban, mint 5.\nVagy nem lehet kevesebb, mint 0.");
            } else
            {

           

                lakas[emelet_szama - 1, lakas_szama - 1] = lakok_szama;



            Console.WriteLine($"A {emelet_szama}. emeleti {lakas_szama}. lakásban mostantól {lakok_szama} lakó lakik.");
            System.Threading.Thread.Sleep(1000);

            int v_ossz_lakok = 0;
            int v_emelet_lakok = 0;
            int v_atlag_lako_per_szint = 0;
            int v_ures_lakasok = 0;

            int v_legtobb_lako_per_szint = 0;
            int v_legkevesebb_lako_per_szint = 0;


            for (int i = 0; i < lakas.GetLength(0); i++)
            {
                for (int j = 0; j < lakas.GetLength(1); j++)
                {
                    Console.WriteLine($"{i + 1}. emelet {j + 1}. lakás: {lakas[i, j]} lakó");

                    v_ossz_lakok += lakas[i, j];
                    v_emelet_lakok += lakas[i, j];
                    v_atlag_lako_per_szint = v_ossz_lakok / (i + 1);

                    if (v_emelet_lakok > v_legtobb_lako_per_szint)
                    {
                        v_legtobb_lako_per_szint = i + 1;
                    }
                    if (v_emelet_lakok < v_legkevesebb_lako_per_szint || v_legkevesebb_lako_per_szint == 0)
                    {
                        v_legkevesebb_lako_per_szint = i + 1;
                    }


                    if (lakas[i, j] == 0) { v_ures_lakasok++; }

                }
                Console.WriteLine($"\n{i + 1}. emelet: {v_emelet_lakok} lakó\n");
                v_emelet_lakok = 0;
            }
            Console.WriteLine($"A változtatás után összesen: {v_ossz_lakok} lakó lakja az épületet.");
            Console.WriteLine($"A változtatás után átlagosan {v_atlag_lako_per_szint} lakó lakik egy szinten.");
            Console.WriteLine($"A változtatás után legkevesebben a {v_legkevesebb_lako_per_szint} emeleten laknak.");
            Console.WriteLine($"A változtatás után legtöbben a {v_legtobb_lako_per_szint}. emeleten laknak.");
            Console.WriteLine($"A változtatás után az épületben {v_ures_lakasok} db lakás üres.");
            }
        }
    }
}