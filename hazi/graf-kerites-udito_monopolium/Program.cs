using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graf_kerites_udito_monopolium
{
    internal class Program
    {
        public class Graf
        {

            List<int>[] szomszedsagi_lista;

            public Graf()
            {
                string[] sor = Console.ReadLine().Split(' ');
                int T = int.Parse(sor[0]);


                
                // tesztesetek
                for (int i = 0; i < T; i++)
                {

                }

                sor = Console.ReadLine().Split(' ');
                int N = int.Parse(sor[0]), M = int.Parse(sor[1]);

                szomszedsagi_lista = new List<int>[N];
                for (int i = 0; i < N; i++)
                    szomszedsagi_lista[i] = new List<int>();

                for (int i = 0; i < M; i++)
                {
                    sor = Console.ReadLine().Split(' ');
                    szomszedsagi_lista[int.Parse(sor[0])].Add(int.Parse(sor[1]));
                }
            }

            public void Diagnosztika()
            {
                Console.WriteLine("\n\n-----------------------\nDiagnosztika\n- - - - - - - - - - - -\n");
                for (int i = 0; i < szomszedsagi_lista.Length; i++)
                    Console.Write($"[{i}]: [{String.Join(", ", szomszedsagi_lista[i])}]\n");
                Console.WriteLine("\n-----------------------\n");
            }



            public bool El_lehet_e_jutni_melysegivel(int innen, int ide)
            {
                int feher = 0, szurke = 1, fekete = 2;

                int[] szin = new int[szomszedsagi_lista.Length];

                Stack<int> tennivalok = new Stack<int>();
                tennivalok.Push(innen);
                szin[innen] = szurke;

                int feldolgozando;
                while (tennivalok.Count != 0)
                {
                    feldolgozando = tennivalok.Pop();
                    if (feldolgozando == ide)
                        return true;
                    szin[feldolgozando] = fekete;

                    foreach (int szomszed in szomszedsagi_lista[feldolgozando])
                        if (szin[szomszed] == feher)
                        {
                            tennivalok.Push(szomszed);
                            szin[szomszed] = szurke;
                        }
                }

                return false;
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
