using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace _1_DNS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /**
                MM - 1 - DNS
                2025.12.04
             */

            string sor;
            int i = 0;
            int j;
            char[] bazis = new char[1000];
            StreamReader be = new StreamReader(@"bsa.txt");
            sor = be.ReadLine();
            while (sor != null)
            {
                bazis[i] = Convert.ToChar(sor);
                i++;
                sor = be.ReadLine();
            }
            i--;
            for(j=i;j>=0;j--)
            {
                Console.Write(bazis[j]);
            }
        }
    }
}
