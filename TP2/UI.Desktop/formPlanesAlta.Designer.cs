namespace UI.Desktop
{
    partial class formPlanesAlta
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
            this.lbDescrip = new System.Windows.Forms.Label();
            this.tbDescrip = new System.Windows.Forms.TextBox();
            this.cbEspecialidad = new System.Windows.Forms.ComboBox();
            this.especialidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.especialidadesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.academicaDS = new UI.Desktop.AcademicaDS();
            this.lbEspecialidad = new System.Windows.Forms.Label();
            this.btAceptar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.especialidadesTableAdapter1 = new UI.Desktop.AcademicaDSTableAdapters.especialidadesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.especialidadesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.especialidadesBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicaDS)).BeginInit();
            this.SuspendLayout();
            // 
            // lbDescrip
            // 
            this.lbDescrip.AutoSize = true;
            this.lbDescrip.Location = new System.Drawing.Point(23, 39);
            this.lbDescrip.Name = "lbDescrip";
            this.lbDescrip.Size = new System.Drawing.Size(63, 13);
            this.lbDescrip.TabIndex = 0;
            this.lbDescrip.Text = "Descripcion";
            // 
            // tbDescrip
            // 
            this.tbDescrip.Location = new System.Drawing.Point(105, 39);
            this.tbDescrip.Name = "tbDescrip";
            this.tbDescrip.Size = new System.Drawing.Size(353, 20);
            this.tbDescrip.TabIndex = 1;
            // 
            // cbEspecialidad
            // 
            this.cbEspecialidad.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.especialidadesBindingSource, "id_especialidad", true));
            this.cbEspecialidad.DataSource = this.especialidadesBindingSource1;
            this.cbEspecialidad.DisplayMember = "desc_especialidad";
            this.cbEspecialidad.FormattingEnabled = true;
            this.cbEspecialidad.Location = new System.Drawing.Point(105, 90);
            this.cbEspecialidad.Name = "cbEspecialidad";
            this.cbEspecialidad.Size = new System.Drawing.Size(353, 21);
            this.cbEspecialidad.TabIndex = 2;
            this.cbEspecialidad.ValueMember = "id_especialidad";
            // 
            // especialidadesBindingSource
            // 
            this.especialidadesBindingSource.DataMember = "especialidades";
            // 
            // especialidadesBindingSource1
            // 
            this.especialidadesBindingSource1.DataMember = "especialidades";
            this.especialidadesBindingSource1.DataSource = this.academicaDS;
            // 
            // academicaDS
            // 
            this.academicaDS.DataSetName = "AcademicaDS";
            this.academicaDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lbEspecialidad
            // 
            this.lbEspecialidad.AutoSize = true;
            this.lbEspecialidad.Location = new System.Drawing.Point(19, 93);
            this.lbEspecialidad.Name = "lbEspecialidad";
            this.lbEspecialidad.Size = new System.Drawing.Size(67, 13);
            this.lbEspecialidad.TabIndex = 3;
            this.lbEspecialidad.Text = "Especialidad";
            // 
            // btAceptar
            // 
            this.btAceptar.Location = new System.Drawing.Point(302, 134);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 4;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(383, 134);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 5;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // especialidadesTableAdapter1
            // 
            this.especialidadesTableAdapter1.ClearBeforeFill = true;
            // 
            // formPlanesAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 178);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.lbEspecialidad);
            this.Controls.Add(this.cbEspecialidad);
            this.Controls.Add(this.tbDescrip);
            this.Controls.Add(this.lbDescrip);
            this.Name = "formPlanesAlta";
            this.Text = "Alta de plan";
            this.Load += new System.EventHandler(this.formPlanes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.especialidadesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.especialidadesBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicaDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbDescrip;
        private System.Windows.Forms.TextBox tbDescrip;
        private System.Windows.Forms.ComboBox cbEspecialidad;
        private System.Windows.Forms.Label lbEspecialidad;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.BindingSource especialidadesBindingSource;
        private AcademicaDS academicaDS;
        private System.Windows.Forms.BindingSource especialidadesBindingSource1;
        private AcademicaDSTableAdapters.especialidadesTableAdapter especialidadesTableAdapter1;
    }
}