SELECT nevado, count - COUNT(*)
FROM feladat, megoldas, csapat, feladatsor,
    (SELECT feladatsorid AS fid, COUNT(*) AS count FROM feladat GROUP BY feladatsorid) AS q1
WHERE feladatid = feladat.id AND csapatid = csapat.id AND feladatsorid = feladatsor.id AND feladatsorid = q1.fid
    AND csapat.nev = "#win"
GROUP BY feladatsorid, count, nevado
HAVING COUNT(*) != count
