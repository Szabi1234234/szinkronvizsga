using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD_orarend
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Órarend
            KD - 2024.10.01.
            */
            string fejlec = "Órarend";
            Console.WriteLine(fejlec);
            for (int i = 0; i < fejlec.Length; i++) Console.Write('-');
            Console.WriteLine();

            string[,] orarend = new string [9,5];

            string[] tantargyak = new string[] {"matek","irodalom","töri","tesi","asztalkfej"};

            Random rnd = new Random();

            string[] napok = new string[] { "óraszám","hétfő", "kedd", "szerda", "csütörtök", "péntek" };

            foreach (var nap in napok)
            {
                if (nap == "óraszám")
                    Console.Write($"{nap.ToUpper(),-10}");
                else
                    Console.Write($"{nap.ToUpper(),-15}");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-',85));

            for (int i = 0; i < orarend.GetLength(0); i++)
            {
                Console.Write($"{i+1}. óra\t| ");

                for (int j = 0; j < orarend.GetLength(1); j++)
                {
                    orarend[i, j] = tantargyak[rnd.Next(0, tantargyak.Length)];
                    Console.Write($"{orarend[i, j],-15}");
                }
                Console.WriteLine();
            }

            //Console.WriteLine(orarend[3,2]);
            /*
            for (int i = 0; i < orarend.GetLength(0); i++)
            {
                for (int j = 0; j < orarend.GetLength(1); j++)
                    Console.Write($"{orarend[i, j]}\t");
                Console.WriteLine();
            }
            */

            //c
            Console.WriteLine($"A szerdai 3. óra: {orarend[2,2]}");

            //d
            Console.Write("Melyik napot választod [1-5]: ");
            int munkanap = Convert.ToInt32(Console.ReadLine());

            Console.Write("Hanyadik órát választod [1-9]: ");
            int ora = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"{napok[munkanap]} {ora}. óra: {orarend[ora-1,munkanap-1]}");

            string csere = orarend[ora - 1, munkanap - 1]; //töri

            Console.WriteLine("CSERE");
            Console.Write("Melyik napot választod [1-5]: ");
            int csere_munkanap = Convert.ToInt32(Console.ReadLine());

            Console.Write("Hanyadik órát választod [1-9]: ");
            int csere_ora = Convert.ToInt32(Console.ReadLine());
            orarend[ora - 1, munkanap - 1] = orarend[csere_ora-1, csere_munkanap-1];
            orarend[csere_ora - 1, csere_munkanap - 1] = csere;

            foreach (var nap in napok)
            {
                if (nap == "óraszám")
                    Console.Write($"{nap.ToUpper(),-10}");
                else
                    Console.Write($"{nap.ToUpper(),-15}");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 85));

            for (int i = 0; i < orarend.GetLength(0); i++)
            {
                Console.Write($"{i + 1}. óra\t| ");

                for (int j = 0; j < orarend.GetLength(1); j++)
                {
                    Console.Write($"{orarend[i, j],-15}");
                }
                Console.WriteLine();
            }



            Console.ReadLine();

        }
    }
}
