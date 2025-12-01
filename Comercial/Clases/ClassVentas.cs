using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Comercial.Clases
{
    class ClassVentas
    {
        classDatos instDatos = new classDatos();

        public DataTable traerPedidosPendientes(string unFiltro)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_PedidosTraerPendientesCabecera", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unFiltro", unFiltro);

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public DataTable traerVentasParaDevolver(string unFiltro)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_Ventas_TraerParaDevolver", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unFiltro", unFiltro);

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public DataTable traerDetalleVentaADevolver(long unaVenta)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_Ventas_TraerParaDevolverDetalle", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unaVenta", unaVenta);

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public DataTable traerTodos (string unFiltro)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_Ventas", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unFiltro", unFiltro);

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public DataTable traerTodosDevolucion(string unFiltro)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_devoluciones", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unFiltro", unFiltro);

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public DataTable traerTodosDetalles(long unaVenta)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_VentasDetalles", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unaVenta", unaVenta );

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public DataTable traerTodosDetallesDevoluciones(long unaDev)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_DevolucionesDetalles", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unaDevolucion", unaDev);

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public long grabarCabeceraVenta (decimal unTotal, decimal unCosto, int unCliente, int unCajero, decimal unIva, decimal unDescuento, decimal unRecargo, int unVendedor, decimal comision, decimal unImpuesto)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = instDatos.abrirConexion();
                cmd.CommandText = "sp_VentasGrabarCabecera";

                cmd.Parameters.AddWithValue("unTotal", unTotal);
                cmd.Parameters.AddWithValue("unCosto", unCosto);
                cmd.Parameters.AddWithValue("unCliente", unCliente);
                cmd.Parameters.AddWithValue("unCajero", unCajero);
                cmd.Parameters.AddWithValue("unIva", unIva);
                cmd.Parameters.AddWithValue("unDescuento", unDescuento );
                cmd.Parameters.AddWithValue("unRecargo", unRecargo );
                cmd.Parameters.AddWithValue("unVendedor", unVendedor);
                cmd.Parameters.AddWithValue("unaComision", comision);
                cmd.Parameters.AddWithValue("unImpuesto", unImpuesto);

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

        public long grabarCabeceraDevolucion(decimal unTotal, decimal unCosto, int unCliente, int unCajero, decimal unIva, decimal unDescuento, decimal unRecargo, int unVendedor, decimal unaComision)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = instDatos.abrirConexion();
                cmd.CommandText = "sp_DevolucionGrabarCabecera";

                cmd.Parameters.AddWithValue("unTotal", unTotal);
                cmd.Parameters.AddWithValue("unCosto", unCosto);
                cmd.Parameters.AddWithValue("unCliente", unCliente);
                cmd.Parameters.AddWithValue("unCajero", unCajero);
                cmd.Parameters.AddWithValue("unIva", unIva);
                cmd.Parameters.AddWithValue("unDescuento", unDescuento);
                cmd.Parameters.AddWithValue("unRecargo", unRecargo);
                cmd.Parameters.AddWithValue("unVendedor", unVendedor);
                cmd.Parameters.AddWithValue("unaComision", unaComision);

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

        public decimal traerPrecioProductosVentas (int unTipo, int unProducto, int unPedido)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = instDatos.abrirConexion();
                cmd.CommandText = "sp_cambioPreciosVentas";
                cmd.Parameters.AddWithValue("tipo", unTipo );
                cmd.Parameters.AddWithValue("producto", unProducto);
                cmd.Parameters.AddWithValue("pedido", unPedido );
                MySqlParameter precio = new MySqlParameter("precioOut", MySqlDbType.Decimal);
                precio.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(precio);

                cmd.ExecuteScalar();
                decimal valor = decimal.Parse(cmd.Parameters["precioOut"].Value.ToString());
                return valor;
            }
            catch
            {
                return -1;
            }
        }

        public long grabarProcesoDetallVenta(long unaVenta, string  unDetalle)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = instDatos.abrirConexion();
                cmd.CommandText = "sp_VentasAddDetalle";

                cmd.Parameters.AddWithValue("unaVenta", unaVenta);
                cmd.Parameters.AddWithValue("detalle", unDetalle );
                

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

        public long grabarProcesoDetalleDevolucion(long unaDevolucion, string unDetalle)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = instDatos.abrirConexion();
                cmd.CommandText = "sp_DevolucionAddDetalle";
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue("unaDevolucion", unaDevolucion);
                cmd.Parameters.AddWithValue("detalle", unDetalle);


                MySqlParameter salida = new MySqlParameter("salida", MySqlDbType.Int64);
                salida.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(salida);

                cmd.ExecuteScalar();
                long valor = 0;
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

        public long ultimaVenta()
        {
            MySqlCommand nComando = new MySqlCommand("select MAX(id) from ventas", instDatos.abrirConexion());
            long valor = long.Parse(nComando.ExecuteScalar().ToString());
            instDatos.cerrarConexion();
            return valor;
        }


    }
}
