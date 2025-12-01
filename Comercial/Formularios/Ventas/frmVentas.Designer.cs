namespace Comercial.Formularios.Ventas
{
    partial class frmVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVentas));
            this.btnGrabar = new System.Windows.Forms.Button();
            this.nudRecargo = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboIVA = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbDesc = new System.Windows.Forms.ListBox();
            this.nudDescuento = new System.Windows.Forms.NumericUpDown();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.Cod_Barras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cod_Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioSinIva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioConIva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioOrig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.cboFiltro = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.ListBox();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.btnCambioPrecio = new System.Windows.Forms.Button();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.btnPedido = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSubSinIVA = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.btnAltaCliente = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCondIVA = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblEncargado = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblDir = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblClienteNombre = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTotGeneral = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.cboVendedores = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtTotalSinIva = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudComision = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.cboIngBrutos = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtIVA = new System.Windows.Forms.TextBox();
            this.txtIB = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecargo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.gbFiltro.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudComision)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.Color.Silver;
            this.btnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGrabar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.Image = global::Comercial.Properties.Resources.save__1_;
            this.btnGrabar.Location = new System.Drawing.Point(981, 658);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(116, 34);
            this.btnGrabar.TabIndex = 10;
            this.btnGrabar.Text = "  Grabar [F5]";
            this.btnGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // nudRecargo
            // 
            this.nudRecargo.DecimalPlaces = 2;
            this.nudRecargo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudRecargo.Location = new System.Drawing.Point(237, 592);
            this.nudRecargo.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudRecargo.Name = "nudRecargo";
            this.nudRecargo.Size = new System.Drawing.Size(83, 23);
            this.nudRecargo.TabIndex = 7;
            this.nudRecargo.ValueChanged += new System.EventHandler(this.nudRecargo_ValueChanged);
            this.nudRecargo.Enter += new System.EventHandler(this.nudRecargo_Enter);
            this.nudRecargo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudRecargo_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(177, 596);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 15);
            this.label6.TabIndex = 44;
            this.label6.Text = "Recargo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 596);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 43;
            this.label5.Text = "Descuento";
            // 
            // cboIVA
            // 
            this.cboIVA.FormattingEnabled = true;
            this.cboIVA.Location = new System.Drawing.Point(199, 46);
            this.cboIVA.Name = "cboIVA";
            this.cboIVA.Size = new System.Drawing.Size(68, 23);
            this.cboIVA.TabIndex = 3;
            this.cboIVA.SelectedIndexChanged += new System.EventHandler(this.cboIVA_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(163, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 17);
            this.label4.TabIndex = 42;
            this.label4.Text = "IVA";
            // 
            // lbDesc
            // 
            this.lbDesc.FormattingEnabled = true;
            this.lbDesc.ItemHeight = 15;
            this.lbDesc.Location = new System.Drawing.Point(154, 192);
            this.lbDesc.Name = "lbDesc";
            this.lbDesc.Size = new System.Drawing.Size(472, 169);
            this.lbDesc.TabIndex = 41;
            this.lbDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbDesc_KeyDown);
            this.lbDesc.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbDesc_MouseDoubleClick);
            // 
            // nudDescuento
            // 
            this.nudDescuento.DecimalPlaces = 2;
            this.nudDescuento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDescuento.Location = new System.Drawing.Point(87, 592);
            this.nudDescuento.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudDescuento.Name = "nudDescuento";
            this.nudDescuento.Size = new System.Drawing.Size(83, 23);
            this.nudDescuento.TabIndex = 6;
            this.nudDescuento.ValueChanged += new System.EventHandler(this.nudDescuento_ValueChanged);
            this.nudDescuento.Enter += new System.EventHandler(this.nudDescuento_Enter);
            this.nudDescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudDescuento_KeyPress);
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cod_Barras,
            this.Cod_Proveedor,
            this.Descripcion,
            this.Stock,
            this.precioSinIva,
            this.precioConIva,
            this.Cantidad,
            this.Subtotal,
            this.PrecioOrig,
            this.id,
            this.pedido,
            this.costo});
            this.dgvProductos.Location = new System.Drawing.Point(13, 203);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.Size = new System.Drawing.Size(1095, 384);
            this.dgvProductos.TabIndex = 5;
            this.dgvProductos.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvProductos_CellParsing);
            this.dgvProductos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellValueChanged);
            this.dgvProductos.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvProductos_RowsRemoved);
            // 
            // Cod_Barras
            // 
            this.Cod_Barras.HeaderText = "Cod_Barras";
            this.Cod_Barras.Name = "Cod_Barras";
            this.Cod_Barras.ReadOnly = true;
            // 
            // Cod_Proveedor
            // 
            this.Cod_Proveedor.HeaderText = "C_Prov";
            this.Cod_Proveedor.Name = "Cod_Proveedor";
            this.Cod_Proveedor.ReadOnly = true;
            this.Cod_Proveedor.Width = 50;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 565;
            // 
            // Stock
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Stock.DefaultCellStyle = dataGridViewCellStyle1;
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            this.Stock.Width = 50;
            // 
            // precioSinIva
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.precioSinIva.DefaultCellStyle = dataGridViewCellStyle2;
            this.precioSinIva.HeaderText = "Precio S/IVA";
            this.precioSinIva.Name = "precioSinIva";
            this.precioSinIva.Width = 70;
            // 
            // precioConIva
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.precioConIva.DefaultCellStyle = dataGridViewCellStyle3;
            this.precioConIva.HeaderText = "Precio C/IVA";
            this.precioConIva.Name = "precioConIva";
            this.precioConIva.Width = 70;
            // 
            // Cantidad
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle4;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Width = 70;
            // 
            // Subtotal
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Subtotal.DefaultCellStyle = dataGridViewCellStyle5;
            this.Subtotal.HeaderText = "Subtotal";
            this.Subtotal.Name = "Subtotal";
            this.Subtotal.Width = 70;
            // 
            // PrecioOrig
            // 
            this.PrecioOrig.HeaderText = "precioOrig";
            this.PrecioOrig.Name = "PrecioOrig";
            this.PrecioOrig.Visible = false;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // pedido
            // 
            this.pedido.HeaderText = "pedido";
            this.pedido.Name = "pedido";
            this.pedido.Visible = false;
            // 
            // costo
            // 
            this.costo.HeaderText = "costo";
            this.costo.Name = "costo";
            this.costo.Visible = false;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(439, 24);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(122, 15);
            this.lblDescripcion.TabIndex = 11;
            this.lblDescripcion.Text = "Búsq. Por Descripción";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Silver;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Image = global::Comercial.Properties.Resources.play_button;
            this.btnAgregar.Location = new System.Drawing.Point(1030, 52);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(49, 23);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // nudCantidad
            // 
            this.nudCantidad.DecimalPlaces = 4;
            this.nudCantidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCantidad.Location = new System.Drawing.Point(894, 52);
            this.nudCantidad.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(120, 23);
            this.nudCantidad.TabIndex = 3;
            this.nudCantidad.Enter += new System.EventHandler(this.nudCantidad_Enter);
            this.nudCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudCantidad_KeyDown);
            this.nudCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudCantidad_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Búsq. Por Descripción";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(141, 52);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(472, 23);
            this.txtDesc.TabIndex = 2;
            this.txtDesc.TextChanged += new System.EventHandler(this.txtDesc_TextChanged);
            this.txtDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDesc_KeyDown);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(230, 20);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(181, 23);
            this.txtFiltro.TabIndex = 1;
            this.txtFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFiltro_KeyDown);
            this.txtFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFiltro_KeyPress);
            // 
            // cboFiltro
            // 
            this.cboFiltro.FormattingEnabled = true;
            this.cboFiltro.Items.AddRange(new object[] {
            "Cod. Proveedor",
            "Cod. Barras",
            "Cod. Interno"});
            this.cboFiltro.Location = new System.Drawing.Point(53, 20);
            this.cboFiltro.Name = "cboFiltro";
            this.cboFiltro.Size = new System.Drawing.Size(171, 23);
            this.cboFiltro.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Filtro:";
            // 
            // lblCliente
            // 
            this.lblCliente.FormattingEnabled = true;
            this.lblCliente.ItemHeight = 15;
            this.lblCliente.Location = new System.Drawing.Point(67, 35);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(436, 169);
            this.lblCliente.TabIndex = 39;
            this.lblCliente.SelectedIndexChanged += new System.EventHandler(this.lblCliente_SelectedIndexChanged);
            this.lblCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lblCliente_KeyDown);
            this.lblCliente.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lblCliente_MouseDoubleClick);
            // 
            // gbFiltro
            // 
            this.gbFiltro.BackColor = System.Drawing.Color.Silver;
            this.gbFiltro.Controls.Add(this.btnCambioPrecio);
            this.gbFiltro.Controls.Add(this.lblDescripcion);
            this.gbFiltro.Controls.Add(this.btnAgregar);
            this.gbFiltro.Controls.Add(this.nudCantidad);
            this.gbFiltro.Controls.Add(this.label3);
            this.gbFiltro.Controls.Add(this.txtDesc);
            this.gbFiltro.Controls.Add(this.txtFiltro);
            this.gbFiltro.Controls.Add(this.cboFiltro);
            this.gbFiltro.Controls.Add(this.label2);
            this.gbFiltro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFiltro.Location = new System.Drawing.Point(13, 115);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(1091, 84);
            this.gbFiltro.TabIndex = 4;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Busqueda por Producto";
            // 
            // btnCambioPrecio
            // 
            this.btnCambioPrecio.BackColor = System.Drawing.Color.Silver;
            this.btnCambioPrecio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambioPrecio.Image = global::Comercial.Properties.Resources.peso;
            this.btnCambioPrecio.Location = new System.Drawing.Point(729, 13);
            this.btnCambioPrecio.Name = "btnCambioPrecio";
            this.btnCambioPrecio.Size = new System.Drawing.Size(151, 35);
            this.btnCambioPrecio.TabIndex = 60;
            this.btnCambioPrecio.Text = "Precios Actualizados";
            this.btnCambioPrecio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCambioPrecio.UseVisualStyleBackColor = false;
            this.btnCambioPrecio.Click += new System.EventHandler(this.btnCambioPrecio_Click);
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(67, 11);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(330, 23);
            this.txtCliente.TabIndex = 0;
            this.txtCliente.TextChanged += new System.EventHandler(this.txtCliente_TextChanged);
            this.txtCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCliente_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 37;
            this.label1.Text = "Cliente";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 17);
            this.label8.TabIndex = 46;
            this.label8.Text = "Tipo";
            // 
            // cboTipo
            // 
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "Nota de Venta",
            "Facturacion"});
            this.cboTipo.Location = new System.Drawing.Point(53, 46);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(103, 23);
            this.cboTipo.TabIndex = 2;
            // 
            // btnPedido
            // 
            this.btnPedido.BackColor = System.Drawing.Color.Silver;
            this.btnPedido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPedido.Image = global::Comercial.Properties.Resources.man_user__1_1;
            this.btnPedido.Location = new System.Drawing.Point(10, 75);
            this.btnPedido.Name = "btnPedido";
            this.btnPedido.Size = new System.Drawing.Size(151, 35);
            this.btnPedido.TabIndex = 1;
            this.btnPedido.Text = "Cargar Pedido";
            this.btnPedido.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPedido.UseVisualStyleBackColor = false;
            this.btnPedido.Click += new System.EventHandler(this.btnPedido_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(120, 630);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 15);
            this.label9.TabIndex = 48;
            this.label9.Text = "Subt. S/ IVA";
            // 
            // txtSubSinIVA
            // 
            this.txtSubSinIVA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubSinIVA.Location = new System.Drawing.Point(199, 626);
            this.txtSubSinIVA.Name = "txtSubSinIVA";
            this.txtSubSinIVA.ReadOnly = true;
            this.txtSubSinIVA.Size = new System.Drawing.Size(84, 23);
            this.txtSubSinIVA.TabIndex = 49;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(289, 630);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 15);
            this.label10.TabIndex = 50;
            this.label10.Text = "Total Descuento";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuento.Location = new System.Drawing.Point(392, 626);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.ReadOnly = true;
            this.txtDescuento.Size = new System.Drawing.Size(72, 23);
            this.txtDescuento.TabIndex = 51;
            // 
            // btnAltaCliente
            // 
            this.btnAltaCliente.BackColor = System.Drawing.Color.Silver;
            this.btnAltaCliente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAltaCliente.Image = global::Comercial.Properties.Resources.plus;
            this.btnAltaCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAltaCliente.Location = new System.Drawing.Point(199, 75);
            this.btnAltaCliente.Name = "btnAltaCliente";
            this.btnAltaCliente.Size = new System.Drawing.Size(151, 35);
            this.btnAltaCliente.TabIndex = 52;
            this.btnAltaCliente.Text = "    Nuevo Cliente";
            this.btnAltaCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAltaCliente.UseVisualStyleBackColor = false;
            this.btnAltaCliente.Click += new System.EventHandler(this.btnAltaCliente_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.lblCondIVA);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.lblEncargado);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lblDir);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblTel);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.lblClienteNombre);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(403, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(701, 99);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Clientes";
            // 
            // lblCondIVA
            // 
            this.lblCondIVA.AutoSize = true;
            this.lblCondIVA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCondIVA.Location = new System.Drawing.Point(77, 80);
            this.lblCondIVA.Name = "lblCondIVA";
            this.lblCondIVA.Size = new System.Drawing.Size(122, 15);
            this.lblCondIVA.TabIndex = 63;
            this.lblCondIVA.Text = "Búsq. Por Descripción";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(6, 79);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(65, 17);
            this.label21.TabIndex = 62;
            this.label21.Text = "CondIVA:";
            // 
            // lblEncargado
            // 
            this.lblEncargado.AutoSize = true;
            this.lblEncargado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncargado.Location = new System.Drawing.Point(484, 80);
            this.lblEncargado.Name = "lblEncargado";
            this.lblEncargado.Size = new System.Drawing.Size(122, 15);
            this.lblEncargado.TabIndex = 61;
            this.lblEncargado.Text = "Búsq. Por Descripción";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(415, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 17);
            this.label11.TabIndex = 60;
            this.label11.Text = "Contacto:";
            // 
            // lblDir
            // 
            this.lblDir.AutoSize = true;
            this.lblDir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDir.Location = new System.Drawing.Point(82, 50);
            this.lblDir.Name = "lblDir";
            this.lblDir.Size = new System.Drawing.Size(122, 15);
            this.lblDir.TabIndex = 59;
            this.lblDir.Text = "Búsq. Por Descripción";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 17);
            this.label12.TabIndex = 58;
            this.label12.Text = "Dirección:";
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTel.Location = new System.Drawing.Point(446, 19);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(122, 15);
            this.lblTel.TabIndex = 57;
            this.lblTel.Text = "Búsq. Por Descripción";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(415, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 17);
            this.label13.TabIndex = 56;
            this.label13.Text = "Tel:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 17);
            this.label14.TabIndex = 55;
            this.label14.Text = "Cliente:";
            // 
            // lblClienteNombre
            // 
            this.lblClienteNombre.AutoSize = true;
            this.lblClienteNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClienteNombre.Location = new System.Drawing.Point(82, 20);
            this.lblClienteNombre.Name = "lblClienteNombre";
            this.lblClienteNombre.Size = new System.Drawing.Size(122, 15);
            this.lblClienteNombre.TabIndex = 16;
            this.lblClienteNombre.Text = "Búsq. Por Descripción";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(724, 668);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(132, 15);
            this.label15.TabIndex = 57;
            this.label15.Text = "TOTAL GENERAL C/IVA";
            // 
            // txtTotGeneral
            // 
            this.txtTotGeneral.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotGeneral.Location = new System.Drawing.Point(858, 661);
            this.txtTotGeneral.Name = "txtTotGeneral";
            this.txtTotGeneral.ReadOnly = true;
            this.txtTotGeneral.Size = new System.Drawing.Size(113, 29);
            this.txtTotGeneral.TabIndex = 58;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Silver;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Image = global::Comercial.Properties.Resources.escoba;
            this.btnLimpiar.Location = new System.Drawing.Point(16, 620);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(98, 35);
            this.btnLimpiar.TabIndex = 11;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // cboVendedores
            // 
            this.cboVendedores.FormattingEnabled = true;
            this.cboVendedores.Location = new System.Drawing.Point(401, 592);
            this.cboVendedores.Name = "cboVendedores";
            this.cboVendedores.Size = new System.Drawing.Size(150, 23);
            this.cboVendedores.TabIndex = 8;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(327, 595);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 17);
            this.label16.TabIndex = 61;
            this.label16.Text = "Vendedor";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtTotalSinIva
            // 
            this.txtTotalSinIva.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalSinIva.Location = new System.Drawing.Point(547, 626);
            this.txtTotalSinIva.Name = "txtTotalSinIva";
            this.txtTotalSinIva.ReadOnly = true;
            this.txtTotalSinIva.Size = new System.Drawing.Size(84, 23);
            this.txtTotalSinIva.TabIndex = 63;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(470, 630);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 15);
            this.label17.TabIndex = 62;
            this.label17.Text = "Total S/ IVA";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(558, 595);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 17);
            this.label7.TabIndex = 64;
            this.label7.Text = "Comisión:";
            // 
            // nudComision
            // 
            this.nudComision.DecimalPlaces = 1;
            this.nudComision.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudComision.Location = new System.Drawing.Point(635, 592);
            this.nudComision.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nudComision.Name = "nudComision";
            this.nudComision.Size = new System.Drawing.Size(83, 23);
            this.nudComision.TabIndex = 9;
            this.nudComision.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudComision_KeyPress);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(274, 49);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(44, 17);
            this.label18.TabIndex = 65;
            this.label18.Text = "Ing. B";
            // 
            // cboIngBrutos
            // 
            this.cboIngBrutos.FormattingEnabled = true;
            this.cboIngBrutos.Location = new System.Drawing.Point(325, 46);
            this.cboIngBrutos.Name = "cboIngBrutos";
            this.cboIngBrutos.Size = new System.Drawing.Size(68, 23);
            this.cboIngBrutos.TabIndex = 66;
            this.cboIngBrutos.SelectedIndexChanged += new System.EventHandler(this.cboIngBrutos_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(637, 630);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(26, 15);
            this.label19.TabIndex = 67;
            this.label19.Text = "IVA";
            // 
            // txtIVA
            // 
            this.txtIVA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIVA.Location = new System.Drawing.Point(669, 626);
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.ReadOnly = true;
            this.txtIVA.Size = new System.Drawing.Size(84, 23);
            this.txtIVA.TabIndex = 68;
            // 
            // txtIB
            // 
            this.txtIB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIB.Location = new System.Drawing.Point(828, 626);
            this.txtIB.Name = "txtIB";
            this.txtIB.ReadOnly = true;
            this.txtIB.Size = new System.Drawing.Size(84, 23);
            this.txtIB.TabIndex = 70;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(759, 630);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(68, 15);
            this.label20.TabIndex = 69;
            this.label20.Text = "Ing. Brutos";
            // 
            // frmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1116, 697);
            this.Controls.Add(this.txtIB);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtIVA);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.cboIngBrutos);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.nudComision);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTotalSinIva);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cboVendedores);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.txtTotGeneral);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAltaCliente);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSubSinIVA);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.nudRecargo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbDesc);
            this.Controls.Add(this.nudDescuento);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.cboIVA);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.gbFiltro);
            this.Controls.Add(this.btnPedido);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventas";
            this.Load += new System.EventHandler(this.frmVentas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVentas_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.nudRecargo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudComision)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.NumericUpDown nudRecargo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboIVA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbDesc;
        private System.Windows.Forms.NumericUpDown nudDescuento;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.ComboBox cboFiltro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lblCliente;
        private System.Windows.Forms.GroupBox gbFiltro;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Button btnPedido;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSubSinIVA;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Button btnAltaCliente;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblEncargado;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblDir;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblClienteNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cod_Barras;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cod_Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioSinIva;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioConIva;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioOrig;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn pedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn costo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTotGeneral;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCambioPrecio;
        private System.Windows.Forms.ComboBox cboVendedores;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtTotalSinIva;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown nudComision;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboIngBrutos;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtIB;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtIVA;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblCondIVA;
        private System.Windows.Forms.Label label21;
    }
}