namespace Comercial.Formularios.Productos
{
    partial class frmCambioPrecios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambioPrecios));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnListar = new System.Windows.Forms.Button();
            this.cboRubros = new System.Windows.Forms.ComboBox();
            this.cbRubros = new System.Windows.Forms.CheckBox();
            this.cboProveedores = new System.Windows.Forms.ComboBox();
            this.cbProveedor = new System.Windows.Forms.CheckBox();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.btnCambioPrecios = new System.Windows.Forms.Button();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.nudValor = new System.Windows.Forms.NumericUpDown();
            this.rtbObserv = new System.Windows.Forms.RichTextBox();
            this.backgroundTarea = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValor)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.btnListar);
            this.groupBox1.Controls.Add(this.cboRubros);
            this.groupBox1.Controls.Add(this.cbRubros);
            this.groupBox1.Controls.Add(this.cboProveedores);
            this.groupBox1.Controls.Add(this.cbProveedor);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(729, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // btnListar
            // 
            this.btnListar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListar.Image = global::Comercial.Properties.Resources.list_with_bullets;
            this.btnListar.Location = new System.Drawing.Point(631, 13);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(86, 36);
            this.btnListar.TabIndex = 4;
            this.btnListar.Text = "Listar";
            this.btnListar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // cboRubros
            // 
            this.cboRubros.FormattingEnabled = true;
            this.cboRubros.Location = new System.Drawing.Point(404, 20);
            this.cboRubros.Name = "cboRubros";
            this.cboRubros.Size = new System.Drawing.Size(223, 23);
            this.cboRubros.TabIndex = 3;
            // 
            // cbRubros
            // 
            this.cbRubros.AutoSize = true;
            this.cbRubros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRubros.Location = new System.Drawing.Point(335, 22);
            this.cbRubros.Name = "cbRubros";
            this.cbRubros.Size = new System.Drawing.Size(65, 19);
            this.cbRubros.TabIndex = 2;
            this.cbRubros.Text = "Rubros";
            this.cbRubros.UseVisualStyleBackColor = true;
            // 
            // cboProveedores
            // 
            this.cboProveedores.FormattingEnabled = true;
            this.cboProveedores.Location = new System.Drawing.Point(108, 20);
            this.cboProveedores.Name = "cboProveedores";
            this.cboProveedores.Size = new System.Drawing.Size(223, 23);
            this.cboProveedores.TabIndex = 1;
            // 
            // cbProveedor
            // 
            this.cbProveedor.AutoSize = true;
            this.cbProveedor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbProveedor.Location = new System.Drawing.Point(7, 22);
            this.cbProveedor.Name = "cbProveedor";
            this.cbProveedor.Size = new System.Drawing.Size(97, 19);
            this.cbProveedor.TabIndex = 0;
            this.cbProveedor.Text = "Proveedores";
            this.cbProveedor.UseVisualStyleBackColor = true;
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AllowUserToOrderColumns = true;
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(3, 123);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.Size = new System.Drawing.Size(962, 394);
            this.dgvProductos.TabIndex = 3;
            // 
            // btnCambioPrecios
            // 
            this.btnCambioPrecios.BackColor = System.Drawing.Color.Silver;
            this.btnCambioPrecios.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambioPrecios.Image = global::Comercial.Properties.Resources.save__1_;
            this.btnCambioPrecios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCambioPrecios.Location = new System.Drawing.Point(815, 523);
            this.btnCambioPrecios.Name = "btnCambioPrecios";
            this.btnCambioPrecios.Size = new System.Drawing.Size(150, 35);
            this.btnCambioPrecios.TabIndex = 4;
            this.btnCambioPrecios.Text = "Cambiar Precios";
            this.btnCambioPrecios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCambioPrecios.UseVisualStyleBackColor = false;
            this.btnCambioPrecios.Click += new System.EventHandler(this.btnCambioPrecios_Click);
            // 
            // cboTipo
            // 
            this.cboTipo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(3, 83);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(121, 28);
            this.cboTipo.TabIndex = 1;
            this.cboTipo.SelectedIndexChanged += new System.EventHandler(this.cboTipo_SelectedIndexChanged);
            // 
            // nudValor
            // 
            this.nudValor.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudValor.Location = new System.Drawing.Point(130, 76);
            this.nudValor.Name = "nudValor";
            this.nudValor.Size = new System.Drawing.Size(61, 43);
            this.nudValor.TabIndex = 2;
            this.nudValor.ValueChanged += new System.EventHandler(this.nudValor_ValueChanged);
            // 
            // rtbObserv
            // 
            this.rtbObserv.Location = new System.Drawing.Point(971, 123);
            this.rtbObserv.Name = "rtbObserv";
            this.rtbObserv.Size = new System.Drawing.Size(162, 394);
            this.rtbObserv.TabIndex = 5;
            this.rtbObserv.Text = "";
            // 
            // backgroundTarea
            // 
            this.backgroundTarea.WorkerReportsProgress = true;
            this.backgroundTarea.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundTarea_DoWork);
            // 
            // frmCambioPrecios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1145, 565);
            this.Controls.Add(this.rtbObserv);
            this.Controls.Add(this.nudValor);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.btnCambioPrecios);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCambioPrecios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambios de Precios";
            this.Load += new System.EventHandler(this.frmCambioPrecios_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.ComboBox cboRubros;
        private System.Windows.Forms.CheckBox cbRubros;
        private System.Windows.Forms.ComboBox cboProveedores;
        private System.Windows.Forms.CheckBox cbProveedor;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Button btnCambioPrecios;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.NumericUpDown nudValor;
        private System.Windows.Forms.RichTextBox rtbObserv;
        private System.ComponentModel.BackgroundWorker backgroundTarea;
    }
}