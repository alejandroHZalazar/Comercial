using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comercial.Formularios
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void condicionIvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.Configuracion.frmABMCondIva unFrmCondIva = new Configuracion.frmABMCondIva();
            unFrmCondIva .ShowDialog ();
        }

        private void porcentajeIvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.Configuracion.frmABMivaProcentajes unFrmPorcentajeIVA = new Configuracion.frmABMivaProcentajes();
            unFrmPorcentajeIVA.ShowDialog();
        }

        private void rubrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.Configuracion.frmABMrubros unFrmRubro = new Configuracion.frmABMrubros();
            unFrmRubro.ShowDialog();
        }

        private void tiposDePreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.Configuracion.frmABMTipoPrecios unFrmTipoPrecios = new Configuracion.frmABMTipoPrecios();
            unFrmTipoPrecios.ShowDialog();
        }

        private void tipoUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.Configuracion.frmABMTipoUsuarios unFrmTipoUsuarios = new Configuracion.frmABMTipoUsuarios();
            unFrmTipoUsuarios.ShowDialog();
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.Usuarios.frmABMUsuarios unFrmAbmUsuarios = new Usuarios.frmABMUsuarios();
            unFrmAbmUsuarios.ShowDialog();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            
            this.Text = "Sistema de Gestión Comercial - Usuario: " + Environment.GetEnvironmentVariable("nombreUser");
            Clases.classUsuarios.setPermisosMenu(int.Parse(Environment.GetEnvironmentVariable("idUser")),this,menuStrip1 );
        }

        private void aBMProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.Productos.frmConsultaProductos unFrmProd = new Productos.frmConsultaProductos();
            unFrmProd.ShowDialog();
        }

        private void aBMProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.Proveedores.frmGestionProveedores unFrmGestProv = new Proveedores.frmGestionProveedores();
            unFrmGestProv.ShowDialog();
        }

        private void aBMClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.Clientes.frmABMClientes unFrmABMClientes = new Clientes.frmABMClientes();
            unFrmABMClientes.ShowDialog();
        }

        private void localidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.Configuracion.frmLocalidades unFmLocalidades = new Configuracion.frmLocalidades();
            unFmLocalidades.ShowDialog();
        }

        private void zonasClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.Configuracion.frmABMclientesZonas unFrmZonas = new Configuracion.frmABMclientesZonas();
            unFrmZonas.ShowDialog();
        }

        private void notasDePedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proveedores.frmOrdenDeCompra unFrmOrdenCompra = new Proveedores.frmOrdenDeCompra();
            unFrmOrdenCompra.ShowDialog();
        }

        private void configurarLogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.Configuracion.frmLogo unFrmLogo = new Configuracion.frmLogo();
            unFrmLogo.ShowDialog();
        }

        private void ingresoDeMercaderiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.Productos.frmIngresoMercaderia unFrmIngreso = new Productos.frmIngresoMercaderia();
            unFrmIngreso.ShowDialog();
        }

        private void cargarPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.Ventas.frmPedidos unFrmPedidos = new Ventas.frmPedidos();
            unFrmPedidos.ShowDialog();
        }

        private void venderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ventas.frmVentas unFrmVentas = new Ventas.frmVentas();
            unFrmVentas.ShowDialog();
        }

        private void altaMasivaDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productos.frmAltaMasiva unFrmAltaMasiva = new Productos.frmAltaMasiva();
            unFrmAltaMasiva.ShowDialog();
        }

        private void listaDePreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productos.frmReportesProductos unFrmReporte = new Productos.frmReportesProductos();
            unFrmReporte.ShowDialog();
        }

        private void reportesPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ventas.frmPedidosReport unFrmPedidosReport = new Ventas.frmPedidosReport();
            unFrmPedidosReport.ShowDialog();
        }

        private void reportesVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ventas.frmVentasReportes unFrmReportVentas = new Ventas.frmVentasReportes();
            unFrmReportVentas.ShowDialog();
        }

        private void inventarioDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productos.frmListaStock unFrmListaStock = new Productos.frmListaStock();
            unFrmListaStock.ShowDialog();
        }

        private void lotesIngresosDeMercaderiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productos.frmReporteIngreso unFrmReporteIngreso = new Productos.frmReporteIngreso();
            unFrmReporteIngreso.ShowDialog();
        }

        private void cambioDePreciosMasivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productos.frmCambioDePreciosMasivo unFrmCambioPreciosMasivos = new Productos.frmCambioDePreciosMasivo();
            unFrmCambioPreciosMasivos.ShowDialog();
        }

        private void movimientosDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productos.frmMovimientoProductos unFrmMovimientos = new Productos.frmMovimientoProductos();
            unFrmMovimientos.ShowDialog();
        }

        private void devolucionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ventas.frmDevolucion unFrmDevolucion = new Ventas.frmDevolucion();
            unFrmDevolucion.ShowDialog();
        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Estadisticas.frmVentasEstadisticas unFrmEstadist = new Estadisticas.frmVentasEstadisticas();
            unFrmEstadist.ShowDialog();
        }

        private void rankingDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Estadisticas.frmRankingVentas unfrRankingVentas = new Estadisticas.frmRankingVentas();
            unfrRankingVentas.ShowDialog();
        }

        private void ajustarStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productos.frmAjusteStock unFrmAjusteStock = new Productos.frmAjusteStock();
            unFrmAjusteStock.ShowDialog();
        }

        private void reportesDevolucionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ventas.frmDevolucionReport unFrmDevReport = new Ventas.frmDevolucionReport();
            unFrmDevReport.ShowDialog();
        }

        private void cambioDePreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productos.frmCambioPrecios unFrmCambioPrecios = new Productos.frmCambioPrecios();
            unFrmCambioPrecios.ShowDialog();
        }
    }
}
