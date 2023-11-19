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
    public partial class frmCambioDePreciosMasivo : Form
    {

        Clases.ClassProductos instProdu = new Clases.ClassProductos();

        public frmCambioDePreciosMasivo()
        {
            InitializeComponent();
        }

        private void frmCambioDePreciosMasivo_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void estadoInicial()
        {
            txtArchivo.Text = string.Empty;
            txtHoja.Text = string.Empty;
            dgvProductos.DataSource = null;
            dgvProductos.Rows.Clear();
        }

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

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LlenarGrid(string archivo, string hoja)
        {
            try
            {
                OleDbConnection conexion = null;
                DataSet dataSet = null;
                OleDbDataAdapter dataAdapter = null;
                string consultaHojaExcel = "select * from [" + hoja + "$]";

                string cadenaConexionArchivoExcel = "provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + archivo + "';Extended Properties=Excel 12.0;";

                if (string.IsNullOrEmpty(hoja))
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
            catch
            {
                OleDbConnection conexion = null;
                DataSet dataSet = null;
                OleDbDataAdapter dataAdapter = null;
                string consultaHojaExcel = "select * from [" + hoja + "$]";

                conexion = null;
                dataSet = null;
                dataAdapter = null;
                consultaHojaExcel = "select * from [" + hoja + "$]";

                string cadenaConexionArchivoExcel = "provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + archivo + "';Extended Properties=Excel 8.0;";

                if (string.IsNullOrEmpty(hoja))
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

                if (string.IsNullOrEmpty(hoja))
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorkerTarea.RunWorkerAsync();
            
        }

        private void backgroundWorkerTarea_DoWork(object sender, DoWorkEventArgs e)
        {
            int progreso = 0;
            pbProceso.Maximum = dgvProductos.RowCount;
            try
            {
                DataTable precios = instProdu.traerProductosProveedores();
                rtbProceso.Text = string.Empty;
                rtbProceso.Text = "[" + DateTime.Now + "] Proceso Iniciado";
                foreach (DataGridViewRow fila in dgvProductos.Rows)
                {

                    instProdu.actualziarMasivaPrecios(fila.Cells [0].Value. ToString(), Math.Round(decimal.Parse(fila.Cells [1].Value.ToString()), 2));
                    rtbProceso.Text += System.Environment.NewLine + "[" + DateTime.Now + "] Procesado Prod: " + fila.Cells[0].Value.ToString();
                progreso++;
                backgroundWorkerTarea.ReportProgress(progreso, DateTime.Now);

            }

                rtbProceso.Text += System.Environment.NewLine + "[" + DateTime.Now + "] Procesado Finalizado";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "CAMBIO DE PRECIOS MASIVO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MessageBox.Show(this, "ACTUALIZACION EXITOSA DE PRECIOS", "CAMBIO DE PRECIOS MASIVO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            estadoInicial();
        }

        private void backgroundWorkerTarea_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbProceso.Value = (e.ProgressPercentage);
        }
    }
}
