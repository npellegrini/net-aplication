using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DocenteCurso:BusinessEntity
    {
        public enum TipoCargo
        {
            Titular,
            Auxiliar
        }

        public TipoCargo Cargo { get; set; }
        public int IDCurso { get; set; }
        public int IDDocente { get; set; }
    }
}
