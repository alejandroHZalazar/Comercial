using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Comercial.Formularios.Configuracion
{
    public partial class frmLogo : Form
    {
        public frmLogo()
        {
            InitializeComponent();
        }

        private void btnLogo_Click(object sender, EventArgs e)
        {
            Clases.classDatos instDatos = new Clases.classDatos();
            OpenFileDialog unOpenFileDialog = new OpenFileDialog();
            unOpenFileDialog.Filter = "All files (*.*)|*.*";
            unOpenFileDialog.RestoreDirectory = true;

            if (unOpenFileDialog .ShowDialog() == DialogResult .OK )
            {
                byte[] archivo;
                string nombreArchivo = string.Empty;
                nombreArchivo = Path.GetFileName(unOpenFileDialog.FileName);
                archivo = File.ReadAllBytes(unOpenFileDialog.FileName);

                MySqlCommand nComando = new MySqlCommand("update parametros set valor = @valor, imagen = @imagen where modulo = 'login' and parametro = 'imagen'", instDatos.abrirConexion());
                nComando.Parameters.AddWithValue("@valor", nombreArchivo);
                nComando.Parameters.AddWithValue("imagen", archivo);
                nComando.ExecuteNonQuery();
                instDatos.cerrarConexion();
                MessageBox.Show(this, "Proceso completo", "LOGO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmLogo_Load(object sender, EventArgs e)
        {

        }
    }
}
