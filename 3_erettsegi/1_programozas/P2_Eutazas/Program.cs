using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P2_Eutazas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("utasadat.txt");

            List<Adat> lista = new List<Adat>();

            foreach (string sor in sorok)
            {
                string[] t = sor.Split(' ');

                string tipus = t[3];

                string datumstr = t[1]; // 20190326-0716
                DateTime datum_felszallas = new DateTime(
                    int.Parse(t[1].Substring(0, 4)),
                    int.Parse(t[1].Substring(4, 2)),
                    int.Parse(t[1].Substring(6, 2)),
                    int.Parse(t[1].Substring(9, 2)),
                    int.Parse(t[1].Substring(11, 2)),
                    0);

                if (tipus == "JGY")
                {
                    lista.Add(new Adat(int.Parse(t[0]), datum_felszallas, t[2], t[3], new DateTime(), int.Parse(t[4])));
                }
                else
                {
                    lista.Add(new Adat(int.Parse(t[0]), datum_felszallas, t[2], t[3], new DateTime(
                        int.Parse(t[4].Substring(0, 4)),
                        int.Parse(t[4].Substring(4, 2)),
                        int.Parse(t[4].Substring(6, 2))
                        ), -1));
                }


            }

            Console.WriteLine($"balbabla {lista.Count} ");

        }
    }
}
