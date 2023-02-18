use pañalera;

ALTER TABLE `costosProductos` 
CHANGE COLUMN `costo` `costo` DECIMAL(18,4) NULL DEFAULT NULL ;

ALTER TABLE `ivaPorcentajes` 
CHANGE COLUMN `valor` `valor` DECIMAL(18,4) NULL DEFAULT NULL ;

ALTER TABLE `preciosProductos` 
CHANGE COLUMN `precio` `precio` DECIMAL(18,4) NULL DEFAULT NULL ;

ALTER TABLE `Proveedores` 
CHANGE COLUMN `ganancia` `ganancia` DECIMAL(18,4) NULL DEFAULT NULL ;

ALTER TABLE `stockProductos` 
CHANGE COLUMN `cantidad` `cantidad` DECIMAL(18,4) NULL DEFAULT NULL ,
CHANGE COLUMN `cantidadMinima` `cantidadMinima` DECIMAL(18,4) NULL DEFAULT NULL ;

ALTER TABLE `tipoPrecios` 
CHANGE COLUMN `valor` `valor` DECIMAL(18,4) NULL DEFAULT NULL ;

ALTER TABLE `ordenCompra` 
CHANGE COLUMN `id` `id` BIGINT(20) NOT NULL ;

