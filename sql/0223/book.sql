DROP DATABASE IF EXISTS bookstore;
CREATE DATABASE bookstore
CHARACTER SET utf8mb4
COLLATE utf8mb4_hungarian_ci;
USE bookstore;

CREATE TABLE categories (
id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
name VARCHAR(50) NOT NULL COMMENT 'Kategória neve'
) COMMENT = 'Könyvkategóriák';

CREATE TABLE publishers (
id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
name VARCHAR(100) NOT NULL COMMENT 'Kiadó neve',
city VARCHAR(80) COMMENT 'Székhely város',
founded_year INT COMMENT 'Alapítás éve',
website VARCHAR(150) COMMENT 'Weboldal cím'
) COMMENT = 'Könyvkiadók';

CREATE TABLE authors (
id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
first_name VARCHAR(60) NOT NULL COMMENT 'Keresztnév',
last_name VARCHAR(60) NOT NULL COMMENT 'Vezetéknév',
birth_year INT COMMENT 'Születési év',
death_year INT COMMENT 'Halálozási év (NULL ha él)',
nationality VARCHAR(40) COMMENT 'Nemzetiség',
is_alive BOOLEAN DEFAULT TRUE COMMENT 'Él-e még'
) COMMENT = 'Szerzők';

CREATE TABLE books (
id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
title VARCHAR(200) NOT NULL COMMENT 'Könyv címe',
author_id INT UNSIGNED NOT NULL COMMENT 'Szerző azonosító',
publisher_id INT UNSIGNED NOT NULL COMMENT 'Kiadó azonosító',
category_id INT UNSIGNED NOT NULL COMMENT 'Kategória azonosító',
publish_year INT NOT NULL COMMENT 'Kiadás éve',
pages INT COMMENT 'Oldalak száma',
price INT COMMENT 'Ár (Ft)',
stock INT DEFAULT 0 COMMENT 'Raktárkészlet (db)',
rating DECIMAL(3,2) COMMENT 'Értékelés (1.00-5.00)',
is_bestseller BOOLEAN DEFAULT FALSE COMMENT 'Bestseller-e',
CONSTRAINT fk_books_author
FOREIGN KEY (author_id) REFERENCES authors(id),
CONSTRAINT fk_books_publisher
FOREIGN KEY (publisher_id) REFERENCES publishers(id),
CONSTRAINT fk_books_category
FOREIGN KEY (category_id) REFERENCES categories(id)
) COMMENT = 'Könyvek';