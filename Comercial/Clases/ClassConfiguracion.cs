using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercial.Clases
{
    class ClassConfiguracion
    {
        classDatos instDatos = new classDatos();

        public DataTable traeCondIVA()                         
        {
            MySqlDataAdapter rows = new MySqlDataAdapter("select * from condIVA", instDatos.abrirConexion());
            DataTable dt = new DataTable();
            rows.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        }

        public DataTable traePorcentajesIva()
        {
            MySqlDataAdapter rows = new MySqlDataAdapter("select * from ivaPorcentajes", instDatos.abrirConexion());
            DataTable dt = new DataTable();
            rows.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        }

        public DataTable traeZonasClientes()
        {
            MySqlDataAdapter rows = new MySqlDataAdapter("select id,nombre from ClientesZonas where baja = 0 order by nombre", instDatos.abrirConexion());
            DataTable dt = new DataTable();
            rows.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        }

        public DataTable traeRubros()
        {
            MySqlDataAdapter rows = new MySqlDataAdapter("select * from Rubros", instDatos.abrirConexion());
            DataTable dt = new DataTable();
            rows.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        }

        public DataTable traeTipoUsuarios()
        {
            MySqlDataAdapter rows = new MySqlDataAdapter("select * from tipoUsuarios order by id", instDatos.abrirConexion());
            DataTable dt = new DataTable();
            rows.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        }

        public DataTable traeTipoPrecios()
        {
            MySqlDataAdapter rows = new MySqlDataAdapter("select t.id, t.descripcion,v.descripcion as 'Tipo',t.valor,t.fk_tipoValor from tipoPrecios as t inner join tipoValoresPrecios as v on v.id = t.fk_tipoValor" , instDatos.abrirConexion());
            DataTable dt = new DataTable();
            rows.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        }

        public DataTable traeUsuarios()
        {
            MySqlDataAdapter rows = new MySqlDataAdapter("select u.id, u.nombre,t.descripcion, u.tipo from usuarios as u inner join tipoUsuarios as t on u.tipo = t.id where u.baja = 0 ", instDatos.abrirConexion());
            DataTable dt = new DataTable();
            rows.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        }

        public DataTable traerMenuPermisos()
        {
            MySqlDataAdapter rows = new MySqlDataAdapter("select * from menuPermisos order by id", instDatos.abrirConexion());
            DataTable dt = new DataTable();
            rows.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        }

        public DataTable traerTipoUsuariosPermisos(int unTipoUsuario)
        {
            MySqlDataAdapter rows = new MySqlDataAdapter("select * from tipoDeUsuariosPermisos where fk_tipoUsuario = " + unTipoUsuario  , instDatos.abrirConexion());
            DataTable dt = new DataTable();
            rows.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        } 

        public void ABMcondIva(string unaDescripcion, string unaAbrev, string unaLetra, int unId, int unTipo)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = instDatos.abrirConexion();
                cmd.CommandText = "sp_ConfiguracionABMcondIva";

                cmd.Parameters.AddWithValue("unaDescripcion", unaDescripcion);
                cmd.Parameters.AddWithValue("unaAbrev", unaAbrev );
                cmd.Parameters.AddWithValue("unaLetra", unaLetra );
                cmd.Parameters.AddWithValue("unId", unId );
                cmd.Parameters.AddWithValue("tipo", unTipo );

                cmd.ExecuteNonQuery();
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

        public void ABMZonasClientes(int unId, string unNombre, int unaAccion)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = instDatos.abrirConexion();
                cmd.CommandText = "sp_ConfiguracionABMZonasClientes";

                cmd.Parameters.AddWithValue("unId", unId );
                cmd.Parameters.AddWithValue("unNombre", unNombre );
                cmd.Parameters.AddWithValue("unaAccion", unaAccion );
                

                cmd.ExecuteNonQuery();
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



        public void ABMPorcentajeIva(int unId, int unTipo, decimal unValor)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = instDatos.abrirConexion();
                cmd.CommandText = "sp_ConfiguracionABMporcentajeIva";

                cmd.Parameters.AddWithValue("unId", unId );
                cmd.Parameters.AddWithValue("unTipo", unTipo );
                cmd.Parameters.AddWithValue("unValor", unValor );
                
                cmd.ExecuteNonQuery();
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

        public DataTable traetipoValoresPrecios()
        {
            MySqlDataAdapter rows = new MySqlDataAdapter("select * from tipoValoresPrecios", instDatos.abrirConexion());
            DataTable dt = new DataTable();
            rows.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        }

        public void ABMRubros(int unId, int unTipo, string unaDescripcion)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = instDatos.abrirConexion();
                cmd.CommandText = "sp_ConfiguracionABMrubros";

                cmd.Parameters.AddWithValue("unId", unId);
                cmd.Parameters.AddWithValue("unTipo", unTipo);
                cmd.Parameters.AddWithValue("unaDescripcion", unaDescripcion );

                cmd.ExecuteNonQuery();
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

        public void ABMTipoPrecios(string unaDescrpcion, int unTipoValor, decimal unValor, int unTipo, int unId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = instDatos.abrirConexion();
                cmd.CommandText = "sp_ConfiguracionABMtipoPrecios";

                cmd.Parameters.AddWithValue("unaDescripcion", unaDescrpcion );
                cmd.Parameters.AddWithValue("unTipoValor", unTipoValor );
                cmd.Parameters.AddWithValue("unValor", unValor );
                cmd.Parameters.AddWithValue("unTipo", unTipo );
                cmd.Parameters.AddWithValue("unId", unId);

                cmd.ExecuteNonQuery();
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

        public void ABMUsuarios(int unID,string unNombre, string unPass, int unTipo, int unaAccion)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = instDatos.abrirConexion();
                cmd.CommandText = "sp_ConfiguracionABMUsuarios";

                cmd.Parameters.AddWithValue("unId", unID);
                cmd.Parameters.AddWithValue("unNombre", unNombre );
                cmd.Parameters.AddWithValue("unPass", unPass );
                cmd.Parameters.AddWithValue("unTipo", unTipo );
                cmd.Parameters.AddWithValue("unaAccion", unaAccion );
                

                cmd.ExecuteNonQuery();
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

        public int ABMtipoUsuarios(string unaDescrpcion, int unId,  int unTipo, string permisos)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = instDatos.abrirConexion();
                cmd.CommandText = "sp_ConfiguracionABMtipoUsuarios";

                cmd.Parameters.AddWithValue("unaDescripcion", unaDescrpcion);
                cmd.Parameters.AddWithValue("unTipo", unTipo);
                cmd.Parameters.AddWithValue("unId", unId);
                cmd.Parameters.AddWithValue("permisos", permisos);

                MySqlParameter salida = new MySqlParameter("salida",MySqlDbType.Int32 );
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
