using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Comercial.Formularios.Estadisticas
{
    public partial class frmRankingVentas : Form
    {
        int cantDec = Clases.ClassProductos.cantDecimales();
        int cantStock = Clases.ClassProductos.cantDecimalesStock();

        public frmRankingVentas()
        {
            InitializeComponent();
        }

        private void btnRankingProductos_Click(object sender, EventArgs e)
        {
            dgvRanking.DataSource = null;
            dgvRanking.Rows.Clear();
            Clases.ClassEstadisticas instEstadist = new Clases.ClassEstadisticas();
            dgvRanking.DataSource = instEstadist.traerVentasRankingProductos(DateTime.Parse(dtpDesde.Value.Year + "-" + dtpDesde.Value.Month + "-" + dtpDesde.Value.Day), DateTime.Parse(dtpHasta.Value.Year + "-" + dtpHasta.Value.Month + "-" + dtpHasta.Value.Day + " 23:59:59"));
        }

        private void btnRankigCliente_Click(object sender, EventArgs e)
        {
            dgvRanking.DataSource = null;
            dgvRanking.Rows.Clear();
            Clases.ClassEstadisticas instEstadist = new Clases.ClassEstadisticas();
            dgvRanking.DataSource = instEstadist.traerVentasRankingClientes(DateTime .Parse (  dtpDesde.Value.Year + "-" + dtpDesde.Value.Month + "-" + dtpDesde.Value.Day) ,DateTime .Parse ( dtpHasta.Value.Year + "-" + dtpHasta.Value.Month + "-" + dtpHasta.Value.Day + " 23:59:59"));
            redondearGrilla();
        }

        private void redondearGrilla()
        {
            if (dgvRanking.RowCount > 0)
            {
                dgvRanking.Columns["Ventas"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                
            }
        }
    }
}
