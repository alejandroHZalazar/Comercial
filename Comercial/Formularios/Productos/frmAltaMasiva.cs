using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Comercial.Formularios.Productos
{
    public partial class frmAltaMasiva : Form
    {
        public frmAltaMasiva()
        {
            InitializeComponent();
        }

        Clases.ClassProductos instProd = new Clases.ClassProductos();

        private void btnLevantar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                string hoja;
                dialog.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx";
                dialog.Title = "Seleccione el archivo de Excel";
                dialog.FileName = string.Empty;

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtArchivo.Text = dialog.FileName;
                    hoja = txtHoja.Text;
                    LlenarGrid(txtArchivo.Text, hoja);
                    dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }

            catch
            { }
        }

        private void LlenarGrid(string archivo, string hoja)
        {
            OleDbConnection conexion = null;
            DataSet dataSet = null;
            OleDbDataAdapter dataAdapter = null;
            string consultaHojaExcel = "select * from [" + hoja + "$]";

            string cadenaConexionArchivoExcel = "provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + archivo + "';Extended Properties=Excel 12.0;";

            if (string .IsNullOrEmpty (hoja))
            {
                MessageBox.Show("No hay una hoja para leer");
            }
            else
            {
                conexion = new OleDbConnection(cadenaConexionArchivoExcel);
                conexion.Open();
                dataAdapter = new OleDbDataAdapter(consultaHojaExcel, conexion);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, hoja);
                dgvProductos.DataSource = dataSet.Tables[0];
                conexion.Close();
                dgvProductos.AllowUserToAddRows = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorkerTarea.RunWorkerAsync();

            //foreach (DataGridViewRow fila in dgvProductos.Rows)
            //{
            //    int result;
            //    result = instProd.ABMProductos(fila.Cells[0].Value.ToString(), fila.Cells[1].Value.ToString(), int.Parse(fila.Cells[3].Value.ToString()), int.Parse(fila.Cells[4].Value.ToString()), fila.Cells[2].Value.ToString().ToUpper ().Trim (), int.Parse(fila.Cells[5].Value.ToString()),decimal.Parse(fila.Cells[7].Value.ToString()), decimal.Parse(fila.Cells[8].Value.ToString()), decimal.Parse(fila.Cells[9].Value.ToString()), decimal.Parse(fila.Cells[10].Value.ToString()), 1, 0, decimal.Parse(fila.Cells[6].Value.ToString()));

            //    if (result == -1)
            //    {
            //        MessageBox.Show(this, "Error en producto: " + fila.Cells[2].Value.ToString(), "ALTA MASIVA DE PRODUCTOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        break;
            //    }
            //}

            //MessageBox.Show(this, "Productos Cargados con exito", "ALTAS MASIVA DE PRODUCTOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //dgvProductos.DataSource = null;
            //dgvProductos.Rows.Clear();
        }

        private void frmAltaMasiva_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void backgroundWorkerTarea_DoWork(object sender, DoWorkEventArgs e)
        {
            int progreso = 0;
            pbProceso.Maximum = dgvProductos.RowCount;
            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {
                int result;
                result = instProd.ABMProductos(fila.Cells[0].Value.ToString(), fila.Cells[1].Value.ToString(), int.Parse(fila.Cells[3].Value.ToString()), fila.Cells[2].Value.ToString().ToUpper().Trim(), int.Parse(fila.Cells[5].Value.ToString()), decimal.Parse(fila.Cells[7].Value.ToString()), decimal.Parse(fila.Cells[8].Value.ToString()), decimal.Parse(fila.Cells[9].Value.ToString()), decimal.Parse(fila.Cells[10].Value.ToString()), 1, 0, decimal.Parse(fila.Cells[6].Value.ToString()));

                if (result == -1)
                {
                    MessageBox.Show(this, "Error en producto: " + fila.Cells[2].Value.ToString(), "ALTA MASIVA DE PRODUCTOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }

                progreso++;
                backgroundWorkerTarea.ReportProgress(progreso,DateTime .Now );
            }

            MessageBox.Show(this, "Productos Cargados con exito", "ALTAS MASIVA DE PRODUCTOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvProductos.DataSource = null;
            dgvProductos.Rows.Clear();
        }

        private void backgroundWorkerTarea_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbProceso.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerTarea_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }
    }
}
