using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.WebFinal.Models
{
    public class AlumnoInscripcionModel
    {
        [Display(Name = "ID Inscripción:")]
        public int id_inscripcion { get; set; }
        [Display(Name = "Legajo:")]
        public int legajo { get; set; }
        [Display(Name = "Condicion:")]
        public int condicion { get; set; }
        [Display(Name = "Nota:")]
        public int nota { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        [Display(Name = "Alumno:")]
        public string nombre_Apellido
        {
            get
            {
                return nombre + " - " + apellido;
            }
        }
    }
}