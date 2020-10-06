using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Data.Database;
using System.Threading.Tasks;

namespace Negocio
{
    public class EspecialidadLogic : BusinessEntity
    {
        EspecialidadAdapter especialidadData { get; set; }

        public EspecialidadLogic()
        {
            especialidadData = new EspecialidadAdapter();
        }

        public string DependenciasExistentes (Especialidad e)
        {
            string dependencias = "";
            PlanesLogic pl = new PlanesLogic();
            List<Plan> planes = pl.GetAll();
            planes = planes.FindAll(plan => (plan.IDEspecialidad == e.ID));
            if(planes != null)
            {
                dependencias = dependencias + "planes";
            }
            return dependencias;
        }

        public List<Especialidad> GetAll()
        {
            return especialidadData.GetAll();
        }

        public Especialidad GetOne(string descripcion)
        {
            return especialidadData.GetOne(descripcion);
        }

        public Especialidad GetOne(int id)
        {
            return especialidadData.GetOne(id);
        }

        public void Delete(string descripcion)
        {
            especialidadData.Delete(descripcion);
        }

        public void Delete(int id)
        {
            especialidadData.Delete(id);
        }

        public void Save(Especialidad e)
        {
            especialidadData.Save(e);
        }
    }

}
