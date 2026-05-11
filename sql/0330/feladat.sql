
-- 1.
SELECT varos, utca, sebesseg_hatar, helyszin_tipus FROM helyszinek
WHERE helyszin_tipus = 'autópálya' AND sebesseg_hatar >= 100 OR helyszin_tipus = 'lakóövezet' AND sebesseg_hatar >= 30
ORDER BY helyszin_tipus, varos ASC; 

-- 2.
SELECT id, mert_sebesseg, meres_datuma, meres_oraja, birsag_osszeg FROM meresek
WHERE mert_sebesseg > 100 AND meres_oraja BETWEEN "22:00:00" AND "06:00:00" OR birsag_osszeg >= 90000
ORDER BY birsag_osszeg, mert_sebesseg DESC;

-- 3.
SELECT vezeteknev, keresztnev, lakcim_varos, pontszam FROM jarmuvezetok
WHERE pontszam > 5 AND lakcim_varos = 'Miskolc' OR pontszam > 5 AND lakcim_varos = 'Budapest' OR pontszam >= 10
ORDER BY pontszam DESC, vezeteknev ASC;

-- 4.
SELECT id, mert_sebesseg, tullepes_km, meres_datuma, birsag_osszeg FROM meresek
WHERE meres_datuma BETWEEN '2024-01-01' AND '2024-06-30' AND kifizetve = 0 AND tullepes_km > 30
ORDER BY meres_datuma, tullepes_km DESC;

-- 5. NOT IN KELL
SELECT rendszam, marka, tipus, gyartas_eve FROM jarmuvek
WHERE marka NOT IN ("Toyota", "BMW") AND gyartas_eve > 2018 AND kategoria = 'személyautó'
ORDER BY gyartas_eve DESC, marka ASC
LIMIT 4;

-- 6.
SELECT m.id, varos, utca, sebesseg_hatar, mert_sebesseg, tullepes_km FROM helyszinek
JOIN meresek m ON m.id = helyszinek.id
WHERE helyszin_tipus = "főút" AND tullepes_km >= 20
ORDER BY tullepes_km DESC, varos ASC;

-- 7. 
SELECT CONCAT(j.vezeteknev, " ", j.keresztnev) AS teljes_nev, mert_sebesseg, meres_datuma, birsag_osszeg, kifizetve FROM meresek
JOIN jarmuvezetok j ON j.id = meresek.vezeto_id
WHERE kifizetve = 0 AND birsag_osszeg >= 50000
ORDER BY birsag_osszeg DESC, meres_datuma ASC;

-- 8.
SELECT j.rendszam, j.marka, j.kategoria, mert_sebesseg, tullepes_km, meres_datuma FROM meresek
JOIN jarmuvek j ON j.id = meresek.jarmu_id
WHERE (j.kategoria = "motorkerékpár" OR j.kategoria = "tehergépjármű") AND mert_sebesseg > 100
ORDER BY meres_datuma, mert_sebesseg DESC;

-- 9.
SELECT CONCAT(j.vezeteknev, " ", j.keresztnev) AS teljes_nev, CONCAT(h.varos, ", ", h.utca) AS helyszin, mert_sebesseg, tullepes_km, meres_oraja, birsag_osszeg FROM meresek
JOIN jarmuvezetok j ON j.id = meresek.vezeto_id
JOIN helyszinek h ON h.id = meresek.helyszin_id
WHERE meres_datuma BETWEEN "2024-07-01" AND "2024-12-31"
ORDER BY varos, teljes_nev, meres_datuma ASC;

-- 10.
SELECT CONCAT(j.vezeteknev, " ", j.keresztnev) AS teljes_nev, h.varos, mert_sebesseg, tullepes_km, meres_oraja, birsag_osszeg FROM meresek
JOIN jarmuvezetok j ON j.id = meresek.vezeto_id
JOIN helyszinek h ON h.id = meresek.helyszin_id
WHERE birsag_osszeg >= 90000 OR tullepes_km >= 40
ORDER BY birsag_osszeg DESC, tullepes_km DESC, meres_oraja; 

-- 11.
SELECT CONCAT(j.vezeteknev, " ", j.keresztnev) AS teljes_nev, h.varos, mert_sebesseg, birsag_osszeg FROM meresek
JOIN jarmuvezetok j ON j.id = meresek.vezeto_id
JOIN helyszinek h ON h.id = meresek.helyszin_id
ORDER BY birsag_osszeg DESC, meresek.id
LIMIT 4 OFFSET 4;

-- 12.
SELECT h.varos, mert_sebesseg, meres_datuma, meres_oraja FROM meresek
JOIN helyszinek h ON h.id = meresek.helyszin_id
WHERE YEAR(meres_datuma) = 2024
ORDER BY meres_datuma, meres_oraja ASC
LIMIT 4 OFFSET 6;

-- 13. 
SELECT CONCAT(j.vezeteknev, " ", j.keresztnev) AS teljes_nev, COUNT(j.id) AS meresek_szama FROM jarmuvezetok j
LEFT JOIN meresek m ON j.id = m.vezeto_id
GROUP BY j.id
ORDER BY meresek_szama DESC, vezeteknev;

-- 14. 
SELECT varos, utca, COUNT(h.id) AS meresek_szama FROM helyszinek h 
LEFT JOIN meresek m ON h.id = m.helyszin_id
GROUP BY h.id, varos, utca
ORDER BY meresek_szama DESC, varos;

-- 15.
SELECT rendszam, marka, kategoria, COUNT(j.id) AS meresek_szama FROM jarmuvek j
LEFT JOIN meresek m ON j.id = m.jarmu_id
GROUP BY j.id, rendszam, marka, kategoria
ORDER BY meresek_szama DESC, marka;

-- 16.
SELECT COUNT(h.id) AS meresek_szama, ROUND(AVG(m.tullepes_km), 1) AS atlag_tullepes, MAX(m.mert_sebesseg) AS max_sebesseg, SUM(m.birsag_osszeg) AS osszes_birsag, varos, utca FROM helyszinek h
JOIN meresek m ON h.id = m.helyszin_id
GROUP BY h.id
HAVING meresek_szama > 3
ORDER BY meresek_szama DESC, varos; 

-- 17.
SELECT COUNT(kifizetve = FALSE) AS kifizetetlen_meresek, SUM(birsag_osszeg) AS kifizetetlen_osszeg, CONCAT(vezeteknev, " ", keresztnev) AS teljes_nev FROM jarmuvezetok j 
JOIN meresek m ON j.id = m.vezeto_id
GROUP BY j.id
ORDER BY kifizetetlen_osszeg DESC, teljes_nev;

-- 18.
SELECT kategoria, COUNT(j.id) AS meresek_szama, ROUND(AVG(m.mert_sebesseg), 1) AS atlag_sebesseg, SUM(m.birsag_osszeg) AS osszes_birsag FROM jarmuvek j
JOIN meresek m ON j.id = m.jarmu_id
GROUP BY kategoria
ORDER BY osszes_birsag DESC, kategoria;

-- 19.
SELECT MONTH(meres_datuma) AS honap, ROUND(AVG(tullepes_km), 1) AS atlag_tullepes, MAX(mert_sebesseg) as max_sebesseg FROM meresek
GROUP BY honap
ORDER BY honap ASC;

-- 20.
SELECT rendszam, marka, COUNT(j.id) AS meresek_szama FROM jarmuvek j
JOIN meresek m ON j.id = m.jarmu_id
GROUP BY j.id
ORDER BY meresek_szama DESC, rendszam
LIMIT 2 OFFSET 3;

-- 21.
SELECT varos, mert_sebesseg, meres_datuma