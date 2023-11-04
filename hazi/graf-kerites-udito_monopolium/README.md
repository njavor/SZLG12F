# Üdítő monopólium

## Feladat
> Bergengóciában mindenki két népszerű üdítőital (a Calo és a Pipse) valamelyikét szereti, a másikból egy kortyot sem hajlandó inni. Nem tudják, hogy a két italt ugyanaz a vállalat gyártja, igazából csak a címkéjükben különböznek. A vállalat igazgatója elhatározta, hogy hatékonysági okból megszünteti az egyik üdítő gyártását (az mindegy, hogy melyiket), de nem szeretne elveszíteni egy vásárlót sem. El kell érnie, hogy mindenki ugyanazt az üdítőt szeresse.
>
> Piackutatások kimutatták, hogy a bergengócok ital preferenciáját nagyban befolyásolja a barátaiké. Ha egy bergengóc átvált a másik italra, akkor az összes olyan barátja is, aki azt az italt szerette, amit ő. Persze a továbbiakban csak az új üdítőfajtát fogják szeretni, a régit nem. Az is ismert, hogy a bergengócok nagyon barátságosak: nincs köztük izolált baráti csoport, közvetve mindenki mindenkinek a barátja.
>
>Az igazgató egy valamely márkát reklámozó üdítős ajándékcsomag elküldésével bármelyik (éppen 
a másik italt kedvelő) bergengócot meg tudja győzni, hogy váltson arra a márkára. Vigyáznia kell, nehogy lelepleződjön a terve, ezért hetente csak egy ajándékcsomagot küld, és nem küld kétszer egymás után azonos márkájú csomagot. Tőled annyit szeretne tudni, hogy minimálisan hány hét alatt sikerülhet elérnie, hogy minden bergengóc ugyanazt az üdítőmárkát szeresse.

### Bemenet
> A  ***standard bemenet***  első sorában a  tesztesetek  (**1≤T≤20**) száma van, melyet T  teszteset leírása követ. Minden teszt első sora tartalmazza a bergengócok (**1≤N≤100**), és a (kölcsönös) baráti kapcsolatok (**N-1≤M≤N*(N-1)/2**) számát. A következő sorban **N** darab  (**b<sub>i</sub>∈{0,1}**) szám jelzi, hogy az **i.** bergengóc kezdetben melyik üdítőt szereti. Az ezt követő M  sorban  egy-egy (**1≤u<sub>i</sub>≠v<sub>i</sub>≤N**) számpár adja meg a baráti kapcsolatokat.

### Kimenet
> A ***standard kimenet*** **i.** sorába az **i.** terv megvalósításához szükséges hetek minimális száma 
kerüljön!

### Példa

#### Bemenet:
```
2
4 3
0 1 0 0
1 2
2 3
2 4
5 4
0 1 1 0 1
1 2
2 3
3 4
4 5
```

#### Kimenet:
```
1
2
```

### Korlátok

| Időlimit: | **0.1 mp** |
| - | - |
| **Memórialimit:** | **32 MB** |

### Pontozás
- A pontok 10%-a szerezhető olyan tesztekre, ahol N≤10
- A pontok további 20%-a szerezhető olyan tesztekre, ahol M=N−1


## Tervezés
A feladat rövid lényege, hogy egy-egy tesztesetnél elérjük, hogy a lehető legkevesebb csúcs (italpreferenciájának) megváltosztatásával minden csúcs értéke egyenlő legyen (**0 V 1**).

### Alapgondolat
1. Elmentjük, hogy melyik italt szeretik kevesebben (ennek ellentétét küldjük majd az első csomagunkban)
2. Elküldjük az első csomagot, ami megváltoztatja x bergengóc preferenciáját (EZ a DFS)
    1. Növeljük a minimum szükséges hetek számát
3. Megvizsgáljuk, hogy minden bergengóc ugyanazt az italt szereti-e
    1. **HA IGEN**: visszaadjuk a minimum szükséges hetek számát
    2. **HA NEM**: visszatérünk a ```2.``` ponthoz

- **BERGENGÓC**
    - ```italpreferencia``` : melyik italt szereti (Calo v. Pipse)
    - ```List<int> baratlista``` : az adott bergengóc összes barátja (kölcsönös kapcsolat)
- **TESZTESET**
    - **```minHet```** : az italpreferenciák egységesítéséhez szükséges hetek minimális száma
    - ```bergengoclista``` : az adott tesztesetben található bergengócok listája (a beolvasott gráf)


### In programming terms
```cs
class Bergengoc{
    bool italpreferencia; //Calo v. Pipse
    List<int> baratlista;
}

class Teszteset{
    int minHet;
    List<Bergengoc> bergengoclista = new List<Bergengoc>;


    public bool Siker(){
        bool res = true

        bool elsopref = bergengoclista[0].italpreferencia;
        foreach(var bergengoc in bergengoclista)
            if(bergengoc.italpreferencia != elsopref)
                res = false;
    }
    public void Csomagkuldes(int hova){ //BFS
        
    }
    public int Ajandekkampany(){
        minhet = 0;

        while(!Siker()){
            Csomagkuldes(Kevesebb(bergengoclista)[0])
            minhet++;
        }
    }
}
```


## Megoldás
```cs
```