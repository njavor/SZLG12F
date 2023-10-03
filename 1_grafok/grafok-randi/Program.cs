using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafok_randi
{
    internal class Program
    {
        public class Csucslista_graf
        {
            List<int>[] szomszedsagi_lista;
            int E; //éva hely
            int A; //ádám hely
            int R; //találkahely

            public Csucslista_graf() //konstruktor
            {
                string[] sor = Console.ReadLine().Split(' ');
                int N = int.Parse(sor[0]); //városok száma
                int M = int.Parse(sor[4]); //járatok száma
                
                E = int.Parse(sor[1]);
                A = int.Parse(sor[2]);
                R = int.Parse(sor[3]);


                szomszedsagi_lista = new List<int>[N];
                for (int i = 0; i < N; i++)
                    szomszedsagi_lista[i] = new List<int>();

                for (int i = 0; i < M; i++)
                {
                    sor = Console.ReadLine().Split(' ');
                    szomszedsagi_lista[int.Parse(sor[0])-1].Add(int.Parse(sor[1])-1);
                }
            }

            public void Diagnosztika()
            {
                Console.WriteLine("\n\n-----------------------\nDiagnosztika\n- - - - - - - - - - - -");
                Console.WriteLine("ne feledd, +1\n\n");
                for (int i = 0; i < szomszedsagi_lista.Length; i++)
                    Console.Write($"[{i}]: [{String.Join(", ", szomszedsagi_lista[i])}]\n");
                Console.WriteLine("\n-----------------------\n");
            }

            public bool Izolalt(int ez) => szomszedsagi_lista[ez] == null;


            
            public bool El_lehet_e_jutni_szelessegivel(int innen, int ide)
            {
                //szinek
                int fehér = 0, szürke = 1, fekete = 2;

                int[] szin = new int[szomszedsagi_lista.Length];

                Queue<int> tennivalok = new Queue<int>();
                tennivalok.Enqueue(innen);
                szin[innen] = szürke;

                int feldolgozando;
                while (tennivalok.Count != 0)
                {
                    //feldolgozás
                    feldolgozando = tennivalok.Dequeue();
                    if (feldolgozando == ide)
                        return true;
                    szin[feldolgozando] = fekete;

                    //feldolgozandok felvétele
                    foreach (int szomszed in szomszedsagi_lista[feldolgozando])
                        if (szin[szomszed] == fehér)
                        {
                            tennivalok.Enqueue(szomszed);
                            szin[szomszed] = szürke;
                        }
                }
                return false;
            }

            public List<int> Legrovidebb_ut(int innen, int ide)
            {
                List<int> result = new List<int>;

                return result;
            }

            public void Randi()
            {
                if (El_lehet_e_jutni_szelessegivel(E, R) && El_lehet_e_jutni_szelessegivel(A, R))
                {
                    Console.WriteLine("INJGNEOINEOIF");
                }
            }
        }

        static void Main(string[] args)
        {
            Csucslista_graf agraf = new Csucslista_graf();
            agraf.Diagnosztika();

            agraf.Randi();
        }
    }
}

/*
10 2 3 7 12
2 1
1 6
7 6
6 8
8 7
7 9
9 4
5 7
10 5
3 5
3 4
4 5

*/