namespace UI.Desktop
{
    partial class formInscripcionAlta
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
            this.lblMateria = new System.Windows.Forms.Label();
            this.cmbMateria = new System.Windows.Forms.ComboBox();
            this.materiasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.academicaDSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.academicaDS = new UI.Desktop.AcademicaDS();
            this.cursomateriascomisionesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.academicaDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.materiasTableAdapter = new UI.Desktop.AcademicaDSTableAdapters.materiasTableAdapter();
            this.cursosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cursosTableAdapter = new UI.Desktop.AcademicaDSTableAdapters.cursosTableAdapter();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnInscribirse = new System.Windows.Forms.Button();
            this.cmbComision = new System.Windows.Forms.ComboBox();
            this.comisionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cursomateriascomisionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cursosBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.lblComision = new System.Windows.Forms.Label();
            this.comisionesTableAdapter = new UI.Desktop.AcademicaDSTableAdapters.comisionesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.materiasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicaDSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicaDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cursomateriascomisionesBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicaDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cursosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comisionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cursomateriascomisionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cursosBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMateria
            // 
            this.lblMateria.AutoSize = true;
            this.lblMateria.Location = new System.Drawing.Point(16, 18);
            this.lblMateria.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMateria.Name = "lblMateria";
            this.lblMateria.Size = new System.Drawing.Size(59, 17);
            this.lblMateria.TabIndex = 0;
            this.lblMateria.Text = "Materia:";
            // 
            // cmbMateria
            // 
            this.cmbMateria.DataSource = this.materiasBindingSource;
            this.cmbMateria.DisplayMember = "desc_materia";
            this.cmbMateria.FormattingEnabled = true;
            this.cmbMateria.Location = new System.Drawing.Point(84, 15);
            this.cmbMateria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbMateria.Name = "cmbMateria";
            this.cmbMateria.Size = new System.Drawing.Size(295, 24);
            this.cmbMateria.TabIndex = 2;
            this.cmbMateria.ValueMember = "id_materia";
            this.cmbMateria.SelectedIndexChanged += new System.EventHandler(this.cmbMateria_SelectedIndexChanged);
            //this.cmbMateria.SelectedValueChanged += new System.EventHandler(this.cmbMateria_SelectedValueChanged);
            // 
            // materiasBindingSource
            // 
            this.materiasBindingSource.DataMember = "materias";
            this.materiasBindingSource.DataSource = this.academicaDSBindingSource;
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
            // cursomateriascomisionesBindingSource1
            // 
            this.cursomateriascomisionesBindingSource1.DataMember = "curso_materias_comisiones";
            this.cursomateriascomisionesBindingSource1.DataSource = this.academicaDS;
            // 
            // materiasTableAdapter
            // 
            this.materiasTableAdapter.ClearBeforeFill = true;
            // 
            // cursosBindingSource
            // 
            this.cursosBindingSource.DataMember = "cursos";
            this.cursosBindingSource.DataSource = this.academicaDS;
            // 
            // cursosTableAdapter
            // 
            this.cursosTableAdapter.ClearBeforeFill = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Location = new System.Drawing.Point(292, 106);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 28);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnInscribirse
            // 
            this.btnInscribirse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInscribirse.Location = new System.Drawing.Point(184, 106);
            this.btnInscribirse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnInscribirse.Name = "btnInscribirse";
            this.btnInscribirse.Size = new System.Drawing.Size(100, 28);
            this.btnInscribirse.TabIndex = 7;
            this.btnInscribirse.Text = "Inscribirse";
            this.btnInscribirse.UseVisualStyleBackColor = true;
            this.btnInscribirse.Click += new System.EventHandler(this.btnInscribirse_Click);
            // 
            // cmbComision
            // 
            this.cmbComision.DataSource = this.comisionesBindingSource;
            this.cmbComision.DisplayMember = "desc_comision";
            this.cmbComision.FormattingEnabled = true;
            this.cmbComision.Location = new System.Drawing.Point(84, 63);
            this.cmbComision.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbComision.Name = "cmbComision";
            this.cmbComision.Size = new System.Drawing.Size(147, 24);
            this.cmbComision.TabIndex = 16;
            this.cmbComision.ValueMember = "id_comision";
            // 
            // comisionesBindingSource
            // 
            this.comisionesBindingSource.DataMember = "comisiones";
            this.comisionesBindingSource.DataSource = this.academicaDS;
            // 
            // cursomateriascomisionesBindingSource
            // 
            this.cursomateriascomisionesBindingSource.DataMember = "curso_materias_comisiones";
            this.cursomateriascomisionesBindingSource.DataSource = this.academicaDS;
            // 
            // cursosBindingSource1
            // 
            this.cursosBindingSource1.DataMember = "cursos";
            this.cursosBindingSource1.DataSource = this.academicaDS;
            // 
            // lblComision
            // 
            this.lblComision.AutoSize = true;
            this.lblComision.Location = new System.Drawing.Point(16, 66);
            this.lblComision.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComision.Name = "lblComision";
            this.lblComision.Size = new System.Drawing.Size(69, 17);
            this.lblComision.TabIndex = 15;
            this.lblComision.Text = "Comisión:";
            // 
            // comisionesTableAdapter
            // 
            this.comisionesTableAdapter.ClearBeforeFill = true;
            // 
            // formInscripcionAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 149);
            this.Controls.Add(this.cmbComision);
            this.Controls.Add(this.lblComision);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnInscribirse);
            this.Controls.Add(this.cmbMateria);
            this.Controls.Add(this.lblMateria);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "formInscripcionAlta";
            this.Text = "Alta de inscripción";
            this.Load += new System.EventHandler(this.formInscripcionAlta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.materiasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicaDSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicaDS)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.cursomateriascomisionesBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicaDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cursosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comisionesBindingSource)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.cursomateriascomisionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cursosBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMateria;
        private System.Windows.Forms.ComboBox cmbMateria;
        private System.Windows.Forms.BindingSource academicaDSBindingSource;
        private AcademicaDS academicaDS;
        private System.Windows.Forms.BindingSource academicaDataSetBindingSource;
        private System.Windows.Forms.BindingSource materiasBindingSource;
        private AcademicaDSTableAdapters.materiasTableAdapter materiasTableAdapter;
        private System.Windows.Forms.BindingSource cursosBindingSource;
        private AcademicaDSTableAdapters.cursosTableAdapter cursosTableAdapter;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnInscribirse;
        private System.Windows.Forms.ComboBox cmbComision;
        private System.Windows.Forms.Label lblComision;
        private System.Windows.Forms.BindingSource cursosBindingSource1;
        private System.Windows.Forms.BindingSource cursomateriascomisionesBindingSource;
        private System.Windows.Forms.BindingSource cursomateriascomisionesBindingSource1;
        private System.Windows.Forms.BindingSource comisionesBindingSource;
        private AcademicaDSTableAdapters.comisionesTableAdapter comisionesTableAdapter;
    }
}