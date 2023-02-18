USE `sistema`;
DROP procedure IF EXISTS `sp_ProveedoresTraerNotaPedidoPendientes`;

DELIMITER $$
USE `sistema`$$
CREATE DEFINER=`remoto`@`%` PROCEDURE `sp_ProveedoresTraerNotaPedidoPendientes`(in unFiltro varchar(1000))
BEGIN

set @consulta =  concat('select id,fecha,total,iva,recargo,descuento from ordenCompra  as o where exists (select * from ordenCompraDetalle where procesado = 0 and fk_ordenCompra = o.id) ',unFiltro);

prepare sentencia from @consulta;

execute sentencia;

deallocate prepare sentencia;

END$$

DELIMITER ;
