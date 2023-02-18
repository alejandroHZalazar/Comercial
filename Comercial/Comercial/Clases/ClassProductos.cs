using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Comercial.Clases
{
    class ClassProductos
    {
        classDatos instDatos = new classDatos();

        public DataTable traeProductosPpal (string unFiltro)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_ProductosConsultaPpal", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unFiltro", unFiltro );

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public DataTable traeParaCambiarPrecio(string unFiltro)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_ProductosTraerParaCambioPrecio", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unFiltro", unFiltro);

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public DataTable traeMovimientoProductos(string unFiltro)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_ProductosTraerMovimientos", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unFiltro", unFiltro);

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public DataTable traeProductosStock(string unFiltro)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_ProductosTraerStock", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unFiltro", unFiltro);

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public DataTable traerLotesIngreso(DateTime desde, DateTime hasta, string unComprobante, int unTipo)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_Productos_TraerLotesIngreso", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unTipo", unTipo );
            a1.SelectCommand.Parameters.AddWithValue("desde", desde);
            a1.SelectCommand.Parameters.AddWithValue("hasta", hasta);
            a1.SelectCommand.Parameters.AddWithValue("unComprobante", unComprobante);

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public int traerDefaultBusq()
        {
            MySqlCommand nComando = new MySqlCommand("select valor from parametros where modulo = 'productos' and parametro = 'indiceBusqueda'", instDatos.abrirConexion());
            int valor = int.Parse (nComando.ExecuteScalar().ToString());
            instDatos.cerrarConexion();
            return valor;
        }

       
        public static  int cantDecimales()
        {
            classDatos instDatos = new Clases.classDatos();
            MySqlCommand nComando = new MySqlCommand("select valor from parametros where modulo = 'productos' and parametro = 'decimales'", instDatos.abrirConexion());
            int valor = int.Parse(nComando.ExecuteScalar().ToString());
            instDatos.cerrarConexion();
            return valor;
        }

        public static int cantDecimalesStock()
        {
            classDatos instDatos = new Clases.classDatos();
            MySqlCommand nComando = new MySqlCommand("select valor from parametros where modulo = 'productos' and parametro = 'decimalesCant'", instDatos.abrirConexion());
            int valor = int.Parse(nComando.ExecuteScalar().ToString());
            instDatos.cerrarConexion();
            return valor;
        }


        public DataTable traerProductosParaEditar(int unProducto)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_ProductosTraerParaEditar", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unProducto", unProducto);

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public DataTable traerDetalleLoteIngreso(string unComprobante)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_Productos_TraerLotesIngresoDetalles", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unComprobante", unComprobante );

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public DataTable traerParaAjustar(string unFiltro)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_ProductosTraerpParaAjustar", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unFiltro", unFiltro);

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public decimal calcularPrecioLista(decimal unCosto, int unProveedor)
        {
            MySqlCommand nComando = new MySqlCommand("select ganancia from Proveedores where id = " + unProveedor  , instDatos.abrirConexion());
            decimal valor = decimal.Parse(nComando.ExecuteScalar().ToString());
            valor = Math.Round(unCosto * (1 + valor / 100), 2);
            instDatos.cerrarConexion();
            return valor;
        }

        public void agregarStock(string unProducto, decimal unaCantidad)
        {
            MySqlCommand nComando = new MySqlCommand("update stockProductos set cantidad = cantidad +" + unaCantidad.ToString ().Replace (',','.') + " where fk_producto = " + unProducto , instDatos.abrirConexion());
            nComando.ExecuteNonQuery();
            instDatos.cerrarConexion();
        }

        public void actualizarEstadoProducto(string unProducto, bool  baja)
        {
            MySqlCommand nComando = new MySqlCommand("update Productos set baja = " + baja.ToString () + " where id = " + unProducto, instDatos.abrirConexion());
            nComando.ExecuteNonQuery();
            instDatos.cerrarConexion();
        }

        public void actualziarMasivaPrecios (string unProducto, decimal unPrecio)
        {
            MySqlCommand nComando = new MySqlCommand("sp_Productos_CambiarPreciosMasivos", instDatos.abrirConexion());
            nComando.CommandType = CommandType.StoredProcedure;

            nComando.Parameters.AddWithValue("@unProducto", unProducto);
            nComando.Parameters.AddWithValue("@unPrecio", unPrecio);
            
            nComando.ExecuteNonQuery();
            instDatos.cerrarConexion();
        }

        public void actualizarPrecios (int unProducto, decimal unPrecio, decimal unCosto, decimal unPrecioProv)
        {
            MySqlCommand nComando = new MySqlCommand("sp_productosActualizarPrecios", instDatos.abrirConexion());
            nComando.CommandType = CommandType.StoredProcedure;

            nComando.Parameters.AddWithValue("@unProducto", unProducto);
            nComando.Parameters.AddWithValue("@unPrecio", unPrecio );
            nComando.Parameters.AddWithValue("@unCosto", unCosto);
            nComando.Parameters.AddWithValue("@unPrecioProv", unPrecioProv );

            nComando.ExecuteNonQuery();
            instDatos.cerrarConexion();
        }


        public void ajustarStock(int unProducto, decimal unStock, decimal unaDif)
        {
            MySqlCommand nComando = new MySqlCommand("sp_Productos_AjusteStock", instDatos.abrirConexion());
            nComando.CommandType = CommandType.StoredProcedure;

            nComando.Parameters.AddWithValue("@unIdProducto", unProducto);
            nComando.Parameters.AddWithValue("@unStock", unStock);
            nComando.Parameters.AddWithValue("@unaDif", unaDif );
            

            nComando.ExecuteNonQuery();
            instDatos.cerrarConexion();
        }


        public void registrarMovimiento(string unProducto, int unTipoMov, string unaDesc, decimal unStockAnt, decimal unStockAct, decimal unCosto, decimal unaVenta, decimal unaCantidad,DateTime unaFecha,string unComprobante, decimal unPrecioProveedor)
            
        {
            MySqlCommand nComando = new MySqlCommand("insert into productosMovimientos (fk_producto, tipoMovimiento, descripcion, stockAnt, stockAct, costo, venta,cantidad,fechaEntrega,nroComprobante,precio_Proveedor,fechaMov) values (@producto,@movimiento,@descripcion,@stockAnt,@stockAct,@costo,@venta,@cantidad,@fecha,@comprobante,@precioProveedor,@fechaMov)", instDatos.abrirConexion());

            nComando.Parameters.AddWithValue("@producto", unProducto);
            nComando.Parameters.AddWithValue("@movimiento", unTipoMov );
            nComando.Parameters.AddWithValue("@descripcion", unaDesc);
            nComando.Parameters.AddWithValue("@stockAnt", unStockAnt );
            nComando.Parameters.AddWithValue("@stockAct", unStockAct );
            nComando.Parameters.AddWithValue("@costo", unCosto );
            nComando.Parameters.AddWithValue("@venta", unaVenta );
            nComando.Parameters.AddWithValue("@cantidad", unaCantidad );
            nComando.Parameters.AddWithValue("@fecha", unaFecha);
            nComando.Parameters.AddWithValue("@comprobante", unComprobante);
            nComando.Parameters.AddWithValue("@precioProveedor", unPrecioProveedor);
            nComando.Parameters.AddWithValue("@fechaMov", DateTime.Now);

            nComando.ExecuteNonQuery();
            instDatos.cerrarConexion();
        }

        public int ABMProductos(string unCodProveedor, string unCodBarras, int unRubro,string unaDescripcion, int unProveedor, decimal unCosto, decimal unPrecio,decimal unStock, decimal unaCantMinima, int unaAccion, int unProducto, decimal unPrecioProveedor)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = instDatos.abrirConexion();
                cmd.CommandText = "sp_ProductosABM";

                cmd.Parameters.AddWithValue("unCodProveedor", unCodProveedor );
                cmd.Parameters.AddWithValue("unCodBarras", unCodBarras );
                cmd.Parameters.AddWithValue("unRubro", unRubro );
                cmd.Parameters.AddWithValue("unaDescripcion", unaDescripcion );
                cmd.Parameters.AddWithValue("unProveedor", unProveedor );
                cmd.Parameters.AddWithValue("unCosto", unCosto );
                cmd.Parameters.AddWithValue("unPrecio", unPrecio );
                cmd.Parameters.AddWithValue("unStock", unStock  );
                cmd.Parameters.AddWithValue("unaCMinima", unaCantMinima );
                cmd.Parameters.AddWithValue("unaAccion", unaAccion );
                cmd.Parameters.AddWithValue("unProducto", unProducto );
                cmd.Parameters.AddWithValue("unPrecioProveedor", unPrecioProveedor);


                MySqlParameter salida = new MySqlParameter("salida", MySqlDbType.Int32);
                salida.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(salida);

                cmd.ExecuteScalar();
                int valor = Int32.Parse(cmd.Parameters["salida"].Value.ToString());
                return valor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                instDatos.cerrarConexion();
            }
        }

        public DataTable traerProductosProveedores()
        {
            MySqlDataAdapter rows = new MySqlDataAdapter("select p.codProveedor, ppr.precio * 1.10 from Productos as p inner join preciosProveedores as ppr on ppr.fk_producto = p.id where p.fk_proveedor = 7 and p.id > 385 order by p.id", instDatos.abrirConexion());
            DataTable dt = new DataTable();
            rows.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        }

    }
}
