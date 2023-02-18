USE `pañalera`;
DROP procedure IF EXISTS `sp_VentasPrint`;

DELIMITER $$
USE `pañalera`$$
CREATE DEFINER=`remoto`@`%` PROCEDURE `sp_VentasPrint`(in unaVenta bigint)
BEGIN

select lpad(v.id,8,0) as nroVenta,fecha,c.nombreComercial, CONCAT(c.direccion , '. ' ,l.nombre , ' - ', p.nombre) as 'Direccion' , d.codBarras, d.descripcion,d.precioConIVA,d.cantidad,d.subtotal,(select imagen from parametros where modulo = 'login' and parametro = 'imagen') as 'imagen'
from ventas as v
inner join Clientes as c on v.fk_cliente = c.id
inner join ventasDetalle as d on v.id = d.fk_venta
inner join Localidades as l on l.id = c.fk_localidad
inner join Provincias as p on p.id = l.fk_Provincia
where v.id = unaVenta;

END$$

DELIMITER ;