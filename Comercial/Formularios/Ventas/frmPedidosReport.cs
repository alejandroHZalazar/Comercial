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
    public partial class frmPedidosReport : Form
    {
        public frmPedidosReport()
        {
            InitializeComponent();
        }

       
        Clases.ClassPedidos instPedidos = new Clases.ClassPedidos();
        Clases.ClassClientes instClie = new Clases.ClassClientes();

        int cantDec = Clases.ClassProductos.cantDecimales();
        int cantStock = Clases.ClassProductos.cantDecimalesStock();

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            estadoInicial();
            dgvOrden.DataSource = null;
            dgvProductos.DataSource = null;
            dgvOrden.Rows.Clear();
            dgvProductos.Rows.Clear();
            string filtro = " fecha between '" + dtpDesde.Value.Year + "-" + dtpDesde.Value.Month + "-" + dtpDesde.Value.Day + "' and '" + dtpHasta.Value.Year + "-" + dtpHasta.Value.Month + "-" + dtpHasta.Value.Day + " 23:59:59'";

            if (cbVendedor.Checked == true)
            {
                filtro += " and p.fk_vendedor = " + cboVendedores.SelectedValue.ToString();
            }


            dgvOrden.DataSource = instPedidos.traerTodosPedidos(filtro);
           

            dgvOrden.Columns["id"].Visible = false;
            dgvOrden.Columns["fk_cliente"].Visible = false;
            dgvOrden.Columns["observacion"].Visible = false;
            dgvOrden.Focus();
            redondearCabecera();

        }

        private void redondearCabecera()
        {
            if (dgvOrden.RowCount > 0)
            {
                dgvOrden.Columns["IVA"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvOrden.Columns["Recargo"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvOrden.Columns["Descuento"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvOrden.Columns["total"].DefaultCellStyle.Format = "N" + cantDec.ToString();
            }
        }

        private void estadoInicial()
        {
            dgvOrden.DataSource = null;
            dgvOrden.Rows.Clear();
            dgvProductos.DataSource = null;
            dgvProductos.Rows.Clear();
            lblClienteNombre.Text = string.Empty;
            lblDir.Text = string.Empty;
            lblLocalidad.Text = string.Empty;
            lblProv.Text = string.Empty;
            lblTel.Text = string.Empty;
            lblEncargado.Text = string.Empty;
            rtbObserv.Text = string.Empty;
        }

        private void frmPedidosReport_Load(object sender, EventArgs e)
        {
            estadoInicial();
            cboVendedores.DataSource = instClie .traerVendedores();
            cboVendedores.ValueMember = "id";
            cboVendedores.DisplayMember = "nombre";
            cboVendedores.SelectedIndex = 0;
        }

        private void dgvOrden_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvProductos.DataSource = instPedidos .traerTodosDetalles(int.Parse(dgvOrden.CurrentRow.Cells["id"].Value.ToString()));
            dgvProductos.Columns["linea"].Visible = false;
            dgvProductos.Columns["fk_pedido"].Visible = false;
            dgvProductos.Columns["fk_producto"].Visible = false;
            dgvProductos.Columns["costo"].Visible = false;
            dgvProductos.Columns["precioOrig"].Visible = false;
            rtbObserv.Text = dgvOrden.CurrentRow.Cells["observacion"].Value.ToString();
            DataTable cliente = instClie.traerDatosVenta(" and c.id = " + dgvOrden.CurrentRow.Cells["fk_cliente"].Value.ToString());


            lblClienteNombre.Text = cliente.Rows[0]["Nombre_Comercial"].ToString();
            lblDir.Text = cliente.Rows[0]["Dir"].ToString();
            lblLocalidad.Text = cliente.Rows[0]["Localidad"].ToString();
            lblProv.Text = cliente.Rows[0]["Provincia"].ToString();
            lblTel.Text = cliente.Rows[0]["Tel"].ToString();
            lblEncargado.Text = cliente.Rows[0]["contacto"].ToString();

            redondearDetalle();

        }

        private void redondearDetalle()
        { 
        if (dgvProductos.RowCount > 0)
            {
                dgvProductos.Columns["Stock"].DefaultCellStyle.Format = "N" + cantStock.ToString();
                dgvProductos.Columns["Precio S/IVA"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvProductos.Columns["Precio C/IVA"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvProductos.Columns["Cantidad"].DefaultCellStyle.Format = "N" + cantStock.ToString();
                dgvProductos.Columns["Subtotal"].DefaultCellStyle.Format = "N" + cantDec.ToString();
            }
           
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dgvOrden .Rows.Count > 0)
            {
                Reportes.frmReport unFrmReport = new Reportes.frmReport();

                unFrmReport.nombreReporte = "ReportPedidos.rdlc";
                List<string> var = new List<string>();
                var.Add(dgvOrden .CurrentRow .Cells["id"].Value .ToString () );
                var.Add(Clases.ClassValidacion.traerEmpresa());
                var.Add("Tel: " + Clases.ClassValidacion.traerEmpresaTelefono());
                var.Add(Clases.ClassValidacion.traerEmpresaDireccion());
                var.Add(Clases.ClassValidacion.traerEmpresaCiudad());
                var.Add(dgvOrden.CurrentRow.Cells["Cliente"].Value.ToString());
                var.Add(cantDec.ToString());
                var.Add(cantStock.ToString());
                var.Add(lblDir.Text + ". " + lblLocalidad.Text + ". " + lblProv.Text);
                var.Add(lblTel .Text );
                unFrmReport.variable = var;
                unFrmReport.ShowDialog();
                instPedidos.marcarPedido(int.Parse(dgvOrden.CurrentRow.Cells["id"].Value.ToString()), 2);
            }
        }
    }
}
