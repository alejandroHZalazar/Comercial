CREATE DEFINER=`remoto`@`%` PROCEDURE `sp_ClientesConsultaPpal`(in unFiltro varchar(1000))
BEGIN

set @consulta =  concat('select c.id as ''ID'', nombreComercial as ''Nombre_Comercial'',razonSocial as ''Razon_Social'' from Clientes as c  where c.baja = 0 ',unFiltro);

prepare sentencia from @consulta;

execute sentencia;

deallocate prepare sentencia;

END