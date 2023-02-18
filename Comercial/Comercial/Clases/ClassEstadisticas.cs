using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Comercial.Clases
{
   

    class ClassEstadisticas
    {
        Clases.classDatos instDatos = new classDatos();

        public DataTable traeEstadisticasVentas(string unFiltro, string unFiltroDev, int  unTipo)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_VentasBuscarEntreFechayFiltro", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unFiltro", unFiltro);
            a1.SelectCommand.Parameters.AddWithValue("unFiltroDev", unFiltroDev);
            a1.SelectCommand.Parameters.AddWithValue("tipo", unTipo);

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public DataTable traeEstadisticasVentasDetalle(long unaVenta)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_ventas_DetalleEstadistica", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unaVenta", unaVenta);

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public DataTable traerVentasRankingProductos(DateTime  desde, DateTime hasta)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_Ventas_RankingProductos", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("desde", desde);
            a1.SelectCommand.Parameters.AddWithValue("hasta", hasta);

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public DataTable traerVentasRankingClientes(DateTime  desde, DateTime hasta)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_Ventas_RankingClientes", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("desde", desde);
            a1.SelectCommand.Parameters.AddWithValue("hasta", hasta);

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }
    }
}
