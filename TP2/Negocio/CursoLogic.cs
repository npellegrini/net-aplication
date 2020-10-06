using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data.Database;
using System.Data;

namespace Negocio
{
    public class CursoLogic : BusinessEntity
    {
        CursoAdapter cursoData { get; set; }

        public CursoLogic()
        {
            cursoData = new CursoAdapter();
        }

        public string DependenciasExistentes(Curso c)
        {
            string dependencias = "";
            InscripcionLogic il = new InscripcionLogic();
            List<AlumnoInscripcion> inscripciones = il.GetAll();
            inscripciones = inscripciones.FindAll(ins => (ins.IDCurso == c.ID));
            if (inscripciones.Count != 0)
                dependencias = dependencias + "inscripciones, ";

            DocenteCursoLogic dcl = new DocenteCursoLogic();
            List<DocenteCurso> dictados = dcl.GetAll();
            dictados = dictados.FindAll(d => (d.IDCurso == c.ID));
            if (dictados.Count != 0)
                dependencias = dependencias + "dictados, ";

            if (dependencias != "")
                dependencias = dependencias.Remove(dependencias.Length - 2, 2);

            return dependencias;
        }
        public bool HayCupo(Curso c)
        {
            int cantInscriptos = cursoData.CountInscriptos(c.ID);
            if (cantInscriptos >= c.Cupo)
                return false;
            else
                return true;
        }

        public bool ValidaPlan(int id_materia, int id_comision)
        {
            Materia m = new MateriaLogic().GetOne(id_materia);
            Comision c = new ComisionLogic().GetOne(id_comision);

            if (m.IDPlan == c.IDPlan)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Curso> GetAll()
        {
            return cursoData.GetAll();
        }

        public DataTable GetCursos()
        {
            return cursoData.GetCursos();
        }

        public DataTable GetCursosPlan(int id_plan)
        {
            return cursoData.GetCursosPlan(id_plan);
        }

        public List<Curso> GetListaCursosPlan(int id_plan, int anio)
        {
            List<Curso> cursosPlan = this.GetAll();
            cursosPlan = cursosPlan.FindAll(curso => (curso.ID == id_plan) && (curso.AnioCalendario == anio));
            return cursosPlan;
        }
        
        public Curso GetOne(int id)
        {
            return cursoData.GetOne(id);
        }

        public Curso GetOne(int idMateria, int idComision, int anio)
        {
            return cursoData.GetOne(idMateria, idComision, anio);
        }

        
        public void Delete(int id)
        {
            cursoData.Delete(id);
        }

        public void Save(Curso c)
        {
            cursoData.Save(c);
        }

        public List<Curso> GetCursosMateria(int idMateria)
        {
            List<Curso> cursosMateria = this.GetAll();
            cursosMateria = cursosMateria.FindAll(curso => (curso.IDMateria == idMateria) && (curso.AnioCalendario == DateTime.Today.Year));
            return cursosMateria;
        }
        public DataTable GetCursosByMateria(int idMateria)
        {
            return cursoData.GetCursosByMateria(idMateria);
        }
    }
}
