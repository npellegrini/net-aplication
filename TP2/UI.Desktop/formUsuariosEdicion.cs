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
    public partial class formUsuariosEdicion : Form
    {
        public enum Modos
        {
            Alta,
            Modificacion
        }
        public Modos Modo { get; set; }
        public bool EventosActivados;
        public Usuario Usuario { get; set; }

        public formUsuariosEdicion()
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
                MessageBox.Show("Usuario guardado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
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
                        else
                        {
                            if (Modo == Modos.Alta && txtContraseña.Text == "")
                                camposCompletos = false;
                            else
                            {
                                if (Modo == Modos.Alta && txtRepetirContraseña.Text == "")
                                    camposCompletos = false;
                                else
                                {
                                    if (cmbPlanes.Visible && (cmbPlanes.SelectedValue == null))
                                        camposCompletos = false;
                                    else
                                    {
                                        if (txtLegajo.Visible && (txtLegajo.Text == ""))
                                            camposCompletos = false;
                                        else
                                        {
                                            if (cmbTUsuario.SelectedValue == null)
                                                camposCompletos = false;
                                        }
                                    }
                                }
                            }
                        }
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
                    else
                    {
                        if (txtLegajo.Visible)
                        {
                            int l;
                            bool parseOK = Int32.TryParse(txtLegajo.Text, out l);
                            if (!parseOK)
                            {
                                valid = false;
                                MessageBox.Show("El legajo no debe tener caracteres no numéricos.", "Error de alta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
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
                u.NombreUsuario = txtNombreUsuario.Text;
                if(Modo == Modos.Modificacion)
                {
                    u.State = BusinessEntity.States.Modified;
                    if (txtContraseña.Text == "")
                        u.Clave = Usuario.Clave;
                    else
                        u.Clave = txtContraseña.Text;
                }
                else
                {
                    u.Clave = txtContraseña.Text;
                    u.State = BusinessEntity.States.New;
                }
                u.Nombre = txtNombre.Text;
                u.Apellido = txtApellido.Text;
                u.Email = txtEmail.Text;
                u.Habilitado = chbHabilitado.Checked;
                u.Direccion = txtDireccion.Text;
                u.Telefono = txtTelefono.Text;
                u.Legajo = Int32.Parse(txtLegajo.Text);
                u.IDPlan = (int)cmbPlanes.SelectedValue;
                u.IDTipoPersona = (int)cmbTUsuario.SelectedValue;
                u.FechaNacimiento = dtpFechaNac.Value;

            }
            return u;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void formUsuariosModificacion_Load(object sender, EventArgs e)
        {
            EventosActivados = false;
            FillTiposUsuario();
            FillEspecialidades();
            FillPlanes();

            if (Modo == Modos.Modificacion)
            {
                this.Text = "Modificación de usuario";
                MostrarCampos(Usuario.IDTipoPersona);
                LoadUsuario();
            }
            EventosActivados = true;


        }

        private void FillEspecialidades()
        {
            cmbEspecialidad.DataSource = new EspecialidadLogic().GetAll();
            cmbEspecialidad.DisplayMember = "Descripcion";
            cmbEspecialidad.ValueMember = "ID";
        }

        private void FillTiposUsuario()
        {
            cmbTUsuario.DataSource = new TipoPersonaLogic().GetAll();
            cmbTUsuario.DisplayMember = "Descripcion";
            cmbTUsuario.ValueMember = "ID";
        }

        private void LoadUsuario()
        {
            txtNombreUsuario.Text = Usuario.NombreUsuario;
            txtContraseña.Text = Usuario.Clave;
            dtpFechaNac.Value = Usuario.FechaNacimiento;
            txtNombre.Text = Usuario.Nombre;
            txtApellido.Text = Usuario.Apellido;
            txtEmail.Text = Usuario.Email;
            txtTelefono.Text = Usuario.Telefono;
            txtDireccion.Text = Usuario.Direccion;
            cmbTUsuario.SelectedValue = Usuario.IDTipoPersona;
            if (Usuario.IDTipoPersona != 3)
            {
                txtLegajo.Text = Usuario.Legajo.ToString();
                if (Usuario.IDTipoPersona == 1)
                {
                    cmbEspecialidad.SelectedValue = (new PlanesLogic()).GetOne(Usuario.IDPlan).IDEspecialidad;
                    FillPlanes();
                    cmbPlanes.SelectedValue = Usuario.IDPlan;
                }
            }
        }
        private void MostrarCampos(int tipo_usuario)
        {
            if (tipo_usuario != 1)
            {
                lblEspecialidad.Visible = false;
                cmbEspecialidad.Visible = false;
                lblPlanes.Visible = false;
                cmbPlanes.Visible = false;
            }
            else
            {
                lblEspecialidad.Visible = true;
                cmbEspecialidad.Visible = true;
                lblPlanes.Visible = true;
                cmbPlanes.Visible = true;
            }
            if (tipo_usuario == 3)
            {
                lblLegajo.Visible = false;
                txtLegajo.Visible = false;
            }
            else
            {
                lblLegajo.Visible = true;
                txtLegajo.Visible = true;
            }
        }

        private void cmbTUsuario_SelectedValueChanged(object sender, EventArgs e)
        {
            if (EventosActivados)
                MostrarCampos((int)cmbTUsuario.SelectedValue);
        }

        private void cmbEspecialidad_SelectedValueChanged(object sender, EventArgs e)
        {
            if (EventosActivados)
            {
                if (cmbEspecialidad.SelectedValue != null)
                    FillPlanes();
                else
                {
                    cmbPlanes.SelectedIndex = -1;
                    cmbPlanes.ResetText();
                }
            }
        }

        private void FillPlanes()
        {
            int id;
            bool parseOK = Int32.TryParse(cmbEspecialidad.SelectedValue.ToString(), out id);
            if (parseOK)
            {
                EventosActivados = false;
                PlanesLogic pl = new PlanesLogic();
                cmbPlanes.DataSource = pl.GetPlanesEspecialidad(id);
                cmbPlanes.DisplayMember = "Descripcion";
                EventosActivados = true;
                cmbPlanes.ValueMember = "ID";
            }
            else
                MessageBox.Show("¡Algo salió mal!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }

}
