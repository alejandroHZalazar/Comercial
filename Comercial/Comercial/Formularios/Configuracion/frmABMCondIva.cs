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
    public partial class frmABMCondIva : Form
    {
        int accion = 0;
        int condId = 0;
        Clases.ClassConfiguracion instConfig = new Clases.ClassConfiguracion();
        public frmABMCondIva()
        {
            InitializeComponent();
        }

        private void frmABMCondIva_Load(object sender, EventArgs e)
        {
            estadoInicial();
        }

        private void estadoInicial()
        {
            dgvCondiciones.DataSource = instConfig.traeCondIVA();
            txtDescripcion.Text = string.Empty;
            txtLetra.Text = string.Empty;
            txtAbrev.Text = string.Empty;
            if (dgvCondiciones.Width == 355)
            {
                dgvCondiciones.Width += gbDatos.Width + 5;
            }
            dgvCondiciones.BringToFront();
            verificarBotones();
            dgvCondiciones .Enabled = true ;
            dgvCondiciones .Focus ();
        }

        private void verificarBotones()
        {
            btnAgregar.Enabled = true;
            if (dgvCondiciones.RowCount > 0)
            {
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else
            {
                btnEditar.Enabled = false ;
                btnEliminar.Enabled = false;
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            estadoAM();
            accion = 1;
            txtAbrev .Text = string .Empty ;
            txtDescripcion .Text = string .Empty ;
            txtLetra .Text = string .Empty ;
            txtDescripcion.Focus();
        }

        private void estadoAM()
        {
            dgvCondiciones .Enabled = false ;
            btnAgregar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            dgvCondiciones.Width = 355; 

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            estadoAM();
            accion = 2;
            txtAbrev.Text = dgvCondiciones.CurrentRow.Cells["abrev"].Value.ToString();
            txtDescripcion.Text = dgvCondiciones.CurrentRow.Cells["descripcion"].Value.ToString();
            txtLetra.Text = dgvCondiciones.CurrentRow.Cells["letra"].Value.ToString();
            condId = int.Parse (dgvCondiciones.CurrentRow.Cells["id"].Value.ToString());
            txtDescripcion.Focus();
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtAbrev_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtLetra_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
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
                    instConfig.ABMcondIva(txtDescripcion.Text.Trim(), txtAbrev.Text.Trim(), txtLetra.Text.Trim(), condId, 1);
                }
                if (accion == 2)
                {
                    instConfig.ABMcondIva(txtDescripcion.Text.Trim(), txtAbrev.Text.Trim(), txtLetra.Text.Trim(), condId, 2);
                }
                estadoInicial();
            }
        }

        private bool formularioValido()
        {
            errorProvider1 .Clear ();
            if (txtDescripcion.Text == string.Empty)
            {
                errorProvider1.SetError(txtDescripcion, "Debe escribir una descripción");
                return false;
            }

            if (txtAbrev.Text == string.Empty)
            {
                errorProvider1.SetError(txtAbrev, "Debe escribir una Abreviatura");
                return false;
            }

            if (txtLetra.Text == string.Empty)
            {
                errorProvider1.SetError(txtLetra, "Indique una letra");
                return false;
            }

            return true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            instConfig.ABMcondIva("", "", "", int.Parse(dgvCondiciones.CurrentRow.Cells["id"].Value.ToString()),3);
            estadoInicial();
        }

        private void frmABMCondIva_KeyDown(object sender, KeyEventArgs e)
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
