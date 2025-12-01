using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Comercial.Clases
{
    

    class ClassPedidos
    {
        Clases.classDatos instDatos = new classDatos();


        public int pedidosAddCabecera(decimal unTotal, int unCliente, decimal unIva, decimal unRecargo, decimal unDescuento,int unVendedor, string  unaObserv)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = instDatos.abrirConexion();
                cmd.CommandText = "sp_PedidosAdd";

                cmd.Parameters.AddWithValue("unTotal", unTotal);
                cmd.Parameters.AddWithValue("unCliente", unCliente );
                cmd.Parameters.AddWithValue("unIva", unIva );
                cmd.Parameters.AddWithValue("unRecargo", unRecargo );
                cmd.Parameters.AddWithValue("unDescuento", unDescuento );
                cmd.Parameters.AddWithValue("unVendedor", unVendedor );
                cmd.Parameters.AddWithValue("unaObserv", unaObserv);

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

        public int pedidosAddDetalle(int unPedido, int unProducto, string unCodBarras, string  unCodProveedor, string unaDescripcion, decimal unPrecioSinIva,decimal unPrecioConIva, decimal unaCantidad, decimal unSubtotal,decimal unPrecioOrig,decimal unCosto,string unaObserv)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = instDatos.abrirConexion();
                cmd.CommandText = "sp_PedidosAddDetalle";

                cmd.Parameters.AddWithValue("unPedido", unPedido );
                cmd.Parameters.AddWithValue("unProducto", unProducto );
                cmd.Parameters.AddWithValue("unCodBarras", unCodBarras );
                cmd.Parameters.AddWithValue("unCodProveedor", unCodProveedor );
                cmd.Parameters.AddWithValue("unaDescripcion", unaDescripcion );
                cmd.Parameters.AddWithValue("unPrecioSinIva", unPrecioSinIva  );
                cmd.Parameters.AddWithValue("unPrecioConIva", unPrecioConIva );
                cmd.Parameters.AddWithValue("unaCantidad", unaCantidad );
                cmd.Parameters.AddWithValue("unSubtotal", unSubtotal );
                cmd.Parameters.AddWithValue("unPrecioOrig", unPrecioOrig);
                cmd.Parameters.AddWithValue("unCosto", unCosto);
                cmd.Parameters.AddWithValue("unaObserv", unaObserv);
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

        public int elimnarPedido(int unPedido)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = instDatos.abrirConexion();
                cmd.CommandText = "sp_pedidos_eliminarPedido";

                cmd.Parameters.AddWithValue("unPedido", unPedido);
               
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

        public DataTable traerCabeceraParaEditar (string unFiltro)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_pedidosTraerParaEditar", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unFiltro", unFiltro);

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public DataTable traerDetalleParaEditar(string unPedido)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_PedidosTraerDetalleParaEditar", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unPedido", unPedido);

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public DataTable traerCabeceraPendientes(string unFiltro)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_PedidosTraerPendientesCabecera", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unFiltro", unFiltro);

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public DataTable traerTodosPedidos(string unFiltro)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_PedidosTraerTodos", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unFiltro", unFiltro);

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public DataTable traerDetallePendientes(int unPedido)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_pedidosTraerPendientesDetalle", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unPedido", unPedido);

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

    

        public DataTable traerTodosDetalles(int unPedido)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_traerTodosDetalle", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unPedido", unPedido);

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public void marcarPedido(int unPedido, int unTipo)
        {
            MySqlCommand nComando = new MySqlCommand("sp_PedidosMarcarPedidos", instDatos.abrirConexion());
            nComando.CommandType = CommandType.StoredProcedure;

            nComando.Parameters.AddWithValue("@unPedido", unPedido);
            nComando.Parameters.AddWithValue("@unTipo", unTipo);

            nComando.ExecuteNonQuery();
            instDatos.cerrarConexion();
        }

        public void eliminarPedido(int unPedido)
        {
            MySqlCommand nComando = new MySqlCommand("sp_PedidosDelete", instDatos.abrirConexion());
            nComando.CommandType = CommandType.StoredProcedure;

            nComando.Parameters.AddWithValue("@unId", unPedido);
            

            nComando.ExecuteNonQuery();
            instDatos.cerrarConexion();
        }

        public int traerIdIVA(decimal unValor)
        {
            MySqlCommand nComando = new MySqlCommand("select id from ivaPorcentajes where valor = " + unValor .ToString ().Replace (',','.') , instDatos.abrirConexion());
            

            int valor = int.Parse (nComando.ExecuteScalar().ToString());

            instDatos.cerrarConexion();
            return valor;
        }
    }
}
