-- 2.
SELECT muvesznev FROM eloadok
WHERE stilus != "pop"
ORDER BY muvesznev ASC;

-- 3.
SELECT cim, kiadas_eve, kiadonev, ar FROM albumok
WHERE kiadas_eve > 2010 AND ar > 5000
ORDER BY kiadas_eve ASC, ar DESC;

-- 4.
SELECT muvesznev, igazi_nev, szuletesi_ev, stilus FROM eloadok
WHERE stilus = "rock" OR stilus = "metal" AND szuletesi_ev < 1980
ORDER BY szuletesi_ev ASC
LIMIT 5;

-- 5. 
SELECT muvesznev, COUNT(*) AS albumok_szama FROM eloadok
JOIN albumok ON eloadok.id = albumok.eloadoid
GROUP BY eloadok.id
ORDER BY albumok_szama DESC
LIMIT 5;

-- 6. 
SELECT muvesznev, stilus, szuletesi_ev FROM eloadok
WHERE id NOT IN (SELECT eloadoid FROM albumok)
ORDER BY muvesznev ASC;

-- 7.
SELECT muvesznev, igazi_nev, szuletesi_ev FROM eloadok
WHERE stilus = "rock" AND igazi_nev NOT LIKE "Queen"; 

-- 8.
UPDATE albumok
SET kiadonev = "Warner Music Group"
WHERE kiadonev = "Warner Bros. Records";

-- 9. 
DELETE FROM dalok
WHERE hossz_mp < 80;

-- 10.
SELECT albumok.cim, albumok.kiadas_eve, sorszam, dalok.cim FROM dalok
JOIN albumok ON dalok.albumid = albumok.id
JOIN eloadok ON albumok.eloadoid = eloadok.id
WHERE eloadok.muvesznev = "Daft Punk"
ORDER BY albumok.kiadas_eve ASC, sorszam ASC;

-- 11.
SELECT muvesznev, albumok.cim AS album_cim, albumok.kiadas_eve, COUNT(*) as dalok_szama, AVG(hossz_mp) AS atlag_hossz_mp FROM dalok
JOIN albumok ON dalok.albumid = albumok.id
JOIN eloadok ON albumok.eloadoid = eloadok.id
GROUP BY albumok.id
HAVING COUNT(*) > 5
ORDER BY dalok_szama DESC;