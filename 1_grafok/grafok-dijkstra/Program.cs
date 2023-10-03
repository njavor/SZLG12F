using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafok_dijkstra
{
    internal class Program
    {
        class Graf
        {
            int[][] szomszedsagi_matrix;

            public Graf()
            {
                // BEOLVASÁS
                string[] sor = Console.ReadLine().Split(' ');
                int N = int.Parse(sor[0]), M = int.Parse(sor[1]);

                szomszedsagi_matrix = new int[N][];
                for (int i = 0; i < N; i++)
                {
                    szomszedsagi_matrix[i] = new int[N];
                    for (int j = 0; j < N; j++)
                        szomszedsagi_matrix[i][j] = int.MaxValue;
                }
                // hurokél vizsgálat
                for (int i = 0; i < N; i++)
                    for (int j = 0; j < N; j++)
                        if (i == j && szomszedsagi_matrix[i][j] == int.MaxValue)
                            szomszedsagi_matrix[i][j] = 0;



                // súlyozás feltöltése
                for (int i = 0; i < M; i++)
                {
                    sor = Console.ReadLine().Split(' ');
                    szomszedsagi_matrix[int.Parse(sor[0])][int.Parse(sor[1])] = int.Parse(sor[2]);
                    szomszedsagi_matrix[int.Parse(sor[1])][int.Parse(sor[0])] = int.Parse(sor[2]);
                }
            }

            public void Diagnosztika()
            {
                Console.Write("\n\n-----------------------\nDiagnosztika\n- - - - - - - - - - - -\n\n ");
                for (int i = 0; i < szomszedsagi_matrix.Length; i++)
                    Console.Write($" {i}");
                Console.WriteLine();
                for (int i = 0; i < szomszedsagi_matrix.Length; i++)
                {
                    Console.Write($"{i} ");
                    for (int j = 0; j < szomszedsagi_matrix.Length; j++)
                        Console.Write($"{szomszedsagi_matrix[i][j]} ");
                    Console.WriteLine();
                }

                //for (int i = 0; i < szomszedsagi_matrix.Length; i++)
                //    Console.Write($"[{i}]: [{String.Join(", ", szomszedsagi_matrix[i])}]\n");
                Console.WriteLine("\n-----------------------\n");
            }

            public void Dijkstra_algoritmus(int eredet)
            {
                List<int[]> csucslista = new List<int[]>();

                List<int> nem_latogatott = new List<int>();

                for (int i = 0; i < szomszedsagi_matrix.Length; i++)
                {
                    csucslista.Add(new int[] {-1,int.MaxValue}); // {előző csúcs, legrövidebb út}
                    nem_latogatott.Add(i);
                }

                //VIZSGÁLAT
                int ut;

                int vizsgalt = eredet;
                csucslista[vizsgalt][1] = 0;

                while (!nem_latogatott.Any())
                {
                    for (int i = 0; i < length; i++)
                    {
                        ut = vizsgalt + szomszedsagi_matrix[i][i];
                        if (ut < csucslista[i][1])
                        {
                            csucslista[i][0] = vizsgalt;
                            csucslista[i][1] = ut;
                        }
                    }


                    nem_latogatott.Remove(vizsgalt);
                }
            }
        }
        static void Main(string[] args)
        {
            Graf zsiraf = new Graf();

            zsiraf.Diagnosztika();
        }
    }
}


/*
5 7
0 1 6
0 3 1
1 2 5
1 3 2
1 4 2
2 4 5
3 4 1


>>
  0 1 2 3 4
0 0 6 X 1 X
1 6 0 5 2 2
2 X 5 0 X 5
3 1 2 X 0 1
4 X 2 5 1 0
*/