using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM_toto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * MM - toto
             * 2026-02-19
            */

            Console.WriteLine("MM - Toto\n\n");



            string[,] meccsek = new string[14, 2]
            {
                { "1", "Chelsea - Arsenal" },
                { "2", "Újpest - Kecskemét" },
                { "3", "MTK - Puskás Akadémia" },
                { "4", "DVSC - Fehérvár" },
                { "5", "Diósgyőr - FTC" },
                { "6", "Darmstadt - RB Leipzig" },
                { "7", "Union Berlin - VfB Stuttgart" },
                { "8", "Wolfsburg - Leverkusen" },
                { "9", "Freiburg - Bochum" },
                { "10", "Mainz - Bayern München" },
                { "11", "Torino - Internazionale" },
                { "12", "Sassuolo - Lazio" },
                { "13", "Roma - Monza" },
                { "14", "Milan - Juventus" }




            };

            int tet = 0;
            Console.Write("Kérlek adj meg egy tétet: ");
            tet = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("A következőkben tippelned kell a meccsekre. \nLehetséges válaszok: 1, 2, X\n");

            char[] tipp = new char[14];
            char[] vegeredmeny = new char[14];


            Console.WriteLine("Sorszám  | Meccs                          | Fogadó tippje");
            Console.WriteLine(new string('-', 70));


            for (int i = 0; i < meccsek.GetLength(0); i++)
            {
                
                Console.Write($"{meccsek[i, 0],-8} | {meccsek[i, 1],-30} | Tipp:  ");
                Random rnd = new Random();
                vegeredmeny[i] = Convert.ToChar(rnd.Next(1, 4));
                if (vegeredmeny[i] == 1)
                {
                    vegeredmeny[i] = '1';
                }
                else if (vegeredmeny[i] == 3)
                {
                    vegeredmeny[i] = 'X';
                }
                else
                {
                    vegeredmeny[i] = '2';
                }

                tipp[i] = Convert.ToChar(Console.ReadLine().ToUpper());


            }

            int talalat = 0;
            Console.WriteLine("\n\n\nSorszám  | Meccs                          | Végeredmény     | Fogadó tippje");
            Console.WriteLine(new string('-', 70));
            for (int i = 0; i < meccsek.GetLength(0); i++)
            {
                System.Threading.Thread.Sleep(200);


                if (tipp[i] == vegeredmeny[i])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{meccsek[i, 0],-8} | {meccsek[i, 1],-30} | {vegeredmeny[i],-15} | {tipp[i]}");

                    talalat++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{meccsek[i, 0],-8} | {meccsek[i, 1],-30} | {vegeredmeny[i],-15} | {tipp[i]}");
                }

            }
            Console.ResetColor();
            int nyeremeny = tet * (talalat * 100);
            Console.WriteLine($"\n\nAz Ön nyereménye: {tet} x ({talalat}x100) = {nyeremeny} Ft");


        }
    }
}
