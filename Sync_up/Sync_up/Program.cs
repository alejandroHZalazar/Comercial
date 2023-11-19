using Sync_up.Clases;
using Sync_up.Models;
using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Sync_up
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer(60000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
           
            Console.ReadKey();
            timer.Stop();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ClassLogAfiliados instLogAfil = new ClassLogAfiliados();
            DataTable Logs = instLogAfil.traerAProcesar();

            ClassLogEspecialidad instLogEspecialidad = new ClassLogEspecialidad();
            DataTable espacialidadLogs = instLogEspecialidad.traerAProcesar();

            ClassLogHorarios instLogHorarios = new ClassLogHorarios();
            DataTable horariosLogs = instLogHorarios.traerAProcesar();

            ClassLogInactivismoMedico instInactMedico = new ClassLogInactivismoMedico();
            DataTable InactivismoLogs = instInactMedico.traerAProcesar();

            ClassLogMedicoEspecialidad instMedicoEsp = new ClassLogMedicoEspecialidad();
            DataTable medicoEspLogs = instMedicoEsp.traerAProcesar();

            ClassLogMedico instLogMedico = new ClassLogMedico();
            DataTable MedicoLogs = instLogMedico.traerAProcesar();

            ClassLogPaciente instLogPaciente = new ClassLogPaciente();
            DataTable PacienteLogs = instLogPaciente.traerAProcesar();

            Console.WriteLine(DateTime.Now + " - Inicio revision de movimientos Afiliados");

            foreach (DataRow fila in Logs.Rows)
            {
                if (fila["EditType"].ToString () == "A")
                {
                    try
                    {
                        // Task<String> resp = 
                        instLogAfil.postProcess(long.Parse(fila["id"].ToString()), long.Parse(fila["fk_grupo"].ToString()), long.Parse(fila["nro"].ToString()),
                    fila["nombre"].ToString(), DateTime.Parse(fila["fechaNac"].ToString()), long.Parse(fila["nroDocumento"].ToString()), DateTime.Parse(fila["fechaAlta"].ToString()),
                           (fila["fechaBaja"].ToString() == "" ? null : DateTime.Parse(fila["fechaBaja"].ToString())), bool.Parse(fila["baja"].ToString()), fila["calle"].ToString(), fila["telCelular"].ToString(),
                        fila["email"].ToString(), bool.Parse(fila["abusador"].ToString()), int.Parse(fila["logId"].ToString())).Wait();

                        //Console.WriteLine(resp);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                if (fila["EditType"].ToString() == "U")
                {
                    try
                    {
                        // Task<String> resp = 
                        instLogAfil.putProcess(long.Parse(fila["id"].ToString()), long.Parse(fila["fk_grupo"].ToString()), long.Parse(fila["nro"].ToString()),
                    fila["nombre"].ToString(), DateTime.Parse(fila["fechaNac"].ToString()), long.Parse(fila["nroDocumento"].ToString()), DateTime.Parse(fila["fechaAlta"].ToString()),
                           (fila["fechaBaja"].ToString() == "" ? null : DateTime.Parse(fila["fechaBaja"].ToString())), bool.Parse(fila["baja"].ToString()), fila["calle"].ToString(), fila["telCelular"].ToString(),
                        fila["email"].ToString(), bool.Parse(fila["abusador"].ToString()), int.Parse(fila["logId"].ToString())).Wait();

                        //Console.WriteLine(resp);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                if (fila["EditType"].ToString() == "D")
                {
                    try
                    {
                        // Task<String> resp = 
                        instLogAfil.DeleteProcess(long.Parse(fila["id"].ToString()), fila["nombre"].ToString(),int.Parse(fila["logId"].ToString())).Wait();

                        //Console.WriteLine(resp);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            Console.WriteLine(DateTime.Now + " - Inicio revision de movimientos Especialidad");

            foreach (DataRow fila in espacialidadLogs.Rows)
            {
                if (fila["EditType"].ToString() == "A")
                {
                    try
                    {
                        instLogEspecialidad.postProcess(int.Parse(fila["id"].ToString()), fila["nombre"].ToString(), fila["tipo"].ToString(), bool.Parse(fila["baja"].ToString()), bool.Parse(fila["esEspecialidad"].ToString()), bool.Parse(fila["esGuardia"].ToString()), int.Parse(fila["logId"].ToString())).Wait();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                if (fila["EditType"].ToString() == "U")
                {
                    try
                    {
                        instLogEspecialidad.putProcess(int.Parse(fila["id"].ToString()), fila["nombre"].ToString(), fila["tipo"].ToString(), bool.Parse(fila["baja"].ToString()), bool.Parse(fila["esEspecialidad"].ToString()), bool.Parse(fila["esGuardia"].ToString()), int.Parse(fila["logId"].ToString())).Wait();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                if (fila["EditType"].ToString() == "D")
                {
                    try
                    {
                        instLogEspecialidad.DeleteProcess(int.Parse(fila["id"].ToString()), fila["nombre"].ToString(), int.Parse(fila["logId"].ToString())).Wait();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            Console.WriteLine(DateTime.Now + " - Inicio revision de movimientos Horarios");

            foreach (DataRow fila in horariosLogs.Rows)
            {
                if (fila["EditType"].ToString() == "A")
                {
                    try
                    {
                        instLogHorarios.postProcess(int.Parse(fila["id"].ToString()), fila["dia"].ToString(), DateTime.Parse(fila["horario"].ToString()), int.Parse(fila["fk_medico"].ToString()), bool.Parse(fila["cancelado"].ToString()), (fila["consultorio"].ToString() == "" ? " ": fila["consultorio"].ToString()), bool.Parse(fila["baja"].ToString()), int.Parse(fila["logId"].ToString()), bool.Parse(fila["sobreTurno"].ToString())).Wait();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                if (fila["EditType"].ToString() == "U")
                {
                    try
                    {
                        instLogHorarios.putProcess(int.Parse(fila["id"].ToString()), fila["dia"].ToString(), DateTime.Parse(fila["horario"].ToString()), int.Parse(fila["fk_medico"].ToString()), bool.Parse(fila["cancelado"].ToString()), fila["consultorio"].ToString(), bool.Parse(fila["baja"].ToString()), int.Parse(fila["logId"].ToString()), bool.Parse(fila["sobreTurno"].ToString())).Wait();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                if (fila["EditType"].ToString() == "D")
                {
                    try
                    {
                        instLogHorarios.DeleteProcess(int.Parse(fila["id"].ToString()), fila["horario"].ToString(),int.Parse(fila["logId"].ToString())).Wait();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            Console.WriteLine(DateTime.Now + " - Inicio revision de movimientos Inactivismo Médico");

            foreach (DataRow fila in InactivismoLogs.Rows)
            {
                if (fila["EditType"].ToString() == "A")
                {
                    try
                    {
                        instInactMedico.postProcess(int.Parse(fila["id"].ToString()), int.Parse(fila["fk_medico"].ToString()), DateTime.Parse(fila["fecha_inicio"].ToString()), DateTime.Parse(fila["fecha_fin"].ToString()), bool.Parse(fila["terminado"].ToString()), int.Parse(fila["logId"].ToString())).Wait();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                if (fila["EditType"].ToString() == "U")
                {
                    try
                    {
                        instInactMedico.putProcess(int.Parse(fila["id"].ToString()), int.Parse(fila["fk_medico"].ToString()), DateTime.Parse(fila["fecha_inicio"].ToString()), DateTime.Parse(fila["fecha_fin"].ToString()), bool.Parse(fila["terminado"].ToString()), int.Parse(fila["logId"].ToString())).Wait();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                if (fila["EditType"].ToString() == "D")
                {
                    try
                    {
                        instInactMedico.DeleteProcess(int.Parse(fila["id"].ToString()), int.Parse(fila["fk_medico"].ToString()), int.Parse(fila["logId"].ToString())).Wait();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
           
            Console.WriteLine(DateTime.Now + " - Inicio revision de movimientos Médico Especialidad");

            foreach (DataRow fila in medicoEspLogs.Rows)
            {
                if (fila["EditType"].ToString() == "A")
                {
                    try
                    {
                        instMedicoEsp.postProcess(int.Parse(fila["id"].ToString()), int.Parse(fila["fk_medico"].ToString()), int.Parse(fila["fk_especialidad"].ToString()), int.Parse(fila["logId"].ToString())).Wait();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                if (fila["EditType"].ToString() == "U")
                {
                    try
                    {
                        instMedicoEsp.putProcess(int.Parse(fila["id"].ToString()), int.Parse(fila["fk_medico"].ToString()), int.Parse(fila["fk_especialidad"].ToString()), int.Parse(fila["logId"].ToString())).Wait();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                if (fila["EditType"].ToString() == "D")
                {
                    try
                    {
                        instMedicoEsp.DeleteProcess(int.Parse(fila["id"].ToString()), int.Parse(fila["fk_medico"].ToString()), int.Parse(fila["logId"].ToString())).Wait();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            Console.WriteLine(DateTime.Now + " - Inicio revision de movimientos Médico");

            foreach (DataRow fila in MedicoLogs.Rows)
            {
                if (fila["EditType"].ToString() == "A")
                {
                    try
                    {
                        instLogMedico.postProcess(int.Parse(fila["id"].ToString()), fila["nombre"].ToString(), fila["domicilio"].ToString(), fila["telFijo"].ToString(),
                                                fila["telCel"].ToString(), bool.Parse(fila["baja"].ToString()), Encoding.ASCII.GetBytes(fila["firma"].ToString()),
                                                bool.Parse(fila["esEspecialista"].ToString()), fila["consultorio"].ToString(), fila["matricula"].ToString(),
                                                 bool.Parse(fila["esGuardia"].ToString()), int.Parse(fila["logId"].ToString())).Wait();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                if (fila["EditType"].ToString() == "U")
                {
                    try
                    {
                        instLogMedico.putProcess(int.Parse(fila["id"].ToString()), fila["nombre"].ToString(), fila["domicilio"].ToString(), fila["telFijo"].ToString(),
                                                fila["telCel"].ToString(), bool.Parse(fila["baja"].ToString()), Encoding.ASCII.GetBytes(fila["firma"].ToString()),
                                                bool.Parse(fila["esEspecialista"].ToString()), fila["consultorio"].ToString(), fila["matricula"].ToString(),
                                                 bool.Parse(fila["esGuardia"].ToString()), int.Parse(fila["logId"].ToString())).Wait();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                if (fila["EditType"].ToString() == "D")
                {
                    try
                    {
                        instLogMedico.DeleteProcess(int.Parse(fila["id"].ToString()), fila["nombre"].ToString(), int.Parse(fila["logId"].ToString())).Wait();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            Console.WriteLine(DateTime.Now + " - Inicio revision de movimientos Paciente");

            foreach (DataRow fila in PacienteLogs.Rows)
            {
                if (fila["EditType"].ToString() == "A")
                {
                    try
                    {
                        instLogPaciente.postProcess(int.Parse(fila["id"].ToString()), fila["nombre"].ToString(), DateTime.Parse(fila["fechaNac"].ToString())
                                                    , int.Parse(fila["fk_tipoDoc"].ToString()),long.Parse(fila["nroDocumento"].ToString()), (fila["cuil"].ToString() == ""?0:long.Parse(fila["cuil"].ToString()))
                                                    , DateTime.Parse(fila["fechaAlta"].ToString()),(fila["fechaBaja"] != DBNull.Value && fila["fechaBaja"] != null?DateTime.Parse(fila["fechaBaja"].ToString ()):DateTime.Parse("1901-01-01")), fila["calle"].ToString()
                                                    , fila["numeroCalle"].ToString(), fila["entreCalle"].ToString(), fila["ycalle"].ToString(), fila["piso"].ToString()
                                                    , fila["dpto"].ToString(), fila["casa"].ToString(), fila["lote"].ToString(), fila["mz"].ToString(), fila["pc"].ToString()
                                                    , fila["block"].ToString(), fila["qta"].ToString(), fila["uf"].ToString(), fila["etapa"].ToString(), fila["torre"].ToString()
                                                    , fila["tira"].ToString(), fila["chacra"].ToString(),int.Parse(fila["fk_barrio"].ToString()), (fila["radioGeografico"].ToString() == ""?0:int.Parse(fila["radioGeografico"].ToString()))
                                                    , fila["telFijo"].ToString(), fila["telCelular"].ToString(), fila["email"].ToString(),bool.Parse(fila["esSocio"].ToString())
                                                    , bool.Parse(fila["baja"].ToString()), int.Parse(fila["fk_obraSocial"].ToString()), (fila["fk_condicionIVA"].ToString() == ""?0:int.Parse(fila["fk_condicionIVA"].ToString()))
                                                    , fila["cuit"].ToString(),(fila["nroAfiliado"].ToString() == ""?0:int.Parse(fila["nroAfiliado"].ToString())), long.Parse(fila["fk_grupo"].ToString())
                                                    , (fila["fk_pais"].ToString() == ""?0:int.Parse(fila["fk_pais"].ToString())),(fila["fk_provincia"].ToString() == ""?0:int.Parse(fila["fk_provincia"].ToString())),(fila["fk_localidad"].ToString()==""?0:int.Parse(fila["fk_localidad"].ToString()))
                                                    , fila["nroAfiliadoOS"].ToString(), fila["sexo"].ToString(), int.Parse(fila["logId"].ToString())).Wait();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                if (fila["EditType"].ToString() == "U")
                {
                    try
                    {
                        instLogPaciente.putProcess(int.Parse(fila["id"].ToString()), fila["nombre"].ToString(), DateTime.Parse(fila["fechaNac"].ToString())
                                                    , int.Parse(fila["fk_tipoDoc"].ToString()), long.Parse(fila["nroDocumento"].ToString()), (fila["cuil"].ToString() == "" ? 0 : long.Parse(fila["cuil"].ToString()))
                                                    , DateTime.Parse(fila["fechaAlta"].ToString()), (fila["fechaBaja"] != DBNull.Value && fila["fechaBaja"] != null ? DateTime.Parse(fila["fechaBaja"].ToString()) : DateTime.Parse("1901-01-01")), fila["calle"].ToString()
                                                    , fila["numeroCalle"].ToString(), fila["entreCalle"].ToString(), fila["ycalle"].ToString(), fila["piso"].ToString()
                                                    , fila["dpto"].ToString(), fila["casa"].ToString(), fila["lote"].ToString(), fila["mz"].ToString(), fila["pc"].ToString()
                                                    , fila["block"].ToString(), fila["qta"].ToString(), fila["uf"].ToString(), fila["etapa"].ToString(), fila["torre"].ToString()
                                                    , fila["tira"].ToString(), fila["chacra"].ToString(), int.Parse(fila["fk_barrio"].ToString()), int.Parse(fila["radioGeografico"].ToString())
                                                    , fila["telFijo"].ToString(), fila["telCelular"].ToString(), fila["email"].ToString(), bool.Parse(fila["esSocio"].ToString())
                                                    , bool.Parse(fila["baja"].ToString()), int.Parse(fila["fk_obraSocial"].ToString()), (fila["fk_condicionIVA"].ToString() == "" ? 0 : int.Parse(fila["fk_condicionIVA"].ToString()))
                                                    , fila["cuit"].ToString(), int.Parse(fila["nroAfiliado"].ToString()), long.Parse(fila["fk_grupo"].ToString())
                                                    , (fila["fk_pais"].ToString() == "" ? 0 : int.Parse(fila["fk_pais"].ToString())), (fila["fk_provincia"].ToString() == "" ? 0 : int.Parse(fila["fk_provincia"].ToString())), (fila["fk_localidad"].ToString() == "" ? 0 : int.Parse(fila["fk_localidad"].ToString()))
                                                    , fila["nroAfiliadoOS"].ToString(), fila["sexo"].ToString(), int.Parse(fila["logId"].ToString())).Wait();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                if (fila["EditType"].ToString() == "D")
                {
                    try
                    {
                        instLogPaciente.DeleteProcess(long.Parse(fila["id"].ToString()), fila["nombre"].ToString(), int.Parse(fila["logId"].ToString())).Wait();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            Console.WriteLine(DateTime.Now + " - Fin revision de movimientos");
            //Console.WriteLine(DateTime.Now + " - Inicio revisión Nube");

            //try
            //{
            //    instLogAfil.GetWeb().Wait();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}


            //Console.WriteLine(DateTime.Now + " - Fin revisión Nube");
        }
    }
}
