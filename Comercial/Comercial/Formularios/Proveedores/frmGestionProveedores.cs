using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comercial.Formularios.Proveedores
{
    public partial class frmGestionProveedores : Form
    {
        Clases.ClassProveedores instProv = new Clases.ClassProveedores();

        public frmGestionProveedores()
        {
            InitializeComponent();
        }

        private void frmGestionProveedores_Load(object sender, EventArgs e)
        {
            estadoInicial();
            
        }

        private void estadoInicial()
        {
            lblId.Text = string.Empty;
            lblNombreComercial.Text = string.Empty;
            lblCuil.Text = string.Empty;
            lblDir.Text = string.Empty;
            lblEmail.Text = string.Empty;
            lblTel.Text = string.Empty;
            lblCel.Text = string.Empty;
            lblGanancia.Text = string.Empty;
            dgvProveedores.DataSource = instProv.traeProveedoresCabecera();
        
            verificarBotones();
        }

        private void verificarBotones()
        {
            if (dgvProveedores.RowCount > 0)
            {
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false ;
            }
        }

        private void dgvProveedores_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataTable prov = instProv.traeProveedoresPorId(dgvProveedores.CurrentRow.Cells["Cod"].Value.ToString());
            if (prov.Rows.Count > 0)
            {
                lblId.Text = prov.Rows[0]["id"].ToString();
                lblNombreComercial.Text = prov.Rows[0]["nombreComercial"].ToString();
                lblCuil.Text = prov.Rows[0]["cuil"].ToString();
                lblDir.Text = prov.Rows[0]["direccion"].ToString();
                lblEmail.Text = prov.Rows[0]["email"].ToString();
                lblTel.Text = prov.Rows[0]["telefono"].ToString();
                lblCel.Text = prov.Rows[0]["celular"].ToString();
                lblGanancia.Text = prov.Rows[0]["ganancia"].ToString();
                lblDescuento.Text = prov.Rows[0]["descuento"].ToString();
            }
        }

        private void frmGestionProveedores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2)
            {
                btnAgregar_Click(null, null);
            }

            if (e.KeyData == Keys.F3 & btnEditar .Enabled)
            {
                btnEditar_Click (null, null);
            }

            if (e.KeyData == Keys.F4 & btnEliminar.Enabled)
            {
                btnEliminar_Click (null, null);
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Formularios.Proveedores.frmAltaModifProveedores unFrmAltaModifProv = new frmAltaModifProveedores();
            unFrmAltaModifProv.unaAccion = 1;
            unFrmAltaModifProv.ShowDialog();
            estadoInicial();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Formularios.Proveedores.frmAltaModifProveedores unFrmAltaModifProv = new frmAltaModifProveedores();
            unFrmAltaModifProv.unaAccion = 2;
            unFrmAltaModifProv.unProveedor = dgvProveedores.CurrentRow.Cells["Cod"].Value.ToString();
            unFrmAltaModifProv.ShowDialog();
            estadoInicial();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            instProv.ABMProveedores(int.Parse(dgvProveedores.CurrentRow.Cells["Cod"].Value.ToString()), "", "", "", "", "", "", 0, 3,0);
            estadoInicial();
        }
    }
}
