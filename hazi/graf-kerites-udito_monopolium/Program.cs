using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int T = int.Parse(Console.ReadLine()); // tesztesetek száma
        int[] results = new int[T];

        for (int t = 0; t < T; t++)
        {
            string[] input = Console.ReadLine().Split();
            int N = int.Parse(input[0]); // bergengócok száma
            int M = int.Parse(input[1]); // baráti kapcsolatok száma

            int[] preferences = Console.ReadLine().Split().Select(int.Parse).ToArray(); // Bergengócok kezdeti preferenciái

            List<int>[] graph = new List<int>[N + 1];
            for (int i = 1; i <= N; i++)
                graph[i] = new List<int>();

            for (int i = 0; i < M; i++)
            {
                int[] edge = Console.ReadLine().Split().Select(int.Parse).ToArray();
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            int[] weeksNeeded = GetWeeksNeeded(N, preferences, graph);
            results.Append(weeksNeeded.Max());
        }
        foreach (int res in results)
        {
            Console.WriteLine(res);
        }
    }

    static int[] GetWeeksNeeded(int N, int[] preferences, List<int>[] graph)
    {
        int[] weeksNeeded = new int[N + 1];
        Queue<int> queue = new Queue<int>();
        bool[] visited = new bool[N + 1];

        for (int i = 1; i <= N; i++)
        {
            if (!visited[i])
            {
                visited[i] = true;
                queue.Enqueue(i);

                while (queue.Count > 0)
                {
                    int current = queue.Dequeue();

                    foreach (int neighbor in graph[current])
                    {
                        if (!visited[neighbor])
                        {
                            visited[neighbor] = true;
                            preferences[neighbor - 1] = preferences[current - 1];
                            queue.Enqueue(neighbor);
                            weeksNeeded[neighbor] = weeksNeeded[current] + 1;
                        }
                    }
                }
            }
        }

        return weeksNeeded;
    }
}
