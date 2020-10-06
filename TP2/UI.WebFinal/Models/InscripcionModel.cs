using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace UI.WebFinal.Models
{
    public class InscripcionModel
    {
        [Display(Name = "ID inscripción")]
        public int id_inscripcion { get; set; }
        public int id_curso { get; set; }
        [Display(Name = "Materia")]
        public string desc_materia { get; set; }
        [Display(Name = "Comisión")]
        public string desc_comision { get; set; }
        [Display(Name = "Condición")]
        public int condicion { get; set; }
        [Display(Name = "Nota")]
        public int nota { get; set; }

    }
}