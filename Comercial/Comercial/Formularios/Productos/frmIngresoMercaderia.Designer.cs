namespace Comercial.Formularios.Productos
{
    partial class frmIngresoMercaderia
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIngresoMercaderia));
            this.lblProveedor = new System.Windows.Forms.Label();
            this.btnSelProveedor = new System.Windows.Forms.Button();
            this.cboProveedores = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboIVA = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.cboFiltro = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCargarNtaPedido = new System.Windows.Forms.Button();
            this.lbDesc = new System.Windows.Forms.ListBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.nudDescuento = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvIngreso = new System.Windows.Forms.DataGridView();
            this.Cod_Barras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cod_Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMinima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_Lista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio_SIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio_CIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoOrig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ntaPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.nudGanancia = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.txtComprobante = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pbProceso = new System.Windows.Forms.ProgressBar();
            this.backgroundWorkerTarea = new System.ComponentModel.BackgroundWorker();
            this.gbFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngreso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGanancia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.Location = new System.Drawing.Point(380, 16);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(122, 15);
            this.lblProveedor.TabIndex = 16;
            this.lblProveedor.Text = "Búsq. Por Descripción";
            // 
            // btnSelProveedor
            // 
            this.btnSelProveedor.BackColor = System.Drawing.Color.Silver;
            this.btnSelProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelProveedor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelProveedor.Image = global::Comercial.Properties.Resources.play_button;
            this.btnSelProveedor.Location = new System.Drawing.Point(294, 12);
            this.btnSelProveedor.Name = "btnSelProveedor";
            this.btnSelProveedor.Size = new System.Drawing.Size(49, 23);
            this.btnSelProveedor.TabIndex = 15;
            this.btnSelProveedor.UseVisualStyleBackColor = false;
            this.btnSelProveedor.Click += new System.EventHandler(this.btnSelProveedor_Click);
            // 
            // cboProveedores
            // 
            this.cboProveedores.FormattingEnabled = true;
            this.cboProveedores.Location = new System.Drawing.Point(88, 12);
            this.cboProveedores.Name = "cboProveedores";
            this.cboProveedores.Size = new System.Drawing.Size(200, 23);
            this.cboProveedores.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Proveedor";
            // 
            // cboIVA
            // 
            this.cboIVA.FormattingEnabled = true;
            this.cboIVA.Location = new System.Drawing.Point(1234, 12);
            this.cboIVA.Name = "cboIVA";
            this.cboIVA.Size = new System.Drawing.Size(88, 23);
            this.cboIVA.TabIndex = 1;
            this.cboIVA.SelectedIndexChanged += new System.EventHandler(this.cboIVA_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1199, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "IVA";
            // 
            // gbFiltro
            // 
            this.gbFiltro.BackColor = System.Drawing.Color.Silver;
            this.gbFiltro.Controls.Add(this.lblDescripcion);
            this.gbFiltro.Controls.Add(this.btnAgregar);
            this.gbFiltro.Controls.Add(this.nudCantidad);
            this.gbFiltro.Controls.Add(this.label3);
            this.gbFiltro.Controls.Add(this.txtDesc);
            this.gbFiltro.Controls.Add(this.txtFiltro);
            this.gbFiltro.Controls.Add(this.cboFiltro);
            this.gbFiltro.Controls.Add(this.label2);
            this.gbFiltro.Controls.Add(this.btnCargarNtaPedido);
            this.gbFiltro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFiltro.Location = new System.Drawing.Point(14, 58);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(1308, 118);
            this.gbFiltro.TabIndex = 2;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Busqueda por Producto";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(439, 33);
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
            this.btnAgregar.Location = new System.Drawing.Point(1243, 73);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(49, 23);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // nudCantidad
            // 
            this.nudCantidad.DecimalPlaces = 4;
            this.nudCantidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCantidad.Location = new System.Drawing.Point(1107, 73);
            this.nudCantidad.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(120, 23);
            this.nudCantidad.TabIndex = 4;
            this.nudCantidad.Enter += new System.EventHandler(this.nudCantidad_Enter);
            this.nudCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudCantidad_KeyDown);
            this.nudCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudCantidad_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Búsq. Por Descripción";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(141, 73);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(472, 23);
            this.txtDesc.TabIndex = 2;
            this.txtDesc.TextChanged += new System.EventHandler(this.txtDesc_TextChanged);
            this.txtDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDesc_KeyDown);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(230, 29);
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
            this.cboFiltro.Location = new System.Drawing.Point(53, 29);
            this.cboFiltro.Name = "cboFiltro";
            this.cboFiltro.Size = new System.Drawing.Size(171, 23);
            this.cboFiltro.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Filtro:";
            // 
            // btnCargarNtaPedido
            // 
            this.btnCargarNtaPedido.BackColor = System.Drawing.Color.Silver;
            this.btnCargarNtaPedido.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCargarNtaPedido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarNtaPedido.Location = new System.Drawing.Point(1133, 29);
            this.btnCargarNtaPedido.Name = "btnCargarNtaPedido";
            this.btnCargarNtaPedido.Size = new System.Drawing.Size(159, 23);
            this.btnCargarNtaPedido.TabIndex = 3;
            this.btnCargarNtaPedido.Text = "Cargar Nota Pedido [F2]";
            this.btnCargarNtaPedido.UseVisualStyleBackColor = false;
            this.btnCargarNtaPedido.Click += new System.EventHandler(this.btnCargarNtaPedido_Click);
            // 
            // lbDesc
            // 
            this.lbDesc.FormattingEnabled = true;
            this.lbDesc.ItemHeight = 15;
            this.lbDesc.Location = new System.Drawing.Point(155, 156);
            this.lbDesc.Name = "lbDesc";
            this.lbDesc.Size = new System.Drawing.Size(472, 169);
            this.lbDesc.TabIndex = 20;
            this.lbDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbDesc_KeyDown);
            this.lbDesc.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbDesc_MouseDoubleClick);
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(1054, 582);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(127, 23);
            this.txtTotal.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(967, 586);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 15);
            this.label7.TabIndex = 27;
            this.label7.Text = "Total General";
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.Color.Silver;
            this.btnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGrabar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.Image = global::Comercial.Properties.Resources.save__1_;
            this.btnGrabar.Location = new System.Drawing.Point(1206, 576);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(116, 34);
            this.btnGrabar.TabIndex = 5;
            this.btnGrabar.Text = "  Grabar [F5]";
            this.btnGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // nudDescuento
            // 
            this.nudDescuento.DecimalPlaces = 2;
            this.nudDescuento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDescuento.Location = new System.Drawing.Point(84, 582);
            this.nudDescuento.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudDescuento.Name = "nudDescuento";
            this.nudDescuento.Size = new System.Drawing.Size(83, 23);
            this.nudDescuento.TabIndex = 3;
            this.nudDescuento.ValueChanged += new System.EventHandler(this.nudDescuento_ValueChanged);
            this.nudDescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudDescuento_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 586);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 23;
            this.label5.Text = "Descuento";
            // 
            // dgvIngreso
            // 
            this.dgvIngreso.AllowUserToAddRows = false;
            this.dgvIngreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngreso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cod_Barras,
            this.Cod_Proveedor,
            this.Descripcion,
            this.Stock,
            this.CMinima,
            this.Costo,
            this.P_Lista,
            this.Precio_SIVA,
            this.Precio_CIVA,
            this.Cantidad,
            this.Subtotal,
            this.costoOrig,
            this.id,
            this.ntaPedido,
            this.linea});
            this.dgvIngreso.Location = new System.Drawing.Point(14, 182);
            this.dgvIngreso.Name = "dgvIngreso";
            this.dgvIngreso.Size = new System.Drawing.Size(1308, 384);
            this.dgvIngreso.TabIndex = 21;
            this.dgvIngreso.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvIngreso_CellParsing);
            this.dgvIngreso.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIngreso_CellValueChanged);
            this.dgvIngreso.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvIngreso_RowsRemoved);
            this.dgvIngreso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvIngreso_KeyPress);
            // 
            // Cod_Barras
            // 
            this.Cod_Barras.HeaderText = "Cod_Barras";
            this.Cod_Barras.Name = "Cod_Barras";
            this.Cod_Barras.ReadOnly = true;
            // 
            // Cod_Proveedor
            // 
            this.Cod_Proveedor.HeaderText = "Cod_Proveedor";
            this.Cod_Proveedor.Name = "Cod_Proveedor";
            this.Cod_Proveedor.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 300;
            // 
            // Stock
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Stock.DefaultCellStyle = dataGridViewCellStyle1;
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            this.Stock.Width = 80;
            // 
            // CMinima
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CMinima.DefaultCellStyle = dataGridViewCellStyle2;
            this.CMinima.HeaderText = "C. Min";
            this.CMinima.Name = "CMinima";
            this.CMinima.Width = 80;
            // 
            // Costo
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Costo.DefaultCellStyle = dataGridViewCellStyle3;
            this.Costo.HeaderText = "Costo";
            this.Costo.Name = "Costo";
            // 
            // P_Lista
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.P_Lista.DefaultCellStyle = dataGridViewCellStyle4;
            this.P_Lista.HeaderText = "P_Lista";
            this.P_Lista.Name = "P_Lista";
            // 
            // Precio_SIVA
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Precio_SIVA.DefaultCellStyle = dataGridViewCellStyle5;
            this.Precio_SIVA.HeaderText = "Precio Prov_S/IVA";
            this.Precio_SIVA.Name = "Precio_SIVA";
            // 
            // Precio_CIVA
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Precio_CIVA.DefaultCellStyle = dataGridViewCellStyle6;
            this.Precio_CIVA.HeaderText = "Precio Prov_C/IVA";
            this.Precio_CIVA.Name = "Precio_CIVA";
            // 
            // Cantidad
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle7;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // Subtotal
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Subtotal.DefaultCellStyle = dataGridViewCellStyle8;
            this.Subtotal.HeaderText = "Subtotal";
            this.Subtotal.Name = "Subtotal";
            // 
            // costoOrig
            // 
            this.costoOrig.HeaderText = "costoOrig";
            this.costoOrig.Name = "costoOrig";
            this.costoOrig.Visible = false;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // ntaPedido
            // 
            this.ntaPedido.HeaderText = "ntaPedido";
            this.ntaPedido.Name = "ntaPedido";
            this.ntaPedido.Visible = false;
            // 
            // linea
            // 
            this.linea.HeaderText = "linea";
            this.linea.Name = "linea";
            this.linea.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(185, 586);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 15);
            this.label6.TabIndex = 24;
            this.label6.Text = "Ganancia";
            // 
            // nudGanancia
            // 
            this.nudGanancia.DecimalPlaces = 2;
            this.nudGanancia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudGanancia.Location = new System.Drawing.Point(244, 582);
            this.nudGanancia.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudGanancia.Name = "nudGanancia";
            this.nudGanancia.Size = new System.Drawing.Size(83, 23);
            this.nudGanancia.TabIndex = 4;
            this.nudGanancia.ValueChanged += new System.EventHandler(this.nudGanancia_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(630, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 15);
            this.label8.TabIndex = 29;
            this.label8.Text = "Fecha Carga:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(711, 12);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 23);
            this.dtpFecha.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(931, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 15);
            this.label9.TabIndex = 31;
            this.label9.Text = "N° Comprobante:";
            // 
            // txtComprobante
            // 
            this.txtComprobante.Location = new System.Drawing.Point(1038, 12);
            this.txtComprobante.Name = "txtComprobante";
            this.txtComprobante.Size = new System.Drawing.Size(120, 23);
            this.txtComprobante.TabIndex = 12;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pbProceso
            // 
            this.pbProceso.Location = new System.Drawing.Point(361, 582);
            this.pbProceso.Name = "pbProceso";
            this.pbProceso.Size = new System.Drawing.Size(589, 23);
            this.pbProceso.TabIndex = 32;
            // 
            // backgroundWorkerTarea
            // 
            this.backgroundWorkerTarea.WorkerReportsProgress = true;
            this.backgroundWorkerTarea.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerTarea_DoWork);
            this.backgroundWorkerTarea.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerTarea_ProgressChanged);
            // 
            // frmIngresoMercaderia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1334, 625);
            this.Controls.Add(this.pbProceso);
            this.Controls.Add(this.txtComprobante);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nudGanancia);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudDescuento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbDesc);
            this.Controls.Add(this.dgvIngreso);
            this.Controls.Add(this.gbFiltro);
            this.Controls.Add(this.cboIVA);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblProveedor);
            this.Controls.Add(this.btnSelProveedor);
            this.Controls.Add(this.cboProveedores);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIngresoMercaderia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso de Mercaderia";
            this.Load += new System.EventHandler(this.frmIngresoMercaderia_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmIngresoMercaderia_KeyDown);
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngreso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGanancia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Button btnSelProveedor;
        private System.Windows.Forms.ComboBox cboProveedores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboIVA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbFiltro;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.ComboBox cboFiltro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCargarNtaPedido;
        private System.Windows.Forms.ListBox lbDesc;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.NumericUpDown nudDescuento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvIngreso;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudGanancia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cod_Barras;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cod_Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMinima;
        private System.Windows.Forms.DataGridViewTextBoxColumn Costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn P_Lista;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio_SIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio_CIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoOrig;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ntaPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn linea;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtComprobante;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ProgressBar pbProceso;
        private System.ComponentModel.BackgroundWorker backgroundWorkerTarea;
    }
}