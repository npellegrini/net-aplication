namespace UI.Desktop
{
    partial class formInscripcion
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tlInscripciones = new System.Windows.Forms.TableLayoutPanel();
            this.dgvInscripciones = new System.Windows.Forms.DataGridView();
            this.dgvColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColMateria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColComision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColCondicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.academicaDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.academicaDS = new UI.Desktop.AcademicaDS();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnValidar = new System.Windows.Forms.Button();
            this.tsInscripciones = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.alumnosinscripcionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.alumnos_inscripcionesTableAdapter = new UI.Desktop.AcademicaDSTableAdapters.alumnos_inscripcionesTableAdapter();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tlInscripciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscripciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicaDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicaDS)).BeginInit();
            this.tsInscripciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alumnosinscripcionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tlInscripciones);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(516, 241);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(516, 266);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tsInscripciones);
            // 
            // tlInscripciones
            // 
            this.tlInscripciones.ColumnCount = 4;
            this.tlInscripciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlInscripciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlInscripciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlInscripciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlInscripciones.Controls.Add(this.dgvInscripciones, 0, 1);
            this.tlInscripciones.Controls.Add(this.lblUsuario, 0, 0);
            this.tlInscripciones.Controls.Add(this.txtUsuario, 1, 0);
            this.tlInscripciones.Controls.Add(this.btnSalir, 3, 2);
            this.tlInscripciones.Controls.Add(this.btnActualizar, 2, 2);
            this.tlInscripciones.Controls.Add(this.btnValidar, 3, 0);
            this.tlInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlInscripciones.Location = new System.Drawing.Point(0, 0);
            this.tlInscripciones.Name = "tlInscripciones";
            this.tlInscripciones.RowCount = 3;
            this.tlInscripciones.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlInscripciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlInscripciones.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlInscripciones.Size = new System.Drawing.Size(516, 241);
            this.tlInscripciones.TabIndex = 0;
            // 
            // dgvInscripciones
            // 
            this.dgvInscripciones.AllowUserToAddRows = false;
            this.dgvInscripciones.AllowUserToDeleteRows = false;
            this.dgvInscripciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInscripciones.AutoGenerateColumns = false;
            this.dgvInscripciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInscripciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvColID,
            this.dgvColMateria,
            this.dgvColComision,
            this.dgvColCondicion,
            this.dgvColNota});
            this.tlInscripciones.SetColumnSpan(this.dgvInscripciones, 4);
            this.dgvInscripciones.DataSource = this.academicaDSBindingSource;
            this.dgvInscripciones.Enabled = false;
            this.dgvInscripciones.Location = new System.Drawing.Point(3, 32);
            this.dgvInscripciones.MultiSelect = false;
            this.dgvInscripciones.Name = "dgvInscripciones";
            this.dgvInscripciones.ReadOnly = true;
            this.dgvInscripciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInscripciones.Size = new System.Drawing.Size(510, 177);
            this.dgvInscripciones.TabIndex = 3;
            // 
            // dgvColID
            // 
            this.dgvColID.DataPropertyName = "id_inscripcion";
            this.dgvColID.HeaderText = "ID";
            this.dgvColID.Name = "dgvColID";
            this.dgvColID.ReadOnly = true;
            // 
            // dgvColMateria
            // 
            this.dgvColMateria.DataPropertyName = "desc_materia";
            this.dgvColMateria.HeaderText = "Materia";
            this.dgvColMateria.Name = "dgvColMateria";
            this.dgvColMateria.ReadOnly = true;
            // 
            // dgvColComision
            // 
            this.dgvColComision.DataPropertyName = "desc_comision";
            this.dgvColComision.HeaderText = "Comision";
            this.dgvColComision.Name = "dgvColComision";
            this.dgvColComision.ReadOnly = true;
            // 
            // dgvColCondicion
            // 
            this.dgvColCondicion.DataPropertyName = "condicion";
            this.dgvColCondicion.HeaderText = "Condicion";
            this.dgvColCondicion.Name = "dgvColCondicion";
            this.dgvColCondicion.ReadOnly = true;
            // 
            // dgvColNota
            // 
            this.dgvColNota.DataPropertyName = "nota";
            this.dgvColNota.HeaderText = "Nota";
            this.dgvColNota.Name = "dgvColNota";
            this.dgvColNota.ReadOnly = true;
            // 
            // academicaDSBindingSource
            // 
            this.academicaDSBindingSource.DataSource = this.academicaDS;
            this.academicaDSBindingSource.Position = 0;
            // 
            // academicaDS
            // 
            this.academicaDS.DataSetName = "AcademicaDS";
            this.academicaDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(173, 8);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.TabIndex = 5;
            this.lblUsuario.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tlInscripciones.SetColumnSpan(this.txtUsuario, 2);
            this.txtUsuario.Location = new System.Drawing.Point(225, 4);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(200, 20);
            this.txtUsuario.TabIndex = 4;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Location = new System.Drawing.Point(431, 215);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(82, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click_1);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Enabled = false;
            this.btnActualizar.Location = new System.Drawing.Point(343, 215);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(82, 23);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnValidar
            // 
            this.btnValidar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnValidar.Location = new System.Drawing.Point(431, 3);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(82, 23);
            this.btnValidar.TabIndex = 6;
            this.btnValidar.Text = "Validar";
            this.btnValidar.UseVisualStyleBackColor = true;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // tsInscripciones
            // 
            this.tsInscripciones.Dock = System.Windows.Forms.DockStyle.None;
            this.tsInscripciones.Enabled = false;
            this.tsInscripciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEliminar});
            this.tsInscripciones.Location = new System.Drawing.Point(3, 0);
            this.tsInscripciones.Name = "tsInscripciones";
            this.tsInscripciones.Size = new System.Drawing.Size(58, 25);
            this.tsInscripciones.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.Image = global::UI.Desktop.Properties.Resources.user_male_2_add;
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(23, 22);
            this.tsbNuevo.Text = "Nuevo";
            this.tsbNuevo.ToolTipText = "Nuevo";
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEliminar.Image = global::UI.Desktop.Properties.Resources.user_male_delete;
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(23, 22);
            this.tsbEliminar.Text = "toolStripButton1";
            this.tsbEliminar.ToolTipText = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // alumnosinscripcionesBindingSource
            // 
            this.alumnosinscripcionesBindingSource.DataMember = "alumnos_inscripciones";
            this.alumnosinscripcionesBindingSource.DataSource = this.academicaDS;
            // 
            // alumnos_inscripcionesTableAdapter
            // 
            this.alumnos_inscripcionesTableAdapter.ClearBeforeFill = true;
            // 
            // formInscripcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 266);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "formInscripcion";
            this.Text = "Inscripciones";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formInscripcion_FormClosed);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tlInscripciones.ResumeLayout(false);
            this.tlInscripciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscripciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicaDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicaDS)).EndInit();
            this.tsInscripciones.ResumeLayout(false);
            this.tsInscripciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alumnosinscripcionesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.TableLayoutPanel tlInscripciones;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.ToolStrip tsInscripciones;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idinscripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcursoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn condicionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notaDataGridViewTextBoxColumn;
        private AcademicaDS academicaDS;
        private AcademicaDSTableAdapters.alumnos_inscripcionesTableAdapter alumnos_inscripcionesTableAdapter;
        private System.Windows.Forms.BindingSource alumnosinscripcionesBindingSource;
        private System.Windows.Forms.BindingSource academicaDSBindingSource;
        private System.Windows.Forms.DataGridView dgvInscripciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColMateria;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColComision;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColCondicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColNota;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Button btnValidar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
    }
}