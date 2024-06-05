# Szóbeli feladatai
*megírás alatt*

## A - Stílusok



## B - Programírás megadott függvény használatával | [Program.cs](./szobeli-B/Program.cs)

### Feladat:

Bla bla bla [...]. Írjon egy programot ```kronogramm``` néven, ami a megadott latin szöveg számértékét adja vissza. [...].

```
Függvény RomaiSzam(kar: Karakter): Szám
    ertek := 0
    Elágazás
        'I' esetén:
            ertek = 1
        'V' esetén:
            ertek = 5
        'X' esetén:
            ertek = 10
        'L' esetén:
            ertek = 50
        'C' esetén:
            ertek = 100
        'D' esetén:
            ertek = 500
        'M' esetén:
            ertek = 1000
    visszaad ertek
Függvény vége.
```

### Megoldás:

#### Kód C#-ban
```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szobeli_B
{
    internal class Program
    {
        public static int RomaiSzam(char kar)
        {
            int ertek = 0;
            switch (kar)
            {
                case 'I':
                    ertek = 1;
                    break;
                case 'V':
                    ertek = 5;
                    break;
                case 'X':
                    ertek = 10;
                    break;
                case 'L':
                    ertek = 50;
                    break;
                case 'C':
                    ertek = 100;
                    break;
                case 'D':
                    ertek = 500;
                    break;
                case 'M':
                    ertek = 1000;
                    break;
            }
            return ertek;
        }

        static void Main(string[] args)
        {
            Console.Write("Kronogramma: ");
            string bemenet = Console.ReadLine();
            int eredmeny = 0;
            foreach (char karakter in bemenet)
            {
                eredmeny += RomaiSzam(karakter);
            }
            Console.WriteLine($"Évszám: {eredmeny}");
        }
    }
}

```