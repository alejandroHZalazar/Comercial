using Sync_up.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sync_up.Clases
{
    class ClassLogAfiliados
    {
        Datos instCon = new Datos();

        public DataTable traerAProcesar()
        {
            SqlDataAdapter a2 = new SqlDataAdapter("sp_logAfiliados_TraerAProcesar", instCon.abrirConexion());
            a2.SelectCommand.CommandType = CommandType.StoredProcedure;
            a2.SelectCommand.CommandTimeout = 0;

            DataTable t2 = new DataTable();
            a2.Fill(t2);
            instCon.cerrarConexion();
            return t2;
        }

        public string traerApiUltimoProcesado(string unModelo)
        {
            SqlCommand nComando = new SqlCommand("sp_ApiWeb_TraerUltimoProcesado", instCon.abrirConexion());
            nComando.CommandType = CommandType.StoredProcedure;

            nComando.Parameters.AddWithValue("@modelo", unModelo);

            string valor = nComando.ExecuteScalar().ToString();
            instCon.cerrarConexion();
            return valor;
        }

        public void UpdateUltimoProcesado(int unId, string unModelo)
        {

            SqlCommand sqlCm = new SqlCommand("sp_ApiWeb_UpdateUltimoProcesado", instCon.abrirConexion());
            sqlCm.CommandType = CommandType.StoredProcedure;


            sqlCm.Parameters.AddWithValue("@id", unId);
            sqlCm.Parameters.AddWithValue("@modelo", unModelo);

            sqlCm.ExecuteNonQuery();
            instCon.cerrarConexion();
        }

        public void WebAPiProccesed (string untipo, int unIdLog, long unId, long unGrupo, long unNro, string unNombre, DateTime unaFechaNac,
                                    long unNroDocumento, DateTime unaFechaAlta, DateTime? unaFechaBaja, bool unaBaja, string unaCalle, string unTelCelular,
                                    string unEmail, bool unAbusador)
        {
            SqlCommand sqlCm = new SqlCommand("sp_ApiWeb_UpCloudeModified", instCon.abrirConexion());
            sqlCm.CommandType = CommandType.StoredProcedure;


            sqlCm.Parameters.AddWithValue("@type", untipo);
            sqlCm.Parameters.AddWithValue("@idLog", unIdLog);
            sqlCm.Parameters.AddWithValue("@id", unId);
            sqlCm.Parameters.AddWithValue("@grupo", unGrupo);
            sqlCm.Parameters.AddWithValue("@nro", unNro);
            sqlCm.Parameters.AddWithValue("@nombre", unNombre);
            sqlCm.Parameters.AddWithValue("@fechaNac", unaFechaNac);
            sqlCm.Parameters.AddWithValue("@nroDocumento", unNroDocumento);
            sqlCm.Parameters.AddWithValue("@fechaAlta", unaFechaAlta);
            sqlCm.Parameters.AddWithValue("@fechaBaja", unaFechaBaja);
            sqlCm.Parameters.AddWithValue("@baja", unaBaja);
            sqlCm.Parameters.AddWithValue("@calle", unaCalle);
            sqlCm.Parameters.AddWithValue("@telCelular", unTelCelular);
            sqlCm.Parameters.AddWithValue("@email", unEmail);
            sqlCm.Parameters.AddWithValue("@abusador", unAbusador);

            sqlCm.ExecuteNonQuery();
            instCon.cerrarConexion();
        }

        public void mark_processed(int unLogId)
        {
            SqlCommand sqlCm = new SqlCommand("sp_logAfiliados_MarcarProcesado", instCon.abrirConexion());
            sqlCm.CommandType = CommandType.StoredProcedure;

            sqlCm.Parameters.AddWithValue("@idLog", unLogId);


            sqlCm.ExecuteNonQuery();
            instCon.cerrarConexion();
        }

        public async Task GetWeb()
        {
            ClassParameters InstParam = new ClassParameters();
            string url = InstParam.traerRuta("afiliados");
            string auth = InstParam.traerAutenticacion();
            
            url = url + "/" + traerApiUltimoProcesado("afiliados");
            JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var httpClient = new HttpClient(clientHandler))
            {
                httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(auth);
                string val = System.Convert.ToBase64String(plainTextBytes);
                httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var afiliadoLog = JsonSerializer.Deserialize<List<AfiliadosLog>>(content,options);

                    foreach (var item in afiliadoLog)
                    {
                        var numero = item.idLog;



                        WebAPiProccesed(item.editType, item.idLog, item.id, item.fk_grupo, item.nro, item.nombre, item.fechaNac, item.nroDocumento,
                                        item.fechaAlta, item.fechaBaja, item.baja, item.calle, item.telCelular, item.email, item.abusador);

                        if (item.editType == "A")
                            Console.WriteLine(item.nombre + " - Agregado a Base");

                        if (item.editType == "U")
                            Console.WriteLine(item.nombre + " - Actualizado en Base");

                        if (item.editType == "D")
                            Console.WriteLine(item.nombre + " - Eliminado de Base");
                    }


                }
            }


            }

        public async Task postProcess(long unId, long unFK_grupo, long unNro, string unNombre, DateTime unaFechaNac, long unNroDocumento, DateTime unaFechaAlta, DateTime? unaFechaBaja,
                                    bool unaBaja, string unaCalle, string unTelCelular, string unEmail, bool unAbusador, int unLogId)

        {
            ClassParameters instParameteres = new ClassParameters();
            

            string url = instParameteres.traerRuta("afiliados");
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

                var response = await httpClient.PostAsJsonAsync(url, new Afiliado
                {
                    id = unId,
                    fk_grupo = unFK_grupo,
                    nro = unNro,
                    nombre = unNombre,
                    fechaNac = unaFechaNac,
                    nroDocumento = unNroDocumento,
                    fechaAlta = unaFechaAlta,
                    fechaBaja = unaFechaBaja,
                    baja = unaBaja,
                    calle = unaCalle,
                    telCelular = unTelCelular,
                    email = unEmail,
                    abusador = unAbusador
                }).ConfigureAwait(false);



                if (response.IsSuccessStatusCode)
                {
                    mark_processed(unLogId);
                    Console.WriteLine(unNombre + " - Afiliado Agregado");
                }
                else
                {
                    Console.WriteLine(unNombre + " - Error en Post Afiliado. " + response.StatusCode  );
                }
            }
        }


            public async Task putProcess(long unId, long unFK_grupo, long unNro, string unNombre, DateTime unaFechaNac, long unNroDocumento, DateTime unaFechaAlta, DateTime? unaFechaBaja,
                                    bool unaBaja, string unaCalle, string unTelCelular, string unEmail, bool unAbusador, int unLogId)

            {
                ClassParameters instParameteres = new ClassParameters();


                string url = instParameteres.traerRuta("afiliados");
                string auth = instParameteres.traerAutenticacion();

                url = url + "/" + unId;
                    JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    HttpClientHandler clientHandler = new HttpClientHandler();
                    clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };


                using (var httpClient = new HttpClient(clientHandler))
                {

                    httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
                    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ale:1234");
                    string val = System.Convert.ToBase64String(plainTextBytes);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + val);

                    var response = await httpClient.PutAsJsonAsync(url, new Afiliado
                    {
                        id = unId,
                        fk_grupo = unFK_grupo,
                        nro = unNro,
                        nombre = unNombre,
                        fechaNac = unaFechaNac,
                        nroDocumento = unNroDocumento,
                        fechaAlta = unaFechaAlta,
                        fechaBaja = unaFechaBaja,
                        baja = unaBaja,
                        calle = unaCalle,
                        telCelular = unTelCelular,
                        email = unEmail,
                        abusador = unAbusador
                    }).ConfigureAwait(false);



                    if (response.IsSuccessStatusCode)
                    {
                        mark_processed(unLogId);
                        Console.WriteLine(unNombre + " - Afiliado Actualizado");
                    }
                    else
                    {
                        Console.WriteLine(unNombre + " - Error en Update Afiliado. " + response.StatusCode );
                    }

                }


            }


        public async Task DeleteProcess(long unId, string unNombre, int unIdLog)

        {
            ClassParameters instParameteres = new ClassParameters();


            string url = instParameteres.traerRuta("afiliados");
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
                    Console.WriteLine(unNombre + " - Afiliado Eliminado");
                }
                else
                {
                    Console.WriteLine(unNombre + " - Error en Delete Afiliado. " + response.StatusCode);
                }

            }


        }

    }
}
