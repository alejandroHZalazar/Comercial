USE `pañalera`;
DROP procedure IF EXISTS `sp_VentasGrabarCabecera`;

DELIMITER $$
USE `pañalera`$$
CREATE DEFINER=`remoto`@`%` PROCEDURE `sp_VentasGrabarCabecera`(in unTotal decimal(18,4),in unCosto decimal(18,4), in unCliente int, in unCajero int, in unIva decimal(18,4), out salida bigint)
BEGIN
declare exit handler for sqlexception
begin
	set salida = -1;
	rollback;
end;

insert into ventas (totalVenta, totalCosto,fk_cliente,fk_cajero,IVA,fecha) values (unTotal,unCosto,unCliente,unCajero,unIva,now());

select max(id) into salida from ventas;

commit;


END$$

DELIMITER ;
