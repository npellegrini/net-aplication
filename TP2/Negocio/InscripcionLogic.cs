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
    public class InscripcionLogic
    {
        AlumnoInscripcionAdapter AlumnoInscripcionData = new AlumnoInscripcionAdapter();
        public InscripcionLogic()
        {
            AlumnoInscripcionData = new AlumnoInscripcionAdapter();
        }
        public List<AlumnoInscripcion> GetAll(int idAlumno)
        {
            return AlumnoInscripcionData.GetAll(idAlumno);
        }

        public DataTable GetInscripciones(int idAlumno)
        {
            return AlumnoInscripcionData.GetInscripciones(idAlumno);
        }

        public List<AlumnoInscripcion> GetAll()
        {
            return AlumnoInscripcionData.GetAll();
        }

        public AlumnoInscripcion GetOne(int ID)
        {
            return AlumnoInscripcionData.GetOne(ID);
        }

        public void Delete(int id)
        {
            AlumnoInscripcionData.Delete(id);
        }

        public void Save(AlumnoInscripcion ins)
        {
            AlumnoInscripcionData.Save(ins);
        }
    }
}
