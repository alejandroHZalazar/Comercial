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
    public partial class frmAltaModifProveedores : Form
    {
       public int unaAccion;
       public string unProveedor;
        Clases.ClassProveedores instProv = new Clases.ClassProveedores();

        public frmAltaModifProveedores()
        {
            InitializeComponent();
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Clases.ClassValidacion.validarEmail(txtEmail))
            {
                txtEmail.ForeColor = Color.Green;
            }
            else
            {
                txtEmail.ForeColor = Color.Red;
            }

        }

       

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.ClassValidacion.soloNumeros(e);
        }

        private void txtCel_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.ClassValidacion.soloNumeros(e);
        }

        private void nudGanancia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void nudGanancia_Enter(object sender, EventArgs e)
        {
            Clases.ClassValidacion.seleccionarTodoNumericUpDown(nudGanancia );
        }

        private void frmAltaModifProveedores_Load(object sender, EventArgs e)
        {
            if (unaAccion == 2)
            {
               DataTable prov =  instProv.traeProveedoresPorId(unProveedor);

               if (prov.Rows.Count > 0)
               {
                   txtNombreComercial.Text = prov.Rows[0]["nombreComercial"].ToString();
                   mtbCuil.Text = prov.Rows[0]["cuil"].ToString();
                   txtDir.Text = prov.Rows[0]["direccion"].ToString();
                   txtEmail.Text = prov.Rows[0]["email"].ToString();
                   txtTel.Text = prov.Rows[0]["telefono"].ToString();
                   txtCel.Text = prov.Rows[0]["celular"].ToString();
                   nudGanancia.Value  = decimal .Parse (prov.Rows[0]["ganancia"].ToString());
                    nudDescuento.Value = decimal.Parse(prov.Rows[0]["descuento"].ToString());

               }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validarFormulario())
            {
                long salida;

                if (unaAccion == 1)
                {
                    string cuil = mtbCuil.Text.Replace("-", "");
                    salida = instProv.ABMProveedores(0, txtNombreComercial.Text.Trim(), cuil, txtDir.Text.Trim(), txtEmail.Text.Trim(), txtTel.Text, txtCel.Text, nudGanancia.Value, 1,nudDescuento .Value );
                }
                else
                { 
                    string cuil = mtbCuil .Text .Replace("-","");
                    salida = instProv.ABMProveedores(int.Parse (unProveedor) , txtNombreComercial.Text.Trim(), cuil, txtDir.Text.Trim(), txtEmail.Text.Trim(), txtTel.Text, txtCel.Text, nudGanancia.Value, 2,nudDescuento .Value );
                }

                if (salida != -1)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ah ocurrido un  error durante el procesamiento", "GESTION PROVEEDORES", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool validarFormulario()
        {
            errorProvider1.Clear();

            if (txtNombreComercial.Text == string.Empty)
            {
                errorProvider1.SetError(txtNombreComercial, "Debe indicar el nombre comercial");
                return false;
            }

            if (mtbCuil.Text == string.Empty | mtbCuil.Text.Length < 11)
            {
                errorProvider1 .SetError (mtbCuil ,"El cuil ingresado debe tener 11 dígitos");
                return false;
            }

            if (txtDir.Text == string.Empty)
            {
                errorProvider1.SetError(txtDir, "Debe indicar una dirección");
                return false;
            }

           
            return true;

        }

        private void txtNombreComercial_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtDir_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (Clases .ClassValidacion .validarEmail (txtEmail ))
            {
                txtEmail.ForeColor = Color.Green;
            }
            else
            {
                txtEmail.ForeColor = Color.Red;
            }
        }

        private void txtNombreComercial_Enter(object sender, EventArgs e)
        {
            Clases.ClassValidacion.seleccionarTodoTextBox(txtNombreComercial);
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
            Clases.ClassValidacion.seleccionarTodoTextBox(txtTel );
        }

        private void txtCel_Enter(object sender, EventArgs e)
        {
            Clases.ClassValidacion.seleccionarTodoTextBox(txtCel);
        }

        private void mtbCuil_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.ClassValidacion.soloNumeros(e);
        }

        private void nudDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }
    }
}
