CREATE DEFINER=`remoto`@`%` PROCEDURE `sp_ConfiguracionABMZonasClientes`(in unId int, in unNombre varchar(45), in unaAccion int)
BEGIN

if unaAccion = 1 then insert into ClientesZonas (nombre,baja) values (unNombre,0);
elseif unaAccion = 2 then update ClientesZonas set nombre = unNombre where id = unId;
else update ClientesZonas set baja = 1 where id = unId;
end if;




END