using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercial.Clases
{
    class ClassLocalidades
    {
        classDatos instDatos = new classDatos();

        public DataTable traeLocalidades(int unaProvincia)
        {
            MySqlDataAdapter rows = new MySqlDataAdapter("select id,nombre from Localidades where baja = 0 and fk_provincia = " + unaProvincia + " order by nombre", instDatos.abrirConexion());
            DataTable dt = new DataTable();
            rows.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        }

        public DataTable traeProvincias()
        {
            MySqlDataAdapter rows = new MySqlDataAdapter("select * from Provincias where baja = 0 order by nombre" , instDatos.abrirConexion());
            DataTable dt = new DataTable();
            rows.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        }

        public DataTable traeLocalidadesPorId(int unId)
        {
            MySqlDataAdapter rows = new MySqlDataAdapter("select id,nombre,fk_Provincia from Localidades where id = " + unId , instDatos.abrirConexion());
            DataTable dt = new DataTable();
            rows.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        }

        public int ABMLocalidades(int unId, int unaProvincia, string unNombre, int unaAccion)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = instDatos.abrirConexion();
                cmd.CommandText = "sp_ConfiguracionABMlocalidades";

                cmd.Parameters.AddWithValue("unId", unId);
                cmd.Parameters.AddWithValue("unaProvincia", unaProvincia);
                cmd.Parameters.AddWithValue("unNombre", unNombre);
                cmd.Parameters.AddWithValue("unaAccion", unaAccion);

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

    }
}
