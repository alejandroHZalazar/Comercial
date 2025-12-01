USE `pañalera`;
DROP procedure IF EXISTS `sp_PedidosAddDetalle`;

DELIMITER $$
USE `pañalera`$$
CREATE DEFINER=`remoto`@`%` PROCEDURE `sp_PedidosAddDetalle`(in unPedido int, in unProducto int, in unCodBarras varchar(45), in unCodProveedor varchar(45), in unaDescripcion varchar(150), in unPrecioSinIva decimal(18,4), in unPrecioConIva decimal(18,4), in unaCantidad decimal(18,4), in unSubtotal decimal(18,4), in unPrecioOrig decimal(18,4), in unCosto decimal(18,4), out salida int)
BEGIN

declare exit handler for sqlexception
begin

    DELETE FROM pedidos WHERE id= unPedido;
    delete from pedidoDetalle where fk_pedido = unPedido;
	set salida = -1;
	rollback;
end;

insert into pedidoDetalle (fk_pedido,fk_producto,codBarras,codProveedor,descripcion,precioSinIva,precioConIva,cantidad,subtotal,procesado,precioOrig,costo) values (unPedido, unProducto,unCodBarras,unCodProveedor,unaDescripcion,unPrecioSinIva,unPrecioConIva,unaCantidad,unSubtotal,0,unPrecioOrig,unCosto); 
set salida = unPedido;
commit;

END$$

DELIMITER ;
