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
using Util;
using Entidades;

namespace UI.Desktop
{
    public partial class formLogin : Form
    {
        public Usuario User { get; set; }
        public formLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            var usuarioLogic = new UsuarioLogic();
            var u = txtUser.Text;
            var tv = new TextValidator();
            Usuario user = new Usuario();
            bool usuarioValido = false;

            if (u.Contains("@"))
            {
                if (tv.IsValidEmail(u))
                {
                    user = usuarioLogic.GetOneByEmail(txtUser.Text);
                    if (u == user.Email)
                        usuarioValido = true;
                    else
                        MessageBox.Show("Email no existe.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                    MessageBox.Show("Email con formato incorrecto.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                user = usuarioLogic.GetOneByNombreUsuario(txtUser.Text);
                if (u == user.NombreUsuario)
                    usuarioValido = true;
                else
                    MessageBox.Show("El nombre de usuario ingresado no existe.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (usuarioValido)
            {
                if (txtPass.Text == user.Clave)// todo exitoso!
                {
                    if (user.IDTipoPersona != 3)
                    {
                        usuarioValido = false;
                        MessageBox.Show("No posee los permisos suficientes para ingresar.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        MessageBox.Show("¡Log in exitoso!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        User = user;
                        this.Close();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
         
        }


        private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria", "Olvidé mi contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void formLogin_Load(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


