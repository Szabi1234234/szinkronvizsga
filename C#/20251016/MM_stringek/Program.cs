using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM_stringek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* *
                MM - stringek
                2025. 10. 16.
             */
            //Console.WriteLine("MM - Stringek\n2025. 10. 16\n----- --- --");

            //string str = "isz";
            //string hb = "";
            //hb = "h" + str + "ed";

            //Console.WriteLine(hb);
            string s = "Ez" + " az!";
            Console.WriteLine(s);

            s = s.Replace('E', 'A');
            Console.WriteLine(s);

            int i = s.Length;
            Console.WriteLine(i);

            string k = s.Substring(1, 3);
            Console.WriteLine(k);

            k = s.Insert(2, " meg");
            Console.WriteLine(k);
        }

    }
}
