using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Comercial.Formularios.Productos;

namespace Comercial.Formularios.Proveedores
{
    public partial class frmNotaPedidosPendientes : Form
    {
        public int unProveedor;
        Clases.ClassProveedores instProv = new Clases.ClassProveedores();
        private frmIngresoMercaderia frmIngresoMercaderia;
        public Form llamador;
        int cantDec = Clases.ClassProductos.cantDecimales();
        int cantStock = Clases.ClassProductos.cantDecimalesStock();

        public frmNotaPedidosPendientes()
        {
            InitializeComponent();
        }

        public frmNotaPedidosPendientes(frmIngresoMercaderia frmIngresoMercaderia)
        {
            this.frmIngresoMercaderia = frmIngresoMercaderia;
            InitializeComponent();
        }

        private void dgvOrden_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmNotaPedidosPendientes_Load(object sender, EventArgs e)
        {
            dgvOrden.Rows.Clear();
            dgvProductos.Rows.Clear(); 
            dgvOrden.DataSource = instProv.traerPedidosPendientes(" and o.fk_proveedor = " + unProveedor);
            lblNomProveedor.Text = instProv.traerNombreProveedor(unProveedor);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtCostoAct.Text = string.Empty;
            dgvOrden.DataSource = null;
            dgvProductos.DataSource = null;
            dgvOrden.Rows.Clear();
            dgvProductos.Rows.Clear();
            dgvOrden.DataSource = instProv.traerPedidosPendientes(" and o.fk_proveedor = " + unProveedor + " and fecha between '" + dtpDesde.Value.Year + "-" + dtpDesde.Value.Month + "-" + dtpDesde.Value.Day + "' and '" + dtpHasta.Value.Year + "-" + dtpHasta.Value.Month + "-" + dtpHasta.Value.Day + " 23:59:59'");
            
        }

        private void redondearCabecera()
        {
            
        }
        private void dgvOrden_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataTable detalle = instProv.traerDetallePedidosPendientes(long.Parse(dgvOrden.CurrentRow.Cells["id"].Value.ToString()));
            dgvProductos.DataSource = detalle;
            dgvProductos.Columns["linea"].Visible = false;
           
            txtCostoAct.Text = (detalle.Compute("SUM(Subtotal)","Subtotal > 0")).ToString ();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvOrden .RowCount > 0)
            {
                ((frmIngresoMercaderia)this.llamador).cargarNotaPedido( long.Parse(dgvOrden.CurrentRow.Cells["id"].Value.ToString()));
                this.Close();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dgvOrden.Rows.Count > 0)
            {
                Reportes.frmReport unFrmReport = new Reportes.frmReport();
               // unFrmReport.titulo = "Nota de Pedido";
                unFrmReport.nombreReporte = "ReportOrdenCompra.rdlc";
                List<string> var = new List<string>();
                var.Add(dgvOrden .CurrentRow .Cells ["id"].Value .ToString ());
                var.Add(Clases.ClassValidacion.traerEmpresa());
                var.Add(cantDec.ToString());
                var.Add(cantStock.ToString());
                unFrmReport.variable = var;
                unFrmReport.ShowDialog();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            instProv.eliminarOrdenCompra(dgvOrden.CurrentRow.Cells["id"].Value.ToString());
            MessageBox.Show(this, "Orden de Compra eliminada con éxito!!", "ORDEN DE COMPRA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnBuscar_Click(null, null);
        }
    }
}
