using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.WebFinal.Models;
using Negocio;
using System.Data;
using Entidades;
using Rotativa;

namespace UI.WebFinal.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        public ActionResult Index()
        {

            var ml = new MateriaLogic();
            var dtMaterias = ml.GetMaterias();
            var materias = (from DataRow drm in dtMaterias.Rows
                            select new MateriaModel()
                            {
                                id_materia = (int)drm["id_materia"],
                                desc_materia = (string)drm["desc_materia"],
                                hs_semanales = (int)drm["hs_semanales"],
                                hs_totales = (int)drm["hs_totales"],
                                desc_plan = (string)drm["desc_plan"],
                                desc_especialidad = (string)drm["desc_especialidad"]
                            });
            return View(materias);


        }
        public ActionResult Agregar()
        {
            if (Session["nivel"].ToString() == "3")
            {

                var pl = new PlanesLogic();
                var dtPlanes = pl.GetPlanes();
                ViewBag.Planes = (from DataRow drp in dtPlanes.Rows
                                  select new PlanesModel()
                                  {
                                      id_especialidad = (int)drp["id_especialidad"],
                                      desc_especialidad = (string)drp["desc_especialidad"],
                                      desc_plan = (string)drp["desc_plan"],
                                      id_plan = (int)drp["id_plan"],
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
        public ActionResult Agregar(MateriaModel materia)
        {
            try
            {
                var ml = new MateriaLogic();
                var materiaNueva = new Materia { IDPlan = materia.id_plan, HSSemanales = materia.hs_semanales, HSTotales = materia.hs_totales, Descripcion = materia.desc_materia, State = BusinessEntity.States.New };
                ml.Save(materiaNueva);
                return RedirectToAction("Index");
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
                    var materia = ml.GetOne(id);
                    var mat = new MateriaModel { id_materia = materia.ID, desc_materia = materia.Descripcion, hs_semanales = materia.HSSemanales, hs_totales = materia.HSTotales };
                    var pl = new PlanesLogic();
                    var dtPlanes = pl.GetPlanes();
                    ViewBag.Planes = (from DataRow drp in dtPlanes.Rows
                                      select new PlanesModel()
                                      {
                                          id_especialidad = (int)drp["id_especialidad"],
                                          desc_especialidad = (string)drp["desc_especialidad"],
                                          desc_plan = (string)drp["desc_plan"],
                                          id_plan = (int)drp["id_plan"],
                                      });
                    return View(mat);
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

        [HttpPost]
        public ActionResult Editar(MateriaModel materia)
        {
            try
            {
                if ( Session["nivel"].ToString()== "3")
                {
                    var ml = new MateriaLogic();
                    var materiaEditada = new Materia { HSTotales = materia.hs_totales, HSSemanales = materia.hs_semanales, Descripcion = materia.desc_materia, State = BusinessEntity.States.Modified, ID = materia.id_materia, IDPlan = materia.id_plan };
                    ml.Save(materiaEditada);
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
       
        public ActionResult Eliminar(int id)
        {
            try
            {

                if (Session["nivel"].ToString() == "3")
                {
                    var ml = new MateriaLogic();
                    ml.Delete(id);
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
        public ActionResult ListarMateriasPlanesEspecialidadPDF()
        {
            var ml = new MateriaLogic();
            var dtMaterias = ml.GetMaterias();
            var materias = (from DataRow drm in dtMaterias.Rows
                            select new MateriaModel()
                            {
                                id_materia = (int)drm["id_materia"],
                                desc_materia = (string)drm["desc_materia"],
                                hs_semanales = (int)drm["hs_semanales"],
                                hs_totales = (int)drm["hs_totales"],
                                desc_plan = (string)drm["desc_plan"],
                                desc_especialidad = (string)drm["desc_especialidad"]
                            });
            return View(materias);

        }

        public ActionResult ExportarPDF()
        {
            return new ActionAsPdf("ListarMateriasPlanesEspecialidadPDF")
            {
                FileName = "ListadoMaterias.pdf"
            };

        }
    }
}