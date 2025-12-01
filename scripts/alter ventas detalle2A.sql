use pañalera;

ALTER TABLE `ventasDetalle` 
ADD COLUMN `precioConIva` DECIMAL(18,4) NULL AFTER `precioSinIva`,
CHANGE COLUMN `cantidad` `cantidad` DECIMAL(18,4) NULL DEFAULT NULL AFTER `precioConIva`,
CHANGE COLUMN `precio` `precioSinIva` DECIMAL(18,4) NULL DEFAULT NULL ;