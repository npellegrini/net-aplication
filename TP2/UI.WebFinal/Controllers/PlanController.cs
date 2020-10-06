using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.WebFinal.Models;
using Negocio;
using Entidades;
using System.Data;
using Rotativa;

namespace UI.WebFinal.Controllers
{
    public class PlanController : Controller
    {
        public ActionResult Index()
        {
            var pl = new PlanesLogic();
            var dtplanes = pl.GetPlanes();
            var planes = (from DataRow drp in dtplanes.Rows
                          select new PlanesModel()
                          {
                              desc_plan = (string)drp["desc_plan"],
                              desc_especialidad = (string)drp["desc_especialidad"],
                              id_plan = (int)drp["id_plan"],
                          });
            return View(planes);
        }
        public ActionResult Agregar()
        {
            if (Session["nivel"].ToString() == "3")
            {
                var el = new EspecialidadLogic();
                var especialidades = el.GetAll().Select(x => new EspecialidadModel()
                {
                    id_especialidad = x.ID,
                    desc_especialidad = x.Descripcion
                });
                ViewBag.Especialidades = especialidades;
                return View();
            }
            else
            {
                Session["Message"] = "No tienes suficientes permisos para crear planes.";
                return RedirectToAction("Index", "Home");
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(PlanesModel plan)
        {

            try
            {
                var pl = new PlanesLogic();
                var nuevoPlan = new Plan { Descripcion = plan.desc_plan, IDEspecialidad = plan.id_especialidad, State = BusinessEntity.States.New };
                pl.Save(nuevoPlan);
                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al crear el plan -" + ex.Message);
                return View();
            }



        }

        public ActionResult Editar(int id)
        {
            try
            {
                if (Session["nivel"].ToString() == "3")
                {
                    var pl = new PlanesLogic();
                    var plan = pl.GetOne(id);
                    var planModel = new PlanesModel { id_plan = plan.ID, id_especialidad = plan.IDEspecialidad, desc_plan = plan.Descripcion };
                    var el = new EspecialidadLogic();
                    var especialidades = el.GetAll().Select(x => new EspecialidadModel()
                    {
                        id_especialidad = x.ID,
                        desc_especialidad = x.Descripcion
                    });
                    ViewBag.Especialidades = especialidades;

                    return View(planModel);
                }
                else
                {
                    Session["Message"] = "No tienes suficientes permisos para editar planes.";
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(PlanesModel plan)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                else
                {
                    var pl = new PlanesLogic();
                    var planEditado = new Plan { ID = plan.id_plan, Descripcion = plan.desc_plan, IDEspecialidad = plan.id_especialidad, State = BusinessEntity.States.Modified };
                    pl.Save(planEditado);
                    return RedirectToAction("Index");
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
                    var pl = new PlanesLogic();
                    pl.Delete(id);
                    return RedirectToAction("Index");
                }
                else
                {
                    Session["Message"] = "No tienes suficientes permisos para eliminar planes.";
                    return RedirectToAction("Index", "Home");
                }
            }

            catch (Exception ex)
            {

                throw;
            }
        }

        public ActionResult ListarPlanesPDF()
        {
            var pl = new PlanesLogic();
            var dtplanes = pl.GetPlanes();
            var planes = (from DataRow drp in dtplanes.Rows
                          select new PlanesModel()
                          {
                              desc_plan = (string)drp["desc_plan"],
                              desc_especialidad = (string)drp["desc_especialidad"],
                              id_plan = (int)drp["id_plan"],
                          });
            return View(planes);
        }

        public ActionResult ExportarPDF()
        {
            return new ActionAsPdf("ListarPlanesPDF")
            {
                FileName = "ListadoPlanes.pdf"
            };

        }
    }
}