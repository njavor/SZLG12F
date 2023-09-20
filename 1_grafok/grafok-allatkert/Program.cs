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
            int N = int.Parse(sor[0]),M = int.Parse(sor[1]);


            Dictionary<int, int> szotar = new Dictionary<int, int>();
            for (int i = 0; i < M; i++)
                foreach (string szam in Console.ReadLine().Split(' '))
                    if (szotar.ContainsKey(int.Parse(szam)))
                        szotar[int.Parse(szam)] += 1;
                    else
                        szotar[int.Parse(szam)] = 1;


            int maxkulcs = -1, max = 0;
            foreach (int kulcs in szotar.Keys)
                if (szotar[kulcs] > max)
                {
                    maxkulcs = kulcs;
                    max = szotar[kulcs];
                }

            // legtöbb helyről elérhető
            Console.WriteLine(maxkulcs + " " + max);
        }
    }
}
