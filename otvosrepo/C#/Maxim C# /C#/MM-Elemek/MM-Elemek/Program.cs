using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;

namespace MM_Elemek
{
    internal class Program
    {
        static void Main(string[] args)
        {

            

            // MM - Elemek
            string[] sorok = File.ReadAllLines("elemek.csv");

            int osszelem = 0;

            int[] rendszam = new int[500];
            string[] vegyjel = new string[500];
            List<string> egybetus = new List<string>();
            string[] nev = new string[500];
            double[] atomtomeg = new double[500];
            int[] suruseg = new int[500];
            List<double> surusegList = new List<double>();
            double[] olvadaspont = new double[500];
            double[] forraspont = new double[500];
            double[] fajho = new double[500];

            for (int i = 1; i < sorok.Length; i++)
            {
                string[] adatok = sorok[i].Split('\t');
                rendszam[i] = int.Parse(adatok[0]);
                vegyjel[i] = adatok[1];
                nev[i] = adatok[2];


                surusegList.Add()
              


                if (vegyjel[i].Length == 1)
                {
                    string elem = $"{vegyjel[i]} {nev[i]}";
                    egybetus.Add(elem);
                }
                osszelem++;



            }
            Console.WriteLine("\nBeolvasott elemek száma: " + osszelem);

            foreach (var elem in egybetus)
            {
                Console.WriteLine($"{elem}");
            }
            Console.WriteLine($"Ezek száma: {egybetus.Count}");

            foreach (var elem in surusegList)
            {
                Console.WriteLine(elem);
            }

            
        }
    }
}
