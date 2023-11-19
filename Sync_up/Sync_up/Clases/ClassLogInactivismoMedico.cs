using Sync_up.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sync_up.Clases
{
    class ClassLogInactivismoMedico
    {
        Datos instCon = new Datos();

        public DataTable traerAProcesar()
        {
            SqlDataAdapter a2 = new SqlDataAdapter("[pol].[sp_Inactivismo_Medico_Log_TraerAProcesar]", instCon.abrirConexion());
            a2.SelectCommand.CommandType = CommandType.StoredProcedure;
            a2.SelectCommand.CommandTimeout = 0;

            DataTable t2 = new DataTable();
            a2.Fill(t2);
            instCon.cerrarConexion();
            return t2;
        }

        public void mark_processed(int unLogId)
        {
            SqlCommand sqlCm = new SqlCommand("sp_logInactivismo_Medico_MarcarProcesado", instCon.abrirConexion());
            sqlCm.CommandType = CommandType.StoredProcedure;

            sqlCm.Parameters.AddWithValue("@idLog", unLogId);


            sqlCm.ExecuteNonQuery();
            instCon.cerrarConexion();
        }

        public async Task postProcess(int unId, int unFk_medico, DateTime unaFechaInicio, DateTime unaFechaFin, bool unTerminado, int unLogId)
        {
            ClassParameters instParameteres = new ClassParameters();


            string url = instParameteres.traerRuta("inactivismo_medico");
            string auth = instParameteres.traerAutenticacion();

            JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var httpClient = new HttpClient(clientHandler))
            {
                httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(auth);
                string val = System.Convert.ToBase64String(plainTextBytes);
                httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

                var response = await httpClient.PostAsJsonAsync(url, new Inactivismo_medico
                {
                    id = unId,
                    fk_medico = unFk_medico,
                    fecha_inicio = unaFechaInicio,
                    fecha_fin = unaFechaFin,
                    terminado = unTerminado
                }).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    mark_processed(unLogId);
                    Console.WriteLine(unFk_medico + " - Inactivismo Médico Agregada");
                }
                else
                {
                    Console.WriteLine(unFk_medico + " - Error en Post Inactivismo Médico. " + response.StatusCode);
                }
            }

        }

        public async Task putProcess(int unId, int unFk_medico, DateTime unaFechaInicio, DateTime unaFechaFin, bool unTerminado, int unLogId)
        {
            ClassParameters instParameteres = new ClassParameters();

            string url = instParameteres.traerRuta("inactivismo_medico");
            string auth = instParameteres.traerAutenticacion();

            url = url + "/" + unId;
            JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var httpClient = new HttpClient(clientHandler))
            {
                httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(auth);
                string val = System.Convert.ToBase64String(plainTextBytes);
                httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

                var response = await httpClient.PutAsJsonAsync(url, new Inactivismo_medico
                {
                    id = unId,
                    fk_medico = unFk_medico,
                    fecha_inicio = unaFechaInicio,
                    fecha_fin = unaFechaFin,
                    terminado = unTerminado
                }).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    mark_processed(unLogId);
                    Console.WriteLine(unFk_medico + " - Inactividad Médico Actualizada");
                }
                else
                {
                    Console.WriteLine(unFk_medico + " - Error en Update Inactividad Médico. " + response.StatusCode);
                }
            }           
        }

        public async Task DeleteProcess(long unId, int unFk_medico, int unIdLog)
        {
            ClassParameters instParameteres = new ClassParameters();

            string url = instParameteres.traerRuta("inactivismo_medico");
            string auth = instParameteres.traerAutenticacion();

            url = url + "/" + unId;
            JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var httpClient = new HttpClient(clientHandler))
            {
                httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(auth);
                string val = System.Convert.ToBase64String(plainTextBytes);
                httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

                var response = await httpClient.DeleteAsync(url).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    mark_processed(unIdLog);
                    Console.WriteLine(unFk_medico + " - Inactivismo Médico Eliminado");
                }
                else
                {
                    Console.WriteLine(unFk_medico + " - Error en Delete Inactivismo Médico. " + response.StatusCode);
                }
            }
        }
    }
}
