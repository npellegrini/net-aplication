using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.WebFinal.Models
{
    public class DocenteCursoModel
    {
        [Display(Name = "ID Dictado")]
        public int id_dictado { get; set; }
        [Display(Name = "ID Curso")]
        public int id_curso { get; set; }
        [Display(Name = "Materia")]
        public string materia { get; set; }
        [Display(Name = "ID Docente")]
        public int id_docente { get; set; }
        [Display(Name = "Cargo")]
        public int cargo { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Apellido")]
        public string apellido { get; set; }
        [Display(Name = "Legajo")]
        public int legajo { get; set; }
        [Display(Name = "Docente")]
        public string ApellidoNombre
        {
            get
            {
                return apellido + " " + nombre;
            }

        }

    }
}