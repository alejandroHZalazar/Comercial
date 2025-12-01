use pañalera;

ALTER TABLE `ordenCompra` 
ADD COLUMN `iva` DECIMAL(18,4) NULL AFTER `procesado`;