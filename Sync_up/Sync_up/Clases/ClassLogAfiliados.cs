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

        public string traerApiUltimoProcesado()
        {
            SqlCommand nComando = new SqlCommand("sp_ApiWeb_TraerUltimoProcesado", instCon.abrirConexion());
            nComando.CommandType = CommandType.StoredProcedure;

            string valor = nComando.ExecuteScalar().ToString();
            instCon.cerrarConexion();
            return valor;
        }

        public void UpdateUltimoProcesado(int unId)
        {

            SqlCommand sqlCm = new SqlCommand("sp_ApiWeb_UpdateUltimoProcesado", instCon.abrirConexion());
            sqlCm.CommandType = CommandType.StoredProcedure;


            sqlCm.Parameters.AddWithValue("@id", unId);
            
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
            StreamReader leer = new StreamReader((System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\urlApi.env").Substring(6));
            var url = "";
            var auth = "";
            int cont = 0;

            while (!leer.EndOfStream)
            {
                cont++;
                switch (cont)
                {
                    case 2:
                        auth = leer.ReadLine();
                        break;
                    case 3:
                        url = leer.ReadLine();
                        break;                    
                    default:
                        leer.ReadLine();
                        break;
                }

                
            }

            leer.Close();

            url = url + "/" + traerApiUltimoProcesado();
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
            StreamReader leer = new StreamReader((System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\urlApi.env").Substring(6));
            var url = "";
            var auth = "";
            int cont = 0;

            while (!leer.EndOfStream)
            {
                cont = cont + 1;
                switch (cont)
                {
                    case 1:
                        url = leer.ReadLine();
                        break;
                    case 2:
                        auth = leer.ReadLine();
                        break;
                    default:
                        leer.ReadLine();
                        break;
                }

            }
            leer.Close();

            JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };


            using (var httpClient = new HttpClient(clientHandler))
            {

                httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes("ale:1234");
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
                    Console.WriteLine(unNombre + " - Agregado");
                }
                else
                {
                    Console.WriteLine(unNombre + " - Error en Post. " + response.StatusCode  );
                }
            }
        }


            public async Task putProcess(long unId, long unFK_grupo, long unNro, string unNombre, DateTime unaFechaNac, long unNroDocumento, DateTime unaFechaAlta, DateTime? unaFechaBaja,
                                    bool unaBaja, string unaCalle, string unTelCelular, string unEmail, bool unAbusador, int unLogId)

            {
                StreamReader leer = new StreamReader((System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\urlApi.env").Substring(6));
                var url = "";
                var auth = "";
                int cont = 0;

                while (!leer.EndOfStream)
                {
                    cont = cont + 1;
                    switch (cont)
                    {
                        case 1:
                            url = leer.ReadLine();
                            break;
                        case 2:
                            auth = leer.ReadLine();
                            break;
                        default:
                        leer.ReadLine();
                        break;
                    }

                }
            leer.Close();
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
                        Console.WriteLine(unNombre + " - Actualizado");
                    }
                    else
                    {
                        Console.WriteLine(unNombre + " - Error en Update. " + response.StatusCode );
                    }

                }


            }


        public async Task DeleteProcess(long unId, string unNombre, int unIdLog)

        {
            StreamReader leer = new StreamReader((System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\urlApi.env").Substring(6));
            var url = "";
            var auth = "";
            int cont = 0;

            while (!leer.EndOfStream)
            {
                cont = cont + 1;
                switch (cont)
                {
                    case 1:
                        url = leer.ReadLine();
                        break;
                    case 2:
                        auth = leer.ReadLine();
                        break;
                    default:
                        leer.ReadLine();
                        break;
                }

            }
            leer.Close();
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

                var response = await httpClient.DeleteAsync(url).ConfigureAwait(false);



                if (response.IsSuccessStatusCode)
                {
                    mark_processed(unIdLog);
                    Console.WriteLine(unNombre + " - Eliminado");
                }
                else
                {
                    Console.WriteLine(unNombre + " - Error en Delete. " + response.StatusCode);
                }

            }


        }

    }
}
