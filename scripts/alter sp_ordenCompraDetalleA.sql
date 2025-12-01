USE `pañalera`;
DROP procedure IF EXISTS `sp_ProveedoresTraerDetalleNotaPedido`;

DELIMITER $$
USE `pañalera`$$
CREATE DEFINER=`remoto`@`%` PROCEDURE `sp_ProveedoresTraerDetalleNotaPedido`( in unaNotaPedido bigint)
BEGIN

	select linea, d.fk_producto as 'id', codBarras as 'Cod_Barras', codProveedor as 'Cod_Proveedor',descripcion as 'Descripcion',costo as 'Costo s/IVA', convert(costo * (1+ o.iva/100),decimal(18,4)) as 'Costo c/IVA', d.cantidad as Cantidad,subtotal as 'Subtotal', s.cantidad as 'Stock',s.cantidadMinima as 'C_Min'
    from ordenCompraDetalle as d 
    inner join ordenCompra as o on d.fk_ordenCompra = o.id 
    inner join stockProductos as s on s.fk_producto = d.fk_producto
    where d.procesado = 0 and fk_ordenCompra = unaNotaPedido ;

END$$

DELIMITER ;