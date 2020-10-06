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
    public class DocenteCursoLogic : BusinessEntity
    {
        DocenteCursoAdapter dcData { get; set; }

        public DocenteCursoLogic()
        {
            dcData = new DocenteCursoAdapter();
        }

        public bool ExisteDictado(int id_docente, int id_curso, DocenteCurso.TipoCargo cargo)
        {
            if (this.GetOne(id_docente, id_curso, cargo) != null)
                return true;
            else
                return false;
        }
        public void Save(DocenteCurso dc)
        {
            dcData.Save(dc);
        }

        public DocenteCurso GetOne(int id)
        {
            return dcData.GetOne(id);
        }

        public DocenteCurso GetOne(int id_docente, int id_curso, DocenteCurso.TipoCargo cargo)
        {
            return dcData.GetOne(id_docente, id_curso, cargo);
        }

        public List<DocenteCurso> GetAll()
        {
            return dcData.GetAll();
            
        }
        public DataTable GetDocentesCurso(int id_curso)
        {
            return dcData.GetDocentesCurso(id_curso);
        }
        public DataTable GetAlumnosCursos(int id_curso)
        {
            return dcData.GetAlumnosCurso(id_curso);
        }
        public DataTable GetCursosDocente(int id_docente)
        {
            return dcData.GetCursosDocente(id_docente);
        }
        public void Delete(int id)
        {
            dcData.Delete(id);
        }
    }
}
