using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD_2D_tomb
{
    internal class Program
    {

        static void Main(string[] args)
        {
            #region fejlec
            /*
            MM - 2-tomb
            MM - 2025.02.07.
            */

            string fejlec = $"MM - 2D tömb";
            Console.WriteLine(fejlec);
            for (int i = 0; i < fejlec.Length; i++) Console.Write('-');
            Console.WriteLine();
            #endregion

            Random rnd = new Random();

            int[,] tomb = new int[5, 5];

            for (int i = 0; i < tomb.GetLength(0); i++)
            {
                for (int j = 0; j < tomb.GetLength(1); j++)
                {
                    tomb[i, j] = rnd.Next(1, 100);
                }
            }

            for (int i = 0; i < tomb.GetLength(0); i++)
            {
                for (int j = 0; j < tomb.GetLength(1); j++)
                {
                    Console.Write($"{tomb[i, j],2} girhes"); 
                }
                Console.WriteLine();
            }
        }
    }
}
