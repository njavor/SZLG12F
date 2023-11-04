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
            int count = queue.Count;

            while (count > 0)
            {
                int current = queue.Dequeue();

                foreach (int neighbor in graph[current])
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

            weeks++;
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
