SELECT hazszam, ar
FROM hirdetes, ingatlan
WHERE ingatlanid = ingatlan.id
    AND kozterulet = "Agyagos utca" 
    AND allapot = "meghirdetve";