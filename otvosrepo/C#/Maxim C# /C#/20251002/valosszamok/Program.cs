using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace valosszamok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             MM - Valós számok
             2025. 10. 02
             */

            Console.WriteLine("MM - 2025-10-02\nValós számok\n------------");
            /*
            Console.Write("Adj meg egy valós számot (pl. 2,25): ");
            double a = Convert.ToDouble(Console.ReadLine());
            */

            /*

            Console.WriteLine($"{Math.Sqrt(a)}");
            Console.WriteLine($"{Math.Pow(a,2)}");
            Console.WriteLine($"{Math.Log(a)}");
            Console.WriteLine($"{Math.Log10(a)}");
            Console.WriteLine($"{Math.Floor(a)}");
            Console.WriteLine($"{Math.Ceiling(a)}");
            Console.WriteLine($"{Math.Round(a,1)}");
            Console.WriteLine($"{Math.Round(a)}");
            Console.WriteLine($"{Math.Abs(-a)}");
            Console.WriteLine($"{Math.Sin(a/2)}");
            Console.WriteLine($"{Math.Asin(a)}");



            Console.WriteLine(a);
            */

            //Random rnd = new Random();
            //double a = rnd.NextDouble()*100; // 0 és 1 közötti véletlen valós szám
            //Console.WriteLine($"A generált százalék: {a:N2}");

            Console.WriteLine("1. feladat");
            Console.Write("Kérlek add meg az első számot: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Kérlek add meg a második számot: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Kérlek add meg a harmadik számot: ");
            double c = Convert.ToDouble(Console.ReadLine());
            double atlag = (a + b + c) / 3;
            Console.WriteLine($"A három szám átlaga: {atlag:N2}");

            Console.WriteLine("2. feladat");
            Random rnd = new Random();
            double befogo1 = rnd.NextDouble() * 100;
            double befogo2 = rnd.NextDouble() * 100;
            double atfogo = Math.Sqrt(Math.Pow(befogo1, 2) + Math.Pow(befogo2, 2));
            Console.WriteLine($"Az első befogó hossza: {befogo1:N1}cm\nA második befogó hossza: {befogo2:N1}cm");
            Console.WriteLine($"Az átfogó hossza: {atfogo:N1}cm");
        }
    }
}
