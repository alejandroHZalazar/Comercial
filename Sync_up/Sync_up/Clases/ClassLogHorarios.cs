using Sync_up.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sync_up.Clases
{
    class ClassLogHorarios
    {
        Datos instCon = new Datos();

        public DataTable traerAProcesar()
        {
            SqlDataAdapter a2 = new SqlDataAdapter("[pol].[sp_horarios_Log_TraerAProcesar]", instCon.abrirConexion());
            a2.SelectCommand.CommandType = CommandType.StoredProcedure;
            a2.SelectCommand.CommandTimeout = 0;

            DataTable t2 = new DataTable();
            a2.Fill(t2);
            instCon.cerrarConexion();
            return t2;
        }

        public void mark_processed(int unLogId)
        {
            SqlCommand sqlCm = new SqlCommand("sp_logHorarios_MarcarProcesado", instCon.abrirConexion());
            sqlCm.CommandType = CommandType.StoredProcedure;

            sqlCm.Parameters.AddWithValue("@idLog", unLogId);


            sqlCm.ExecuteNonQuery();
            instCon.cerrarConexion();
        }

        public async Task postProcess(int unId, string unDia, DateTime unHorario, int unFk_medio, bool unCancelado, string? unConsultorio, bool unaBaja, int unLogId, bool unSobreTurno)
        {
            ClassParameters instParameteres = new ClassParameters();


            string url = instParameteres.traerRuta("horarios");
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

                var response = await httpClient.PostAsJsonAsync(url, new Horario
                {
                    id = unId,
                    dia = unDia,
                    horario = unHorario,
                    fk_medico = unFk_medio,
                    cancelado = unCancelado,
                    consultorio = unConsultorio,
                    baja = unaBaja,
                    sobreTurno = unSobreTurno
                }).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    mark_processed(unLogId);
                    Console.WriteLine(unHorario + " - Horario Agregada");
                }
                else
                {
                    Console.WriteLine(unHorario + " - Error en Post Horario. " + response.StatusCode);
                }
            }
        }

        public async Task putProcess(int unId, string unDia, DateTime  unHorario, int unFk_medio, bool unCancelado, string unConsultorio, bool unaBaja, int unLogId, bool unSobreTurno)
        {
            ClassParameters instParameteres = new ClassParameters();

            string url = instParameteres.traerRuta("horarios");
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

                var response = await httpClient.PutAsJsonAsync(url, new Horario
                {
                    id = unId,
                    dia = unDia,
                    horario = unHorario,
                    fk_medico = unFk_medio,
                    cancelado = unCancelado,
                    consultorio = unConsultorio,
                    baja = unaBaja,
                    sobreTurno = unSobreTurno
                }).ConfigureAwait(false);


                if (response.IsSuccessStatusCode)
                {
                    mark_processed(unLogId);
                    Console.WriteLine(unHorario + " - Horario Actualizada");
                }
                else
                {
                    Console.WriteLine(unHorario + " - Error en Update Horario. " + response.StatusCode);
                }
            }
        }

        public async Task DeleteProcess(long unId, string unHorario, int unIdLog)
        {
            ClassParameters instParameteres = new ClassParameters();


            string url = instParameteres.traerRuta("horarios");
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
                    Console.WriteLine(unHorario + " - Horario Eliminada");
                }
                else
                {
                    Console.WriteLine(unHorario + " - Error en Delete Horario. " + response.StatusCode);
                }
            }
            }

    }
}
