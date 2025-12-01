use pañalera;

CREATE TABLE `productosMovimientos` (
  `id` BIGINT(20) NOT NULL AUTO_INCREMENT,
  `fk_producto` INT NULL,
  `tipoMovimiento` INT NULL,
  `descripcion` VARCHAR(150) NULL,
  `stockAnt` DECIMAL(18,4) NULL,
  `stockAct` DECIMAL(18,4) NULL,
  `costo` DECIMAL(18,4) NULL,
  `venta` DECIMAL(18,4) NULL,
  PRIMARY KEY (`id`));