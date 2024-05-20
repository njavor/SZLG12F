SELECT nevado, ag, SUM(pontszam)
FROM feladat, feladatsor
WHERE feladatsorid = feladatsor.id
GROUP BY feladatsorid, nevado, ag 
HAVING SUM(pontszam) != 150