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
    public partial class frmABMrubros : Form
    {
        Clases.ClassConfiguracion instConfig = new Clases.ClassConfiguracion();
        int accion = 0;
        int idRubro;

        public frmABMrubros()
        {
            InitializeComponent();
        }

        private void frmABMrubros_Load(object sender, EventArgs e)
        {
            dgvRubros.DataSource = instConfig.traeRubros ();
            txtDescripcion.Text = string.Empty;

            if (dgvRubros.Width == 355)
            {
                dgvRubros.Width += gbDatos.Width + 5;
            }
            dgvRubros.BringToFront();
            verificarBotones();
            dgvRubros.Enabled = true;
            dgvRubros.Focus();
        }

        private void estadoInicial()
        {
            dgvRubros.DataSource = instConfig.traeRubros ();
            txtDescripcion.Text = string.Empty;
            
            if (dgvRubros.Width == 355)
            {
                dgvRubros.Width += gbDatos.Width + 5;
            }
            dgvRubros.BringToFront();
            verificarBotones();
            dgvRubros.Enabled = true;
            dgvRubros.Focus();
        }


        private void verificarBotones()
        {
            btnAgregar.Enabled = true;
            if (dgvRubros.RowCount > 0)
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
            txtDescripcion.Text = string.Empty;
            txtDescripcion.Focus();
        }

        private void estadoAM()
        {
            dgvRubros.Enabled = false;
            btnAgregar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            dgvRubros.Width = 355;

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            estadoAM();
            accion = 2;
            txtDescripcion.Text = dgvRubros.CurrentRow.Cells["descripcion"].Value.ToString();

            idRubro = int.Parse(dgvRubros.CurrentRow.Cells["id"].Value.ToString());
            txtDescripcion.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            instConfig.ABMRubros (int.Parse (dgvRubros .CurrentRow .Cells["id"].Value .ToString ()),3,txtDescripcion .Text.Trim ());
            estadoInicial();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (formularioValido())
            {
                if (accion == 1)
                {
                    instConfig.ABMRubros(idRubro, 1, txtDescripcion.Text.Trim());
                }
                if (accion == 2)
                {
                    instConfig.ABMRubros(idRubro, 2, txtDescripcion.Text.Trim());
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

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            estadoInicial();
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void frmABMrubros_KeyDown(object sender, KeyEventArgs e)
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
