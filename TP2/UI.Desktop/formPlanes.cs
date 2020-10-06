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
    public partial class formPlanes : Form
    {
        public int SelectedRow { get; set; }

        public formPlanes()
        {
            InitializeComponent();
            this.dgvPlanes.AutoGenerateColumns = false;
        }
        public void Listar()
        {
            var planesLogic = new PlanesLogic();
            this.dgvPlanes.DataSource = planesLogic.GetPlanes();
        }

        private void formPlanesModificacion_Load(object sender, EventArgs e)
        {

            Listar();
        }



        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }



        private void tbsAgregar_Click(object sender, EventArgs e)
        {
            formPlanesModificacion fpm = new formPlanesModificacion();
            fpm.Modo = formPlanesModificacion.Modos.Alta;
            fpm.Show();
        }


        private void tbsModificar_Click(object sender, EventArgs e)
        {
            if (dgvPlanes.SelectedRows.Count > 0)
            {
                SelectedRow = dgvPlanes.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvPlanes.Rows[SelectedRow];
                int id = Convert.ToInt32(selectedRow.Cells[0].Value);

                PlanesLogic planesLogic = new PlanesLogic();

                formPlanesModificacion fpm = new formPlanesModificacion();
                fpm.Modo = formPlanesModificacion.Modos.Modificacion;
                fpm.Plan = planesLogic.GetOne(id);
                fpm.Show();
            }

            else
                MessageBox.Show("No ha seleccionado ningún plan.", "Error de modificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }


        private void tbsEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPlanes.SelectedRows.Count > 0)
            {
                SelectedRow = dgvPlanes.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvPlanes.Rows[SelectedRow];
                int idPlan = Convert.ToInt32(selectedRow.Cells[0].Value);
                PlanesLogic planLogic = new PlanesLogic();
                Plan p = planLogic.GetOne(idPlan);
                string dependencias = planLogic.DependenciasExistentes(p);
                if (dependencias == "")
                {
                    if ((MessageBox.Show("¿Estás seguro de eliminar a este plan?", "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                    {
                        p.State = BusinessEntity.States.Deleted;
                        planLogic.Save(p);
                        this.Listar();
                    }
                }
                else
                    MessageBox.Show("No se puede eliminar el plan. Existen registros relacionados en: " + dependencias + ".", "Error de baja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
                MessageBox.Show("No ha seleccionado ningún plan", "Error de baja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void dgvPlanes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                SelectedRow = e.RowIndex;
            }
        }

        private void formPlanes_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}