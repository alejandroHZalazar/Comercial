use pañalera;
CREATE DEFINER=`remoto`@`%` PROCEDURE `sp_ProveedoresTraerDetalleNotaPedido`( in unaNotaPedido bigint)
BEGIN

	select linea, fk_producto as 'id', codBarras as 'Cod_Barras', codProveedor as 'Cod_Proveedor',descripcion as 'Descripcion',costo as 'Costo s/IVA', convert(costo * (1+ o.iva/100),decimal(18,4)) as 'Costo c/IVA', cantidad as Cantidad,subtotal as 'Subtotal' from ordenCompraDetalle as d inner join ordenCompra as o on d.fk_ordenCompra = o.id where d.procesado = 0 and fk_ordenCompra = unaNotaPedido ;

END