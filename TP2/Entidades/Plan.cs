using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Plan: BusinessEntity
    {
        public string Descripcion { get; set; }
        public int IDEspecialidad { get; set; }
    }
}
