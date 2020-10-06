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
    public partial class formPlanesModificacion : Form
    {
        public enum Modos
        {
            Alta,
            Modificacion
        }
        public Plan Plan { get; set; }
        public Modos Modo { get; set; }

        public formPlanesModificacion()
        {
            InitializeComponent();
            
        }
        public void LoadPlan()
        {
            txtDescripcion.Text = Plan.Descripcion;
            cmbEspecialidades.SelectedValue = Plan.IDEspecialidad;
        }

        private void formPlanesModificacion_Load(object sender, EventArgs e)
        {

            var especialidadesLogic = new EspecialidadLogic();
            cmbEspecialidades.DataSource = especialidadesLogic.GetAll();
            cmbEspecialidades.DisplayMember = "Descripcion";
            cmbEspecialidades.ValueMember = "ID";
            if (Modo == Modos.Modificacion)
                LoadPlan();
            else
                this.Text = "Alta de plan";

        }
        public void btnAceptar_Click(object sender, EventArgs e)
        {
            if (DatosValidos())
            {
                PlanesLogic planLogic = new PlanesLogic();
                this.GetPlan();
                planLogic.Save(Plan);
                if (Modo == Modos.Alta)
                    MessageBox.Show("Alta exitosa.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Cambios guardados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
           
        }


        private bool DatosValidos()
        {
            bool camposCompletos = true;
            bool valid = true;

            if (txtDescripcion.Text == "")
                camposCompletos = false;
            if (!camposCompletos)
            {
                MessageBox.Show("Un plan debe tener descripción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                valid = false;
            }
            return valid;
        }

        private void GetPlan()
        {

            if (Modo == Modos.Alta)
            {
                Plan = new Plan();
                Plan.State = BusinessEntity.States.New;
            }
            else
                Plan.State = BusinessEntity.States.Modified;
            Plan.Descripcion = txtDescripcion.Text;
            Plan.IDEspecialidad = (cmbEspecialidades.SelectedItem as Especialidad).ID;

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
        }
    }
}