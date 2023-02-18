
CREATE DEFINER=`remoto`@`%` PROCEDURE `sp_ConfiguracionABMlocalidades`(in unId int, in unaProvincia int,in unNombre varchar(150), in unaAccion int, out salida int )
BEGIN

declare exit handler for sqlexception
begin
 set salida = -1;
 rollback;
end;

start transaction;

if unaAccion = 1 then
	insert into Localidades (fk_Provincia,nombre,baja) Values (unaProvincia,unNombre,0);
    select Max(id) into salida from Localidades;

elseif unaAccion = 2 then 
	update Localidades set fk_Provincia = unaProvincia, nombre = unNombre where id = unId;
    set salida = unId;

else
	update Localidades set baja = 1 where id = unId;
    set salida = unId;
end if;

commit;
END