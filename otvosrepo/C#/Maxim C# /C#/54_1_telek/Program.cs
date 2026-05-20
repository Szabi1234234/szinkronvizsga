using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

struct telek
{
    public int hazszam;
    public int szeles;
    public int hossz;
}


namespace _54_1_telek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            telek[] buff = new telek[3];
            telek[] telkek = new telek[50];


            buff[0].hazszam = 21;
            buff[0].szeles = 15;
            buff[0].hossz = 50;

            telkek[10] = buff[0];

            int terulet;

            terulet = telkek[10].szeles * telkek[10].hossz;
            Console.WriteLine($"A {telkek[10].hazszam}. számú telek területe {terulet} négyzetméter");

            buff[0].hossz = 50 - 10;
            buff[0].szeles = 15 + 10;

            terulet = buff[0].szeles * buff[0].hossz;
            Console.WriteLine($"A módosított {telkek[10].hazszam}. számú telek területe {terulet} négyzetméter.");


        }
    }
}
