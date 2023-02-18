use pañalera;

ALTER TABLE `Clientes` 
ADD COLUMN `fk_localdiad` INT NULL AFTER `baja`,
ADD COLUMN `fk_zona` INT NULL AFTER `fk_localdiad`;