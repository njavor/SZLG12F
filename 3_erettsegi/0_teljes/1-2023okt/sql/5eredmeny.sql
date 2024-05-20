SELECT nev, SUM(pontszam)
FROM megoldas, csapat
WHERE csapatid = csapat.id
GROUP BY csapatid
ORDER BY SUM(pontszam) DESC