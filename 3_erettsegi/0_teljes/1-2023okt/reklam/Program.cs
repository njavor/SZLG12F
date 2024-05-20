using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;

namespace reklam
{
    internal class Program
    {
        // 6. feladat
        static int osszes(string v, int n, List<Rendeles> r)
        {
            int sum = r.Where(x => x.nap == n).Where(x => x.varos == v).Sum(x => x.db);
            return sum;
        }

        class Rendeles
        {
            public int nap;
            public string varos;
            public int db;

            public Rendeles(int n, string v, int d)
            {
                nap = n;
                varos = v;
                db = d;
            }
        }

        static void Main(string[] args)
        {
            #region beolvasás
            List<Rendeles> rendelesek = new List<Rendeles>();
            using (StreamReader r = new StreamReader("rendel.txt", Encoding.UTF8))
            {
                string[] sor;
                while (!r.EndOfStream)
                {
                    sor = r.ReadLine().Split(' ');
                    rendelesek.Add(new Rendeles(int.Parse(sor[0]), sor[1], int.Parse(sor[2])));
                }
            }
            #endregion



            #region megoldás
            // 2. feladat
            Console.WriteLine("2. feladat:");
            Console.WriteLine($"A rendelések száma: {rendelesek.Count}");


            // 3. feladat
            Console.Write("3. feladat:\nKérem, adjon meg egy napot: ");
            int q = int.Parse(Console.ReadLine());

            Console.WriteLine($"A rendelések száma az adott napon: {rendelesek.Count(x => x.nap == q)}");


            // 4. feladat
            int i = rendelesek.Where(x => x.varos == "NR").GroupBy(x => x.nap).ToList().Count;

            Console.WriteLine("4. feladat:");
            Console.WriteLine(30 - i == 0 ? "Minden nap volt rendelés a reklámban nem érintett városból" : $"{30-i} nap nem volt a reklámban nem érintett városból rendelés");


            // 5. feladat
            int max = rendelesek.Max(x => x.db);

            Console.WriteLine("5. feladat:");
            Console.WriteLine($"A legnagyobb darabszám: {max}, a rendelés napja: {rendelesek.Find(x => x.db == max).nap}");


            // 7. feladat
            Console.WriteLine("7. feladat:");
            Console.WriteLine($"A rendelt termékek darabszáma a 21. napon PL: {osszes("PL", 21, rendelesek)} TV: {osszes("TV", 21, rendelesek)} NR: {osszes("NR", 21, rendelesek)}");


            // 8. feladat
            List<Rendeles> pl = rendelesek.Where(x => x.varos == "PL").ToList();
            List<Rendeles> tv = rendelesek.Where(x => x.varos == "TV").ToList();
            List<Rendeles> nr = rendelesek.Where(x => x.varos == "NR").ToList();

            Console.WriteLine("8. feladat:");
            Console.WriteLine("Napok\t1..10\t11..20\t21..30");
            Console.WriteLine($"PL\t{pl.Where(x => x.nap <= 10).Count()}\t{pl.Where(x => 11 <= x.nap).Where(x => x.nap <= 20).Count()}\t{pl.Where(x => 21 <= x.nap).Count()}");
            Console.WriteLine($"TV\t{tv.Where(x => x.nap <= 10).Count()}\t{tv.Where(x => 11 <= x.nap).Where(x => x.nap <= 20).Count()}\t{tv.Where(x => 21 <= x.nap).Count()}");
            Console.WriteLine($"NR\t{nr.Where(x => x.nap <= 10).Count()}\t{nr.Where(x => 11 <= x.nap).Where(x => x.nap <= 20).Count()}\t{nr.Where(x => 21 <= x.nap).Count()}");

            using(StreamWriter w = new StreamWriter("kampany.txt"))
            {
                w.WriteLine("Napok\t1..10\t11..20\t21..30");
                w.WriteLine($"PL\t{pl.Where(x => x.nap <= 10).Count()}\t{pl.Where(x => 11 <= x.nap).Where(x => x.nap <= 20).Count()}\t{pl.Where(x => 21 <= x.nap).Count()}");
                w.WriteLine($"TV\t{tv.Where(x => x.nap <= 10).Count()}\t{tv.Where(x => 11 <= x.nap).Where(x => x.nap <= 20).Count()}\t{tv.Where(x => 21 <= x.nap).Count()}");
                w.WriteLine($"NR\t{nr.Where(x => x.nap <= 10).Count()}\t{nr.Where(x => 11 <= x.nap).Where(x => x.nap <= 20).Count()}\t{nr.Where(x => 21 <= x.nap).Count()}");
            }
            #endregion
        }
    }
}
