using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UI.Desktop;

namespace UI.WebFinal.Models
{
    public class UserLogin
    {
        public int id_usuario { get; set; }
        [Required]
        [Display(Name ="Nombre de usuario")]
        public string nombre_usuario { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        public string clave { get; set; }
        public bool habilitado { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public Nullable<int> idNivel { get; set; }


        AcademicaDS db = new AcademicaDS();
        

        public bool login()
        {
            var query = from u in db.usuarios
                        where u.nombre_usuario == nombre_usuario && u.clave == clave
                        select u;
            if (query.Count() > 0)
            {
                var query2 = from u in db.usuarios where u.nombre_usuario == nombre_usuario select u;
                var datos = query2.ToList();
                foreach (var data in datos)
                {
                    nombre_usuario = data.nombre_usuario;
                }
                return true;
            }
            else
            {
                return false;
            }
            //return true;
        }
    }
}