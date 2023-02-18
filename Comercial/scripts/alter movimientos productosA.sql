use pañalera;

ALTER TABLE `productosMovimientos` 
ADD COLUMN `cantidad` DECIMAL(18,4) NULL AFTER `venta`;