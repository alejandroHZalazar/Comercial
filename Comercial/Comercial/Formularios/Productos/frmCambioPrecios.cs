using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comercial.Formularios.Productos
{
    public partial class frmCambioPrecios : Form
    {
        bool cargado = false;
        public frmCambioPrecios()
        {
            InitializeComponent();
        }

        private void frmCambioPrecios_Load(object sender, EventArgs e)
        {
            cargarCombos();
            estadoInicial();
            cargado = true;
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void cargarCombos()
        {
            Clases.ClassProveedores instProv = new Clases.ClassProveedores();
            Clases.ClassConfiguracion instConfig = new Clases.ClassConfiguracion();


            cboProveedores.DataSource = instProv.traeProveedoresCabecera();
            cboProveedores.ValueMember = "Cod";
            cboProveedores.DisplayMember = "Proveedor";
            cboRubros.DataSource = instConfig.traeRubros();
            cboRubros.ValueMember = "id";
            cboRubros.DisplayMember = "descripcion";

            DataTable tiposMov = new DataTable();
            tiposMov.Columns.Add("id");
            tiposMov.Columns.Add("nombre");

            DataRow fila = tiposMov.NewRow();
            fila["id"] = "1";
            fila["nombre"] = "Aumento";
            tiposMov.Rows.Add(fila);

            fila = tiposMov.NewRow();
            fila["id"] = "-1";
            fila["nombre"] = "Rebaja";
            tiposMov.Rows.Add(fila);

            cboTipo.DataSource = tiposMov;
            cboTipo.ValueMember = "id";
            cboTipo.DisplayMember = "nombre";
        }

        private void estadoInicial()
        {
            cboProveedores.SelectedIndex = 0;
            cboRubros.SelectedIndex = 0;
            dgvProductos.Rows.Clear();
            nudValor.Value = 0;
        }

        private void redondearColumnas()
        {
            int cantDec = Clases.ClassProductos.cantDecimales();
            
            dgvProductos .Columns["P_Prov"].DefaultCellStyle.Format = "N" + cantDec .ToString();
            dgvProductos.Columns["P_SIVA"].DefaultCellStyle.Format = "N" + cantDec.ToString();
            dgvProductos.Columns["Costo"].DefaultCellStyle.Format = "N" + cantDec.ToString();
            dgvProductos.Columns["P_Prov_M"].DefaultCellStyle.Format = "N" + cantDec.ToString();
            dgvProductos.Columns["P_SIVA_M"].DefaultCellStyle.Format = "N" + cantDec.ToString();
            dgvProductos.Columns["Costo_M"].DefaultCellStyle.Format = "N" + cantDec.ToString();

        }

        private void calcularNuevosPrecios()
        {
            
            if (cargado)
            {
                
                foreach (DataGridViewRow fila in dgvProductos.Rows)
                {
                    fila.Cells["P_Prov_M"].Value = decimal.Parse(fila.Cells["P_Prov"].Value.ToString()) *  ((100 + (nudValor.Value * decimal.Parse(cboTipo.SelectedValue.ToString()))) / 100);
                    fila.Cells["P_SIVA_M"].Value = decimal.Parse(fila.Cells["P_SIVA"].Value.ToString()) * ((100 + (nudValor.Value * decimal.Parse(cboTipo.SelectedValue.ToString()))) / 100);
                    fila.Cells["Costo_M"].Value = decimal.Parse(fila.Cells["Costo"].Value.ToString()) * ((100 + (nudValor.Value * decimal.Parse(cboTipo.SelectedValue.ToString()))) / 100);
                } 
                formatoGrilla();
                redondearColumnas();
            }
        }

        private void formatoGrilla()
        {
            dgvProductos.Columns["P_Prov_M"].DefaultCellStyle.BackColor = Color.LightGreen;
            dgvProductos.Columns["P_SIVA_M"].DefaultCellStyle.BackColor = Color.LightGreen;
            dgvProductos.Columns["Costo_M"].DefaultCellStyle.BackColor = Color.LightGreen;
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            Clases.ClassProductos instProd = new Clases.ClassProductos();

            string unFiltro = string.Empty;

            if (cbProveedor .Checked )
            {
                unFiltro = " where p.fk_proveedor = " + cboProveedores.SelectedValue.ToString();                 
            }

            if (cbRubros .Checked )
            {
                unFiltro = (unFiltro == string.Empty ? unFiltro = " where p.fk_Rubro = " + cboRubros.SelectedValue.ToString() : unFiltro += " and p.fk_Rubro = " + cboRubros.SelectedValue.ToString());
            }

            dgvProductos.DataSource = instProd.traeParaCambiarPrecio(unFiltro);
            calcularNuevosPrecios();
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            calcularNuevosPrecios();
        }

        private void nudValor_ValueChanged(object sender, EventArgs e)
        {
            calcularNuevosPrecios();
        }

        private void btnCambioPrecios_Click(object sender, EventArgs e)
        {
            backgroundTarea.RunWorkerAsync();
        }

        private void backgroundTarea_DoWork(object sender, DoWorkEventArgs e)
        {
            dgvProductos.Enabled = false;
            rtbObserv.Text = string.Empty;
            rtbObserv.Text = "[" + DateTime.Now + "] Proceso Iniciado";
            Clases.ClassProductos instProd = new Clases.ClassProductos();

            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {
                try
                {
                    instProd.actualziarMasivaPrecios(fila.Cells["Cod_Prov"].Value.ToString(), decimal.Parse(fila.Cells["P_Prov_M"].Value.ToString()));
                    rtbObserv.Text += System.Environment.NewLine + "[" + DateTime.Now + "] Procesado Prod: " + fila.Cells["Cod_Prov"].Value.ToString();
                }
                catch
                {
                    rtbObserv.Text += System.Environment.NewLine + "[" + DateTime.Now + "] Error Prod: " + fila.Cells["Cod_Prov"].Value.ToString();
                }
            }

            rtbObserv.Text += System.Environment.NewLine + "[" + DateTime.Now + "] Procesado Finalizado";
            MessageBox.Show(this, "Cambio de Precio Finalizado. Verifique en el cuadro de resultados los errores", "Cambio de Precios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            dgvProductos.Enabled = true;
        }
    }
}
