CREATE DEFINER=`remoto`@`%` PROCEDURE `sp_ClientesABM`(in unId int, in unNombreComercial varchar(150), in unaRazonSocial varchar(150),in unCuil varchar(11),in unaDireccion varchar(150), in unEMail varchar(150), in unTelefono varchar(150), in unCelular varchar(150),in unContacto varchar(150), in unaCondIva int, in unVendedor int, in unaZona int, in unaLocalidad int, in unaAccion int, out salida int)
BEGIN

declare exit handler for sqlexception
begin
	set salida = -1;
	rollback;
end;

start transaction;	
if unaAccion = 1 then
	insert into Clientes (nombreComercial, razonSocial,cuil,direccion, email,telefono,celular,contacto,fk_condIva,fk_Vendedor,baja,fk_zona,fk_localidad) values (unNombreComercial,unaRazonSocial,unCuil,unaDireccion,unEMail,unTelefono,unCelular,unContacto,unaCondIva,unVendedor,0,unaZona,unaLocalidad);
    select max(id) into salida from Clientes; 
    
elseif unaAccion = 2 then
	update Clientes set nombreComercial = unNombreComercial, razonSocial = unaRazonSocial, cuil = unCuil, direccion = unaDireccion, email = unEMail, telefono = unTelefono, celular = unCelular,contacto = unContacto, fk_condIva = unaCondIva, fk_Vendedor = unVendedor,fk_zona = unaZona, fk_localidad = unaZona where id = unId;
	set salida = unId;
    
else
	update Clientes set baja = 1 where id = unId;
    set salida = unId;
end if;
   
commit;

END