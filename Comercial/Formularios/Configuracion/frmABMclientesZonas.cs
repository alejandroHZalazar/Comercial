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
    public partial class frmABMclientesZonas : Form
    {
        Clases.ClassConfiguracion instConfig = new Clases.ClassConfiguracion();
        int accion;
        int zonaId;

        public frmABMclientesZonas()
        {
            InitializeComponent();
        }

        private void frmABMclientesZonas_Load(object sender, EventArgs e)
        {
            estadoInicial();
        }

        private void estadoInicial()
        {
            dgvZonas.DataSource = instConfig.traeZonasClientes();
            txtNombre.Text = string.Empty;

            if (dgvZonas.Width == 355)
            {
                dgvZonas.Width += gbDatos.Width + 5;
            }
            dgvZonas.BringToFront();
            verificarBotones();
            dgvZonas.Enabled = true;
            dgvZonas.Focus();
        }

        private void verificarBotones()
        {
            btnAgregar.Enabled = true;
            if (dgvZonas.RowCount > 0)
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
            txtNombre.Text = string.Empty;
            txtNombre.Focus();
        }

        private void estadoAM()
        {
            dgvZonas.Enabled = false;
            btnAgregar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            dgvZonas.Width = 355;

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            estadoAM();
            accion = 2;
            txtNombre.Text = dgvZonas.CurrentRow.Cells["nombre"].Value.ToString();

            zonaId = int.Parse(dgvZonas.CurrentRow.Cells["id"].Value.ToString());
            txtNombre.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            instConfig.ABMZonasClientes(int.Parse(dgvZonas.CurrentRow.Cells["id"].Value.ToString()), "", 3);
            estadoInicial();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (formularioValido())
            {
                if (accion == 1)
                {
                    instConfig.ABMZonasClientes(0, txtNombre.Text.Trim(), 1);
                }
                if (accion == 2)
                {
                    instConfig.ABMZonasClientes(zonaId, txtNombre.Text.Trim(), 2);
                }
                estadoInicial();
            }
        }

        private bool formularioValido()
        {
            if (txtNombre.Text == string.Empty)
            {
                errorProvider1.SetError(txtNombre, "Debe indicar el nombre");
                return false;
            }

            return true;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void frmABMclientesZonas_KeyDown(object sender, KeyEventArgs e)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            estadoInicial();
        }
    }
}
