using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using System.Data.SqlClient;
using System.Data;
using Entidades;

namespace Negocio
{
    public class ComisionLogic : BusinessEntity
    {
        ComisionAdapter comisionData { get; set; }

        public ComisionLogic()
        {
            comisionData = new ComisionAdapter();
        }

        public string DependenciasExistentes(Comision c)
        {
            string dependencias = "";
            CursoLogic cl = new CursoLogic();
            List<Curso> cursos = cl.GetAll();
            cursos = cursos.FindAll(cur => (cur.IDComision == c.ID));
            if (cursos.Count != 0)
                dependencias = dependencias + "cursos";

            
            return dependencias;
        }

        public List<Comision> GetAll()
        {
            return comisionData.GetAll();
        }

        public DataTable GetComisiones()
        {
            return comisionData.GetComisiones();
        }

        public List<Comision> GetListaComisionesPlan(int id_plan)
        {
            List<Comision> comisionPlan = this.GetAll();
            comisionPlan = comisionPlan.FindAll(comision => (comision.IDPlan == id_plan));
            return comisionPlan;
        }

        public Comision GetOne(int id)
        {
            return comisionData.GetOne(id);
        }

        public void Delete(int id)
        {
            comisionData.Delete(id);
        }

        public void Save(Comision c)
        {
            comisionData.Save(c);
        }
    }
}
