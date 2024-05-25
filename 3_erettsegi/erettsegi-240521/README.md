# Érettségi 2024 - digitális kultúra emelt szint

## Információ
helyszín: BMSZC Pataky István Híradásipari és Informatikai Technikum

dátum: 2024.05.21.

[feladatsor](./e_digkult_24maj_fl.pdf)

---

## 1B. Lámpák (táblázatkezelés)

##### 3. Véletlenszerű kapcsolás
```excel
INDEX($C$1:$H$1;1;VÉLETLEN.KÖZÖTT(1;6))
```

#### 5. Le-/felkapcsolás megjelenítése
```excel
HA($B3=C$1;HA(C2="Ég";"";"Ég");C2)
```

#### 6. Aktuálisan égő lámpák száma
```excel
DARABHATÖBB(C3:H3;"Ég")
```

#### 7. Feltételes formázás
```excel
$I3=6
```

#### 10. Adott száma égő lámpa előfordulása
```excel
DARABHATÖBB($I$3:$I$102;L3)
```

#### 11. Első kapcsolás, ahol minden lámpa ég
```excel
HAHIÁNYZIK(INDEX(A3:I102;HOL.VAN(6;I3:I102;0);1);"Nincs ilyen")
```






## 2. Ingatlanközvetítő iroda (adatbázis-kezelés)

#### 2. Közterületek, ahol lakásokat kínálnak
```sql
SELECT DISTINCT(kozterulet)
FROM ingatlan
WHERE lakas = 1
ORDER BY kozterulet
;
```

#### 3. ```Agyagos utca``` ingatlanjainak meghirdetési árai
```sql
SELECT hazszam, ar
FROM hirdetes, ingatlan
WHERE ingatlanid = ingatlan.id
    AND kozterulet = "Agyagos utca" 
    AND allapot = "meghirdetve"
    ;
```

#### 4. Bevétel 2021-ben
```sql
SELECT SUM(ar*0.015)
FROM hirdetes
WHERE allapot = "eladva" 
    AND YEAR(datum) = 2021
    ;
```

#### 5. Legdrágább és legolcsóbb meghirdetés aránya
```sql
SELECT MAX(ar) / MIN(ar)
FROM hirdetes
WHERE allapot = "meghirdetve"
;
```

#### 6. Legrégebben meghirdetett, nem eladott/módosított ingatlan
```sql
SELECT kozterulet, hazszam, datum
FROM hirdetes, ingatlan
WHERE ingatlanid = ingatlan.id
    AND hirdetes.ingatlanid NOT IN (SELECT ingatlanid FROM hirdetes WHERE allapot != "meghirdetve")
ORDER BY datum
LIMIT 1
;
```

#### 7. Azonos áron meghirdetett és eladott ingatlanok
```sql
SELECT kozterulet, hazszam, hirdetes.ar
FROM hirdetes, hirdetes AS seged1, ingatlan
WHERE hirdetes.ingatlanid = ingatlan.id
    AND hirdetes.ingatlanid = seged.ingatlanid 
    AND hirdetes.ar = seged1.ar 
    AND hirdetes.allapot = "meghirdetve" 
    AND seged1.allapot = "eladva"
    ;
```

#### 8. Külön konyha és WC nélküli ingatlanok
```sql
SELECT kozterulet, hazszam
FROM ingatlan
WHERE id NOT IN (SELECT ingatlanid FROM helyiseg WHERE funkcio = "konyha")
    AND id NOT IN (SELECT ingatlanid FROM helyiseg WHERE funkcio = "WC");
```

#### 9. 180 m<sup>2</sup>-nél nagyobb alapterületű ingatlanok
```sql
SELECT kozterulet, hazszam, SUM(IF(funkcio = "terasz", hossz*szel/2, hossz*szel))
FROM helyiseg, ingatlan
WHERE ingatlanid = ingatlan.id
GROUP BY ingatlanid
HAVING 180 < SUM(IF(funkcio = "terasz", hossz*szel/2, hossz*szel))
;
```





## 3. Beléptető rendszer (algoritmizálás és programozás)

#### 0. Használt class
```cs
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
```
#### 1. Beolvasás 
```cs
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
```
#### 2. Első és utolsó be- és kilépés
```cs
Console.WriteLine("2. feladat");
int res21 = esemenyek.First(x => x.tipus == 1).idopont;
int res22 = esemenyek.Last(x => x.tipus == 2).idopont;

if (res21 < 1000) Console.WriteLine($"Az első tanuló 0{res21.ToString()[0]}:{res21.ToString().Remove(0, 1)}-kor lépett be a főkapun.");
else Console.WriteLine($"Az első tanuló {res21.ToString().Remove(2, 2)}:{res21.ToString().Remove(0, 2)}-kor lépett be a főkapun.");

if (res22 < 1000) Console.WriteLine($"Az utolsó tanuló 0{res21.ToString()[0]}:{res21.ToString().Remove(0, 1)}-kor lépett ki a főkapun.");
else Console.WriteLine($"Az utolsó tanuló {res22.ToString().Remove(2, 2)}:{res22.ToString().Remove(0, 2)}-kor lépett ki a főkapun.");
```
#### 3. Késők összegyűjtése
```cs
List<Esemeny> res3 = esemenyek.Where(x => x.tipus == 1 && 750 < x.idopont && x.idopont <= 815).ToList();

using (StreamWriter w = new StreamWriter("kesok.txt"))
{
    foreach (Esemeny e in res3)
    {
        w.WriteLine($"0{e.idopont.ToString()[0]}:{e.idopont.ToString().Remove(0, 1)} {e.azonosito}");
    }
}
```
#### 4. Menzán ebédelők száma
```cs
Console.WriteLine("4. feladat");
int res4 = esemenyek.Count(x => x.tipus == 3);

Console.WriteLine($"A menzán aznap {res4} tanuló ebédelt.");
```
#### 5. Könyvkölcsönzők száma, összehasonlítás
```cs
Console.WriteLine("5. feladat");
int res5 = esemenyek.Where(x => x.tipus == 4).GroupBy(x => x.azonosito).Count();

Console.WriteLine($"Aznap {res5} tanuló kölcsönzött a könyvtárban.");
Console.WriteLine(res4 < res5 ? "Többen voltak, mint a menzán" : "Nem voltak többen, mint a menzán.");
```
#### 6. Kiszökő diákok
```cs
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
```
#### 7. Iskolában töltött idő
```cs
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
```