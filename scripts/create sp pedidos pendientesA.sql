USE `pañalera`;
DROP procedure IF EXISTS `sp_PedidosTraerPendientesCabecera`;

DELIMITER $$
USE `pañalera`$$
CREATE PROCEDURE `sp_PedidosTraerPendientesCabecera` (in unFiltro varchar(1000))
BEGIN

set @consulta =  concat('select distinct id, total, fecha, c.nombreComercial as ''Cliente'', iva,recargo, descuento,u.nombre from pedidos as p inner join clientes as c on p.fk_cliente = c.idr inner join usuarios as u on u.id = p.fk_vendedor where exists (select * from pedidoDetalle where fk_pedido = p.id and procesado = 0 ) ' , unFiltro);

prepare sentencia from @consulta;

execute sentencia;

deallocate prepare sentencia;

END$$

DELIMITER ;