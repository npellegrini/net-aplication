using Entidades;
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
    public partial class formMain : Form
    {
        public Usuario User { get; set; }
        public formUsuarios Usuarios { get; set; }
        public formEspecialidades Especialidades { get; set; }
        public formPlanes Planes { get; set; }
        public formMaterias Materias { get; set; }
        public formComisiones Comisiones { get; set; }
        public formCursos Cursos { get; set; }
        public formInscripcion Inscripciones { get; set; }


        public formMain()
        {
            InitializeComponent();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void formMain_Shown(object sender, EventArgs e)
        {
            formLogin appLogin = new formLogin();
            if (appLogin.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
            else
            {
                User = appLogin.User;
                appLogin.Dispose();
            }

        }

        private void btnPlanes_Click(object sender, EventArgs e)
        {
            if (Planes == null)
            {
                Planes = new formPlanes();
                Planes.Show();
            }
            else
            {
                if (Planes.IsDisposed)
                {
                    Planes = new formPlanes();
                    Planes.Show();
                }
                else
                    Planes.BringToFront();

            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            if (Usuarios == null)
            {
                Usuarios = new formUsuarios();
                Usuarios.Show();
            }
            else
            {
                if (Usuarios.IsDisposed)
                {
                    Usuarios = new formUsuarios();
                    Usuarios.Show();
                }
                else
                    Usuarios.BringToFront();
            }
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            if (Cursos == null)
            {
                Cursos = new formCursos();
                Cursos.Show();
            }
            else
            {
                if (Cursos.IsDisposed)
                {
                    Cursos = new formCursos();
                    Cursos.Show();
                }
                else
                    Cursos.BringToFront();
            }
        }

        private void btnComisiones_Click(object sender, EventArgs e)
        {
            if (Comisiones == null)
            {
                Comisiones = new formComisiones();
                Comisiones.Show();
            }
            else
            {
                if (Comisiones.IsDisposed)
                {
                    Comisiones = new formComisiones();
                    Comisiones.Show();
                }
                else
                    Comisiones.BringToFront();

            }
        }

        private void btnInscripciones_Click(object sender, EventArgs e)
        {
            if (Inscripciones == null)

            {
                Inscripciones = new formInscripcion();
                Inscripciones.Show();
            }
            else
            {
                if (Inscripciones.IsDisposed)
                {
                    Inscripciones = new formInscripcion();
                    Inscripciones.Show();
                }
                else
                    Inscripciones.BringToFront();

            }
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            if (Materias == null)
            {
                Materias = new formMaterias();
                Materias.Show();
            }
            else
            {
                if (Materias.IsDisposed)
                {
                    Materias = new formMaterias();
                    Materias.Show();
                }
                else
                    Materias.BringToFront();

            }
        }

        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            if (Especialidades == null)
            {
                Especialidades = new formEspecialidades();
                Especialidades.Show();
            }
            else
            {
                if(Especialidades.IsDisposed)
                {
                    Especialidades = new formEspecialidades();
                    Especialidades.Show();
                }
                else
                    Especialidades.BringToFront();

            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("¿Salir de la aplicación?", "Saliendo...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                this.Dispose();
        }
    }
}
