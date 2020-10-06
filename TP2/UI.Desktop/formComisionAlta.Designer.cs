namespace UI.Desktop
{
    partial class formComisionAlta
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblAnio = new System.Windows.Forms.Label();
            this.nupAnio = new System.Windows.Forms.NumericUpDown();
            this.cmbPlanes = new System.Windows.Forms.ComboBox();
            this.planesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.academicaDS = new UI.Desktop.AcademicaDS();
            this.lblPlan = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.planesTableAdapter = new UI.Desktop.AcademicaDSTableAdapters.planesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.nupAnio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicaDS)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(168, 98);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 26;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(249, 98);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Location = new System.Drawing.Point(178, 55);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(91, 13);
            this.lblAnio.TabIndex = 24;
            this.lblAnio.Text = "Año especialidad:";
            // 
            // nupAnio
            // 
            this.nupAnio.Location = new System.Drawing.Point(275, 53);
            this.nupAnio.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nupAnio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupAnio.Name = "nupAnio";
            this.nupAnio.Size = new System.Drawing.Size(49, 20);
            this.nupAnio.TabIndex = 23;
            this.nupAnio.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbPlanes
            // 
            this.cmbPlanes.DataSource = this.planesBindingSource;
            this.cmbPlanes.DisplayMember = "desc_plan";
            this.cmbPlanes.FormattingEnabled = true;
            this.cmbPlanes.Location = new System.Drawing.Point(84, 52);
            this.cmbPlanes.Name = "cmbPlanes";
            this.cmbPlanes.Size = new System.Drawing.Size(84, 21);
            this.cmbPlanes.TabIndex = 22;
            this.cmbPlanes.ValueMember = "id_plan";
            // 
            // planesBindingSource
            // 
            this.planesBindingSource.DataMember = "planes";
            this.planesBindingSource.DataSource = this.academicaDS;
            // 
            // academicaDS
            // 
            this.academicaDS.DataSetName = "AcademicaDS";
            this.academicaDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblPlan
            // 
            this.lblPlan.AutoSize = true;
            this.lblPlan.Location = new System.Drawing.Point(47, 55);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(31, 13);
            this.lblPlan.TabIndex = 21;
            this.lblPlan.Text = "Plan:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(84, 12);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(240, 20);
            this.txtDescripcion.TabIndex = 20;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(12, 15);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 19;
            this.lblDescripcion.Text = "Descripcion:";
            // 
            // planesTableAdapter
            // 
            this.planesTableAdapter.ClearBeforeFill = true;
            // 
            // formComisionAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 133);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblAnio);
            this.Controls.Add(this.nupAnio);
            this.Controls.Add(this.cmbPlanes);
            this.Controls.Add(this.lblPlan);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(352, 172);
            this.MinimumSize = new System.Drawing.Size(352, 172);
            this.Name = "formComisionAlta";
            this.Text = "Alta de comisión";
            this.Load += new System.EventHandler(this.formComisionAlta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nupAnio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicaDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.NumericUpDown nupAnio;
        private System.Windows.Forms.ComboBox cmbPlanes;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private AcademicaDS academicaDS;
        private System.Windows.Forms.BindingSource planesBindingSource;
        private AcademicaDSTableAdapters.planesTableAdapter planesTableAdapter;
    }
}