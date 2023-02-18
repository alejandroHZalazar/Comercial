using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comercial.Formularios.Productos
{
    public partial class frmConsultaProductos : Form
    {
        Clases.ClassProductos instProd = new Clases.ClassProductos();
        int cantDec = Clases.ClassProductos.cantDecimales();
        int cantStock = Clases.ClassProductos.cantDecimalesStock();

        public frmConsultaProductos()
        {
            InitializeComponent();
        }

        private void frmConsultaProductos_Load(object sender, EventArgs e)
        {
            estadoInicial();

        }

        private void estadoInicial()
        {
            cboFiltro.SelectedIndex = instProd.traerDefaultBusq();
            dgvProductos.DataSource = null;
            dgvProductos.Rows.Clear();
            txtFiltro.Text = string.Empty;
            lblCodProducto.Text = string.Empty;
            lblCodProveedor.Text = string.Empty;
            lblCodBarras.Text = string.Empty;
            lblIVA.Text = string.Empty;
            lblRubro.Text = string.Empty;
            lblProveedor.Text = string.Empty;
            lblLista.Text = string.Empty;
            lblCosto.Text = string.Empty;
            lblStock.Text = string.Empty;
            lblPProveedor.Text = string.Empty;
            txtFiltro.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarProducto();
        }

        private void buscarProducto()
        {
            if (txtFiltro.Text != string.Empty)
            {
                if (cboFiltro.SelectedIndex == 0)
                {
                   dgvProductos .DataSource = instProd.traeProductosPpal(" where baja = 0 and codProveedor = '" + txtFiltro.Text.Trim() + "'");
                }
                else if (cboFiltro.SelectedIndex == 1)
                {
                    dgvProductos.DataSource = instProd.traeProductosPpal(" where baja = 0 and codBarras = " + txtFiltro.Text.Trim());
                }
                else
                {
                    dgvProductos.DataSource = instProd.traeProductosPpal(" where baja = 0 and descripcion like '%" + txtFiltro.Text.Trim() + "%'");

                }

                if (dgvProductos .RowCount == 0)
                {
                    estadoInicial();
                }
                else
                {
                    dgvProductos.Columns["id"].Visible = false;
                    dgvProductos.Columns["fk_Rubro"].Visible = false;
                    dgvProductos.Columns["iva"].Visible = false;
                    dgvProductos.Columns["fk_proveedor"].Visible = false;
                    dgvProductos.Columns["baja"].Visible = false;
                    dgvProductos.Focus();
                }
            }
            else
            {
                estadoInicial();
            }
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnBuscar_Click(null, null);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaModifProductos unFrmABMProductos = new frmAltaModifProductos(this);
            unFrmABMProductos.unAccion = 1;
            unFrmABMProductos.unProducto = 0;
            unFrmABMProductos.llamador = this;
            unFrmABMProductos.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.RowCount > 0)
            {
                frmAltaModifProductos unFrmABMProductos = new frmAltaModifProductos(this);
                unFrmABMProductos.unAccion = 2;
                unFrmABMProductos.unProducto = int.Parse(dgvProductos.CurrentRow.Cells["id"].Value.ToString());
                unFrmABMProductos.llamador = this;
                unFrmABMProductos.ShowDialog();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            instProd.ABMProductos("", "", 0, "", 0, 0, 0, 0, 0, 3, int.Parse(dgvProductos.CurrentRow.Cells["ID"].Value.ToString()),0);
            estadoInicial();
            
        }

        private void frmConsultaProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys .F2)
            {
                btnAgregar_Click(null, null);
            }

            if (e.KeyData == Keys.F3 & btnEditar .Enabled )
            {
                btnEditar_Click (null, null);
            }

            if (e.KeyData == Keys.F4 & btnEliminar .Enabled )
            {
                btnEliminar_Click (null, null);
            }
        }

        private void dgvProductos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            buscarDatosProductos();
        }

        private void buscarDatosProductos()
        {
            DataTable Prod = instProd.traerProductosParaEditar(int.Parse(dgvProductos.CurrentRow.Cells["ID"].Value.ToString()));

            if (Prod.Rows.Count > 0)
            {
                lblCodProducto.Text = dgvProductos.CurrentRow.Cells["ID"].Value.ToString();
                lblCodProveedor.Text = Prod.Rows[0]["codProveedor"].ToString();
                lblCodBarras.Text = Prod.Rows[0]["codBarras"].ToString();
                lblDescripcion.Text = Prod.Rows[0]["descripcion"].ToString();
                lblIVA.Text =  (Math.Round (decimal.Parse (Prod.Rows[0]["iva"].ToString()),cantDec)).ToString ();
                lblRubro.Text = Prod.Rows[0]["rubro"].ToString();
                lblProveedor.Text = Prod.Rows[0]["Proveedor"].ToString();
                lblLista.Text = (Math.Round(decimal.Parse(Prod.Rows[0]["precio"].ToString()), cantDec)).ToString();
                lblCosto.Text = (Math.Round(decimal.Parse(Prod.Rows[0]["costo"].ToString()), cantDec)).ToString();
                lblStock .Text = (Math.Round(decimal.Parse(Prod.Rows[0]["cantidad"].ToString()), cantStock)).ToString();
                lblPProveedor .Text = (Math.Round(decimal.Parse(Prod.Rows[0]["P_Proveedor"].ToString()), cantDec)).ToString();
            }
        }
    }
}
