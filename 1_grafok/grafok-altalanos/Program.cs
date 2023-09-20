using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafok_altalanos
{
    internal class Program
    {
        class Ellistas_graf
        {
            private List<List<int>> ellista;
            public int csucsszam;
            public int elszam;

            public Ellistas_graf()
            {
                ellista = new List<List<int>>();
                csucsszam = 0;
                elszam = 0;
            }
            
            // INPUT-OUTPUT
            public void MesterUploadInput()
            {
                string[] sor = Console.ReadLine().Split(' ');
                csucsszam = int.Parse(sor[0]);
                elszam = int.Parse(sor[1]);

                for (int i = 0; i < elszam; i++)
                {
                    sor = Console.ReadLine().Split(' ');
                    ellista.Add(new List<int>{int.Parse(sor[0]),int.Parse(sor[1])});
                }
            }

            public void GraphvizOutput()
            {
                string res = "graph G {\n";
                foreach (List<int> par in ellista)
                    res += par[0] + " -- " + par[1] + ";\n";
                Console.WriteLine(res + "}");
            }


            //BASIC FUNCTIONS
            public bool Van_csucs(int a) => a < csucsszam;

            public bool Van_el(int a, int b)
            {
                foreach (List<int> par in ellista)
                {
                    if ((par[0] == a && par[1] == b) || (par[0] == b && par[1] == a))
                        return true;
                }
                return false;
            }
            public int Fokszam(int a)
            {
                if (!Van_csucs(a))
                    return -1;

                int fokszam = 0;
                foreach (List<int> par in ellista)
                {
                    if (par[0] == a)
                        fokszam++;
                    if (par[1] == a)
                        fokszam++;
                }
                
                return fokszam;
            }

            public int[] Foktomb()
            {
                int[] result = new int[csucsszam];
                foreach (List<int> par in ellista)
                {
                    result[par[0]]++;
                    result[par[1]]++;
                }

                return result;
            }


            // COMPLEX FUNCTIONS
            public bool IzolaltE(int a) => Fokszam(a) == 0;

            public List<int> IzolaltCsucslista()
            {
                List<int> nemizolalt = new List<int>();
                List<int> csucslista = new List<int>();



                return csucslista;
            }
        }


        static void Main(string[] args)
        {
            Ellistas_graf agraf = new Ellistas_graf();
            agraf.MesterUploadInput();
            agraf.GraphvizOutput();

            Console.WriteLine(agraf.Van_el(1, 2));
            Console.WriteLine(agraf.Van_el(0, 2));
            Console.WriteLine(agraf.Fokszam(1));
        }
    }
}
