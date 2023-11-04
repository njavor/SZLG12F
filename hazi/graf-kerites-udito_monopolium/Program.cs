using System;
using System.Collections.Generic;

class Program
{
    static List<int>[] graph;
    static int[] drinks;

    static int BFS(int start)
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);

        int[] visited = new int[drinks.Length];
        visited[start] = 1;

        int targetDrink = drinks[start];
        int weeks = 0;

        while (queue.Count > 0)
        {
            public bool italpreferencia; //Calo (0) vagy Pipse (1)
            public List<int> baratok;

            while (count > 0)
            {
                int current = queue.Dequeue();

            public void Diagnosztika()
            {
                Console.WriteLine("\n\n-----------------------\nDiagnosztika - bergeng\n- - - - - - - - - - - -\n");
                for (int i = 0; i < baratok.Count(); i++)
                    Console.Write($"[{i} - ital:{italpreferencia}]: [{String.Join(", ", baratok[i])}]\n");
                Console.WriteLine("\n-----------------------\n");
            }

            public void Italvaltas() => italpreferencia = !italpreferencia;
        }
        class Teszteset
        {
            List<Bergengoc> bergengoclista;
            (int C, int P) = (0,0);

            public Teszteset(int N, int M)
            {
                bergengoclista = new List<Bergengoc>();
                string[] sor = Console.ReadLine().Split(' ');
                for (int i = 0; i < N; i++)
                    bergengoclista.Add(new Bergengoc(int.Parse(sor[i])));

                for (int j = 0; j < M; j++)
                {
                    if (visited[neighbor] == 0)
                    {
                        visited[neighbor] = 1;
                        queue.Enqueue(neighbor);

                        if (drinks[neighbor] != targetDrink)
                        {
                            drinks[neighbor] = targetDrink;
                        }
                    }
                }

                count--;
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

        return weeks;
    }

    static void Main(string[] args)
    {
        int T = int.Parse(Console.ReadLine());

        for (int t = 0; t < T; t++)
        {
            string[] input = Console.ReadLine().Split();
            int N = int.Parse(input[0]);
            int M = int.Parse(input[1]);

            drinks = new int[N];
            graph = new List<int>[N];

            for (int i = 0; i < N; i++)
            {
                drinks[i] = int.Parse(Console.ReadLine());
                graph[i] = new List<int>();
            }

            for (int i = 0; i < M; i++)
            {
                input = Console.ReadLine().Split();
                int u = int.Parse(input[0]) - 1;
                int v = int.Parse(input[1]) - 1;

                graph[u].Add(v);
                graph[v].Add(u);
            }

            int result = BFS(0);
            Console.WriteLine(result);
        }
    }
}
