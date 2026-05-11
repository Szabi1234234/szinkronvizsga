-- ============================================================
-- Zenei adatbázis
-- Ezt a fájlt importáld MySQL Workbench-ben vagy parancssorból!
-- ============================================================

DROP DATABASE IF EXISTS musicstore;
CREATE DATABASE musicstore
  CHARACTER SET utf8mb4
  COLLATE utf8mb4_hungarian_ci;
USE musicstore;

-- ============================================================
-- TÁBLÁK LÉTREHOZÁSA
-- ============================================================

CREATE TABLE genres (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(50) NOT NULL COMMENT 'Műfaj neve'
) COMMENT = 'Zenei műfajok';

CREATE TABLE labels (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(100) NOT NULL COMMENT 'Kiadó neve',
  city VARCHAR(80) COMMENT 'Székhely város',
  founded_year INT COMMENT 'Alapítás éve',
  website VARCHAR(150) COMMENT 'Weboldal cím'
) COMMENT = 'Lemezkiadók';

CREATE TABLE artists (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  first_name VARCHAR(60) NOT NULL COMMENT 'Keresztnév',
  last_name VARCHAR(60) NOT NULL COMMENT 'Vezetéknév',
  birth_year INT COMMENT 'Születési év',
  death_year INT COMMENT 'Halálozási év (NULL ha él)',
  nationality VARCHAR(40) COMMENT 'Nemzetiség',
  is_alive BOOLEAN DEFAULT TRUE COMMENT 'Él-e még'
) COMMENT = 'Előadók';

CREATE TABLE albums (
  id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  title VARCHAR(200) NOT NULL COMMENT 'Album címe',
  artist_id INT UNSIGNED NOT NULL COMMENT 'Előadó azonosító',
  label_id INT UNSIGNED NOT NULL COMMENT 'Kiadó azonosító',
  genre_id INT UNSIGNED NOT NULL COMMENT 'Műfaj azonosító',
  release_year INT NOT NULL COMMENT 'Kiadás éve',
  tracks INT COMMENT 'Számok száma',
  price INT COMMENT 'Ár (Ft)',
  stock INT DEFAULT 0 COMMENT 'Raktárkészlet (db)',
  rating DECIMAL(3,2) COMMENT 'Értékelés (1.00-5.00)',
  is_platinum BOOLEAN DEFAULT FALSE COMMENT 'Platinalemez-e',

  CONSTRAINT fk_albums_artist
    FOREIGN KEY (artist_id) REFERENCES artists(id),
  CONSTRAINT fk_albums_label
    FOREIGN KEY (label_id) REFERENCES labels(id),
  CONSTRAINT fk_albums_genre
    FOREIGN KEY (genre_id) REFERENCES genres(id)
) COMMENT = 'Albumok';

-- ============================================================
-- MINTAADATOK FELTÖLTÉSE
-- ============================================================

-- Műfajok (12 db)
INSERT INTO genres (name) VALUES
  ('rock'), ('pop'), ('hip-hop'), ('electronic'),
  ('jazz'), ('klasszikus'), ('metal'), ('punk'),
  ('soul'), ('blues'), ('reggae'), ('filmzene');

-- Lemezkiadók (10 db)
INSERT INTO labels (name, city, founded_year, website) VALUES
  ('Universal Music', 'Los Angeles', 1934, 'www.universalmusic.com'),
  ('Sony Music', 'New York', 1929, 'www.sonymusic.com'),
  ('Warner Music', 'New York', 1958, 'www.warnermusic.com'),
  ('Hungaroton', 'Budapest', 1951, 'www.hungaroton.hu'),
  ('Island Records', 'London', 1959, 'www.islandrecords.com'),
  ('Parlophone', 'London', 1896, 'www.parlophone.co.uk'),
  ('Def Jam', 'New York', 1983, 'www.defjam.com'),
  ('Sub Pop', 'Seattle', 1986, 'www.subpop.com'),
  ('BMG', 'Berlin', 1987, 'www.bmg.com'),
  ('Atlantic Records', 'New York', 1947, 'www.atlanticrecords.com');

-- Előadók (18 db)
INSERT INTO artists (first_name, last_name, birth_year, death_year, nationality, is_alive) VALUES
  ('János', 'Kóbor', 1943, 2021, 'magyar', FALSE),
  ('Gábor', 'Presser', 1948, NULL, 'magyar', TRUE),
  ('Tibor', 'Kiss', 1963, NULL, 'magyar', TRUE),
  ('David', 'Bowie', 1947, 2016, 'brit', FALSE),
  ('Freddie', 'Mercury', 1946, 1991, 'brit', FALSE),
  ('Kurt', 'Cobain', 1967, 1994, 'amerikai', FALSE),
  ('Thom', 'Yorke', 1968, NULL, 'brit', TRUE),
  ('Thomas', 'Bangalter', 1975, NULL, 'francia', TRUE),
  ('Amy', 'Winehouse', 1983, 2011, 'brit', FALSE),
  ('Marshall', 'Mathers', 1972, NULL, 'amerikai', TRUE),
  ('Bob', 'Marley', 1945, 1981, 'jamaicai', FALSE),
  ('Johnny', 'Cash', 1932, 2003, 'amerikai', FALSE),
  ('Björk', 'Guðmundsdóttir', 1965, NULL, 'izlandi', TRUE),
  ('Ennio', 'Morricone', 1928, 2020, 'olasz', FALSE),
  ('Tamás', 'Cseh', 1943, 2009, 'magyar', FALSE),
  ('Márta', 'Sebestyén', 1957, NULL, 'magyar', TRUE),
  ('Bori', 'Péterfy', 1977, NULL, 'magyar', TRUE),
  ('András', 'Lovasi', 1969, NULL, 'magyar', TRUE);

-- Albumok (31 db)
INSERT INTO albums (title, artist_id, label_id, genre_id, release_year, tracks, price, stock, rating, is_platinum) VALUES
  ('Időrabló', 1, 4, 1, 1977, 8, 2990, 35, 4.72, TRUE),
  ('10000 lépés', 1, 4, 1, 1969, 10, 2490, 22, 4.65, TRUE),
  ('Mindig magasabbra', 2, 4, 1, 1975, 9, 2890, 30, 4.68, TRUE),
  ('Electro-Magnetic', 2, 4, 2, 2014, 13, 3490, 42, 4.55, TRUE),
  ('Kilégzés', 3, 4, 1, 2000, 11, 3690, 55, 4.78, TRUE),
  ('The Rise and Fall of Ziggy Stardust', 4, 6, 1, 1972, 11, 4290, 90, 4.95, TRUE),
  ('Heroes', 4, 6, 1, 1977, 10, 3890, 75, 4.88, TRUE),
  ('A Night at the Opera', 5, 1, 1, 1975, 12, 4590, 80, 4.97, TRUE),
  ('News of the World', 5, 1, 1, 1977, 11, 3990, 65, 4.91, TRUE),
  ('Nevermind', 6, 8, 1, 1991, 12, 3690, 120, 4.93, TRUE),
  ('In Utero', 6, 8, 8, 1993, 12, 3290, 85, 4.78, FALSE),
  ('OK Computer', 7, 6, 1, 1997, 12, 4290, 95, 4.96, TRUE),
  ('Kid A', 7, 6, 4, 2000, 10, 3990, 70, 4.89, TRUE),
  ('Discovery', 8, 1, 4, 2001, 14, 3490, 110, 4.92, TRUE),
  ('Random Access Memories', 8, 2, 4, 2013, 13, 4990, 130, 4.94, TRUE),
  ('Back to Black', 9, 5, 9, 2006, 11, 3890, 100, 4.90, TRUE),
  ('Frank', 9, 5, 9, 2003, 13, 3290, 15, 4.61, FALSE),
  ('The Marshall Mathers LP', 10, 1, 3, 2000, 18, 3990, 150, 4.88, TRUE),
  ('The Eminem Show', 10, 1, 3, 2002, 20, 3690, 140, 4.85, TRUE),
  ('Legend', 11, 5, 11, 1984, 14, 3290, 200, 4.94, TRUE),
  ('Exodus', 11, 5, 11, 1977, 10, 3590, 85, 4.91, TRUE),
  ('At Folsom Prison', 12, 2, 10, 1968, 16, 2990, 25, 4.82, TRUE),
  ('American IV: The Man Comes Around', 12, 1, 10, 2002, 15, 3490, 50, 4.87, FALSE),
  ('Homogenic', 13, 1, 4, 1997, 10, 4290, 38, 4.85, TRUE),
  ('Post', 13, 1, 4, 1995, 11, 3890, 18, 4.73, FALSE),
  ('A Jó, a Rossz és a Csúf', 14, 9, 12, 1966, 17, 2890, 18, 4.90, TRUE),
  ('Cinema Paradiso', 14, 9, 12, 1988, 14, 2590, 15, 4.86, TRUE),
  ('Mélyrepülés', 15, 4, 2, 1981, 10, 2290, 12, 4.50, FALSE),
  ('Frontátvonulás', 15, 4, 2, 1974, 9, 1990, 8, 4.45, FALSE),
  ('Le a kalappal', 17, 4, 1, 2005, 12, 3290, 48, 4.62, FALSE),
  ('Bálnavadászok', 18, 4, 1, 2003, 14, 3490, 52, 4.70, TRUE);

-- ============================================================
-- Az adatbázis készen áll a feladatok megoldására!
-- ============================================================

-- Műfajonkénti statisztika
INSERT INTO genres (name) VALUES ('country'), ('latin'), ('gospel');

INSERT INTO albums (title, artist_id, label_id, genre_id, release_year, tracks, price, stock, rating, is_platinum) VALUES
('Budapesti Búcsúkoncert', 1, 4, 1, 1999, 16, 3290, 45, 4.8, TRUE),
('Curtain Call', 10, 1, 3, 2005, 17, 3890, 95, 4.76, TRUE);


SELECT title, price, rating FROM albums 
WHERE is_platinum = TRUE AND rating > 4.8 AND price > 3000
ORDER BY rating DESC
LIMIT 5 ;

SELECT g.name AS mufaj, COUNT(a.id) AS albumok_szama, ROUND(AVG(a.rating), 2) AS atlag_ertekeles, SUM(a.stock) AS osszes_keszlet
FROM albums a
JOIN genres g ON a.genre_id = g.id  
GROUP BY g.name, g.id
HAVING COUNT(*) >= 3
ORDER BY albumok_szama DESC;

SELECT a.title AS album_cime, CONCAT(ar.first_name, ' ', ar.last_name) AS eloado_nev, l.name AS kiado_neve, g.name AS mufaj
FROM albums a
JOIN artists ar ON a.artist_id = ar.id
JOIN labels l ON a.label_id = l.id
JOIN genres g ON a.genre_id = g.id
WHERE a.release_year > 2000 OR a.rating > 4.9
ORDER BY ar.last_name, a.release_year ASC;

UPDATE albums SET price = ROUND(price * 1.25)
WHERE rating >= 4.85 AND is_platinum = TRUE;

UPDATE albums SET stock = stock + 50
WHERE release_year > 1990 AND stock < 20;

ALTER TABLE albums ADD COLUMN catalog_number VARCHAR(20) UNIQUE COMMENT 'Katalógus szám',
 MODIFY COLUMN rating DECIMAL(4,2);

DELETE FROM albums
WHERE release_year < 1970 AND stock < 30;

DELETE artists FROM artists
LEFT JOIN albums ON artists.id = albums.artist_id
WHERE albums.id IS NULL;
