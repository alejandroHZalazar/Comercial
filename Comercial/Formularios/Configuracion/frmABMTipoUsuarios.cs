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
    public partial class frmABMTipoUsuarios : Form
    {

        Clases.ClassConfiguracion instConfig = new Clases.ClassConfiguracion();

        public frmABMTipoUsuarios()
        {
            InitializeComponent();
        }

        private void frmABMTipoUsuarios_Load(object sender, EventArgs e)
        {
            estadoInicial();
        }

        public void estadoInicial()
        {
            dgvTipoUsuarios.DataSource = instConfig.traeTipoUsuarios();
            verificarBotones();
            dgvTipoUsuarios.Focus();
        }

        private void verificarBotones()
        {
            btnAgregar.Enabled = true;
            if (dgvTipoUsuarios.RowCount > 0)
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int salida = instConfig.ABMtipoUsuarios ("",int.Parse (dgvTipoUsuarios .CurrentRow .Cells ["id"].Value .ToString ()),3,"");

            if (salida != -1)
            {
                estadoInicial();
            }
            else
            {
                MessageBox.Show("Error al eliminar tipo de Usuario", "ABM Tipo de usuarios y Permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarModifTipoUsuarios unFrmAgregarModfiTipoUser = new frmAgregarModifTipoUsuarios(this);
            unFrmAgregarModfiTipoUser.tipoAccion = 1;
            unFrmAgregarModfiTipoUser.unTipoUsuario = 0;
            unFrmAgregarModfiTipoUser.llamador = this;
            unFrmAgregarModfiTipoUser.ShowDialog();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmAgregarModifTipoUsuarios unFrmAgregarModfiTipoUser = new frmAgregarModifTipoUsuarios(this);
            unFrmAgregarModfiTipoUser.tipoAccion = 2;
            unFrmAgregarModfiTipoUser.unTipoUsuario = int.Parse (dgvTipoUsuarios .CurrentRow .Cells ["id"].Value .ToString ());
            unFrmAgregarModfiTipoUser.unNombre = dgvTipoUsuarios.CurrentRow.Cells["descripcion"].Value.ToString();
            unFrmAgregarModfiTipoUser.llamador = this;
            unFrmAgregarModfiTipoUser.ShowDialog();
        }

        private void frmABMTipoUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2)
            {
                btnAgregar_Click(null, null);
            }

            if (e.KeyData == Keys.F3 & dgvTipoUsuarios .RowCount > 0)
            {
                btnEditar_Click (null, null);
            }

            if (e.KeyData == Keys.F4 & dgvTipoUsuarios.RowCount > 0)
            {
                btnEliminar_Click (null, null);
            }


        }

    }
}
