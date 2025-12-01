CREATE DEFINER=`remoto`@`%` PROCEDURE `sp_ProveedoresAltaCabeceraOrdenCompra`(in unProveedor int, in unTotal decimal(18,4), in unIva decimal(18,4),in unRecargo decimal(18,4), in unDescuento decimal(18,4), out salida bigint )
BEGIN

declare exit handler for sqlexception
begin
	set salida = -1;
	rollback;
end;

insert into ordenCompra (fecha,fk_proveedor,total,procesado,iva,recargo,descuento) values (now(),unProveedor,unTotal,0,unIva,unRecargo, unDescuento);

select max(id) into salida from ordenCompra;

commit;


END