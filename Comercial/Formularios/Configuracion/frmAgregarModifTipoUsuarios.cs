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
    public partial class frmAgregarModifTipoUsuarios : Form
    {
        public int tipoAccion; //1 nuevo; 2 edicion
        public int unTipoUsuario;
        public string unNombre;
        public Form llamador;

        Clases.ClassConfiguracion instConfig = new Clases.ClassConfiguracion();
        private frmABMTipoUsuarios frmABMTipoUsuarios;

        public frmAgregarModifTipoUsuarios()
        {
            InitializeComponent();
        }

        public frmAgregarModifTipoUsuarios(frmABMTipoUsuarios frmABMTipoUsuarios)
        {
            // TODO: Complete member initialization
            this.frmABMTipoUsuarios = frmABMTipoUsuarios;
            InitializeComponent();
        }

        private void frmAgregarModifTipoUsuarios_Load(object sender, EventArgs e)
        {
            estadoInicial();
            if (tipoAccion == 2)
            {
                txtNombre.Text = unNombre;
                llenarGrilla();
                traerPermisos();
            }
        }



        private void estadoInicial()
        {
            
            llenarGrilla();
        }

        private void llenarGrilla()
        {
            dgvMenuPermisos.Rows.Clear();
            DataTable Menu = instConfig.traerMenuPermisos();
             foreach (DataRow fila in Menu.Rows)
            {
                dgvMenuPermisos.Rows.Add(fila["funcion"].ToString(), false, fila["id"].ToString());
            }
        }

        private void traerPermisos()
        {
            DataTable permisos = instConfig.traerTipoUsuariosPermisos(unTipoUsuario);
            DataRow [] resul;

            foreach (DataGridViewRow fila in dgvMenuPermisos.Rows)
            {
                resul = permisos.Select("fk_menuPermiso = " + fila.Cells["id"].Value, "fk_menuPermiso");
                if (resul.LongLength > 0)
                {
                    fila.Cells["Permiso"].Value = true;
                }
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (validarFormulario())
            {
                string permisos = string.Empty;
                int salida = -1;

                foreach (DataGridViewRow fila in dgvMenuPermisos.Rows)
                {
                    if (fila.Cells["permiso"].Value.ToString() == "True")
                    {
                        permisos += fila.Cells["id"].Value.ToString() + ";";
                    }
                }

                if (tipoAccion == 1)
                {
                    
                     salida = instConfig.ABMtipoUsuarios(txtNombre.Text.Trim(), 0, 1, permisos);

                }

                else if (tipoAccion == 2)
                {
                     salida = instConfig.ABMtipoUsuarios(txtNombre.Text.Trim(), unTipoUsuario , 2, permisos);
                }

                if (salida != -1)
                {
                    ((frmABMTipoUsuarios)this.llamador).estadoInicial();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error durante el procedimiento", "Agregar o Modificar tipo de Usuarios y Permiso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private bool validarFormulario()
        {
            errorProvider1.Clear();
            if (txtNombre.Text == string.Empty)
            {
                errorProvider1.SetError(txtNombre, "Debe indicar un nombre para el tipo de Usuario");
                return false;
            }

            foreach (DataGridViewRow fila in dgvMenuPermisos.Rows )
            {
                
                if (fila.Cells["Permiso"].Value.ToString () == "True")
                {
                    return true;
                }
            }

            errorProvider1.SetError(dgvMenuPermisos, "Debe seleccionar al menos un permiso");
            return false;

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void frmAgregarModifTipoUsuarios_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void frmAgregarModifTipoUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                btnGrabar_Click(null, null);
            }

        }

        private void rbtTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtTodos.Checked)
            {
                foreach (DataGridViewRow fila in dgvMenuPermisos.Rows)
                {
                    fila.Cells["Permiso"].Value = true;
                }
            }
        }

        private void rbtNinguno_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtNinguno.Checked)
            {
                foreach (DataGridViewRow fila in dgvMenuPermisos.Rows)
                {
                    fila.Cells["Permiso"].Value = false ;
                }
            }
        }
    }
}
