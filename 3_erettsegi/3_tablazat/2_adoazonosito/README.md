# Adóazonosító jel
**[feladatleírás](/3_erettsegi/3_excel/2_adoazonosito/adóazonosító%20jel%20-%20a%20feladat%20leírása.pdf)**


## Megoldás

#### 4. Adóazonosítójel másolás
tartomány: ```Feldolgozás!B2:K24```
```excel
=KÖZÉP(Adatlap!$J4;B$1;1)
```

#### 5. Szorzatösszeg
tartomány: ```Feldolgozás!L2:L24```
```excel
=$B$1*$B2+$C$1*$C2+$D$1*$D2+$E$1*$E2+$F$1*$F2+$G$1*$G2+$H$1*$H2+$I$1*$I2+$J$1*$J2
```

#### 6. Adóazonosító érvényesség vizsgálat
tartomány: ```Adatlap!K3:K25```
```excel
=HA(SZÁMÉRTÉK(KÖZÉP(J3;10;1))=MARADÉK(Feldolgozás!L2;11);IGAZ)
```

#### 7. Feltételes formázás
tartomány: ```Adatlap!I3:K25```
```excel
=$K3=HAMIS
```

#### 8. Születési dátum előállítás
tartomány: ```Adatlap!L2:L25```
```excel
=HA(K3;SZÁMÉRTÉK(KÖZÉP(J3;2;5))-12051;"")
```

#### 9. Azonosító személyhez rendelése
tartomány: ```Adatlap!F3:F22```
```excel
=INDEX($J$3:$J$25;HOL.VAN(DÁTUM(C3;D3;E3);$L$3:$L$25;0))
```
