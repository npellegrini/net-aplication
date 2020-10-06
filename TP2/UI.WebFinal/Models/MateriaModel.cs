using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.WebFinal.Models
{
    public class MateriaModel
    {
        [Display(Name = "ID")]
        public int id_materia { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        public string desc_materia { get; set; }
        [Required]
        [Display(Name = "Horas totales")]
        public int hs_totales { get; set; }
        [Required]
        [Display(Name = "Horas semanales")]
        public int hs_semanales { get; set; }

        public int id_plan { get; set; }
        [Display(Name = "Plan")]
        public string desc_plan { get; set; }

        [Display(Name = "Especialidad")]
        public string desc_especialidad { get; set; }

        public string plan_especialidad
        {
            get
            {
                return desc_especialidad + " - " + desc_plan;
            }
        }

        public string materia_plan
        {
            get
            {
                return desc_materia + " - " + id_plan + "-" + desc_plan;
            }
        }
    }
}