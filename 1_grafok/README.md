# Gráfok

## Gráfreprezentációk
### Éllista
### Szomszédsági mátrix
### Szomszédsági lista



<br><br>
## Bejárások
Egy-egy bejárásnál azt vizsgáljuk, hogy a gráfunkban egy megadott csúcstól képesek vagyunk-e eljutni egy másik megadott csúcsba. Ezt két féle képpen vizsgálhatjuk, ***szélességi bejárással** (Breadth-first search - BFS)* vagy ***mélységi bejárással** (Depth-first search - DFS)*.
<br><br>

A ***szélességi bejárás*** olyan, mint a pénztárnál álló sor.

Tegyük fel, hogy amikor egy vevő fizet, akkor behív még *x* vásárlót *('x' lehet 0 db)*, hogy álljon sorba. Ebben a helyzetben az újonnan beérkező vásárlók a sor végére állnak be. Hozzájuk azután jutunk el, hogy a már sorban álló vevőket lefizettetük. Magyarán mindig

**a *legrégebbi teendőmet* vizsgálom meg először, a vizsgálatnál talált új elemek a *teendőim listájának végére* kerülnek.**
<br><br><br>


A ***mélységi bejárás*** ezzel szemben olyan, mintha egy labirintusból szeretnénk kijutni.

Indulás után, mikor egy elágazáshoz érünk, akkor az egyik úton továbbhaladunk. Ezt addig ismételgetjük, amíg zsákutcába nem érünk. Amikor ez megtörténik, akkor visszamegyünk a legutolsó elágazásig, ahol pedig a másik úton haladunk tovább. Ezt, a "végigmegyünk a zsákutcáig, vissza az utolsó elágazásig" folyamatot ismételgetjük, amíg ki nem jutunk a labirintusból. Magyarán mindig

**a *legfrissebb teendőmet* vizsgálom meg először, a vizsgálatnál talált új elemek a *teendőim listájának elejére* kerülnek.**



<br><br>
### Példa

Vegyük az alábbi irányított gráfot példaként:
![](_assets/graf-bejarasok.png)

**Feladat: eljutni a ```0```-ás csúcsból a ```7```-es csúcsba**

<details>
<summary><b>Levezetés:</b></summary>
<br>

| # | Szélességi bejárás (BFS) | teendők<br>listája | Mélységi bejárás (DFS) | teendők<br>listája |
| :---: | :---: | :---: | :---: | :---: |
| **0.**| ![](_assets/graf-bejarasok-1.png) | 0 | ![](_assets/graf-bejarasok-1.png) | 0 |
| **1.**| ![](_assets/graf-bejarasok-2.png) | 1<br>2<br>3<br>5<br>6 | ![](_assets/graf-bejarasok-2.png) | 1<br>2<br>3<br>5<br>6 |
| **2.**| ![](_assets/graf-bejarasok-3.png) | 2<br>3<br>5<br>6 | ![](_assets/graf-bejarasok-3.png) | 2<br>3<br>5<br>6 |
| **3.**| ![](_assets/graf-bejarasok-4.png) | 3<br>5<br>6<br>4 | ![](_assets/graf-bejarasok-4.png) | 4<br>3<br>5<br>6 |
| **4.**| ![](_assets/graf-bejarasok-5sz.png) | 5<br>6<br>4<br>7 | ![](_assets/graf-bejarasok-5m.png) | 7<br>3<br>5<br>6 |
| **5.**| ![](_assets/graf-bejarasok-6sz.png) | 6<br>4<br>7 | ![](_assets/graf-bejarasok-6m.png) | **M<br>E<br>G<br>V<br>A<br>N** |
| **6.**| ![](_assets/graf-bejarasok-7sz.png) | 4<br>7 |  | |
| **7.**| ![](_assets/graf-bejarasok-8sz.png) | 7 |  | |
| **8.**| ![](_assets/graf-bejarasok-9sz.png) | **M<br>E<br>G<br>V<br>A<br>N** |  | |
</details>

Ebben a példában a mélységi bejárás bizonyult gyorsabbnak, ám ha mondjuk a 7-es csúcs helyett pl. a 3-as csúcs elérhetőségét vizsgáltuk volna, akkor a szélességi bejárás lett volna gyorsabb. *(Az 1-es csúcsból az 5-ös csúcsba eljutni pedig nem lehetséges.)* Felmerül ekkor a kérdés:

<br><br>
### Mikor melyiket használjuk?

Néha a szélességi jobb, néha pedig a mélységi.

**Hogy melyik a jobb az adott helyzetben, azt pontosan nem tudhatjuk** (hiszen akkor tudnánk a megoldást, nem lenne szükség bejárni a gráfot), ám ha ismerjük az adatszerkezetünk körülbelüli felépítését, akkor ki tudjuk választani, hogy *valószínűleg* melyik lesz gyorsabb.

**Szélességi bejárás:** ha a keresett érték közel van a kiindulóponthoz

**Mélységi bejárás:** ha a keresett érték aránylag messzebb van a kiindulóponttól


<br><br>
### Pszeudokód

Programozás során ez egy különbséget jelent: a tennivalókat **Sorban** (**```Queue```**) vagy **Veremben** (**```Stack```**) tároljuk-e. Az előbbit a szélességi bejárásnál, míg az utóbbit a mélységinél használjuk.

<details>
<summary><b>Szélességi bejárás - BFS</b></summary>

```
Függvény El_lehet_e_jutni_szelessegivel(graf: Graf, innen: Egész, ide: Egész): Logikai
    Lokális:
        fehér: Egész
        szürke: Egész
        fekete: Egész
        tennivalók: Sor
        szín: Tömb[Egész]
        tennivaló: Egész

    fehér := 0
    szürke := 1
    fekete := 2

    szín := új Tömb[Egész](graf.Csúcsszama)

    tennivalók := új Sor
    tennivalók.Beletesz(innen)
    szín[innen] := szürke

    El_lehet_e_jutni := Hamis

    Ciklus amíg nem El_lehet_e_jutni és nem tennivalók.Üres():
        tennivaló := tennivalók.Kivesz()

        Ha feldolgozando = ide:
            El_lehet_e_jutni := Igaz
        Különben:
            szín[feldolgozando] := fekete

            Iteráció szomszéd eleme graf.szomszédai[tennivaló]:
                Ha szín[szomszéd] = fehér:
                    tennivalók.Beletesz(szomszéd)
                    szín[szomszéd] := szürke
                Elágazás vége
            Iteráció vége
        Elágazás vége
    Ciklus vége
Függvény vége
```
</details>

[C#](_assets/bfs.cs)


<details>
<summary><b>Mélységi bejárás - DFS</b></summary>

```
Függvény El_lehet_e_jutni_melysegivel(graf: Graf, innen: Egész, ide: Egész): Logikai
    Lokális:
        fehér: Egész
        szürke: Egész
        fekete: Egész
        tennivalók: Verem
        szín: Tömb[Egész]
        tennivaló: Egész

    fehér := 0
    szürke := 1
    fekete := 2

    szín := új Tömb[Egész](graf.Csúcsszama)

    tennivalók := új Verem
    tennivalók.Beletesz(innen)
    szín[innen] := szürke

    El_lehet_e_jutni := Hamis

    Ciklus amíg nem El_lehet_e_jutni és nem tennivalók.Üres():
        tennivaló := tennivalók.Kivesz()

        Ha feldolgozando = ide:
            El_lehet_e_jutni := Igaz
        Különben:
            szín[feldolgozando] := fekete

            Iteráció szomszéd eleme graf.szomszédai[tennivaló]:
                Ha szín[szomszéd] = fehér:
                    tennivalók.Beletesz(szomszéd)
                    szín[szomszéd] := szürke
                Elágazás vége
            Iteráció vége
        Elágazás vége
    Ciklus vége
Függvény vége
```
</details>

[C#](_assets/dfs.cs)


## Legrövidebb út
