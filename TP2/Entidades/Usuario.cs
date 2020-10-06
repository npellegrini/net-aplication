using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario : BusinessEntity
    {
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IDPlan { get; set; }
        public int Legajo { get; set; }
        public int IDTipoPersona { get; set; }
        public string Clave { get; set; }
        public bool Habilitado { get; set; }
        public string NombreUsuario { get; set; }

        public string ApellidoNombre
        {
            get
            {
                return Apellido + " " + Nombre;
            }
        }
    }
}
