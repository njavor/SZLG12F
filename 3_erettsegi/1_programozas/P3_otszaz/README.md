*Informatika érettségi — emelt szint <br>(2016. május 10.)*

## 4. Ötszáz

Egy apróságokat árusító boltban minden árucikk darabja 500 Ft. Ha egy vásárlás során
valaki egy adott árucikkből több darabot is vesz, a második ára már csak 450 Ft, a harmadik
pedig 400 Ft, de a negyedik és további darabok is ennyibe kerülnek, tehát az ár a harmadik
ugyanazon cikk vásárlása után már nem csökken tovább.

A pénztárhoz menők kosarában legalább 1 és legfeljebb 20 darab árucikk lehet. A kosarak
tartalmát a *penztar.txt* fájl írja le, amelyben soronként egy-egy árucikk neve vagy az F
karakter szerepel. A fájlban legfeljebb 1000 sor lehet. Az F karakter azt jelzi, hogy az adott
vásárlónak nincs már újabb árucikk a kosarában, fizetés következik. Az árucikkek neve ékezet
nélküli, több szóból is állhat, hossza legfeljebb 30 karakter.

Példa a *penztar.txt* fájl első néhány sorára:
```
toll
F
colostok
HB ceruza
HB ceruza
colostok
toll
szatyor
csavarkulcs
doboz
F
```

A példa alapján az első vásárló összesen 1 tollat vásárolt, ezért összesen 500 Ft-ot kell fizetnie. A második vásárlás során hatféle árucikket vásároltak – a HB ceruzából és a colostokból többet is –, összesen 3900 Ft értékben.

Készítsen programot, amely a *penztar.txt* állomány adatait felhasználva az alábbi
kérdésekre válaszol! A program forráskódját mentse *otszaz* néven! (A program megírásakor a felhasználó által megadott adatok helyességét, érvényességét nem kell ellenőriznie, és feltételezheti, hogy a rendelkezésre álló adatok a leírtaknak megfelelnek.)

A képernyőre írást igénylő részfeladatok eredményének megjelenítése előtt írja a képernyőre a feladat sorszámát (például: ```3. feladat:```)! Ha a felhasználótól kér be adatot, jelenítse meg a képernyőn, hogy milyen értéket vár! Az ékezetmentes kiírás is elfogadott.

<ol style="font-weight :bold">
    <li>Olvassa be és tárolja el a <i style="font-weight:normal">penztar.txt</i> fájl tartalmát!</li>
    <li>Határozza meg, hogy hányszor fizettek a pénztárnál!</li>
    <li>Írja a képernyőre, hogy az első vásárlónak hány darab árucikk volt a kosarában!</li>
    <li>Kérje be a felhasználótól egy vásárlás sorszámát, egy árucikk nevét és egy darabszámot! <br>A következő három feladat megoldásánál ezeket használja fel!</li>
</ol>

Feltételezheti, hogy a program futtasásakor csak a bemeneti állományban rögzített
adatoknak megfelelő vásárlási sorszámot és árucikknevet ad meg a felhasználó.

<ol start=5 style="font-weight: bold">
    <li>Határozza meg, hogy a bekért árucikkből
        <ol style="list-style-type: lower-alpha;">
            <li>melyik vásárláskor vettek először, és melyiknél utoljára!</li>
            <li>összesen hány alkalommal vásároltak!</li>
        </ol>
    </li>
    <li>Határozza meg, hogy a bekért darabszámot vásárolva egy termékből mennyi a fizetendő összeg! A feladat megoldásához készítsen függvényt ertek néven, amely a darabszámhoz a fizetendő összeget rendeli!</li>
    <li>atározza meg, hogy a bekért sorszámú vásárláskor mely árucikkekből és milyen mennyiségben vásároltak! Az árucikkek nevét tetszőleges sorrendben megjelenítheti.</li>
    <li>Készítse el az <i style="font-weight: normal">osszeg.txt</i> fájlt, amelybe soronként az egy-egy vásárlás alkalmával fizetendő összeg kerüljön a kimeneti mintának megfelelően!</li>
</ol>

<br>
<br>

**Minta a szöveges kimenetek kialakításához:**
```
2. feladat
A fizetések száma: 141

3. feladat
Az első vásárló 1 darab árucikket vásárolt.

4. feladat
Adja meg egy vásárlás sorszámát! 2
Adja meg egy árucikk nevét! kefe
Adja meg a vásárolt darabszámot! 2

5. feladat
Az első vásárlás sorszáma: 5
Az utolsó vásárlás sorszáma: 139
32 vásárlás során vettek belőle.

6. feladat
2 darab vételekor fizetendő: 950

7. feladat
1 toll
1 szatyor
1 doboz
1 csavarkulcs
2 colostok
2 HB ceruza
```

**Részlet az** *osszeg.txt* **fájlból:**
```
1: 500
2: 3900
3: 2300
4: 1000
5: 2500
6: 2900
7: 950
...
```
```
45 pont
```

<br>
<br>

> forrás: **[ötszáz.pdf](/3_erettsegi/1_programozas/P3_otszaz/ötszáz.pdf)**