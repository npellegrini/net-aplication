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
    public partial class formUsuarios : Form
    {
        public int SelectedRow { get; set; }
        public formUsuarios()
        {
            InitializeComponent();
            this.dgvUsuarios.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            this.dgvUsuarios.DataSource = ul.GetUsuarios();
        }

        private void formUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                Listar();
            }
            catch (Exception ex)
            {
                Exception exceptionManejada = new Exception("error al cargar usuarios en interfaz", ex);
                throw exceptionManejada;
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

       

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
               // int selectedrowindex = dgvUsuarios.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvUsuarios.Rows[SelectedRow];
                int id = Convert.ToInt32(selectedRow.Cells[1].Value);

                UsuarioLogic ul = new UsuarioLogic();

                formUsuariosEdicion fue = new formUsuariosEdicion();
                fue.Usuario = ul.GetOne(id);
                fue.Modo = formUsuariosEdicion.Modos.Modificacion;
                fue.Show();
            }

            else
                MessageBox.Show("No ha seleccionado ningún usuario", "Error de modificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                UsuarioLogic ul = new UsuarioLogic();
                DataGridViewRow selectedRow = dgvUsuarios.Rows[SelectedRow];
                int id = Convert.ToInt32(selectedRow.Cells[1].Value);
                Usuario u = ul.GetOne(id);
                string dependencias = ul.DependenciasExistentes(u);
                if (dependencias == "")
                {
                    if ((MessageBox.Show("¿Estás seguro de eliminar a este usuario?", "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                    {
                        u.State = BusinessEntity.States.Deleted;
                        ul.Save(u);
                        this.Listar();
                    }
                }
                else
                    MessageBox.Show("No se puede eliminar el usuario. Existen registros relacionados en: " + dependencias + ".", "Error de baja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
                MessageBox.Show("No ha seleccionado ningún usuario", "Error de baja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            Form alta = new formUsuariosEdicion();
            alta.Show();
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                SelectedRow = e.RowIndex;
                
            }
        }

        private void formUsuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
