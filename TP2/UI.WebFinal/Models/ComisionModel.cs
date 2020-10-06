using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.WebFinal.Models
{
    public class ComisionModel
    {

        [Display(Name = "ID")]
        public int id_comision { get; set; }
        
        [Display (Name = "Descripcion")]
        public string desc_comision { get; set; }
        
        [Display(Name = "Año especialidad")]
        public int anio_especialidad { get; set; }
       
        public int id_plan { get; set; }
        [Display(Name = "Especialidad")]
        public string desc_especialidad { get; set; }
        [Display(Name = "Plan")]
        public string desc_plan { get; set; }

        public string comision_plan
        {
            get
            {
                return desc_comision + " - " + id_plan+ "-" + desc_plan;
            }
        }
    }
}