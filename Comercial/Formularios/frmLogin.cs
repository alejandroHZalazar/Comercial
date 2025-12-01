using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comercial.Formularios
{
    public partial class frmLogin : Form
    {
        Clases.classUsuarios instUser = new Clases.classUsuarios();
        Clases.ClassParametros instParam = new Clases.ClassParametros();
       

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (datosValidos())
            {
                DataTable user =  instUser.traerUsuario(txtUsuario.Text.Trim(), txtPass.Text.Trim());

                if (user.Rows.Count > 0)
                {
                    instUser.obtenerUsuario(user.Rows[0]["nombre"].ToString(), user.Rows[0]["tipo"].ToString(), user.Rows[0]["id"].ToString());
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    txtUsuario.Focus();
                    errorProvider1.SetError(txtUsuario, "Usuario y/o contraseña incorrectos");
                }

                                
            }
        }

        private bool datosValidos()
        {
            errorProvider1.Clear();
            if (txtUsuario.Text == string.Empty)
            {
                errorProvider1.SetError(txtUsuario, "Debe indicar un usuario");
                return false;
            }

            if (txtPass.Text == string.Empty)
            {
                errorProvider1.SetError(txtPass, "Debe indicar una contraseña");
                return false;
            }

            return true;
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            buscarLogo();
        }

        private void buscarLogo()
        {
            try
            {
                pbLogo.Image = Image.FromFile(instParam.traePathLogo());
            }
            catch { }
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            Clases.ClassValidacion.seleccionarTodoTextBox(txtUsuario);
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            Clases.ClassValidacion.seleccionarTodoTextBox(txtPass );
        }

    }
}
