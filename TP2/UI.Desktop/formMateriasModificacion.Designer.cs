namespace UI.Desktop
{
    partial class formMateriasModificacion
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblHsSemanales = new System.Windows.Forms.Label();
            this.nupHsSemanales = new System.Windows.Forms.NumericUpDown();
            this.cmbPlanes = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.cmbEspecialidades = new System.Windows.Forms.ComboBox();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.lblHsTotales = new System.Windows.Forms.Label();
            this.nupHsTotales = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nupHsSemanales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupHsTotales)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(251, 165);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 28);
            this.btnGuardar.TabIndex = 26;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(359, 165);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 28);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblHsSemanales
            // 
            this.lblHsSemanales.AutoSize = true;
            this.lblHsSemanales.Location = new System.Drawing.Point(9, 123);
            this.lblHsSemanales.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHsSemanales.Name = "lblHsSemanales";
            this.lblHsSemanales.Size = new System.Drawing.Size(122, 17);
            this.lblHsSemanales.TabIndex = 24;
            this.lblHsSemanales.Text = "Horas semanales:";
            // 
            // nupHsSemanales
            // 
            this.nupHsSemanales.Location = new System.Drawing.Point(139, 121);
            this.nupHsSemanales.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nupHsSemanales.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nupHsSemanales.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupHsSemanales.Name = "nupHsSemanales";
            this.nupHsSemanales.Size = new System.Drawing.Size(65, 22);
            this.nupHsSemanales.TabIndex = 23;
            this.nupHsSemanales.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbPlanes
            // 
            this.cmbPlanes.DisplayMember = "desc_plan";
            this.cmbPlanes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlanes.FormattingEnabled = true;
            this.cmbPlanes.Location = new System.Drawing.Point(139, 85);
            this.cmbPlanes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbPlanes.Name = "cmbPlanes";
            this.cmbPlanes.Size = new System.Drawing.Size(139, 24);
            this.cmbPlanes.TabIndex = 22;
            this.cmbPlanes.ValueMember = "id_plan";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 89);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Plan:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(139, 15);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(319, 22);
            this.txtDescripcion.TabIndex = 20;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(43, 18);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(86, 17);
            this.lblDescripcion.TabIndex = 19;
            this.lblDescripcion.Text = "Descripcion:";
            // 
            // cmbEspecialidades
            // 
            this.cmbEspecialidades.DisplayMember = "desc_plan";
            this.cmbEspecialidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialidades.FormattingEnabled = true;
            this.cmbEspecialidades.Location = new System.Drawing.Point(139, 49);
            this.cmbEspecialidades.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbEspecialidades.Name = "cmbEspecialidades";
            this.cmbEspecialidades.Size = new System.Drawing.Size(319, 24);
            this.cmbEspecialidades.TabIndex = 28;
            this.cmbEspecialidades.ValueMember = "id_plan";
            this.cmbEspecialidades.SelectedIndexChanged += new System.EventHandler(this.cmbEspecialidades_SelectedIndexChanged);
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Location = new System.Drawing.Point(37, 53);
            this.lblEspecialidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(92, 17);
            this.lblEspecialidad.TabIndex = 27;
            this.lblEspecialidad.Text = "Especialidad:";
            // 
            // lblHsTotales
            // 
            this.lblHsTotales.AutoSize = true;
            this.lblHsTotales.Location = new System.Drawing.Point(229, 123);
            this.lblHsTotales.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHsTotales.Name = "lblHsTotales";
            this.lblHsTotales.Size = new System.Drawing.Size(96, 17);
            this.lblHsTotales.TabIndex = 30;
            this.lblHsTotales.Text = "Horas totales:";
            // 
            // nupHsTotales
            // 
            this.nupHsTotales.Location = new System.Drawing.Point(333, 121);
            this.nupHsTotales.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nupHsTotales.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupHsTotales.Name = "nupHsTotales";
            this.nupHsTotales.Size = new System.Drawing.Size(65, 22);
            this.nupHsTotales.TabIndex = 29;
            this.nupHsTotales.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // formMateriasModificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 202);
            this.Controls.Add(this.lblHsTotales);
            this.Controls.Add(this.nupHsTotales);
            this.Controls.Add(this.cmbEspecialidades);
            this.Controls.Add(this.lblEspecialidad);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblHsSemanales);
            this.Controls.Add(this.nupHsSemanales);
            this.Controls.Add(this.cmbPlanes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(490, 249);
            this.MinimumSize = new System.Drawing.Size(490, 249);
            this.Name = "formMateriasModificacion";
            this.Text = "Modificación de materia";
            this.Load += new System.EventHandler(this.formMateriasModificacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nupHsSemanales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupHsTotales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblHsSemanales;
        private System.Windows.Forms.NumericUpDown nupHsSemanales;
        private System.Windows.Forms.ComboBox cmbPlanes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.ComboBox cmbEspecialidades;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.Label lblHsTotales;
        private System.Windows.Forms.NumericUpDown nupHsTotales;
    }
}