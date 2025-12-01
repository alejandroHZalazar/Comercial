USE `pañalera`;
DROP procedure IF EXISTS `sp_PedidosAdd`;

DELIMITER $$
USE `pañalera`$$
CREATE DEFINER=`remoto`@`%` PROCEDURE `sp_PedidosAdd`(in unTotal decimal(18,4), in unCliente int, in unIva decimal(18,4), in unRecargo decimal(18,4), in unDescuento decimal(18,4), out salida int )
BEGIN

declare exit handler for sqlexception
begin

    set salida = -1;
	rollback;
end;

insert into pedidos (total, fecha, fk_cliente, iva, recargo,descuento) values (unTotal, now(), unCliente, unIva, unRecargo, unDescuento);

select max(id) into salida from pedidos; 

commit;

END$$

DELIMITER ;
