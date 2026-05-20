using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

struct hojelentes
{   
    public string nap;
    public int hovastagsag;
    public int veszely_szint;
}

namespace MM_hojelentes
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("MM - Hóvastagság\n2025.11.20\n----------");

            hojelentes[] jelentesek = new hojelentes[7];

            jelentesek[0].nap = "Hétfő"; jelentesek[1].nap = "Kedd"; jelentesek[2].nap = "Szerda"; jelentesek[3].nap = "Csütörtök"; jelentesek[4].nap = "Péntek"; jelentesek[5].nap = "Szombat"; jelentesek[6].nap = "Vasárnap";
            
            Random hovast = new Random();
            for (int i = 0; i < jelentesek.Length; i++)
            {
                double vastagsag = hovast.Next(10, 400);
                jelentesek[i].hovastagsag = (int)(Math.Round(vastagsag / 10.0) * 10);
            }


            for (int i = 0; i < jelentesek.Length; i++)
            {
                if (i == 0)
                {
                    jelentesek[i].veszely_szint = 1;
                }
                else
                {
                    int kulonbseg = jelentesek[i].hovastagsag - jelentesek[i - 1].hovastagsag;
                    if (kulonbseg == 20)
                    {
                        jelentesek[i].veszely_szint = 2;
                    }
                    else if (kulonbseg == 40)
                    {
                        jelentesek[i].veszely_szint = 3;
                    }
                    else if (kulonbseg >= 41 && kulonbseg <= 69)
                    {
                        jelentesek[i].veszely_szint = 4;
                    }
                    else if (kulonbseg >= 70 && kulonbseg <= 400 ) //itt azért 400 a 100 helyett, mert az a max amit generálhatunk
                    {
                        jelentesek[i].veszely_szint = 5;
                    }
                    else if (kulonbseg < 0)
                    {
                        //nem mehet minuszba
                        jelentesek[i].veszely_szint = jelentesek[i - 1].veszely_szint - 1;
                        if (jelentesek[i].veszely_szint < 1)
                        {
                            jelentesek[i].veszely_szint = 0;
                        }

                    }
                    else
                    {
                        jelentesek[i].veszely_szint = 1;
                    }
                }
                Console.WriteLine($"Nap: {jelentesek[i].nap} | Vastagság: {jelentesek[i].hovastagsag}cm | Veszély: {jelentesek[i].veszely_szint}");
            }



        }
    }
}
