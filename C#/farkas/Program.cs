using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace farkas
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> veetel_lista = File.ReadAllLines("veetel_e.txt").ToList();
            string[] reszek;
            string[] alreszek;
            int felnott, kolyok;

            foreach (var sor in veetel_lista)
            {
                reszek = sor.Split(' ');
                alreszek = reszek[0].Split('/');
                felnott = Convert.ToInt16(alreszek[0]);
                kolyok = Convert.ToInt16(alreszek[1]);
                Console.WriteLine($"Összesen: {felnott + kolyok,2} | felnőtt {felnott,2} kolyok: {kolyok}")
            }
        }
    }
}
