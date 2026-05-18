using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD_amoba 
{
    internal class Program
    {

        static void Main(string[] args)
        {
            #region fejlec
            /*
            MM - amoba
            MM - 2026.02.12.
            */

            string fejlec = $"MM - 2D tömb";
            Console.WriteLine(fejlec);
            for (int i = 0; i < fejlec.Length; i++) Console.Write('-');
            Console.WriteLine();
            #endregion

            Random rnd = new Random();

            char[] xoz = { 'X', 'O', '.' };

            int x = 0;
            int o = 0;
            int dot = 0;

            char[,] tomb = new char[20, 20];

            for (int i = 0; i < tomb.GetLength(0); i++)
            {
                for (int j = 0; j < tomb.GetLength(1); j++)
                {
                    tomb[i, j] = xoz[rnd.Next(0, 3)];
                }
            }

            for (int i = 0; i < tomb.GetLength(0); i++)
            {
                for (int j = 0; j < tomb.GetLength(1); j++)
                {
                    if (tomb[i, j] == 'X') x++;
                    else if (tomb[i, j] == 'O') o++;
                    else dot++;

                    Console.Write(tomb[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("X: " + x);
            Console.WriteLine("O: " + o);
            Console.WriteLine(".: " + dot);
        }
    }
}

