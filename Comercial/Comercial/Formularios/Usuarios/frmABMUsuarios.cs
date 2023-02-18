using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comercial.Formularios.Usuarios
{
    public partial class frmABMUsuarios : Form
    {
        Clases.ClassConfiguracion instConfig = new Clases.ClassConfiguracion();
        int accion = 0;
        int userId = 0;
        
        public frmABMUsuarios()
        {
            InitializeComponent();
        }

        private void frmABMUsuarios_Load(object sender, EventArgs e)
        {
            estadoInicial();
        }

        private void estadoInicial()
        {
            dgvUsuarios.DataSource = instConfig.traeUsuarios();
            cboTipo.DataSource = instConfig.traeTipoUsuarios();
            cboTipo.DisplayMember = "descripcion";
            cboTipo.ValueMember = "id";
            dgvUsuarios.Columns["tipo"].Visible = false;
            txtNombre.Text = string.Empty;
            cboTipo .SelectedIndex  = 0;
            txtContraseña.Text = string.Empty;
            txtRepContraseña.Text = string.Empty;

            if (dgvUsuarios.Width == 355)
            {
                dgvUsuarios.Width += gbDatos.Width + 5;
            }
            dgvUsuarios.BringToFront();
            verificarBotones();
            dgvUsuarios.Enabled = true;
            dgvUsuarios.Focus();
        }

        private void verificarBotones()
        {
            btnAgregar.Enabled = true;
            if (dgvUsuarios.RowCount > 0)
            {
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            estadoAM();
            accion = 1;
            txtNombre .Text  = string.Empty;
            cboTipo .SelectedIndex  = 0;
            txtContraseña .Text  = string.Empty;
            txtRepContraseña.Text = string.Empty;
            txtContraseña.Enabled = true;
            txtRepContraseña.Enabled = true;
            txtNombre.Focus();
        }

        private void estadoAM()
        {
            dgvUsuarios.Enabled = false;
            btnAgregar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            dgvUsuarios.Width = 355;

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            estadoAM();
            accion = 2;
            txtNombre.Text = dgvUsuarios.CurrentRow.Cells["nombre"].Value.ToString();
            cboTipo.SelectedValue  = int.Parse (dgvUsuarios.CurrentRow.Cells["tipo"].Value.ToString());
            txtContraseña.Text = "123";
            txtRepContraseña.Text = "123";
            txtContraseña.Enabled = false ;
            txtRepContraseña.Enabled = false;
            userId = int.Parse(dgvUsuarios.CurrentRow.Cells["id"].Value.ToString());
            txtNombre.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            instConfig.ABMUsuarios(int.Parse(dgvUsuarios.CurrentRow.Cells["id"].Value.ToString()), "", "", 0, 3);
            estadoInicial();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            estadoInicial();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (formularioValido())
            {
                if (accion == 1)
                {
                    instConfig.ABMUsuarios (userId , txtNombre.Text.Trim(), txtContraseña.Text.Trim(), int.Parse (cboTipo .SelectedValue .ToString ()), 1);
                }
                if (accion == 2)
                {
                    instConfig.ABMUsuarios(userId, txtNombre .Text .Trim (),"", int.Parse (cboTipo .SelectedValue .ToString ()), 2);
                }
                estadoInicial();
            }
        }

        private bool formularioValido()
        {
            errorProvider1.Clear();
            if (txtNombre.Text == string.Empty)
            {
                errorProvider1.SetError(txtNombre , "Debe escribir un Nombre");
                return false;
            }

            if (cboTipo.SelectedIndex  < 0)
            {
                errorProvider1.SetError(cboTipo, "Debe seleccionar un tipo de usuario");
                return false;
            }

            if (txtContraseña.Text == string.Empty)
            {
                errorProvider1.SetError(txtContraseña, "debe escribir contraseña");
                return false;
            }

            if (txtRepContraseña .Text  == string.Empty)
            {
                errorProvider1.SetError(txtContraseña, "debe repetir la contraseña contraseña");
                return false;
            }

            if (txtContraseña.Text != txtRepContraseña .Text )
            {
                errorProvider1.SetError(txtContraseña, "deben coincidir las contraseñas");
                return false;
            }
            return true;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtRepContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void frmABMUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2 & btnAgregar.Enabled == true)
            {
                btnAgregar_Click(null, null);
            }

            if (e.KeyData == Keys.F3 & btnEditar.Enabled == true)
            {
                btnEditar_Click(null, null);
            }

            if (e.KeyData == Keys.F4 & btnEliminar.Enabled == true)
            {
                btnEliminar_Click(null, null);
            }

            if (e.KeyData == Keys.F5 & btnAgregar.Enabled == false)
            {
                btnGrabar_Click(null, null);
            }

            if (e.KeyData == Keys.F6 & btnAgregar.Enabled == false)
            {
                btnCancelar_Click(null, null);
            }
        }
    }
}
