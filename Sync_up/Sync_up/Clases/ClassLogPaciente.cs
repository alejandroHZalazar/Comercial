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
    class ClassLogPaciente
    {
        Datos instCon = new Datos();

        public DataTable traerAProcesar()
        {
            SqlDataAdapter a2 = new SqlDataAdapter("sp_logPaciente_TraerAProcesar", instCon.abrirConexion());
            a2.SelectCommand.CommandType = CommandType.StoredProcedure;
            a2.SelectCommand.CommandTimeout = 0;

            DataTable t2 = new DataTable();
            a2.Fill(t2);
            instCon.cerrarConexion();
            return t2;
        }
        public void mark_processed(int unLogId)
        {
            SqlCommand sqlCm = new SqlCommand("sp_logPaciente_MarcarProcesado", instCon.abrirConexion());
            sqlCm.CommandType = CommandType.StoredProcedure;

            sqlCm.Parameters.AddWithValue("@idLog", unLogId);


            sqlCm.ExecuteNonQuery();
            instCon.cerrarConexion();
        }

        public async Task postProcess(int unId, string unNombre, DateTime UnaFechAnAC, int unTipoDoc, long unNroDoc, long unCuil, DateTime unafechaAlta
                                    , DateTime unaFechabaja, string unaCalle, string unNroCalle, string unEntreCalle, string unYCalle, string unPiso,
                                    string unDpto, string unaCasa, string unLote, string unaMz, string unaPc, string unBlock, string unaQta, string unaUf,
                                     string unEtapa, string unaTorre, string unaTira, string unaChacra, int unFk_barrio, int unRadioGeografico, string unTelFijo,
                                     string unCelular, string unEmail, bool unEsSocio, bool unaBaja, int unFk_ObraSocial, int unFk_condicionIVA, string unCuit,
                                     int unNroAfiliado, long unFk_grupo, int unFk_pais, int unFk_provincia, int unFk_localidad, string unNroAfiliadoOs, string unSexo
                                    , int unLogId)
        {
            ClassParameters instParameteres = new ClassParameters();


            string url = instParameteres.traerRuta("paciente");
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


                var response = await httpClient.PostAsJsonAsync(url, new Paciente
                {
                    id = unId,
                    nombre = unNombre,
                    fechaNac = UnaFechAnAC,
                    fk_tipoDoc = unTipoDoc,
                    nroDocumento = unNroDoc,
                    cuil = unCuil,
                    fechaAlta = unafechaAlta,
                    fechaBaja = unaFechabaja,
                    calle = unaCalle,
                    numeroCalle = unNroCalle,
                    entreCalle = unEntreCalle,
                    ycalle= unYCalle,
                    piso=unPiso,
                    dpto = unDpto,
                    casa = unaCasa,
                    lote=unLote,
                    mz=unaMz,
                    pc=unaPc,
                    block=unBlock,
                    qta=unaQta,
                    uf=unaUf,
                    etapa=unEtapa,
                    torre=unaTorre,
                    tira=unaTira,
                    chacra=unaChacra,
                    fk_barrio=unFk_barrio,
                    radioGeografico=unRadioGeografico,
                    telFijo=unTelFijo,
                    telCelular=unCelular,
                    email=unEmail,
                    esSocio=unEsSocio,
                    baja=unaBaja,
                    fk_obraSocial=unFk_ObraSocial,
                    fk_condicionIVA=unFk_condicionIVA,
                    cuit=unCuit,
                    nroAfiliado=unNroAfiliado,
                    fk_grupo=unFk_grupo,
                    fk_pais=unFk_pais,
                    fk_provincia=unFk_provincia,
                    fk_localidad=unFk_localidad,
                    nroAfiliadoOS=unNroAfiliadoOs,
                    sexo=unSexo
                }).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    mark_processed(unLogId);
                    Console.WriteLine(unNombre + " - Paciente Agregado");
                }
                else
                {
                    Console.WriteLine(unNombre + " - Error en Post Paciente. " + response.StatusCode);
                }
            }
        }

        public async Task putProcess(int unId, string unNombre, DateTime UnaFechAnAC, int unTipoDoc, long unNroDoc, long unCuil, DateTime unafechaAlta
                                    , DateTime unaFechabaja, string unaCalle, string unNroCalle, string unEntreCalle, string unYCalle, string unPiso,
                                    string unDpto, string unaCasa, string unLote, string unaMz, string unaPc, string unBlock, string unaQta, string unaUf,
                                     string unEtapa, string unaTorre, string unaTira, string unaChacra, int unFk_barrio, int unRadioGeografico, string unTelFijo,
                                     string unCelular, string unEmail, bool unEsSocio, bool unaBaja, int unFk_ObraSocial, int unFk_condicionIVA, string unCuit,
                                     int unNroAfiliado, long unFk_grupo, int unFk_pais, int unFk_provincia, int unFk_localidad, string unNroAfiliadoOs, string unSexo
                                    , int unLogId)
        {

            ClassParameters instParameteres = new ClassParameters();

            string url = instParameteres.traerRuta("paciente");
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

                var response = await httpClient.PutAsJsonAsync(url, new Paciente
                {
                    id = unId,
                    nombre = unNombre,
                    fechaNac = UnaFechAnAC,
                    fk_tipoDoc = unTipoDoc,
                    nroDocumento = unNroDoc,
                    cuil = unCuil,
                    fechaAlta = unafechaAlta,
                    fechaBaja = unaFechabaja,
                    calle = unaCalle,
                    numeroCalle = unNroCalle,
                    entreCalle = unEntreCalle,
                    ycalle = unYCalle,
                    piso = unPiso,
                    dpto = unDpto,
                    casa = unaCasa,
                    lote = unLote,
                    mz = unaMz,
                    pc = unaPc,
                    block = unBlock,
                    qta = unaQta,
                    uf = unaUf,
                    etapa = unEtapa,
                    torre = unaTorre,
                    tira = unaTira,
                    chacra = unaChacra,
                    fk_barrio = unFk_barrio,
                    radioGeografico = unRadioGeografico,
                    telFijo = unTelFijo,
                    telCelular = unCelular,
                    email = unEmail,
                    esSocio = unEsSocio,
                    baja = unaBaja,
                    fk_obraSocial = unFk_ObraSocial,
                    fk_condicionIVA = unFk_condicionIVA,
                    cuit = unCuit,
                    nroAfiliado = unNroAfiliado,
                    fk_grupo = unFk_grupo,
                    fk_pais = unFk_pais,
                    fk_provincia = unFk_provincia,
                    fk_localidad = unFk_localidad,
                    nroAfiliadoOS = unNroAfiliadoOs,
                    sexo = unSexo
                }).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    mark_processed(unLogId);
                    Console.WriteLine(unNombre + " - Paciente Actualizada");
                }
                else
                {
                    Console.WriteLine(unNombre + " - Error en Update Paciente. " + response.StatusCode);
                }
            }
        }

        public async Task DeleteProcess(long unId, string unNombre, int unIdLog)
        {
            ClassParameters instParameteres = new ClassParameters();


            string url = instParameteres.traerRuta("paciente");
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
                    Console.WriteLine(unNombre + " - Paciente Eliminado");
                }
                else
                {
                    Console.WriteLine(unNombre + " - Error en Delete Paciente. " + response.StatusCode);
                }
            }
        }
    }
}
