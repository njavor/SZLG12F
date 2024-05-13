using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _5_epitmenyado
{
    internal class Program
    {
        class Telek
        {
            public int adoszam;
            public string nev;
            public string hazszam;
            public string adosav;
            public int alapterulet;

            public Telek(int aszam, string n, string hszam, string asav, int ter)
            {
                adoszam = aszam;
                nev = n;
                hazszam = hszam;
                adosav = asav;
                alapterulet = ter;
            }
        }

        public int ado(string adosav, int alapterulet, int A, int B, int C)
        {
            int fizetendo = 0;
            switch (adosav)
            {
                case "A":
                    fizetendo = alapterulet * A;
                    break;
                case "B":
                    fizetendo = alapterulet * B;
                    break;
                case "C":
                    fizetendo = alapterulet * C;
                    break;
            }

            if (fizetendo < 10000)
                return 0;
            else
                return fizetendo;
        }

        static void Main(string[] args)
        {
            int A, B, C;    // adósávok

            List<Telek> teleklista = new List<Telek>();

            using (StreamReader r = new StreamReader("utca.txt", Encoding.UTF8))
            {
                string[] sor = r.ReadLine().Split(' ');
                A = int.Parse(sor[0]);
                B = int.Parse(sor[1]);
                C = int.Parse(sor[2]);
                
                while (!r.EndOfStream)
                {
                    sor = r.ReadLine().Split(' ');
                    teleklista.Add(new Telek(int.Parse(sor[0]), sor[1], sor[2], sor[3], int.Parse(sor[4])));
                }
            }
            #region ReadIn teszt
            /*
            foreach (var tel in teleklista)
            {
                Console.Write(tel.adoszam + " ");
                Console.Write(tel.nev + " ");
                Console.Write(tel.hazszam + " ");
                Console.Write(tel.adosav + " ");
                Console.WriteLine(tel.alapterulet);
            }
            */
            #endregion

            #region 2. feladat
            Console.WriteLine($"2. feladat. A mintában {teleklista.Count} telek szerepel.");
            #endregion

            #region 3. feladat
            Console.Write($"3. feladat. Egy tulajdonos adószáma: ");
            int input3 = int.Parse(Console.ReadLine());
            bool szerepel = false;
            foreach(var telek in teleklista)
            {
                if(telek.adoszam == input3){
                    Console.WriteLine($"{telek.nev} utca {telek.hazszam}");
                    szerepel = true;
                }
            }
            if (!szerepel) { Console.WriteLine("Nem szerepel az adattartományban."); }
            #endregion

            #region 5. feladat
            Console.WriteLine($"5. feladat");
            Console.WriteLine($"A sávba {teleklista.Count(x => x.adosav == "A")} telek esik, az adó {teleklista.Where(x => x.adosav == "A").Where(x => x.alapterulet * A >= 10000).Sum(x => x.alapterulet * A)} Ft");
            Console.WriteLine($"B sávba {teleklista.Count(x => x.adosav == "B")} telek esik, az adó {teleklista.Where(x => x.adosav == "B").Where(x => x.alapterulet * B >= 10000).Sum(x => x.alapterulet * B)} Ft");
            Console.WriteLine($"C sávba {teleklista.Count(x => x.adosav == "C")} telek esik, az adó {teleklista.Where(x => x.adosav == "C").Where(x => x.alapterulet * C >= 10000).Sum(x => x.alapterulet * C)} Ft");
            #endregion

            #region 6. feladat
            Console.WriteLine("6. feladat. A több sávba sorsolt utcák:");
            Console.WriteLine()
            #endregion
        }
    }
}
