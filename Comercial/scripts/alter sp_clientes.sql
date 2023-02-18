USE `pañalera`;
DROP procedure IF EXISTS `sp_ClientesTraerTodos`;

DELIMITER $$
USE `pañalera`$$
CREATE DEFINER=`remoto`@`%` PROCEDURE `sp_ClientesTraerTodos`(in unCliente int)
BEGIN

select 
c.id
,nombreComercial
,razonSocial
,cuil
,direccion
,email
,telefono
,celular
,contacto
,fk_condIva
,fk_Vendedor
,I.descripcion
,u.nombre
,z.nombre as 'Zona'
,l.nombre as 'Localidad'
,p.nombre as 'Provincia'
,c.fk_zona
,c.fk_localidad
,l.fk_Provincia
from Clientes as c
inner join condIVA as I on c.fk_condIva = I.id
inner join usuarios as u on u.id = c.fk_Vendedor
inner join ClientesZonas as z on z.id = c.fk_zona
inner join Localidades as l on l.id = c.fk_localidad
inner join Provincias as p on p.id = l.fk_Provincia
where c.id = unCliente order by nombreComercial;
END$$

DELIMITER ;