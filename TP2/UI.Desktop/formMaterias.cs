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
using Entidades;

namespace UI.Desktop
{
    public partial class formMaterias : Form
    {
        public int SelectedRow { get; set; }
        public formMaterias()
        {
            InitializeComponent();
            this.dgvMaterias.AutoGenerateColumns = false;

        }

       

        private void formMaterias_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void Listar()
        {
            MateriaLogic ml = new MateriaLogic();
            dgvMaterias.DataSource = ml.GetMaterias();
        }

        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            formMateriasModificacion fmm = new formMateriasModificacion();
            fmm.Modo = formMateriasModificacion.Modos.Alta;
            fmm.Show();
            
        }

        private void dgvMaterias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                SelectedRow = e.RowIndex;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void formMaterias_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvMaterias.SelectedRows.Count > 0)
            {
                SelectedRow = dgvMaterias.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvMaterias.Rows[SelectedRow];
                int id = Convert.ToInt32(selectedRow.Cells[0].Value);

                MateriaLogic ml = new MateriaLogic();

                formMateriasModificacion fmm = new formMateriasModificacion();
                fmm.Modo = formMateriasModificacion.Modos.Modificacion;
                fmm.Materia = ml.GetOne(id);
                fmm.Show();
            }

            else
                MessageBox.Show("No ha seleccionado ningúna materia.", "Error de modificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMaterias.SelectedRows.Count > 0)
            {
                SelectedRow = dgvMaterias.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvMaterias.Rows[SelectedRow];
                int idMateria = Convert.ToInt32(selectedRow.Cells[0].Value);
                MateriaLogic ml = new MateriaLogic();
                Materia m = ml.GetOne(idMateria);
                string dependencias = ml.DependenciasExistentes(m);
                if (dependencias == "")
                {
                    if ((MessageBox.Show("¿Estás seguro de eliminar a este plan?", "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                    {
                        m.State = BusinessEntity.States.Deleted;
                        ml.Save(m);
                        this.Listar();
                    }
                }
                else
                    MessageBox.Show("No se puede eliminar el plan. Existen registros relacionados en: " + dependencias + ".", "Error de baja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
                MessageBox.Show("No ha seleccionado ningún plan", "Error de baja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }


    }
}
