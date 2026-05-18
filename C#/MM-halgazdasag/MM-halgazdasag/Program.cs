using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM_halgazdasag
{
    internal class Program
    {
        static double Atlag(double[] halak)
        {
            double atlag;
            double osszeg = 0;
            double db = 0;

            foreach (double i in halak)
            {
                osszeg = osszeg + i;
                db += 1;
            }
            atlag = osszeg / db;
            return atlag;
        }

        static double Legnagyobb(double[] halak)
        {
            double legnagyobb = halak.Max();

            return legnagyobb;
        }

        static double Arany(double[] halak)
        {
            double nagy = 0;
            for (int i = 0; i < halak.Length; i++)
            {
                if (halak[i] > 0.5)
                {
                    nagy = nagy + 1;
                }
            }
            double arany;
            arany = (nagy / halak.Length) * 100;

            return arany;
        }

        static void Meretes(double[] Halak)
        {
            double meretenaluli = 0;
            double meretenaluli_index = 0;
            foreach (double i in Halak)
            {
                if (i < 0.5)
                {
                    meretenaluli = i;
                    break;
                }
                else
                {
                    meretenaluli_index++;
                }
            }
            if (meretenaluli == 0)
            {
                Console.WriteLine("Nincs méreten aluli hal!");

            }
            else
            {
                Console.WriteLine($"Van ilyen hal! Az első ilyen: [{meretenaluli_index + 1}] : {meretenaluli} kg-os");
            }
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();

            double[] Halak = new double[20];

            for (int i = 0; i < Halak.Length; i++)
            {
                double suly = rnd.Next(100, 20000);
                suly /= 1000;
                Halak[i] = suly;
            }

            foreach (double i in Halak)
            {
                Console.WriteLine($"{i:N2}");

            }
            Meretes(Halak);
            Console.WriteLine($"A halak átlagos tömege: {Atlag(Halak):N3} kg");
            Console.WriteLine($"A legnagyobb hal tömege: {Legnagyobb(Halak):N3} kg");
            Console.WriteLine($"A méretes halak aránya: {Arany(Halak):N1}%");



        }
    }
}
