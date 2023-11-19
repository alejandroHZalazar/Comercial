using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync_up.Clases
{
    class ClassParameters
    {
        Datos instCon = new Datos();
        public string traerAutenticacion()
        {
            SqlCommand nComando = new SqlCommand("Select valor from [dbo].[parametros] where [servicio] = 'APIMohemby' and [parametro] = 'Auth'",instCon.abrirConexion());
            string valor = nComando.ExecuteScalar().ToString();
            instCon.cerrarConexion();
            return valor;
        }

        public string traerRuta(string unModelo)
        {
            SqlCommand nComando = new SqlCommand("Select [routeController] from [dbo].[ModelsMohembyApi] where [tableName] = '" + unModelo + "'", instCon.abrirConexion());
            string valor = nComando.ExecuteScalar().ToString();
            instCon.cerrarConexion();
            return valor;
        }
    }
}
