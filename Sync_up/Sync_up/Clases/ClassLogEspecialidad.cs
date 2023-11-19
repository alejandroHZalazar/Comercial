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
    class ClassLogEspecialidad
    {
        Datos instCon = new Datos();

        public DataTable traerAProcesar()
        {
            SqlDataAdapter a2 = new SqlDataAdapter("[pol].[sp_especialidad_Log_TraerAProcesar]", instCon.abrirConexion());
            a2.SelectCommand.CommandType = CommandType.StoredProcedure;
            a2.SelectCommand.CommandTimeout = 0;

            DataTable t2 = new DataTable();
            a2.Fill(t2);
            instCon.cerrarConexion();
            return t2;
        }

        public void mark_processed(int unLogId)
        {
            SqlCommand sqlCm = new SqlCommand("sp_logEspecialidad_MarcarProcesado", instCon.abrirConexion());
            sqlCm.CommandType = CommandType.StoredProcedure;

            sqlCm.Parameters.AddWithValue("@idLog", unLogId);


            sqlCm.ExecuteNonQuery();
            instCon.cerrarConexion();
        }

        public async Task postProcess(int unId, string unNombre, string unTipo, bool unaBaja, bool unEsEspecialidad, bool unEsGuardia, int unLogId)
        {
            ClassParameters instParameteres = new ClassParameters();


            string url = instParameteres.traerRuta("Especialidad");
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


                var response = await httpClient.PostAsJsonAsync(url, new Especialidad
                {
                    id = unId,
                    nombre = unNombre,
                    tipo = unTipo,
                    baja = unaBaja,
                    esEspecialidad = unEsEspecialidad,
                    esGuardia = unEsGuardia
                }).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    mark_processed(unLogId);
                    Console.WriteLine(unNombre + " - Especialidad Agregada");
                }
                else
                {
                    Console.WriteLine(unNombre + " - Error en Post Especialidad. " + response.StatusCode);
                }
            }
        }

        public async Task putProcess(int unId, string unNombre, string unTipo, bool unaBaja, bool unEsEspecialidad, bool unEsGuardia, int unLogId)
        {

            ClassParameters instParameteres = new ClassParameters();

            string url = instParameteres.traerRuta("Especialidad");
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

                var response = await httpClient.PutAsJsonAsync(url, new Especialidad
                {
                    id = unId,
                    nombre = unNombre,
                    tipo = unTipo,
                    baja = unaBaja,
                    esEspecialidad = unEsEspecialidad,
                    esGuardia = unEsGuardia
                }).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    mark_processed(unLogId);
                    Console.WriteLine(unNombre + " - Especialidad Actualizada");
                }
                else
                {
                    Console.WriteLine(unNombre + " - Error en Update Especialidad. " + response.StatusCode);
                }
            }
        }

        public async Task DeleteProcess(long unId, string unNombre, int unIdLog)
        {
            ClassParameters instParameteres = new ClassParameters();


            string url = instParameteres.traerRuta("Especialidad");
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
                    Console.WriteLine(unNombre + " - Especialidad Eliminada");
                }
                else
                {
                    Console.WriteLine(unNombre + " - Error en Delete Especialidad. " + response.StatusCode);
                }
            }
        }

    }
}
