use pañalera;

CREATE TABLE `pedidoDetalle` (
  `linea` BIGINT(20) NOT NULL,
  `fk_pedido` INT NULL,
  `pedidoDetallecol` VARCHAR(45) NULL,
  `fk_producto` INT NULL,
  `codBarras` VARCHAR(45) NULL,
  `codProveedor` VARCHAR(45) NULL,
  `descripcion` VARCHAR(150) NULL,
  `precio` DECIMAL(18,4) NULL,
  `cantidad` DECIMAL(18,4) NULL,
  `subtotal` DECIMAL(18,4) NULL,
  `procesado` TINYINT(1) NULL,
  `cantEntregada` DECIMAL(18,4) NULL,
  PRIMARY KEY (`linea`));
