namespace Comercial.Formularios.Ventas
{
    partial class frmPedidos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPedidos));
            this.lblClienteNombre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.ListBox();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.rtbObserv = new System.Windows.Forms.RichTextBox();
            this.cboVendedores = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.cboFiltro = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvPedido = new System.Windows.Forms.DataGridView();
            this.Cod_Barras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cod_Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioSinIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioConIva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioOrig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbDesc = new System.Windows.Forms.ListBox();
            this.cboIVA = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.nudRecargo = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nudDescuento = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.pbProceso = new System.Windows.Forms.ProgressBar();
            this.backgroundWorkerTarea = new System.ComponentModel.BackgroundWorker();
            this.btnAltaCliente = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblEncargado = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblDir = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.txtTotGeneral = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSinIVA = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtTotalConIVA = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.gbFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecargo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDescuento)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Cliente";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(61, 5);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(330, 23);
            this.txtCliente.TabIndex = 0;
            this.txtCliente.TextChanged += new System.EventHandler(this.txtDesc_TextChanged);
            this.txtCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCliente_KeyDown);
            // 
            // lblCliente
            // 
            this.lblCliente.FormattingEnabled = true;
            this.lblCliente.ItemHeight = 15;
            this.lblCliente.Location = new System.Drawing.Point(61, 32);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(475, 169);
            this.lblCliente.TabIndex = 18;
            this.lblCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lblCliente_KeyDown);
            this.lblCliente.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lblCliente_MouseDoubleClick);
            // 
            // gbFiltro
            // 
            this.gbFiltro.BackColor = System.Drawing.Color.Silver;
            this.gbFiltro.Controls.Add(this.label13);
            this.gbFiltro.Controls.Add(this.rtbObserv);
            this.gbFiltro.Controls.Add(this.cboVendedores);
            this.gbFiltro.Controls.Add(this.label8);
            this.gbFiltro.Controls.Add(this.lblDescripcion);
            this.gbFiltro.Controls.Add(this.btnAgregar);
            this.gbFiltro.Controls.Add(this.nudCantidad);
            this.gbFiltro.Controls.Add(this.label3);
            this.gbFiltro.Controls.Add(this.txtDesc);
            this.gbFiltro.Controls.Add(this.txtFiltro);
            this.gbFiltro.Controls.Add(this.cboFiltro);
            this.gbFiltro.Controls.Add(this.label2);
            this.gbFiltro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFiltro.Location = new System.Drawing.Point(7, 101);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(1078, 118);
            this.gbFiltro.TabIndex = 2;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Busqueda por Producto";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(810, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 17);
            this.label13.TabIndex = 56;
            this.label13.Text = "Observaciones";
            // 
            // rtbObserv
            // 
            this.rtbObserv.Location = new System.Drawing.Point(810, 32);
            this.rtbObserv.Name = "rtbObserv";
            this.rtbObserv.Size = new System.Drawing.Size(251, 80);
            this.rtbObserv.TabIndex = 55;
            this.rtbObserv.Text = "";
            // 
            // cboVendedores
            // 
            this.cboVendedores.FormattingEnabled = true;
            this.cboVendedores.Location = new System.Drawing.Point(507, 11);
            this.cboVendedores.Name = "cboVendedores";
            this.cboVendedores.Size = new System.Drawing.Size(150, 23);
            this.cboVendedores.TabIndex = 54;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(434, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 17);
            this.label8.TabIndex = 54;
            this.label8.Text = "Vendedor";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(431, 42);
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
            this.btnAgregar.Location = new System.Drawing.Point(747, 82);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(49, 23);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // nudCantidad
            // 
            this.nudCantidad.DecimalPlaces = 4;
            this.nudCantidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCantidad.Location = new System.Drawing.Point(616, 82);
            this.nudCantidad.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(120, 23);
            this.nudCantidad.TabIndex = 2;
            this.nudCantidad.Enter += new System.EventHandler(this.nudCantidad_Enter);
            this.nudCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudCantidad_KeyDown);
            this.nudCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudCantidad_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Búsq. Por Descripción";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(133, 82);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(472, 23);
            this.txtDesc.TabIndex = 1;
            this.txtDesc.TextChanged += new System.EventHandler(this.txtDesc_TextChanged_1);
            this.txtDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDesc_KeyDown);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(222, 38);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(181, 23);
            this.txtFiltro.TabIndex = 0;
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
            this.cboFiltro.Location = new System.Drawing.Point(45, 38);
            this.cboFiltro.Name = "cboFiltro";
            this.cboFiltro.Size = new System.Drawing.Size(171, 23);
            this.cboFiltro.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Filtro:";
            // 
            // dgvPedido
            // 
            this.dgvPedido.AllowUserToAddRows = false;
            this.dgvPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedido.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cod_Barras,
            this.Cod_Proveedor,
            this.Descripcion,
            this.Observ,
            this.Stock,
            this.PrecioSinIVA,
            this.PrecioConIva,
            this.Cantidad,
            this.Subtotal,
            this.PrecioOrig,
            this.id,
            this.costo});
            this.dgvPedido.Location = new System.Drawing.Point(7, 226);
            this.dgvPedido.Name = "dgvPedido";
            this.dgvPedido.Size = new System.Drawing.Size(1080, 384);
            this.dgvPedido.TabIndex = 20;
            this.dgvPedido.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedido_CellEndEdit);
            this.dgvPedido.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvPedido_CellParsing);
            this.dgvPedido.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedido_CellValueChanged);
            this.dgvPedido.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvPedido_CurrentCellDirtyStateChanged);
            this.dgvPedido.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvPedido_RowsRemoved);
            this.dgvPedido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPedido_KeyDown);
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
            this.Cod_Proveedor.Width = 70;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 470;
            // 
            // Observ
            // 
            this.Observ.HeaderText = "Observ";
            this.Observ.Name = "Observ";
            this.Observ.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Observ.Width = 70;
            // 
            // Stock
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Stock.DefaultCellStyle = dataGridViewCellStyle1;
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            this.Stock.Width = 50;
            // 
            // PrecioSinIVA
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PrecioSinIVA.DefaultCellStyle = dataGridViewCellStyle2;
            this.PrecioSinIVA.HeaderText = "Precio S/IVA";
            this.PrecioSinIVA.Name = "PrecioSinIVA";
            this.PrecioSinIVA.Width = 70;
            // 
            // PrecioConIva
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PrecioConIva.DefaultCellStyle = dataGridViewCellStyle3;
            this.PrecioConIva.HeaderText = "Precio C/IVA";
            this.PrecioConIva.Name = "PrecioConIva";
            this.PrecioConIva.Width = 70;
            // 
            // Cantidad
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle4;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Width = 60;
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
            // costo
            // 
            this.costo.HeaderText = "costo";
            this.costo.Name = "costo";
            this.costo.Visible = false;
            // 
            // lbDesc
            // 
            this.lbDesc.FormattingEnabled = true;
            this.lbDesc.ItemHeight = 15;
            this.lbDesc.Location = new System.Drawing.Point(141, 207);
            this.lbDesc.Name = "lbDesc";
            this.lbDesc.Size = new System.Drawing.Size(472, 169);
            this.lbDesc.TabIndex = 21;
            this.lbDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbDesc_KeyDown);
            this.lbDesc.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbDesc_MouseDoubleClick);
            // 
            // cboIVA
            // 
            this.cboIVA.FormattingEnabled = true;
            this.cboIVA.Location = new System.Drawing.Point(318, 55);
            this.cboIVA.Name = "cboIVA";
            this.cboIVA.Size = new System.Drawing.Size(88, 23);
            this.cboIVA.TabIndex = 1;
            this.cboIVA.SelectedIndexChanged += new System.EventHandler(this.cboIVA_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(281, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "IVA";
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.Color.Silver;
            this.btnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGrabar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.Image = global::Comercial.Properties.Resources.save__1_;
            this.btnGrabar.Location = new System.Drawing.Point(969, 662);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(116, 34);
            this.btnGrabar.TabIndex = 5;
            this.btnGrabar.Text = "  Grabar [F5]";
            this.btnGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // nudRecargo
            // 
            this.nudRecargo.DecimalPlaces = 2;
            this.nudRecargo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudRecargo.Location = new System.Drawing.Point(216, 628);
            this.nudRecargo.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudRecargo.Name = "nudRecargo";
            this.nudRecargo.Size = new System.Drawing.Size(56, 23);
            this.nudRecargo.TabIndex = 4;
            this.nudRecargo.ValueChanged += new System.EventHandler(this.nudRecargo_ValueChanged);
            this.nudRecargo.Enter += new System.EventHandler(this.nudRecargo_Enter);
            this.nudRecargo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudRecargo_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(152, 632);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 15);
            this.label6.TabIndex = 26;
            this.label6.Text = "Recargo";
            // 
            // nudDescuento
            // 
            this.nudDescuento.DecimalPlaces = 2;
            this.nudDescuento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDescuento.Location = new System.Drawing.Point(85, 628);
            this.nudDescuento.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudDescuento.Name = "nudDescuento";
            this.nudDescuento.Size = new System.Drawing.Size(56, 23);
            this.nudDescuento.TabIndex = 3;
            this.nudDescuento.ValueChanged += new System.EventHandler(this.nudDescuento_ValueChanged);
            this.nudDescuento.Enter += new System.EventHandler(this.nudDescuento_Enter);
            this.nudDescuento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudDescuento_KeyDown);
            this.nudDescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudDescuento_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 632);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 25;
            this.label5.Text = "Descuento";
            // 
            // pbProceso
            // 
            this.pbProceso.Location = new System.Drawing.Point(771, 628);
            this.pbProceso.Name = "pbProceso";
            this.pbProceso.Size = new System.Drawing.Size(314, 23);
            this.pbProceso.TabIndex = 30;
            // 
            // backgroundWorkerTarea
            // 
            this.backgroundWorkerTarea.WorkerReportsProgress = true;
            this.backgroundWorkerTarea.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerTarea_DoWork);
            this.backgroundWorkerTarea.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerTarea_ProgressChanged);
            // 
            // btnAltaCliente
            // 
            this.btnAltaCliente.BackColor = System.Drawing.Color.Silver;
            this.btnAltaCliente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAltaCliente.Image = global::Comercial.Properties.Resources.plus;
            this.btnAltaCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAltaCliente.Location = new System.Drawing.Point(10, 49);
            this.btnAltaCliente.Name = "btnAltaCliente";
            this.btnAltaCliente.Size = new System.Drawing.Size(133, 35);
            this.btnAltaCliente.TabIndex = 53;
            this.btnAltaCliente.Text = "    Nuevo Cliente";
            this.btnAltaCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAltaCliente.UseVisualStyleBackColor = false;
            this.btnAltaCliente.Click += new System.EventHandler(this.btnAltaCliente_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.Silver;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Image = global::Comercial.Properties.Resources.pencil_edit_button__1_;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(151, 49);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(122, 35);
            this.btnEditar.TabIndex = 54;
            this.btnEditar.Text = "Editar Pedido";
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.lblEncargado);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lblDir);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblTel);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lblClienteNombre);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(420, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(665, 82);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Clientes";
            // 
            // lblEncargado
            // 
            this.lblEncargado.AutoSize = true;
            this.lblEncargado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncargado.Location = new System.Drawing.Point(492, 45);
            this.lblEncargado.Name = "lblEncargado";
            this.lblEncargado.Size = new System.Drawing.Size(122, 15);
            this.lblEncargado.TabIndex = 61;
            this.lblEncargado.Text = "Búsq. Por Descripción";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(423, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 17);
            this.label11.TabIndex = 60;
            this.label11.Text = "Contacto:";
            // 
            // lblDir
            // 
            this.lblDir.AutoSize = true;
            this.lblDir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDir.Location = new System.Drawing.Point(82, 45);
            this.lblDir.Name = "lblDir";
            this.lblDir.Size = new System.Drawing.Size(122, 15);
            this.lblDir.TabIndex = 59;
            this.lblDir.Text = "Búsq. Por Descripción";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 17);
            this.label12.TabIndex = 58;
            this.label12.Text = "Dirección:";
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTel.Location = new System.Drawing.Point(492, 20);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(122, 15);
            this.lblTel.TabIndex = 57;
            this.lblTel.Text = "Búsq. Por Descripción";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(423, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 17);
            this.label10.TabIndex = 56;
            this.label10.Text = "Tel:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 17);
            this.label9.TabIndex = 55;
            this.label9.Text = "Cliente:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Silver;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Image = global::Comercial.Properties.Resources.escoba;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(637, 622);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(116, 34);
            this.btnLimpiar.TabIndex = 56;
            this.btnLimpiar.Text = "    Limpiar";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtTotGeneral
            // 
            this.txtTotGeneral.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotGeneral.Location = new System.Drawing.Point(837, 664);
            this.txtTotGeneral.Name = "txtTotGeneral";
            this.txtTotGeneral.ReadOnly = true;
            this.txtTotGeneral.Size = new System.Drawing.Size(113, 29);
            this.txtTotGeneral.TabIndex = 66;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(733, 671);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(98, 15);
            this.label15.TabIndex = 65;
            this.label15.Text = "TOTAL GENERAL";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuento.Location = new System.Drawing.Point(503, 668);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.ReadOnly = true;
            this.txtDescuento.Size = new System.Drawing.Size(113, 23);
            this.txtDescuento.TabIndex = 64;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(400, 672);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(97, 15);
            this.label14.TabIndex = 63;
            this.label14.Text = "Total Descuento";
            // 
            // txtSinIVA
            // 
            this.txtSinIVA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSinIVA.Location = new System.Drawing.Point(85, 668);
            this.txtSinIVA.Name = "txtSinIVA";
            this.txtSinIVA.ReadOnly = true;
            this.txtSinIVA.Size = new System.Drawing.Size(113, 23);
            this.txtSinIVA.TabIndex = 62;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(8, 672);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 15);
            this.label16.TabIndex = 61;
            this.label16.Text = "Total S/ IVA";
            // 
            // txtTotalConIVA
            // 
            this.txtTotalConIVA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalConIVA.Location = new System.Drawing.Point(281, 668);
            this.txtTotalConIVA.Name = "txtTotalConIVA";
            this.txtTotalConIVA.ReadOnly = true;
            this.txtTotalConIVA.Size = new System.Drawing.Size(113, 23);
            this.txtTotalConIVA.TabIndex = 59;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(204, 672);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 15);
            this.label17.TabIndex = 60;
            this.label17.Text = "Total C/ IVA";
            // 
            // frmPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1097, 699);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.txtTotGeneral);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtSinIVA);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtTotalConIVA);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnAltaCliente);
            this.Controls.Add(this.pbProceso);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.nudRecargo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudDescuento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboIVA);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbDesc);
            this.Controls.Add(this.dgvPedido);
            this.Controls.Add(this.gbFiltro);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPedidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargar Pedidos";
            this.Load += new System.EventHandler(this.frmPedidos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPedidos_KeyDown);
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecargo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDescuento)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClienteNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.ListBox lblCliente;
        private System.Windows.Forms.GroupBox gbFiltro;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.ComboBox cboFiltro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvPedido;
        private System.Windows.Forms.ListBox lbDesc;
        private System.Windows.Forms.ComboBox cboIVA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.NumericUpDown nudRecargo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudDescuento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar pbProceso;
        private System.ComponentModel.BackgroundWorker backgroundWorkerTarea;
        private System.Windows.Forms.Button btnAltaCliente;
        private System.Windows.Forms.ComboBox cboVendedores;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblEncargado;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblDir;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cod_Barras;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cod_Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioSinIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioConIva;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioOrig;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn costo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RichTextBox rtbObserv;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtTotGeneral;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSinIVA;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtTotalConIVA;
        private System.Windows.Forms.Label label17;
    }
}