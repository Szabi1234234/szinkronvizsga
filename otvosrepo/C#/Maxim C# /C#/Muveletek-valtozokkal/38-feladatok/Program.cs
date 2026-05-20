using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _38_feladatok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * MM - 38. feladatok
             * 2025.09.18.
             */
            Console.WriteLine("MM - 38. feladatok\n2025.09.18\n----------");

            ////1.
            //Console.Write("Add meg a hosszúságot: ");
            //int hosszusag = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Add meg a szélességet: ");
            //int szelesseg = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine($"A kert területe: {hosszusag * szelesseg} négyzetméter.\n{2 * (hosszusag + szelesseg)} métert kell gyalogolni a kert körbejárásához");

            ////2. 
            //Console.Write("Adj meg egy számot: ");
            //int szam = Convert.ToInt32(Console.ReadLine());
            //if (szam % 2 == 0)
            //{
            //    Console.WriteLine(0);
            //}
            //else Console.WriteLine(1);

            ////3.
            //Console.Write("Kérlek adj meg egy kétjegyű számot: ");
            //int szam2 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine(szam2 % 10);

            ////4.
            //Console.Write("Kérlek adj meg egy kétjegyű számot: ");
            //int egesz = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine($"{egesz / 10}");

            //5. 
            //Console.Write("Kérlek adj meg egy háromjegyű egész számot: ");
            //int egesz = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine($"{egesz}\negyesei: {egesz % 10}\ntízesei: {(egesz / 10) % 10}\nszázasai: {egesz / 100}");

            //6.
            //int a = 24;
            //int b = 6;
            //Console.WriteLine($"{a}/{b} = {a / b}");

            //7.
            //int a = 24;
            //int b = 32;
            //Console.WriteLine($"{a}/{b} = {a/8}/{b/8}");

            //8.
            //Console.Write("Kérlek adj meg egy háromjegyű egész számot: ");
            //int sz = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine($"{sz} --> {sz = sz + 1} --> {sz = sz + 3} --> {sz = sz + 10} --> {sz = sz + 100}");

            //9.
            //Console.Write("Kérlek adj meg egy háromjegyű egész számot: ");
            //int sz = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine($"{sz} --> {sz += 1} --> {sz += 3} --> {sz += 10} --> {sz += 100}");

            //10.
            Console.Write("Adj meg egy egész számot: ");
            int x = Convert.ToInt32(Console.ReadLine());

            Console.Write("Adj meg egy egész számot: ");
            int y = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(x += y);
            Console.WriteLine(x -= y);
            Console.WriteLine(x *= y);
        }
    }
}
