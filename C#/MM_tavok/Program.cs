using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM_tavok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * MM_tavok
             * 2025.11.27
             */
                Console.WriteLine("MM - Tavok\n2025.11.27\n----------");
            string[] reszek;
            string nap;
            foreach (string sor in tavok)
            {                    
                reszek = sor.Split(' ');

                switch (reszek[0])
                {   
                    case "1": nap = "Hétfő";    break;
                    case "2": nap = "Kedd";     break;
                    case "3": nap = "Szerda";   break;
                    case "4": nap = "Csütörtök";break;
                    case "5": nap = "Péntek";   break;
                    case "6": nap = "Szombat";  break;
                    case "7": nap = "Vasárnap"; break;
                    default:                    break;

                }
                Console.WriteLine($"{nap} {reszek[1]} {reszek[2]}");
            }
        }
    }
}
