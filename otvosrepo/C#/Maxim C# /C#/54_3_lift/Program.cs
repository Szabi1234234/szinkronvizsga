using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

struct lift
{
    public int ora;
    public int perc;
    public int masodperc;
    public int szorszam;
    public int induloszint;
    public int celszint;
}

namespace _54_3_lift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            lift[] liftek = new lift[120];

            lift buff;

            buff.ora = 10;
            buff.perc = 15;
            buff.masodperc = 20;
            buff.szorszam = 5;
            buff.induloszint = 3;
            buff.celszint = 8;

            liftek[67] = buff;

            buff.ora = 12;
            buff.perc = 30;
            buff.masodperc = 45;
            buff.szorszam = 1;
            buff.induloszint = 0;
            buff.celszint = 5;

            liftek[69] = buff;

            liftek[67].ora += 1;
            liftek[69].ora -= 1;

            buff = liftek[67];
            liftek[67] = liftek[69];
            liftek[69] = buff;


            Console.WriteLine($"A {liftek[69].szorszam} számú lift indult {liftek[69].induloszint}. emeletről {liftek[69].ora}:{liftek[69].perc}:{liftek[69].masodperc} időpontban a {liftek[69].celszint}. emeletre.");
            Console.WriteLine($"A {liftek[67].szorszam} számú lift indult {liftek[67].induloszint}. emeletről {liftek[67].ora}:{liftek[67].perc}:{liftek[67].masodperc} időpontban a {liftek[67].celszint}. emeletre.");


        }
    }
}
