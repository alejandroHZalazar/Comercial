use pañalera;

CREATE TABLE `ordenCompraDetalle` (
  `linea` BIGINT(20) NOT NULL AUTO_INCREMENT,
  `fk_ordenCompra` BIGINT(20) NULL,
  `fk_producto` INT NULL,
  `codBarras` VARCHAR(45) NULL,
  `codProveedor` VARCHAR(45) NULL,
  `descripcion` VARCHAR(150) NULL,
  `costo` DECIMAL(18,4) NULL,
  `cantidad` DECIMAL(18,4) NULL,
  `subtotal` DECIMAL(18,4) NULL,
  PRIMARY KEY (`linea`));