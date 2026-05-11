CREATE DATABASE IF NOT EXISTS music CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci;

USE music;

CREATE TABLE IF NOT EXISTS countries (
    id INT UNSIGNED PRIMARY KEY AUTO_INCREMENT NOT NULL COMMENT 'Ország azonosító',
    name VARCHAR(50) NOT NULL COMMENT 'Ország neve'
) COMMENT 'Országok'

CREATE TABLE IF NOT EXISTS genres (
    id INT UNSIGNED PRIMARY KEY AUTO_INCREMENT NOT NULL COMMENT 'Műfaj azonosító',
    name VARCHAR(50) NOT NULL COMMENT 'Műfaj neve'
) COMMENT 'Műfajok'

CREATE TABLE IF NOT EXISTS record_labels (
    id INT UNSIGNED PRIMARY KEY AUTO_INCREMENT NOT NULL COMMENT 'Lemezkiadó azonosító',
    name VARCHAR(100) NOT NULL COMMENT 'Kiadó neve',
    founded_year INT COMMENT "Alapítás éve"
) COMMENT 'Lemezkiadók'

CREATE TABLE IF NOT EXISTS formats (
    id INT UNSIGNED PRIMARY KEY AUTO_INCREMENT NOT NULL COMMENT 'Formátum azonosító',
    name VARCHAR(30) NOT NULL COMMENT 'Formátum neve'
) COMMENT 'Formátumok'

-----------------------------------

CREATE TABLE IF NOT EXISTS artists (
    id INT UNSIGNED PRIMARY KEY AUTO_INCREMENT NOT NULL COMMENT 'Előadó azonosító',
    name VARCHAR(100) NOT NULL COMMENT 'Előadó/zenekar neve',
    country_id INT UNSIGNED NOT NULL COMMENT 'Ország azonosító',
    FOREIGN KEY (country_id) REFERENCES countries(id),
    genre_id INT UNSIGNED NOT NULL COMMENT 'Műfaj azonosító',
    FOREIGN KEY (genre_id) REFERENCES genres(id)
    formed_year INT COMMENT 'Alakulás/indulás éve',
    is_active BOOLEAN NOT NULL DEFAULT 'TRUE' COMMENT 'Aktív-e',
    member_count TINYINT  COMMENT 'Tagok száma'
) COMMENT 'Előadók/zenekarok'

CREATE TABLE IF NOT EXISTS albums (
    id INT UNSIGNED PRIMARY KEY AUTO_INCREMENT NOT NULL COMMENT 'Album azonosító',
    title VARCHAR(150) NOT NULL COMMENT 'Album címe',
    artist_id INT UNSIGNED NOT NULL COMMENT 'Előadó azonosító',
    FOREIGN KEY (artist_id) REFERENCES artists(id),
    label_id INT UNSIGNED NOT NULL COMMENT 'Kiadó azonosító',
    FOREIGN KEY (label_id) REFERENCES record_labels(id),
    release_date DATE NOT NULL COMMENT 'Kiadás dátuma',
    format_id INT UNSIGNED NOT NULL COMMENT 'Formátum azonosító',
    FOREIGN KEY (format_id) REFERENCES formats(id),
    price INT COMMENT 'Ár (Ft)',
    copies_sold INT DEFAULT 0 COMMENT 'Eladott példányszám',
    rating DECIMAL(3,2) COMMENT 'Értékelés (1.00-5.00)'
) COMMENT 'Zenei albumok'

CREATE TABLE IF NOT EXISTS songs (
    id INT UNSIGNED PRIMARY KEY AUTO_INCREMENT NOT NULL COMMENT 'Dal azonosító',
    title VARCHAR(200) NOT NULL COMMENT 'Dal címe',
    album_id INT UNSIGNED NOT NULL COMMENT 'Album azonosító',
    FOREIGN KEY (album_id) REFERENCES albums(id),
    track_number TINYINT NOT NULL COMMENT 'Sorszám az albumon',
    duration INT NOT NULL COMMENT 'Hossz (másodpercben)',
    genre_id INT UNSIGNED NOT NULL COMMENT 'Műfaj azonosító',
    FOREIGN KEY (genre_id) REFERENCES genres(id),
    plays INT DEFAULT 0 COMMENT 'Lejátszások száma',
    is_single BOOLEAN NOT NULL DEFAULT 'FALSE' COMMENT 'Megjelent-e kislemezként',
    writer VARCHAR(100) COMMENT 'Dalszerző neve'
) COMMENT 'Dalok/számok'

--------------------

INSTERT INTO countries (name) VALUES
('USA'), ('Egyesült Királyság'), ('Kanada'), ('Ausztrália'), ('Írország');

INSERT INTO genres (name) VALUES
('rock'), ('pop'), ('jazz'), ('blues'), ('country'), ('hip-hop'), ('elektronikus');

INSERT INTO record_labels (name, founded_year) VALUES
('Atlantic Records', 1947), ('Columbia Records', 1887), ('Warner Music', 1958), ('Universal Music', 1934);

INSERT INTO formats (name) VALUES
('CD'), ('vinyl'), ('digitális'), ('kazetta');

INSERT INTO artists (name, country_id, genre_id, formed_year, is_active, member_count) VALUES
('The Beatles', 2, 1, 1960, FALSE, 4),
('Pink Floyd', 2, 1, 1965, FALSE, 5),
('Queen', 2, 1, 1970, TRUE, 4),
('Led Zeppelin', 2, 1, 1968, FALSE, 4);

INSERT INTO albums (title, artist_id, label_id, release_date, format_id, price, copies_sold, rating) VALUES
('Abbey Road', 1, 1, '1969-09-26', 1, 8500, 25000000, 4.95),
('The Dark Side of the Moon', 2, 2, '1973-03-01', 1, 6500, 45000000, 4.98),
('A Night at the Opera', 3, 3, '1975-11-21', 1, 7200, 60000000, 4.89),
('Led Zeppelin IV', 4, 4, '1971-11-08', 1, 8900, 37000000, 4.92);

INSERT INTO songs (title, album_id, track_number, duration, genre_id, plays, is_single, writer) VALUES
('Come Together', 1, 1, 259, 1, 25000000, TRUE, 'Lennon-McCartney'),
('Something', 1, 2, 182, 1, 18000000, TRUE, 'George Harrison'),
('Time', 2, 6, 382, 1, 41000000, TRUE, 'Roger Waters'),
('Stairway to Heaven', 4, 1, 482, 1, 35000000, FALSE, 'Page Plant');

------------------------------------

ALTER TABLE artists
    ADD COLUMN website VARCHAR(150) COMMENT 'Hivatalos weboldal';

ALTER TABLE albums
    ADD 1