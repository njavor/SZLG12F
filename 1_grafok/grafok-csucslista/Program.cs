using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafok_csucslista
{
    internal class Program
    {
        public class Csucslista_graf
        {
            List<int>[] szomszedsagi_lista;

            public Csucslista_graf() //konstruktor
            {
                string[] sor = Console.ReadLine().Split(' ');
                int M = int.Parse(sor[1]);

                szomszedsagi_lista = new List<int>[int.Parse(sor[0])];
                for (int i = 0; i < szomszedsagi_lista.Length; i++)
                    szomszedsagi_lista[i] = new List<int>();

                for (int i = 0; i < M; i++)
                {
                    sor = Console.ReadLine().Split(' ');
                    szomszedsagi_lista[int.Parse(sor[0])].Add(int.Parse(sor[1]));
                }
            }

            public void Diagnosztika()
            {
                Console.WriteLine("\n\n-----------------------\nDiagnosztika\n- - - - - - - - - - - -\n");
                for (int i = 0; i < szomszedsagi_lista.Length; i++)
                    Console.Write($"[{i}]: [{String.Join(", ", szomszedsagi_lista[i])}]\n");
                Console.WriteLine("\n-----------------------\n");
            }


            /* FELADATOK */
            public bool Van_el(int innen, int ide) => szomszedsagi_lista[innen].Contains(ide);

            /// <summary>
            /// megadja, hogy hány él megy ki egy adott csúcsból
            /// </summary>
            public int Kifok(int innen) => szomszedsagi_lista[innen].Count();

            /// <summary>
            /// Izolált-e a csúcs?
            /// </summary>
            public bool Izolalt(int ez) => szomszedsagi_lista[ez] == null;

            /// <summary>
            /// <summary>
            /// pontosan akkor igaz, ha van egy hurokél a csúcs körül
            /// </summary>
            public bool Van_e_hurok(int itt) => szomszedsagi_lista[itt].Contains(itt);


            /// <summary>
            /// Megmondja, hogy hány él van a gráfban.
            /// </summary>
            public int Elek_szama()
            {
                int res = 0;
                foreach (List<int> lista in szomszedsagi_lista)
                    res += lista.Count();
                return res;
            }





            /// <summary>
            /// fehér - hozzá sem értünk | szürke - még nem dolgoztuk fel | fekete - feldolgoztuk, kész, vége
            /// </summary>
            public bool El_lehet_e_jutni_szelessegivel(int innen, int ide)
            {
                //szinek
                int fehér = 0, szürke = 1, fekete = 2;

                int[] szin = new int[szomszedsagi_lista.Length];
                
                Queue<int> tennivalok = new Queue<int>();
                tennivalok.Enqueue(innen);
                szin[innen] = szürke;

                int feldolgozando;
                while (tennivalok.Count != 0)
                {
                    //feldolgozás
                    feldolgozando = tennivalok.Dequeue();
                    if (feldolgozando == ide)
                        return true;
                    szin[feldolgozando] = fekete;

                    //feldolgozandok felvétele
                    foreach (int szomszed in szomszedsagi_lista[feldolgozando])
                        if (szin[szomszed] == fehér)
                        {
                            tennivalok.Enqueue(szomszed);
                            szin[szomszed] = szürke;
                        }
                }
                return false;
            }


            /// <summary>
            /// a "nem így csináljuk", lassú megoldás
            /// </summary>
            /// <param name="innen"></param>
            /// <returns></returns>
            public int Hany_csucs_erheto_el_2(int innen)
            {
                int result = 0; //-1, mert önmagához is eltud jutni, de azt nem számoljuk
                for (int i = 0; i < szomszedsagi_lista.Length; i++)
                    if(El_lehet_e_jutni_szelessegivel(innen, i))
                        result++;
                return result;
            }
            public int Hany_csucs_erheto_el(int innen)
            {
                int result = 0;

                int fehér = 0, szürke = 1, fekete = 2;
                int[] szin = new int[szomszedsagi_lista.Length];

                Queue<int> tennivalok = new Queue<int>();
                tennivalok.Enqueue(innen);
                szin[innen] = szürke;


                int feldolgozando;
                while (tennivalok.Count != 0)
                {
                    feldolgozando = tennivalok.Dequeue();
                    result++;
                    szin[feldolgozando] = fekete;

                    foreach (int szomszed in szomszedsagi_lista[feldolgozando])
                        if (szin[szomszed] == fehér)
                        {
                            tennivalok.Enqueue(szomszed);
                            szin[szomszed] = szürke;
                        }
                }
                return result;
            }

            public int Hany_paros_csucs_erheto_el(int innen)
            {
                int result = 0;

                int fehér = 0, szürke = 1, fekete = 2;
                int[] szin = new int[szomszedsagi_lista.Length];

                Queue<int> tennivalok = new Queue<int>();
                tennivalok.Enqueue(innen);
                szin[innen] = szürke;


                int feldolgozando;
                while (tennivalok.Count != 0)
                {
                    feldolgozando = tennivalok.Dequeue();
                    if (feldolgozando %2 == 0)
                        result++;
                    szin[feldolgozando] = fekete;

                    foreach (int szomszed in szomszedsagi_lista[feldolgozando])
                        if (szin[szomszed] == fehér)
                        {
                            tennivalok.Enqueue(szomszed);
                            szin[szomszed] = szürke;
                        }
                }
                return result;
            }


            public List<int> Mely_csucsok_erhetok_el(int innen)
            {
                List<int> result = new List<int>();

                int fehér = 0, szürke = 1, fekete = 2;
                int[] szin = new int[szomszedsagi_lista.Length];

                Queue<int> tennivalok = new Queue<int>();
                tennivalok.Enqueue(innen);
                szin[innen] = szürke;


                int feldolgozando;
                while (tennivalok.Count != 0)
                {
                    feldolgozando = tennivalok.Dequeue();
                    result.Add(feldolgozando);
                    szin[feldolgozando] = fekete;

                    foreach (int szomszed in szomszedsagi_lista[feldolgozando])
                        if (szin[szomszed] == fehér)
                        {
                            tennivalok.Enqueue(szomszed);
                            szin[szomszed] = szürke;
                        }
                }
                return result;
            }


            public int Komponens_fokszamosszege(int kiindulopont)
            {
                int result = 0;

                int fehér = 0, szürke = 1, fekete = 2;
                int[] szin = new int[szomszedsagi_lista.Length];

                Queue<int> tennivalok = new Queue<int>();
                tennivalok.Enqueue(kiindulopont);
                szin[kiindulopont] = szürke;


                int feldolgozando;
                while (tennivalok.Count != 0)
                {
                    feldolgozando = tennivalok.Dequeue();
                    result += Kifok(feldolgozando);
                    szin[feldolgozando] = fekete;

                    foreach (int szomszed in szomszedsagi_lista[feldolgozando])
                        if (szin[szomszed] == fehér)
                        {
                            tennivalok.Enqueue(szomszed);
                            szin[szomszed] = szürke;
                        }
                }
                return result;
            }
        }

        static void Main(string[] args)
        {
            Csucslista_graf graf = new Csucslista_graf();
            graf.Diagnosztika();

            Console.WriteLine("------\nFELADAT: Van_el\n");
            Console.Write("Van_el(0,1): ");
            Console.WriteLine(graf.Van_el(0, 1));
            Console.Write("Van_el(0,6): ");
            Console.WriteLine(graf.Van_el(0, 6));

            Console.WriteLine("\n\n------\nFELADAT: Elek_szama");
            Console.WriteLine(graf.Elek_szama());


            //23-09-18
            Console.WriteLine("\n\n------\nFELADAT: El_lehet_e_jutni_szelessegivel");
            Console.Write("El_lehet_e_jutni_szelessegivel(5,0): ");
            Console.WriteLine(graf.El_lehet_e_jutni_szelessegivel(5,0));
            Console.Write("El_lehet_e_jutni_szelessegivel(0,5): ");
            Console.WriteLine(graf.El_lehet_e_jutni_szelessegivel(0, 5));


            //23-09-19
            Console.WriteLine("\n\n------\nFELADAT: Hany_csucs_erheto_el");
            Console.Write("Hany_csucs_erheto_el(0): ");
            Console.WriteLine(graf.Hany_csucs_erheto_el(0)); //6
            Console.Write("Hany_csucs_erheto_el(9): ");
            Console.WriteLine(graf.Hany_csucs_erheto_el(9)); //2


            //23-09-20
            Console.WriteLine("\n\n------\nFELADAT: Hany_paros_csucs_erheto_el");
            Console.Write("Hany_paros_csucs_erheto_el(0): ");
            Console.WriteLine(graf.Hany_paros_csucs_erheto_el(0)); //3
            Console.Write("Hany_paros_csucs_erheto_el(9): ");
            Console.WriteLine(graf.Hany_paros_csucs_erheto_el(9)); //0

            Console.WriteLine("\n\n------\nFELADAT: Mely_csucsok_erhetok_el");
            Console.Write("Mely_csucsok_erhetok_el(0): ");
            Console.WriteLine($"[{String.Join(",", graf.Mely_csucsok_erhetok_el(0))}]");

            Console.WriteLine("\n\n------\nFELADAT: Komponens_fokszamosszege");
            Console.Write("Komponens_fokszamosszege(0): ");
            Console.WriteLine(graf.Komponens_fokszamosszege(0));



            Console.WriteLine();
        }
    }
}

/*
6 7
0 1
1 4
3 1
3 5
2 0
2 3
1 2



12 14
0 1
1 2
1 3
1 4
2 3
3 2
3 5
4 3
4 4
5 4
6 7
8 9
10 9
9 11

*/