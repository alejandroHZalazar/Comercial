CREATE DEFINER=`remoto`@`%` PROCEDURE `sp_ProductosCantMinimaPorProveedor`(in unProveedor int)
BEGIN

select 
p.codBarras
,p.codProveedor
,p.descripcion
,s.cantidad
,s.cantidadMinima
,c.costo
,s.cantidadMinima - s.cantidad + 1 as 'Pedido'
,p.id
from productos as p
inner join stockProductos as s on p.id = s.fk_producto
inner join costosProductos as c on p.id = c.fk_producto
where s.cantidad <= s.cantidadMinima;

END