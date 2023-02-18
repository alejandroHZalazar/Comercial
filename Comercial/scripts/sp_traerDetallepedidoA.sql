USE `pañalera`;
DROP procedure IF EXISTS `sp_pedidosTraerPendientesDetalle`;

DELIMITER $$
USE `pañalera`$$
CREATE DEFINER=`remoto`@`%` PROCEDURE `sp_pedidosTraerPendientesDetalle`(in unPedido int)
BEGIN
select linea, fk_pedido,d.fk_producto,codBarras as 'Cod_Barras',codProveedor as 'Cod_Proveedor',Descripcion,s.cantidad as 'Stock',Precio,d.Cantidad,Subtotal,precioOrig
from pedidoDetalle as d
inner join stockProductos as s on s.fk_producto = d.fk_producto
 where fk_pedido = unPedido and procesado = 0;
END$$

DELIMITER ;
