namespace Comercial.Formularios.Productos
{
    partial class frmAltaModifProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAltaModifProductos));
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodBarras = new System.Windows.Forms.TextBox();
            this.cboRubro = new System.Windows.Forms.ComboBox();
            this.nudCosto = new System.Windows.Forms.NumericUpDown();
            this.txtCodProveedor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboProveedor = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nudLista = new System.Windows.Forms.NumericUpDown();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.nudStock = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.nudMinima = new System.Windows.Forms.NumericUpDown();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnCalcularPrecio = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.nudProveedor = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.nudDescuento = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.nudGanancia = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudCosto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinima)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGanancia)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cod. Proveedor";
            // 
            // txtCodBarras
            // 
            this.txtCodBarras.Location = new System.Drawing.Point(107, 53);
            this.txtCodBarras.Name = "txtCodBarras";
            this.txtCodBarras.Size = new System.Drawing.Size(133, 23);
            this.txtCodBarras.TabIndex = 1;
            this.txtCodBarras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodBarras_KeyPress);
            // 
            // cboRubro
            // 
            this.cboRubro.FormattingEnabled = true;
            this.cboRubro.Location = new System.Drawing.Point(107, 131);
            this.cboRubro.Name = "cboRubro";
            this.cboRubro.Size = new System.Drawing.Size(172, 23);
            this.cboRubro.TabIndex = 3;
            // 
            // nudCosto
            // 
            this.nudCosto.DecimalPlaces = 2;
            this.nudCosto.Location = new System.Drawing.Point(107, 249);
            this.nudCosto.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCosto.Name = "nudCosto";
            this.nudCosto.Size = new System.Drawing.Size(94, 23);
            this.nudCosto.TabIndex = 10;
            this.nudCosto.Enter += new System.EventHandler(this.nudCosto_Enter);
            this.nudCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericUpDown1_KeyPress);
            // 
            // txtCodProveedor
            // 
            this.txtCodProveedor.Location = new System.Drawing.Point(107, 14);
            this.txtCodProveedor.Name = "txtCodProveedor";
            this.txtCodProveedor.Size = new System.Drawing.Size(133, 23);
            this.txtCodProveedor.TabIndex = 0;
            this.txtCodProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodProveedor_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cod. Barras";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Descripcion";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(107, 92);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(314, 23);
            this.txtDescripcion.TabIndex = 2;
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcion_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Rubro";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Proveedor";
            // 
            // cboProveedor
            // 
            this.cboProveedor.FormattingEnabled = true;
            this.cboProveedor.Location = new System.Drawing.Point(107, 171);
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Size = new System.Drawing.Size(181, 23);
            this.cboProveedor.TabIndex = 5;
            this.cboProveedor.SelectedIndexChanged += new System.EventHandler(this.cboProveedor_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 253);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "P. Costo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 292);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "P. Lista";
            // 
            // nudLista
            // 
            this.nudLista.DecimalPlaces = 2;
            this.nudLista.Location = new System.Drawing.Point(107, 288);
            this.nudLista.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudLista.Name = "nudLista";
            this.nudLista.Size = new System.Drawing.Size(94, 23);
            this.nudLista.TabIndex = 11;
            this.nudLista.Enter += new System.EventHandler(this.nudLista_Enter);
            this.nudLista.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudLista_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Silver;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = global::Comercial.Properties.Resources.back_arrow;
            this.btnCancelar.Location = new System.Drawing.Point(321, 405);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(111, 35);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar [F6]";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.Color.Silver;
            this.btnGrabar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.Image = global::Comercial.Properties.Resources.save__1_;
            this.btnGrabar.Location = new System.Drawing.Point(172, 405);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(111, 35);
            this.btnGrabar.TabIndex = 14;
            this.btnGrabar.Text = "Grabar [F5]";
            this.btnGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 331);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "Stock";
            // 
            // nudStock
            // 
            this.nudStock.DecimalPlaces = 2;
            this.nudStock.Location = new System.Drawing.Point(107, 327);
            this.nudStock.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudStock.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nudStock.Name = "nudStock";
            this.nudStock.Size = new System.Drawing.Size(94, 23);
            this.nudStock.TabIndex = 12;
            this.nudStock.Enter += new System.EventHandler(this.nudStock_Enter);
            this.nudStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudStock_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 370);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 15);
            this.label10.TabIndex = 17;
            this.label10.Text = "Cant. Mínima";
            // 
            // nudMinima
            // 
            this.nudMinima.DecimalPlaces = 2;
            this.nudMinima.Location = new System.Drawing.Point(107, 366);
            this.nudMinima.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMinima.Name = "nudMinima";
            this.nudMinima.Size = new System.Drawing.Size(94, 23);
            this.nudMinima.TabIndex = 13;
            this.nudMinima.Enter += new System.EventHandler(this.nudMinima_Enter);
            this.nudMinima.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudMinima_KeyPress);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnCalcularPrecio
            // 
            this.btnCalcularPrecio.BackColor = System.Drawing.Color.Silver;
            this.btnCalcularPrecio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcularPrecio.Location = new System.Drawing.Point(244, 286);
            this.btnCalcularPrecio.Name = "btnCalcularPrecio";
            this.btnCalcularPrecio.Size = new System.Drawing.Size(150, 27);
            this.btnCalcularPrecio.TabIndex = 9;
            this.btnCalcularPrecio.Text = "Calcular Precios [F7]";
            this.btnCalcularPrecio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCalcularPrecio.UseVisualStyleBackColor = false;
            this.btnCalcularPrecio.Click += new System.EventHandler(this.btnCalcularPrecio_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 214);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 15);
            this.label11.TabIndex = 18;
            this.label11.Text = "P. Proveedor";
            // 
            // nudProveedor
            // 
            this.nudProveedor.DecimalPlaces = 2;
            this.nudProveedor.Location = new System.Drawing.Point(107, 210);
            this.nudProveedor.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudProveedor.Name = "nudProveedor";
            this.nudProveedor.Size = new System.Drawing.Size(94, 23);
            this.nudProveedor.TabIndex = 6;
            this.nudProveedor.Enter += new System.EventHandler(this.nudProveedor_Enter);
            this.nudProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudProveedor_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(231, 214);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 15);
            this.label12.TabIndex = 20;
            this.label12.Text = "Descuento";
            // 
            // nudDescuento
            // 
            this.nudDescuento.DecimalPlaces = 2;
            this.nudDescuento.Location = new System.Drawing.Point(300, 210);
            this.nudDescuento.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudDescuento.Name = "nudDescuento";
            this.nudDescuento.Size = new System.Drawing.Size(94, 23);
            this.nudDescuento.TabIndex = 7;
            this.nudDescuento.Enter += new System.EventHandler(this.nudDescuento_Enter);
            this.nudDescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudDescuento_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(231, 253);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 15);
            this.label13.TabIndex = 22;
            this.label13.Text = "Ganancia";
            // 
            // nudGanancia
            // 
            this.nudGanancia.DecimalPlaces = 2;
            this.nudGanancia.Location = new System.Drawing.Point(300, 249);
            this.nudGanancia.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudGanancia.Name = "nudGanancia";
            this.nudGanancia.Size = new System.Drawing.Size(94, 23);
            this.nudGanancia.TabIndex = 8;
            this.nudGanancia.Enter += new System.EventHandler(this.nudGanancia_Enter);
            this.nudGanancia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudGanancia_KeyPress);
            // 
            // frmAltaModifProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(444, 448);
            this.Controls.Add(this.nudGanancia);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.nudDescuento);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.nudProveedor);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnCalcularPrecio);
            this.Controls.Add(this.nudMinima);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.nudStock);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.nudLista);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboProveedor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodProveedor);
            this.Controls.Add(this.nudCosto);
            this.Controls.Add(this.cboRubro);
            this.Controls.Add(this.txtCodBarras);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAltaModifProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta - Modificacion de Productos";
            this.Load += new System.EventHandler(this.frmAltaModifProductos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAltaModifProductos_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmAltaModifProductos_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.nudCosto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinima)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGanancia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodBarras;
        private System.Windows.Forms.ComboBox cboRubro;
        private System.Windows.Forms.NumericUpDown nudCosto;
        private System.Windows.Forms.TextBox txtCodProveedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboProveedor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudLista;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudStock;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudMinima;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnCalcularPrecio;
        private System.Windows.Forms.NumericUpDown nudGanancia;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown nudDescuento;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nudProveedor;
        private System.Windows.Forms.Label label11;
    }
}