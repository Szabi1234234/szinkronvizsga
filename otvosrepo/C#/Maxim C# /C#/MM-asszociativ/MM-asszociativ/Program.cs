using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM_asszociativ
{
    internal class Program                                         
    {                                                              
        static void Main(string[] args)                            
        {                                                          
            /*                                                     
             * MM - asszociatív tömbök                             
             * 2026.03.05. 13:06
             */

            Console.WriteLine("MM - Asszociatív\n2026.03.05\n----------");

            Hashtable meccsek = new Hashtable() {
                { "Barcelona - Atl. Madrid", '1' },
                { "Real Sociedad - Ath. Bilbao", '1' },
                { "Győr - Kecskemét", 'X' }
            };

            foreach (DictionaryEntry meccs in meccsek)
            {
                Console.WriteLine($"{meccs.Key,-30} {meccs.Value}");
            }
        }
    }
}
