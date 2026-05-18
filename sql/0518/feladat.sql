-- 1.
SELECT cim, szerzo, kiadas_ev FROM konyvek
WHERE kategoria = "krimi"
ORDER BY kiadas_ev ASC;

-- 2.
SELECT nev, kor, foglalkozas FROM olvasok
WHERE varos = "Budapest"
ORDER BY kor DESC;

-- 3.
SELECT cim, szerzo, oldalszam FROM konyvek
WHERE oldalszam > (SELECT AVG(oldalszam) FROM konyvek)
ORDER BY oldalszam DESC;

-- 4.
SELECT cim, szerzo, kategoria, kiadas_ev FROM konyvek
WHERE kiadas_ev > 1950 AND kiadas_ev < 2010
ORDER BY kiadas_ev ASC, cim ASC;

-- 5.
SELECT nev, varos, foglalkozas, kor FROM olvasok
WHERE (foglalkozas = "tanár" AND kor > 40) OR (foglalkozas = "diák" AND kor < 22)
ORDER BY kor ASC;

-- 6.
SELECT cim, szerzo, kategoria, ar FROM konyvek
WHERE kategoria NOT IN ("gyermek") AND ar < (SELECT AVG(ar) FROM konyvek)
ORDER BY ar DESC;

-- 7. 
SELECT cim, szerzo FROM konyvek
WHERE szerzo LIKE "M%"
ORDER BY szerzo ASC, cim ASC;

-- 8.
SELECT cim, szerzo, ar FROM konyvek
ORDER BY ar DESC
LIMIT 5;

-- 9.
SELECT cim, szerzo, oldalszam FROM konyvek
ORDER BY oldalszam ASC
LIMIT 5 OFFSET 3;

-- 10.
SELECT id, konyvid, olvasoid, kezdes_datum, hatarido_datum, allapot FROM kolcsonzesek
WHERE (allapot = "aktív" OR allapot = "késik") AND hatarido_datum < '2026-05-15'
ORDER BY hatarido_datum ASC;

-- 11.
SELECT kategoria, COUNT(*) AS konyvek_szama FROM konyvek
GROUP BY kategoria
ORDER BY konyvek_szama DESC, kategoria ASC;

-- 12.
SELECT varos, COUNT(*) AS olvasok_szama FROM olvasok
GROUP BY varos
ORDER BY olvasok_szama DESC;

-- 13.
SELECT kategoria, AVG(ar) AS atlag_ar FROM konyvek
GROUP BY kategoria
ORDER BY atlag_ar DESC;

-- 14.
SELECT szerzo, COUNT(*) AS konyvek_szama, AVG(ar) AS atlag_ar FROM konyvek
GROUP BY szerzo
ORDER BY konyvek_szama DESC, szerzo ASC;

-- 15.
SELECT varos, COUNT(*) AS olvasok_szama, AVG(kor) AS atlag_kor FROM olvasok
GROUP BY varos
HAVING AVG(kor) > 30
ORDER BY olvasok_szama DESC, varos ASC;

-- 16.
SELECT kiadas_ev, COUNT(*) AS konyvek_szama, MAX(oldalszam) AS max_oldalszam FROM konyvek
GROUP BY kiadas_ev
HAVING COUNT(*) >= 2 AND MAX(oldalszam) > 400
ORDER BY kiadas_ev ASC;

-- 17.
SELECT cim, szerzo, nev, kezdes_datum, allapot FROM konyvek
JOIN kolcsonzesek ON konyvek.id = kolcsonzesek.konyvid
JOIN olvasok ON kolcsonzesek.olvasoid = olvasok.id
WHERE kezdes_datum BETWEEN '2026-04-30' AND '2026-05-11'
ORDER BY kezdes_datum ASC, cim ASC;

-- 18.
SELECT cim, szerzo, kezdes_datum, allapot FROM konyvek
JOIN kolcsonzesek ON konyvek.id = kolcsonzesek.konyvid
JOIN olvasok ON kolcsonzesek.olvasoid = olvasok.id
WHERE nev = "Kovács Anna"
ORDER BY kezdes_datum ASC;

-- 19.
SELECT kategoria, COUNT(*) AS kolcsonzesek_szama FROM konyvek
JOIN kolcsonzesek ON konyvek.id = kolcsonzesek.konyvid
GROUP BY kategoria
ORDER BY kolcsonzesek_szama DESC 
LIMIT 3;

-- 20.
SELECT nev, varos, foglalkozas FROM olvasok
WHERE NOT EXISTS (
    SELECT 1
    FROM kolcsonzesek
    WHERE kolcsonzesek.olvasoid = olvasok.id
)
ORDER BY varos ASC, nev ASC;

-- 21.
SELECT cim, szerzo, kategoria FROM konyvek
WHERE NOT EXISTS (
    SELECT 1
    FROM kolcsonzesek
    WHERE kolcsonzesek.konyvid = konyvek.id
)
ORDER BY kategoria ASC, cim ASC;

-- 22.
UPDATE konyvek
SET kategoria = "tudomány"
WHERE kategoria = "ismeretterjesztő";

-- 23.
UPDATE konyvek
SET ar = ROUND(ar * 1.10)
WHERE kiadas_ev > 1970;

-- 24.
DELETE FROM kolcsonzesek
WHERE allapot = "visszahozva" AND kezdes_datum < '2025-06-01';