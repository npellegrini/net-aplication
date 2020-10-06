using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.WebFinal.Models
{
    public class PlanesModel
    {
        [Display(Name = "ID")]
        public int id_plan { get; set; }

        [Display(Name = "Descripcion")]
        public string desc_plan { get; set; }

        public int id_especialidad { get; set; }

        [Display(Name = "Especialidad")]
        public string desc_especialidad { get; set; }

        public string plan_especialidad
        {
            get
            {
                return desc_especialidad + " - " + desc_plan;
            }
        }
    }
}
