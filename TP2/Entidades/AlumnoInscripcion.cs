using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AlumnoInscripcion:BusinessEntity
    {
        public enum Condiciones
        {
            Libre,
            Inscripto,
            Regular,
            Aprobado
        }

        public Condiciones Condicion { get; set; }
        public int IDAlumno { get; set; }
        public int IDCurso { get; set; }
        public int Nota { get; set; }
    }
}
