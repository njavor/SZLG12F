# 3. forgalom

#### 1,2 Adatimportálás
**KATEGÓRIA**
```sql
CREATE TABLE KATEGORIA
(
  kat_kod	INT unsigned PRIMARY KEY AUTO_INCREMENT,
  kat_nev	VARCHAR(50) NOT NULL,
);
```

<details>
<summary><i>importálás</i></summary>

```sql
INSERT INTO kategoria (kat_kod, kat_nev) VALUES
    ('4', 'Édesség'),
    ('1', 'Húsáru'),
    ('3', 'Tejtermék'),
    ('5', 'Tészták'),
    ('6', 'Üditőitalok'),
    ('2', 'Zöldség');
```

</details>

##### ELADÁS
```sql
CREATE TABLE ELADAS
(
    aru_kod INT unsigned PRIMARY KEY AUTO_INCREMENT,
    mennyiseg   INT unsigned NOT NULL,
);
```

<details>
<summary><i>importálás</i></summary>

```sql
INSERT INTO eladas (aru_kod, mennyiseg) VALUES
    ('6', '1'),
    ('13', '2'),
    ('16', '3'),
    ('25', '8'),
    ('26', '8'),
    ('37', '8'),
    ('46', '10'),
    ('19', '10'),
    ('35', '12'),
    ('38', '12'),
    ('22', '13'),
    ('23', '14'),
    ('5', '16'),
    ('27', '16'),
    ('10', '19'),
    ('33', '20'),
    ('30', '22'),
    ('41', '24'),
    ('29', '25'),
    ('24', '26'),
    ('40', '26'),
    ('17', '27'),
    ('21', '28'),
    ('8', '29'),
    ('28', '29'),
    ('42', '29'),
    ('2', '31'),
    ('9', '33'),
    ('31', '33'),
    ('18', '35'),
    ('36', '35'),
    ('7', '36'),
    ('11', '39'),
    ('44', '41'),
    ('45', '41'),
    ('4', '42'),
    ('12', '42'),
    ('39', '43'),
    ('15', '45'),
    ('14', '46'),
    ('34', '46'),
    ('43', '47'),
    ('1', '48'),
    ('3', '48'),
    ('32', '49'),
    ('20', '50');
```

</details>

```sql
CREATE TABLE ARU(
	aru_kod INT unsigned PRIMARY KEY AUTO_INCREMENT,
	kat_kod INT unsigned NOT NULL,
	nev VARCHAR(100) NOT NULL,
	egyseg  VARCHAR(20) NOT NULL,
	ar  INT unsigned NOT NULL,
    FOREIGN KEY (aru_kod) REFERENCES eladas(aru_kod),
    FOREIGN KEY (kat_kod) REFERENCES kategoria (kat_kod)
);
```

<details>
<summary><i>importálás</i></summary>

```sql
    INSERT INTO aru (aru_kod, kat_kod, nev, egyseg, ar) VALUES
        ('31', '6', 'Almalé', 'liter', '269'),
        ('30', '6', 'Ásványvíz', 'liter', '119'),
        ('10', '1', 'Bánáti kolbász', 'kg', '549'),
        ('13', '1', 'Baromfi párizsi', 'kg', '209'),
        ('36', '4', 'Boci csoki', 'darab', '142'),
        ('2', '3', 'Camembert', 'doboz', '239'),
        ('44', '5', 'Cérnametélt', 'kg', '332'),
        ('43', '5', 'Csigatészta', 'kg', '320'),
        ('42', '5', 'Durillo tészta', 'kg', '238'),
        ('8', '3', 'Eidami sajt', 'doboz', '1222'),
        ('15', '1', 'Erdélyi szalonna', 'kg', '599'),
        ('16', '1', 'Farmer felvágott', 'kg', '579'),
        ('41', '5', 'Füri tészta', 'kg', '179'),
        ('12', '1', 'Füstölt-főtt pulyka alsócomb', 'kg', '629'),
        ('11', '1', 'Füstölt-főtt pulykamell sonka', 'kg', '1199'),
        ('35', '4', 'Gabonapehely szelet', 'darab', '52'),
        ('29', '6', 'Ice Tea', 'doboz', '229'),
        ('46', '1', 'Paprikás szalámi', 'kg', '2899'),
        ('33', '6', 'Kajszilé', 'liter', '269'),
        ('25', '2', 'Karfiol', 'kg', '168'),
        ('37', '4', 'Konyakos meggy', 'darab', '712'),
        ('40', '5', 'Korona tészta', 'kg', '290'),
        ('39', '5', 'La Pasta 4 tojásos tészta', 'kg', '230'),
        ('19', '1', 'Marha darálthús', 'kg', '899'),
        ('23', '1', 'Marha párizsi', 'kg', '899'),
        ('7', '3', 'Medve sajt', 'doboz', '209'),
        ('32', '6', 'Őszilé', 'liter', '269'),
        ('28', '2', 'Paradicsom', 'kg', '239'),
        ('34', '4', 'Piros mogyorós', 'darab', '155'),
        ('4', '3', 'Pötyös Túró Rudi', 'darab', '42'),
        ('21', '1', 'Sertés darálthús', 'kg', '539'),
        ('18', '1', 'Sertés hátsó csülök', 'kg', '559'),
        ('20', '1', 'Sertéslapocka', 'kg', '739'),
        ('22', '1', 'Sertéstarja csont nélkül', 'kg', '1099'),
        ('17', '1', 'Sertéscomb csont nélkül', 'kg', '829'),
        ('5', '3', 'Sovány tej', 'liter', '145'),
        ('38', '4', 'Sportszelet', 'darab', '82'),
        ('24', '2', 'Sütőtök', 'kg', '49'),
        ('45', '5', 'Szélesmetélt', 'kg', '230'),
        ('14', '1', 'Szeletelt bacon', 'kg', '1490'),
        ('1', '3', 'Tejföl 20%-os', 'doboz', '175'),
        ('3', '3', 'Tejszínhab-spray', 'liter', '676'),
        ('27', '2', 'Téli alma', 'kg', '199'),
        ('9', '1', 'Téliszalámi', 'kg', '2899'),
        ('26', '2', 'Zöldborsó', 'doboz', '489'),
        ('6',	'3', 'Zsíros tej', 'liter', '169');
```

</details>

#### 3. 1000 Ft-nál drágább áruk (név, ár)
```sql
SELECT nev, ar 
FROM aru 
WHERE ar > 1000;
```

#### 4. Üdítőitalok listája (név, ár, egység, eladott mennyiség)
```sql
SELECT nev, ar, egyseg, mennyiseg
FROM aru 
    INNER JOIN kategoria ON aru.kat_kod = kategoria.kat_kod 
    INNER JOIN eladas ON aru.aru_kod = eladas.aru_kod
WHERE kategoria.kat_nev = "Üditőitalok";
```

#### 5. Liter egységű áruk
```sql
SELECT COUNT(*)
FROM aru
WHERE egyseg = "liter"
GROUP BY egyseg;
```

#### 6. Árunkénti bevétel (név [a-z], bevétel)
```sql
SELECT nev, ar*mennyiseg AS bevetel
FROM aru
    INNER JOIN eladas ON aru.aru_kod = eladas.aru_kod
ORDER BY nev;
```

#### 7. Kategóriánkénti termékfajták száma (kategória név, termékek száma)
```sql
SELECT kat_nev, COUNT(*) AS termekszam
FROM aru
    INNER JOIN kategoria ON aru.kat_kod = kategoria.kat_kod
GROUP BY aru.kat_kod;
```

#### 8. Kategóriánkénti összbevétel (kategória név, bevétel)
```sql
SELECT kat_nev, SUM(bevetel) AS osszbevetel
FROM(
    SELECT nev, kat_kod, ar*mennyiseg AS bevetel
    FROM aru
        INNER JOIN eladas ON aru.aru_kod = eladas.aru_kod
) AS aru_bevetel
    INNER JOIN kategoria ON aru_bevetel.kat_kod = kategoria.kat_kod
GROUP BY aru_bevetel.kat_kod;
```

#### 9. Legdrágább áruk (név, ár)
```sql
SELECT nev, ar
FROM aru
WHERE ar = (SELECT MAX(ar) FROM aru)
ORDER BY ar DESC;
```

#### 10. 1000 Ft-nál drágább terméket tartalmazó árukategóriák
```sql
SELECT kat_kod
FROM aru
WHERE ar > 1000
GROUP BY kat_kod;
```