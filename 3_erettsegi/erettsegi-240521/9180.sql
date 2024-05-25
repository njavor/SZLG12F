SELECT kozterulet, hazszam, SUM(IF(funkcio = "terasz", hossz*szel/2, hossz*szel))
FROM helyiseg, ingatlan
WHERE ingatlanid = ingatlan.id
GROUP BY ingatlanid
HAVING 180 < SUM(IF(funkcio = "terasz", hossz*szel/2, hossz*szel));