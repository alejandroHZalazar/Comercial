CREATE DEFINER=`remoto`@`%` PROCEDURE `sp_ordenCompraDetalle`(in unaOrdenCompra bigint, in unProducto int, in unCodBarras varchar(45), in unCodProveedor varchar(45), in unaDescripcion varchar(150), in unCosto decimal(18,4),in unaCantidad decimal(18,4), unSubtotal decimal(18,4), out salida bigint )
BEGIN

declare exit handler for sqlexception
begin

    DELETE FROM ordenCompra WHERE id= unaOrdenCompra;
    delete from ordenCompraDetalle where fk_ordenCompra = unaOrdenCompra;
	set salida = -1;
	rollback;
end;

insert into ordenCompraDetalle (fk_ordenCompra,fk_producto,codBarras,codProveedor,descripcion,costo,cantidad,subtotal) values (unaOrdenCompra, unProducto,unCodBarras,unCodProveedor,unaDescripcion,unCosto,unaCantidad,unSubtotal); 
set salida = unaOrdenCompra;
commit;
END