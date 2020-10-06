using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Entidades;

namespace UI.Desktop
{
    public partial class formPlanesAlta : Form
    {
        public Especialidad Especialidad { get; set; }

        public formPlanesAlta()
        {
            InitializeComponent();
        }

        private void formPlanes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'academicaDS.especialidades' Puede moverla o quitarla según sea necesario.
            this.especialidadesTableAdapter1.Fill(this.academicaDS.especialidades);
            var especialidadesLogic = new EspecialidadLogic();
            cbEspecialidad.DataSource = especialidadesLogic.GetAll();

        }

        private void btAceptar_Click(object sender, EventArgs e) //CHECKEAR QUE SE HAYA SELECCIONADO ALGO EN EL COMBOBOX --> DatosValidos()
        {
            var planesLogic = new PlanesLogic();
            var plan = new Plan();
            plan.Descripcion = tbDescrip.Text;
            int id;
            bool parseOK = Int32.TryParse(cbEspecialidad.SelectedValue.ToString(), out id);
            plan.IDEspecialidad = id;
            plan.State = BusinessEntity.States.New;
            planesLogic.Save(plan);
            MessageBox.Show("¡Carga exitosa!", "Información de alta", MessageBoxButtons.OK);
            this.Dispose();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
