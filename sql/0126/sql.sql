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