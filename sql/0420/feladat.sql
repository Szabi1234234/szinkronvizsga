-- 2.
SELECT nev FROM szineszek
WHERE nemzetiseg = "amerikai"
ORDER BY nev ASC;

-- 3. 
SELECT cim, megjelenes_eve, rendezo FROM filmek
WHERE mufaj = "vígjáték"
ORDER BY megjelenes_eve ASC;

-- 4.
SELECT cim, mufaj, megjelenes_eve, jegy_ar FROM filmek
WHERE megjelenes_eve > 2019 AND jegy_ar > 2500
ORDER BY jegy_ar DESC, megjelenes_eve DESC;
LIMIT 5;

-- 5.
SELECT mufaj, COUNT(*) AS film_szam FROM filmek
GROUP BY mufaj
ORDER BY film_szam DESC;

-- 6.
SELECT szi.nev, szi.nemzetiseg, cim, sz.foszerep FROM filmek
JOIN szerepek sz ON filmek.id = sz.filmid
JOIN szineszek szi ON sz.szineszid = szi.id
WHERE rendezo = "Christopher Nolan"
ORDER BY cim ASC, sz.foszerep DESC, szi.nev ASC;

-- 7.
SELECT cim, megjelenes_eve, mufaj, rendezo FROM filmek
WHERE id NOT IN (SELECT filmid FROM szerepek)
ORDER BY megjelenes_eve ASC;

-- 8.
SELECT nev, szuletesi_ev FROM szineszek
WHERE nemzetiseg = "ír" AND nev NOT LIKE "Cillian Murphy";

-- 9. 
UPDATE filmek
SET rendezo = "Denis Villeneuve-Tremblay"
WHERE rendezo = "Denis Villeneuve";

-- 10.
DELETE FROM szerepek
WHERE foszerep = 0;

-- 11.
SELECT nev, nemzetiseg, COUNT(*) AS filmek_szama FROM szineszek
JOIN szerepek ON szineszek.id = szerepek.szineszid
GROUP BY szineszek.id
ORDER BY filmek_szama DESC, nev ASC;