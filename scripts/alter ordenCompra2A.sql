USE pañalera;

ALTER TABLE `ordenCompra` 
ADD COLUMN `recargo` DECIMAL(18,4) NULL AFTER `iva`,
ADD COLUMN `descuento` DECIMAL(18,4) NULL AFTER `recargo`;
