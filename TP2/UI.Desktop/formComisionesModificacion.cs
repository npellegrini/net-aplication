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
    public partial class formComisionesModificacion : Form
    {
        public enum Modos
        {
            Alta,
            Modificacion
        }


        public Comision Comision { get; set; }
        public Modos Modo { get; set; }
        private bool EventosActivados { get; set; }
        public formComisionesModificacion()
        {
            InitializeComponent();
        }

        private void formComisionesModificacion_Load(object sender, EventArgs e)
        {
            EventosActivados = false;
            FillEspecialidades();
            if (Modo == Modos.Modificacion)
                LoadComision();
            else
                this.Text = "Alta de Comision";
            EventosActivados = true;
        }

        private void LoadComision()
        {
            int plan = Comision.IDPlan;
            int especialidad = (new PlanesLogic()).GetOne(plan).IDEspecialidad;
            cmbEspecialidades.SelectedValue = especialidad;
            FillPlanes();
            cmbPlanes.SelectedValue = plan;
            txtDescripcion.Text = Comision.Descripcion;
            nupAnio.Value = Comision.AnioEspecialidad;
        }

        private void FillEspecialidades()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            cmbEspecialidades.DataSource = el.GetAll();
            cmbEspecialidades.DisplayMember = "Descripcion";
            cmbEspecialidades.ValueMember = "ID";
        }

        private void cmbEspecialidades_SelectedIndexChanged_1(object sender, EventArgs e)
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


        private void GetComision()
        {
            try
            {
                if (Modo == Modos.Alta)
                {
                    Comision = new Comision();
                    Comision.State = BusinessEntity.States.New;
                }
                else
                {
                    Comision.State = BusinessEntity.States.Modified;
                }
                Comision.IDPlan = Convert.ToInt32(cmbPlanes.SelectedValue);
                Comision.AnioEspecialidad = Convert.ToInt32(nupAnio.Value);
                Comision.Descripcion = txtDescripcion.Text;
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
            

            if ((nupAnio.Value <= 0))
            {
                MessageBox.Show("Año inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                valid = false;
            }

            return valid;
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (DatosValidos())
            {
                ComisionLogic cl = new ComisionLogic();
                this.GetComision();
                cl.Save(Comision);
                this.Close();
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
