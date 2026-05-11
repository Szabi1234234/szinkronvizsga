-- =============================================================
--  sebessegmeres_install.sql
--  Sebességmérési adatbázis – telepítő és mintaadat szkript
--  Informatika és távközlés – Adatbázis-kezelés gyakorlat
-- =============================================================

DROP DATABASE IF EXISTS sebessegmeres;

CREATE DATABASE sebessegmeres
    CHARACTER SET utf8mb4
    COLLATE utf8mb4_hungarian_ci;

USE sebessegmeres;

-- -------------------------------------------------------------
-- 1. Tábla: helyszinek
-- -------------------------------------------------------------
CREATE TABLE helyszinek (
    id              INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    varos           VARCHAR(80)  NOT NULL  COMMENT 'Helyszín városa',
    utca            VARCHAR(120) NOT NULL  COMMENT 'Utca / útvonal neve',
    sebesseg_hatar  INT          NOT NULL  COMMENT 'Megengedett sebesség (km/h)',
    helyszin_tipus  VARCHAR(40)            COMMENT 'Helyszín típusa',
    megye           VARCHAR(60)            COMMENT 'Megye'
) COMMENT = 'Mérési helyszínek';

-- -------------------------------------------------------------
-- 2. Tábla: jarmuvezetok
-- -------------------------------------------------------------
CREATE TABLE jarmuvezetok (
    id              INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    vezeteknev      VARCHAR(60)  NOT NULL  COMMENT 'Vezetéknév',
    keresztnev      VARCHAR(60)  NOT NULL  COMMENT 'Keresztnév',
    szuletesi_ev    INT                    COMMENT 'Születési év',
    nem             VARCHAR(10)            COMMENT 'Nem (férfi / nő)',
    lakcim_varos    VARCHAR(80)            COMMENT 'Lakcím városa',
    pontszam        INT          DEFAULT 0 COMMENT 'Büntetőpontok száma'
) COMMENT = 'Járművezetők';

-- -------------------------------------------------------------
-- 3. Tábla: jarmuvek
-- -------------------------------------------------------------
CREATE TABLE jarmuvek (
    id              INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    rendszam        VARCHAR(20)  NOT NULL  COMMENT 'Rendszám',
    marka           VARCHAR(60)  NOT NULL  COMMENT 'Gépjármű márkája',
    tipus           VARCHAR(60)            COMMENT 'Gépjármű típusa',
    kategoria      VARCHAR(40)            COMMENT 'Jármű kategóriája',
    gyartas_eve     INT                    COMMENT 'Gyártási év'
) COMMENT = 'Gépjárművek';

-- -------------------------------------------------------------
-- 4. Tábla: meresek
-- -------------------------------------------------------------
CREATE TABLE meresek (
    id              INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    helyszin_id     INT UNSIGNED NOT NULL  COMMENT 'Helyszín FK',
    vezeto_id       INT UNSIGNED NOT NULL  COMMENT 'Járművezető FK',
    jarmu_id        INT UNSIGNED NOT NULL  COMMENT 'Jármű FK',
    mert_sebesseg   INT          NOT NULL  COMMENT 'Mért sebesség (km/h)',
    tullepes_km     INT          NOT NULL  COMMENT 'Túllépés mértéke (km/h)',
    meres_datuma    DATE         NOT NULL  COMMENT 'Mérés dátuma',
    meres_oraja     TIME                   COMMENT 'Mérés időpontja',
    birsag_osszeg   INT                    COMMENT 'Bírság összege (Ft)',
    kifizetve       BOOLEAN DEFAULT FALSE  COMMENT 'Bírság kifizetve-e',
    CONSTRAINT fk_meresek_helyszin
        FOREIGN KEY (helyszin_id) REFERENCES helyszinek(id),
    CONSTRAINT fk_meresek_vezeto
        FOREIGN KEY (vezeto_id)   REFERENCES jarmuvezetok(id),
    CONSTRAINT fk_meresek_jarmu
        FOREIGN KEY (jarmu_id)    REFERENCES jarmuvek(id)
) COMMENT = 'Sebességmérési adatok';

-- =============================================================
--  MINTAADATOK
-- =============================================================

-- Helyszínek (8 rekord)
INSERT INTO helyszinek (varos, utca, sebesseg_hatar, helyszin_tipus, megye) VALUES
    ('Budapest',  'Váci út 12.',             50,  'főút',       'Pest'),
    ('Budapest',  'Üllői út 88.',            50,  'főút',       'Pest'),
    ('Debrecen',  'Hajdú út 34.',            70,  'főút',       'Hajdú-Bihar'),
    ('Miskolc',   'Avasi lakótelep bejárat', 30,  'lakóövezet', 'Borsod-Abaúj-Zemplén'),
    ('Győr',      'Árpád út 5.',             60,  'főút',       'Győr-Moson-Sopron'),
    ('Pécs',      'Mecsek utca 3.',          30,  'lakóövezet', 'Baranya'),
    ('Siófok',    'M7 autópálya 101. km',   130,  'autópálya',  'Somogy'),
    ('Tatabánya', 'M1 autópálya 58. km',    130,  'autópálya',  'Komárom-Esztergom');

-- Járművezetők (10 rekord) – 2 vezetőnek szándékosan nincs mérése (LEFT JOIN feladathoz)
INSERT INTO jarmuvezetok (vezeteknev, keresztnev, szuletesi_ev, nem, lakcim_varos, pontszam) VALUES
    ('Kovács',    'Péter',    1978, 'férfi', 'Budapest',  4),
    ('Nagy',      'Ádám',     1992, 'férfi', 'Debrecen',  0),
    ('Szabó',     'Bence',    1985, 'férfi', 'Miskolc',   8),
    ('Kiss',      'Gábor',    1970, 'férfi', 'Győr',      2),
    ('Varga',     'Dávid',    2001, 'férfi', 'Pécs',      0),
    ('Fekete',    'Eszter',   1995, 'nő',    'Budapest',  6),
    ('Horváth',   'Luca',     1999, 'nő',    'Siófok',    0),
    ('Tóth',      'Miklós',   1965, 'férfi', 'Tatabánya', 12),
    ('Farkas',    'Nóra',     2003, 'nő',    'Debrecen',  0),   -- nincs mérése
    ('Balogh',    'Tamás',    1950, 'férfi', 'Budapest',  0);   -- nincs mérése

-- Járművek (10 rekord) – 1 járműnek szándékosan nincs mérése (LEFT JOIN feladathoz)
INSERT INTO jarmuvek (rendszam, marka, tipus, kategoria, gyartas_eve) VALUES
    ('ABC-123', 'Toyota',     'Corolla',      'személyautó',      2018),
    ('DEF-456', 'BMW',        '3 Series',     'személyautó',      2022),
    ('GHI-789', 'Ford',       'Transit',      'tehergépjármű',    2019),
    ('JKL-012', 'Volkswagen', 'Golf',         'személyautó',      2017),
    ('MNO-345', 'Honda',      'CB500',        'motorkerékpár',    2020),
    ('PQR-678', 'Mercedes',   'Sprinter',     'tehergépjármű',    2015),
    ('STU-901', 'Audi',       'A4',           'személyautó',      2021),
    ('VWX-234', 'Suzuki',     'Swift',        'személyautó',      2016),
    ('YZA-567', 'Renault',    'Clio',         'személyautó',      2023),
    ('BCD-890', 'Kawasaki',   'Z650',         'motorkerékpár',    2021);  -- nincs mérése

-- Mérések (42 rekord)
-- helyszin_id, vezeto_id, jarmu_id,
-- mert_sebesseg, tullepes_km, meres_datuma, meres_oraja,
-- birsag_osszeg, kifizetve
INSERT INTO meresek
    (helyszin_id, vezeto_id, jarmu_id,
     mert_sebesseg, tullepes_km, meres_datuma, meres_oraja,
     birsag_osszeg, kifizetve)
VALUES
-- Kovács Péter (vezeto_id=1)
(1, 1, 1,  72,  22, '2024-01-15', '08:12:00', 30000,  TRUE),
(7, 1, 1, 158,  28, '2024-03-22', '14:30:00', 50000,  FALSE),
(2, 1, 4,  81,  31, '2024-06-10', '17:45:00', 50000,  TRUE),

-- Nagy Ádám (vezeto_id=2)
(3, 2, 4,  92,  22, '2024-02-08', '09:00:00', 30000,  TRUE),
(5, 2, 4,  78,  18, '2024-04-17', '07:30:00', 15000,  TRUE),
(8, 2, 2, 162,  32, '2024-07-03', '21:15:00', 50000,  FALSE),

-- Szabó Bence (vezeto_id=3)
(4, 3, 8,  58,  28, '2024-01-28', '23:50:00', 50000,  FALSE),
(6, 3, 8,  55,  25, '2024-02-14', '22:10:00', 50000,  TRUE),
(1, 3, 8,  95,  45, '2024-05-05', '18:20:00', 90000,  FALSE),
(7, 3, 5, 175,  45, '2024-08-19', '13:10:00', 90000,  FALSE),

-- Kiss Gábor (vezeto_id=4)
(5, 4, 7,  85,  25, '2024-03-01', '06:45:00', 30000,  TRUE),
(3, 4, 7, 110,  40, '2024-05-20', '16:00:00', 90000,  FALSE),
(8, 4, 2, 148,  18, '2024-09-14', '10:30:00', 15000,  TRUE),

-- Varga Dávid (vezeto_id=5)
(6, 5, 9,  52,  22, '2024-01-07', '11:25:00', 30000,  TRUE),
(2, 5, 9,  68,  18, '2024-04-30', '15:55:00', 15000,  FALSE),

-- Fekete Eszter (vezeto_id=6)
(1, 6, 1,  88,  38, '2024-02-22', '19:40:00', 90000,  FALSE),
(4, 6, 4,  62,  32, '2024-03-18', '07:05:00', 50000,  TRUE),
(7, 6, 5, 180,  50, '2024-06-25', '23:00:00', 150000, FALSE),
(2, 6, 1,  74,  24, '2024-10-02', '08:30:00', 30000,  FALSE),

-- Horváth Luca (vezeto_id=7)
(7, 7, 9, 155,  25, '2024-04-12', '12:00:00', 30000,  TRUE),
(5, 7, 9,  88,  28, '2024-07-21', '16:45:00', 50000,  TRUE),

-- Tóth Miklós (vezeto_id=8)
(1, 8, 6,  86,  36, '2024-01-30', '20:15:00', 90000,  FALSE),
(2, 8, 6,  92,  42, '2024-03-09', '06:20:00', 90000,  FALSE),
(4, 8, 3,  72,  42, '2024-05-15', '22:45:00', 90000,  FALSE),
(6, 8, 3,  68,  38, '2024-06-01', '21:30:00', 90000,  FALSE),
(7, 8, 5, 192,  62, '2024-07-18', '00:10:00', 150000, FALSE),
(8, 8, 2, 175,  45, '2024-09-27', '03:20:00', 90000,  FALSE),
(3, 8, 7, 118,  48, '2024-10-10', '11:00:00', 90000,  FALSE),

-- Vegyes, több helyszínen
(8, 1, 2, 165,  35, '2024-11-03', '04:45:00', 90000,  FALSE),
(1, 2, 4,  79,  29, '2024-11-15', '08:00:00', 50000,  TRUE),
(3, 3, 8, 105,  35, '2024-11-22', '17:30:00', 90000,  FALSE),
(5, 5, 7,  89,  29, '2024-12-01', '09:15:00', 50000,  FALSE),
(6, 4, 9,  57,  27, '2024-12-05', '14:20:00', 50000,  TRUE),
(2, 7, 4,  73,  23, '2024-12-08', '07:50:00', 30000,  TRUE),
(4, 6, 8,  65,  35, '2024-12-10', '22:00:00', 90000,  FALSE),
(7, 4, 1, 165,  35, '2024-12-12', '15:45:00', 90000,  FALSE),
(1, 5, 9,  78,  28, '2024-12-14', '08:10:00', 50000,  FALSE),
(8, 3, 2, 172,  42, '2024-12-17', '02:30:00', 90000,  FALSE),
(3, 2, 7, 100,  30, '2024-12-20', '10:00:00', 50000,  FALSE),
(5, 1, 4,  82,  22, '2024-12-23', '16:30:00', 30000,  TRUE),
(6, 7, 1,  61,  31, '2024-12-28', '20:45:00', 50000,  FALSE);