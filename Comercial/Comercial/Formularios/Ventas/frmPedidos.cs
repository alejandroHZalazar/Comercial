using Comercial.Formularios.Clientes;
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
    public partial class frmPedidos : Form
    {
        private List<string> resgClientes = new List<string>();
        private List<string> resgProducto = new List<string>();
        Clases.ClassClientes instClie = new Clases.ClassClientes();
        Clases.ClassProductos instProd = new Clases.ClassProductos();
        Clases.ClassProveedores instProv = new Clases.ClassProveedores();
        Clases.classUsuarios instUser = new Clases.classUsuarios();
        Clases.ClassPedidos instPed = new Clases.ClassPedidos();
        Clases .ClassColores instColor = new Clases.ClassColores ();

        int clientePed = 0;
        int unProducto = 0;
        bool cargado = false;
        int unTipoBusq = 1;
        public int unPedActual = 0;
        int cantDec = Clases.ClassProductos.cantDecimales();
        int cantStock = Clases.ClassProductos.cantDecimalesStock();

        public frmPedidos()
        {
            InitializeComponent();
        }

       

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            if (txtCliente .Focused & txtCliente.Text != string.Empty)
            {
                filtrarCargarListBoxClie();
            }
            else
            {
                lblCliente .Visible = false;
            }
        }

        private void filtrarCargarListBoxClie()
        {
            lblCliente .Items.Clear();

            if (txtCliente .Text.Trim().Length == 0)
            {
                lblCliente .Visible = false;
            }

            var result = resgClientes .FindAll(l => l.ToUpper().Contains(txtCliente .Text.Trim().ToUpper()));

            lblCliente .Items.Clear();

            if (result.Count > 0)
            {
                result.ForEach(x => lblCliente .Items.Add(x));
                lblCliente .Visible = true;
            }
        }

        private void frmPedidos_Load(object sender, EventArgs e)
        {
            
            cargarClientes();
            cargarProductos();
            cargarCombos();
            estadoInicial();
            Control.CheckForIllegalCrossThreadCalls = false;
           
        }

        private void cargarCombos()
        {
            cboIVA.DataSource = instProv.traePorcentajeIVA();
            cboIVA.ValueMember = "id";
            cboIVA.DisplayMember = "valor";
            cboVendedores.DataSource  = instUser .traerTodosUsuarios ();
            cboVendedores.ValueMember = "id";
            cboVendedores.DisplayMember = "nombre";
            cboVendedores.SelectedValue = int.Parse(Environment.GetEnvironmentVariable("idUser"));
            
           cargado = true;
        }

        private void estadoInicial()
        {
            lblDescripcion.Text = string.Empty;
            lblClienteNombre.Text = string.Empty;
            dgvPedido.Rows.Clear();
            lbDesc.Visible = false;
            lblCliente.Visible = false;
            cboIVA.Enabled = false;
            gbFiltro.Enabled = false;
            dgvPedido.Enabled = false;
            nudDescuento.Enabled = false;
            nudRecargo.Enabled = false;
            btnGrabar.Enabled = false;
            cboFiltro.SelectedIndex = Clases.ClassParametros.indiceBusqNotaPed();
            txtCliente.Text = string.Empty;
            cboIVA.SelectedIndex = 0;
            txtSinIVA .Text = "0";
            txtTotalConIVA.Text = "0";
            txtDescuento.Text = "0";
            txtTotGeneral .Text = "0";
            nudDescuento.Value = 0;
            nudRecargo.Value = 0;
            clientePed  = 0;
            unPedActual = 0;
            unProducto = 0;
            rtbObserv.Text = string.Empty;
            btnAltaCliente.Enabled = true;
            txtCliente.Focus();
            lblDir.Text = string.Empty;
            lblTel.Text = string.Empty;
            lblEncargado.Text = string.Empty;
            nudCantidad.DecimalPlaces = cantStock;
        }

        private void cargarProductos()
        {
            resgProducto .Clear();
            DataTable productos = instProd.traeProductosPpal(" where baja = 0 order by descripcion");

            if (productos.Rows.Count > 0)
            {
                foreach (DataRow fila in productos.Rows)
                {
                    resgProducto.Add(fila["Descripcion"].ToString());
                }
            }
        }
        private void cargarClientes()
        {
            resgClientes.Clear();
            
            DataTable clientes = instClie.buscarAVender ();

            if (clientes.Rows.Count > 0)
            {
                foreach (DataRow fila in clientes.Rows)
                {
                    resgClientes .Add(fila["ID"].ToString() + "-  "+fila["Nombre_Comercial"].ToString() + "  -" + fila["Dir"].ToString());
                }
            }

        }

        private void lblCliente_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            cargarDatosCliente(0,0);
        }

        private void lblCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter & lblCliente .Items.Count > 0)
            {
                cargarDatosCliente(0,0);

            }
        }

        public void cargarDatosCabecera (string unVendedor, string unaObserv, decimal unDescuento, int unIVA)
        {
            cboVendedores.Text = unVendedor;
            rtbObserv.Text = unaObserv;
            nudDescuento.Value = unDescuento;
            cboIVA.SelectedValue   = unIVA;
        }

        public void cargarDatosCliente(int unTipo, int unCliente)
        {
            DataTable cliente;
                if (unTipo == 0)
            {
               cliente  = instClie.traerDatosVenta (" and c.id = " + lblCliente.SelectedItem.ToString ().Substring (0,lblCliente .SelectedItem .ToString ().IndexOf ("-")));
            }
                else
            {
                cliente = instClie.traerDatosVenta (" and c.id = " + unCliente.ToString());
            }

            if (cliente.Rows.Count > 0)
            {
                clientePed  = int.Parse(cliente.Rows[0]["ID"].ToString());
                lblClienteNombre .Text = cliente.Rows[0]["Nombre_Comercial"].ToString();
                lblDir .Text = cliente.Rows[0]["Dir"].ToString() + ". " + cliente.Rows[0]["Localidad"].ToString() + ". " + cliente.Rows[0]["Provincia"].ToString();
                lblTel .Text = cliente.Rows[0]["Tel"].ToString();
                lblEncargado .Text = cliente.Rows[0]["contacto"].ToString();
                lbDesc.Visible = false;
                txtCliente .Text = string.Empty;
                estadoConCliente();
                txtFiltro.Focus();

            }
        }

        private void estadoConCliente()
        {
            lblDescripcion.Text = string.Empty;
            dgvPedido .Rows.Clear();
            lbDesc.Visible = false;
            cboIVA.Enabled = true;
            gbFiltro.Enabled = true;
            dgvPedido.Enabled = true;
            nudDescuento.Enabled = true;
            nudRecargo.Enabled = true;
            btnGrabar.Enabled = true;
            cboIVA.SelectedIndex = 0;
            btnAltaCliente.Enabled = false;
        }

        private void cboIVA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargado)
            {
                procesoTotalesyColorear();
            }
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter & txtFiltro .Text != string .Empty )
            {
                buscarProducto();
                unTipoBusq = 1;
                txtFiltro.Text = string.Empty;
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

        private void dgvPedido_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            procesoTotalesyColorear();
            

        }



        private void dgvPedido_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            procesoTotalesyColorear();
        }

        private void procesoTotalesyColorear()
        {
            decimal totalSinIva = 0;
            decimal totalConIVA = 0;
            decimal totalDescuento = 0;
           
            foreach (DataGridViewRow fila in dgvPedido .Rows)
            {
                
                fila.Cells["precioConIva"].Value = Math.Round(decimal.Parse(fila.Cells["precioSinIVA"].Value.ToString()) * (1 + Decimal.Parse(cboIVA.Text) / 100), cantDec );
                fila.Cells["Subtotal"].Value = decimal.Parse(fila.Cells["precioConIva"].Value.ToString()) * decimal.Parse(fila.Cells["Cantidad"].Value.ToString());
                totalConIVA += decimal.Parse(fila.Cells["Subtotal"].Value.ToString());
                totalSinIva += Math.Round(decimal.Parse(fila.Cells["precioSinIva"].Value.ToString()) * decimal.Parse(fila.Cells["Cantidad"].Value.ToString()), cantDec);

                //System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml(instColor .traerColor (fila.Cells ["Color"].Value .ToString ()));
                //fila.Cells["descripcion"].Style.ForeColor = col;
            }
            totalDescuento = Math.Round(totalConIVA  * (nudDescuento.Value / 100), cantDec);
            txtTotalConIVA .Text = Math.Round(totalConIVA , 2).ToString();
            txtSinIVA.Text = Math.Round(totalSinIva , cantDec).ToString();
            txtDescuento.Text = Math.Round(totalDescuento, cantDec).ToString();
            txtTotGeneral.Text = Math.Round((totalConIVA  - totalDescuento), cantDec).ToString();
        }

        private void buscarProducto()
        {
            DataTable producto = null;

            if (txtFiltro.Text != string.Empty)
            {
                if (cboFiltro.SelectedIndex == 0)
                {
                    producto = instProd.traeProductosPpal(" where baja = 0 and codProveedor = '" + txtFiltro.Text.Trim()+"'");
                }
                else if (cboFiltro.SelectedIndex == 1)
                {
                    producto = instProd.traeProductosPpal(" where baja = 0 and codBarras = " + txtFiltro.Text.Trim());
                }
                else

                    producto = instProd.traeProductosPpal(" where baja = 0 and id = " + txtFiltro.Text.Trim());

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

        private void lbDesc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            prepararProducto();
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Clases.ClassValidacion.soloNumeros(e);
        }

        private void prepararProducto()
        {
            DataTable producto = instProd.traeProductosPpal(" where baja = 0 and descripcion = '" + lbDesc.SelectedItem.ToString() + "'");

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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (nudCantidad.Value > 0 & unProducto != 0)
            {
                agregarProducto();
                nudCantidad.Value = 0;
                unProducto = 0;

                dgvPedido.CurrentCell = dgvPedido.Rows[dgvPedido.RowCount - 1].Cells["Observ"];
                dgvPedido.BeginEdit(true);

                
            }
        }

        private void agregarProducto()
        {
           
                DataTable producto = instProd.traerProductosParaEditar(unProducto);
                if (producto.Rows.Count > 0)
                {
                    dgvPedido.Rows.Add(producto.Rows[0]["codBarras"].ToString(), producto.Rows[0]["codProveedor"].ToString(), producto.Rows[0]["descripcion"].ToString()," ", Math.Round(decimal.Parse (producto.Rows[0]["cantidad"].ToString()),cantStock ), Math.Round (decimal.Parse (producto.Rows[0]["precio"].ToString()),cantDec ), Math.Round(decimal.Parse(producto.Rows[0]["precio"].ToString()), cantDec), Math.Round (nudCantidad.Value,cantStock ), 0, Math.Round(decimal.Parse(producto.Rows[0]["precio"].ToString()), cantDec),  unProducto,Math .Round (decimal.Parse (producto.Rows[0]["costo"].ToString()),cantDec ));
                    
                }
            

            dgvPedido.FirstDisplayedScrollingRowIndex = dgvPedido.RowCount - 1;

            procesoTotalesyColorear();
        }

        public void cargarDetallePedidoEditar (int unPedido)
        {
            DataTable detalle = instPed.traerDetalleParaEditar(unPedido.ToString ());
            
            if (detalle .Rows .Count  > 0)
            {
                dgvPedido.Rows.Clear();

                foreach (DataRow fila in detalle .Rows )
                {
                    dgvPedido.Rows.Add(fila["codBarras"].ToString(), fila["codProveedor"].ToString(), fila["descripcion"].ToString(), fila["observ"].ToString(), Math .Round (decimal.Parse (fila["stock"].ToString()),cantStock ), Math.Round(decimal.Parse(fila["precioSinIva"].ToString()), cantDec ), Math.Round(decimal.Parse(fila["precioConIva"].ToString()), cantDec), Math.Round(decimal.Parse(fila["cantidad"].ToString()), cantStock), 0, Math.Round(decimal.Parse(fila["precioOrig"].ToString()), cantDec), fila["fk_producto"].ToString(), Math.Round(decimal.Parse(fila["costo"].ToString()), cantDec));
                    
                }

                dgvPedido.FirstDisplayedScrollingRowIndex = dgvPedido.RowCount - 1;

                procesoTotalesyColorear();
            }
        }

        private void nudCantidad_Enter(object sender, EventArgs e)
        {
            Clases.ClassValidacion.seleccionarTodoNumericUpDown(nudCantidad);
        }

        private void nudDescuento_Enter(object sender, EventArgs e)
        {
            Clases.ClassValidacion.seleccionarTodoNumericUpDown(nudDescuento );
        }

        private void nudRecargo_Enter(object sender, EventArgs e)
        {
            Clases.ClassValidacion.seleccionarTodoNumericUpDown(nudRecargo);
        }

        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                if (lblCliente .Items.Count > -1)
                {
                    lblCliente.SetSelected(0, true);
                    lblCliente.Focus();
                }
            }
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

        private void nudDescuento_ValueChanged(object sender, EventArgs e)
        {
            if (nudDescuento.Value != 0 | nudDescuento.Focused)
            {
                
                procesoTotalesyColorear();

                nudRecargo.Value = 0;
            }
        }

        private void nudRecargo_ValueChanged(object sender, EventArgs e)
        {
            if (nudRecargo.Value != 0 | nudRecargo.Focused)
            {
               
                procesoTotalesyColorear();

                nudDescuento.Value = 0;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            backgroundWorkerTarea.RunWorkerAsync();

           
        }

        private void frmPedidos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData== Keys.F5 )
            {
                btnGrabar_Click(null, null);
            }
        }

        private void txtDesc_TextChanged_1(object sender, EventArgs e)
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

        private void txtDesc_KeyDown(object sender, KeyEventArgs e)
        {
            try
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
            catch { }
        }

        private void nudDescuento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter )
            {

            }
        }

        private void dgvPedido_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
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
            if (dgvPedido.RowCount > 0)
            {
                int progreso = 0;
                pbProceso.Maximum = dgvPedido.RowCount;
                Clases.ClassPedidos instPedidos = new Clases.ClassPedidos();
                int salida = 0;

                salida = instPedidos.pedidosAddCabecera(decimal.Parse(txtTotGeneral.Text), clientePed, decimal.Parse(cboIVA.Text), nudRecargo.Value, nudDescuento.Value, int.Parse(cboVendedores.SelectedValue.ToString()),rtbObserv .Text .Trim ());

                if (salida != -1)
                {
                    foreach (DataGridViewRow fila in dgvPedido.Rows)
                    {
                        salida = instPedidos.pedidosAddDetalle(salida, int.Parse(fila.Cells["id"].Value.ToString()), fila.Cells["Cod_Barras"].Value.ToString(), fila.Cells["Cod_Proveedor"].Value.ToString(), fila.Cells["Descripcion"].Value.ToString(), decimal.Parse(fila.Cells["PrecioSinIVA"].Value.ToString()), decimal.Parse(fila.Cells["PrecioConIva"].Value.ToString()), decimal.Parse(fila.Cells["Cantidad"].Value.ToString()), decimal.Parse(fila.Cells["Subtotal"].Value.ToString()), decimal.Parse(fila.Cells["PrecioOrig"].Value.ToString()), decimal.Parse(fila.Cells["costo"].Value.ToString()),fila.Cells ["Observ"].Value .ToString ());

                        if (salida == -1)
                        {
                            MessageBox.Show(this, "Ha ocurrido un error durante el procesamiento", "Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        

                        progreso++;
                        backgroundWorkerTarea.ReportProgress(progreso, DateTime.Now);
                    }

                    salida = instPed.elimnarPedido(unPedActual);

                    MessageBox.Show(this, "Pedido Cargado con éxito!!", "Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pbProceso.Value = 0;
                    estadoInicial();
                }
                else
                {
                    MessageBox.Show(this, "Ha ocurrido un error durante el procesamiento", "Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void backgroundWorkerTarea_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbProceso.Value = (e.ProgressPercentage);
        }

        private void btnAltaCliente_Click(object sender, EventArgs e)
        {
            frmAltaModifClientes unFrmAltaModifClientes = new frmAltaModifClientes();
            unFrmAltaModifClientes.unaAccion = 1;
            unFrmAltaModifClientes.idCliente = 0;
            unFrmAltaModifClientes.ShowDialog();
            if (unFrmAltaModifClientes.DialogResult == DialogResult.OK)
            {
                cargarDatosCliente(1, instClie.traerUltimoCliente());
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmPedidosParaEditar unFrmPedidosEditar = new frmPedidosParaEditar(this);
            unFrmPedidosEditar.llamador = this;
            unFrmPedidosEditar.ShowDialog();
        }

        private void dgvPedido_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvPedido.IsCurrentCellDirty)
            {
                dgvPedido.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvPedido_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void dgvPedido_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPedido.Rows[dgvPedido.RowCount - 1].Cells["Observ"].Selected == true)
            {
                if (unTipoBusq == 1)
                {
                    txtFiltro.Focus();
                }
                else { txtDesc.Focus(); }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            estadoInicial();
        }
    }
}
