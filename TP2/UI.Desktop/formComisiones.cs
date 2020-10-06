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
    public partial class formComisiones : Form
    {
        public int SelectedRow { get; set; }
        public formComisiones()
        {
            InitializeComponent();
        }
        public void Listar()
        {
            ComisionLogic cl = new ComisionLogic();
            this.dgvComisiones.DataSource = cl.GetComisiones();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            formComisionesModificacion fca = new formComisionesModificacion();
            fca.Modo = formComisionesModificacion.Modos.Alta;
            fca.Show();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvComisiones.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvComisiones.Rows[SelectedRow];
                int id = Convert.ToInt32(selectedRow.Cells[0].Value);

                ComisionLogic cl = new ComisionLogic();

                formComisionesModificacion fcm = new formComisionesModificacion();
                fcm.Modo = formComisionesModificacion.Modos.Modificacion;
                fcm.Comision = cl.GetOne(id);
                fcm.Show();
            }

            else
                MessageBox.Show("No ha seleccionado ninguna comision.", "Error de modificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvComisiones.SelectedRows.Count > 0)
            {
                ComisionLogic cl = new ComisionLogic();
                DataGridViewRow selectedRow = dgvComisiones.Rows[SelectedRow];
                int id = Convert.ToInt32(selectedRow.Cells[0].Value);
                Comision c = cl.GetOne(id);
                string dependencias = cl.DependenciasExistentes(c);

                if (dependencias == "")
                {
                    if ((MessageBox.Show("¿Estás seguro de eliminar esta comisión?", "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                    {
                        c.State = BusinessEntity.States.Deleted;
                        cl.Save(c);
                        this.Listar();
                    }
                }
                else
                    MessageBox.Show("No se puede eliminar la comisión. Existen registros relacionados en: " + dependencias + ".", "Error de baja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
                MessageBox.Show("No ha seleccionado ninguna comision.", "Error de baja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void formComisiones_Load(object sender, EventArgs e)
        {
            dgvComisiones.AutoGenerateColumns = false;
            // TODO: esta línea de código carga datos en la tabla 'academicaDS._comisiones_plan' Puede moverla o quitarla según sea necesario.
            Listar();
        }



        private void dgvComisiones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                SelectedRow = e.RowIndex;
            }
        }

        private void formComisiones_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
