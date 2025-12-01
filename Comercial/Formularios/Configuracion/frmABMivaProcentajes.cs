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
    public partial class frmABMivaProcentajes : Form
    {
        Clases.ClassConfiguracion instConfig = new Clases.ClassConfiguracion();
        int porcId;
        int accion = 0;
        public frmABMivaProcentajes()
        {
            InitializeComponent();
        }

        private void frmABMivaProcentajes_Load(object sender, EventArgs e)
        {
            estadoInicial();
        }

        private void estadoInicial()
        {
            dgvPorcentajes .DataSource = instConfig.traePorcentajesIva ();
            nudPorcentaje.Value = 0;

            if (dgvPorcentajes.Width == 355)
            {
                dgvPorcentajes.Width += gbDatos.Width + 5;
            }
            dgvPorcentajes.BringToFront();
            verificarBotones();
            dgvPorcentajes.Enabled = true;
            dgvPorcentajes.Focus();
        }
        private void verificarBotones()
        {
            btnAgregar.Enabled = true;
            if (dgvPorcentajes.RowCount > 0)
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

        private void estadoAM()
        {
            dgvPorcentajes.Enabled = false;
            btnAgregar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            dgvPorcentajes.Width = 355;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            estadoAM();
            accion = 1;
            nudPorcentaje.Value  = 0;
            nudPorcentaje.Focus();
            nudPorcentaje.Select(0, nudPorcentaje.Text.Length);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            estadoAM();
            accion = 2;
            nudPorcentaje.Value = decimal.Parse (dgvPorcentajes.CurrentRow.Cells["valor"].Value.ToString());

            porcId = int.Parse(dgvPorcentajes.CurrentRow.Cells["id"].Value.ToString());
            nudPorcentaje.Focus();
            nudPorcentaje.Select(0, nudPorcentaje.Text.Length);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            instConfig.ABMPorcentajeIva(int.Parse(dgvPorcentajes.CurrentRow.Cells["id"].Value.ToString()),3, 0);
            estadoInicial();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (formularioValido())
            {
                if (accion == 1)
                {
                    instConfig.ABMPorcentajeIva(porcId, 1, nudPorcentaje.Value);
                }
                if (accion == 2)
                {
                    instConfig.ABMPorcentajeIva(porcId, 2, nudPorcentaje.Value);
                }
                estadoInicial();
            }
        }

        private bool formularioValido()
        {
            errorProvider1.Clear();

            if (nudPorcentaje.Value == 0)
            {
                errorProvider1.SetError(nudPorcentaje, "indique un porcentaje de IVA");
                return false;
            }

            return true;

        }
        private void nudPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            estadoInicial();
        }

        private void frmABMivaProcentajes_KeyDown(object sender, KeyEventArgs e)
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
