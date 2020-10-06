using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Curso:BusinessEntity
    {
        public int AnioCalendario { get; set; }
        public int Cupo { get; set; }
        public int IDComision { get; set; }
        public int IDMateria { get; set; }
    }
}
