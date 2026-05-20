using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Valtozok_31
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             MM - Valtozo-31
             2025.09.11
             */
            Console.WriteLine("MM - Valtozok-31\n2025.09.11.\n----------------");

            #region 1
            int szamlalo, nevezo;
            #endregion
            #region 2
            char betu;
            #endregion
            #region 3
            string vnev = "Kiss";
            #endregion
            #region 4
            double atlag;
            #endregion
            #region 5
            double mobilszam;
            #endregion
            #region 6
            double kor;
            #endregion
            #region 7
            bool andras, bela;
            #endregion
            #region 8
            szamlalo = 24;
            #endregion
            #region 9 
            nevezo = 32;
            #endregion
            #region 10
            betu = 'B';
            #endregion
            #region 11
            mobilszam = 06209876543;
            #endregion
            #region 12
            kor = 29;
            #endregion
            #region 13
            andras = true;
            bela = false;
            #endregion
            #region 14

            Console.WriteLine("" +
                "Felbontások\n" +
                "-----------\n" +
                "1- 1920x1080\n" +
                "2- 1280x1024\n" +
                "3- 1280x720\n");


            Console.Write("Válasszon egy felbontást (1-3): ");
            int valasztott_felbontas = Convert.ToInt32(Console.ReadLine());

            int vf, ff;

            if (valasztott_felbontas == 1)
            {
                 vf = 1920;
                 ff = 1080;
            }
            else if (valasztott_felbontas == 2)
            {
                 vf = 1280;
                 ff = 1024;
            }
            else if (valasztott_felbontas == 3)
            {
                 vf = 1280;
                 ff = 720;
            } else
            {
                Console.WriteLine("Nincs ilyen felbontás!");
                 vf = 0;
                 ff = 0;
            }

            Console.WriteLine("A választott felbontás: " + vf + "x" + ff);
                #endregion
                #region 15
                double irsz = 1234;
            #endregion
            #region 16
            bool tulaj;
            Console.Write("Ön a lakás tulajdonosa? (igen/nem): ");
            if (Console.ReadLine().ToLower() == "igen")
            {
                tulaj = true;
            } else
            {
                tulaj = false;
            }
            #endregion

        }
    }
}
