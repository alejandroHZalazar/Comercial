using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comercial.Formularios.Clientes
{
    public partial class frmABMClientes : Form
    {
        Clases.ClassClientes instClie = new Clases.ClassClientes();

        public frmABMClientes()
        {
            InitializeComponent();
        }

        private void frmABMClientes_Load(object sender, EventArgs e)
        {
            estadoInicial();
        }

        private void estadoInicial()
        {
            limpiarLabels();
            txtBuscar.Text = string.Empty;
            dgvClientes .DataSource = instClie.traeClientesPpal("");
            verificarBotones();
            cboBusqueda.SelectedIndex  = instClie.traerFiltroDefecto();

        }

        private void verificarBotones()
        {
            btnAgregar.Enabled = true;

            if (dgvClientes.RowCount > 0)
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

        private void limpiarLabels()
        {
            lblId.Text = string.Empty;
            lblNombreComercial.Text = string.Empty;
            lblRaonSocial.Text = string.Empty;
            lblCuil.Text = string.Empty;
            lblDir.Text = string.Empty;
            lblEmail.Text = string.Empty;
            lblTel.Text = string.Empty;
            lblCel.Text = string.Empty;
            lblContacto.Text = string.Empty;
            lblIVA.Text = string.Empty;
            lblVendedor.Text = string.Empty;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text != string.Empty)
            {
                limpiarLabels();
                if (cboBusqueda.SelectedIndex == 0)
                {
                    dgvClientes.DataSource = instClie.traeClientesPpal(" and nombreComercial like '%" + txtBuscar.Text + "%'");
                }
                if (cboBusqueda.SelectedIndex == 1)
                {
                    dgvClientes.DataSource = instClie.traeClientesPpal(" and razonSocial like '%" + txtBuscar.Text + "%'");
                }
                if (cboBusqueda.SelectedIndex == 2)
                {
                    dgvClientes.DataSource = instClie.traeClientesPpal(" and cuil = " + txtBuscar.Text);
                }

                if (cboBusqueda.SelectedIndex == 3)
                {
                    dgvClientes.DataSource = instClie.traeClientesPpal(" and l.nombre like '%" + txtBuscar.Text.Trim() + "%'");
                }

                if (cboBusqueda.SelectedIndex == 4)
                {
                    dgvClientes.DataSource = instClie.traeClientesPpal(" and z.nombre like '%" + txtBuscar.Text.Trim() + "%'");
                }

                verificarBotones();
            }
        }

        private void dgvClientes_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            limpiarLabels();
            DataTable cliente = instClie.traeTodosDatos(int.Parse(dgvClientes.CurrentRow.Cells["ID"].Value.ToString()));

            if (cliente.Rows.Count > 0)
            {
                lblId.Text = cliente.Rows[0]["id"].ToString();
                lblNombreComercial.Text = cliente.Rows[0]["nombreComercial"].ToString();
                lblRaonSocial.Text = cliente.Rows[0]["razonSocial"].ToString();
                lblCuil.Text = cliente.Rows[0]["cuil"].ToString();
                lblDir.Text = cliente.Rows[0]["direccion"].ToString();
                lblEmail.Text = cliente.Rows[0]["email"].ToString();
                lblTel.Text = cliente.Rows[0]["telefono"].ToString();
                lblCel.Text = cliente.Rows[0]["celular"].ToString();
                lblContacto.Text = cliente.Rows[0]["contacto"].ToString();
                lblIVA.Text = cliente.Rows[0]["descripcion"].ToString();
                lblVendedor.Text = cliente.Rows[0]["nombre"].ToString();
                lblLocalidad.Text = cliente.Rows[0]["Localidad"].ToString();
                lblProvincia.Text = cliente.Rows[0]["Provincia"].ToString();
                lblZona.Text = cliente.Rows[0]["Zona"].ToString();
               
            }
        }
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnBuscar_Click(null, null);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaModifClientes unFrmAltaModifClientes = new frmAltaModifClientes();
            unFrmAltaModifClientes.unaAccion = 1;
            unFrmAltaModifClientes.idCliente = 0;
            unFrmAltaModifClientes.ShowDialog();
            if (unFrmAltaModifClientes.DialogResult == DialogResult.OK)
            {
                estadoInicial();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmAltaModifClientes unFrmAltaModifClientes = new frmAltaModifClientes();
            unFrmAltaModifClientes.unaAccion = 2;
            unFrmAltaModifClientes.idCliente = int.Parse (dgvClientes .CurrentRow .Cells ["ID"].Value .ToString ());
            unFrmAltaModifClientes.ShowDialog();
            if (unFrmAltaModifClientes.DialogResult == DialogResult.OK)
            {
                estadoInicial();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            instClie.ABMClientes(int.Parse(dgvClientes.CurrentRow.Cells["ID"].Value.ToString()), "", "", "", "", "", "", "", "", 0, 0, 3,0,0);
            estadoInicial();
        }

        private void frmABMClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2)
            {
                btnAgregar_Click(null, null);
            }

            if (e.KeyData == Keys.F3 & btnEditar.Enabled)
            {
                btnEditar_Click(null, null);
            }

            if (e.KeyData == Keys.F4 & btnEliminar .Enabled )
            {
                btnEliminar_Click(null, null);
            }
        }

       
    }
}
