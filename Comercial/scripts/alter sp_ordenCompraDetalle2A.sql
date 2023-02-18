USE `pañalera`;
DROP procedure IF EXISTS `sp_PedidosAddDetalle`;

DELIMITER $$
USE `pañalera`$$
CREATE DEFINER=`remoto`@`%` PROCEDURE `sp_PedidosAddDetalle`(in unPedido int, in unProducto int, in unCodBarras varchar(45), in unCodProveedor varchar(45), in unaDescripcion varchar(150), in unPrecio decimal(18,4), in unaCantidad decimal(18,4), in unSubtotal decimal(18,4), in precioOrig decimal(18,4), out salida int)
BEGIN

declare exit handler for sqlexception
begin

    DELETE FROM pedidos WHERE id= unPedido;
    delete from pedidoDetalle where fk_pedido = unPedido;
	set salida = -1;
	rollback;
end;

insert into pedidoDetalle (fk_pedido,fk_producto,codBarras,codProveedor,descripcion,precio,cantidad,subtotal,procesado) values (unPedido, unProducto,unCodBarras,unCodProveedor,unaDescripcion,unPrecio,unaCantidad,unSubtotal,0); 
set salida = unPedido;
commit;

END$$

DELIMITER ;