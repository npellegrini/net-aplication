namespace UI.Desktop
{
    partial class formCursosAlta
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
            this.materiasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.academicaDS = new UI.Desktop.AcademicaDS();
            this.comisionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comisionesTableAdapter = new UI.Desktop.AcademicaDSTableAdapters.comisionesTableAdapter();
            this.materiasTableAdapter = new UI.Desktop.AcademicaDSTableAdapters.materiasTableAdapter();
            this.nupCupo = new System.Windows.Forms.NumericUpDown();
            this.lblCupo = new System.Windows.Forms.Label();
            this.cmbMateria = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cmbComision = new System.Windows.Forms.ComboBox();
            this.lblMateria = new System.Windows.Forms.Label();
            this.lblComision = new System.Windows.Forms.Label();
            this.planesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.planesTableAdapter = new UI.Desktop.AcademicaDSTableAdapters.planesTableAdapter();
            this.nupAnio = new System.Windows.Forms.NumericUpDown();
            this.lblAnio = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblDocentes = new System.Windows.Forms.Label();
            this.btnAgregarDocente = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.materiasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicaDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comisionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupCupo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupAnio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // materiasBindingSource
            // 
            this.materiasBindingSource.DataMember = "materias";
            this.materiasBindingSource.DataSource = this.academicaDS;
            // 
            // academicaDS
            // 
            this.academicaDS.DataSetName = "AcademicaDS";
            this.academicaDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comisionesBindingSource
            // 
            this.comisionesBindingSource.DataMember = "comisiones";
            this.comisionesBindingSource.DataSource = this.academicaDS;
            // 
            // comisionesTableAdapter
            // 
            this.comisionesTableAdapter.ClearBeforeFill = true;
            // 
            // materiasTableAdapter
            // 
            this.materiasTableAdapter.ClearBeforeFill = true;
            // 
            // nupCupo
            // 
            this.nupCupo.Location = new System.Drawing.Point(311, 51);
            this.nupCupo.Name = "nupCupo";
            this.nupCupo.Size = new System.Drawing.Size(84, 20);
            this.nupCupo.TabIndex = 37;
            // 
            // lblCupo
            // 
            this.lblCupo.AutoSize = true;
            this.lblCupo.Location = new System.Drawing.Point(270, 53);
            this.lblCupo.Name = "lblCupo";
            this.lblCupo.Size = new System.Drawing.Size(35, 13);
            this.lblCupo.TabIndex = 36;
            this.lblCupo.Text = "Cupo:";
            // 
            // cmbMateria
            // 
            this.cmbMateria.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.comisionesBindingSource, "id_comision", true));
            this.cmbMateria.DataSource = this.materiasBindingSource;
            this.cmbMateria.DisplayMember = "desc_materia";
            this.cmbMateria.FormattingEnabled = true;
            this.cmbMateria.Location = new System.Drawing.Point(61, 12);
            this.cmbMateria.Name = "cmbMateria";
            this.cmbMateria.Size = new System.Drawing.Size(334, 21);
            this.cmbMateria.TabIndex = 35;
            this.cmbMateria.ValueMember = "id_materia";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(239, 271);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 33;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(320, 271);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 32;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // cmbComision
            // 
            this.cmbComision.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.comisionesBindingSource, "id_comision", true));
            this.cmbComision.DataSource = this.comisionesBindingSource;
            this.cmbComision.DisplayMember = "desc_comision";
            this.cmbComision.FormattingEnabled = true;
            this.cmbComision.Location = new System.Drawing.Point(61, 50);
            this.cmbComision.Name = "cmbComision";
            this.cmbComision.Size = new System.Drawing.Size(80, 21);
            this.cmbComision.TabIndex = 31;
            this.cmbComision.ValueMember = "id_comision";
            // 
            // lblMateria
            // 
            this.lblMateria.AutoSize = true;
            this.lblMateria.Location = new System.Drawing.Point(10, 15);
            this.lblMateria.Name = "lblMateria";
            this.lblMateria.Size = new System.Drawing.Size(45, 13);
            this.lblMateria.TabIndex = 30;
            this.lblMateria.Text = "Materia:";
            // 
            // lblComision
            // 
            this.lblComision.AutoSize = true;
            this.lblComision.Location = new System.Drawing.Point(3, 53);
            this.lblComision.Name = "lblComision";
            this.lblComision.Size = new System.Drawing.Size(52, 13);
            this.lblComision.TabIndex = 29;
            this.lblComision.Text = "Comision:";
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
            // nupAnio
            // 
            this.nupAnio.Location = new System.Drawing.Point(182, 51);
            this.nupAnio.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nupAnio.Minimum = new decimal(new int[] {
            1970,
            0,
            0,
            0});
            this.nupAnio.Name = "nupAnio";
            this.nupAnio.Size = new System.Drawing.Size(82, 20);
            this.nupAnio.TabIndex = 39;
            this.nupAnio.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Location = new System.Drawing.Point(147, 53);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(29, 13);
            this.lblAnio.TabIndex = 38;
            this.lblAnio.Text = "Año:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(61, 92);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(334, 140);
            this.dataGridView1.TabIndex = 40;
            // 
            // lblDocentes
            // 
            this.lblDocentes.AutoSize = true;
            this.lblDocentes.Location = new System.Drawing.Point(3, 92);
            this.lblDocentes.Name = "lblDocentes";
            this.lblDocentes.Size = new System.Drawing.Size(56, 13);
            this.lblDocentes.TabIndex = 41;
            this.lblDocentes.Text = "Docentes:";
            // 
            // btnAgregarDocente
            // 
            this.btnAgregarDocente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarDocente.Location = new System.Drawing.Point(61, 238);
            this.btnAgregarDocente.Name = "btnAgregarDocente";
            this.btnAgregarDocente.Size = new System.Drawing.Size(156, 23);
            this.btnAgregarDocente.TabIndex = 42;
            this.btnAgregarDocente.Text = "Agregar docente";
            this.btnAgregarDocente.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(239, 238);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 23);
            this.button1.TabIndex = 43;
            this.button1.Text = "Eliminar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // formCursosAlta
            // 
            this.ClientSize = new System.Drawing.Size(407, 300);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAgregarDocente);
            this.Controls.Add(this.lblDocentes);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.nupAnio);
            this.Controls.Add(this.lblAnio);
            this.Controls.Add(this.nupCupo);
            this.Controls.Add(this.lblCupo);
            this.Controls.Add(this.cmbMateria);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.cmbComision);
            this.Controls.Add(this.lblMateria);
            this.Controls.Add(this.lblComision);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(423, 157);
            this.Name = "formCursosAlta";
            this.Text = "Alta de curso";
            this.Load += new System.EventHandler(this.formCursosAlta_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.materiasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicaDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comisionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupCupo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupAnio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private AcademicaDS academicaDS;
        private System.Windows.Forms.BindingSource comisionesBindingSource;
        private AcademicaDSTableAdapters.comisionesTableAdapter comisionesTableAdapter;
        private System.Windows.Forms.BindingSource materiasBindingSource;
        private AcademicaDSTableAdapters.materiasTableAdapter materiasTableAdapter;
        private System.Windows.Forms.NumericUpDown nupCupo;
        private System.Windows.Forms.Label lblCupo;
        private System.Windows.Forms.ComboBox cmbMateria;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cmbComision;
        private System.Windows.Forms.Label lblMateria;
        private System.Windows.Forms.Label lblComision;
        private System.Windows.Forms.BindingSource planesBindingSource;
        private AcademicaDSTableAdapters.planesTableAdapter planesTableAdapter;
        private System.Windows.Forms.NumericUpDown nupAnio;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblDocentes;
        private System.Windows.Forms.Button btnAgregarDocente;
        private System.Windows.Forms.Button button1;
    }
}