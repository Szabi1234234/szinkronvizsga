using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szokitalalo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // MM - szókitaláló
            Console.WriteLine("MM - Szókitaláló\n2025.10.16\n----------\n");

            Console.Write("Adj meg egy szót: ");
            string word = Console.ReadLine().ToLower();
            int wordLength = word.Length;

            bool fut = true;
            string tippmezo = new string('_', wordLength);
            Console.WriteLine(tippmezo);

            while (fut)
            {
                char tipp;
                Console.Write("Kérlek tippelj egy betűt: ");
                tipp = Convert.ToChar(Console.ReadLine().ToLower());
                if (word.Contains(tipp)) {
                    Console.WriteLine("Talált!");
                    tippmezo = tippmezo.Replace(tippme, tipp);
                    Console.WriteLine(tippmezo);
                } else {
                    Console.WriteLine("Nincs ilyen betű a szóban.");
                }
            }
        }
    }
}
