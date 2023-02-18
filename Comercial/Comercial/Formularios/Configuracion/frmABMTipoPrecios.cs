using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comercial.Formularios.Configuracion
{
    public partial class frmABMTipoPrecios : Form
    {
        int accion = 0;
        int tipoId;
        Clases.ClassConfiguracion instConfig = new Clases.ClassConfiguracion();

        public frmABMTipoPrecios()
        {
            InitializeComponent();
        }

        private void frmABMTipoPrecios_Load(object sender, EventArgs e)
        {
            cargarCombos();
            estadoInicial();
        }

        private void cargarCombos()
        {
            cboTipoValor.DataSource = instConfig.traetipoValoresPrecios();
            cboTipoValor.DisplayMember = "descripcion";
            cboTipoValor.ValueMember = "id";
        }

        private void estadoInicial()
        {
            dgvTipoPrecios .DataSource = instConfig.traeTipoPrecios ();
            dgvTipoPrecios.Columns["fk_tipoValor"].Visible = false;
            txtDescripcion.Text = string.Empty;
            nudValor.Value  = 0;
            cboTipoValor.SelectedIndex  = 0;
            if (dgvTipoPrecios.Width == 355)
            {
                dgvTipoPrecios.Width += gbDatos.Width + 5;
            }
            dgvTipoPrecios.BringToFront();
            verificarBotones();
            dgvTipoPrecios.Enabled = true;
            dgvTipoPrecios.Focus();
        }

        private void verificarBotones()
        {
            btnAgregar.Enabled = true;
            if (dgvTipoPrecios.RowCount > 0)
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
            cboTipoValor.SelectedIndex = 0;
            txtDescripcion.Text = string.Empty;
            nudValor.Value = 0;
            txtDescripcion.Focus();
        }

        private void estadoAM()
        {
            dgvTipoPrecios.Enabled = false;
            btnAgregar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            dgvTipoPrecios.Width = 355;

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            estadoAM();
            accion = 2;
            txtDescripcion.Text = dgvTipoPrecios.CurrentRow.Cells["descripcion"].Value.ToString();
            cboTipoValor.SelectedValue = dgvTipoPrecios.CurrentRow.Cells["fk_tipoValor"].Value.ToString();
            nudValor.Value = decimal.Parse (dgvTipoPrecios.CurrentRow.Cells["valor"].Value.ToString());
            tipoId = int.Parse(dgvTipoPrecios.CurrentRow.Cells["id"].Value.ToString());
            txtDescripcion.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            instConfig.ABMTipoPrecios(txtDescripcion.Text.Trim(), int.Parse(cboTipoValor.SelectedValue.ToString()), nudValor.Value, 3, tipoId);
            estadoInicial();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (formularioValido())
            {
                if (accion == 1)
                {
                    instConfig.ABMTipoPrecios(txtDescripcion.Text.Trim(), int.Parse(cboTipoValor.SelectedValue.ToString()), nudValor.Value, 1, 0);
                }
                if (accion == 2)
                {
                    instConfig.ABMTipoPrecios(txtDescripcion.Text.Trim(), int.Parse(cboTipoValor.SelectedValue.ToString()), nudValor.Value, 2, tipoId);
                }
                estadoInicial();
            }
        }

        private bool formularioValido()
        {
            errorProvider1.Clear();

            if (txtDescripcion.Text == string.Empty)
            {
                errorProvider1.SetError(txtDescripcion, "Debe indicar una descripcion");
                return false;
            }

            if (cboTipoValor.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboTipoValor, "Debe seleccionar un Tipo de Valor");
                return false;
            }

            return true;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            estadoInicial();
        }

        private void nudValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void frmABMTipoPrecios_KeyDown(object sender, KeyEventArgs e)
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
