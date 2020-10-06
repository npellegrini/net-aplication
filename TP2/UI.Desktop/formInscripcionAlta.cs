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
    public partial class formInscripcionAlta : Form
    {
        public Usuario Usuario { get; set; }
        private bool EventosActivados { get; set; }
        public formInscripcionAlta()
        {
            InitializeComponent();
        }

        private void formInscripcionAlta_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'academicaDS.comisiones' Puede moverla o quitarla según sea necesario.
            //this.comisionesTableAdapter.Fill(this.academicaDS.comisiones);

            // TODO: esta línea de código carga datos en la tabla 'academicaDS.materias' Puede moverla o quitarla según sea necesario.
            //this.materiasTableAdapter.Fill(this.academicaDS.materias);
            EventosActivados = false;
            FillMateriasByPlan();

        }

        private void btnInscribirse_Click(object sender, EventArgs e)
        {
            InscripcionLogic il = new InscripcionLogic();
            AlumnoInscripcion ins = this.GetInscripcion();
            if (ins != null)
            {
                try
                {

                    il.Save(ins);
                    MessageBox.Show("¡Inscripción exitosa!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                catch
                {
                    MessageBox.Show("Algo salió mal.", "Error de inscripción", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private AlumnoInscripcion GetInscripcion()
        {
            AlumnoInscripcion ins = null;
            CursoLogic cl = new CursoLogic();
            if (DatosValidos())
            {
                Curso c = this.GetCurso();
                if (c != null)
                {
                    if (cl.HayCupo(c))
                    {
                        ins = new AlumnoInscripcion();
                        ins.IDAlumno = Usuario.ID;
                        ins.IDCurso = c.ID;
                        ins.Condicion = AlumnoInscripcion.Condiciones.Inscripto;
                        ins.State = BusinessEntity.States.New;
                    }
                    else
                    {
                        MessageBox.Show("No hay cupo disponible en este curso.", "Error de inscripción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("No existe un curso para la materia y comisión elegidas.", "Error de inscripción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }


            }

            return ins;
        }

        private bool DatosValidos()
        {
            if (!cmbMateria.SelectedValue.Equals(null))
            {
                if (!cmbComision.SelectedValue.Equals(null))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("No ha seleccionado una comisión.", "Error de inscripción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado una materia.", "Error de inscripción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }
        private void FillMateriasByPlan()
        {

            MateriaLogic el = new MateriaLogic();
            cmbMateria.DataSource = el.GetListaMateriasPlan(Usuario.IDPlan);
            cmbMateria.DisplayMember = "Descripcion";
            cmbMateria.ValueMember = "ID";
            EventosActivados = true;

        }
        private void FillComisionesByMateria()
        {
            int id;
            bool parseOK = Int32.TryParse(cmbMateria.SelectedValue.ToString(), out id);
            if (parseOK)
            {
                CursoLogic cl = new CursoLogic();
                cmbComision.DataSource = cl.GetCursosByMateria(id);
                cmbComision.DisplayMember = "desc_comision";
                cmbComision.ValueMember = "id_comision";
            }
            else 
                //ACA PUEDE ESTAR EL ERROR QUE SALE APENAS ABRIS EL FORMULARIO DE ALTA DE INSCRIPCION
                MessageBox.Show("¡Algo salió mal!", "Error de alta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private Curso GetCurso()
        {
            Curso c = null;
            try
            {
                DateTime date = DateTime.Today;
                int idMateria = Convert.ToInt32(cmbMateria.SelectedValue);
                int idComision = Convert.ToInt32(cmbComision.SelectedValue);
                c = (new CursoLogic()).GetOne(idMateria, idComision, date.Year);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Error al recuperar valor de lista.", "Error de modificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return c;

        }



        private void cmbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EventosActivados)
            {
                if (cmbMateria.SelectedValue != null)
                    FillComisionesByMateria();
                else
                {
                    cmbComision.SelectedIndex = -1;
                    cmbComision.ResetText();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        
    }
}

/*Al inscribirse, se elige una materia y se muestran las comisiones de esa materia. Se elige comision. El sistema busca el curso que corresponde
a esa materia, esa comision en el año calendario actual. Sistema valida que haya cupo disponible (cantInscriptos < cupo del curso). Si está todo OK,
inscribe al alumno --> crea nueva AlumnoInscripcion, con Condicion = "inscripto"*/
