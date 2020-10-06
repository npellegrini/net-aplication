using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data.Database;

namespace Negocio
{
    public class TipoPersonaLogic
    {
        public List<TipoPersona> GetAll()
        {
            TipoPersonaAdapter tpa = new TipoPersonaAdapter();
            return tpa.GetAll();
        }

        public TipoPersona GetOne(int id)
        {
            TipoPersonaAdapter tpa = new TipoPersonaAdapter();
            return tpa.GetOne(id);
        }
    }
}
