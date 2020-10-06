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
    public partial class formCursos : Form
    {
        public int SelectedRow { get; set; }
        public formCursos()
        {
            InitializeComponent();
            this.dgvCursos.AutoGenerateColumns = false;
        }
        private void formCursos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'academicaDataSet1.usuarios' Puede moverla o quitarla según sea necesario.
            //this.usuariosTableAdapter.Fill(this.academicaDataSet1.usuarios); acomodar esta lista agregando la fuente del dgv

            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void Listar()
        {
            CursoLogic cl = new CursoLogic();
            this.dgvCursos.DataSource = cl.GetCursos();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvCursos.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCursos.Rows[SelectedRow];
                int id = Convert.ToInt32(selectedRow.Cells[0].Value);

                CursoLogic cl = new CursoLogic();

                formCursosModificacion fcm = new formCursosModificacion();
                fcm.Modo = formCursosModificacion.Modos.Modificacion;
                fcm.Curso = cl.GetOne(id);
                fcm.Show();
            }

            else
                MessageBox.Show("No ha seleccionado ningún Curso", "Error de modificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCursos.SelectedRows.Count > 0)
            {
                CursoLogic cl = new CursoLogic();
                DataGridViewRow selectedRow = dgvCursos.Rows[SelectedRow];
                int id = Convert.ToInt32(selectedRow.Cells[0].Value);
                Curso c = cl.GetOne(id);
                string dependencias = cl.DependenciasExistentes(c);
                if (dependencias == "")
                {
                    if ((MessageBox.Show("¿Estás seguro de eliminar a este Curso?", "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                    {
                        c.State = BusinessEntity.States.Deleted;
                        cl.Save(c);
                        this.Listar();
                    }
                }
                else
                    MessageBox.Show("No se puede eliminar el curso. Existen registros relacionados en: " + dependencias + ".", "Error de baja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
                MessageBox.Show("No ha seleccionado ningún curso.", "Error de baja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            formCursosModificacion fcm = new formCursosModificacion();
            fcm.Modo = formCursosModificacion.Modos.Alta;
            fcm.Show();
        }

        private void dgvCursos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                SelectedRow = e.RowIndex;

            }
        }

        private void dgvCursos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvCursos.Rows[SelectedRow];
                int id = Convert.ToInt32(selectedRow.Cells[0].Value);
                CursoLogic cl = new CursoLogic();
                formCursosDictados fcd = new formCursosDictados();
                fcd.Curso = cl.GetOne(id);
                fcd.Show();
            }
        }

        private void formCursos_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
