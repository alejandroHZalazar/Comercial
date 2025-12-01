using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Comercial.Formularios.Productos
{
    public partial class frmAjusteStock : Form
    {
        string temp;
       
        public frmAjusteStock()
        {
            InitializeComponent();
        }

        private void frmAjusteStock_Load(object sender, EventArgs e)
        {
            Clases.ClassProveedores instProv = new Clases.ClassProveedores();
            Clases.ClassConfiguracion instConfig = new Clases.ClassConfiguracion();


            cboProveedores.DataSource = instProv.traeProveedoresCabecera();
            cboProveedores.ValueMember = "Cod";
            cboProveedores.DisplayMember = "Proveedor";
            cboRubros.DataSource = instConfig.traeRubros();
            cboRubros.ValueMember = "id";
            cboRubros.DisplayMember = "descripcion";

            cboProveedores.SelectedIndex = 0;
            cboRubros.SelectedIndex = 0;
            cboFiltro.SelectedIndex = 0;
        }

        private void btnBuscarCat_Click(object sender, EventArgs e)
        {
            dgvAjuste.DataSource = null;
            dgvAjuste.Rows.Clear();
            string filtro = string.Empty;
            if (cbProveedor .Checked )
            {
                filtro += " p.fk_proveedor = " + cboProveedores.SelectedValue.ToString();
            }

            if (cbRubros .Checked )
            {
                filtro += " p.fk_rubro = " + cboRubros .SelectedValue.ToString();
            }

            if (cbBaja.Checked  )
            {
                filtro += " and p.baja = 0";
            }

            Clases.ClassProductos instProd = new Clases.ClassProductos();
            dgvAjuste.DataSource = instProd.traerParaAjustar(filtro );
            redondearColumnas();
            deshabilitarColumnas();
        }

        private void deshabilitarColumnas()
        {
            dgvAjuste.Columns["id"].Visible = false;
            dgvAjuste.Columns["Cod_Prov"].ReadOnly  = true;
            dgvAjuste.Columns["Cod_Barra"].ReadOnly = true;
            dgvAjuste.Columns["Descripcion"].ReadOnly = true;
            dgvAjuste.Columns["Stock"].ReadOnly = true;
            dgvAjuste.Columns["Dif"].ReadOnly = true;
        }

        private void redondearColumnas()
        {
            int cantDec = Clases.ClassProductos.cantDecimales();
            int cantStock = Clases.ClassProductos.cantDecimalesStock();
            dgvAjuste.Columns["Stock"].DefaultCellStyle.Format = "N" + cantStock.ToString();
            dgvAjuste.Columns["Ajuste"].DefaultCellStyle.Format = "N" + cantStock.ToString();
            dgvAjuste.Columns["Dif"].DefaultCellStyle.Format = "N" + cantStock.ToString();
           
        }

        private void dgvAjuste_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.ClassValidacion.soloNumeros(e);
        }

        private void dgvAjuste_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvAjuste.CurrentCell.ColumnIndex == 5)

            {

                TextBox txt = e.Control as TextBox;

                if (txt != null)

                {

                    txt.KeyPress -= new KeyPressEventHandler(dgvAjuste_KeyPress );

                    txt.KeyPress += new KeyPressEventHandler(dgvAjuste_KeyPress );

                }

            }
        }

        private void dgvAjuste_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            temp = dgvAjuste.CurrentCell.Value.ToString();
        }

        private void dgvAjuste_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string cellVaue = dgvAjuste.CurrentCell.Value.ToString();
            if (cellVaue == temp)
            {
                
            }
            else
            {
                if (cellVaue == string .Empty )
                {
                    dgvAjuste.CurrentCell.Value = temp;
                }
                else
                {
                    dgvAjuste.CurrentRow.Cells[6].Value = decimal.Parse(dgvAjuste.CurrentRow.Cells[5].Value.ToString()) - decimal.Parse(dgvAjuste.CurrentRow.Cells[4].Value.ToString());
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtFiltro.Text != string.Empty)
            {
                dgvAjuste.DataSource = null;
                dgvAjuste.Rows.Clear();
                string filtro = string.Empty;

                if (cboFiltro.Text == "Cod. Proveedor")
                {
                    filtro += " p.codProveedor = " + txtFiltro.Text.Trim();
                }
                if (cboFiltro.Text == "Cod.Barras")
                {
                    filtro += " p.codBarras = " + txtFiltro.Text.Trim();
                }
                if (cboFiltro.Text == "Descripcion")
                {
                    filtro += " p.descripcion like '%" + txtFiltro.Text.Trim() + "%'";
                }

                if (cbBaja.Checked)
                {
                    filtro += " and p.baja = 0";
                }

                if (filtro != string.Empty)
                {
                    Clases.ClassProductos instProd = new Clases.ClassProductos();
                    dgvAjuste.DataSource = instProd.traerParaAjustar(filtro);
                    redondearColumnas();
                    deshabilitarColumnas();
                }
            }
            else
            {
                errorProvider1.SetError(txtFiltro, "el campo de texto esta vacío");
                return;
            }
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter )
            {
                btnBuscar_Click(null, null);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Clases.ClassProductos instProd = new Clases.ClassProductos();
            int cont = 0;
            foreach (DataGridViewRow fila in dgvAjuste .Rows )
            {
                if (fila.Cells ["Dif"].Value .ToString () != "0")
                {
                    instProd.ajustarStock(int.Parse(fila.Cells["id"].Value.ToString()), decimal.Parse(fila.Cells["Ajuste"].Value.ToString()), decimal.Parse(fila.Cells["Dif"].Value.ToString()));
                    cont++;
                }
            }

            MessageBox.Show(this, cont + " productos ajustaron su stock", "AJUSTE DE STOCK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvAjuste.DataSource = null;
            dgvAjuste.Rows.Clear();
        }

        private void dgvAjuste_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                Clases.ClassProductos instProductos = new Clases.ClassProductos();
                bool baja = bool.Parse(dgvAjuste.Rows[e.RowIndex].Cells[7].Value.ToString());
                instProductos.actualizarEstadoProducto(dgvAjuste.Rows[e.RowIndex].Cells["id"].Value.ToString(), baja);
            }
        }

        private void dgvAjuste_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvAjuste.IsCurrentCellDirty)
            {
                dgvAjuste.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
