using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P1_Sudoku
{
    internal class Program
    {
        // program neve feladat szerint: "sudoku"
        static void Main(string[] args)
        {
            // 1.
            Console.WriteLine("1. feladat");
            Console.Write("Adja meg a bemeneti fájl nevét! ");
            string fajlnev = Console.ReadLine();
            /*Console.Write("Adja meg egy sor számát! ");
            string sor = Console.ReadLine();
            Console.Write("Adja meg egy oszlop számát! ");
            string oszlop = Console.ReadLine();
            */


            int[][] matrix = new int[9][];
            List<List<int>> lepesek = new List<List<int>>();

            // 2.
            using(var reader = new StreamReader(fajlnev))
            {
                string[] line;
                for (int i = 0; i < 9; i++)
                {
                    line = reader.ReadLine().Split(' ');
                    matrix[i] = new int[9];
                    for (int j = 0; j < 9; j++)
                    {
                        matrix[i][j] = int.Parse(line[j]);
                    }
                }
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine().Split(' ');
                    lepesek.Append(new List<int>());
                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine();
                    }
                }
            }



            
        }
    }
}
