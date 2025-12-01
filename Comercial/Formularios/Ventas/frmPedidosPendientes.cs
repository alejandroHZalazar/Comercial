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
    public partial class frmPedidosPendientes : Form
    {
        Clases.classUsuarios instUsuario = new Clases.classUsuarios();
        Clases.ClassPedidos instPed = new Clases.ClassPedidos();
        Clases.ClassClientes instClie = new Clases.ClassClientes();
        public Form llamador;
        private frmVentas frmVentas;
        int cantDec = Clases.ClassProductos.cantDecimales();
        int cantStock = Clases.ClassProductos.cantDecimalesStock();
        public string filtro;
        public int position;
        public bool buscarYa;
       

        public frmPedidosPendientes()
        {
            InitializeComponent();
        }

        public frmPedidosPendientes(frmVentas frmVentas)
        {
            InitializeComponent();
            this.frmVentas = frmVentas;
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
        }

        private void frmPedidosPendientes_Load(object sender, EventArgs e)
        {
            estadoInicial();
            cboVendedores.DataSource = instUsuario.traerUsuariosActivos();
            cboVendedores.ValueMember = "id";
            cboVendedores.DisplayMember = "nombre";
            cboVendedores.SelectedIndex = 0;

            if (buscarYa )
            {
                btnBuscar_Click(null, null);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            estadoInicial();
            
            txtTotalActual.Text = string.Empty;
            dgvOrden.DataSource = null;
            dgvProductos.DataSource = null;
            dgvOrden.Rows.Clear();
            dgvProductos.Rows.Clear();

            if (buscarYa == false)
            {
                filtro = " fecha between '" + dtpDesde.Value.Year + "-" + dtpDesde.Value.Month.ToString() + "-" + dtpDesde.Value.Day.ToString() + "' and '" + dtpHasta.Value.Year + "-" + dtpHasta.Value.Month + "-" + dtpHasta.Value.Day + " 23:59:59'";
                if (cboVendedores.SelectedValue.ToString() != "0")
                {
                    filtro += " and p.fk_vendedor = " + cboVendedores.SelectedValue.ToString();
                }
            }
            dgvOrden.DataSource = instPed.traerCabeceraPendientes(filtro);
            dgvOrden.Columns["id"].Visible = false;
            dgvOrden.Columns["fk_cliente"].Visible = false;
            dgvOrden.Columns["observacion"].Visible = false;
            redondearCabecera();
            if (buscarYa & dgvOrden .RowCount > 0)
            {
                dgvOrden.Rows[position].Selected = true;
                dgvOrden.FirstDisplayedScrollingRowIndex = position;
            }
            dgvOrden.Focus();
            
        }

        private void redondearCabecera()
        {
            if (dgvOrden.RowCount> 0)
            {
                dgvOrden.Columns["IVA"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvOrden.Columns["Recargo"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvOrden.Columns["Descuento"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvOrden.Columns["total"].DefaultCellStyle.Format = "N" + cantDec.ToString();
            }
        }

        private void dgvOrden_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataTable detalle = instPed.traerDetallePendientes(int.Parse(dgvOrden.CurrentRow.Cells["id"].Value.ToString()));
            dgvProductos.DataSource = detalle;
            dgvProductos.Columns["linea"].Visible = false;
            dgvProductos.Columns["fk_pedido"].Visible = false;
            dgvProductos.Columns["fk_producto"].Visible = false;
            dgvProductos.Columns["costo"].Visible = false;
            dgvProductos.Columns["precioOrig"].Visible = false;
            dgvProductos.Columns["Stock"].Visible = false;

            txtTotalActual.Text = Math .Round (decimal.Parse (dgvOrden.CurrentRow.Cells["total"].Value.ToString()),cantDec ).ToString ();
            DataTable cliente = instClie.traerDatosVenta(" and c.id = " + dgvOrden.CurrentRow.Cells["fk_cliente"].Value.ToString());
            lblClienteNombre.Text = cliente.Rows[0]["Nombre_Comercial"].ToString();
            lblDir.Text = cliente.Rows[0]["Dir"].ToString();
            lblLocalidad.Text = cliente.Rows[0]["Localidad"].ToString();
            lblProv.Text = cliente.Rows[0]["Provincia"].ToString();
            lblTel.Text = cliente.Rows[0]["Tel"].ToString();
            lblEncargado.Text = cliente.Rows[0]["contacto"].ToString();
            rtbObserv .Text = dgvOrden.CurrentRow.Cells["observacion"].Value .ToString ();
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
            if (dgvOrden .RowCount > 0)
            {
                ((frmVentas)this.llamador).cargarDatosCliente (1,int.Parse(dgvOrden.CurrentRow.Cells["fk_cliente"].Value.ToString()));
                ((frmVentas)this.llamador).unCliente = int.Parse(dgvOrden.CurrentRow.Cells["fk_cliente"].Value.ToString());
                ((frmVentas )this.llamador).cargarPedidoPendiente (int.Parse(dgvOrden.CurrentRow.Cells["id"].Value.ToString()),decimal .Parse (dgvOrden .CurrentRow .Cells ["IVA"].Value .ToString ()),decimal .Parse (dgvOrden.CurrentRow.Cells["Descuento"].Value.ToString()),decimal .Parse (dgvOrden.CurrentRow.Cells["Recargo"].Value.ToString()));
                ((frmVentas)this.llamador).filtro = this.filtro;
                ((frmVentas)this.llamador).pos = dgvOrden.CurrentRow.Index;
                ((frmVentas)this.llamador).buscoPend = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            instPed.eliminarPedido(int.Parse(dgvOrden.CurrentRow.Cells["id"].Value.ToString()));
            btnBuscar_Click(null, null);

        }
    }
}
