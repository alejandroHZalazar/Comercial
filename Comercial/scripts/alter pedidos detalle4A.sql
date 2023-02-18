ALTER TABLE `pañalera`.`pedidoDetalle` 
ADD COLUMN `precioConIva` DECIMAL(18,4) NULL AFTER `costo`,
CHANGE COLUMN `precio` `precioSinIva` DECIMAL(18,4) NULL DEFAULT NULL ;