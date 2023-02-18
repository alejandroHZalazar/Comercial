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
   
    public partial class frmLocalidades : Form
    {
        int locId;
        bool listo = false;
        Clases.ClassLocalidades instLocalidad = new Clases.ClassLocalidades(); 
        int accion = 0;

        public frmLocalidades()
        {
            InitializeComponent();
        }

        private void frmLocalidades_Load(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;

            estadoInicial();
            cargarCombos();
            listo = true; 
            cboProvincia.SelectedIndex = 0;
            cboBusqProv_SelectedIndexChanged(null, null);
        }

        private void estadoInicial()
        {
            if (dgvLocalidades.Width == 355)
            {
                dgvLocalidades.Width += gbDatos.Width + 5;
            }
            dgvLocalidades.BringToFront();
            verificarBotones();
            dgvLocalidades.Enabled = true;
            dgvLocalidades.Focus();
        }

        private void cboBusqProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listo)
            {
                dgvLocalidades.DataSource = instLocalidad.traeLocalidades(int.Parse(cboBusqProv.SelectedValue.ToString()));
            }
        }

        private void cargarCombos()
        {
            cboBusqProv.DataSource = instLocalidad.traeProvincias();
            cboBusqProv.DisplayMember = "nombre";
            cboBusqProv.ValueMember = "id";
            cboBusqProv.SelectedIndex = 0;

            cboProvincia .DataSource = instLocalidad.traeProvincias();
            cboProvincia.DisplayMember = "nombre";
            cboProvincia.ValueMember = "id";
            cboProvincia.SelectedIndex = 0;

        }

        private void verificarBotones()
        {
            btnAgregar.Enabled = true;
            if (dgvLocalidades.RowCount > 0)
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
            cboProvincia.SelectedIndex = -1;
            txtNombre.Focus();
       }

        private void estadoAM()
        {
            dgvLocalidades.Enabled = false;
            btnAgregar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            dgvLocalidades.Width = 355;

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            estadoAM();
            accion = 2;
            DataTable loc = instLocalidad.traeLocalidadesPorId(int.Parse (dgvLocalidades.CurrentRow.Cells["id"].Value.ToString()));

            txtNombre.Text = loc.Rows[0]["nombre"].ToString();
            cboProvincia .SelectedValue = loc .Rows [0]["fk_Provincia"].ToString ();

            locId = int.Parse (loc.Rows[0]["id"].ToString());
            txtNombre.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int salida = instLocalidad.ABMLocalidades(int.Parse(dgvLocalidades.CurrentRow.Cells["id"].Value.ToString()), 0, "", 3);
            if (salida != -1)
            {
                cboBusqProv_SelectedIndexChanged(null, null);
            }
            else
            {
                MessageBox.Show(this, "Ha ocurrido un error durante el procesamiento", "Gestión Localidades", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (formularioValido())
            {
                int salida;
                if (accion == 1)
                {
                    salida = instLocalidad.ABMLocalidades(0, int.Parse(cboProvincia.SelectedValue.ToString()), txtNombre.Text.Trim(), 1);
                }
                else
                {
                    salida = instLocalidad.ABMLocalidades(locId, int.Parse(cboProvincia.SelectedValue.ToString()), txtNombre.Text.Trim(), 2);
                }

                if (salida != -1)
                {
                    estadoInicial();
                    cboBusqProv_SelectedIndexChanged(null, null);
                    
                }
                else
                {
                    MessageBox.Show(this, "Ha ocurrido un error durante el procesamiento", "Gestión Localidades", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private bool formularioValido()
        {
            if (txtNombre.Text == string.Empty)
            {
                errorProvider1.SetError(txtNombre, "Debe escribir un nombre");
                return false;
            }

            if (cboProvincia.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboProvincia, "Debe seleccionar una Provincia");
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            estadoInicial();
        }

        private void frmLocalidades_KeyDown(object sender, KeyEventArgs e)
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

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
    }
}
