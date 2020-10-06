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
    public partial class formComisionAlta : Form
    {
        public formComisionAlta()
        {
            InitializeComponent();
        }

        private bool DatosValidos()
        {
            bool camposCompletos = true;
            bool valid = true;

            if (txtDescripcion.Text == "")
                camposCompletos = false;
            else
            {
                if (nupAnio.Text == "" || nupAnio.Value < 0)
                    camposCompletos = false;
                else
                {
                    if (cmbPlanes.SelectedItem == null)
                        camposCompletos = false;
                }
            }
            if (!camposCompletos)
            {
                MessageBox.Show("Hay campos sin completar", "Error de alta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                valid = false;
            }
            return valid;
        }
        private Comision GetComision()
        {
            var c = new Comision();
            if (DatosValidos())
            {
                c.Descripcion = txtDescripcion.Text;
                c.AnioEspecialidad = Convert.ToInt32(nupAnio.Value);
                c.IDPlan = (int)cmbPlanes.SelectedValue;
                c.State = BusinessEntity.States.New;

            }
            return c;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void formComisionAlta_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'academicaDS.planes' Puede moverla o quitarla según sea necesario.
            this.planesTableAdapter.Fill(this.academicaDS.planes);

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ComisionLogic cl = new ComisionLogic();
            Comision c = this.GetComision();
            if (c != null)
            {
                cl.Save(c);
                this.Close();
            }
        }
    }
}
