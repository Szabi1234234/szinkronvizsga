using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tippmix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            MM - tippmix
            2025.09.04
            */

            string meccsnev = "Csád - Ghána";
            double h = 16.00;
            double d = 6.25;
            double v = 1.08;

            Console.Write("Mennyi szeretnél felrakni: ");
            int tet = Convert.ToInt32(Console.ReadLine());


            Console.Write("Az ön tippje <h, d, v>: ");
            char tipp = Convert.ToChar(Console.ReadLine());

            Random rnd = new Random();
            int kimenet = rnd.Next(0, 3); //0 - hazai, 1 - döntetlen, 2 - vendég


            int nyeremeny = -1;

            if (kimenet == 0 && tipp == d) //dontetlen
            {
                nyeremeny = Convert.ToInt32((Convert.ToDouble(tet) * d));
                Console.WriteLine("Az Ön nyereménye: " + nyeremeny + " Ft");
            }
            else if (kimenet == 1 && tipp == h) //hazai
            {
                nyeremeny = Convert.ToInt32((Convert.ToDouble(tet) * h));
                Console.WriteLine("Az Ön nyereménye: " + nyeremeny + " Ft");
            }
            else if (kimenet == 2 && tipp == v) //vendeg
            {
                nyeremeny = Convert.ToInt32((Convert.ToDouble(tet) * v));
                Console.WriteLine("Az Ön nyereménye: " + nyeremeny + " Ft");
            }
            else
            {
                nyeremeny = 0;
                Console.WriteLine("Elállt a pénz a háztól.");
            }

                
        }
    }
}
