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
    public partial class frmReporteIngreso : Form
    {
        Clases.ClassProductos instProd = new Clases.ClassProductos();
        int cantDec = Clases.ClassProductos.cantDecimales();
        int cantStock = Clases.ClassProductos.cantDecimalesStock();

        public frmReporteIngreso()
        {
            InitializeComponent();
        }

        private void btnBuscarFecha_Click(object sender, EventArgs e)
        {
            dgvCabecera.DataSource = null;
            dgvDetalle.DataSource = null;
            dgvCabecera.Rows.Clear();
            dgvDetalle.Rows.Clear();
            txtTotal.Text = string.Empty;
            // dgvCabecera.DataSource = instProd.traerLotesIngreso(DateTime.Parse(dtpDesde.Value.Year + "-" + dtpDesde.Value.Month + "-" + dtpDesde.Value.Day), DateTime.Parse(dtpHasta.Value.Year + "-" + dtpHasta.Value.Month + "-" + dtpHasta.Value.Day + " 23:59:59'"),"", 1);
           
            dgvCabecera.DataSource = instProd.traerLotesIngreso(DateTime.Parse(dtpDesde.Value.ToShortDateString()), DateTime.Parse(dtpHasta.Value.ToString().Substring(0, 10) + " 23:59:59"), "", 1);

        }

        private void btnBuscarComp_Click(object sender, EventArgs e)
        {
            dgvCabecera.DataSource = null;
            dgvDetalle.DataSource = null;
            dgvCabecera.Rows.Clear();
            dgvDetalle.Rows.Clear();
            txtTotal.Text = string.Empty;

            if (txtComprobante .Text != string.Empty )
            {
                
                dgvCabecera.DataSource = instProd.traerLotesIngreso(DateTime.Now, DateTime.Now, txtComprobante.Text.Trim(), 2);
              
            }

            
        }

        private void dgvCabecera_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataTable result = instProd.traerDetalleLoteIngreso(dgvCabecera.CurrentRow.Cells["Comprobante"].Value.ToString());
            dgvDetalle.DataSource = result;

            if (result .Rows .Count > 0)
            {
                txtTotal.Text = result.Compute("Sum(P_Proveedor)", "P_Proveedor > 0").ToString();
                redondearGrilla();
            }
        }

        private void redondearGrilla()
        {
            dgvDetalle.Columns["Cantidad"].DefaultCellStyle.Format = "N" + cantStock.ToString();
            dgvDetalle.Columns["Costo"].DefaultCellStyle.Format = "N" + cantDec.ToString();
            dgvDetalle.Columns["P_Venta"].DefaultCellStyle.Format = "N" + cantDec.ToString();
            dgvDetalle.Columns["P_Proveedor"].DefaultCellStyle.Format = "N" + cantDec.ToString();
        }
        
    }
}
