use pañalera;

ALTER TABLE `pedidoDetalle` 
ADD COLUMN `precioOrig` DECIMAL(18,4) NULL AFTER `cantEntregada`;