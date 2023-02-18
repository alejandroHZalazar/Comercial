CREATE TABLE `pedidos` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `total` DECIMAL(18,4) NULL,
  `fecha` DATE NULL,
  `fk_cliente` INT NULL,
  `iva` DECIMAL(18,4) NULL,
  `recargo` DECIMAL(18,4) NULL,
  `descuento` DECIMAL(18,4) NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `total_UNIQUE` (`total` ASC));