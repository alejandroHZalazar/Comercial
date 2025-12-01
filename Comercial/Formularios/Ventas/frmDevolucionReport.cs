using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comercial.Formularios.Ventas
{
    public partial class frmDevolucionReport : Form
    {
        public frmDevolucionReport()
        {
            InitializeComponent();
        }

        Clases.ClassClientes instClie = new Clases.ClassClientes();
        Clases.ClassVentas instVentas = new Clases.ClassVentas();

        int cantDec = Clases.ClassProductos.cantDecimales();
        int cantStock = Clases.ClassProductos.cantDecimalesStock();

        private void frmDevolucionReport_Load(object sender, EventArgs e)
        {
            estadoInicial();
            cboCliente.DataSource = instClie.buscarAVender();
            cboCliente.DisplayMember = "Completo";
            cboCliente.ValueMember = "ID";
            cboCliente.SelectedIndex = 0;
        }

        private void estadoInicial()
        {
            dgvDetalle.DataSource = null;
            dgvDevCabecera.DataSource = null;
            dgvDetalle.Rows.Clear();
            dgvDevCabecera.Rows.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            estadoInicial();
            string unFiltro = " d.fecha between '" + dtpDesde.Value.Year + "-" + dtpDesde.Value.Month + "-" + dtpDesde.Value.Day + "' and '" + dtpHasta.Value.Year + "-" + dtpHasta.Value.Month + "-" + dtpHasta.Value.Day + " 23:59:59'";

            if (cbCliente.Checked == true)
            {
                unFiltro = unFiltro + " and d.fk_cliente = " + cboCliente.SelectedValue.ToString();
            }

            dgvDevCabecera.DataSource = instVentas.traerTodosDevolucion(unFiltro);

            if (dgvDevCabecera.Rows.Count > 0)
            {
                dgvDevCabecera.Columns["id"].Visible = false;
                dgvDevCabecera.Select();
            }

            redondearEncabezado();
        }

        private void redondearEncabezado()
        {
            if (dgvDevCabecera.RowCount > 0)
            {
                dgvDevCabecera.Columns["IVA"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvDevCabecera.Columns["Total"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvDevCabecera.Columns["Costo"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvDevCabecera.Columns["descuento"].DefaultCellStyle.Format = "N" + cantDec.ToString();
            }

        }

        private void dgvDevCabecera_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetalle.DataSource = instVentas.traerTodosDetallesDevoluciones (long.Parse(dgvDevCabecera.CurrentRow.Cells["id"].Value.ToString()));
            redondearDetalle();
        }

        private void redondearDetalle()
        {
            if (dgvDetalle.RowCount > 0)
            {
                dgvDetalle.Columns["Precio_S_IVA"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvDetalle.Columns["Precio_C_IVA"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvDetalle.Columns["Cantidad"].DefaultCellStyle.Format = "N" + cantStock.ToString();
                dgvDetalle.Columns["Subtotal"].DefaultCellStyle.Format = "N" + cantDec.ToString();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dgvDevCabecera.Rows.Count > 0)
            {
                Reportes.frmReport unFrmReport = new Reportes.frmReport();

                unFrmReport.nombreReporte = "ReportDevolucion.rdlc";
                List<string> var = new List<string>();
                var.Add(dgvDevCabecera.CurrentRow.Cells["id"].Value.ToString());
                var.Add(Clases.ClassValidacion.traerEmpresa());
                var.Add("Tel: " + Clases.ClassValidacion.traerEmpresaTelefono());
                var.Add(Clases.ClassValidacion.traerEmpresaDireccion());
                var.Add(Clases.ClassValidacion.traerEmpresaCiudad());
                var.Add("CUIT: " + Clases.ClassValidacion.traerEmpresaCuit());
                var.Add(dgvDevCabecera.CurrentRow.Cells["IVA"].Value.ToString());
                var.Add(cantDec.ToString());
                var.Add(cantStock.ToString());
                var.Add(Clases.ClassValidacion.traerRazonSocial());
                unFrmReport.variable = var;
                unFrmReport.ShowDialog();
            }
        }
    }
}
