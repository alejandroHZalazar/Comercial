using Sync_up.Clases;
using Sync_up.Models;
using System;
using System.Data;
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

            Console.WriteLine(DateTime.Now + " - Inicio revision de movimientos");

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

            Console.WriteLine(DateTime.Now + " - Fin revision de movimientos");
            Console.WriteLine(DateTime.Now + " - Inicio revisión Nube");

            try
            {
                instLogAfil.GetWeb().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.WriteLine(DateTime.Now + " - Fin revisión Nube");
        }
    }
}
