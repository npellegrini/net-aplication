using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.WebFinal.Models
{
    public class EspecialidadModel
    {
        [Display(Name = "ID")]
        public int id_especialidad { get; set; }
        [Display(Name = "Descripción")]
        public string desc_especialidad { get; set; }
    }
}