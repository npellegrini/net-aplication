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
    public partial class formCursosAlta : Form
    {
        public formCursosAlta()
        {
            InitializeComponent();
            nupAnio.Value = DateTime.Today.Year;
        }


        public Curso Curso { get; set; }

      

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CursoLogic cl = new CursoLogic();
            Curso c = this.GetCurso();
            if (c != null)
            {
                cl.Save(c);
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
        }
        private bool DatosValidos()
        {
            if (!cmbMateria.SelectedValue.Equals(null))
            {
                if (!cmbComision.SelectedValue.Equals(null))
                {
                    if (!(nupAnio.Value <= 0))
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Año inválido.", "Error de modificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("No ha seleccionado una comisión.", "Error de modificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado una materia.", "Error de modificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

        }

        private Curso GetCurso()
        {
            var c = new Curso();
            if (DatosValidos())
            {
                try
                {
                    c.IDComision = Convert.ToInt32(cmbComision.SelectedValue);
                    c.AnioCalendario = Convert.ToInt32(nupAnio.Value);
                    c.IDMateria = Convert.ToInt32(cmbMateria.SelectedValue);
                    c.Cupo = Convert.ToInt32(nupCupo.Value);
                    c.State = BusinessEntity.States.New;
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Error al recuperar valor de lista.", "Error de modificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            return c;
        }

        private void formCursosAlta_Load(object sender, EventArgs e)
        {

            // TODO: esta línea de código carga datos en la tabla 'academicaDS.comisiones' Puede moverla o quitarla según sea necesario.
            this.comisionesTableAdapter.Fill(this.academicaDS.comisiones);
            // TODO: esta línea de código carga datos en la tabla 'academicaDS.materias' Puede moverla o quitarla según sea necesario.
            this.materiasTableAdapter.Fill(this.academicaDS.materias);

        }

        private void formCursosAlta_Load_1(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'academicaDS.planes' Puede moverla o quitarla según sea necesario.
            this.planesTableAdapter.Fill(this.academicaDS.planes);
            // TODO: esta línea de código carga datos en la tabla 'academicaDS.materias' Puede moverla o quitarla según sea necesario.
            this.materiasTableAdapter.Fill(this.academicaDS.materias);
            // TODO: esta línea de código carga datos en la tabla 'academicaDS.comisiones' Puede moverla o quitarla según sea necesario.
            this.comisionesTableAdapter.Fill(this.academicaDS.comisiones);

        }
    }
}