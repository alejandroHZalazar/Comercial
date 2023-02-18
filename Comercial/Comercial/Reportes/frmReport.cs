using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Comercial.Reportes
{
    public partial class frmReport : Form
    {
        
        public string nombreReporte;
        dsComercial unDs = new dsComercial();
        dsComercial1 unDs1 = new dsComercial1();
        BindingSource bindingSourceReporte = new BindingSource();
        BindingSource bindingSourceReporte1 = new BindingSource();


        public List<string> variable;

        public frmReport()
        {
            InitializeComponent();
        }


        private void frmReport_Load(object sender, EventArgs e)
        {
           
            bindingSourceReporte.DataSource = unDs ;
            bindingSourceReporte1.DataSource = unDs1;
            switch (nombreReporte)
            {
                case "ReportOrdenCompra.rdlc":
                    ReportOrdenCompra();
                    break;
                case "ReportVenta.rdlc":
                    ReportVenta();
                    break;
                case "ReportListaDePreciosPorRubro.rdlc":
                    ReportListaDePreciosPorRubro();
                    break;
                case "ReportPedidos.rdlc":
                    ReportPedidosTodos();
                    break;
                case "ReportProductosStock.rdlc":
                    ReportProductosStock();
                    break;
                case "ReportVentasEstadisticas.rdlc":
                    ReportVentasEstadisticas();
                    break;
                case "ReportDevolucion.rdlc":
                    ReportDevolucion();
                    break;
                case "ReportProductoPedir.rdlc":
                    ReportProductosPedir();
                    break;
                default:

                    MessageBox.Show("NO EXISTE REPORTE");
                    this.Close();
                    break;


            }


        }

        private void ReportProductosPedir()
        {
            unDs.EnforceConstraints = false;
            dsComercialTableAdapters.sp_ProveedoresListarProductosAPedirTableAdapter unTablaAdapter = new dsComercialTableAdapters.sp_ProveedoresListarProductosAPedirTableAdapter();
            unTablaAdapter.Fill(unDs.sp_ProveedoresListarProductosAPedir,int.Parse (variable[0]),DateTime .Parse (variable[1]),DateTime .Parse (variable [2]));


            //ASIGNAMOS LOS PARAMETROS
            ReportParameter[] parameters = new ReportParameter[3];
            parameters[0] = new ReportParameter("subtitulo", variable[3]);
            parameters[1] = new ReportParameter("cantDec", variable[4]);
            parameters[2] = new ReportParameter("cantStock", variable[5]);

            //seteamos los margenes
            PageSettings pg = new PageSettings();
            pg.Margins.Left = 40;
            pg.Margins.Right = 0;
            pg.Margins.Top = 40;
            pg.Margins.Bottom = 40;


            this.unReport.SetPageSettings(pg);

            //ASIGNAMOS EL ORIGEN DE DATOS DEL REPORTE

            ReportDataSource rds = new ReportDataSource();
            unReport.LocalReport.DataSources.Clear();
            bindingSourceReporte.DataMember = "sp_ProveedoresListarProductosAPedir";
            rds.Name = "dsProductosPedir";
            rds.Value = bindingSourceReporte;

            unReport.LocalReport.DataSources.Add(rds);
            unReport.LocalReport.ReportEmbeddedResource = @"Comercial.Reportes" + "." + nombreReporte;


            unReport.LocalReport.SetParameters(parameters);

            unReport.RefreshReport();
        }

        private void ReportDevolucion()
        {
            unDs.EnforceConstraints = false;
            dsComercial1TableAdapters.sp_DevolucionPrintTableAdapter  unTablaAdapter = new dsComercial1TableAdapters.sp_DevolucionPrintTableAdapter ();
            unTablaAdapter.Fill(unDs1.sp_DevolucionPrint ,long.Parse(variable[0]));


            //ASIGNAMOS LOS PARAMETROS
            ReportParameter[] parameters = new ReportParameter[9];
            parameters[0] = new ReportParameter("Empresa", variable[1]);
            parameters[1] = new ReportParameter("telefono", variable[2]);
            parameters[2] = new ReportParameter("direccion", variable[3]);
            parameters[3] = new ReportParameter("ciudad", variable[4]);
            parameters[4] = new ReportParameter("cuit", variable[5]);
            parameters[5] = new ReportParameter("iva", variable[6]);
            parameters[6] = new ReportParameter("cantDec", variable[7]);
            parameters[7] = new ReportParameter("cantStock", variable[8]);
            parameters[8] = new ReportParameter("razonSocial", variable[9]);

            //seteamos los margenes
            PageSettings pg = new PageSettings();
            pg.Margins.Left = 40;
            pg.Margins.Right = 0;
            pg.Margins.Top = 40;
            pg.Margins.Bottom = 40;


            this.unReport.SetPageSettings(pg);

            //ASIGNAMOS EL ORIGEN DE DATOS DEL REPORTE

            ReportDataSource rds = new ReportDataSource();
            unReport.LocalReport.DataSources.Clear();
            bindingSourceReporte1 .DataMember = "sp_DevolucionPrint";
            rds.Name = "dsDevolucion";
            rds.Value = bindingSourceReporte1 ;

            unReport.LocalReport.DataSources.Add(rds);
            unReport.LocalReport.ReportEmbeddedResource = @"Comercial.Reportes" + "." + nombreReporte;


            unReport.LocalReport.SetParameters(parameters);

            unReport.RefreshReport();
        }

        private void ReportVentasEstadisticas()
        {
            unDs1 .EnforceConstraints = false;
            dsComercial1TableAdapters .sp_VentasBuscarEntreFechayFiltroTableAdapter  unTablaAdapter = new dsComercial1TableAdapters .sp_VentasBuscarEntreFechayFiltroTableAdapter();
            unTablaAdapter.Fill(unDs1.sp_VentasBuscarEntreFechayFiltro, variable[0],variable [2],int.Parse (variable [3]));


            //ASIGNAMOS LOS PARAMETROS
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("subtitulo", variable[1]);
            

            //seteamos los margenes
            PageSettings pg = new PageSettings();
            pg.Margins.Left = 40;
            pg.Margins.Right = 0;
            pg.Margins.Top = 40;
            pg.Margins.Bottom = 40;


            this.unReport.SetPageSettings(pg);

            //ASIGNAMOS EL ORIGEN DE DATOS DEL REPORTE

           ReportDataSource rds = new ReportDataSource();
            unReport.LocalReport.DataSources.Clear();
            bindingSourceReporte1 .DataMember = "sp_VentasBuscarEntreFechayFiltro";
            rds.Name = "dsVentasEst";
            rds.Value = bindingSourceReporte1 ;

            unReport.LocalReport.DataSources.Add(rds);
            unReport.LocalReport.ReportEmbeddedResource = @"Comercial.Reportes" + "." + nombreReporte;


            unReport.LocalReport.SetParameters(parameters);

            unReport.RefreshReport();
        }

        private void ReportProductosStock()
        {
            unDs.EnforceConstraints = false;
            dsComercial1TableAdapters.sp_ProductosTraerStockTableAdapter unTablaAdapter = new dsComercial1TableAdapters.sp_ProductosTraerStockTableAdapter();
            unTablaAdapter.Fill(unDs1.sp_ProductosTraerStock, variable[0]);


            //ASIGNAMOS LOS PARAMETROS
            ReportParameter[] parameters = new ReportParameter[3];
            parameters[0] = new ReportParameter("empresa", variable[1]);
            parameters[1] = new ReportParameter("cantDec", variable[2]);
            parameters[2] = new ReportParameter("cantStock", variable[3]);

            //seteamos los margenes
            PageSettings pg = new PageSettings();
            pg.Margins.Left = 40;
            pg.Margins.Right = 0;
            pg.Margins.Top = 40;
            pg.Margins.Bottom = 40;


            this.unReport.SetPageSettings(pg);

            //ASIGNAMOS EL ORIGEN DE DATOS DEL REPORTE

            ReportDataSource rds = new ReportDataSource();
            unReport.LocalReport.DataSources.Clear();
            bindingSourceReporte1.DataMember = "sp_ProductosTraerStock";
            rds.Name = "DataSetProductosStock";
            rds.Value = bindingSourceReporte1;

            unReport.LocalReport.DataSources.Add(rds);
            unReport.LocalReport.ReportEmbeddedResource = @"Comercial.Reportes" + "." + nombreReporte;


            unReport.LocalReport.SetParameters(parameters);

            unReport.RefreshReport();
        }

        private void ReportPedidosTodos()
        {
            unDs1 .EnforceConstraints = false;
            dsComercial1TableAdapters .sp_PedidosPrintPedidoTableAdapter  unTablaAdapter = new dsComercial1TableAdapters.sp_PedidosPrintPedidoTableAdapter();
            unTablaAdapter.Fill(unDs1.sp_PedidosPrintPedido, int.Parse(variable[0]));


            //ASIGNAMOS LOS PARAMETROS
            ReportParameter[] parameters = new ReportParameter[9];
            parameters[0] = new ReportParameter("empresa", variable[1]);
            parameters[1] = new ReportParameter("telefono", variable[2]);
            parameters[2] = new ReportParameter("direccion", variable[3]);
            parameters[3] = new ReportParameter("ciudad", variable[4]);
            parameters[4] = new ReportParameter("cliente", variable[5]);
            parameters[5] = new ReportParameter("cantDec", variable[6]);
            parameters[6] = new ReportParameter("cantStock", variable[7]);
            parameters[7] = new ReportParameter("dirCliente", variable[8]);
            parameters[8] = new ReportParameter("telCliente", variable[9]);

            //seteamos los margenes
            PageSettings pg = new PageSettings();
            pg.Margins.Left = 40;
            pg.Margins.Right = 0;
            pg.Margins.Top = 40;
            pg.Margins.Bottom = 40;


            this.unReport.SetPageSettings(pg);

            //ASIGNAMOS EL ORIGEN DE DATOS DEL REPORTE

            ReportDataSource rds = new ReportDataSource();
            unReport.LocalReport.DataSources.Clear();
            bindingSourceReporte1 .DataMember = "sp_PedidosPrintPedido";
            rds.Name = "dsPedido";
            rds.Value = bindingSourceReporte1;

            unReport.LocalReport.DataSources.Add(rds);
            unReport.LocalReport.ReportEmbeddedResource = @"Comercial.Reportes" + "." + nombreReporte;


            unReport.LocalReport.SetParameters(parameters);

            unReport.RefreshReport();
        }

        private void ReportListaDePreciosPorRubro()
        {
            unDs.EnforceConstraints = false;
            dsComercialTableAdapters.sp_ProductosListaPreciosTableAdapter   unTablaAdapter = new dsComercialTableAdapters.sp_ProductosListaPreciosTableAdapter ();
            unTablaAdapter.Fill(unDs.sp_ProductosListaPrecios, variable[0]);


            //ASIGNAMOS LOS PARAMETROS
            ReportParameter[] parameters = new ReportParameter[6];
            parameters[0] = new ReportParameter("empresa", variable[1]);
            parameters[1] = new ReportParameter("telefono", variable[2]);
            parameters[2] = new ReportParameter("direccion", variable[3]);
            parameters[3] = new ReportParameter("ciudad", variable[4]);
            parameters[4] = new ReportParameter("fecha", DateTime .Now .ToShortDateString ());
            parameters[5] = new ReportParameter("cantDec", variable [5]);

            //seteamos los margenes
            PageSettings pg = new PageSettings();
            pg.Margins.Left = 40;
            pg.Margins.Right = 0;
            pg.Margins.Top = 40;
            pg.Margins.Bottom = 40;


            this.unReport.SetPageSettings(pg);

            //ASIGNAMOS EL ORIGEN DE DATOS DEL REPORTE

            ReportDataSource rds = new ReportDataSource();
            unReport.LocalReport.DataSources.Clear();
            bindingSourceReporte.DataMember = "sp_ProductosListaPrecios";
            rds.Name = "DataSetListaPrecios";
            rds.Value = bindingSourceReporte;

            unReport.LocalReport.DataSources.Add(rds);
            unReport.LocalReport.ReportEmbeddedResource = @"Comercial.Reportes" + "." + nombreReporte;


            unReport.LocalReport.SetParameters(parameters);

            unReport.RefreshReport();
        }

        private void ReportVenta()
        {
            unDs1 .EnforceConstraints = false;
            dsComercial1TableAdapters.sp_VentasPrintTableAdapter  unTablaAdapter = new dsComercial1TableAdapters.sp_VentasPrintTableAdapter ();
            unTablaAdapter.Fill(unDs1.sp_VentasPrint , long.Parse(variable[0]));


            //ASIGNAMOS LOS PARAMETROS
            ReportParameter[] parameters = new ReportParameter[9];
            parameters[0] = new ReportParameter("Empresa", variable[1]);
            parameters[1] = new ReportParameter("telefono", variable[2]);
            parameters[2] = new ReportParameter("direccion", variable[3]);
            parameters[3] = new ReportParameter("ciudad", variable[4]);
            parameters[4] = new ReportParameter("cuit", variable[5]);
            parameters[5] = new ReportParameter("iva", variable[6]);
            parameters[6] = new ReportParameter("cantDec", variable[7]);
            parameters[7] = new ReportParameter("cantStock", variable[8]);
            parameters[8] = new ReportParameter("razonSocial", variable[9]);

            //seteamos los margenes
            PageSettings pg = new PageSettings();
            pg.Margins.Left = 40;
            pg.Margins.Right = 0;
            pg.Margins.Top = 40;
            pg.Margins.Bottom = 40;


            this.unReport.SetPageSettings(pg);

            //ASIGNAMOS EL ORIGEN DE DATOS DEL REPORTE

            ReportDataSource rds = new ReportDataSource();
            unReport.LocalReport.DataSources.Clear();
            bindingSourceReporte1 .DataMember = "sp_VentasPrint";
            rds.Name = "DataSetVenta";
            rds.Value = bindingSourceReporte1 ;

            unReport.LocalReport.DataSources.Add(rds);
            unReport.LocalReport.ReportEmbeddedResource = @"Comercial.Reportes" + "." + nombreReporte;


            unReport.LocalReport.SetParameters(parameters);

            unReport.RefreshReport();
        }

        private void ReportOrdenCompra()
        {
            unDs .EnforceConstraints = false;
            dsComercialTableAdapters.ordenCompraPrintTableAdapter  unTablaAdapter = new dsComercialTableAdapters.ordenCompraPrintTableAdapter ();
            unTablaAdapter.Fill(unDs.ordenCompraPrint ,long.Parse  (variable [0]));


            //ASIGNAMOS LOS PARAMETROS
            ReportParameter[] parameters = new ReportParameter[3];
            parameters[0] = new ReportParameter("empresa", variable [1]);
            parameters[1] = new ReportParameter("cantDec", variable[2]);
            parameters[2] = new ReportParameter("cantStock", variable[3]);


            //seteamos los margenes
            PageSettings pg = new PageSettings();
            pg.Margins.Left = 40;
            pg.Margins.Right = 0;
            pg.Margins.Top = 40;
            pg.Margins.Bottom = 40;


            this.unReport .SetPageSettings(pg);

            //ASIGNAMOS EL ORIGEN DE DATOS DEL REPORTE

            ReportDataSource rds = new ReportDataSource();
            unReport.LocalReport.DataSources.Clear();
            bindingSourceReporte.DataMember = "ordenCompraPrint";
            rds.Name = "DataSetOrdenCompra";
            rds.Value = bindingSourceReporte;

            unReport.LocalReport.DataSources.Add(rds);
            unReport.LocalReport.ReportEmbeddedResource = @"Comercial.Reportes" + "." + nombreReporte;


            unReport.LocalReport.SetParameters(parameters);

            unReport.RefreshReport();

        }
    }
}
