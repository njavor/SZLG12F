# 3. Űrhajózás

#### 1. Adatimportálás
phpMyAdmin

#### 2. "#" karakterrel kezdődő csapatok neve (nev)
```sql
SELECT nev 
FROM csapat 
WHERE nev LIKE "#%";
```


#### 3. Feladatsorok egy szóközös névadókkal (nevado)
```sql
SELECT nevado
FROM feladatsor
WHERE nevado LIKE "% %" AND nevado NOT LIKE "% % %";
```


#### 4. 2018. szilveszteri feladatsorok névadói (nevado)
```sql
SELECT *
FROM feladatsor
WHERE YEAR(kituzes) < YEAR(hatarido);
```

#### 5. Csapatok összpontszáma (csapatnev, osszpontszam)
```sql
SELECT csapat.nev, SUM(megoldas.pontszam) as osszpontszam
FROM megoldas, csapat
WHERE megoldas.csapatid = csapat.id
GROUP BY csapat.nev
ORDER BY SUM(megoldas.pontszam) DESC;
```

#### 6. Nem 150 pontos feladatsorok (nevado, muveszeti ag, pontszam)
```sql
SELECT nevado, ag, SUM(pontszam)
FROM feladat, feladatsor
WHERE feladat.feladatsorid = feladatsor.id
GROUP BY nevado, ag
HAVING SUM(pontszam) != 150;
```

#### 7. Maximális pontszámot elérő csapatok (csapatnev)
```sql
SELECT DISTINCT csapat.nev
FROM megoldas, feladat, csapat
WHERE megoldas.feladatid = feladat.id AND megoldas.csapatid = csapat.id
    AND megoldas.pontszam = feladat.pontszam;
```

#### 8. "#win" csapat be nem adott feladatainak száma feladatsoronként (feladatsor nevadoja, feladatszam)
```sql
SELECT nevado, Count(*)
FROM feladat, feladatsor
WHERE feladat.feladatsorid = feladatsor.id
    AND feladat.id NOT IN (SELECT megoldas.feladatid FROM megoldas, csapat WHERE megoldas.csapatid = csapat.id AND csapat.nev = "#win")
GROUP BY nevado
```