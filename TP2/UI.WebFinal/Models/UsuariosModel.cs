using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.WebFinal.Models
{
    public class UsuariosModel
    {
        [Display(Name = "ID")]
        public int id_usuario { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        public string apellido { get; set; }

        public string ApellidoNombre
        {
            get
            {
                return apellido + " " + nombre;
            }

        }


        [Display(Name = "Dirección")]
        public string direccion { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Clave")]
        public string clave { get; set; }

        [Display(Name = "Confirmar clave")]
        [DataType(DataType.Password)]
        public string confirmarClave { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha_nac { get; set; }

        [Display(Name = "Teléfono")]
        public string telefono { get; set; }

        [Required]
        public int id_tipo_persona { get; set; }

        [Display(Name = "Tipo usuario")]
        public string tipo_persona { get; set; }

        [Display(Name = "Legajo")]
        public int legajo { get; set; }

        public int id_plan { get; set; }

        [Display(Name = "Plan")]
        public string desc_plan { get; set; }

        [Display(Name = "Nombre de usuario")]
        public string nombre_usuario { get; set; }

        [Display(Name = "Habilitado")]
        public bool habilitado { get; set; }

        [Display(Name = "Especialidad")]
        public string desc_especialidad { get; set; }

    }
}