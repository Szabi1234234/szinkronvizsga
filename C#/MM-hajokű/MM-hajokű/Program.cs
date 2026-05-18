using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel;

namespace MM_hajokű
{
    //MM - Hajók
    //2026.01.22
    class Hajok
    {
        public string nev;
        public string tipus;
        public double hossz;
        public double sebesseg;
        public int ev;


        public Hajok(string s)
        {
            this.nev = s.Split('\t')[0];
            this.tipus = s.Split('\t')[1];
            this.hossz = Convert.ToDouble(s.Split('\t')[2].Replace('.', ','));
            this.sebesseg = Convert.ToDouble(s.Split('\t')[3].Replace('.', ','));
            this.ev = Convert.ToInt32(s.Split('\t')[4]);
        }
    
    } 
    

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Hajok> lista = new List<Hajok>();
            string[] hajo = File.ReadAllLines("adatok.txt", Encoding.UTF8);

            StreamWriter ki = new StreamWriter("ki.txt", false, Encoding.UTF8);

            foreach (string line in hajo)
            {
                lista.Add(new Hajok(line));
            }

            //1. fel
            Console.WriteLine($"A hajók száma: {lista.Count}");
            ki.WriteLine($"A hajók száma: {lista.Count}");

            //2. fel

            Console.WriteLine("\nA hajók listája:");
            ki.WriteLine("\nA hajók listája:");
            Console.WriteLine("--------------------------------------------------------------------------------------");
            ki.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine("A hajó neve                    Típus                Hossz                Sebesség   Év");
            ki.WriteLine("A hajó neve                    Típus                Hossz                Sebesség   Év");
            foreach (Hajok hajok in lista)
            {
                Console.WriteLine($"{hajok.nev,-30} {hajok.tipus,-20} {hajok.hossz,-20:N2} {hajok.sebesseg,-10:N1} {hajok.ev,-10}");
                ki.WriteLine($"{hajok.nev,-30} {hajok.tipus,-20} {hajok.hossz,-20:N2} {hajok.sebesseg,-10:N1} {hajok.ev,-10}");
            }

            //3. feladat
            Console.WriteLine("\nLuxushajók:");
            ki.WriteLine("\nLuxushajók:");
            List<Hajok> luxushajok = new List<Hajok>();


            foreach (Hajok hajok in lista)
            {
                if(hajok.tipus.Contains("luxus-hajó"))
                {
                    luxushajok.Add(hajok);
                }
            }

            foreach (Hajok luxus in luxushajok)
            {
                Console.WriteLine(luxus.nev);
            }
            ki.WriteLine($"Összesen {luxushajok.Count} ilyen hajó van a listában.");
            Console.WriteLine($"Összesen {luxushajok.Count} ilyen hajó van a listában.");



            Hajok leggyorsabb = new Hajok("0\t0\t0\t0\t0");
            
            foreach (Hajok hajok in lista)
            {
                if (hajok.sebesseg > leggyorsabb.sebesseg)
                {
                    leggyorsabb = hajok;
                }
            }
            ki.WriteLine($"\nA leggyorsabb hajó: {leggyorsabb.nev} {leggyorsabb.tipus}");
            Console.WriteLine($"\nA leggyorsabb hajó: {leggyorsabb.nev} {leggyorsabb.tipus}");

            int utani = 0;
            double utaniseb = 0;

            foreach (Hajok hajok in lista)
            {
                if (hajok.ev > 2000)
                {
                    utani++;
                    utaniseb = utaniseb + hajok.sebesseg;
                }
            }

            double utanisebatlag = utaniseb / utani;
            Console.WriteLine($"\nA 2000 után épített hajók száma {utani}, átlagsebességük {utanisebatlag:N2} km/óra");
            ki.WriteLine($"\nA 2000 után épített hajók száma {utani}, átlagsebességük {utanisebatlag:N2} km/óra");

            ki.Flush();
        }
    }
}
