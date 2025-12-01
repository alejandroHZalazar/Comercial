using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercial.Clases
{
    class ClassClientes
    {
        Clases.classDatos instDatos = new classDatos();

        public DataTable traeClientesPpal(string unFiltro)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_ClientesConsultaPpal", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unFiltro", unFiltro);

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public DataTable buscarAVender()
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_clientesBuscarAVender", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
           

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public DataTable traerDatosVenta(string unFiltro)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_ClientesTraerDatosVentas", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unFiltro", unFiltro);

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public int traerFiltroDefecto()
        {
            MySqlCommand nComando = new MySqlCommand("select valor from parametros where modulo = 'clientes' and parametro = 'indiceBusqueda'", instDatos.abrirConexion());
            int valor = int.Parse(nComando.ExecuteScalar().ToString());
            instDatos.cerrarConexion();
            return valor;
        }

        public DataTable traerParaCombos()
        {
            MySqlDataAdapter nComando = new MySqlDataAdapter("select id, nombreComercial  from Clientes order by nombreComercial", instDatos.abrirConexion());
            DataTable dt = new DataTable();
            nComando.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        }

        public DataTable traerProvincias()
        {
            MySqlDataAdapter rows = new MySqlDataAdapter("select id, nombre from Provincias where baja = 0 order by nombre", instDatos.abrirConexion());
            DataTable dt = new DataTable();
            rows.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        }

        public DataTable traerZonas()
        {
            MySqlDataAdapter rows = new MySqlDataAdapter("select id, nombre from ClientesZonas where baja = 0 order by nombre", instDatos.abrirConexion());
            DataTable dt = new DataTable();
            rows.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        }

        public DataTable traerLocalidad(int unaProvincia)
        {
            MySqlDataAdapter rows = new MySqlDataAdapter("select id, nombre from Localidades where fk_Provincia = " + unaProvincia + " order by nombre", instDatos.abrirConexion());
            DataTable dt = new DataTable();
            rows.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        }

        public DataTable traerCondIVA()
        {
            MySqlDataAdapter rows = new MySqlDataAdapter("select * from condIVA", instDatos.abrirConexion());
            DataTable dt = new DataTable();
            rows.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        }

        public DataTable traeTodosDatos(int unCliente)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_ClientesTraerTodos", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unCliente", unCliente );

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public DataTable traerVendedores()
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_CLientesTraerVendedores", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            
            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        public int traerUltimoCliente()
        {
            MySqlCommand nComando = new MySqlCommand("select max(id) from Clientes", instDatos.abrirConexion());
            int valor = int.Parse(nComando.ExecuteScalar().ToString());
            instDatos.cerrarConexion();
            return valor;
        }


        public int ABMClientes(int unId, string unNombreComercial, string unaRazonSocial, string unCuil, string unaDireccion, string unEMail, string unTelefono, string unCelular, string unContacto, int unaCondIva, int unVendedor, int unaAccion,int unaZona, int unaLocaldiad)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = instDatos.abrirConexion();
                cmd.CommandText = "sp_ClientesABM";

                cmd.Parameters.AddWithValue("unId", unId );
                cmd.Parameters.AddWithValue("unNombreComercial", unNombreComercial );
                cmd.Parameters.AddWithValue("unaRazonSocial", unaRazonSocial );
                cmd.Parameters.AddWithValue("unCuil", unCuil);
                cmd.Parameters.AddWithValue("unaDireccion", unaDireccion );
                cmd.Parameters.AddWithValue("unEMail", unEMail );
                cmd.Parameters.AddWithValue("unTelefono", unTelefono );
                cmd.Parameters.AddWithValue("unCelular", unCelular);
                cmd.Parameters.AddWithValue("unContacto", unContacto );
                cmd.Parameters.AddWithValue("unaCondIva", unaCondIva );
                cmd.Parameters.AddWithValue("unVendedor", unVendedor );
                cmd.Parameters.AddWithValue("unaAccion", unaAccion );
                cmd.Parameters.AddWithValue("unaZona", unaZona );
                cmd.Parameters.AddWithValue("unaLocalidad", unaLocaldiad );
                

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
