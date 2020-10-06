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
    public class DocenteCursoController : Controller
    {
        // GET: DocenteCurso
        public ActionResult Index(int id)
        {
            Session["id_curso"] = id;
            var dcl = new DocenteCursoLogic();
            var dtDocentesCurso = dcl.GetDocentesCurso(id);
            var docentes = (from DataRow drd in dtDocentesCurso.Rows
                            select new DocenteCursoModel()
                            {
                                id_dictado = (int)drd["id_dictado"],
                                id_curso = (int)drd["id_curso"],
                                cargo = (int)drd["cargo"],
                                nombre = (string)drd["nombre"],
                                apellido = (string)drd["apellido"],
                                legajo = (int)drd["legajo"],
                                materia = (string)drd["desc_materia"]
                            });
            return View(docentes);
        }

        public ActionResult MisCursos()
        {
            Session["Message"] = "";
            if (Session["nivel"].ToString() == "2")
            {
                var cl = new DocenteCursoLogic();
                var dtDocentesCurso = cl.GetCursosDocente((int)Session["id"]);
                var cursos = (from DataRow drd in dtDocentesCurso.Rows
                              select new DocenteCursoModel()
                              {
                                  id_dictado = (int)drd["id_dictado"],
                                  id_curso = (int)drd["id_curso"],
                                  id_docente = (int)drd["id_docente"],
                                  cargo = (int)drd["cargo"],
                                  nombre = (string)drd["nombre"],
                                  apellido = (string)drd["apellido"],
                                  materia = (string)drd["desc_materia"]

                              });
                return View(cursos);
            }
            else
            {
                Session["Message"] = "No tienes suficientes permisos para ver cursos.";
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult MisAlumnosCurso(int id)
        {
            Session["Message"] = "";
            if (Session["nivel"].ToString() == "2")
            {
                var cl = new DocenteCursoLogic();
                Session["id_curso"] = id;
                var dtAlumnosCurso = cl.GetAlumnosCursos(id);
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
            else
            {
                Session["Message"] = "No tienes suficientes permisos para ver cursos.";
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult AgregarDocente(int id)
        {
            var dictado = new DocenteCursoModel { id_curso = id };
            var ul = new UsuarioLogic();
            ViewBag.Docentes = ul.GetDocentes().Select(x => new UsuariosModel()
            {
                nombre = x.Nombre,
                apellido = x.Apellido,
                id_usuario = x.ID,
            });

           // ViewBag.Cargos = Enum.GetValues(typeof(DocenteCurso.TipoCargo));
            var cargs = Enum.GetValues(typeof(DocenteCurso.TipoCargo));
            //var condicion { id, desc};

            List<SelectListItem> itemsCombo = new List<SelectListItem>();
            foreach (DocenteCurso.TipoCargo item in cargs)
            {
                SelectListItem cargos = new SelectListItem();
                cargos.Value = ((int)item).ToString();
                cargos.Text = item.ToString();
                itemsCombo.Add(cargos);
            }
            ViewBag.Cargos = itemsCombo;
            return View(dictado);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarDocente(DocenteCursoModel docenteCurso)
        {
            Session["error"] = "";
            {
                try
                {
                    var dcl = new DocenteCursoLogic();
                    DocenteCurso.TipoCargo cargo = (DocenteCurso.TipoCargo)docenteCurso.cargo;
                    var nuevoDictado = new DocenteCurso
                    {
                        Cargo = cargo,
                        IDCurso = docenteCurso.id_curso,
                        IDDocente = docenteCurso.id_docente,
                        State = BusinessEntity.States.New
                    };
                    var id_curso = Session["id_curso"];
                    if (!dcl.ExisteDictado(nuevoDictado.IDDocente, nuevoDictado.IDCurso, nuevoDictado.Cargo))
                    {
                        dcl.Save(nuevoDictado);
                        return RedirectToAction("Index", new { id = id_curso });
                    }
                    else
                    {
                        Session["error"] = "Ya existe el dictado";
                        return RedirectToAction("AgregarDocente", new { id = id_curso });

                    }
                    

                }

                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al crear el Dictado -" + ex.Message);
                    return View();
                }
            }
        }

        public ActionResult CargarNota(int id)
        {
            var il = new InscripcionLogic();
            var inscripcionAlumno = il.GetOne(id);
            var inscripcionModel = new InscripcionModel { nota = inscripcionAlumno.Nota, id_inscripcion = inscripcionAlumno.ID, condicion = (int)inscripcionAlumno.Condicion };
            //ViewBag.Condiciones = Enum.GetValues(typeof(AlumnoInscripcion.Condiciones));
            var conds = Enum.GetValues(typeof(AlumnoInscripcion.Condiciones));
            //var condicion { id, desc};
            
            List<SelectListItem> itemsCombo = new List<SelectListItem>();
            foreach (AlumnoInscripcion.Condiciones item in conds)
            {
                SelectListItem condicion = new SelectListItem();
                condicion.Value = ((int)item).ToString();
                condicion.Text = item.ToString();
                itemsCombo.Add(condicion);
            }
            ViewBag.Condiciones = itemsCombo;
            return View(inscripcionModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CargarNota(InscripcionModel inscripcion)
        {
            try
            {
                var dcl = new InscripcionLogic();
                //AlumnoInscripcion.Condiciones condicion = (AlumnoInscripcion.Condiciones)inscripcion.condicion;
                //var actualizanota = new AlumnoInscripcion { ID= inscripcion.id_inscripcion, State = BusinessEntity.States.Modified, Nota = inscripcion.nota, Condicion = condicion };
                var actualizanota = new AlumnoInscripcion { ID = inscripcion.id_inscripcion, State = BusinessEntity.States.Modified, Nota = inscripcion.nota, Condicion = (AlumnoInscripcion.Condiciones)inscripcion.condicion };
                dcl.Save(actualizanota);
                return RedirectToAction("Index");
            }
            

            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al actualizar -" + ex.Message);
                return View();
            }

        }
        public ActionResult Eliminar(int id)
        {
            try
            {
                foreach (string key in Session.Contents)
                {
                    string value = "Key: " + key + ", Value: " + Session[key].ToString();

                    Response.Write(value);
                }

                if (Session["nivel"].ToString() == "3")
                {
                    var dcl = new DocenteCursoLogic();
                    dcl.Delete(id);
                    return RedirectToAction("Index", new { id = (int)Session["id_curso"] });
                }
                else
                {
                    Session["Message"] = "No tienes suficientes permisos para eliminar dictados.";
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult ActualizaNota(int idInscripcion, int nota)
        {
            try
            {
                var dcl = new InscripcionLogic();
                //AlumnoInscripcion.Condiciones condicion = (AlumnoInscripcion.Condiciones)inscripcion.condicion;
                //var actualizanota = new AlumnoInscripcion { ID= inscripcion.id_inscripcion, State = BusinessEntity.States.Modified, Nota = inscripcion.nota, Condicion = condicion };
                var actualizanota = new AlumnoInscripcion { ID = idInscripcion, State = BusinessEntity.States.Modified, Nota = nota};
                dcl.Save(actualizanota);
                return Json("Exito");
            }


            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al actualizar -" + ex.Message);
                return Json("Error al actualizar -" + ex.Message);
            }

        }
    }
}