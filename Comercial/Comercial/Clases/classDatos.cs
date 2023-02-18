using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercial.Clases
{
    class classDatos
    {
        MySqlConnection miCOnexion = new MySqlConnection("Server = 93.188.164.127; Database = pañalera; Uid = remoto; Password = 0315061");
        
        public MySqlConnection abrirConexion()
        {
            try
            {
                miCOnexion.Open();
                return miCOnexion;
            }
            catch (Exception)
            {
                return miCOnexion;
            }

         }

        public void cerrarConexion()
        {
            miCOnexion.Close();
        }
    }
}
