namespace UI.Desktop
{
    partial class formCursosModificacion
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
            this.comisionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.academicaDS = new UI.Desktop.AcademicaDS();
            this.materiasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.materiasTableAdapter = new UI.Desktop.AcademicaDSTableAdapters.materiasTableAdapter();
            this.comisionesTableAdapter = new UI.Desktop.AcademicaDSTableAdapters.comisionesTableAdapter();
            this.academicaDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.planesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.planesTableAdapter = new UI.Desktop.AcademicaDSTableAdapters.planesTableAdapter();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.nupCupo = new System.Windows.Forms.NumericUpDown();
            this.lblCupo = new System.Windows.Forms.Label();
            this.planesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.especialidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.especialidadesTableAdapter = new UI.Desktop.AcademicaDSTableAdapters.especialidadesTableAdapter();
            this.lblPlan = new System.Windows.Forms.Label();
            this.cmbPlan = new System.Windows.Forms.ComboBox();
            this.cmbMateria = new System.Windows.Forms.ComboBox();
            this.lblMateria = new System.Windows.Forms.Label();
            this.cmbComision = new System.Windows.Forms.ComboBox();
            this.lblComision = new System.Windows.Forms.Label();
            this.nupAnio = new System.Windows.Forms.NumericUpDown();
            this.lblAnio = new System.Windows.Forms.Label();
            this.cmbEspecialidad = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.comisionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicaDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materiasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicaDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupCupo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planesBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.especialidadesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupAnio)).BeginInit();
            this.SuspendLayout();
            // 
            // comisionesBindingSource
            // 
            this.comisionesBindingSource.DataMember = "comisiones";
            this.comisionesBindingSource.DataSource = this.academicaDS;
            // 
            // academicaDS
            // 
            this.academicaDS.DataSetName = "AcademicaDS";
            this.academicaDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // materiasBindingSource
            // 
            this.materiasBindingSource.DataMember = "materias";
            this.materiasBindingSource.DataSource = this.academicaDS;
            // 
            // materiasTableAdapter
            // 
            this.materiasTableAdapter.ClearBeforeFill = true;
            // 
            // comisionesTableAdapter
            // 
            this.comisionesTableAdapter.ClearBeforeFill = true;
            // 
            // academicaDSBindingSource
            // 
            this.academicaDSBindingSource.DataSource = this.academicaDS;
            this.academicaDSBindingSource.Position = 0;
            // 
            // planesBindingSource
            // 
            this.planesBindingSource.DataMember = "planes";
            this.planesBindingSource.DataSource = this.academicaDS;
            // 
            // planesTableAdapter
            // 
            this.planesTableAdapter.ClearBeforeFill = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(340, 146);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(127, 28);
            this.btnGuardar.TabIndex = 21;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(475, 146);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(127, 28);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // nupCupo
            // 
            this.nupCupo.Location = new System.Drawing.Point(503, 105);
            this.nupCupo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nupCupo.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nupCupo.Name = "nupCupo";
            this.nupCupo.Size = new System.Drawing.Size(100, 22);
            this.nupCupo.TabIndex = 27;
            // 
            // lblCupo
            // 
            this.lblCupo.AutoSize = true;
            this.lblCupo.Location = new System.Drawing.Point(448, 110);
            this.lblCupo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCupo.Name = "lblCupo";
            this.lblCupo.Size = new System.Drawing.Size(45, 17);
            this.lblCupo.TabIndex = 26;
            this.lblCupo.Text = "Cupo:";
            // 
            // planesBindingSource1
            // 
            this.planesBindingSource1.DataMember = "planes";
            this.planesBindingSource1.DataSource = this.academicaDS;
            // 
            // especialidadesBindingSource
            // 
            this.especialidadesBindingSource.DataMember = "especialidades";
            this.especialidadesBindingSource.DataSource = this.academicaDS;
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Location = new System.Drawing.Point(17, 18);
            this.lblEspecialidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(92, 17);
            this.lblEspecialidad.TabIndex = 50;
            this.lblEspecialidad.Text = "Especialidad:";
            // 
            // especialidadesTableAdapter
            // 
            this.especialidadesTableAdapter.ClearBeforeFill = true;
            // 
            // lblPlan
            // 
            this.lblPlan.AutoSize = true;
            this.lblPlan.Location = new System.Drawing.Point(347, 18);
            this.lblPlan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(40, 17);
            this.lblPlan.TabIndex = 48;
            this.lblPlan.Text = "Plan:";
            // 
            // cmbPlan
            // 
            this.cmbPlan.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.planesBindingSource1, "id_plan", true));
            this.cmbPlan.DataSource = this.planesBindingSource1;
            this.cmbPlan.DisplayMember = "desc_plan";
            this.cmbPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlan.FormattingEnabled = true;
            this.cmbPlan.Location = new System.Drawing.Point(396, 15);
            this.cmbPlan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbPlan.Name = "cmbPlan";
            this.cmbPlan.Size = new System.Drawing.Size(205, 24);
            this.cmbPlan.TabIndex = 49;
            this.cmbPlan.ValueMember = "id_plan";
            this.cmbPlan.SelectedIndexChanged += new System.EventHandler(this.cmbPlan_SelectedIndexChanged);
            this.cmbPlan.SelectedValueChanged += new System.EventHandler(this.cmbPlanes_SelectedValueChanged);
            // 
            // cmbMateria
            // 
            this.cmbMateria.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.comisionesBindingSource, "id_comision", true));
            this.cmbMateria.DataSource = this.materiasBindingSource;
            this.cmbMateria.DisplayMember = "desc_materia";
            this.cmbMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMateria.FormattingEnabled = true;
            this.cmbMateria.Location = new System.Drawing.Point(119, 60);
            this.cmbMateria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbMateria.Name = "cmbMateria";
            this.cmbMateria.Size = new System.Drawing.Size(483, 24);
            this.cmbMateria.TabIndex = 53;
            this.cmbMateria.ValueMember = "id_materia";
            // 
            // lblMateria
            // 
            this.lblMateria.AutoSize = true;
            this.lblMateria.Location = new System.Drawing.Point(51, 64);
            this.lblMateria.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMateria.Name = "lblMateria";
            this.lblMateria.Size = new System.Drawing.Size(59, 17);
            this.lblMateria.TabIndex = 52;
            this.lblMateria.Text = "Materia:";
            // 
            // cmbComision
            // 
            this.cmbComision.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.comisionesBindingSource, "id_comision", true));
            this.cmbComision.DataSource = this.comisionesBindingSource;
            this.cmbComision.DisplayMember = "desc_comision";
            this.cmbComision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComision.FormattingEnabled = true;
            this.cmbComision.Location = new System.Drawing.Point(119, 105);
            this.cmbComision.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbComision.Name = "cmbComision";
            this.cmbComision.Size = new System.Drawing.Size(136, 24);
            this.cmbComision.TabIndex = 55;
            this.cmbComision.ValueMember = "id_comision";
            // 
            // lblComision
            // 
            this.lblComision.AutoSize = true;
            this.lblComision.Location = new System.Drawing.Point(41, 111);
            this.lblComision.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComision.Name = "lblComision";
            this.lblComision.Size = new System.Drawing.Size(69, 17);
            this.lblComision.TabIndex = 54;
            this.lblComision.Text = "Comision:";
            // 
            // nupAnio
            // 
            this.nupAnio.Location = new System.Drawing.Point(331, 105);
            this.nupAnio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nupAnio.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.nupAnio.Name = "nupAnio";
            this.nupAnio.Size = new System.Drawing.Size(91, 22);
            this.nupAnio.TabIndex = 57;
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Location = new System.Drawing.Point(284, 110);
            this.lblAnio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(37, 17);
            this.lblAnio.TabIndex = 56;
            this.lblAnio.Text = "Año:";
            // 
            // cmbEspecialidad
            // 
            this.cmbEspecialidad.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.especialidadesBindingSource, "id_especialidad", true));
            this.cmbEspecialidad.DataSource = this.especialidadesBindingSource;
            this.cmbEspecialidad.DisplayMember = "desc_especialidad";
            this.cmbEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialidad.FormattingEnabled = true;
            this.cmbEspecialidad.Location = new System.Drawing.Point(119, 15);
            this.cmbEspecialidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbEspecialidad.Name = "cmbEspecialidad";
            this.cmbEspecialidad.Size = new System.Drawing.Size(207, 24);
            this.cmbEspecialidad.TabIndex = 51;
            this.cmbEspecialidad.ValueMember = "id_especialidad";
            this.cmbEspecialidad.SelectedValueChanged += new System.EventHandler(this.cmbEspecialidad_SelectedValueChanged);
            // 
            // formCursosModificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 180);
            this.Controls.Add(this.nupAnio);
            this.Controls.Add(this.lblAnio);
            this.Controls.Add(this.cmbComision);
            this.Controls.Add(this.lblComision);
            this.Controls.Add(this.cmbMateria);
            this.Controls.Add(this.lblMateria);
            this.Controls.Add(this.cmbEspecialidad);
            this.Controls.Add(this.lblEspecialidad);
            this.Controls.Add(this.cmbPlan);
            this.Controls.Add(this.lblPlan);
            this.Controls.Add(this.nupCupo);
            this.Controls.Add(this.lblCupo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(633, 227);
            this.MinimumSize = new System.Drawing.Size(633, 227);
            this.Name = "formCursosModificacion";
            this.Text = "Modificación de curso";
            this.Load += new System.EventHandler(this.formCursosModificacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.comisionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicaDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materiasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicaDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupCupo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planesBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.especialidadesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupAnio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private AcademicaDS academicaDS;
        private System.Windows.Forms.BindingSource materiasBindingSource;
        private AcademicaDSTableAdapters.materiasTableAdapter materiasTableAdapter;
        private System.Windows.Forms.BindingSource comisionesBindingSource;
        private AcademicaDSTableAdapters.comisionesTableAdapter comisionesTableAdapter;
        private System.Windows.Forms.BindingSource academicaDSBindingSource;
        private System.Windows.Forms.BindingSource planesBindingSource;
        private AcademicaDSTableAdapters.planesTableAdapter planesTableAdapter;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.NumericUpDown nupCupo;
        private System.Windows.Forms.Label lblCupo;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.BindingSource especialidadesBindingSource;
        private AcademicaDSTableAdapters.especialidadesTableAdapter especialidadesTableAdapter;
        private System.Windows.Forms.BindingSource planesBindingSource1;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.ComboBox cmbPlan;
        private System.Windows.Forms.ComboBox cmbMateria;
        private System.Windows.Forms.Label lblMateria;
        private System.Windows.Forms.ComboBox cmbComision;
        private System.Windows.Forms.Label lblComision;
        private System.Windows.Forms.NumericUpDown nupAnio;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.ComboBox cmbEspecialidad;
    }
}