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
    public partial class formMateriasModificacion : Form
    {
        public enum Modos
        {
            Alta,
            Modificacion
        }


        public Materia Materia { get; set; }
        public Modos Modo { get; set; }
        private bool EventosActivados { get; set; }
        public formMateriasModificacion()
        {
            InitializeComponent();
        }

        private void formMateriasModificacion_Load(object sender, EventArgs e)
        {
            EventosActivados = false;
            FillEspecialidades();
            if (Modo == Modos.Modificacion)
                LoadMateria();
            else
                this.Text = "Alta de materia";
            EventosActivados = true;
        }

        private void LoadMateria()
        {
            int plan = Materia.IDPlan;
            int especialidad = (new PlanesLogic()).GetOne(plan).IDEspecialidad;
            cmbEspecialidades.SelectedValue = especialidad;
            FillPlanes();
            cmbPlanes.SelectedValue = plan;
            txtDescripcion.Text = Materia.Descripcion;
            nupHsSemanales.Value = Materia.HSSemanales;
            nupHsTotales.Value = Materia.HSTotales;
        }

        private void FillEspecialidades()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            cmbEspecialidades.DataSource = el.GetAll();
            cmbEspecialidades.DisplayMember = "Descripcion";
            cmbEspecialidades.ValueMember = "ID";
        }

        private void cmbEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EventosActivados)
            {
                if (cmbEspecialidades.SelectedValue != null)
                    FillPlanes();
                else
                {
                    cmbPlanes.SelectedIndex = -1;
                    cmbPlanes.ResetText();
                }
            }
        }


        private void FillPlanes()
        {
            int id;
            bool parseOK = Int32.TryParse(cmbEspecialidades.SelectedValue.ToString(), out id);
            if (parseOK)
            {
                EventosActivados = false;
                PlanesLogic pl = new PlanesLogic();
                cmbPlanes.DataSource = pl.GetPlanesEspecialidad(id);
                cmbPlanes.DisplayMember = "Descripcion";
                EventosActivados = true;
                cmbPlanes.ValueMember = "ID";
            }
            else
                MessageBox.Show("¡Algo salió mal!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (DatosValidos())
            {
                MateriaLogic cl = new MateriaLogic();
                this.GetMateria();
                cl.Save(Materia);
                this.Close();
            }
        }

        private void GetMateria()
        {
            try
            {
                if (Modo == Modos.Alta)
                {
                    Materia = new Materia();
                    Materia.State = BusinessEntity.States.New;
                }
                else
                {
                    Materia.State = BusinessEntity.States.Modified;
                }
                Materia.IDPlan = Convert.ToInt32(cmbPlanes.SelectedValue);
                Materia.HSSemanales = Convert.ToInt32(nupHsSemanales.Value);
                Materia.HSTotales = Convert.ToInt32(nupHsTotales.Value);
                Materia.Descripcion = txtDescripcion.Text;
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Error al recuperar valor de lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool DatosValidos()
        {
            bool valid = true;

            if (txtDescripcion.Text == "")
            {
                MessageBox.Show("No ha ingresado una descripción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                valid = false;
            }

            if (cmbEspecialidades.SelectedValue.Equals(null))
            {
                MessageBox.Show("No ha seleccionado ninguna especialidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                valid = false;
            }

            if (cmbPlanes.SelectedValue.Equals(null))
            {
                MessageBox.Show("No ha seleccionado ningún plan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                valid = false;


            }
            if ((nupHsTotales.Value <= 0))
            {

                MessageBox.Show("Horas totales inválidas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                valid = false;
            }

            if ((nupHsSemanales.Value <= 0))
            {
                MessageBox.Show("Horas semanales inválidas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                valid = false;
            }

            return valid;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


    }
}
