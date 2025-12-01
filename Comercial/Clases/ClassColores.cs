using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Comercial.Clases
{
    class ClassColores
    {
        Clases.classDatos instDatos = new classDatos();

      
        public DataTable traerTodos()
        {
            MySqlDataAdapter rows = new MySqlDataAdapter("select id, nombre,color from colores", instDatos.abrirConexion());
            DataTable dt = new DataTable();
            rows.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        }

        public string  traerColor(string unNombre)
        {
            MySqlCommand nComando = new MySqlCommand("select color from colores where nombre = @nombre", instDatos.abrirConexion());
            nComando.Parameters.AddWithValue("@nombre", unNombre);
            string valor = nComando.ExecuteScalar().ToString();
            instDatos.cerrarConexion();
            return valor;
        }

        public string traerNombreColor(string unCodigo)
        {
            MySqlCommand nComando = new MySqlCommand("select nombre from colores where id = @codigo", instDatos.abrirConexion());
            nComando.Parameters.AddWithValue("@codigo", unCodigo );
            string valor = nComando.ExecuteScalar().ToString();
            instDatos.cerrarConexion();
            return valor;
        }

        public string traerColorPorCodigo(string unCodigo)
        {
            MySqlCommand nComando = new MySqlCommand("select color from colores where id = @codigo", instDatos.abrirConexion());
            nComando.Parameters.AddWithValue("@codigo", unCodigo);
            string valor = nComando.ExecuteScalar().ToString();
            instDatos.cerrarConexion();
            return valor;
        }

        public int traerCodigo (string unNombre)
        {
            MySqlCommand nComando = new MySqlCommand("select id from colores where nombre = @nombre", instDatos.abrirConexion());
            nComando.Parameters.AddWithValue("@nombre", unNombre);
            int valor = int.Parse(nComando.ExecuteScalar().ToString());
            instDatos.cerrarConexion();
            return valor;
        }
    }
}
