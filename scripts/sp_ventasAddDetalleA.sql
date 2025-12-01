USE `pañalera`;
DROP procedure IF EXISTS `sp_VentasAddDetalle`;

DELIMITER $$
USE `pañalera`$$
CREATE DEFINER=`remoto`@`%` PROCEDURE `sp_VentasAddDetalle`(in unaVenta bigint, in detalle varchar(4000), out salida bigint)
BEGIN

declare pos int;
declare producto int;
declare precioSinIva decimal(18,4);
declare precioConIva decimal(18,4);
declare cantidad decimal(18,4);
declare pedido bigint;


declare exit handler for sqlexception
	begin
    delete from ventas where id = unaVenta;
	set salida = -1;
	rollback;
end;


start transaction;
	while detalle <> "" do
		select locate('#',detalle) into pos;
        select substring(detalle,1,pos-1) into producto;
        select substring(detalle,pos+1,LENGTH(detalle) - pos) into detalle;
        
        select locate('*',detalle) into pos;
        select substring(detalle,1,pos-1) into precioSinIva;
        select substring(detalle,pos+1,LENGTH(detalle) - pos) into detalle;
        
        select locate('!',detalle) into pos;
        select substring(detalle,1,pos-1) into precioConIva;
        select substring(detalle,pos+1,LENGTH(detalle) - pos) into detalle;
        
        select locate('?',detalle) into pos;
        select substring(detalle,1,pos-1) into cantidad;
        select substring(detalle,pos+1,LENGTH(detalle) - pos) into detalle;
        
        select locate(';',detalle) into pos;
        select substring(detalle,1,pos-1) into pedido;
        select substring(detalle,pos+1,LENGTH(detalle) - pos) into detalle;
        
        #------------------------------------------------------------------------------------
        
        #insertamos detalle de venta
        insert into ventasDetalle (fk_venta,fk_producto,codBarras,codProveedor,descripcion,precioSinIva,precioConIva,cantidad,costo,subtotal)
        values (
        unaVenta
        ,producto
        ,(select codBarras from Productos where id = producto )
        ,(select codProveedor from Productos where id = producto )
        ,(select descripcion from Productos where id = producto )
        ,precioSinIva
        ,precioConIva
        ,cantidad
        ,(cantidad  * (select costo from costosProductos where fk_producto = producto))
        ,(cantidad  * precioConIva )
        );
		
        #descontamos stock
        SET SQL_SAFE_UPDATES=0;
        update stockProductos s set s.cantidad = s.cantidad -  cantidad where fk_producto = producto;
        
        #insertamos movimientos
        insert into productosMovimientos (fk_producto, tipoMovimiento, descripcion,stockAnt,stockAct,costo,venta,cantidad) 
        values (
         producto
        ,3
        ,(select descripcion from Productos where id = producto )
        ,(select s.cantidad + cantidad from stockProductos s where fk_producto = producto ) 
        ,(select s.cantidad from stockProductos s where fk_producto = producto )
        ,(cantidad * (select costo from costosProductos where fk_producto = producto))
        ,(cantidad *  precioConIva )
        ,(cantidad)
        );
        
      #ProcesoPedidos
        if pedido <> 0 then
			
            update pedidoDetalle set procesado = 1, cantEntregada = cantidad where fk_pedido = pedido and fk_producto = producto;
        
        end if;
        
		
    end while;
    
   commit;
    
    set salida = unaVenta;
END$$

DELIMITER ;
