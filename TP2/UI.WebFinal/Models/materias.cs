//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UI.WebFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class materias
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public materias()
        {
            this.cursos = new HashSet<cursos>();
        }
    
        public int id_materia { get; set; }
        [Display(Name = "Descripcion materia")]
        public string desc_materia { get; set; }
        [Display(Name = "Horas semanales")]
        public int hs_semanales { get; set; }
        [Display(Name = "Horas totales")]
        public int hs_totales { get; set; }
        public int id_plan { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cursos> cursos { get; set; }
        public virtual planes planes { get; set; }
    }
}
