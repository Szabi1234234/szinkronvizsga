using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace random
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //11.
            //Random rnd = new Random();
            //int dobas = rnd.Next(1, 6 + 1);

            //Console.WriteLine($"1. dobás {dobas}");
            //dobas = rnd.Next(1, 6 + 1);
            //Console.WriteLine($"2. dobás {dobas}");

            //12.
            Random rnd = new Random();

            for (int i = 1; i <= 3; i++)
            {
                int dobas = rnd.Next(0, 1 + 1);
                Console.Write($"A(z) {i} dobás: ");

                if (dobas == 0)
                {
                    Console.WriteLine("fej");
                }
                else Console.WriteLine("írás");
            }

        }
    }
}
