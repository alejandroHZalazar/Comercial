using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Comercial.Clases
{
    class ClassValidacion
    {
        public static void soloNumeros(System.Windows.Forms.KeyPressEventArgs  e)
        {
            if (char.IsNumber(e.KeyChar) | e.KeyChar  == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled =  true ;
            }
                
        }

        public static decimal cambiarPuntoPorComa ( string cantidad)
        {
            decimal res = -1;

            try
                {
                    if (cantidad .IndexOf ('.') != -1)
                    {
                    String[] cant = cantidad.Split('.');

                    if (cant .Length ==2)
                    {
                        res = decimal.Parse(cant[0] + "," + cant[1]);
                    }

                    if (cant .Length ==1)
                    {
                        res = 0;
                    }
                    }
                }
            catch
            {

            }
            return res;

        }
        

        public static void seleccionarTodoNumericUpDown (System .Windows .Forms .NumericUpDown unControl)
        {
            unControl.Select(0, unControl.Text.Length);
        }

        public static void seleccionarTodoTextBox(System.Windows.Forms.TextBox  unControl)
        {
            unControl.Select(0, unControl.Text.Length);
        }

        public static void seleccionarTodoMask(System.Windows.Forms.MaskedTextBox unMask)
        {
            unMask.Select(0, unMask.Text.Length);
        }

        public static string traerEmpresa()
        {
            classDatos instDatos = new classDatos();
            MySqlCommand nComando = new MySqlCommand("select valor from parametros where modulo = 'empresa' and parametro = 'nombre'", instDatos.abrirConexion());
            string valor = nComando.ExecuteScalar().ToString();
            instDatos.cerrarConexion();
            return valor;
        }

        public static string traerEmpresaDireccion()
        {
            classDatos instDatos = new classDatos();
            MySqlCommand nComando = new MySqlCommand("select valor from parametros where modulo = 'empresa' and parametro = 'direccion'", instDatos.abrirConexion());
            string valor = nComando.ExecuteScalar().ToString();
            instDatos.cerrarConexion();
            return valor;
        }

        public static string traerRazonSocial()
        {
            classDatos instDatos = new classDatos();
            MySqlCommand nComando = new MySqlCommand("select valor from parametros where modulo = 'empresa' and parametro = 'razonSocial'", instDatos.abrirConexion());
            string valor = nComando.ExecuteScalar().ToString();
            instDatos.cerrarConexion();
            return valor;
        }

        public static string traerEmpresaCuit()
        {
            classDatos instDatos = new classDatos();
            MySqlCommand nComando = new MySqlCommand("select valor from parametros where modulo = 'empresa' and parametro = 'cuit'", instDatos.abrirConexion());
            string valor = nComando.ExecuteScalar().ToString();
            instDatos.cerrarConexion();
            return valor;
        }

        public static string traerEmpresaCiudad()
        {
            classDatos instDatos = new classDatos();
            MySqlCommand nComando = new MySqlCommand("select valor from parametros where modulo = 'empresa' and parametro = 'localidad'", instDatos.abrirConexion());
            string valor = nComando.ExecuteScalar().ToString();
            instDatos.cerrarConexion();
            return valor;
        }

        public static string traerEmpresaTelefono()
        {
            classDatos instDatos = new classDatos();
            MySqlCommand nComando = new MySqlCommand("select valor from parametros where modulo = 'empresa' and parametro = 'telefono'", instDatos.abrirConexion());
            string valor = nComando.ExecuteScalar().ToString();
            instDatos.cerrarConexion();
            return valor;
        }


        public static  bool validarEmail(System .Windows .Forms .TextBox unTextBox)
        {
            try
            {
                if (unTextBox.Text == string.Empty)
                {
                    return true;
                }
                else
                {

                    var mail = new System.Net.Mail.MailAddress(unTextBox.Text.Trim());
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
