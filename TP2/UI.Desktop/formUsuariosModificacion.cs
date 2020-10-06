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
    public partial class formUsuariosModificacion : Form
    {
        public Usuario User { get; set; }

        public formUsuariosModificacion()
        {
            InitializeComponent();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            UsuarioLogic ul = new UsuarioLogic();
            Usuario u = this.GetUser();
            if (u != null)
            {
                ul.Save(u);
                MessageBox.Show("Los cambios han sido guardados correctamente.", "Información de modificación");
                this.Close(); //Se comentó el close despues de consultar al Prof. Porta, ya que provocaba una excepcion en Main cuya razon no pudimos determinar 
                //this.DialogResult = DialogResult.OK;
            }

        }

        private bool DatosValidos()
        {
            bool camposCompletos = true;
            bool valid = true;

            if (txtNombreUsuario.Text == "")
                camposCompletos = false;
            else
            {
                if (txtNombre.Text == "")
                    camposCompletos = false;
                else
                {
                    if (txtApellido.Text == "")
                        camposCompletos = false;
                    else
                    {
                        if (txtEmail.Text == "")
                            camposCompletos = false;
                    }
                }
            }
            if (!camposCompletos)
            {
                MessageBox.Show("Hay campos sin completar", "Error de alta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                valid = false;
            }
            else
            {
                TextValidator tv = new TextValidator();
                if (!tv.IsValidEmail(txtEmail.Text))
                {
                    MessageBox.Show("Email con formato incorrecto.", "Error de alta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    valid = false;
                }
                else
                {
                    if (txtContraseña.Text != txtRepetirContraseña.Text)
                    {
                        MessageBox.Show("La contraseña no coincide en ambos campos.", "Error de alta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        valid = false;
                    }
                }
            }
            return valid;
        }

        private Usuario GetUser()
        {
            Usuario u = null;
            if (DatosValidos())
            {
                u = new Usuario();
                u.ID = User.ID;
                u.NombreUsuario = txtNombreUsuario.Text;
                if (txtContraseña.Text != "")
                    u.Clave = txtContraseña.Text;
                else
                    u.Clave = User.Clave;
                u.Nombre = txtNombre.Text;
                u.Apellido = txtApellido.Text;
                u.Email = txtEmail.Text;
                u.Habilitado = true;
                u.State = BusinessEntity.States.Modified;
            }
            return u;
        }

        public void LoadUser()
        {
            txtNombreUsuario.Text = User.NombreUsuario;
            txtNombre.Text = User.Nombre;
            txtApellido.Text = User.Apellido;
            txtEmail.Text = User.Email;
            chbHabilitado.Checked = User.Habilitado;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
           // this.Close();
           // this.DialogResult = DialogResult.OK;
        }
    }
}
