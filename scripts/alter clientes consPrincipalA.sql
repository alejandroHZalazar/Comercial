CREATE DEFINER=`remoto`@`%` PROCEDURE `sp_ClientesConsultaPpal`(in unFiltro varchar(1000))
BEGIN

set @consulta =  concat('select c.id as ''ID'', nombreComercial as ''Nombre_Comercial'',razonSocial as ''Razon_Social'',z.nombre as ''Zona'', l.nombre as ''Localidad'', p.nombre as ''Provincia'' from Clientes as c inner join ClientesZonas as z on z.id = c.fk_zona inner join Localidades as l on l.id = c.fk_localidad inner join Provincias as p on p.id = l.fk_Provincia  where c.baja = 0 ',unFiltro);

prepare sentencia from @consulta;

execute sentencia;

deallocate prepare sentencia;

END