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
    class ClassLogMedicoEspecialidad
    {
        Datos instCon = new Datos();
        public DataTable traerAProcesar()
        {
            SqlDataAdapter a2 = new SqlDataAdapter("[pol].[sp_medico_especialidad_Log_TraerAProcesar]", instCon.abrirConexion());
            a2.SelectCommand.CommandType = CommandType.StoredProcedure;
            a2.SelectCommand.CommandTimeout = 0;

            DataTable t2 = new DataTable();
            a2.Fill(t2);
            instCon.cerrarConexion();
            return t2;
        }

        public void mark_processed(int unLogId)
        {
            SqlCommand sqlCm = new SqlCommand("sp_logMedico_especialidad_MarcarProcesado", instCon.abrirConexion());
            sqlCm.CommandType = CommandType.StoredProcedure;

            sqlCm.Parameters.AddWithValue("@idLog", unLogId);


            sqlCm.ExecuteNonQuery();
            instCon.cerrarConexion();
        }

        public async Task postProcess(int unId, long unFk_medico, long unFK_especialidad, int unLogId)
        {
            ClassParameters instParameteres = new ClassParameters();


            string url = instParameteres.traerRuta("Medico_especialidad");
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


                var response = await httpClient.PostAsJsonAsync(url, new Medico_especialidad
                {
                    id = unId,
                    fk_medico = unFk_medico,
                    fk_especialidad = unFK_especialidad                   
                }).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    mark_processed(unLogId);
                    Console.WriteLine(unFk_medico + " - Medico_Especialidad Agregada");
                }
                else
                {
                    Console.WriteLine(unFk_medico + " - Error en Post Medico_Especialidad. " + response.StatusCode);
                }
            }
        }
        public async Task putProcess(int unId, long unFk_medico, long unFK_especialidad, int unLogId)
        {

            ClassParameters instParameteres = new ClassParameters();

            string url = instParameteres.traerRuta("Medico_especialidad");
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

                var response = await httpClient.PutAsJsonAsync(url, new Medico_especialidad
                {
                    id = unId,
                    fk_medico = unFk_medico,
                    fk_especialidad = unFK_especialidad
                }).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    mark_processed(unLogId);
                    Console.WriteLine(unFk_medico + " - Medico_especialidad Actualizado");
                }
                else
                {
                    Console.WriteLine(unFk_medico + " - Error en Update Medico_especialidad. " + response.StatusCode);
                }
            }
        }
        public async Task DeleteProcess(long unId, long unFk_medico, int unIdLog)
        {
            ClassParameters instParameteres = new ClassParameters();


            string url = instParameteres.traerRuta("Medico_especialidad");
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
                    Console.WriteLine(unFk_medico + " - Medico_especialidad Eliminado");
                }
                else
                {
                    Console.WriteLine(unFk_medico + " - Error en Delete Medico_especialidad. " + response.StatusCode);
                }
            }
        }
    }
}
