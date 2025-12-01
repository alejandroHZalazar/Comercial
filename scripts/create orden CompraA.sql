using pañalera;

CREATE TABLE `ordenCompra` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `fecha` DATETIME NULL,
  `fk_proveedor` INT NULL,
  `total` DECIMAL(18,4) NULL,
  `procesado` TINYINT(1) NULL,
  PRIMARY KEY (`id`));