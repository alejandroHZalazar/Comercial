USE `pañalera`;
DROP procedure IF EXISTS `sp_PedidosTraerPendientesCabecera`;

DELIMITER $$
USE `pañalera`$$
CREATE DEFINER=`remoto`@`%` PROCEDURE `sp_PedidosTraerPendientesCabecera`(in unFiltro varchar(1000))
BEGIN

set @consulta =  concat('select distinct p.id, Fecha, c.nombreComercial as ''Cliente'', IVA,Recargo, Descuento,u.nombre ''Vendedor'',total from pedidos as p inner join Clientes as c on p.fk_cliente = c.id inner join usuarios as u on u.id = p.fk_vendedor where exists (select * from pedidoDetalle where fk_pedido = p.id and procesado = 0 ) ' , unFiltro);

prepare sentencia from @consulta;

execute sentencia;

deallocate prepare sentencia ;

END$$

DELIMITER ;
