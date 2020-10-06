using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.WebFinal.Models
{
    public class CursoModel
    {

        [Display(Name = "ID Curso")]
        public int id_curso { get; set; }
        [Display(Name = "ID Comisión")]
        public int id_comision { get; set; }
        [Display(Name = "Comisión")]
        public string desc_comision { get; set; }
        [Display(Name = "ID Materia:")]
        public int id_materia { get; set; }
        [Display(Name = "Materia")]
        public string desc_materia { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Cupo")]
        public int cupo { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Año Calendario")]
        public int anio_calendario { get; set; }
        [Display(Name = "Especialidad")]
        public string desc_especialidad { get; set; }
        [Display(Name = "Plan")]
        public string desc_plan { get; set; }
        public string materia_comision
        {
            get
            {
                return desc_materia + " - " + desc_comision;
            }
        }
    }
}