using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace tombopk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                MM - Tömbök
                2025. 10. 02
                */

            Console.WriteLine("MM - 2025-10-02\nTömbök\n------");

            int[] ints = { 1, 2, 3 };
            foreach (int i in ints)
            {
                Console.WriteLine(i);
            }

            string[] honap = new string[3] { "január", "február", "március" };
            Console.WriteLine($"{honap[honap.Length - 1]}");
            Console.WriteLine($"{honap.GetLength(0) - 1}");

            char[] c = new char[] { '1', 'X', '2' };
            Random rnd = new Random();
            for (int i = 1; i <= 6; i++)
            {
                Console.WriteLine($"{i}. meccs: {c[rnd.Next(0,c.Length)]}");
            };

            double[] odds = new double[8]; // 6 meccs * 3 végkimenetel = 18
            for (int i = 0; i < odds.Length; i++)
            {
                odds[i] = rnd.NextDouble() * 7;
            };

            foreach (int o in odds)
            {
                Console.WriteLine($"{o+1}. odds");
            }



        }
    }
}
