namespace Comercial.Formularios.Configuracion
{
    partial class frmAgregarModifTipoUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarModifTipoUsuarios));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.dgvMenuPermisos = new System.Windows.Forms.DataGridView();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtNinguno = new System.Windows.Forms.RadioButton();
            this.rbtTodos = new System.Windows.Forms.RadioButton();
            this.Formulario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Permiso = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuPermisos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(74, 6);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(217, 23);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // dgvMenuPermisos
            // 
            this.dgvMenuPermisos.AllowUserToAddRows = false;
            this.dgvMenuPermisos.AllowUserToDeleteRows = false;
            this.dgvMenuPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMenuPermisos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Formulario,
            this.Permiso,
            this.id});
            this.dgvMenuPermisos.Location = new System.Drawing.Point(12, 45);
            this.dgvMenuPermisos.MultiSelect = false;
            this.dgvMenuPermisos.Name = "dgvMenuPermisos";
            this.dgvMenuPermisos.Size = new System.Drawing.Size(414, 489);
            this.dgvMenuPermisos.TabIndex = 2;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.Color.Silver;
            this.btnGrabar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.Image = global::Comercial.Properties.Resources.save__1_;
            this.btnGrabar.Location = new System.Drawing.Point(314, 542);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(111, 35);
            this.btnGrabar.TabIndex = 5;
            this.btnGrabar.Text = "Grabar [F5]";
            this.btnGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.rbtNinguno);
            this.groupBox1.Controls.Add(this.rbtTodos);
            this.groupBox1.Location = new System.Drawing.Point(12, 540);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 42);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // rbtNinguno
            // 
            this.rbtNinguno.AutoSize = true;
            this.rbtNinguno.Checked = true;
            this.rbtNinguno.Location = new System.Drawing.Point(78, 17);
            this.rbtNinguno.Name = "rbtNinguno";
            this.rbtNinguno.Size = new System.Drawing.Size(72, 19);
            this.rbtNinguno.TabIndex = 8;
            this.rbtNinguno.TabStop = true;
            this.rbtNinguno.Text = "Ninguno";
            this.rbtNinguno.UseVisualStyleBackColor = true;
            this.rbtNinguno.CheckedChanged += new System.EventHandler(this.rbtNinguno_CheckedChanged);
            // 
            // rbtTodos
            // 
            this.rbtTodos.AutoSize = true;
            this.rbtTodos.Location = new System.Drawing.Point(14, 17);
            this.rbtTodos.Name = "rbtTodos";
            this.rbtTodos.Size = new System.Drawing.Size(58, 19);
            this.rbtTodos.TabIndex = 7;
            this.rbtTodos.Text = "Todos";
            this.rbtTodos.UseVisualStyleBackColor = true;
            this.rbtTodos.CheckedChanged += new System.EventHandler(this.rbtTodos_CheckedChanged);
            // 
            // Formulario
            // 
            this.Formulario.HeaderText = "Formulario";
            this.Formulario.Name = "Formulario";
            this.Formulario.ReadOnly = true;
            this.Formulario.Width = 300;
            // 
            // Permiso
            // 
            this.Permiso.HeaderText = "Permiso";
            this.Permiso.Name = "Permiso";
            this.Permiso.Width = 70;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id.Visible = false;
            // 
            // frmAgregarModifTipoUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(437, 589);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.dgvMenuPermisos);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAgregarModifTipoUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar - Modificar Tipo de usuarios y Permisos";
            this.Load += new System.EventHandler(this.frmAgregarModifTipoUsuarios_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAgregarModifTipoUsuarios_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmAgregarModifTipoUsuarios_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenuPermisos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DataGridView dgvMenuPermisos;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtNinguno;
        private System.Windows.Forms.RadioButton rbtTodos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Formulario;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Permiso;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
    }
}