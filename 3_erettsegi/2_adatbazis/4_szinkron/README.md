# 3. Szinkron

#### 1. Adatimportálás
phpMyAdmin

#### 2. Filmek Heltai Olga magyar szövegével (magyar cim, eredeti cim)
```sql
SELECT cim, eredeti
FROM film
WHERE magyarszoveg = "Heltai Olga";
```
#### 3. 2000 utáni filmek film- és szinkronrendezői
```sql
SELECT DISTINCT rendezo, szinkronrendezo
FROM film
WHERE 2000 < ev;
```
#### 4. Christopher Nolen film Mafilm Audio Kft. szinkronjának szövegírói (magyar cim, iro [abc])
```sql
SELECT cim, magyarszoveg
FROM film
WHERE rendezo = "Christopher Nolan" AND studio = "Mafilm Audio Kft."
ORDER BY magyarszoveg;
```
#### 5. Anger Zsolt szerepei (magyar cim, eredeti cim, szinesz, karakter)
```sql
SELECT cim, eredeti, szinesz, szerep
FROM szinkron, film
WHERE szinkron.filmaz = film.filmaz
    AND hang = "Anger Zsolt";
```
#### 6. Filmenkénti szinkronhangok száma az adatbázisban (eredeti cim, magyar cim, szinkronszerepek szama)
```sql
SELECT eredeti, cim, Count(szinkid)
FROM szinkron, film
WHERE szinkron.filmaz = film.filmaz
GROUP BY eredeti, cim;
```
#### 7. 
```sql
SELECT szerep, szinesz, hang
FROM szinkron
WHERE szerep LIKE "% rab%" OR szerep LIKE "rab%";
```
#### 8. 
```sql
SELECT rendezo AS "Színész-rendező"
FROM film
INTERSECT
SELECT szinesz
FROM szinkron;
```
```sql
SELECT DISTINCT rendezo, szinesz
FROM film, szinkron
WHERE szinesz = rendezo;
```

#### 9.
```sql
SELECT cim, hang
FROM szinkron, film
WHERE szinkron.filmaz = film.filmaz
    AND szinkron.filmaz IN (SELECT filmaz FROM szinkron WHERE hang = "Pap Kati")
    AND hang != "Pap Kati"
ORDER BY cim, hang;
```

#### 10.
```sql
SELECT szinesz, hang, Count(*)
FROM szinkron
GROUP BY szinesz, hang
HAVING 3 <= Count(*)
ORDER BY Count(*) DESC;
```