SELECT kozterulet, hazszam, datum
FROM hirdetes, ingatlan
WHERE ingatlanid = ingatlan.id
    AND hirdetes.ingatlanid NOT IN (SELECT ingatlanid FROM hirdetes WHERE allapot != "meghirdetve")
ORDER BY datum
LIMIT 1;