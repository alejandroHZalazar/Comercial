using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Comercial.Formularios.Estadisticas
{
    public partial class frmVentasEstadisticas : Form
    {
        int cantDec = Clases.ClassProductos.cantDecimales();
        int cantStock = Clases.ClassProductos.cantDecimalesStock();
        int Tipo = 1;

        public frmVentasEstadisticas()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmVentasEstadisticas_Load(object sender, EventArgs e)
        {
            cargarCombos();
            estadoInicial();
        }

        private void cargarCombos()
        {
            Clases.ClassClientes instClie = new Clases.ClassClientes();
            Clases.classUsuarios instUser = new Clases.classUsuarios();
            Clases.ClassProveedores instProv = new Clases.ClassProveedores();

            cboCliente.DataSource = instClie.buscarAVender ();
            cboCliente.ValueMember = "ID";
            cboCliente.DisplayMember = "Completo";

            cboUsuario.DataSource = instUser.traerTodosUsuarios();
            cboUsuario.ValueMember = "id";
            cboUsuario.DisplayMember = "nombre";

            cboProveedor.DataSource = instProv.traeProveedores();
            cboProveedor.ValueMember = "id";
            cboProveedor.DisplayMember = "nombreComercial";


        }

        private void estadoInicial()
        {
            dgvVentas.DataSource = null;
            dgvVentas.Rows.Clear();
            dgvDetalle.DataSource = null;
            dgvDetalle.Rows.Clear();
            nudVenta.Value = 0;
            nudCantidad.Value = 0;
            nudCosto.Value = 0;
            nudComision.Value = 0;
            cboProveedor.SelectedIndex = 0;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            Clases.ClassEstadisticas instEstad = new Clases.ClassEstadisticas();
            string filtro;
            string filtroDev;
            if (cbProveedor.Checked == false)
            {
                Tipo = 1;
                filtro = " where v.fecha between '" + dtpDesde.Value.Year + "-" + dtpDesde.Value.Month + "-" + dtpDesde.Value.Day + "' and '" + dtpHasta.Value.Year + "-" + dtpHasta.Value.Month + "-" + dtpHasta.Value.Day + " 23:59:59'";

                if (cbUsuario.Checked)
                {
                    filtro += " and v.fk_vendedor = " + cboUsuario.SelectedValue.ToString();
                }

                if (cbCliente.Checked)
                {
                    filtro += " and v.fk_cliente = " + cboCliente.SelectedValue.ToString();
                }

                filtroDev = filtro.Replace("v.", "d.");

                dgvVentas.DataSource = instEstad.traeEstadisticasVentas(filtro, filtroDev,1);
                
            }
            else
            {
                Tipo = 2;
                filtro = " where v.fecha between '" + dtpDesde.Value.Year + "-" + dtpDesde.Value.Month + "-" + dtpDesde.Value.Day + "' and '" + dtpHasta.Value.Year + "-" + dtpHasta.Value.Month + "-" + dtpHasta.Value.Day + " 23:59:59'";

                if (cbUsuario.Checked)
                {
                    filtro += " and v.fk_vendedor = " + cboUsuario.SelectedValue.ToString();
                }

                if (cbCliente.Checked)
                {
                    filtro += " and v.fk_cliente = " + cboCliente.SelectedValue.ToString();
                }

                filtro += " and p.fk_proveedor = " + cboProveedor.SelectedValue.ToString();

                filtroDev = filtro;

                dgvVentas.DataSource = instEstad.traeEstadisticasVentas(filtro, filtroDev, 2);
            }

            redondearVentas();
            procesarTotales();
        }

        private void procesarTotales()
        {
            if (dgvVentas.RowCount > 0)
            {
                nudCantidad.Value = dgvVentas.RowCount;
                decimal total = 0;
                decimal costo = 0;
                decimal comision = 0;
                foreach (DataGridViewRow fila in dgvVentas .Rows  )
                {
                    total += decimal.Parse(fila.Cells["totalSIVA"].Value.ToString());
                    costo += decimal.Parse(fila.Cells["Costo"].Value.ToString());
                    comision += decimal.Parse(fila.Cells["Comision"].Value.ToString());
                }

                nudVenta.Value = total;
                nudCosto.Value = costo;
                nudComision.Value = comision;
            }
        }

        private void redondearVentas()
        {
            if (dgvVentas.RowCount > 0)
            {
                dgvVentas.Columns["Desc_Rec"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvVentas.Columns["TotalCIVA"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvVentas.Columns["IVA"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvVentas.Columns["totalSIVA"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvVentas.Columns["Costo"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvVentas.Columns["Comision"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvVentas.Columns["P_Com"].DefaultCellStyle.Format = "N" + cantDec.ToString();
            }
        }

        private void dgvVentas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (Tipo == 1)
            {
                Clases.ClassEstadisticas instEstad = new Clases.ClassEstadisticas();
                dgvDetalle.DataSource = instEstad.traeEstadisticasVentasDetalle(long.Parse(dgvVentas.CurrentRow.Cells["Nro"].Value.ToString()));
                redondearDetalle();
            }
            else
            {
                dgvDetalle.DataSource = null;
                dgvDetalle.Rows.Clear();
            }
        }

        private void redondearDetalle()
        {
            if (dgvDetalle.RowCount > 0)
            {
                dgvDetalle.Columns["Precio_S_IVA"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                dgvDetalle.Columns["Cantidad"].DefaultCellStyle.Format = "N" + cantStock.ToString();
                dgvDetalle.Columns["Subtotal"].DefaultCellStyle.Format = "N" + cantDec.ToString();
                
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            Reportes.frmReport unFrmReport = new Reportes.frmReport();
            unFrmReport.nombreReporte = "ReportVentasEstadisticas.rdlc";
            List<string> var = new List<string>();
            

            string filtro;
            string filtroDev;
            string Subtitulo;
            filtro = " where v.fecha between '" + dtpDesde.Value.Year + "-" + dtpDesde.Value.Month + "-" + dtpDesde.Value.Day + "' and '" + dtpHasta.Value.Year + "-" + dtpHasta.Value.Month + "-" + dtpHasta.Value.Day + " 23:59:59'";
            Subtitulo = "Periodo desde " + dtpDesde.Value.ToShortDateString().Substring(0, 10) + " al " + dtpHasta.Value.ToShortDateString().Substring(0, 10);

            if (cbProveedor.Checked == false)
            {
                Tipo = 1;
                filtro = " where v.fecha between '" + dtpDesde.Value.Year + "-" + dtpDesde.Value.Month + "-" + dtpDesde.Value.Day + "' and '" + dtpHasta.Value.Year + "-" + dtpHasta.Value.Month + "-" + dtpHasta.Value.Day + " 23:59:59'";

                if (cbUsuario.Checked)
                {
                    filtro += " and v.fk_vendedor = " + cboUsuario.SelectedValue.ToString();
                }

                if (cbCliente.Checked)
                {
                    filtro += " and v.fk_cliente = " + cboCliente.SelectedValue.ToString();
                }

                filtroDev = filtro.Replace("v.", "d.");

               
            }
            else
            {
                Tipo = 2;
                filtro = " where v.fecha between '" + dtpDesde.Value.Year + "-" + dtpDesde.Value.Month + "-" + dtpDesde.Value.Day + "' and '" + dtpHasta.Value.Year + "-" + dtpHasta.Value.Month + "-" + dtpHasta.Value.Day + " 23:59:59'";

                if (cbUsuario.Checked)
                {
                    filtro += " and v.fk_vendedor = " + cboUsuario.SelectedValue.ToString();
                }

                if (cbCliente.Checked)
                {
                    filtro += " and v.fk_cliente = " + cboCliente.SelectedValue.ToString();
                }

                filtro += " and p.fk_proveedor = " + cboProveedor.SelectedValue.ToString();

                filtroDev = filtro;

                
            }



            var.Add(filtro);
            var.Add(Subtitulo);
            var.Add(filtroDev);
            var.Add(Tipo.ToString());

            unFrmReport.variable = var;
            unFrmReport.ShowDialog();
        }
    }

} 
