using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comercial.Formularios.Productos
{
    public partial class frmAltaModifProductos : Form
    {
        Clases.ClassProductos instProd = new Clases.ClassProductos();
        public int unProducto;
        public int unAccion;
        public Form llamador;
        private frmConsultaProductos frmConsultaProductos;

        public frmAltaModifProductos()
        {
            InitializeComponent();
        }

        public frmAltaModifProductos(frmConsultaProductos frmConsultaProductos)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.frmConsultaProductos = frmConsultaProductos;
        }

        private void txtCodProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Clases.ClassValidacion.soloNumeros(e);
        }

        private void txtCodBarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.ClassValidacion.soloNumeros(e);
        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void nudLista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void frmAltaModifProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                btnGrabar_Click(null, null);
            }

            if (e.KeyData == Keys.F6)
            {
                btnCancelar_Click(null, null);
            }

            if (e.KeyData == Keys.F7 & btnCalcularPrecio.Enabled)
            {
                btnCalcularPrecio_Click(null, null);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (formularioValido())
            {
                int resul;
                if (unAccion == 1)
                {
                    resul = instProd.ABMProductos(txtCodProveedor.Text.Trim(), txtCodBarras.Text.Trim(), int.Parse(cboRubro.SelectedValue.ToString()), txtDescripcion.Text.Trim(), int.Parse(cboProveedor.SelectedValue.ToString()), nudCosto.Value, nudLista.Value, nudStock.Value, nudMinima.Value, 1, 0,nudProveedor .Value );
                }
                else
                {
                    resul = instProd .ABMProductos( txtCodProveedor.Text.Trim(), txtCodBarras.Text.Trim(), int.Parse(cboRubro.SelectedValue.ToString()),  txtDescripcion.Text.Trim(), int.Parse(cboProveedor.SelectedValue.ToString()), nudCosto.Value, nudLista.Value, nudStock.Value, nudMinima.Value, 2,unProducto,nudProveedor .Value  );
                }

                if (resul == -1)
                {
                    MessageBox.Show("Ha ocurrido un error durante el procedimiento", "ABM Productos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.Close();
                }
            }
        }

        private bool formularioValido()
        {
            errorProvider1.Clear();

            if (txtCodProveedor.Text == string.Empty)
            {
                errorProvider1.SetError(txtCodProveedor, "Debe escribir el código de Proveedor");
                return false;
            }

            if (txtCodBarras.Text == string.Empty)
            {
                errorProvider1.SetError(txtCodBarras, "Debe escribir el código de Barras");
                return false;
            }

            if (cboRubro.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboRubro, "Debe seleccionar un rubro");
                return false;
            }

           

            if (cboProveedor.SelectedIndex == -1)
            {
                errorProvider1 .SetError (cboProveedor ,"Debe seleccionar proveedor");
                return false;
            }

            return true;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAltaModifProductos_Load(object sender, EventArgs e)
        {
            
            cargarCombos();
            if (unAccion == 2)
            {
                cargarProducto();
                nudStock.Enabled = false;
            }
            
        }

        private void cargarProducto()
        {
            DataTable producto = instProd.traerProductosParaEditar(unProducto);

            txtCodProveedor .Text = producto.Rows[0]["codProveedor"].ToString();
            txtCodBarras .Text = producto .Rows[0]["codBarras"].ToString ();
            txtDescripcion.Text = producto.Rows[0]["descripcion"].ToString();
            cboRubro.SelectedValue = int.Parse(producto.Rows[0]["fk_rubro"].ToString());
            cboProveedor.SelectedValue = int.Parse(producto.Rows[0]["fk_proveedor"].ToString());
            nudCosto.Value = decimal.Parse(producto.Rows[0]["costo"].ToString());
            nudLista.Value = decimal.Parse(producto .Rows [0]["precio"].ToString ());
            nudStock.Value = decimal.Parse(producto.Rows[0]["cantidad"].ToString());
            nudMinima.Value = decimal.Parse(producto.Rows[0]["cantidadMinima"].ToString());
            nudProveedor.Value = decimal.Parse(producto.Rows[0]["P_Proveedor"].ToString());
        }

        private void cargarCombos()
        {
            Clases .ClassConfiguracion instConfig = new Clases.ClassConfiguracion ();
            Clases.ClassProveedores instProveed = new Clases.ClassProveedores ();

            cboRubro.DataSource = instConfig.traeRubros();
            cboRubro.DisplayMember = "descripcion";
            cboRubro.ValueMember = "id";
            cboRubro.SelectedIndex = -1;

            cboProveedor.DataSource = instProveed.traeProveedores();
            cboProveedor.DisplayMember = "nombreComercial";
            cboProveedor.ValueMember = "id";
            cboProveedor.SelectedIndex = -1;
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void nudStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void nudMinima_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void frmAltaModifProductos_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnCalcularPrecio_Click(object sender, EventArgs e)
        {
            nudCosto.Value = nudProveedor.Value  * (1 - (nudDescuento.Value / 100));
            nudLista .Value = nudProveedor.Value * (1 + (nudGanancia .Value / 100));
        }

        private void nudCosto_Enter(object sender, EventArgs e)
        {
            Clases.ClassValidacion.seleccionarTodoNumericUpDown(nudCosto);
        }

        private void nudLista_Enter(object sender, EventArgs e)
        {
            Clases.ClassValidacion.seleccionarTodoNumericUpDown(nudLista);
        }

        private void nudStock_Enter(object sender, EventArgs e)
        {
            Clases.ClassValidacion.seleccionarTodoNumericUpDown(nudStock);
        }

        private void nudMinima_Enter(object sender, EventArgs e)
        {
            Clases.ClassValidacion.seleccionarTodoNumericUpDown(nudMinima);
        }

        private void cboProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProveedor.SelectedIndex != -1)
            {
                btnCalcularPrecio.Enabled = true;
                traerCoeficientes();
            }
            else
            {
                btnCalcularPrecio.Enabled = false;
            }
        }

        private void traerCoeficientes()
        {
            try
            {
                Clases.ClassProveedores instProv = new Clases.ClassProveedores();
                DataTable coef = instProv.traerCoeficientes(int.Parse(cboProveedor.SelectedValue.ToString()));

                if (coef.Rows.Count > 0)
                {
                    nudDescuento.Value = decimal.Parse(coef.Rows[0]["descuento"].ToString());
                    nudGanancia.Value = decimal.Parse(coef.Rows[0]["ganancia"].ToString());
                }
            }
            catch
            { }
        }

        private void nudProveedor_Enter(object sender, EventArgs e)
        {
            Clases.ClassValidacion.seleccionarTodoNumericUpDown(nudProveedor );
        }

        private void nudDescuento_Enter(object sender, EventArgs e)
        {
            Clases.ClassValidacion.seleccionarTodoNumericUpDown(nudDescuento );
        }

        private void nudGanancia_Enter(object sender, EventArgs e)
        {
            Clases.ClassValidacion.seleccionarTodoNumericUpDown(nudGanancia );
        }

        private void nudProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void nudDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void nudGanancia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }
    }
}
