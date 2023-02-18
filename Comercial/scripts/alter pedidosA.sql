use pañalera;

ALTER TABLE `pedidos` 
ADD COLUMN `fk_vendedor` INT NULL AFTER `descuento`;