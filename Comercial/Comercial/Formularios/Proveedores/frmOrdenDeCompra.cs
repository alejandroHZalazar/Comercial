using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Comercial.Formularios.Proveedores
{
    public partial class frmOrdenDeCompra : Form
    {
        int unProveedor = 0;
        int unTipoBusq = 1;
        int unProducto = 0;
        bool cargado = false;
        long salida = 0;
        Clases.ClassProductos instProd = new Clases.ClassProductos();
        Clases.ClassProveedores instProv = new Clases.ClassProveedores();
        int cantDec = Clases.ClassProductos.cantDecimales();
        int cantStock = Clases.ClassProductos.cantDecimalesStock();

        private List<string> resgProducto = new List<string>();

        public frmOrdenDeCompra()
        {
            InitializeComponent();
        }

        private void frmOrdenDeCompra_Load(object sender, EventArgs e)
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
            dgvOrden.Rows.Clear();
            lbDesc.Visible = false;
            btnCantMinima.Enabled = false;
            cboIVA.Enabled = false;
            gbFiltro.Enabled = false;
            dgvOrden.Enabled = false;
            nudDescuento.Enabled = false;
            nudRecargo.Enabled = false;
            btnGrabar.Enabled = false;
            cboFiltro .SelectedIndex = Clases.ClassParametros.indiceBusqNotaPed();
            cboProveedores.SelectedIndex = -1;
            cboIVA.SelectedIndex = 0;
            txtTotal.Text = "0";
            nudDescuento.Value = 0;
            nudRecargo.Value = 0;
            nudCantidad.DecimalPlaces = cantStock;
            pbProgreso.Value = 0;
        }
        
        private void estadoConProveedor()
        {
            lblDescripcion.Text = string.Empty;
            lblProveedor.Text = cboProveedores.Text;
            dgvOrden.Rows.Clear();
            lbDesc .Visible = false;
            btnCantMinima.Enabled = true;
            cboIVA.Enabled = true;
            gbFiltro.Enabled = true;
            dgvOrden.Enabled = true;
            nudDescuento.Enabled = true;
            nudRecargo.Enabled = true;
            btnGrabar.Enabled = true;
            cboIVA.SelectedIndex = 0;
            cargarProductos();
        }

        private void btnSelProveedor_Click(object sender, EventArgs e)
        {
            if (cboProveedores .SelectedIndex > -1)
            {
                unProveedor = int.Parse(cboProveedores.SelectedValue.ToString());
                estadoConProveedor();
                txtFiltro.Focus();
                
            }
        }

        private void cargarProductos()
        {
            resgProducto.Clear();
            DataTable productos = instProv.traerProductosProveedor (int.Parse (cboProveedores.SelectedValue.ToString()));

            if (productos .Rows .Count > 0)
            {
                foreach (DataRow fila in productos.Rows  )
                {
                    resgProducto.Add(fila["descripcion"].ToString ());
                }
            }
            
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Clases.ClassValidacion.soloNumeros(e);
        }

        private void nudCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
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

        private void buscarProducto()
        {
            DataTable producto = null;

            if (txtFiltro.Text != string.Empty)
            {
                if (cboFiltro.SelectedIndex == 0)
                {
                    producto  = instProd.traeProductosPpal(" where baja = 0 and codProveedor = '" + txtFiltro.Text.Trim() + "' and fk_proveedor = " + unProveedor );
                }
                else if (cboFiltro.SelectedIndex == 1)
                {
                    producto  = instProd.traeProductosPpal(" where baja = 0 and codBarras = " + txtFiltro.Text.Trim() + " and fk_proveedor = " + unProveedor);
                }
                else
                
                    producto = instProd.traeProductosPpal(" where baja = 0 and id = " + txtFiltro .Text .Trim () + " and fk_proveedor " + unProveedor );

                }

                if (producto .Rows .Count > 0)
                {
                    unProducto = int.Parse (producto.Rows[0]["ID"].ToString());
                    lblDescripcion.Text = producto.Rows[0]["Descripcion"].ToString();
                    nudCantidad.Focus();
                }
            else
            {
                MessageBox.Show(this, "No existe el producto n°: " + txtFiltro.Text.Trim(), "Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void nudCantidad_Enter(object sender, EventArgs e)
        {
            Clases.ClassValidacion.seleccionarTodoNumericUpDown(nudCantidad);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (nudCantidad .Value > 0 & unProducto != 0)
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
            foreach (DataGridViewRow fila in dgvOrden .Rows )
            {
                if (int.Parse (fila.Cells ["id"].Value .ToString ()) == unProducto )
                {
                    fila.Cells["cantidad"].Value  = decimal.Parse (fila.Cells["cantidad"].Value.ToString ()) + nudCantidad.Value;
                    band = true;
                    break;
                }
            }

            if (band == false)
            {
                DataTable producto = instProd.traerProductosParaEditar(unProducto);
                if (producto .Rows .Count > 0)
                {
                    dgvOrden.Rows.Add(producto.Rows[0]["codBarras"].ToString(), producto.Rows[0]["codProveedor"].ToString(), producto.Rows[0]["descripcion"].ToString(),Math.Round(decimal.Parse (producto.Rows[0]["cantidad"].ToString()),cantStock ), Math.Round(decimal.Parse(producto.Rows[0]["cantidadMinima"].ToString()), cantStock), Math.Round(decimal.Parse(producto.Rows[0]["P_Proveedor"].ToString()), cantDec ), 0, nudCantidad.Value, 0, Math.Round(decimal.Parse(producto.Rows[0]["P_Proveedor"].ToString()), cantDec), unProducto);
                }
            }

            dgvOrden.FirstDisplayedScrollingRowIndex = dgvOrden.RowCount - 1;
            procesoTotales();
        }

        private void procesoTotales()
        {
            decimal total = 0;

            

            foreach (DataGridViewRow fila in dgvOrden .Rows )
            {
                fila.Cells["Precio_CIVA"].Value = Math .Round (decimal.Parse(fila.Cells["Precio_SIVA"].Value.ToString()) * (1 + Decimal.Parse(cboIVA.Text) / 100),cantDec );
                fila.Cells["Subtotal"].Value = Math.Round ( decimal.Parse(fila.Cells["Precio_CIVA"].Value.ToString()) * decimal.Parse(fila.Cells["Cantidad"].Value.ToString()),cantDec );
                total +=  decimal.Parse(fila.Cells["Subtotal"].Value.ToString());
            }

            txtTotal.Text = Math.Round ( total,2).ToString ();
        } 
        private void nudCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter )
            {
                btnAgregar_Click(null, null);
            }
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            
            if (txtDesc .Focused & txtDesc.Text != string .Empty )
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
            lbDesc .Items.Clear();

            if (txtDesc.Text.Trim().Length == 0)
            {
                lbDesc.Visible = false;
            }

            var result = resgProducto .FindAll(l => l.ToUpper().Contains(txtDesc .Text .Trim ().ToUpper()));

            lbDesc.Items.Clear();

            if (result.Count > 0)
            {
                result.ForEach(x => lbDesc.Items.Add(x));
                lbDesc.Visible = true;
            }
        }

        private void txtDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData  == Keys.Down)
            {
                if (lbDesc .Items .Count > -1)
                {
                    lbDesc.SetSelected(0, true);
                    lbDesc.Focus();
                }
            }
                
        }

        private void lbDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData  == Keys.Back)
            {
                txtDesc.Focus();
            }

            if (e.KeyData == Keys.Enter & lbDesc .Items .Count > 0)
            {
                prepararProducto();

            }


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

        private void cboIVA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargado)
            {
                procesoTotales();
            }
        }

        private void btnCantMinima_Click(object sender, EventArgs e)
        {
            dgvOrden.Rows.Clear();
            DataTable producto = instProv.traeCantMinPorProveedor(unProveedor);

            if (producto .Rows .Count > 0)
            {
                foreach (DataRow fila in producto .Rows )
                {
                    dgvOrden.Rows.Add(fila["codBarras"].ToString(), fila["codProveedor"].ToString(), fila["descripcion"].ToString(),Math .Round (decimal .Parse (fila["cantidad"].ToString()),cantStock ), Math.Round(decimal.Parse(fila["cantidadMinima"].ToString()), cantStock), Math.Round(decimal.Parse(fila["precio"].ToString()), cantDec ), 0,Math.Round(decimal.Parse ( fila["Pedido"].ToString()),cantStock ), 0, Math.Round(decimal.Parse(fila["precio"].ToString()), cantDec), fila["id"].ToString());
                }

                procesoTotales();
            }
        }

        private void dgvOrden_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            procesoTotales();
        }

        private void dgvOrden_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            procesoTotales();
        }

        private void nudDescuento_ValueChanged(object sender, EventArgs e)
        {
            if (nudDescuento .Value != 0 | nudDescuento .Focused )
            {
                foreach (DataGridViewRow fila in dgvOrden .Rows )
                {
                    fila.Cells["Precio_SIVA"].Value = Math.Round (((100 - nudDescuento.Value) * decimal.Parse(fila.Cells["costoOrig"].Value.ToString()) / 100),cantDec );   
                } 

                procesoTotales();

                nudRecargo.Value = 0;
            }
        }

        private void nudDescuento_Enter(object sender, EventArgs e)
        {
            Clases.ClassValidacion.seleccionarTodoNumericUpDown(nudDescuento);
        }

        private void nudRecargo_Enter(object sender, EventArgs e)
        {
            Clases.ClassValidacion.seleccionarTodoNumericUpDown(nudRecargo);
        }

        private void nudRecargo_ValueChanged(object sender, EventArgs e)
        {
            if (nudRecargo .Value != 0 | nudRecargo .Focused )
            {
                foreach (DataGridViewRow fila in dgvOrden.Rows)
                {
                    fila.Cells["Costo_SIVA"].Value = Math.Round (( (100 + nudRecargo .Value) * decimal.Parse(fila.Cells["costoOrig"].Value.ToString()) / 100),cantDec );
                }

                procesoTotales();

                nudDescuento.Value = 0;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            

            if (dgvOrden.Rows.Count > 0)
            {


                salida = instProv.insertOrdenCompraCabecera(unProveedor, decimal.Parse(txtTotal.Text), decimal.Parse(cboIVA.Text), nudRecargo.Value, nudDescuento.Value);

                if (salida != -1)
                {
                    foreach (DataGridViewRow fila in dgvOrden.Rows)
                    {
                        if (salida != -1)
                        {
                            salida = instProv.insertOrdenCompraDetalle(salida, int.Parse(fila.Cells["id"].Value.ToString()), fila.Cells["Cod_Barras"].Value.ToString(), fila.Cells["Cod_Proveedor"].Value.ToString(), fila.Cells["Descripcion"].Value.ToString(), decimal.Parse(fila.Cells["Precio_SIVA"].Value.ToString()), decimal.Parse(fila.Cells["Cantidad"].Value.ToString()), decimal.Parse(fila.Cells["Subtotal"].Value.ToString()));

                        }
                        else
                        {
                            MessageBox.Show(this, "Ha ocurrido un error durante el proceso", "NOTA DE PEDIDO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }

                       
                    }

                    Reportes.frmReport unFrmReport = new Reportes.frmReport();
                    //unFrmReport.titulo = "Nota de Pedido";
                    unFrmReport.nombreReporte = "ReportOrdenCompra.rdlc";
                    List<string> var = new List<string>();
                    var.Add(salida.ToString());
                    var.Add(Clases.ClassValidacion.traerEmpresa());
                    var.Add(cantDec.ToString());
                    var.Add(cantStock.ToString());
                    unFrmReport.variable = var;
                    unFrmReport.ShowDialog();
                    salida = 0;
                    estadoInicial();

                }
                else
                {
                    MessageBox.Show(this, "Ha ocurrido un error durante el proceso", "NOTA DE PEDIDO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }

           
        }

        

        private void lbDesc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            prepararProducto();
        }

        private void frmOrdenDeCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 )
            {
                btnCantMinima_Click(null, null);
            }

            if (e.KeyData == Keys.F5 )
            {
                btnGrabar_Click(null, null);
            }

            if (e.KeyData == Keys.F3)
            {
                btnInventario_Click (null, null);
            }
        }

        private void cboProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblProveedor_Click(object sender, EventArgs e)
        {

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

        private void dgvOrden_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void dgvOrden_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            decimal prec = 0;

            if (e != null)
            {
                if (e.Value != null)
                {
                    if (e.Value .ToString ().IndexOf ('.') != -1)
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
            pbProgreso.Maximum = dgvOrden.RowCount;

            if (dgvOrden.Rows.Count > 0)
            {
                

                salida = instProv.insertOrdenCompraCabecera(unProveedor, decimal.Parse(txtTotal.Text), decimal.Parse(cboIVA.Text), nudRecargo.Value, nudDescuento.Value);

                if (salida != -1)
                {
                    foreach (DataGridViewRow fila in dgvOrden.Rows)
                    {
                        if (salida != -1)
                        {
                            salida = instProv.insertOrdenCompraDetalle(salida, int.Parse(fila.Cells["id"].Value.ToString()), fila.Cells["Cod_Barras"].Value.ToString(), fila.Cells["Cod_Proveedor"].Value.ToString(), fila.Cells["Descripcion"].Value.ToString(), decimal.Parse(fila.Cells["Precio_SIVA"].Value.ToString()), decimal.Parse(fila.Cells["Cantidad"].Value.ToString()), decimal.Parse(fila.Cells["Subtotal"].Value.ToString()));

                        }
                        else
                        {
                            MessageBox.Show(this, "Ha ocurrido un error durante el proceso", "NOTA DE PEDIDO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }

                        progreso++;
                        backgroundWorkerTarea.ReportProgress(progreso, DateTime.Now);
                    }


                }
                else
                {
                    MessageBox.Show(this, "Ha ocurrido un error durante el proceso", "NOTA DE PEDIDO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }
        }

        private void backgroundWorkerTarea_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbProgreso .Value = (e.ProgressPercentage);
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            frmListaProductosAPedir unFrmLista = new Proveedores.frmListaProductosAPedir();
            unFrmLista.Proveedor = unProveedor;
            unFrmLista.ShowDialog();
            if (unFrmLista .DialogResult == DialogResult.OK )
            {
                cargarPedido(unFrmLista.pedido);
            }
        }

        private void cargarPedido(DataTable unPedido)
        {
            estadoConProveedor();

            if (unPedido .Rows .Count > 0)
            {
                foreach (DataRow fila in unPedido .Rows )
                {
                    
                    dgvOrden.Rows.Add(fila["CodBarras"].ToString(), fila["codProveedor"].ToString(), fila["descripcion"].ToString(), Math.Round(decimal.Parse(fila["cantidad"].ToString()), cantStock), Math.Round(decimal.Parse(fila["cantidadMinima"].ToString()), cantStock), Math.Round(decimal.Parse(fila["P_Proveedor"].ToString()), cantDec), 0, Math.Round(decimal.Parse(fila["Pedido"].ToString()), cantStock), 0, Math.Round(decimal.Parse(fila["P_Proveedor"].ToString()), cantDec), fila["producto"].ToString());
                }
            }

            dgvOrden.FirstDisplayedScrollingRowIndex = dgvOrden.RowCount - 1;
            procesoTotales();
            txtFiltro.Focus();
        }

        private void dgvOrden_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


