using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ModuloUsuario:BusinessEntity
    {
        private int _IDModulo, _IDUsuario;
        private bool _PermiteBaja, _PermiteAlta, _PermiteConsulta, _PermiteModificacion;

        public int IDModulo { get; set; }
        public int IDUsuario { get; set; }
        public bool PermiteAlta { get; set; }
        public bool PermiteBaja { get; set; }
        public bool PermiteConsulta { get; set; }
        public bool PermiteModificacion { get; set; }
    }
}
