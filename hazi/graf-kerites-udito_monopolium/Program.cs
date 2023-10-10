using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graf_kerites_udito_monopolium
{
    internal class Program
    {
        class Bergengoc
        {
            public int italpreferencia; //Calo vagy Pipse
            public List<int> baratok;

            public Bergengoc(int ital)
            {
                italpreferencia = ital;
                baratok = new List<int>();
            }

            public void Diagnosztika()
            {
                Console.WriteLine("\n\n-----------------------\nDiagnosztika - bergeng\n- - - - - - - - - - - -\n");
                for (int i = 0; i < baratok.Count(); i++)
                    Console.Write($"[{i} - ital:{italpreferencia}]: [{String.Join(", ", baratok[i])}]\n");
                Console.WriteLine("\n-----------------------\n");
            }
        }
        class Teszteset
        {
            List<Bergengoc> bergengoclista;

            public Teszteset(int N, int M)
            {
                bergengoclista = new List<Bergengoc>();
                string[] sor = Console.ReadLine().Split(' ');
                for (int i = 0; i < N; i++)
                    bergengoclista.Add(new Bergengoc(int.Parse(sor[i])));

                for (int j = 0; j < M; j++)
                {
                    sor = Console.ReadLine().Split(' ');
                    //kölcsönös a kapcsolat
                    bergengoclista[int.Parse(sor[0])-1].baratok.Add(int.Parse(sor[1]) - 1);
                    bergengoclista[int.Parse(sor[1]) - 1].baratok.Add(int.Parse(sor[0]) - 1);
                }
            }

            public void Diagnosztika()
            {
                Console.WriteLine("\n\n-----------------------\nDiagnosztika\n- - - - - - - - - - - -\n");
                for (int i = 0; i < bergengoclista.Count(); i++)
                {
                    Console.Write($"[{i} - ital:{bergengoclista[i].italpreferencia}]: [{String.Join(", ", bergengoclista[i].baratok)}]\n");
                }
                Console.WriteLine("\n-----------------------\n");
            }
        }
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());
            List<Teszteset> tesztesetek = new List<Teszteset>();

            string[] sor;
            int N, M;
            for (int i = 0; i < T; i++)
            {
                sor = Console.ReadLine().Split(' ');
                N = int.Parse(sor[0]);
                M = int.Parse(sor[1]);

                tesztesetek.Add(new Teszteset(N, M));
            }




            //diagnosztika
            /*
             */
            foreach (var teszt in tesztesetek)
            {
                Console.WriteLine("TESZTEK DIAGNOSZTIKÁJA");
                teszt.Diagnosztika();
            }
        }
    }
}

/*

Gondolatmenet:
    meg kell keresni a legtöbb baráttal rendelkező bergengócot,
    úgy hogy a kevésbé szeretett üdítőt szeresse.


* Példa bemenet
2
4 3
0 1 0 0
1 2
2 3
2 4
5 4
0 1 1 0 1
1 2
2 3
3 4
4 5

2
4 3
0 1 0 0
0 1
1 2
1 3
5 4
0 1 1 0 1
0 1
1 2
2 3
3 4

 * Példa kimenet
1
2
*/