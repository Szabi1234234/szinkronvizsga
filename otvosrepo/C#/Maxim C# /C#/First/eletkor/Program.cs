using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eletkor
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*
                MM - eletkor
                2025.09.04
            */


            Console.WriteLine("MM - eletkor");

            int aktev = 2025;
            int szulev;

            Console.Write("Kérem a születési évedet: ");
            szulev = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Az Ön életkora: " + (aktev - szulev) + " év.");

        }
    }
}
