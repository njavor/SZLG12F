SELECT kozterulet, hazszam, hirdetes.ar
FROM hirdetes, hirdetes AS seged1, ingatlan
WHERE hirdetes.ingatlanid = ingatlan.id
    AND hirdetes.ingatlanid = seged.ingatlanid 
    AND hirdetes.ar = seged1.ar 
    AND hirdetes.allapot = "meghirdetve" 
    AND seged1.allapot = "eladva";