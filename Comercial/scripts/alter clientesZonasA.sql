use pañalera;

ALTER TABLE `ClientesZonas` 
ADD COLUMN `baja` TINYINT(1) NULL AFTER `nombre`;