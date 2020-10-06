using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rotativa;
using UI.WebFinal.Models;

namespace UI.WebFinal.Controllers
{
    public class CursoController : Controller
    {
        public ActionResult Index()
        {
            Session["Message"] = "";
            if (Session["nivel"].ToString() == "3")
            {
                var cl = new CursoLogic();
                var dtCursos = cl.GetCursos();
                var cursos = (from DataRow drc in dtCursos.Rows
                              select new CursoModel()
                              {
                                  id_comision = (int)drc["id_comision"],
                                  id_curso = (int)drc["id_curso"],
                                  desc_comision = (string)drc["desc_comision"],
                                  id_materia = (int)drc["id_materia"],
                                  desc_materia = (string)drc["desc_materia"],
                                  anio_calendario = (int)drc["anio_calendario"],
                                  cupo = (int)drc["cupo"],
                                  desc_especialidad = (string)drc["desc_especialidad"],
                                  desc_plan = (string)drc["desc_plan"]

                              });
                return View(cursos);
            }
            else
            {
                Session["Message"] = "No tienes suficientes permisos para ver cursos.";
                return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult Agregar()
        {
            if (Session["nivel"].ToString() == "3")
            {
                var ml = new MateriaLogic();
                var dtMaterias = ml.GetMaterias();
                ViewBag.Materias = (from DataRow drm in dtMaterias.Rows
                                    select new MateriaModel()
                                    {
                                        id_materia = (int)drm["id_materia"],
                                        desc_materia = (string)drm["desc_materia"],
                                        id_plan = (int)drm["id_plan"],
                                        desc_plan = (string)drm["desc_plan"]
                                    });
                var cl = new ComisionLogic();
                var dtComisiones = cl.GetComisiones();
                ViewBag.Comisiones = (from DataRow drc in dtComisiones.Rows
                                      select new ComisionModel()
                                      {
                                          id_comision = (int)drc["id_comision"],
                                          desc_comision = (string)drc["desc_comision"],
                                          anio_especialidad = (int)drc["anio_especialidad"],
                                          desc_especialidad = (string)drc["desc_especialidad"],
                                          desc_plan = (string)drc["desc_plan"],
                                          id_plan = (int)drc["id_plan"],
                                      });


                return View();

            }
            else
            {
                Session["Message"] = "No tienes suficientes permisos para crear materias.";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(CursoModel curso)
        {
            try
            {
                var cl = new CursoLogic();
                if (cl.ValidaPlan(curso.id_materia, curso.id_comision))
                {
                    var nuevoCurso = new Curso { IDComision = curso.id_comision, IDMateria = curso.id_materia, AnioCalendario = curso.anio_calendario, Cupo = curso.cupo, State = BusinessEntity.States.New };
                    cl.Save(nuevoCurso);
                    Session["Message"] = "Curso creado exitosamente";
                    return RedirectToAction("Index");
                }
                else
                {
                    Session["Message"] = "No se puede crear el curso, la materia y la comision no pertenecen al mismo plan.";
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public ActionResult Editar(int id)
        {
            try
            {
                if (Session["nivel"].ToString() == "3")
                {
                    var ml = new MateriaLogic();
                    var dtMaterias = ml.GetMaterias();
                    ViewBag.Materias = (from DataRow drm in dtMaterias.Rows
                                        select new MateriaModel()
                                        {
                                            id_materia = (int)drm["id_materia"],
                                            desc_materia = (string)drm["desc_materia"],
                                            id_plan = (int)drm["id_plan"],
                                            desc_plan = (string)drm["desc_plan"]
                                        });
                    var cl = new ComisionLogic();
                    var dtComisiones = cl.GetComisiones();
                    ViewBag.Comisiones = (from DataRow drc in dtComisiones.Rows
                                          select new ComisionModel()
                                          {
                                              id_comision = (int)drc["id_comision"],
                                              desc_comision = (string)drc["desc_comision"],
                                              anio_especialidad = (int)drc["anio_especialidad"],
                                              desc_especialidad = (string)drc["desc_especialidad"],
                                              desc_plan = (string)drc["desc_plan"],
                                              id_plan = (int)drc["id_plan"],
                                          });
                    var curso = new CursoLogic().GetOne(id);
                    var cursoModel = new CursoModel { anio_calendario = curso.AnioCalendario, cupo = curso.Cupo, id_comision = curso.IDComision, id_materia = curso.IDMateria, id_curso = curso.ID };
                    return View(cursoModel);
                }
                else
                {
                    Session["Message"] = "No tienes suficientes permisos para editar cursos.";
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception ex)
            {

                throw;
            }


        }

        [HttpPost]
        public ActionResult Editar(CursoModel curso)
        {
            try
            {
                if (Session["nivel"].ToString() == "3")
                {
                    var cl = new CursoLogic();
                    var cursoEditado = new Curso { Cupo = curso.cupo, IDComision = curso.id_comision, AnioCalendario = curso.anio_calendario, IDMateria = curso.id_materia, State = BusinessEntity.States.Modified, ID = curso.id_curso };
                    cl.Save(cursoEditado);
                    Session["Message"] = "Curso creado exitosamente!.";
                    return RedirectToAction("Index");
                }
                else
                {
                    Session["Message"] = "No tienes suficientes permisos para editar cursos.";
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public ActionResult Eliminar(int id)
        {
            try
            {

                if (Session["nivel"].ToString() == "3")
                {
                    var cl = new CursoLogic();
                    cl.Delete(id);
                    return RedirectToAction("Index");
                }
                else
                {
                    Session["Message"] = "No tienes suficientes permisos para editar materias.";
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public ActionResult ListadoCursosPDF(int idCurso)
        {

            var cl = new DocenteCursoLogic();
            var dtAlumnosCurso = cl.GetAlumnosCursos(idCurso);
            var almunos = (from DataRow drd in dtAlumnosCurso.Rows
                           select new AlumnoInscripcionModel()
                           {
                               id_inscripcion = (int)drd["id_inscripcion"],
                               legajo = (int)drd["legajo"],
                               condicion = (int)drd["condicion"],
                               nota = (int)drd["nota"],
                               nombre = (string)drd["nombre"],
                               apellido = (string)drd["apellido"]
                           });
            return View(almunos);
        }
        public ActionResult ExportPdf(int id)
        {
            return new ActionAsPdf("ListadoCursosPDF", new { idCurso = id })
            {
                FileName = "ListadoCursos.pdf"
            };
        }


    }
}