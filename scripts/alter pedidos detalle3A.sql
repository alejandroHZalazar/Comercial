use pañalera;

ALTER TABLE `pedidoDetalle` 
ADD COLUMN `costo` DECIMAL(18,4) NULL AFTER `precioOrig`;