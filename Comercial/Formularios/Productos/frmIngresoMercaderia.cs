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
    public partial class frmIngresoMercaderia : Form
    {
        Clases.ClassProductos instProd = new Clases.ClassProductos();
        Clases.ClassProveedores instProv = new Clases.ClassProveedores();
        bool cargado = false;
        int unProveedor = 0;
        int unTipoBusq = 1;
        int unProducto = 0;
        int cantDec = Clases.ClassProductos.cantDecimales();
        int cantStock = Clases.ClassProductos.cantDecimalesStock();

        private List<string> resgProducto = new List<string>();

        public frmIngresoMercaderia()
        {
            InitializeComponent();
        }

        private void frmIngresoMercaderia_Load(object sender, EventArgs e)
        {
            cargarCombos();
            estadoInicial();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void cargarCombos()
        {
            cboProveedores.DataSource = instProv.traeProveedoresCabecera();
            cboProveedores.ValueMember = "Cod";
            cboProveedores.DisplayMember = "Proveedor";

            cboIVA.DataSource = instProv.traePorcentajeIVA();
            cboIVA.ValueMember = "id";
            cboIVA.DisplayMember = "valor";
            cargado = true;
        }

        private void estadoInicial()
        {
            lblDescripcion.Text = string.Empty;
            lblProveedor.Text = string.Empty;
            dgvIngreso.Rows.Clear();
            lbDesc.Visible = false;
            btnCargarNtaPedido.Enabled = false;
            cboIVA.Enabled = false;
            gbFiltro.Enabled = false;
            dgvIngreso.Enabled = false;
            nudDescuento.Enabled = false;
            nudGanancia.Enabled = false;
            btnGrabar.Enabled = false;
            cboFiltro.SelectedIndex = Clases.ClassParametros.indiceBusqNotaPed();
            cboProveedores.SelectedIndex = -1;
            cboIVA.SelectedIndex = 0;
            txtTotal.Text = "0";
            nudDescuento.Value = 0;
            nudGanancia .Value = 0;
            txtComprobante.Text = string.Empty;
            nudCantidad.DecimalPlaces = cantStock;
            pbProceso.Value = 0;
        }

        private void btnSelProveedor_Click(object sender, EventArgs e)
        {
            if (cboProveedores.SelectedIndex > -1)
            {
                unProveedor = int.Parse(cboProveedores.SelectedValue.ToString());
                estadoConProveedor();
                txtFiltro.Focus();

            }
        }

        private void estadoConProveedor()
        {
            lblDescripcion.Text = string.Empty;
            lblProveedor.Text = cboProveedores.Text;
            dgvIngreso.Rows.Clear();
            lbDesc.Visible = false;
            btnCargarNtaPedido .Enabled = true;
            cboIVA.Enabled = true;
            gbFiltro.Enabled = true;
            dgvIngreso.Enabled = true;
            nudDescuento.Enabled = true;
            nudGanancia .Enabled = true;
            btnGrabar.Enabled = true;
            cboIVA.SelectedIndex = 0;
            cargarProductos();
        }

        private void cargarProductos()
        {
            resgProducto.Clear();
            DataTable productos = instProv.traerProductosProveedor(int.Parse(cboProveedores.SelectedValue.ToString()));

            if (productos.Rows.Count > 0)
            {
                foreach (DataRow fila in productos.Rows)
                {
                    resgProducto.Add(fila["descripcion"].ToString());
                }
            }

        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                buscarProducto();
                unTipoBusq = 1;
                txtFiltro.Text = string.Empty;
            }
        }

        private void buscarProducto()
        {
            DataTable producto = null;

            if (txtFiltro.Text != string.Empty)
            {
                if (cboFiltro.SelectedIndex == 0)
                {
                    producto = instProd.traeProductosPpal(" where baja = 0 and codProveedor = '" + txtFiltro.Text.Trim() + "' and fk_proveedor = " + unProveedor);
                }
                else if (cboFiltro.SelectedIndex == 1)
                {
                    producto = instProd.traeProductosPpal(" where baja = 0 and codBarras = " + txtFiltro.Text.Trim() + " and fk_proveedor = " + unProveedor);
                }
                else

                    producto = instProd.traeProductosPpal(" where baja = 0 and id = " + txtFiltro.Text.Trim() + " and fk_proveedor " + unProveedor);

            }

            if (producto.Rows.Count > 0)
            {
                unProducto = int.Parse(producto.Rows[0]["ID"].ToString());
                lblDescripcion.Text = producto.Rows[0]["Descripcion"].ToString();
                nudCantidad.Focus();
            }
            else
            {
                MessageBox.Show(this, "No existe el producto n°: " + txtFiltro.Text.Trim(), "Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Clases.ClassValidacion.soloNumeros(e);
        }

        private void txtDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                if (lbDesc.Items.Count > -1)
                {
                    lbDesc.SetSelected(0, true);
                    lbDesc.Focus();
                }
            }
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            if (txtDesc.Focused & txtDesc.Text != string.Empty)
            {
                filtrarCargarListBox();
            }
            else
            {
                lbDesc.Visible = false;
            }
        }

        private void filtrarCargarListBox()
        {
            lbDesc.Items.Clear();

            if (txtDesc.Text.Trim().Length == 0)
            {
                lbDesc.Visible = false;
            }

            var result = resgProducto.FindAll(l => l.ToUpper().Contains(txtDesc.Text.Trim().ToUpper()));

            lbDesc.Items.Clear();

            if (result.Count > 0)
            {
                result.ForEach(x => lbDesc.Items.Add(x));
                lbDesc.Visible = true;
            }
        }

        private void lbDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Back)
            {
                txtDesc.Focus();
            }

            if (e.KeyData == Keys.Enter & lbDesc.Items.Count > 0)
            {
                prepararProducto();

            }
        }

        private void lbDesc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            prepararProducto();
        }

        private void prepararProducto()
        {
            DataTable producto = instProd.traeProductosPpal(" where baja = 0 and descripcion = '" + lbDesc.SelectedItem.ToString() + "' and fk_proveedor = " + unProveedor);

            if (producto.Rows.Count > 0)
            {
                unProducto = int.Parse(producto.Rows[0]["ID"].ToString());
                lblDescripcion.Text = producto.Rows[0]["Descripcion"].ToString();
                nudCantidad.Focus();
                lbDesc.Visible = false;
                txtDesc.Text = string.Empty;
                unTipoBusq = 2;
            }
        }

        private void nudCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void nudCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnAgregar_Click(null, null);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (nudCantidad.Value > 0 & unProducto != 0)
            {
                agregarProducto();
                nudCantidad.Value = 0;
                unProducto = 0;
                if (unTipoBusq == 1)
                {
                    txtFiltro.Focus();
                }
                else { txtDesc.Focus(); }
            }
        }


        private void agregarProducto()
        {
            bool band = false;
            foreach (DataGridViewRow fila in dgvIngreso.Rows)
            {
                if (int.Parse(fila.Cells["id"].Value.ToString()) == unProducto)
                {
                    fila.Cells["cantidad"].Value = decimal.Parse(fila.Cells["cantidad"].Value.ToString()) + nudCantidad.Value;
                    band = true;
                    break;
                }
            }

            if (band == false)
            {
                DataTable producto = instProd.traerProductosParaEditar(unProducto);
                if (producto.Rows.Count > 0)
                {
                    dgvIngreso.Rows.Add(producto.Rows[0]["codBarras"].ToString(), producto.Rows[0]["codProveedor"].ToString(), producto.Rows[0]["descripcion"].ToString(), Math.Round (decimal .Parse (producto.Rows[0]["cantidad"].ToString()),cantStock ), Math.Round(decimal.Parse(producto.Rows[0]["cantidadMinima"].ToString()), cantStock), Math.Round(decimal.Parse(producto.Rows[0]["costo"].ToString()), cantDec ), Math.Round(decimal.Parse(producto.Rows[0]["precio"].ToString()), cantDec), Math.Round(decimal.Parse(producto.Rows[0]["P_Proveedor"].ToString()), cantDec), 0, nudCantidad.Value, 0, Math.Round(decimal.Parse(producto.Rows[0]["P_Proveedor"].ToString()), cantDec), unProducto,0,0);
                }
            }

            dgvIngreso.FirstDisplayedScrollingRowIndex = dgvIngreso.RowCount - 1;
            procesoTotales();
        }

        private void nudDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void nudRecargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void cboIVA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargado)
            {
                procesoTotales();
                nudGanancia_ValueChanged(null,null);
                nudDescuento_ValueChanged(null, null);
            }
        }

        private void nudDescuento_ValueChanged(object sender, EventArgs e)
        {
            if (nudDescuento.Value != 0 | nudDescuento.Focused)
            {
                foreach (DataGridViewRow fila in dgvIngreso.Rows)
                {
                    fila.Cells["costo"].Value = Math .Round ((100 - nudDescuento.Value) * decimal.Parse(fila.Cells["Precio_CIVA"].Value.ToString()) / 100,2);
                }

                procesoTotales();

                
            }
        }

       

        private void procesoTotales()
        {
            decimal total = 0;

            foreach (DataGridViewRow fila in dgvIngreso .Rows)
            {
                fila.Cells["Precio_CIVA"].Value = Math.Round(decimal.Parse(fila.Cells["Precio_SIVA"].Value.ToString()) * (1 + Decimal.Parse(cboIVA.Text) / 100), cantDec );
                fila.Cells["Subtotal"].Value = Math .Round( decimal.Parse(fila.Cells["Precio_CIVA"].Value.ToString()) * decimal.Parse(fila.Cells["Cantidad"].Value.ToString()),cantDec);
                total += decimal.Parse(fila.Cells["Subtotal"].Value.ToString());
            }

            txtTotal.Text = Math.Round(total, 2).ToString();
        }

        private void btnCargarNtaPedido_Click(object sender, EventArgs e)
        {
            Formularios.Proveedores.frmNotaPedidosPendientes unFrmNota = new Proveedores.frmNotaPedidosPendientes(this);
            unFrmNota.unProveedor = unProveedor;
            unFrmNota.llamador = this;
            unFrmNota.ShowDialog();
        }

        public void cargarNotaPedido (long unaNota)
        {
            dgvIngreso.Rows.Clear();
            DataTable notaEncabezado = instProv.traerPedidosPendientes(" and o.id = " + unaNota);

            if (notaEncabezado .Rows .Count > 0)
            {
                cboIVA.Text  = notaEncabezado.Rows[0]["iva"].ToString();
                nudDescuento .Value = decimal.Parse (notaEncabezado.Rows[0]["descuento"].ToString());
                txtTotal .Text = notaEncabezado.Rows[0]["total"].ToString();

                DataTable detalle = instProv.traerDetallePedidosPendientes(unaNota);
                if (detalle.Rows.Count > 0)
                {
                    foreach (DataRow fila in detalle.Rows)
                    {
                        dgvIngreso.Rows.Add(fila["Cod_Barras"].ToString(), fila["Cod_Proveedor"].ToString(), fila["Descripcion"].ToString(), fila["Stock"].ToString(), fila["C_Min"].ToString(), fila["costo"].ToString(), fila["precio"].ToString(), fila["P_Proveedor_s/IVA"].ToString(), fila["P_Proveedor_c/IVA"].ToString(), fila["Cantidad"].ToString(), fila["Subtotal"].ToString(), fila["P_Proveedor_s/IVA"].ToString(), fila["id"].ToString(), unaNota, fila["linea"].ToString());

                     }

                    procesoTotales();
                }
            }
        }

        private void nudCantidad_Enter(object sender, EventArgs e)
        {
            Clases.ClassValidacion.seleccionarTodoNumericUpDown(nudCantidad);
        }

        private bool formularioValido()
        {
            errorProvider1.Clear();
            bool resp = true;

            if (txtComprobante .Text == string .Empty ) 
            {
                errorProvider1.SetError(txtComprobante, "Ingrese número de comprobante");
                resp = false;
            }

            return resp;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (dgvIngreso.RowCount > 0 & formularioValido())
            {
                backgroundWorkerTarea.RunWorkerAsync();
            } 
            


        }

        private void procesoNotaPedido(string unalinea)
        {
            instProv.marcarlineaNotaPedido(unalinea);
        }


        private void registrarMovimiento(string unProducto, int unTipoMov, string unaDescipcion, decimal unStockAnt, decimal unStockAct, decimal unCosto, decimal unaVenta, decimal unaCantidad, decimal unPrecProveedor)
        {
            instProd.registrarMovimiento(unProducto, unTipoMov, unaDescipcion, unStockAnt, unStockAct, unCosto, unaVenta,unaCantidad,dtpFecha .Value ,txtComprobante.Text,unPrecProveedor);
        }
        private void ingresarStock (string unProducto, decimal unaCantidad)
        {
            instProd.agregarStock(unProducto, unaCantidad);
        }

        private void dgvIngreso_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            procesoTotales();
        }

        private void frmIngresoMercaderia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 )
            {
                btnCargarNtaPedido_Click(null, null);
            }

            if (e.KeyData == Keys.F5)
            {
                btnGrabar_Click (null, null);
            }
        }

        private void dgvIngreso_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            procesoTotales();
            nudDescuento_ValueChanged(null, null);
            nudGanancia_ValueChanged(null, null);
        }

        private void nudGanancia_ValueChanged(object sender, EventArgs e)
        {
            if (nudGanancia.Value != 0 | nudGanancia.Focused)
            {
                foreach (DataGridViewRow fila in dgvIngreso.Rows)
                {
                    fila.Cells["P_Lista"].Value = Math .Round ((100 + nudGanancia.Value) * decimal.Parse(fila.Cells["Precio_CIVA"].Value.ToString()) / 100,2);
                }

                procesoTotales();

            }
        }

        private void dgvIngreso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void dgvIngreso_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            decimal prec = 0;

            if (e != null)
            {
                if (e.Value != null)
                {
                    if (e.Value.ToString().IndexOf('.') != -1)
                    {
                        try
                        {
                            prec = Clases.ClassValidacion.cambiarPuntoPorComa(e.Value.ToString());
                            e.Value = prec;
                            e.ParsingApplied = true;
                        }
                        catch
                        {
                            e.ParsingApplied = false;
                        }
                    }
                }
            }
        }

        private void backgroundWorkerTarea_DoWork(object sender, DoWorkEventArgs e)
        {
            int progreso = 0;
            pbProceso.Maximum = dgvIngreso .RowCount;

            
                foreach (DataGridViewRow fila in dgvIngreso.Rows)
                {
                    if (fila.Cells["ntaPedido"].Value.ToString() != "0")
                    {
                        procesoNotaPedido(fila.Cells["linea"].Value.ToString());
                    }

                    ingresarStock(fila.Cells["id"].Value.ToString(), decimal.Parse(fila.Cells["Cantidad"].Value.ToString()));
                    registrarMovimiento(fila.Cells["id"].Value.ToString(), 2, fila.Cells["Descripcion"].Value.ToString(), decimal.Parse(fila.Cells["Stock"].Value.ToString()), decimal.Parse(fila.Cells["Stock"].Value.ToString()) + decimal.Parse(fila.Cells["Cantidad"].Value.ToString()), decimal.Parse(fila.Cells["Costo"].Value.ToString()), decimal.Parse(fila.Cells["P_Lista"].Value.ToString()), decimal.Parse(fila.Cells["Cantidad"].Value.ToString()), decimal.Parse(fila.Cells["Precio_CIVA"].Value.ToString()));
                    instProd.actualizarPrecios(int.Parse(fila.Cells["id"].Value.ToString()), decimal.Parse(fila.Cells["P_Lista"].Value.ToString()), decimal.Parse(fila.Cells["Costo"].Value.ToString()), decimal.Parse(fila.Cells["Precio_CIVA"].Value.ToString()));

                    progreso++;
                    backgroundWorkerTarea.ReportProgress(progreso, DateTime.Now);

                }

                MessageBox.Show(this, "Nota de pedido ingresada con éxito!!", "NOTA DE PEDIDO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                estadoInicial();
            
        }

        private void backgroundWorkerTarea_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbProceso.Value = (e.ProgressPercentage);
        }
    }
}
