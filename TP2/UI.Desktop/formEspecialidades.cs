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
    public partial class formEspecialidades : Form
    {
        private int SelectedRow { get; set; }
        public formEspecialidades()
        {
            InitializeComponent();
            dgvEspecialidades.AutoGenerateColumns = false;
        }

        private void formEspecialidades_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void Listar()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            dgvEspecialidades.DataSource = el.GetAll();
        }

        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            formEspecialidadesModificacion fem = new formEspecialidadesModificacion();
            fem.Modo = formEspecialidadesModificacion.Modos.Alta;
            fem.Show();
        }

        private void tsbModificar_Click(object sender, EventArgs e)
        {
            if (dgvEspecialidades.SelectedRows.Count > 0)
            {
                SelectedRow = dgvEspecialidades.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvEspecialidades.Rows[SelectedRow];
                int id = Convert.ToInt32(selectedRow.Cells[0].Value);

                EspecialidadLogic el = new EspecialidadLogic();

                formEspecialidadesModificacion fem = new formEspecialidadesModificacion();
                fem.Modo = formEspecialidadesModificacion.Modos.Modificacion;
                fem.Especialidad = el.GetOne(id);
                fem.Show();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEspecialidades.SelectedRows.Count > 0)
            {
                EspecialidadLogic el = new EspecialidadLogic();
                SelectedRow = dgvEspecialidades.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvEspecialidades.Rows[SelectedRow];
                int id = Convert.ToInt32(selectedRow.Cells[0].Value);
                Especialidad esp = el.GetOne(id);
                string dependencias = el.DependenciasExistentes(esp);
                if (dependencias == "")
                {
                    if ((MessageBox.Show("¿Estás seguro de eliminar esta especialidad?", "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                    {
                        esp.State = BusinessEntity.States.Deleted;
                        el.Save(esp);
                        this.Listar();
                    }
                }
                else
                    MessageBox.Show("No se puede eliminar especialidad. Existen registros relacionados en: " + dependencias + ".", "Error de baja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("No ha seleccionado ningún plan", "Error de baja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void formEspecialidades_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
