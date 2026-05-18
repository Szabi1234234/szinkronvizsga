using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

struct tortek
{
    public int szaml1;
    public int nev1;
    public int szaml2;
    public int nev2;
    public char muvjel;
}

namespace MM_Rekordok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* 
             * MM - Rekordok 
             * 2025.11.13
             */

            Console.WriteLine("MM - Rekordok\n-------------");

            tortek[] tort = new tortek[3];
            tort[0].szaml1 = 30;
            tort[0].nev1   = 12;
            tort[0].szaml2 = 8;
            tort[0].nev2   = 8;
            tort[0].muvjel = '+';

            tort[1].szaml1 = 8;
            tort[1].nev1 = 20;
            tort[1].szaml2 = 8;
            tort[1].nev2 = 30;
            tort[1].muvjel = '*';

            tort[2].szaml1 = 10;
            tort[2].nev1 = 4;
            tort[2].szaml2 = 12;
            tort[2].nev2 = 3;
            tort[2].muvjel = '+';

            int elsotort;
            int masodiktort;
            int vegsoeredmeny = 0;
            char akt_muvjel = ' ';

            for (int i = 0; i < tort.Length; i++)
            {
                elsotort = tort[i].szaml1 / tort[i].nev1;
                masodiktort = tort[i].szaml2 / tort[i].nev2;
                akt_muvjel = tort[i].muvjel;

                switch (akt_muvjel)
                {
                    case '+': vegsoeredmeny = elsotort + masodiktort; break;
                    case '-': vegsoeredmeny = elsotort - masodiktort; break;
                    case '*': vegsoeredmeny = elsotort * masodiktort; break;
                    case '/': vegsoeredmeny = elsotort / masodiktort; break;

                    default:
                        break;
                }
                Console.WriteLine(vegsoeredmeny);

            }


            //if (akt_muvjel == '+')
            //{
            //    vegsoeredmeny = elsotort + masodiktort;
            //}
            //else if (akt_muvjel == '-') {
            //    vegsoeredmeny = elsotort - masodiktort;
            //}
            //else if (akt_muvjel == '*')
            //{
            //    vegsoeredmeny = elsotort * masodiktort;
            //}
            //else
            //{
            //    vegsoeredmeny = elsotort / masodiktort;
            //}



        }
    }

}