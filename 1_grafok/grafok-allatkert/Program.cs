using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace grafok_allatkert
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] sor = Console.ReadLine().Split(' ');            
            int N = int.Parse(sor[0]);
            int M = int.Parse(sor[1]);


            int[][] pontok = new int[N][];
            foreach (var item in pontok)
            {
                item = 0;
            }

            for (int i = 0; i < N; i++)
            {
                sor = Console.ReadLine().Split(' ');
                pontok[int.Parse(sor[0])] ++;
                pontok[int.Parse(sor[1])]++;
            }
        }
    }
}
