using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.WebFinal.Models;

namespace UI.WebFinal.Controllers
{
    public class InscripcionController : Controller
    {

        public ActionResult Index()
        {
            Console.WriteLine(Session);
            Session["Message"] = "";
            if (Session["nivel"].ToString() == "1") // devuelve inscripciones de un alumno
            {
                try
                {    
                var ins = new InscripcionLogic();
                var dtinscripciones = ins.GetInscripciones((int)Session["id"]);
                var inscripciones = (from DataRow dri in dtinscripciones.Rows
                                     select new InscripcionModel()
                                     {
                                         id_inscripcion = (int)dri["id_inscripcion"],
                                         desc_materia = (string)dri["desc_materia"],
                                         desc_comision = (string)dri["desc_comision"],
                                         condicion = (int)dri["condicion"],
                                         nota = (int)dri["nota"]
                                     });
                return View(inscripciones);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de inscripciones del alumno", Ex);
                throw ExcepcionManejada;
            }
        }
            else if (Session["nivel"].ToString() == "3") // devuelve inscripciones de algun alumno para editar o eliminar.
            {
                Session["Message"] = "Proximamente! El Administrador tendra permisos para editar inscripciones.";
                return RedirectToAction("Index", "Home");
            }
            else //si un Docente 
            {
                Session["Message"] = "Debe ser solo Alumnos poseen inscripciones o Administrador tiene permisos para editar.";
                return RedirectToAction("Index", "Home");
            }

        }
        public ActionResult Eliminar(int id)
        {
            if (Session["nivel"].ToString() != "3")
            {
                try
                {

                    var il = new InscripcionLogic();
                    il.Delete(id);
                    return RedirectToAction("Index");


                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Agregar()
        {
            if (Session["nivel"].ToString() == "1")
            {
                try
                {

                    var ul = new UsuarioLogic();
                    int plan_usuario = ul.GetOne((int)Session["id"]).IDPlan;
                    var cl = new CursoLogic();
                    var dtCursos = cl.GetCursosPlan(plan_usuario);
                    ViewBag.Cursos = (from DataRow drc in dtCursos.Rows
                                      select new CursoModel()
                                      {
                                          id_curso = (int)drc["id_curso"],
                                          id_comision = (int)drc["id_comision"],
                                          desc_comision = (string)drc["desc_comision"],
                                          id_materia = (int)drc["id_materia"],
                                          desc_materia = (string)drc["desc_materia"],
                                          cupo = (int)drc["cupo"]
                                      });
                    return View();

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
            {
                Session["Message"] = "No tienes suficientes permisos para crear Inscriciones.";
                return RedirectToAction("Index", "Home");
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(InscripcionModel inscripcion)
        {
            try
            {
                var il = new InscripcionLogic();
                var inscripcionNueva = new AlumnoInscripcion { IDAlumno = (int)Session["id"], IDCurso = inscripcion.id_curso, Condicion = AlumnoInscripcion.Condiciones.Inscripto, Nota = 0, State = BusinessEntity.States.New };
                il.Save(inscripcionNueva);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ActionResult Editar(int id)
        {
            if (Session["Nivel"].ToString() == "1")
            {
                try
                {
                    var ins = new InscripcionLogic();
                    var dtinscripciones = ins.GetInscripciones((int)Session["id"]);
                    var inscripciones = (from DataRow dri in dtinscripciones.Rows
                                         select new InscripcionModel()
                                         {
                                             id_inscripcion = (int)dri["id_inscripcion"],
                                             desc_materia = (string)dri["desc_materia"],
                                             desc_comision = (string)dri["desc_comision"],
                                             condicion = (int)dri["condicion"],
                                             nota = (int)dri["nota"]
                                         });
                    return View(inscripciones);



                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            else
            {
                Session["Message"] = "No tenes permiso para editar Inscripciones.";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}

