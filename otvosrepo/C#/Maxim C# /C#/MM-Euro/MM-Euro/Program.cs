using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq.Expressions;

namespace MM_Euro
{
    internal class Program
    {


        static void Main(string[] args)
        {
            
            string[] honapnev = { "január", "február", "március", "április", "május", "június", "július", "augusztus", "szeptember", "október", "november", "december" };
            int[] euroertek = new int[200];


            List<string> ertekek = new List<string>();

            string[] euro = File.ReadAllLines("euro.txt", Encoding.UTF8);

            foreach (string s in euro)
            {
                ertekek.Add(s);
            }
            int ev = 1999;
            
                for (int i = 0; i < honapnev.Length; i++)
                {
                 
                }
            

            Console.WriteLine("Az adatok 1999. január és 2009. november közöttiek");



            }
            



        
    }
}
