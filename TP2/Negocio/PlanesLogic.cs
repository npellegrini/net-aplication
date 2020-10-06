using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Negocio;
using Data.Database;
using System.Data;

namespace Negocio
{
    public class PlanesLogic :BusinessEntity
    {   
        PlanAdapter PlanesData { get; set; }

        public PlanesLogic()
        {
            PlanesData = new PlanAdapter();
        }

        public string DependenciasExistentes(Plan p)
        {
            string dependencias = "";
            MateriaLogic ml = new MateriaLogic();
            List<Materia> materias = ml.GetAll();
            materias = materias.FindAll(m => (m.IDPlan == p.ID));
            if (materias.Count != 0)
                dependencias = dependencias + "materias, ";
            
            ComisionLogic cl = new ComisionLogic();
            List<Comision> comisiones = cl.GetListaComisionesPlan(p.ID);
            if (comisiones.Count != 0)
                dependencias = dependencias + "comisiones, ";

            UsuarioLogic ul = new UsuarioLogic();
            List<Usuario> usuarios = ul.GetAll();
            usuarios = usuarios.FindAll(u => (u.IDPlan == p.ID));
            if (usuarios.Count != 0)
                dependencias = dependencias + "usuarios, ";

            if(dependencias != "")
                dependencias = dependencias.Remove(dependencias.Length-2, 2);

            return dependencias;
        }

        public List<Plan> GetAll()
        {
            return PlanesData.GetAll();
        }

        public DataTable GetPlanes()
        {
            return PlanesData.GetPlanes();
        }

        public Plan GetOne(int id)
        {
            return PlanesData.GetOne(id);
        }

        public void Delete(int id)
        {
            PlanesData.Delete(id);
        }

        public void Save(Plan p)
        {
            PlanesData.Save(p);
        }

        public List<Plan> GetPlanesEspecialidad(int id)
        {
            List<Plan> planesEspecialidad = this.GetAll();
            planesEspecialidad = planesEspecialidad.FindAll(plan => (plan.IDEspecialidad == id));
            return planesEspecialidad;
        }
    
    }
}
