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
    public partial class frmMovimientoProductos : Form
    {
        int cantStock = Clases.ClassProductos.cantDecimalesStock();
        public frmMovimientoProductos()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Clases.ClassProductos instProd = new Clases.ClassProductos();
            dgvMov.DataSource = null;
            dgvMov.Rows.Clear();
            
            string filtro = " m.fechaMov between '" + dtpDesde.Value.Year + "-" + dtpDesde.Value.Month + "-" + dtpDesde.Value.Day + "' and '" + dtpHasta.Value.Year + "-" + dtpHasta.Value.Month + "-" + dtpHasta.Value.Day + " 23:59:59' ";

            if (txtProd .Text != string .Empty )
            {
                filtro += " and p.codProveedor = '" + txtProd.Text + "'";
            }

            dgvMov.DataSource = instProd.traeMovimientoProductos(filtro);
            redondearGrilla();

        }

        private void redondearGrilla()
        {
            if (dgvMov.RowCount > 0)
            {
                dgvMov.Columns["Cant"].DefaultCellStyle.Format = "N" + cantStock.ToString();
                dgvMov.Columns["Stock_Ant"].DefaultCellStyle.Format = "N" + cantStock.ToString();
                dgvMov.Columns["Stock_Act"].DefaultCellStyle.Format = "N" + cantStock.ToString();

            }

        }

        private void txtProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Clases.ClassValidacion.soloNumeros(e);
        }

        private void txtProd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData  == Keys.Enter)
            {
                btnBuscar_Click(null, null);
            }
        }
    }
}
 