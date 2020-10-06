using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class formEspecialidadesModificacion : Form
    {
        public enum Modos
        {
            Alta,
            Modificacion
        }
        public Especialidad Especialidad { get; set; }
        public Modos Modo { get; set; }

        public formEspecialidadesModificacion()
        {
            InitializeComponent();
        }

        private void formEspecialidadesModificacion_Load(object sender, EventArgs e)
        {
            if (Modo == Modos.Modificacion)
                LoadEspecialidad();
            else
                this.Text = "Alta de especialidad";

        }

        private void LoadEspecialidad()
        {
            txtDescripcion.Text = Especialidad.Descripcion;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text != "")
            {
                if (Modo == Modos.Alta)
                {
                    Especialidad = new Especialidad();
                    Especialidad.State = BusinessEntity.States.New;
                }
                else
                    Especialidad.State = BusinessEntity.States.Modified;
                Especialidad.Descripcion = txtDescripcion.Text;

                EspecialidadLogic el = new EspecialidadLogic();
                el.Save(Especialidad);
                if (Modo == Modos.Alta)
                    MessageBox.Show("Alta exitosa.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Cambios guardados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
                MessageBox.Show("No ha ingresado una descripción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
