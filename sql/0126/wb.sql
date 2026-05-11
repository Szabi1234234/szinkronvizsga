-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema cars
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema cars
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `cars` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci ;
USE `cars` ;

-- -----------------------------------------------------
-- Table `cars`.`countries`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `cars`.`countries` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Ország azonosítója',
  `name` VARCHAR(50) NOT NULL COMMENT 'Ország neve',
  PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = 'Országok';


-- -----------------------------------------------------
-- Table `cars`.`categories`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `cars`.`categories` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Kategória azonosítója',
  `name` VARCHAR(30) NOT NULL COMMENT 'Kategória neve',
  PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = 'Kategóriák';


-- -----------------------------------------------------
-- Table `cars`.`colors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `cars`.`colors` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Színek azonosító',
  `name` VARCHAR(30) NOT NULL COMMENT 'Szín neve',
  PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = 'Színek';


-- -----------------------------------------------------
-- Table `cars`.`fuel_types`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `cars`.`fuel_types` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Üzemanyag azonosítója',
  `name` VARCHAR(30) NOT NULL COMMENT 'Üzemanyag neve',
  PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = 'Üzemanyag típusok';


-- -----------------------------------------------------
-- Table `cars`.`brands`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `cars`.`brands` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Autó típus ID',
  `name` VARCHAR(50) NOT NULL COMMENT 'Márka neve',
  `founded_year` INT NULL COMMENT 'Alapítás éve',
  `countries_id` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_brands_countries_idx` (`countries_id` ASC) VISIBLE,
  CONSTRAINT `fk_brands_countries`
    FOREIGN KEY (`countries_id`)
    REFERENCES `cars`.`countries` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
COMMENT = 'Autó márkák\n';


-- -----------------------------------------------------
-- Table `cars`.`models`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `cars`.`models` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Típus azonosító',
  `name` VARCHAR(50) NOT NULL COMMENT 'Típus neve',
  `brand_id` INT UNSIGNED NOT NULL COMMENT 'Márka azonosító',
  `category_id` INT UNSIGNED NOT NULL COMMENT 'Kategória azonosító',
  `production_start` INT NULL COMMENT 'Gyártás kezdete (év)',
  `production_end` INT NULL COMMENT 'Gyártás vége (év) NULL ha még gyártják',
  PRIMARY KEY (`id`),
  INDEX `fk_models_brands1_idx` (`brand_id` ASC) VISIBLE,
  INDEX `fk_models_categories1_idx` (`category_id` ASC) VISIBLE,
  CONSTRAINT `fk_models_brands1`
    FOREIGN KEY (`brand_id`)
    REFERENCES `cars`.`brands` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_models_categories1`
    FOREIGN KEY (`category_id`)
    REFERENCES `cars`.`categories` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
COMMENT = 'Autó típusok\n';


-- -----------------------------------------------------
-- Table `cars`.`cars`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `cars`.`cars` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Autó azonosító',
  `model_id` INT UNSIGNED NOT NULL COMMENT 'Típus azonosító',
  `color_id` INT UNSIGNED NOT NULL COMMENT 'Szín',
  `year` INT NOT NULL COMMENT 'Gyártási év',
  `mileage` INT NULL DEFAULT 0 COMMENT 'Futott km',
  `price` INT NULL COMMENT 'Ár (Ft)',
  `fuel_type_id` INT UNSIGNED NOT NULL COMMENT 'Üzemanyag típus',
  `engine_capacity` INT NULL COMMENT 'Hengerürtartalom (cm3)',
  `horsepower` INT NULL COMMENT 'Teljesítmény (LE)',
  `purchase_date` DATE NULL COMMENT 'Vásárlás dátuma',
  `mot_expiry` DATE NULL COMMENT 'Forgalmi érvényessége',
  PRIMARY KEY (`id`),
  INDEX `fk_cars_models1_idx` (`model_id` ASC) VISIBLE,
  INDEX `fk_cars_colors1_idx` (`color_id` ASC) VISIBLE,
  INDEX `fk_cars_fuel_types1_idx` (`fuel_type_id` ASC) VISIBLE,
  CONSTRAINT `fk_cars_models1`
    FOREIGN KEY (`model_id`)
    REFERENCES `cars`.`models` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_cars_colors1`
    FOREIGN KEY (`color_id`)
    REFERENCES `cars`.`colors` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_cars_fuel_types1`
    FOREIGN KEY (`fuel_type_id`)
    REFERENCES `cars`.`fuel_types` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
COMMENT = 'Konkrét autók';


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
