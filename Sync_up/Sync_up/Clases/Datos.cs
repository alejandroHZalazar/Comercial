using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync_up.Clases
{
    public class Datos
    {
        public SqlConnection miConexion;
        string host = "", dbName = "", usuario = "", pass = "";

        public Datos()
        {
            StreamReader leer = new StreamReader((System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\login.env").Substring(6));

            int cont = 0;

            while (!leer.EndOfStream)
            {
                cont = cont + 1;

                switch (cont)
                {
                    case 1:
                        host = leer.ReadLine();
                        break;
                    case 2:
                        dbName = leer.ReadLine();
                        break;
                    case 3:
                        usuario = leer.ReadLine();
                        break;
                    case 4:
                        pass = leer.ReadLine();
                        break;

                    default:
                        break;
                }
            }


                miConexion = new SqlConnection(@"Data Source=" + host + ";Initial Catalog=" + dbName + ";Persist Security Info=True;User ID=" + usuario + ";Password=" + pass + ";MultipleActiveResultSets=True");//servidor produccion


            
        }

        public string cadenaConexion()
        {
            return miConexion.ConnectionString;
        }


        public SqlConnection abrirConexion()
        {
            try
            {
                miConexion.Open();
                return miConexion;
            }
            catch (Exception)
            {
                return miConexion;
            }
        }

        public void cerrarConexion()
        {
            miConexion.Close();
        }

    }


}
