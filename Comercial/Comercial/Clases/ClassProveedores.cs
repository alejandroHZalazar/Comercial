using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Comercial.Clases
{
    class ClassProveedores
    {
        classDatos instDatos = new classDatos();

        public DataTable traeProveedores()
        {
            MySqlDataAdapter rows = new MySqlDataAdapter("select * from Proveedores order by nombreComercial", instDatos.abrirConexion());
            DataTable dt = new DataTable();
            rows.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        }

        public DataTable traerPedidosPendientes(string unFiltro)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_ProveedoresTraerNotaPedidoPendientes", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unFiltro", unFiltro );

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public DataTable traerListaProdAPedir(int unProveedor, DateTime unDesde, DateTime unHasta)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_ProveedoresListarProductosAPedir", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unProveedor", unProveedor );
            a1.SelectCommand.Parameters.AddWithValue("desde", unDesde );
            a1.SelectCommand.Parameters.AddWithValue("hasta", unHasta);
            a1.SelectCommand.CommandTimeout = 0;

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public DataTable traerCoeficientes (int unId)
        {
            MySqlDataAdapter rows = new MySqlDataAdapter("select ganancia, descuento from Proveedores where id = " + unId , instDatos.abrirConexion());
            DataTable dt = new DataTable();
            rows.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        }

        public string traerNombreProveedor (int unId)
        {
            classDatos datos = new classDatos();
            MySqlCommand nComando = new MySqlCommand("select nombreComercial from Proveedores where id = " + unId , datos.abrirConexion());
            string valor = nComando.ExecuteScalar().ToString();
            datos.cerrarConexion();
            return valor;
        }


        public DataTable traerDetallePedidosPendientes (long unaNorta)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_ProveedoresTraerDetalleNotaPedido", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unaNotaPedido", unaNorta );

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }



        public DataTable traeProveedoresPorId( string unId)
        {
            MySqlDataAdapter rows = new MySqlDataAdapter("select * from Proveedores where id = " + unId , instDatos.abrirConexion());
            DataTable dt = new DataTable();
            rows.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        }

        public DataTable traeProveedoresCabecera()
        {
            MySqlDataAdapter rows = new MySqlDataAdapter("select id as 'Cod', nombreComercial as 'Proveedor', direccion as 'Direccion' from Proveedores where baja = 0 order by nombreComercial", instDatos.abrirConexion());
            DataTable dt = new DataTable();
            rows.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        }

        public DataTable traePorcentajeIVA()
        {
            MySqlDataAdapter rows = new MySqlDataAdapter("select * from ivaPorcentajes", instDatos.abrirConexion());
            DataTable dt = new DataTable();
            rows.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        }

        public DataTable traerPorcentajeImpuestos()
        {
            MySqlDataAdapter rows = new MySqlDataAdapter("select * from impuestos", instDatos.abrirConexion());
            DataTable dt = new DataTable();
            rows.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        }

        public DataTable traerProductosProveedor (int unProveedor)
        {
            MySqlDataAdapter rows = new MySqlDataAdapter("select descripcion from Productos where baja = 0 and fk_proveedor = " + unProveedor , instDatos.abrirConexion());
            DataTable dt = new DataTable();
            rows.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        }

        public DataTable traeCantMinPorProveedor(int unProveedor)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_ProductosCantMinimaPorProveedor", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unProveedor", unProveedor );

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public long ABMProveedores(int unId, string unNombreComercial, string unCuil, string unaDireccion, string unEmail, string unTel, string unCel, decimal unaGanacia, int unAccion, decimal unDescuento)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = instDatos.abrirConexion();
                cmd.CommandText = "sp_ProveedoresABM";

                cmd.Parameters.AddWithValue("unId", unId );
                cmd.Parameters.AddWithValue("unNombreComercial", unNombreComercial );
                cmd.Parameters.AddWithValue("unCuil", unCuil );
                cmd.Parameters.AddWithValue("unaDireccion", unaDireccion );
                cmd.Parameters.AddWithValue("unEmail", unEmail);
                cmd.Parameters.AddWithValue("unTel", unTel );
                cmd.Parameters.AddWithValue("unCel", unCel );
                cmd.Parameters.AddWithValue("unaGanancia", unaGanacia );
                cmd.Parameters.AddWithValue("unaAccion", unAccion);
                cmd.Parameters.AddWithValue("unDescuento", unDescuento );

                MySqlParameter salida = new MySqlParameter("salida", MySqlDbType.Int64  );
                salida.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(salida);

                cmd.ExecuteScalar();
                long valor = long.Parse(cmd.Parameters["salida"].Value.ToString());
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

        public void marcarlineaNotaPedido (string unaLinea)
        {
            MySqlCommand nComando = new MySqlCommand("update ordenCompraDetalle set procesado = 1 where linea = " + unaLinea, instDatos.abrirConexion());
            nComando.ExecuteNonQuery();
            instDatos.cerrarConexion();
        }

        public void eliminarOrdenCompra(string unaOrden)
        {
            MySqlCommand nComando = new MySqlCommand("delete from ordenCompra where id = " + unaOrden, instDatos.abrirConexion());
            nComando.ExecuteNonQuery();
            instDatos.cerrarConexion();
        }

        public long insertOrdenCompraCabecera(int unProveedor, decimal unTotal, decimal unIva, decimal unRecargo, decimal unDescuento)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = instDatos.abrirConexion();
                cmd.CommandText = "sp_ProveedoresAltaCabeceraOrdenCompra";

                cmd.Parameters.AddWithValue("unProveedor", unProveedor );
                cmd.Parameters.AddWithValue("unTotal", unTotal);
                cmd.Parameters.AddWithValue("unIva", unIva );
                cmd.Parameters.AddWithValue("unRecargo", unRecargo );
                cmd.Parameters.AddWithValue("unDescuento", unDescuento);

                MySqlParameter salida = new MySqlParameter("salida", MySqlDbType.Int64);
                salida.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(salida);

                cmd.ExecuteScalar();
                long valor = long.Parse(cmd.Parameters["salida"].Value.ToString());
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


        public long insertOrdenCompraDetalle(long unaOrdenCompra, int unProducto, string unCodBarras, string unCodProveedor, string unaDescripcion, decimal unPrecioProveedor, decimal unaCantidad, decimal unSubtotal)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = instDatos.abrirConexion();
                cmd.CommandText = "sp_ordenCompraDetalle";

                cmd.Parameters.AddWithValue("unaOrdenCompra", unaOrdenCompra );
                cmd.Parameters.AddWithValue("unProducto", unProducto );
                cmd.Parameters.AddWithValue("unCodBarras", unCodBarras );
                cmd.Parameters.AddWithValue("unCodProveedor", unCodProveedor);
                cmd.Parameters.AddWithValue("unaDescripcion", unaDescripcion);
                cmd.Parameters.AddWithValue("unPrecioProveedor", unPrecioProveedor  );
                cmd.Parameters.AddWithValue("unaCantidad", unaCantidad );
                cmd.Parameters.AddWithValue("unSubtotal", unSubtotal);
                

                MySqlParameter salida = new MySqlParameter("salida", MySqlDbType.Int64);
                salida.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(salida);

                cmd.ExecuteScalar();
                long valor = long.Parse(cmd.Parameters["salida"].Value.ToString());
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

    }
}
