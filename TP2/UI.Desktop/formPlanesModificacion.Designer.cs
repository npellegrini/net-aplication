namespace UI.Desktop
{
    partial class formPlanesModificacion
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.blDescripcion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEspecialidades = new System.Windows.Forms.ComboBox();
            this.especialidadesBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.academicaDS = new UI.Desktop.AcademicaDS();
            this.especialidadesTableAdapter2 = new UI.Desktop.AcademicaDSTableAdapters.especialidadesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.especialidadesBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicaDS)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(278, 108);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(359, 108);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(81, 25);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(353, 20);
            this.txtDescripcion.TabIndex = 1;
            // 
            // blDescripcion
            // 
            this.blDescripcion.AutoSize = true;
            this.blDescripcion.Location = new System.Drawing.Point(12, 28);
            this.blDescripcion.Name = "blDescripcion";
            this.blDescripcion.Size = new System.Drawing.Size(63, 13);
            this.blDescripcion.TabIndex = 4;
            this.blDescripcion.Text = "Descripcion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Especialidad";
            // 
            // cmbEspecialidades
            // 
            this.cmbEspecialidades.DataSource = this.especialidadesBindingSource2;
            this.cmbEspecialidades.DisplayMember = "desc_especialidad";
            this.cmbEspecialidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialidades.FormattingEnabled = true;
            this.cmbEspecialidades.Location = new System.Drawing.Point(81, 66);
            this.cmbEspecialidades.Name = "cmbEspecialidades";
            this.cmbEspecialidades.Size = new System.Drawing.Size(353, 21);
            this.cmbEspecialidades.TabIndex = 2;
            this.cmbEspecialidades.ValueMember = "id_especialidad";
            // 
            // especialidadesBindingSource2
            // 
            this.especialidadesBindingSource2.DataMember = "especialidades";
            this.especialidadesBindingSource2.DataSource = this.academicaDS;
            // 
            // academicaDS
            // 
            this.academicaDS.DataSetName = "AcademicaDS";
            this.academicaDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // especialidadesTableAdapter2
            // 
            this.especialidadesTableAdapter2.ClearBeforeFill = true;
            // 
            // formPlanesModificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 143);
            this.Controls.Add(this.cmbEspecialidades);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.blDescripcion);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(469, 182);
            this.MinimumSize = new System.Drawing.Size(469, 182);
            this.Name = "formPlanesModificacion";
            this.Text = "Modificar plan";
            this.Load += new System.EventHandler(this.formPlanesModificacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.especialidadesBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicaDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label blDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEspecialidades;
        private System.Windows.Forms.BindingSource academicaDataSet4BindingSource;
        private AcademicaDS academicaDS;
        private System.Windows.Forms.BindingSource especialidadesBindingSource2;
        private AcademicaDSTableAdapters.especialidadesTableAdapter especialidadesTableAdapter2;
    }
}