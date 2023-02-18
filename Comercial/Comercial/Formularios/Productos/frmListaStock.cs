using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Comercial.Formularios.Productos
{
    public partial class frmListaStock : Form
    {
        int cantDec = Clases.ClassProductos.cantDecimales();
        int cantStock = Clases.ClassProductos.cantDecimalesStock();

        public frmListaStock()
        {
            InitializeComponent();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Clases.ClassConfiguracion instConfig = new Clases.ClassConfiguracion ();
            Reportes.frmReport unFrmReport = new Reportes.frmReport();
            unFrmReport.nombreReporte = "ReportProductosStock.rdlc";
            List<string> var = new List<string>();
            var.Add(obtenerFiltro ());
            var.Add(Clases.ClassValidacion.traerEmpresa());
            var.Add(cantDec.ToString());
            var.Add(cantStock.ToString());
            unFrmReport.variable = var;
            unFrmReport.ShowDialog();

        }

        private string obtenerFiltro ()
        {
            string filtro = string.Empty;
            
                if (cbProveedor.Checked)
                {
                    filtro += " and pr.id = " + cboProveedores.SelectedValue.ToString();
                }

                if (cbRubros.Checked)
                {
                    
                    
                        filtro += " and r.id = " + cboRubros.SelectedValue.ToString();
                                 
                }

            
            return filtro;
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            Clases.ClassProductos instProductos = new Clases.ClassProductos();
            dgvProductos.DataSource = null;
            dgvProductos.Rows.Clear();
            nudCosto.Value = 0;
            nudVenta.Value = 0;

            dgvProductos.DataSource = instProductos.traeProductosStock (obtenerFiltro());

            if (dgvProductos .RowCount > 0)
            {
                redondearColumnas();
                obtenerTotales();
            }
        }

        private void obtenerTotales ()
        {
            decimal costo = 0;
            decimal venta = 0;

            foreach (DataGridViewRow fila in dgvProductos .Rows )
            {
                // costo += decimal.Parse(fila.Cells["Stock"].Value.ToString()) >= 0 ?decimal.Parse(fila.Cells["Costo"].Value.ToString()) * decimal.Parse(fila.Cells["Stock"].Value.ToString()):0;
                //venta += decimal.Parse(fila.Cells["Stock"].Value.ToString()) >= 0 ?decimal.Parse(fila.Cells["P_Lista"].Value.ToString()) * decimal.Parse(fila.Cells["Stock"].Value.ToString()):0;
                costo += decimal.Parse(fila.Cells["Costo"].Value.ToString()) * decimal.Parse(fila.Cells["Stock"].Value.ToString());
                venta += decimal.Parse(fila.Cells["P_Lista"].Value.ToString()) * decimal.Parse(fila.Cells["Stock"].Value.ToString());
            }

            nudCosto.Value = Math.Round(costo, cantDec);
            nudVenta.Value = Math.Round(venta, cantDec);
        }

        private void redondearColumnas()
        {
            dgvProductos.Columns["Stock"].DefaultCellStyle.Format = "N"+cantStock .ToString ();
            dgvProductos.Columns["C_Min"].DefaultCellStyle.Format = "N" + cantStock.ToString();
            dgvProductos.Columns["Costo"].DefaultCellStyle.Format = "N" + cantDec.ToString();
            dgvProductos.Columns["P_Prov"].DefaultCellStyle.Format = "N" + cantDec.ToString();
            dgvProductos.Columns["P_Prov"].DefaultCellStyle.Format = "N" + cantDec.ToString();
            dgvProductos.Columns["P_Lista"].DefaultCellStyle.Format = "N" + cantDec.ToString();
        }

        private void frmListaStock_Load(object sender, EventArgs e)
        {
            Clases.ClassProveedores instProv = new Clases.ClassProveedores();
            Clases.ClassConfiguracion instConfig = new Clases.ClassConfiguracion();


            cboProveedores.DataSource = instProv.traeProveedoresCabecera ();
            cboProveedores.ValueMember = "Cod";
            cboProveedores.DisplayMember = "Proveedor";
            cboRubros.DataSource = instConfig.traeRubros();
            cboRubros.ValueMember = "id";
            cboRubros.DisplayMember = "descripcion";

            cboProveedores.SelectedIndex = 0;
            cboRubros.SelectedIndex = 0;
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
