using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace fajlkiiratas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * MM - Fájlkiiratás
             *  2026. 01. 08
             */
        
            StreamWriter ki = new StreamWriter("szuletes.txt", false, Encoding.UTF8);

            Console.Write("Add meg a beceneved: ");
            string becenev = Console.ReadLine();

            DateTime szuldatum = new DateTime(2007, 06, 29, 4, 53, 11);

            ki.WriteLine($"{becenev} --> {szuldatum:d}");

            ki.Flush();
            ki.Close();
        }

    }
}
