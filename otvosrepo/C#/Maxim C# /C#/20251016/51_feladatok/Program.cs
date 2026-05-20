using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _51_feladatok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1.");
            Console.WriteLine("Adj meg egy szót: ");
            string szo = Console.ReadLine();
            Console.WriteLine(szo.Length);

            Console.WriteLine("2.");
            Console.WriteLine(szo[0]);

            Console.WriteLine("3.");
            Console.WriteLine(szo[szo.Length - 1]);

            Console.WriteLine("4.");
            Console.WriteLine("Adj meg egy 5 betűs szót");
            string ot_betus = Console.ReadLine();
            Console.WriteLine(szo.Substring(1, 3));

            Console.WriteLine("5.");
            Console.Write("Kérlek adj meg egy budapesti irányítószámot: ");
            string iranyitoszam = Console.ReadLine();

            Console.WriteLine("7.");
            Console.Write("kérlek add meg a vezetékneved: ");
            string vezeteknev = Console.ReadLine();
            Console.Write("kérlek add meg a keresztneved: ");
            string keresztnev = Console.ReadLine();

            Console.WriteLine(vezeteknev.Substring(0, 3) + keresztnev.Substring(0,3) + "01");
        }
    }
}
