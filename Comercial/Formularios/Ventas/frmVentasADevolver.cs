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
    public partial class frmVentasADevolver : Form
    {
        private frmDevolucion frmDevolucion;
        public Form llamador;
        int cantDec = Clases.ClassProductos.cantDecimales();
        int cantStock = Clases.ClassProductos.cantDecimalesStock();

        public frmVentasADevolver()
        {
            InitializeComponent();
        }

        public frmVentasADevolver(frmDevolucion frmDevolucion)
        {
            this.frmDevolucion = frmDevolucion;
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Clases.ClassVentas instVentas = new Clases.ClassVentas();
            estadoInicial();
            string filtro;
            txtTotalActual.Text = string.Empty;
            dgvVenta.DataSource = null;
            dgvProductos.DataSource = null;
            dgvVenta.Rows.Clear();
            dgvProductos.Rows.Clear();
            filtro = " where v.fecha between '" + dtpDesde.Value.Year + "-" + dtpDesde.Value.Month.ToString ("D2") + "-" + dtpDesde.Value.Day.ToString ("D2") + "' and '" + dtpHasta.Value.Year + "-" + dtpHasta.Value.Month.ToString("D2") + "-" + dtpHasta.Value.Day.ToString("D2") + " 23:59:59'";
            if (cboVendedores.SelectedValue.ToString() != "0")
            {
                filtro += " and v.fk_vendedor = " + cboVendedores.SelectedValue.ToString();
            }
           dgvVenta.DataSource = instVentas.traerVentasParaDevolver (filtro);
            dgvVenta.Columns["id"].Visible = false;
            dgvVenta.Columns["fk_cliente"].Visible = false;
            dgvVenta.Columns["fk_vendedor"].Visible = false;
            redondearCabecera();
            dgvVenta.Focus();
        }

        private void redondearCabecera()
        {
            if (dgvVenta.RowCount > 0)
            {
                dgvVenta.Columns["IVA"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvVenta.Columns["Recargo"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvVenta.Columns["Descuento"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvVenta.Columns["Total_Venta"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvVenta.Columns["totalCosto"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvVenta.Columns["Comision"].DefaultCellStyle.Format = "N" + cantDec.ToString();
            }
        }

        private void estadoInicial()
        {
            dgvVenta.DataSource = null;
            dgvVenta.Rows.Clear();
            dgvProductos.DataSource = null;
            dgvProductos.Rows.Clear();
            lblClienteNombre.Text = string.Empty;
            lblDir.Text = string.Empty;
            lblLocalidad.Text = string.Empty;
            lblProv.Text = string.Empty;
            lblTel.Text = string.Empty;
            lblEncargado.Text = string.Empty;
        }

        private void frmVentasADevolver_Load(object sender, EventArgs e)
        {
            Clases.classUsuarios instUsuario = new Clases.classUsuarios();
            estadoInicial();
            cboVendedores.DataSource = instUsuario.traerUsuariosActivos();
            cboVendedores.ValueMember = "id";
            cboVendedores.DisplayMember = "nombre";
            cboVendedores.SelectedIndex = 0;
        }

        private void dgvVenta_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Clases.ClassVentas instVentas = new Clases.ClassVentas();
            Clases.ClassClientes instClie = new Clases.ClassClientes();
            DataTable detalle = instVentas.traerDetalleVentaADevolver (long.Parse(dgvVenta.CurrentRow.Cells["id"].Value.ToString()));
            dgvProductos.DataSource = detalle;
            dgvProductos.Columns["linea"].Visible = false;
            dgvProductos.Columns["fk_venta"].Visible = false;
            dgvProductos.Columns["fk_producto"].Visible = false;
            dgvProductos.Columns["costo"].Visible = false;
            dgvProductos.Columns["Stock"].Visible = false;

            txtTotalActual.Text = Math.Round(decimal.Parse(dgvVenta.CurrentRow.Cells["Total_Venta"].Value.ToString()), cantDec).ToString();
            DataTable cliente = instClie.traerDatosVenta(" and c.id = " + dgvVenta.CurrentRow.Cells["fk_cliente"].Value.ToString());
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
                dgvProductos.Columns["Precio S/IVA"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvProductos.Columns["Precio C/IVA"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvProductos.Columns["Cantidad"].DefaultCellStyle.Format = "N" + cantStock.ToString();
                dgvProductos.Columns["Subtotal"].DefaultCellStyle.Format = "N" + cantDec.ToString();
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvVenta.RowCount > 0)
            {
                ((frmDevolucion)this.llamador).cargarDatosCliente(1, int.Parse(dgvVenta.CurrentRow.Cells["fk_cliente"].Value.ToString()));
                ((frmDevolucion)this.llamador).unCliente = int.Parse(dgvVenta.CurrentRow.Cells["fk_cliente"].Value.ToString());
                ((frmDevolucion)this.llamador).cargarVenta(int.Parse(dgvVenta.CurrentRow.Cells["id"].Value.ToString()), decimal.Parse(dgvVenta.CurrentRow.Cells["IVA"].Value.ToString()), decimal.Parse(dgvVenta.CurrentRow.Cells["Descuento"].Value.ToString()), decimal.Parse(dgvVenta.CurrentRow.Cells["Recargo"].Value.ToString()), int.Parse(dgvVenta.CurrentRow.Cells["fk_vendedor"].Value.ToString()), decimal.Parse(dgvVenta.CurrentRow.Cells["Comision"].Value.ToString()));
                this.Close();
            }
        }
    }
}
