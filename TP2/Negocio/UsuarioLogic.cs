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
    public class UsuarioLogic: BusinessEntity
    {

        UsuarioAdapter UsuarioData { get; set; }

        public UsuarioLogic()
        {
            UsuarioData = new UsuarioAdapter();
        }

        public string DependenciasExistentes(Usuario u)
        {
            string dependencias = "";
            InscripcionLogic il = new InscripcionLogic();
            List<AlumnoInscripcion> inscripciones = il.GetAll();
            inscripciones = inscripciones.FindAll(ins => (ins.IDAlumno == u.ID));
            if (inscripciones.Count != 0)
                dependencias = dependencias + "inscripciones, ";

            DocenteCursoLogic dcl = new DocenteCursoLogic();
            List<DocenteCurso> dictados = dcl.GetAll();
            dictados = dictados.FindAll(d => (d.IDDocente == u.ID));
            if (dictados.Count != 0)
                dependencias = dependencias + "dictados, ";

            if (dependencias != "")
                dependencias = dependencias.Remove(dependencias.Length - 2, 2);

            return dependencias;
        }

        public List<Usuario> GetAll()
        {
            return UsuarioData.GetAll();
        }

        public DataTable GetUsuarios()
        {
            return UsuarioData.GetUsuarios();
        }

        public List<Usuario> GetDocentes()
        {
            List<Usuario> docentes = this.GetAll();
            docentes = docentes.FindAll(d => (d.IDTipoPersona == 2));
            return docentes;
        }

        public bool EmailValido(Usuario u)
        {
            Usuario existente = UsuarioData.GetOneByEmail(u.Email);
            if (existente.ID == 0 || existente.ID == u.ID)
                return true;
            else
                return false;
        }

        public bool NombreUsuarioValido(Usuario u)
        {
            Usuario existente = UsuarioData.GetOneByNombreUsuario(u.NombreUsuario);
            if (existente.ID == 0 || existente.ID == u.ID)
                return true;
            else
                return false;
        }

        public Usuario GetOne(int id)
        {
            return UsuarioData.GetOne(id);
        }

        public Usuario GetOneByEmail(string email)
        {
            return UsuarioData.GetOneByEmail(email);
        }

        public Usuario GetOneByNombreUsuario(string nombreUsuario)
        {
            return UsuarioData.GetOneByNombreUsuario(nombreUsuario);
        }

        public void Delete (int id)
        {
            UsuarioData.Delete(id);
        }

        public void Save (Usuario u)
        {
            UsuarioData.Save(u);
        }


    }
}
