using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P4_reklam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string[]> adatok = new List<string[]>();

            Console.WriteLine("kezdés");
            using (StreamReader r = new StreamReader("rendel.txt", Encoding.UTF8))
            {
                string[] line;
                while (!r.EndOfStream)
                {
                    adatok.Add(new string[3](r.ReadLine().Split(' ')));
                    adatok[-1] = r.ReadLine().Split(' ');
                }
            }

            // 2.
            Console.WriteLine(adatok.Count());
        }
    }
}
