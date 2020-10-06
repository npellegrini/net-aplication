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
using Util;

namespace UI.Desktop
{
    public partial class formInscripcion : Form
    {
        private formInscripcionAlta Alta { get; set; }
        public int SelectedRow { get; set; }
        public Usuario Usuario { get; set; }
        public formInscripcion()
        {
            InitializeComponent();
            this.dgvInscripciones.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            InscripcionLogic il = new InscripcionLogic();
            this.dgvInscripciones.DataSource = il.GetInscripciones(Usuario.ID);

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvInscripciones.SelectedRows.Count > 0)
            {
                //CORREGIR COMO TOMA EL ID DE LA COLUMNA, YA QUE TOMA UN ID ERRONEO Y POR ESO NO DEJA ELIMINAR
                SelectedRow = dgvInscripciones.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRoww = dgvInscripciones.Rows[SelectedRow];
                int idInscripcion = Convert.ToInt32(selectedRoww.Cells[0].Value);

                if ((new InscripcionLogic()).GetOne(idInscripcion).Condicion == AlumnoInscripcion.Condiciones.Inscripto)
                {
                    if ((MessageBox.Show("¿Estás seguro de eliminar tu inscripción?", "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                    {
                        //int selectedrowindex = dgvUsuarios.SelectedCells[0].RowIndex;
                        //DataGridViewRow selectedRow = dgvInscripciones.Rows[SelectedRow];
                        //int id = Convert.ToInt32(selectedRow.Cells[0].Value);
                        InscripcionLogic il = new InscripcionLogic();
                        il.Delete(idInscripcion);
                        this.Listar();
                    }
                }
                else
                    MessageBox.Show("No ha seleccionado ninguna inscripción.", "Error de baja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("No es posible eliminar esta inscripcion.", "Error de baja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            if (Alta == null)
            {
                Alta = new formInscripcionAlta();
                Alta.Usuario = Usuario;
                Alta.Show();
            }
            else
                Alta.BringToFront();
            
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = e.RowIndex;
        }



        private void btnValidar_Click(object sender, EventArgs e)
        {
            var usuarioLogic = new UsuarioLogic();
            var u = txtUsuario.Text;
            var tv = new TextValidator();
            Usuario user = new Usuario();
            bool usuarioValido = false;

            if (u.Contains("@"))
            {
                if (tv.IsValidEmail(u))
                {
                    user = usuarioLogic.GetOneByEmail(u);
                    if (u == user.Email)
                        usuarioValido = true;
                    else
                        MessageBox.Show("Email no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                    MessageBox.Show("Email con formato incorrecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                user = usuarioLogic.GetOneByNombreUsuario(u);
                if (u == user.NombreUsuario)
                    usuarioValido = true;
                else
                    MessageBox.Show("El nombre de usuario ingresado no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (usuarioValido)
            {
                if (user.IDTipoPersona != 1)
                {
                    usuarioValido = false;
                    MessageBox.Show("El usuario ingresado no es un alumno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (user.Habilitado == false)
                    {
                        usuarioValido = false;
                        MessageBox.Show("El usuario ingresado no está habilitado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    
 
                }
                if (usuarioValido)
                {
                    Usuario = user;
                    dgvInscripciones.Enabled = true;
                    dgvInscripciones.DataSource = new InscripcionLogic().GetInscripciones(Usuario.ID);
                    btnActualizar.Enabled = true;
                    tsInscripciones.Enabled = true;
                    Listar();
                }
                else
                {
                    if (Usuario != null)
                        txtUsuario.Text = Usuario.NombreUsuario;
                    else
                        txtUsuario.Text = "";
                }

            }

        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void formInscripcion_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }


}

