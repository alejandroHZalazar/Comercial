using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Comercial.Clases
{
    class classUsuarios
    {
        classDatos instDatos = new classDatos();

        public DataTable traerTodosUsuarios()
        {
            MySqlDataAdapter rows = new MySqlDataAdapter("select * from usuarios order by nombre", instDatos.abrirConexion());
            DataTable dt = new DataTable();
            rows.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        }

        public DataTable traerUsuariosActivos()
        {
            MySqlDataAdapter rows = new MySqlDataAdapter("select 0 as id ,'TODOS' as nombre,null,null,null union (select * from usuarios where baja = 0 order by nombre)", instDatos.abrirConexion());
            DataTable dt = new DataTable();
            rows.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        }

        public DataTable traerUsuario(string unNombre, string unPass)
        {
            MySqlDataAdapter rows = new MySqlDataAdapter("select * from usuarios where nombre = '" + unNombre + "' and password = '" + unPass +"'", instDatos.abrirConexion());
            DataTable dt = new DataTable();
            rows.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        }

        public DataTable traerVendedores()
        {
            MySqlDataAdapter rows = new MySqlDataAdapter("select id, nombre from usuarios where tipo in ( (select valor from parametros where modulo = 'configuracion' and parametro = 'vendedor'))", instDatos.abrirConexion());
            DataTable dt = new DataTable();
            rows.Fill(dt);
            instDatos.cerrarConexion();
            return dt;
        }

        public void obtenerUsuario(string unNombre, string unTipo, string unID)
        {
            Environment.SetEnvironmentVariable("nombreUser", unNombre);
            Environment.SetEnvironmentVariable("tipoUser", unTipo);
            Environment.SetEnvironmentVariable("idUser", unID);
        }

        public DataTable traerPermisosUsuario(int unIdUser)
        {
            MySqlDataAdapter a1 = new MySqlDataAdapter("sp_UsuariosTraerPermisos", instDatos.abrirConexion());
            a1.SelectCommand.CommandType = CommandType.StoredProcedure;
            a1.SelectCommand.Parameters.AddWithValue("unId", unIdUser);

            DataTable t2 = new DataTable();
            a1.Fill(t2);
            return t2;
        }

        static public void setPermisosMenu(int rol, System.Windows.Forms.Form unForm, System.Windows.Forms.MenuStrip menu)
        {
            
            classUsuarios instUser = new classUsuarios (); 
            DataTable permisos = instUser .traerPermisosUsuario  (rol);
            DataRow[] result;

            foreach (Control c in unForm.Controls)
            {
                if (c is MenuStrip)
                {
                    foreach (ToolStripMenuItem unMenu in menu.Items)
                    {
                        result = permisos .Select ("nombreControl = '" + unMenu.Name  + "'");

                        if (result.LongLength > 0) { unMenu.Visible = true; } else { unMenu.Visible = false; }

                        foreach (ToolStripMenuItem rama in unMenu.DropDownItems)
                        {
                            result = permisos.Select("nombreControl = '" + rama.Name + "'");
                            if (result.LongLength > 0) { rama.Visible = true; } else { rama.Visible = false; }

                            foreach (ToolStripMenuItem hoja in rama.DropDownItems)
                            {
                                result = permisos.Select("nombreControl = '" + hoja.Name + "'");
                                if (result.LongLength > 0) { hoja.Visible = true; } else { hoja.Visible = false; }
                            }
                        }
                    }
                }
            }
        }

    }
}
