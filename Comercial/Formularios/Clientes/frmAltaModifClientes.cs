using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comercial.Formularios.Clientes
{
    public partial class frmAltaModifClientes : Form
    {
        Clases.ClassClientes instClie = new Clases.ClassClientes();
        public int idCliente;
        public int unaAccion;
        bool listo = false;

        public frmAltaModifClientes()
        {
            InitializeComponent();
        }

        private void frmAltaModifClientes_Load(object sender, EventArgs e)
        {
            cargarCombos();
            listo = true;
            cboProvincia_SelectedIndexChanged(null, null);
            if (unaAccion == 2)
            {
                cargarCliente();
            }
            
        }

        private void cargarCliente()
        {
            DataTable clie =  instClie.traeTodosDatos(idCliente);
            if (clie.Rows.Count > 0)
            {
                txtNombreComercial.Text = clie.Rows[0]["nombreComercial"].ToString();
                txtRazonSocial.Text = clie.Rows[0]["razonSocial"].ToString();
                mtbCuil.Text = clie.Rows[0]["cuil"].ToString();
                txtDir.Text = clie.Rows[0]["direccion"].ToString();
                txtEmail.Text = clie.Rows[0]["email"].ToString();
                txtTel.Text = clie.Rows[0]["telefono"].ToString();
                txtCel.Text = clie.Rows[0]["celular"].ToString();
                txtContacto.Text = clie.Rows[0]["contacto"].ToString();
                cboIVA.SelectedValue = clie.Rows[0]["fk_condIva"].ToString();
                cboVendedor.SelectedValue = clie.Rows[0]["fk_Vendedor"].ToString();
                cboProvincia .SelectedValue = clie.Rows[0]["fk_Provincia"].ToString();
                cboLocalidad .SelectedValue = clie.Rows[0]["fk_localidad"].ToString();
                cboZona .SelectedValue = clie.Rows[0]["fk_zona"].ToString();
                
            }
        }

        private void cargarCombos()
        {
            cboIVA.DataSource = instClie.traerCondIVA();
            cboIVA.ValueMember = "id";
            cboIVA.DisplayMember = "descripcion";
            cboIVA.SelectedIndex = -1;

            cboVendedor.DataSource = instClie.traerVendedores();
            cboVendedor.ValueMember = "id";
            cboVendedor.DisplayMember = "nombre";
            cboVendedor.SelectedIndex = -1;

            cboProvincia.DataSource = instClie.traerProvincias();
            cboProvincia.ValueMember = "id";
            cboProvincia.DisplayMember = "nombre";
            cboProvincia.SelectedIndex = cboProvincia.Items.Count > 0 ? 0 : 1;

            cboZona.DataSource = instClie.traerZonas();
            cboZona.ValueMember = "id";
            cboZona.DisplayMember = "nombre";
            cboZona.SelectedIndex = cboZona.Items.Count > 0 ? 0 : 1;
        }

        private void txtNombreComercial_Enter(object sender, EventArgs e)
        {
            Clases.ClassValidacion.seleccionarTodoTextBox(txtNombreComercial);
        }

        private void txtRazonSocial_Enter(object sender, EventArgs e)
        {
            Clases.ClassValidacion.seleccionarTodoTextBox(txtRazonSocial );
        }

        private void mtbCuil_Enter(object sender, EventArgs e)
        {
            Clases.ClassValidacion.seleccionarTodoMask(mtbCuil);
        }

        private void txtDir_Enter(object sender, EventArgs e)
        {
            Clases.ClassValidacion.seleccionarTodoTextBox(txtDir);
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            Clases.ClassValidacion.seleccionarTodoTextBox(txtEmail);
        }

        private void txtTel_Enter(object sender, EventArgs e)
        {
            Clases.ClassValidacion.seleccionarTodoTextBox(txtTel);
        }

        private void txtCel_Enter(object sender, EventArgs e)
        {
            Clases.ClassValidacion.seleccionarTodoTextBox(txtCel);
        }

        private void txtContacto_Enter(object sender, EventArgs e)
        {
            Clases.ClassValidacion.seleccionarTodoTextBox(txtContacto);
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Clases.ClassValidacion .validarEmail (txtEmail))
            {
                txtEmail.ForeColor = Color.Green;
            }
            else
            {
                txtEmail.ForeColor = Color.Red;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (Clases .ClassValidacion .validarEmail(txtEmail ))
            {
                txtEmail.ForeColor = Color.Green;
            }
            else
            {
                txtEmail.ForeColor = Color.Red;
            }
        }

        private void mtbCuil_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtNombreComercial_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtRazonSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtDir_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.ClassValidacion.soloNumeros(e);
        }

        private void txtCel_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.ClassValidacion.soloNumeros(e);
        }

        private void txtContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (formularioValido())
            {
                int salida = -1;
                if (unaAccion == 1)
                {
                    string cuil = mtbCuil.Text.Replace("-", "");
                    salida = instClie.ABMClientes(0, txtNombreComercial.Text.Trim(), txtRazonSocial.Text.Trim(), cuil, txtDir.Text.Trim(), txtEmail.Text.Trim(), txtTel.Text.Trim(), txtCel.Text.Trim(), txtContacto.Text.Trim(), int.Parse(cboIVA.SelectedValue.ToString()), int.Parse(cboVendedor.SelectedValue.ToString()), 1,int.Parse (cboZona .SelectedValue .ToString ()),int.Parse (cboLocalidad.SelectedValue.ToString ())); 
                }
                if (unaAccion == 2)
                {
                    string cuil = mtbCuil.Text.Replace("-", "");
                   salida =  instClie.ABMClientes(idCliente , txtNombreComercial.Text.Trim(), txtRazonSocial.Text.Trim(), cuil, txtDir.Text.Trim(), txtEmail.Text.Trim(), txtTel.Text.Trim(), txtCel.Text.Trim(), txtContacto.Text.Trim(), int.Parse(cboIVA.SelectedValue.ToString()), int.Parse(cboVendedor.SelectedValue.ToString()), 2, int.Parse(cboZona.SelectedValue.ToString()), int.Parse(cboLocalidad.SelectedValue.ToString()) );
                }

                if (salida != -1)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, "Ha ocurrido un error dureante el procesamiento", "GESTION DE CLIENTES", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private bool formularioValido()
        {
            errorProvider1.Clear();

            if (txtNombreComercial.Text == string.Empty)
            {
                errorProvider1.SetError(txtNombreComercial, "Debe escribir el nommbre Comercial");
                return false;
            }

           if (cboIVA.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboIVA, "Debe indicar la condición ante IVA");
                return false;
            }

            if (cboVendedor.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboVendedor, "Debe indicar el vendedor");
                return false;
            }

            if (cboZona .SelectedIndex == -1)
            {
                errorProvider1.SetError(cboZona , "Debe indicar una Zona");
                return false;
            }

            if (cboProvincia.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboZona, "Debe indicar una Provincia");
                return false;
            }

            return true;
        }

        private void frmAltaModifClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                btnGrabar_Click(null, null);
            }

            if (e.KeyData == Keys.F6)
            {
                btnCancelar_Click(null, null);
            }
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listo )
            {
                cboLocalidad.DataSource = instClie.traerLocalidad(int.Parse(cboProvincia.SelectedValue.ToString()));
                cboLocalidad.ValueMember = "id";
                cboLocalidad.DisplayMember = "nombre";
                cboLocalidad.SelectedIndex = cboLocalidad.Items.Count > 0 ? 0 : -1;
            }
        }

       

        
    }
}
