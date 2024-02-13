-- 1,2 Adatimportálás
CREATE TABLE kategoria
(
  kat_kod	INT unsigned PRIMARY KEY AUTO_INCREMENT,
  kat_nev	VARCHAR(50) NOT NULL,
);

CREATE TABLE eladas
(
    aru_kod INT unsigned PRIMARY KEY AUTO_INCREMENT,
    mennyiseg   INT unsigned NOT NULL,
);

CREATE TABLE aru
(
	aru_kod INT unsigned PRIMARY KEY AUTO_INCREMENT,
	kat_kod INT unsigned NOT NULL,
	nev VARCHAR(100) NOT NULL,
	egyseg  VARCHAR(20) NOT NULL,
	ar  INT unsigned NOT NULL,
    FOREIGN KEY (aru_kod) REFERENCES eladas(aru_kod),
    FOREIGN KEY (kat_kod) REFERENCES kategoria (kat_kod)
);

--
-- INSERT INTO -> "_insert-into.sql"
--

-- 3. 1000 Ft-nál drágább áruk (név, ár)
SELECT nev, ar 
FROM aru 
WHERE ar > 1000;


-- 4. Üdítőitalok listája (név, ár, egység, eladott mennyiség)
SELECT nev, ar, egyseg, mennyiseg
FROM aru 
    INNER JOIN kategoria ON aru.kat_kod = kategoria.kat_kod 
    INNER JOIN eladas ON aru.aru_kod = eladas.aru_kod
WHERE kategoria.kat_nev = "Üditőitalok";


-- 5. Liter egységű áruk
SELECT COUNT(*)
FROM aru
WHERE egyseg = "liter"
GROUP BY egyseg;


-- 6. Árunkénti bevétel (név [a-z], bevétel)
SELECT nev, ar*mennyiseg AS bevetel
FROM aru
    INNER JOIN eladas ON aru.aru_kod = eladas.aru_kod
ORDER BY nev;


-- 7. Kategóriánkénti termékfajták száma (kategória név, termékek száma)
SELECT kat_nev, COUNT(*) AS termekszam
FROM aru
    INNER JOIN kategoria ON aru.kat_kod = kategoria.kat_kod
GROUP BY aru.kat_kod;


-- 8. Kategóriánkénti összbevétel (kategória név, bevétel)
SELECT kat_nev, SUM(bevetel) AS osszbevetel
FROM(
    SELECT nev, kat_kod, ar*mennyiseg AS bevetel
    FROM aru
        INNER JOIN eladas ON aru.aru_kod = eladas.aru_kod
) AS aru_bevetel
    INNER JOIN kategoria ON aru_bevetel.kat_kod = kategoria.kat_kod
GROUP BY aru_bevetel.kat_kod;


-- 9. Legdrágább áruk (név, ár)
SELECT nev, ar
FROM aru
WHERE ar = (SELECT MAX(ar) FROM aru)
ORDER BY ar DESC;


-- 10. 1000 Ft-nál drágább terméket tartalmazó árukategóriák
SELECT kat_kod
FROM aru
WHERE ar > 1000
GROUP BY kat_kod;