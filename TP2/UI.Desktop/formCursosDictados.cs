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
    public partial class formCursosDictados : Form
    {
        public Curso Curso;
        int SelectedRow;

        public formCursosDictados()
        {
            InitializeComponent();
            dgvDocentes.AutoGenerateColumns = false;
        }

        private void formCursosDictados_Load(object sender, EventArgs e)
        {
            FillDocentes();
            FillCargos();
            cmbDocente.DisplayMember = "ApellidoNombre";
            cmbDocente.ValueMember = "ID";
            FillDocentesCurso();
        }

        private void FillDocentes()
        {
            UsuarioLogic ul = new UsuarioLogic();
            cmbDocente.DataSource = ul.GetDocentes();

        }

        private void FillCargos()
        {
            cmbCargo.DataSource = Enum.GetValues(typeof(DocenteCurso.TipoCargo));
        }

        private void dgvDocentes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = e.RowIndex;
            DataGridViewRow selectedRow = dgvDocentes.Rows[SelectedRow];
            int id_docente = Convert.ToInt32(selectedRow.Cells[5].Value);
            cmbDocente.SelectedValue = id_docente;
            int id_dictado = Convert.ToInt32(selectedRow.Cells[0].Value);
            DocenteCurso dc = (new DocenteCursoLogic()).GetOne(id_dictado);
            cmbCargo.SelectedValue = dc.Cargo;

        }

        private void FillDocentesCurso()
        {
            DocenteCursoLogic dcl = new DocenteCursoLogic();
            dgvDocentes.DataSource = dcl.GetDocentesCurso(Curso.ID);
        }

        private void dgvDocentes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDocentes.Columns[e.ColumnIndex].Name == "colCargo")
            {
                DocenteCurso.TipoCargo enumValue = (DocenteCurso.TipoCargo)e.Value;
                string enumstring = enumValue.ToString(); // convert here the enum to displayed string 
                e.Value = enumstring;
            }
        }

        private void btnAgregarDocente_Click(object sender, EventArgs e)
        {
            DocenteCursoLogic dcl = new DocenteCursoLogic();
            DocenteCurso dc = GetDocenteCurso();

            if (dcl.ExisteDictado(dc.IDDocente, dc.IDCurso, dc.Cargo))
            {
                MessageBox.Show("Ya existe un dictado con el docente y el cargo seleccionados en este curso.", "Error de alta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else if (cmbDocente.SelectedIndex > -1)
            {
                dc.State = BusinessEntity.States.New;
                dcl.Save(dc);
                FillDocentesCurso();
                MessageBox.Show("Alta de dictado exitosa.", "Información de alta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminarDocentes_Click(object sender, EventArgs e)
        {
            DocenteCurso dc = GetDocenteCurso();
            if (dgvDocentes.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvDocentes.Rows[SelectedRow];
                dc.ID = Convert.ToInt32(selectedRow.Cells[0].Value);
                dc.State = BusinessEntity.States.Deleted;
                DocenteCursoLogic dcl = new DocenteCursoLogic();
                dcl.Save(dc);
                FillDocentesCurso();
                MessageBox.Show("Eliminación exitosa.", "Información de baja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No ha seleccionado ningún dictado.", "Error de baja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private DocenteCurso GetDocenteCurso()
        {
            int id_docente = (int)cmbDocente.SelectedValue;
            DocenteCurso.TipoCargo cargo;
            Enum.TryParse<DocenteCurso.TipoCargo>(cmbCargo.SelectedValue.ToString(), out cargo);
            DocenteCurso dc = new DocenteCurso
            {
                IDCurso = Curso.ID,
                IDDocente = id_docente,
                Cargo = cargo,
            };

            return dc;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
