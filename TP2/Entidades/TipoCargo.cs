using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoCargo:BusinessEntity
    {
        private int _IDTipoCargo;
        private string _Descripcion;

        public int IDTipoCargo { get; set; }
        public string Descripcion { get; set; }
    }
}
