using Data.Database;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MateriaLogic
    {
        MateriaAdapter materiaData { get; set; }

        public MateriaLogic()
        {
            materiaData = new MateriaAdapter();
        }

        public string DependenciasExistentes(Materia m)
        {
            string dependencias = "";
            CursoLogic cl = new CursoLogic();
            List<Curso> cursos = cl.GetAll();
            cursos = cursos.FindAll(cur => (cur.IDMateria == m.ID));
            if (cursos.Count != 0)
                dependencias = dependencias + "cursos";


            return dependencias;
        }

        public List<Materia> GetAll()
        {
            return materiaData.GetAll();
        }

        public DataTable GetMaterias()
        {
            return materiaData.GetMaterias();
        }

        public List<Materia> GetListaMateriasPlan(int id_plan)
        {
            List<Materia> materiasPlan = this.GetAll();
            materiasPlan = materiasPlan.FindAll(materia => (materia.IDPlan == id_plan));
            return materiasPlan;
        }

        public Materia GetOne(int id)
        {
            return materiaData.GetOne(id);
        }

        public void Delete(int id)
        {
            materiaData.Delete(id);
        }

        public void Save(Materia m)
        {
            materiaData.Save(m);
        }
    }
}
