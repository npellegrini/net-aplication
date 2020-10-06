namespace UI.Desktop
{
    partial class formUsuarios
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
            this.tlUsuarios = new System.Windows.Forms.TableLayoutPanel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.dgvColHabilitado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColLegajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColTipoUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColNombreUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColPlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColFechaNac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsUsuarios = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.usuariosBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.academicaDS = new UI.Desktop.AcademicaDS();
            this.usuariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usuariosTableAdapter2 = new UI.Desktop.AcademicaDSTableAdapters.usuariosTableAdapter();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tlUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.tsUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicaDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tlUsuarios);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(643, 261);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(643, 286);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tsUsuarios);
            // 
            // tlUsuarios
            // 
            this.tlUsuarios.AutoSize = true;
            this.tlUsuarios.ColumnCount = 2;
            this.tlUsuarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlUsuarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlUsuarios.Controls.Add(this.btnSalir, 1, 1);
            this.tlUsuarios.Controls.Add(this.btnActualizar, 0, 1);
            this.tlUsuarios.Controls.Add(this.dgvUsuarios, 0, 0);
            this.tlUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlUsuarios.Location = new System.Drawing.Point(0, 0);
            this.tlUsuarios.Name = "tlUsuarios";
            this.tlUsuarios.RowCount = 2;
            this.tlUsuarios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlUsuarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlUsuarios.Size = new System.Drawing.Size(643, 261);
            this.tlUsuarios.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(565, 235);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(484, 235);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvColHabilitado,
            this.dgvColID,
            this.dgvColLegajo,
            this.dgvColNombre,
            this.dgvColApellido,
            this.dgvColTipoUsuario,
            this.dgvColNombreUsuario,
            this.dgvColEspecialidad,
            this.dgvColDireccion,
            this.dgvColEmail,
            this.dgvColTelefono,
            this.dgvColPlan,
            this.dgvColFechaNac});
            this.tlUsuarios.SetColumnSpan(this.dgvUsuarios, 2);
            this.dgvUsuarios.Location = new System.Drawing.Point(3, 3);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(637, 226);
            this.dgvUsuarios.TabIndex = 3;
            this.dgvUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellClick);
            // 
            // dgvColHabilitado
            // 
            this.dgvColHabilitado.DataPropertyName = "habilitado";
            this.dgvColHabilitado.HeaderText = "Habilitado";
            this.dgvColHabilitado.Name = "dgvColHabilitado";
            this.dgvColHabilitado.ReadOnly = true;
            // 
            // dgvColID
            // 
            this.dgvColID.DataPropertyName = "id_usuario";
            this.dgvColID.HeaderText = "ID";
            this.dgvColID.Name = "dgvColID";
            this.dgvColID.ReadOnly = true;
            // 
            // dgvColLegajo
            // 
            this.dgvColLegajo.DataPropertyName = "legajo";
            this.dgvColLegajo.HeaderText = "Legajo";
            this.dgvColLegajo.Name = "dgvColLegajo";
            this.dgvColLegajo.ReadOnly = true;
            // 
            // dgvColNombre
            // 
            this.dgvColNombre.DataPropertyName = "nombre";
            this.dgvColNombre.HeaderText = "Nombre";
            this.dgvColNombre.Name = "dgvColNombre";
            this.dgvColNombre.ReadOnly = true;
            // 
            // dgvColApellido
            // 
            this.dgvColApellido.DataPropertyName = "apellido";
            this.dgvColApellido.HeaderText = "Apellido";
            this.dgvColApellido.Name = "dgvColApellido";
            this.dgvColApellido.ReadOnly = true;
            // 
            // dgvColTipoUsuario
            // 
            this.dgvColTipoUsuario.DataPropertyName = "descripcion";
            this.dgvColTipoUsuario.HeaderText = "Tipo usuario";
            this.dgvColTipoUsuario.Name = "dgvColTipoUsuario";
            this.dgvColTipoUsuario.ReadOnly = true;
            // 
            // dgvColNombreUsuario
            // 
            this.dgvColNombreUsuario.DataPropertyName = "nombre_usuario";
            this.dgvColNombreUsuario.HeaderText = "Usuario";
            this.dgvColNombreUsuario.Name = "dgvColNombreUsuario";
            this.dgvColNombreUsuario.ReadOnly = true;
            // 
            // dgvColEspecialidad
            // 
            this.dgvColEspecialidad.DataPropertyName = "desc_especialidad";
            this.dgvColEspecialidad.HeaderText = "Especialidad";
            this.dgvColEspecialidad.Name = "dgvColEspecialidad";
            this.dgvColEspecialidad.ReadOnly = true;
            // 
            // dgvColDireccion
            // 
            this.dgvColDireccion.DataPropertyName = "direccion";
            this.dgvColDireccion.HeaderText = "Direccion";
            this.dgvColDireccion.Name = "dgvColDireccion";
            this.dgvColDireccion.ReadOnly = true;
            // 
            // dgvColEmail
            // 
            this.dgvColEmail.DataPropertyName = "email";
            this.dgvColEmail.HeaderText = "Email";
            this.dgvColEmail.Name = "dgvColEmail";
            this.dgvColEmail.ReadOnly = true;
            // 
            // dgvColTelefono
            // 
            this.dgvColTelefono.DataPropertyName = "telefono";
            this.dgvColTelefono.HeaderText = "Telefono";
            this.dgvColTelefono.Name = "dgvColTelefono";
            this.dgvColTelefono.ReadOnly = true;
            // 
            // dgvColPlan
            // 
            this.dgvColPlan.DataPropertyName = "desc_plan";
            this.dgvColPlan.HeaderText = "Plan";
            this.dgvColPlan.Name = "dgvColPlan";
            this.dgvColPlan.ReadOnly = true;
            // 
            // dgvColFechaNac
            // 
            this.dgvColFechaNac.DataPropertyName = "fecha_nac";
            this.dgvColFechaNac.HeaderText = "Fecha nacimiento";
            this.dgvColFechaNac.Name = "dgvColFechaNac";
            this.dgvColFechaNac.ReadOnly = true;
            // 
            // tsUsuarios
            // 
            this.tsUsuarios.Dock = System.Windows.Forms.DockStyle.None;
            this.tsUsuarios.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tsUsuarios.Location = new System.Drawing.Point(3, 0);
            this.tsUsuarios.Name = "tsUsuarios";
            this.tsUsuarios.Size = new System.Drawing.Size(81, 25);
            this.tsUsuarios.TabIndex = 0;
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
            // tsbEditar
            // 
            this.tsbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditar.Image = global::UI.Desktop.Properties.Resources.user_male_edit;
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(23, 22);
            this.tsbEditar.Text = "toolStripButton1";
            this.tsbEditar.ToolTipText = "Editar";
            this.tsbEditar.Click += new System.EventHandler(this.tsbEditar_Click);
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
            // usuariosBindingSource1
            // 
            this.usuariosBindingSource1.DataMember = "usuarios";
            this.usuariosBindingSource1.DataSource = this.academicaDS;
            // 
            // academicaDS
            // 
            this.academicaDS.DataSetName = "AcademicaDS";
            this.academicaDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usuariosTableAdapter2
            // 
            this.usuariosTableAdapter2.ClearBeforeFill = true;
            // 
            // formUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 286);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "formUsuarios";
            this.Text = "Usuarios";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formUsuarios_FormClosed);
            this.Load += new System.EventHandler(this.formUsuarios_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tlUsuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.tsUsuarios.ResumeLayout(false);
            this.tsUsuarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicaDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.TableLayoutPanel tlUsuarios;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.ToolStrip tsUsuarios;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.BindingSource usuariosBindingSource;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn idusuarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreusuarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cambiaclaveDataGridViewCheckBoxColumn;
        private System.Windows.Forms.Button btnSalir;
        private AcademicaDS academicaDS;
        private System.Windows.Forms.BindingSource usuariosBindingSource1;
        private AcademicaDSTableAdapters.usuariosTableAdapter usuariosTableAdapter2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvColHabilitado;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColLegajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColTipoUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColNombreUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColPlan;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColFechaNac;
    }
}