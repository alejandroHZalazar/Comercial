namespace Comercial.Formularios.Productos
{
    partial class frmAltaMasiva
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAltaMasiva));
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHoja = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLevantar = new System.Windows.Forms.Button();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.pbProceso = new System.Windows.Forms.ProgressBar();
            this.backgroundWorkerTarea = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtArchivo
            // 
            this.txtArchivo.Location = new System.Drawing.Point(12, 25);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.Size = new System.Drawing.Size(326, 23);
            this.txtArchivo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Archivo";
            // 
            // txtHoja
            // 
            this.txtHoja.Location = new System.Drawing.Point(353, 25);
            this.txtHoja.Name = "txtHoja";
            this.txtHoja.Size = new System.Drawing.Size(147, 23);
            this.txtHoja.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(353, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hoja";
            // 
            // btnLevantar
            // 
            this.btnLevantar.BackColor = System.Drawing.Color.Silver;
            this.btnLevantar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLevantar.Image = global::Comercial.Properties.Resources.icon1;
            this.btnLevantar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLevantar.Location = new System.Drawing.Point(518, 19);
            this.btnLevantar.Name = "btnLevantar";
            this.btnLevantar.Size = new System.Drawing.Size(150, 32);
            this.btnLevantar.TabIndex = 8;
            this.btnLevantar.Text = "   Levantar Excel";
            this.btnLevantar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLevantar.UseVisualStyleBackColor = false;
            this.btnLevantar.Click += new System.EventHandler(this.btnLevantar_Click);
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(12, 63);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.Size = new System.Drawing.Size(656, 337);
            this.dgvProductos.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Comercial.Properties.Resources.icon1;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(518, 406);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 32);
            this.button1.TabIndex = 10;
            this.button1.Text = "Cargar Productos";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pbProceso
            // 
            this.pbProceso.Location = new System.Drawing.Point(12, 407);
            this.pbProceso.Name = "pbProceso";
            this.pbProceso.Size = new System.Drawing.Size(488, 23);
            this.pbProceso.TabIndex = 11;
            // 
            // backgroundWorkerTarea
            // 
            this.backgroundWorkerTarea.WorkerReportsProgress = true;
            this.backgroundWorkerTarea.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerTarea_DoWork);
            this.backgroundWorkerTarea.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerTarea_ProgressChanged);
            this.backgroundWorkerTarea.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerTarea_RunWorkerCompleted);
            // 
            // frmAltaMasiva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(681, 442);
            this.Controls.Add(this.pbProceso);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.btnLevantar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHoja);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtArchivo);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAltaMasiva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta Masivo Productos";
            this.Load += new System.EventHandler(this.frmAltaMasiva_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHoja;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLevantar;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar pbProceso;
        private System.ComponentModel.BackgroundWorker backgroundWorkerTarea;
    }
}