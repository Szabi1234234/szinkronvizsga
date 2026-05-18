using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace laz
{
    internal class Program 
    {
        static void Main(string[] args)
        {
            /* 
             * MM - Laz
             * 2025. 01. 08
             */

            Console.WriteLine("MM - Laz");

            List<string> meresek = File.ReadAllLines(@"K:\Kovács Dénes\Tantárgyak\Asztali alkalmazások fejlesztése-11.D-S1\Láz\meresek.csv").ToList();

            string[] reszek;
            List<double> ertekek = new List<double>();

            foreach (var napi in meresek)
            {
                reszek = napi.Split('\t');

                //ertekek.Add(Convert.ToDouble(reszek[0]));
                //ertekek.Add(Convert.ToDouble(reszek[1]));
                //ertekek.Add(Convert.ToDouble(reszek[2]));

                foreach (var x in meresek)
                {
                    ertekek.Add(Convert.ToDouble(x));
                }

                foreach (var y in ertekek)
                {
                    Console.WriteLine($"{y:N1}");
                }


            }
        }
    }
}
