using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace UI.Desktop
{
    public partial class formCursosModificacion : Form
    {
        public enum Modos
        {
            Alta,
            Modificacion
        }

        
        public Curso Curso { get; set; }
        public Modos Modo { get; set; }

        public bool EventosActivados;
        public formCursosModificacion()
        {
            InitializeComponent();
        }

        private void formCursosModificacion_Load(object sender, EventArgs e)
        {
            EventosActivados = false;
            FillEspecialidades();
            if (Modo == Modos.Modificacion)
                LoadCurso();
            else
                this.Text = "Alta de comisión";
            EventosActivados = true;
        }

        public void LoadCurso()
        {
            int plan = (new MateriaLogic()).GetOne(Curso.IDMateria).IDPlan;
            int especialidad = (new PlanesLogic()).GetOne(plan).IDEspecialidad;
            cmbEspecialidad.SelectedValue = especialidad;
            FillPlanes();
            cmbPlan.SelectedValue = plan;
            FillMaterias();
            cmbMateria.SelectedValue = Curso.IDMateria;
            FillComisiones();
            cmbComision.SelectedValue = Curso.IDComision;
            nupAnio.Value = Curso.AnioCalendario;
            nupCupo.Value = Curso.Cupo;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (DatosValidos())
            {
                CursoLogic cl = new CursoLogic();
                this.GetCurso();
                cl.Save(Curso);
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
                        MessageBox.Show("Año inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("No ha seleccionado una comisión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado una materia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

        }

        private void GetCurso()
        {

            try
            {
                if(Modo == Modos.Alta)
                {
                    Curso = new Curso();
                    Curso.State = BusinessEntity.States.New;
                }
                else
                {
                    Curso.State = BusinessEntity.States.Modified;
                }
                Curso.IDComision = Convert.ToInt32(cmbComision.SelectedValue);
                Curso.AnioCalendario = Convert.ToInt32(nupAnio.Value);
                Curso.IDMateria = Convert.ToInt32(cmbMateria.SelectedValue);
                Curso.Cupo = Convert.ToInt32(nupCupo.Value);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Error al recuperar valor de lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void FillEspecialidades()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            cmbEspecialidad.DataSource = el.GetAll();
            cmbEspecialidad.DisplayMember = "Descripcion";
            cmbEspecialidad.ValueMember = "ID";
        }

        private void FillPlanes()
        {
            int id;
            bool parseOK = Int32.TryParse(cmbEspecialidad.SelectedValue.ToString(), out id);
            if (parseOK)
            {
                EventosActivados = false;
                PlanesLogic pl = new PlanesLogic();
                cmbPlan.DataSource = pl.GetPlanesEspecialidad(id);
                cmbPlan.DisplayMember = "Descripcion";
                EventosActivados = true;
                cmbPlan.ValueMember = "ID";
            }
            else
                MessageBox.Show("¡Algo salió mal!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void cmbEspecialidad_SelectedValueChanged(object sender, EventArgs e)
        {
            if (EventosActivados)
            {
                if (cmbEspecialidad.SelectedValue != null)
                    FillPlanes();
                else
                {
                    cmbPlan.SelectedIndex = -1;
                    cmbPlan.ResetText();
                }
            }
        }

        private void FillMaterias()
        {
            int id;
            bool parseOK = Int32.TryParse(cmbPlan.SelectedValue.ToString(), out id);
            if (parseOK)
            {
                EventosActivados = false;
                MateriaLogic cl = new MateriaLogic();
                cmbMateria.DataSource = cl.GetListaMateriasPlan(id);
                cmbMateria.DisplayMember = "Descripcion";
                EventosActivados = true;
                cmbMateria.ValueMember = "ID";
            }
            else
                MessageBox.Show("¡Algo salió mal!", "Error de modificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void cmbPlanes_SelectedValueChanged(object sender, EventArgs e)
        {
            if (EventosActivados)
            {
                if (cmbPlan.SelectedValue != null)
                {
                    FillMaterias();
                    FillComisiones();
                }
                else
                {
                    cmbMateria.SelectedIndex = -1;
                    cmbMateria.ResetText();
                    cmbComision.SelectedIndex = -1;
                    cmbComision.ResetText();
                }

            }

        }

        private void FillComisiones()
        {
            int id;
            bool parseOK = Int32.TryParse(cmbPlan.SelectedValue.ToString(), out id);
            if (parseOK)
            {
                ComisionLogic cl = new ComisionLogic();
                cmbComision.DataSource = cl.GetListaComisionesPlan(id);
                cmbComision.DisplayMember = "Descripcion";
                cmbComision.ValueMember = "ID";
            }
            else
                MessageBox.Show("¡Algo salió mal!", "Error de modificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void cmbPlan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
