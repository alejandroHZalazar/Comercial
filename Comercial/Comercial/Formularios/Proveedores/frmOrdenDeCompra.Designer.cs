namespace Comercial.Formularios.Proveedores
{
    partial class frmOrdenDeCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrdenDeCompra));
            this.gbFiltro = new System.Windows.Forms.GroupBox();
            this.btnInventario = new System.Windows.Forms.Button();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.cboFiltro = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCantMinima = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboProveedores = new System.Windows.Forms.ComboBox();
            this.lbDesc = new System.Windows.Forms.ListBox();
            this.btnSelProveedor = new System.Windows.Forms.Button();
            this.dgvOrden = new System.Windows.Forms.DataGridView();
            this.Cod_Barras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cod_Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMinima = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio_SIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio_CIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoOrig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.cboIVA = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nudDescuento = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nudRecargo = new System.Windows.Forms.NumericUpDown();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.pbProgreso = new System.Windows.Forms.ProgressBar();
            this.backgroundWorkerTarea = new System.ComponentModel.BackgroundWorker();
            this.gbFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecargo)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFiltro
            // 
            this.gbFiltro.BackColor = System.Drawing.Color.Silver;
            this.gbFiltro.Controls.Add(this.btnInventario);
            this.gbFiltro.Controls.Add(this.lblDescripcion);
            this.gbFiltro.Controls.Add(this.btnAgregar);
            this.gbFiltro.Controls.Add(this.nudCantidad);
            this.gbFiltro.Controls.Add(this.label3);
            this.gbFiltro.Controls.Add(this.txtDesc);
            this.gbFiltro.Controls.Add(this.txtFiltro);
            this.gbFiltro.Controls.Add(this.cboFiltro);
            this.gbFiltro.Controls.Add(this.label2);
            this.gbFiltro.Controls.Add(this.btnCantMinima);
            this.gbFiltro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFiltro.Location = new System.Drawing.Point(12, 40);
            this.gbFiltro.Name = "gbFiltro";
            this.gbFiltro.Size = new System.Drawing.Size(1100, 118);
            this.gbFiltro.TabIndex = 2;
            this.gbFiltro.TabStop = false;
            this.gbFiltro.Text = "Busqueda por Producto";
            // 
            // btnInventario
            // 
            this.btnInventario.BackColor = System.Drawing.Color.Silver;
            this.btnInventario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInventario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventario.Location = new System.Drawing.Point(755, 25);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(159, 23);
            this.btnInventario.TabIndex = 12;
            this.btnInventario.Text = "Inv. de Productos [F3]";
            this.btnInventario.UseVisualStyleBackColor = false;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
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
            this.btnAgregar.Location = new System.Drawing.Point(1037, 76);
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
            this.nudCantidad.Location = new System.Drawing.Point(901, 76);
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
            // btnCantMinima
            // 
            this.btnCantMinima.BackColor = System.Drawing.Color.Silver;
            this.btnCantMinima.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCantMinima.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCantMinima.Location = new System.Drawing.Point(927, 25);
            this.btnCantMinima.Name = "btnCantMinima";
            this.btnCantMinima.Size = new System.Drawing.Size(159, 23);
            this.btnCantMinima.TabIndex = 3;
            this.btnCantMinima.Text = "Debajo Cant. Minima [F2]";
            this.btnCantMinima.UseVisualStyleBackColor = false;
            this.btnCantMinima.Click += new System.EventHandler(this.btnCantMinima_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Proveedor";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cboProveedores
            // 
            this.cboProveedores.FormattingEnabled = true;
            this.cboProveedores.Location = new System.Drawing.Point(89, 6);
            this.cboProveedores.Name = "cboProveedores";
            this.cboProveedores.Size = new System.Drawing.Size(200, 23);
            this.cboProveedores.TabIndex = 0;
            this.cboProveedores.SelectedIndexChanged += new System.EventHandler(this.cboProveedores_SelectedIndexChanged);
            // 
            // lbDesc
            // 
            this.lbDesc.FormattingEnabled = true;
            this.lbDesc.ItemHeight = 15;
            this.lbDesc.Location = new System.Drawing.Point(153, 137);
            this.lbDesc.Name = "lbDesc";
            this.lbDesc.Size = new System.Drawing.Size(472, 169);
            this.lbDesc.TabIndex = 4;
            this.lbDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbDesc_KeyDown);
            this.lbDesc.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbDesc_MouseDoubleClick);
            // 
            // btnSelProveedor
            // 
            this.btnSelProveedor.BackColor = System.Drawing.Color.Silver;
            this.btnSelProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelProveedor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelProveedor.Image = global::Comercial.Properties.Resources.play_button;
            this.btnSelProveedor.Location = new System.Drawing.Point(295, 6);
            this.btnSelProveedor.Name = "btnSelProveedor";
            this.btnSelProveedor.Size = new System.Drawing.Size(49, 23);
            this.btnSelProveedor.TabIndex = 1;
            this.btnSelProveedor.UseVisualStyleBackColor = false;
            this.btnSelProveedor.Click += new System.EventHandler(this.btnSelProveedor_Click);
            // 
            // dgvOrden
            // 
            this.dgvOrden.AllowUserToAddRows = false;
            this.dgvOrden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrden.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cod_Barras,
            this.Cod_Proveedor,
            this.Descripcion,
            this.Stock,
            this.CMinima,
            this.Precio_SIVA,
            this.Precio_CIVA,
            this.Cantidad,
            this.Subtotal,
            this.costoOrig,
            this.id});
            this.dgvOrden.Location = new System.Drawing.Point(15, 164);
            this.dgvOrden.Name = "dgvOrden";
            this.dgvOrden.Size = new System.Drawing.Size(1104, 385);
            this.dgvOrden.TabIndex = 3;
            this.dgvOrden.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrden_CellContentClick);
            this.dgvOrden.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvOrden_CellParsing);
            this.dgvOrden.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrden_CellValueChanged);
            this.dgvOrden.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvOrden_RowsRemoved);
            this.dgvOrden.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvOrden_KeyPress);
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
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            this.Stock.Width = 80;
            // 
            // CMinima
            // 
            this.CMinima.HeaderText = "C. Min";
            this.CMinima.Name = "CMinima";
            this.CMinima.Width = 80;
            // 
            // Precio_SIVA
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.NullValue = null;
            this.Precio_SIVA.DefaultCellStyle = dataGridViewCellStyle1;
            this.Precio_SIVA.HeaderText = "Precio_S/IVA";
            this.Precio_SIVA.Name = "Precio_SIVA";
            // 
            // Precio_CIVA
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Precio_CIVA.DefaultCellStyle = dataGridViewCellStyle2;
            this.Precio_CIVA.HeaderText = "Precio_C/IVA";
            this.Precio_CIVA.Name = "Precio_CIVA";
            // 
            // Cantidad
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle3;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // Subtotal
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Subtotal.DefaultCellStyle = dataGridViewCellStyle4;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(989, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "IVA";
            // 
            // cboIVA
            // 
            this.cboIVA.FormattingEnabled = true;
            this.cboIVA.Location = new System.Drawing.Point(1024, 6);
            this.cboIVA.Name = "cboIVA";
            this.cboIVA.Size = new System.Drawing.Size(88, 23);
            this.cboIVA.TabIndex = 8;
            this.cboIVA.SelectedIndexChanged += new System.EventHandler(this.cboIVA_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 565);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Descuento";
            // 
            // nudDescuento
            // 
            this.nudDescuento.DecimalPlaces = 2;
            this.nudDescuento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDescuento.Location = new System.Drawing.Point(85, 561);
            this.nudDescuento.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudDescuento.Name = "nudDescuento";
            this.nudDescuento.Size = new System.Drawing.Size(83, 23);
            this.nudDescuento.TabIndex = 4;
            this.nudDescuento.ValueChanged += new System.EventHandler(this.nudDescuento_ValueChanged);
            this.nudDescuento.Enter += new System.EventHandler(this.nudDescuento_Enter);
            this.nudDescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudDescuento_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(188, 565);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Recargo";
            // 
            // nudRecargo
            // 
            this.nudRecargo.DecimalPlaces = 2;
            this.nudRecargo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudRecargo.Location = new System.Drawing.Point(247, 561);
            this.nudRecargo.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudRecargo.Name = "nudRecargo";
            this.nudRecargo.Size = new System.Drawing.Size(83, 23);
            this.nudRecargo.TabIndex = 5;
            this.nudRecargo.ValueChanged += new System.EventHandler(this.nudRecargo_ValueChanged);
            this.nudRecargo.Enter += new System.EventHandler(this.nudRecargo_Enter);
            this.nudRecargo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudRecargo_KeyPress);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.Color.Silver;
            this.btnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGrabar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.Image = global::Comercial.Properties.Resources.save__1_;
            this.btnGrabar.Location = new System.Drawing.Point(1003, 555);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(116, 34);
            this.btnGrabar.TabIndex = 6;
            this.btnGrabar.Text = "  Grabar [F5]";
            this.btnGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.Location = new System.Drawing.Point(437, 11);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(122, 15);
            this.lblProveedor.TabIndex = 12;
            this.lblProveedor.Text = "Búsq. Por Descripción";
            this.lblProveedor.Click += new System.EventHandler(this.lblProveedor_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(764, 565);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "Total General";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(851, 561);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(127, 23);
            this.txtTotal.TabIndex = 16;
            // 
            // pbProgreso
            // 
            this.pbProgreso.Location = new System.Drawing.Point(348, 561);
            this.pbProgreso.Name = "pbProgreso";
            this.pbProgreso.Size = new System.Drawing.Size(410, 23);
            this.pbProgreso.TabIndex = 17;
            // 
            // backgroundWorkerTarea
            // 
            this.backgroundWorkerTarea.WorkerReportsProgress = true;
            this.backgroundWorkerTarea.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerTarea_DoWork);
            this.backgroundWorkerTarea.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerTarea_ProgressChanged);
            // 
            // frmOrdenDeCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1124, 599);
            this.Controls.Add(this.pbProgreso);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblProveedor);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.nudRecargo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudDescuento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboIVA);
            this.Controls.Add(this.lbDesc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSelProveedor);
            this.Controls.Add(this.cboProveedores);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbFiltro);
            this.Controls.Add(this.dgvOrden);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOrdenDeCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orden de Compra";
            this.Load += new System.EventHandler(this.frmOrdenDeCompra_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOrdenDeCompra_KeyDown);
            this.gbFiltro.ResumeLayout(false);
            this.gbFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecargo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFiltro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboProveedores;
        private System.Windows.Forms.Button btnCantMinima;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.ComboBox cboFiltro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.ListBox lbDesc;
        private System.Windows.Forms.Button btnSelProveedor;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvOrden;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboIVA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudDescuento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudRecargo;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cod_Barras;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cod_Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMinima;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio_SIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio_CIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoOrig;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.ProgressBar pbProgreso;
        private System.ComponentModel.BackgroundWorker backgroundWorkerTarea;
        private System.Windows.Forms.Button btnInventario;
    }
}