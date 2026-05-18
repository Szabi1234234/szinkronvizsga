using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2_RGB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                MM - 2 - rgb
                2025.12.04
            */

            Console.WriteLine("MM - 2-RGB \n2025.12.04 ");
            string[] sorok = File.ReadAllLines("kep.txt");

            int meret = 50;

            int[] r = new int[2500];
            int[] g = new int[2500];
            int[] b = new int[2500];

            for (int i = 0; i < 2500; i++)
            {
                string[] szinek = sorok[i].Split(' ');
                r[i] = int.Parse(szinek[0]);
                g[i] = int.Parse(szinek[1]);
                b[i] = int.Parse(szinek[2]);

            }


            Console.Write("   ");
            for (int x = 0; x < meret;x ++)
            {
                Console.Write(x / 10);
            }
            Console.WriteLine();

            Console.Write("   ");
            for (int x = 0; x < meret; x++)
            {
                Console.Write($"{ x % 10}");
            }
            Console.WriteLine();



            for (int i = 0; i < meret; i++)
            {
                if (i < 10)
                {
                    Console.Write("0" + i + " ");
                }
                else
                {
                    Console.Write(i + " ");
                }
                for (int j = 0; j < meret; j++)
                {
                    int index = i * meret + j;
                    if (r[index] == 255 && g[index] == 0 && b[index] == 0)
                    {
                        Console.Write("P");
                    }
                    else if (r[index] == 0 && g[index] == 255 && b[index] == 0)
                    {
                        Console.Write("Z");
                    }
                    else if (r[index] == 0 && g[index] == 0 && b[index] == 255)
                    {
                        Console.Write("K");
                    }
                    else if (r[index] == 255 && g[index] == 255 && b[index] == 0)
                    {
                        Console.Write("S");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }





        }

    }
}
