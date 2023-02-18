using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Comercial.Formularios.Proveedores
{
    public partial class frmListaProductosAPedir : Form
    {
        public int Proveedor;
        int cantDec = Clases.ClassProductos.cantDecimales();
        int cantStock = Clases.ClassProductos.cantDecimalesStock();

        public DataTable pedido = new DataTable();
        

        public frmListaProductosAPedir()
        {
            InitializeComponent();
        }

        private void frmListaProductosAPedir_Load(object sender, EventArgs e)
        {
            Clases.ClassProveedores instProv = new Clases.ClassProveedores();
            dtpDesde.Value = dtpHasta.Value.AddDays(-90);
            dgvListaProdAPedir.DataSource = instProv.traerListaProdAPedir(Proveedor, dtpDesde .Value ,dtpHasta .Value);
            deshabilitarColumnas();
            redondearDetalle();
            crearColumnasDataTable();
        }

        private void crearColumnasDataTable()
        {
            pedido.Columns.Add("CodBarras");
            pedido.Columns.Add("codProveedor");
            pedido.Columns.Add("descripcion");
            pedido.Columns.Add("cantidad");
            pedido.Columns.Add("cantidadMinima");
            pedido.Columns.Add("P_Proveedor");
            pedido.Columns.Add("Pedido");
            pedido.Columns.Add("producto");

        }

        private void deshabilitarColumnas()
        {
            dgvListaProdAPedir.Columns["Cod_Prov"].ReadOnly = true;
            dgvListaProdAPedir.Columns["Descripcion"].ReadOnly = true;
            dgvListaProdAPedir.Columns["Stock"].ReadOnly = true;
            dgvListaProdAPedir.Columns["C_Min"].ReadOnly = true;
            dgvListaProdAPedir.Columns["Costo"].ReadOnly = true;
            dgvListaProdAPedir.Columns["P_Prov"].ReadOnly = true;
            dgvListaProdAPedir.Columns["P_Lista"].ReadOnly = true;
            dgvListaProdAPedir.Columns["Prod"].Visible = false;
            dgvListaProdAPedir.Columns["codBarras"].Visible = false;
        }

        private void redondearDetalle()
        {
            
           dgvListaProdAPedir.Columns["Stock"].DefaultCellStyle.Format = "N" + cantStock.ToString();
           dgvListaProdAPedir.Columns["C_Min"].DefaultCellStyle.Format = "N" + cantStock.ToString();
           dgvListaProdAPedir.Columns["Costo"].DefaultCellStyle.Format = "N" + cantDec.ToString();
           dgvListaProdAPedir.Columns["P_Prov"].DefaultCellStyle.Format = "N" + cantDec.ToString();
           dgvListaProdAPedir.Columns["P_Lista"].DefaultCellStyle.Format = "N" + cantDec.ToString();
            dgvListaProdAPedir.Columns["Ingreso"].DefaultCellStyle.Format = "N" + cantStock.ToString();
            dgvListaProdAPedir.Columns["Ventas"].DefaultCellStyle.Format = "N" + cantStock.ToString();
        }

        private void dgvListaProdAPedir_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.ClassValidacion.soloNumeros(e);
        }

        private void dgvListaProdAPedir_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            procesoTotales();
        }

        private void procesoTotales()
        {
            
            decimal totCosto = 0;
            decimal totProv = 0;
            decimal totLista = 0;
            int prod = 0;
            foreach (DataGridViewRow fila in dgvListaProdAPedir .Rows )
            {



                fila.Cells["Cant"].Value = (fila.Cells["Cant"].Value is DBNull) ? 0 : fila.Cells["Cant"].Value;
                totCosto += decimal.Parse(fila.Cells["Cant"].Value.ToString()) * decimal.Parse(fila.Cells["Costo"].Value.ToString());
                    totProv += decimal.Parse(fila.Cells["Cant"].Value.ToString()) * decimal.Parse(fila.Cells["P_Prov"].Value.ToString());
                    totLista += decimal.Parse(fila.Cells["Cant"].Value.ToString()) * decimal.Parse(fila.Cells["P_Lista"].Value.ToString());
                    
                if  (decimal.Parse(fila.Cells["Cant"].Value.ToString())>0)
                {
                    prod++;
                }
                   
                
            }

            txtCant.Text = prod.ToString ();
            txtCosto.Text = Math.Round(totCosto, cantDec).ToString("C");
            txtPrecioLista .Text = Math.Round(totLista, cantDec).ToString("C");
            txtPrecioProv .Text = Math.Round(totProv , cantDec).ToString("C");
        }

        private void frmListaProductosAPedir_KeyPress(object sender, KeyPressEventArgs e)
        {
            Clases.ClassValidacion.soloNumeros(e);
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            
            foreach (DataGridViewRow fila in dgvListaProdAPedir .Rows )
            {
                fila.Cells["Cant"].Value = (fila.Cells["Cant"].Value is DBNull) ? 0 : fila.Cells["Cant"].Value;
                if (decimal.Parse (fila.Cells ["Cant"].Value .ToString ()) > 0)
                {
                    DataRow linea = pedido.NewRow();
                    linea["CodBarras"] = fila.Cells["codBarras"].Value.ToString();
                    linea["codProveedor"] = fila.Cells["Cod_Prov"].Value.ToString();
                    linea["descripcion"] = fila.Cells["Descripcion"].Value.ToString();
                    linea["cantidad"] = fila.Cells["Stock"].Value.ToString();
                    linea["cantidadMinima"] = fila.Cells["C_Min"].Value.ToString();
                    linea["P_Proveedor"] = fila.Cells["P_Prov"].Value.ToString();
                    linea["Pedido"] = fila.Cells["Cant"].Value.ToString();
                    linea["producto"] = fila.Cells["Prod"].Value.ToString();
                    pedido.Rows.Add(linea);
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Clases.ClassProveedores instProv = new Clases.ClassProveedores();
            dgvListaProdAPedir.DataSource = null;
            dgvListaProdAPedir.Rows.Clear();
            dgvListaProdAPedir.DataSource = instProv.traerListaProdAPedir(Proveedor, dtpDesde.Value, dtpHasta.Value);
            deshabilitarColumnas();
            redondearDetalle();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Reportes.frmReport unFrmReport = new Reportes.frmReport();
            //unFrmReport.titulo = "Nota de Pedido";
            unFrmReport.nombreReporte = "ReportProductoPedir.rdlc";
            List<string> var = new List<string>();
            var.Add(Proveedor .ToString ());
            var.Add(dtpDesde.Value.ToString ());
            var.Add(dtpHasta.Value.ToString ());
            var.Add("MOVIMIENTOS DE PRODUCTOS DESDE " + dtpDesde .Value .ToShortDateString () + " HASTA " + dtpHasta .Value .ToShortDateString () );
            var.Add(cantDec.ToString());
            var.Add(cantStock.ToString());
            unFrmReport.variable = var;
            unFrmReport.ShowDialog();
        }
    }
}
