DROP DATABASE IF EXISTS cars;
CREATE DATABASE IF NOT EXISTS cars DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci;

USE CARS;

CREATE TABLE countries (
	`id` INT UNSIGNED AUTO_INCREMENT COMMENT 'Ország azonsoítója',
    name VARCHAR(50) NOT NULL COMMENT 'Ország neve', PRIMARY KEY (id)
) COMMENT = 'Országok';

CREATE TABLE categories (
	id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY COMMENT 'Kategória azonosító',
    name VARCHAR(30) NOT NULL COMMENT 'Kategória neve'
) COMMENT = 'Kategóriák';

CREATE TABLE colors (
	id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY COMMENT 'Színek',
    name VARCHAR(30) NOT NULL COMMENT 'Szín neve'
) COMMENT 'Színek';

CREATE TABLE fuel_types (
	id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY COMMENT 'Üzemanyag azonosító',
    name VARCHAR(30) NOT NULL COMMENT 'Üzemanyag neve'
) COMMENT 'Üzemanyag típusok';

CREATE TABLE brands (
	id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY COMMENT 'Márka azonosító',
    name VARCHAR(50) NOT NULL COMMENT 'Márka neve',
    founded_year INT COMMENT 'Alapítás éve',
    country_id INT UNSIGNED NOT NULL, FOREIGN KEY(country_id) REFERENCES countries(id)
) COMMENT 'Márkák';

CREATE TABLE models (
	id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY COMMENT 'Model azonosító',
    name VARCHAR(50) NOT NULL COMMENT 'Model neve',
    brand_id INT UNSIGNED NOT NULL COMMENT 'Márka azonosító', FOREIGN KEY(brand_id) REFERENCES brands(id),
    category_id INT UNSIGNED NOT NULL COMMENT 'Kategória azonosító', FOREIGN KEY(category_id) REFERENCES categories(id),
    production_start INT COMMENT 'Gyártás kezdete',
    production_end INT COMMENT 'Gyártás vége'
) COMMENT 'Modellek';

CREATE TABLE cars (
    id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY COMMENT 'Autó azonosító',
    model_id INT UNSIGNED NOT NULL  COMMENT 'Model azonosító', FOREIGN KEY(model_id) REFERENCES models(id),
    license_plate VARCHAR(10) NOT NULL COMMENT 'Rendszám', -- AA-AA-123 AAA-111
    color_id INT UNSIGNED NOT NULL COMMENT 'Szín', FOREIGN KEY(color_id) REFERENCES colors(id),
    year INT NOT NULL COMMENT 'Gyártási év',
    mileage INT DEFAULT 0 COMMENT "Futott km",
    price INT COMMENT "ár (ft)",
    fuel_type_id INT UNSIGNED NOT NULL COMMENT 'Üzemanyag típus', foreign key (fuel_type_id) REFERENCES fuel_types(id),
    engine_capacity int COMMENT 'Hengerűrtartalom (cm3)', 
    horsepower INT COMMENT 'Teljesítmény (LE)',
    purchase_date DATE comment 'Vásárlás dátuma',
    mot_expiry DATE NOT NULL COMMENT 'Forgalmi érvényessége' -- megjegyzés: feladat nem kéri a notnullt, de sztem ez fontos infó és kell
) comment 'Konkrét autók';


INSERT INTO countries (name) VALUES('Japán'),
 ('Németország'),
 ('USA'),
 ('Dél-Korea'),
 ('Franciaország'),
 ('Olaszország'),
 ('Egyesült Királyság'),
 ('Svédország'),
 ('Csehország'),
 ('Spanyolország'),
 ('Kína'),
 ('INdia'),
 ('Magyarország');

 INSERT INTO categories (name) VALues('sedan'),
 ('SUV'),
 ('hatchback'),
 ('kombi'),
 ('pickup'),
 ('coupe'),
 ('kabrió'),
 ('minivan'),
 ('crossover'),
 ('sportautó');

 INSERT INTO colors (name) VALUES('fehér'),
 ('fekete'),
 ('ezüst'),
 ('piros'),
 ('kék'),
 ('zöld'),
 ('sárga'),
 ('narancs'),
 ('barna'),
 ('bordó'),
 ('lila'),
 ('arany');

 INSERT INTo fuel_types (name) VALUES ('benzin'),
 ('dízel'),
 ('hibrid'),
 ('plugin hibrid'),
 ('gáz'),
 ('etanol'),
 ('biodízel');

 INSERT INTO brands (name, founded_year, country_id) VALUES
 ('Toyota', 1937, 1),
 ('BMW', 1916, 2),
 ('Ford', 1903, 3),
 ('Hyundai', 1967, 4),
 ('Renault', 1899, 5),
 ('Fiat', 1899, 6),
 ('Wolksvagen', 1937, 2),
 ('Volvo', 1927, 8),
 ('Suzuki', 1909, 1),
 ('Audi', 1909, 2),
 ('Mercedes-Benz', 1926, 2),
 ('SEAT', 1950, 10),
 ('Cadillac', 1902, 3),
 ('Opel', 1862, 2),
 ('Ferrari', 1947, 6);

 INSERT INTO models (name, brand_id, category_id, production_start, production_end) VALUES
 ('Toyota Corolla', 1, 1, 1966, NULL),
 ('Toyota RAV4', 1, 2, 1994, NULL),
 ('BMW X5', 2, 2, 1999, NULL),
 ('Ford Focus', 3, 3, 1998, NULL),
 ('BMW 3 széria', 2, 1, 1998, NULL),
 ('Hyundai Santa Fe', 4, 2, 2000, NULL),
 ('Renault Clio', 5, 3, 1990, NULL),
 ('Fiat 500', 6, 3, 2007, NULL),
 ('Volkswagen Golf', 7, 3, 1974, NULL),
 ('Volvo XC60', 8, 2, 2008, NULL),
 ('Suzuki Swift', 9, 3, 1983, NULL),
 ('Audi RS6', 10, 4, 2002, NULL),
 ('Mercedes-Benz C osztály', 11, 1, 1993, NULL),
 ('Seat Leon', 12, 3, 1999, NULL),
 ('Ferrari F40', 15, 6, 1987, 1992),
 ('Cadillac Escalade', 13, 2, 1998, NULL),
 ('Opel Astra', 14, 3, 1991, NULL);

 INSERT INTO cars (model_id, license_plate, color_id, year, mileage, price, fuel_type_id, engine_capacity, horsepower, purchase_date, mot_expiry) VALUES
 (1, 'KAB-123', 1, 2005, 210000, 1200000, 1, 1598, 110, '2019-05-10', '2026-05-10'),
 (11, 'RKA-404', 4, 2019, 45000, 4200000, 1, 1242, 90, '2020-06-01', '2027-06-01'),
 (3, 'AA-AB-423', 2, 2022, 25000, 28000000, 2, 2993, 286, '2022-08-15', '2028-08-15'),
 (4, 'MZZ-500', 3, 2013, 160000, 3500000, 1, 1390, 122, '2017-03-20', '2026-03-20'),
 (15, 'OT-12-34', 4, 1990, 12000, 50000000, 1, 2936, 478, '2010-01-01', '2027-01-01'),
 (8, 'PPL-688', 7, 2018, 30000, 3900000, 1, 1242, 69, '2020-11-05', '2026-11-05'),
 (12, 'AE-RS-600', 3, 2023, 8000, 45000000, 1, 3996, 600, '2023-02-20', '2029-02-20'),
 (13, 'SND-913', 5, 2016, 145000, 6800000, 3, 2143, 170, '2019-09-10', '2026-09-10'),
 (2, 'ZZZ-999', 6, 2020, 55000, 11500000, 4, 2487, 218, '2021-12-01', '2027-12-01'),
 (7, 'LCA-145', 8, 2008, 195000, 950000, 1, 1149, 75, '2015-07-15', '2026-07-15'),
 (16, 'CA-DI-111', 2, 2015, 130000, 15000000, 2, 6142, 426, '2018-05-05', '2028-05-05'),
 (17, 'HLY-992', 3, 1993, 180000, 800000, 1, 1598, 75, '2003-04-11', '2027-04-11'),
 (10, 'PEJ-384', 2, 2008, 300000, 4500000, 2, 2400, 200, '2012-09-09', '2026-09-09'),
 (4, 'NDK-882', 1, 2014, 140000, 3700000, 1, 1596, 125, '2016-10-20', '2027-10-20'),
 (6, 'RNO-456', 5, 2017, 80000, 5200000, 1, 1461, 114, '2018-03-30', '2026-03-30');

 ALTER TABLE brands ADD COLUMN website VARCHAR(100) COMMENT 'Hivataéps weboldal';

 ALTER TABLE cars ADD COLUMN doors TINYINT DEFAULT 5 COMMENT 'Ajtók száma';

 ALTER TABLE cars MODIFY column license_plate VARCHAR(15) NOT NULL COMMENT 'Rendszám';

 ALTER TABLE cars MODIFY column mileage INT NOT NULL DEFAULT 0 COMMENT 'Futott km';

 ALTER TABLE brands MODIFY COLUMN founded_year INT NOT NULL COMMENT 'Alapítás éve';

 ALTER TABLE brands MODIFY COLUMN name VARCHAR(100) NOT NULL UNIQUE COMMENT 'Márka neve';

 ALTER TABLE models ADD COLUMN active BOOLEAN NOT NULL DEFAULT TRUE COMMENT 'Aktív gyártás';

 ALTER TABLE cars CHANGE COLUMN horsepower power INT COMMENT 'Teljesítmény (LE)';

 ALTER TABLE cars DROP column doors;

 ALTER TABLE cars ADD COLUMN vin VARCHAR(17) NOT NULL COMMENT 'Alvázszám', ADD COLUMN owner VARCHAR(100) COMMENT 'Tulajdonos neve'; 
 