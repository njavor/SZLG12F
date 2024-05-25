using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace belepteto
{
    internal class Program
    {
        public class Esemeny
        {
            public string azonosito;
            public int idopont;
            public int tipus;

            public Esemeny(string a, int i, int t)
            {
                azonosito = a;
                idopont = i;
                tipus = t;
            }
        }

        static void Main(string[] args)
        {
            List<Esemeny> esemenyek = new List<Esemeny>();

            using (StreamReader r = new StreamReader("bedat.txt", Encoding.UTF8))
            {
                string[] sor;
                while (!r.EndOfStream)
                {
                    sor = r.ReadLine().Split();

                    esemenyek.Add(new Esemeny(sor[0], int.Parse(sor[1].Remove(2, 1)), int.Parse(sor[2])));
                }
            }




            #region 2. feladat
            Console.WriteLine("2. feladat");
            int res21 = esemenyek.First(x => x.tipus == 1).idopont;
            int res22 = esemenyek.Last(x => x.tipus == 2).idopont;

            if (res21 < 1000) Console.WriteLine($"Az első tanuló 0{res21.ToString()[0]}:{res21.ToString().Remove(0, 1)}-kor lépett be a főkapun.");
            else Console.WriteLine($"Az első tanuló {res21.ToString().Remove(2, 2)}:{res21.ToString().Remove(0, 2)}-kor lépett be a főkapun.");

            if (res22 < 1000) Console.WriteLine($"Az utolsó tanuló 0{res21.ToString()[0]}:{res21.ToString().Remove(0, 1)}-kor lépett ki a főkapun.");
            else Console.WriteLine($"Az utolsó tanuló {res22.ToString().Remove(2, 2)}:{res22.ToString().Remove(0, 2)}-kor lépett ki a főkapun.");
            #endregion


            #region 3. feladat
            List<Esemeny> res3 = esemenyek.Where(x => x.tipus == 1 && 750 < x.idopont && x.idopont <= 815).ToList();

            using (StreamWriter w = new StreamWriter("kesok.txt"))
            {
                foreach (Esemeny e in res3)
                {
                    w.WriteLine($"0{e.idopont.ToString()[0]}:{e.idopont.ToString().Remove(0, 1)} {e.azonosito}");
                }
            }
            #endregion


            #region 4. feladat
            Console.WriteLine("4. feladat");
            int res4 = esemenyek.Count(x => x.tipus == 3);

            Console.WriteLine($"A menzán aznap {res4} tanuló ebédelt.");
            #endregion


            #region 5. feladat
            Console.WriteLine("5. feladat");
            int res5 = esemenyek.Where(x => x.tipus == 4).GroupBy(x => x.azonosito).Count();

            Console.WriteLine($"Aznap {res5} tanuló kölcsönzött a könyvtárban.");
            Console.WriteLine(res4 < res5 ? "Többen voltak, mint a menzán" : "Nem voltak többen, mint a menzán.");
            #endregion


            #region 6. feladat
            Console.WriteLine("6. feladat");
            List<string> checker6 = new List<string>();

            Console.WriteLine($"Az érintett tanulók:");
            foreach (Esemeny e in esemenyek)
            {
                if(esemenyek.Count(x => x.azonosito == e.azonosito && x.tipus == 1) > esemenyek.Count(x => x.azonosito == e.azonosito && x.tipus == 2))
                {
                    if (!checker6.Contains(e.azonosito))
                    {
                        checker6.Add(e.azonosito);
                        Console.Write($"{e.azonosito} ");
                    }
                }
            }
            Console.WriteLine();
            #endregion


            #region 7. feladat
            Console.WriteLine("7. feladat");
            Console.Write("Egy tanuló azonosítója=");
            string in7  = Console.ReadLine();
            List<Esemeny> list7 = esemenyek.Where(x => x.azonosito == in7 && (x.tipus == 1 || x.tipus == 2)).ToList();
            if (list7.Count == 0)
                Console.WriteLine("Ilyen azonosítójú tanuló aznap nem volt az iskolában.");
            else
            {
                int be7 = list7.First(x => x.tipus == 1).idopont;
                int ki7 = list7.Last(x => x.tipus == 2).idopont;
                if (be7 < 1000) be7 = be7.ToString()[0] * 60 + int.Parse(be7.ToString().Remove(0, 1));
                else be7 = int.Parse(be7.ToString().Remove(2, 2)) * 60 + int.Parse(be7.ToString().Remove(0, 2));

                if (ki7 < 1000) ki7 = ki7.ToString()[0] * 60 + int.Parse(ki7.ToString().Remove(0, 1));
                else ki7 = int.Parse(ki7.ToString().Remove(2, 2)) * 60 + int.Parse(ki7.ToString().Remove(0, 2));

                Console.WriteLine($"A tanuló érkezése és távozása között {(ki7 - be7) / 60} óra {(ki7 - be7) % 60} perc telt el.");
            }
            #endregion
        }
    }
}
