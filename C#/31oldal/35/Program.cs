using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _35
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * MM - 35
             * 2025.09.11
             */
            Console.WriteLine("MM - 35 \n2025.09.11\n----------");

            int t = 32;
            int k = 8;
            Console.WriteLine("A téglalap területe {0} nm, a kerülete {1} m.", t, k);
            Console.WriteLine($"A téglalap területe {t} nm, a kerülete {k} m.");

            #region 1
            Console.WriteLine("1.");
            Console.Write("Add meg a nevedet: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Helló, {name}!");
            #endregion

            #region 2
            Console.WriteLine("2.");
            Console.Write("Adj meg egy számot: ");
            int szam = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"A 2. feladat tesztje: {szam}");
            #endregion

            #region 3
            Console.WriteLine("3.");
            string szo1 = "abba";
            string szo2 = "baba";
            Console.WriteLine($"A {szo2} szó az {szo1} anagrammája.");
            #endregion

            #region 4
            Console.WriteLine("4.");
            int sz1, n1, sz2, n2;
            sz1 = 24; n1 = 32; sz2 = 3; n2 = 4;
            Console.WriteLine($"{sz1}/{n1} = {sz2}/{n2}");
            #endregion
        }
    }
}
