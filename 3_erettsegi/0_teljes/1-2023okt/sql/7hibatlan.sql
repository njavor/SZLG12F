SELECT DISTINCT(nev)
FROM feladat, megoldas, csapat
WHERE feladatid = feladat.id AND csapatid = csapat.id
    AND megoldas.pontszam = feladat.pontszam