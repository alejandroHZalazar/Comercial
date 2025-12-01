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
    public partial class frmVentas : Form
    {
        public int unCliente;
        int unProducto = 0;
        bool cargado = false;
        int unTipoBusq = 1;
        int unPedido = 0;
        decimal unCosto = 0;
        int pedidoCargado;
        public string filtro;
        public bool buscoPend = false;
        public int pos = 0;
        

        private List<string> resgClientes = new List<string>();
        private List<string> resgProducto = new List<string>();
        Clases.ClassClientes instClie = new Clases.ClassClientes();

        Clases.ClassPedidos instPed = new Clases.ClassPedidos();
        Clases.ClassProductos instProd = new Clases.ClassProductos();
        Clases.ClassProveedores instProv = new Clases.ClassProveedores();
        Clases.ClassVentas instVentas = new Clases.ClassVentas();
        Clases.classUsuarios instUser = new Clases.classUsuarios();
        int cantDec = Clases.ClassProductos.cantDecimales();
        int cantStock = Clases.ClassProductos.cantDecimalesStock();

        public frmVentas()
        {
            InitializeComponent();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            cargarClientes();
            cargarProductos();
            cargarCombos();
            estadoInicial();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void estadoInicial()
        {
            lblDescripcion.Text = string.Empty;
            lblClienteNombre.Text = string.Empty;
            dgvProductos.Rows.Clear();
            lbDesc.Visible = false;
            lblCliente.Visible = false;
            cboIVA.Enabled = false;
            cboIngBrutos.Enabled = false;
            gbFiltro.Enabled = false;
            dgvProductos.Enabled = false;
            nudDescuento.Enabled = false;
            nudRecargo.Enabled = false;
            btnGrabar.Enabled = false;
            cboFiltro.SelectedIndex = Clases.ClassParametros.indiceBusqNotaPed();
            txtCliente.Text = string.Empty;
            cboIVA.SelectedIndex = 0;
            cboIngBrutos.SelectedIndex = 0;
            txtSubSinIVA .Text = "0";
            nudDescuento.Value = 0;
            nudRecargo.Value = 0;
            unCliente = 0;
            unProducto = 0;
            txtSubSinIVA.Text = "0";
            txtCliente.Focus();
            cboTipo.Enabled = false;
            cboTipo.SelectedIndex = 0;
            btnAltaCliente.Enabled = true;
            nudComision.Value = -1;
            lblDir.Text = string.Empty;
            lblTel.Text = string.Empty;
            lblCondIVA.Text = string.Empty;
            lblEncargado.Text = string.Empty;
            nudCantidad.DecimalPlaces = cantStock;
            btnCambioPrecio.Enabled = false;
            btnCambioPrecio.Text = "Precios Actualizados";
            pedidoCargado = 0;
            txtTotalSinIva.Text = "0";
            txtIVA.Text = "0";
            txtIB.Text = "0";
            txtTotGeneral.Text = "0";
          
            cboVendedores.SelectedIndex = -1;
        }

        private void cargarCombos()
        {
            cboIVA.DataSource = instProv.traePorcentajeIVA();
            cboIVA.ValueMember = "id";
            cboIVA.DisplayMember = "valor";

            cboVendedores.DataSource = instUser.traerTodosUsuarios();
            cboVendedores.ValueMember = "id";
            cboVendedores.DisplayMember = "nombre";
            cboVendedores.SelectedIndex = -1;

            cboIngBrutos.DataSource = instProv.traerPorcentajeImpuestos();
            cboIngBrutos.ValueMember = "id";
            cboIngBrutos.DisplayMember = "valor";

            cargado = true;
        }

        private void cargarProductos()
        {
            resgProducto.Clear();
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
            DataTable clientes = instClie.buscarAVender();

            if (clientes.Rows.Count > 0)
            {
                foreach (DataRow fila in clientes.Rows)
                {
                    resgClientes.Add(fila["ID"].ToString() + "-  " + fila["Nombre_Comercial"].ToString() + "  -" + fila["Dir"].ToString());
                }
            }

        }


        private void btnPedido_Click(object sender, EventArgs e)
        {
            Formularios.Ventas .frmPedidosPendientes unFrmPendientes = new frmPedidosPendientes(this);
            unFrmPendientes.llamador = this;
            unFrmPendientes.buscarYa = buscoPend;
            unFrmPendientes.position = pos;
            unFrmPendientes.filtro = this.filtro;
            unFrmPendientes.ShowDialog();
            if (unFrmPendientes .DialogResult == DialogResult.OK )
            {
                buscoPend = true;
            }
            else
            {
                buscoPend = false;
            }
        }

        public void cargarPedidoPendiente(int unPed, decimal unIva, decimal unDescuento, decimal unRecargo)
        {
            unPedido = 0;
            pedidoCargado = unPed;
            DataTable cliente = instClie.traeClientesPpal(" and c.id = " + unCliente);
            if (cliente.Rows.Count > 0)
            {
                lblClienteNombre.Text = cliente.Rows[0]["Nombre_Comercial"].ToString();
                estadoConCliente();
            }
            DataTable pedido = instPed.traerDetallePendientes(unPed);
            dgvProductos.Rows.Clear();
            if (pedido.Rows.Count > 0)
            {
                unPedido = unPed;
                foreach (DataRow fila in pedido.Rows)
                {
                    dgvProductos.Rows.Add(fila["Cod_Barras"].ToString(), fila["Cod_Proveedor"].ToString(), fila["Descripcion"].ToString(), Math.Round(decimal.Parse (fila["Stock"].ToString()),cantStock ), Math.Round(decimal.Parse(fila["Precio S/IVA"].ToString()), cantDec ), Math.Round(decimal.Parse(fila["Precio C/IVA"].ToString()), cantDec), Math.Round(decimal.Parse(fila["Cantidad"].ToString()), cantStock ), Math.Round(decimal.Parse(fila["Subtotal"].ToString()), cantDec ), Math.Round(decimal.Parse(fila["precioOrig"].ToString()), cantDec), fila["fk_producto"].ToString(), unPedido, Math.Round(decimal.Parse(fila["costo"].ToString()), cantDec));
                }
            }
            unPedido = 0;
            nudDescuento.Value = unDescuento;
            nudRecargo.Value = unRecargo;
            cboIVA.Text = unIva.ToString();
            procesoTotales();
            btnCambioPrecio.Enabled = true;
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            if (txtCliente.Focused & txtCliente.Text != string.Empty)
            {
                filtrarCargarListBoxClie();
            }
            else
            {
                lblCliente.Visible = false;
            }
        }

        private void filtrarCargarListBoxClie()
        {
            lblCliente.Items.Clear();

            if (txtCliente.Text.Trim().Length == 0)
            {
                lblCliente.Visible = false;
            }

            var result = resgClientes.FindAll(l => l.ToUpper().Contains(txtCliente.Text.Trim().ToUpper()));

            lblCliente.Items.Clear();

            if (result.Count > 0)
            {
                result.ForEach(x => lblCliente.Items.Add(x));
                lblCliente.Visible = true;
            }
        }

        private void lblCliente_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            cargarDatosCliente(0,0);
        }

        private void lblCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter )
            {
                cargarDatosCliente(0,0);
            }
        }

        public void cargarDatosCliente(int tipo, int unCliente)
        {
            DataTable cliente;
            if (tipo  == 0)
            {
                cliente = instClie.traerDatosVenta(" and c.id = " + lblCliente.SelectedItem.ToString().Substring(0, lblCliente.SelectedItem.ToString().IndexOf("-")));
            }
            else
            {
                cliente = instClie.traerDatosVenta(" and c.id = " + unCliente.ToString());
            }

            if (cliente.Rows.Count > 0)
            {
                this.unCliente = int.Parse(cliente.Rows[0]["ID"].ToString());
                lblClienteNombre .Text = cliente.Rows[0]["Nombre_Comercial"].ToString();
                lblDir .Text = cliente.Rows[0]["Dir"].ToString() + ". " + cliente.Rows[0]["Localidad"].ToString() + ". " + cliente.Rows[0]["Provincia"].ToString();
                lblTel .Text = cliente.Rows[0]["Tel"].ToString();
                lblCondIVA .Text = cliente.Rows[0]["CondIVA"].ToString();
                lblEncargado .Text = cliente.Rows[0]["contacto"].ToString();
                lbDesc.Visible = false;
                txtCliente.Text = string.Empty;
                estadoConCliente();
                txtFiltro.Focus();

            }
        }

        private void estadoConCliente()
        {
            lblDescripcion.Text = string.Empty;
            lbDesc.Visible = false;
            cboIVA.Enabled = true;
            cboIngBrutos.Enabled = true;
            gbFiltro.Enabled = true;
            dgvProductos.Enabled = true;
            nudDescuento.Enabled = true;
            nudRecargo.Enabled = true;
            btnGrabar.Enabled = true;
            cboIVA.SelectedIndex = 0;
            cboIngBrutos.SelectedIndex = 0;
            cboTipo.Enabled = true;
            btnPedido.Enabled = true;
            btnAltaCliente.Enabled = false;
            txtFiltro.Focus();
        }

        private void cboIVA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargado)
            {
                procesoTotales();
            }
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter & txtFiltro.Text != string.Empty)
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

        private void dgvProductos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            procesoTotales();
        }

        private void procesoTotales()
        {
            
            decimal totalSIVA = 0;
            decimal totalDescuento = 0;
            decimal totalRecargo = 0;
            
            foreach (DataGridViewRow fila in dgvProductos .Rows)
            {
                fila.Cells["precioConIva"].Value = Math.Round(decimal.Parse(fila.Cells["precioSinIva"].Value.ToString()) * (1 + Decimal.Parse(cboIVA.Text) / 100), cantDec );
                fila.Cells["Subtotal"].Value = Math .Round ( decimal.Parse(fila.Cells["precioConIva"].Value.ToString()) * decimal.Parse(fila.Cells["Cantidad"].Value.ToString()),cantDec);
                totalSIVA += Math.Round(decimal.Parse(fila.Cells["precioSinIva"].Value.ToString()) * decimal.Parse(fila.Cells["Cantidad"].Value.ToString()), cantDec );
                
            }

            if (dgvProductos.RowCount > 0)
            {
                txtSubSinIVA.Text = totalSIVA.ToString();
                totalDescuento = Math.Round(totalSIVA * (nudDescuento.Value / 100), cantDec);
                totalRecargo = Math.Round(totalSIVA * (nudRecargo.Value / 100), cantDec);
                txtTotalSinIva.Text = Math.Round((totalSIVA - totalDescuento + totalRecargo ), cantDec).ToString();


                txtDescuento.Text = Math.Round(totalDescuento * -1 + totalRecargo , cantDec).ToString();
                txtIVA .Text = (Math.Round((totalSIVA - totalDescuento + totalRecargo) * (Decimal.Parse(cboIVA.Text) / 100), cantDec)).ToString();
                txtIB.Text = (Math.Round((totalSIVA - totalDescuento + totalRecargo) * (Decimal.Parse(cboIngBrutos.Text) / 100), cantDec)).ToString();
                // txtTotGeneral.Text = (Math.Round((totalSIVA - totalDescuento + totalRecargo ) * (1 + Decimal.Parse(cboIVA.Text) / 100), cantDec)).ToString();
                txtTotGeneral.Text = (Math.Round (decimal.Parse (txtTotalSinIva .Text) + decimal.Parse(txtIVA .Text) + decimal.Parse(txtIB .Text)  , cantDec)).ToString();
            }
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
            foreach (DataGridViewRow fila in dgvProductos .Rows)
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
                    dgvProductos.Rows.Add(producto.Rows[0]["codBarras"].ToString(), producto.Rows[0]["codProveedor"].ToString(), producto.Rows[0]["descripcion"].ToString(), Math .Round (decimal .Parse ( producto.Rows[0]["cantidad"].ToString()),cantStock ), Math.Round(decimal.Parse(producto.Rows[0]["precio"].ToString()), cantDec ), Math.Round(decimal.Parse(producto.Rows[0]["precio"].ToString()), cantDec), Math.Round(nudCantidad.Value, cantStock), 0, Math.Round(decimal.Parse(producto.Rows[0]["precio"].ToString()), cantDec), unProducto,0 , Math.Round(decimal.Parse(producto.Rows[0]["costo"].ToString()), cantDec));
                }
            }

            dgvProductos.FirstDisplayedScrollingRowIndex = dgvProductos.RowCount - 1;

            procesoTotales();
        }

        private void nudCantidad_Enter(object sender, EventArgs e)
        {
            Clases.ClassValidacion.seleccionarTodoNumericUpDown(nudCantidad);
        }

        private void nudDescuento_Enter(object sender, EventArgs e)
        {
            Clases.ClassValidacion.seleccionarTodoNumericUpDown(nudDescuento);
        }

        private void nudRecargo_Enter(object sender, EventArgs e)
        {
            Clases.ClassValidacion.seleccionarTodoNumericUpDown(nudRecargo);
        }

        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                if (lblCliente.Items.Count > -1)
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
                nudRecargo.Value = 0;
                procesoTotales();
                                
            }
        }

        private void nudRecargo_ValueChanged(object sender, EventArgs e)
        {
            if (nudRecargo.Value != 0 | nudRecargo.Focused)
            {
                nudDescuento.Value = 0;
                procesoTotales();                
            }
        }

        private void frmVentas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                btnGrabar_Click(null, null);
            }
        }

        private bool formularioValido()
        {
            errorProvider1.Clear();

            if (cboVendedores.SelectedIndex < 0)
            {
                errorProvider1.SetError(cboVendedores, "Seleccione un vendedor");
                return false;
            }
            if (nudComision .Value == -1)
            {
                errorProvider1.SetError(nudComision, "indique comision");
                return false;
            }
            return true;
        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {
          

            if (formularioValido ())
            {
                vender();
                if (buscoPend )
                {
                    btnPedido_Click(null, null);
                }
            }
            
           
        }

        private void imprimirVenta(long unaVenta)
        {
            Reportes.frmReport unFrmReport = new Reportes.frmReport();
            
            unFrmReport.nombreReporte = "ReportVenta.rdlc";
            List<string> var = new List<string>();
            var.Add(unaVenta.ToString());
            var.Add(Clases.ClassValidacion.traerEmpresa());
            var.Add("Tel: " + Clases.ClassValidacion.traerEmpresaTelefono());
            var.Add(Clases.ClassValidacion.traerEmpresaDireccion());
            var.Add(Clases.ClassValidacion.traerEmpresaCiudad());
            var.Add("CUIT: " + Clases.ClassValidacion.traerEmpresaCuit ());
            var.Add(cboIVA.Text);
            var.Add(cantDec.ToString());
            var.Add(cantStock.ToString());
            var.Add(Clases.ClassValidacion.traerRazonSocial());
            unFrmReport.variable = var;
            unFrmReport.ShowDialog();
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

        private void dgvProductos_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
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
            
        }

        private void vender()
        {
            long salida = -1;
            if (dgvProductos.RowCount > 0)
            {
                int progreso = 0;
                
                unCosto = 0;
                foreach (DataGridViewRow fila in dgvProductos.Rows)
                {
                    unCosto += Math.Round(decimal.Parse(fila.Cells["costo"].Value.ToString()) * decimal.Parse(fila.Cells["Cantidad"].Value.ToString()), 4);

                }
                salida = instVentas.grabarCabeceraVenta(decimal.Parse(txtTotGeneral.Text), unCosto, unCliente, int.Parse(Environment.GetEnvironmentVariable("idUser")), decimal.Parse(cboIVA.Text), nudDescuento.Value, nudRecargo.Value,int.Parse (cboVendedores .SelectedValue .ToString ()),nudComision.Value  /100, decimal.Parse(cboIngBrutos .Text));

                if (salida != -1)
                {
                    string detalle = string.Empty;
                    foreach (DataGridViewRow fila in dgvProductos.Rows)
                    {
                        detalle += fila.Cells["id"].Value.ToString() + "#";
                        detalle += decimal.Parse(fila.Cells["precioSinIva"].Value.ToString()) + "*";
                        detalle += decimal.Parse(fila.Cells["precioConIva"].Value.ToString()) + "!";
                        detalle += decimal.Parse(fila.Cells["Cantidad"].Value.ToString()) + "?";
                        detalle += fila.Cells["pedido"].Value.ToString() + ";";
                        detalle = detalle.Replace(',', '.');
                        progreso++;
                        
                    }

                    salida = instVentas.grabarProcesoDetallVenta(salida, detalle);

                    if (salida != -1)
                    {
                        if (cboTipo.SelectedIndex == 1)
                        {
                            //procesoFacturacion();
                            estadoInicial();
                        }
                        else
                        {
                            instPed.marcarPedido(pedidoCargado, 1);
                            imprimirVenta(salida);
                            estadoInicial();
                           
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Ha ocurrido un error en el proceso", "VENTAS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       
                    }

                }
                else
                {
                    MessageBox.Show(this, "Ha ocurrido un error en el proceso", "VENTAS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
        }

        private void backgroundWorkerTarea_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
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

        private void dgvProductos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            procesoTotales();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            
            estadoInicial();
        }

        private void btnCambioPrecio_Click(object sender, EventArgs e)
        {
            if (dgvProductos.RowCount > 0)
            {
                decimal precio;

                if (btnCambioPrecio.Text == "Precios Actualizados")
                {
                    foreach (DataGridViewRow fila in dgvProductos.Rows)
                    {
                        precio = instVentas.traerPrecioProductosVentas(1, int.Parse(fila.Cells["id"].Value.ToString()), unPedido);
                        if (precio  > -1)
                        {
                            fila.Cells["precioSinIva"].Value = Math.Round(precio, cantDec);
                        }

                    }

                    btnCambioPrecio.Text = "Precios del Pedido"; 
                }

                else if (btnCambioPrecio.Text == "Precios del Pedido")
                {
                    foreach (DataGridViewRow fila in dgvProductos.Rows)
                    {
                        precio = instVentas.traerPrecioProductosVentas(2, int.Parse(fila.Cells["id"].Value.ToString()), pedidoCargado);
                        if (precio > -1)
                        {
                            fila.Cells["precioSinIva"].Value = Math.Round(precio, cantDec);
                        }

                    }
                    btnCambioPrecio.Text = "Precios Actualizados";
                }

                procesoTotales();
            }
        }

        private void nudComision_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void lblCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboIngBrutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            procesoTotales();
        }
    }
}
