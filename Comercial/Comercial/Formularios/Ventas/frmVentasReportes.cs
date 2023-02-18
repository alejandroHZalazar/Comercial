using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Comercial.Formularios.Ventas
{
    public partial class frmVentasReportes : Form
    {
        public frmVentasReportes()
        {
            InitializeComponent();
        }

        Clases.ClassClientes instClie = new Clases.ClassClientes();
        Clases.ClassVentas instVentas = new Clases.ClassVentas();

        int cantDec = Clases.ClassProductos.cantDecimales();
        int cantStock = Clases.ClassProductos.cantDecimalesStock();

        private void frmVentasReportes_Load(object sender, EventArgs e)
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
            dgvVentasCabecera.DataSource = null;
            dgvDetalle.Rows.Clear();
            dgvVentasCabecera.Rows.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            estadoInicial();
            string unFiltro = " v.fecha between '" + dtpDesde.Value.Year + "-" + dtpDesde.Value.Month + "-" + dtpDesde.Value.Day + "' and '" + dtpHasta.Value.Year + "-" + dtpHasta.Value.Month + "-" + dtpHasta.Value.Day + " 23:59:59'";

            if (cbCliente .Checked == true)
            { 
                unFiltro = unFiltro + " and v.fk_cliente = " + cboCliente .SelectedValue .ToString ();
            }

            dgvVentasCabecera.DataSource = instVentas.traerTodos(unFiltro);

            if (dgvVentasCabecera .Rows .Count > 0)
            {
                dgvVentasCabecera.Columns["id"].Visible = false;
            }

            redondearEncabezado();
        }

        private void redondearEncabezado()
        {
            if (dgvVentasCabecera.RowCount > 0)
            {
                dgvVentasCabecera.Columns["IVA"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvVentasCabecera.Columns["Total"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvVentasCabecera.Columns["Costo"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvVentasCabecera.Columns["descuento"].DefaultCellStyle.Format = "N" + cantDec.ToString();
            }
            
        }

        private void dgvVentasCabecera_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetalle.DataSource = instVentas.traerTodosDetalles(long.Parse(dgvVentasCabecera.CurrentRow.Cells["id"].Value.ToString()));
            redondearDetalle();
        }

        private void redondearDetalle()
        {
            if(dgvDetalle .RowCount > 0)
            {
                dgvDetalle.Columns["Precio_S_IVA"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvDetalle.Columns["Precio_C_IVA"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvDetalle.Columns["Cantidad"].DefaultCellStyle.Format = "N" + cantStock .ToString();
                dgvDetalle.Columns["Subtotal"].DefaultCellStyle.Format = "N" + cantDec.ToString();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dgvVentasCabecera .Rows .Count > 0)
            {
                Reportes.frmReport unFrmReport = new Reportes.frmReport();

                unFrmReport.nombreReporte = "ReportVenta.rdlc";
                List<string> var = new List<string>();
                var.Add(dgvVentasCabecera.CurrentRow.Cells["id"].Value.ToString());
                var.Add(Clases.ClassValidacion.traerEmpresa());
                var.Add("Tel: " + Clases.ClassValidacion.traerEmpresaTelefono());
                var.Add(Clases.ClassValidacion.traerEmpresaDireccion());
                var.Add(Clases.ClassValidacion.traerEmpresaCiudad());
                var.Add("CUIT: " + Clases.ClassValidacion.traerEmpresaCuit());
                var.Add(dgvVentasCabecera.CurrentRow.Cells["IVA"].Value.ToString());
                var.Add(cantDec.ToString());
                var.Add(cantStock.ToString());
                var.Add(Clases.ClassValidacion.traerRazonSocial());
                unFrmReport.variable = var;
                unFrmReport.ShowDialog();
            }
        }
    }
}