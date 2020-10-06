using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.WebFinal.Models;
using Negocio;
using System.Data;
using Entidades;

namespace UI.WebFinal.Controllers
{
    public class ComisionController : Controller
    {
        // GET: Comision
        public ActionResult Index()
        {
            var cl = new ComisionLogic();
            var dtComisiones = cl.GetComisiones();
            var comisiones = (from DataRow drc in dtComisiones.Rows
                              select new ComisionModel()
                              {
                                  id_comision = (int)drc["id_comision"],
                                  desc_comision = (string)drc["desc_comision"],
                                  anio_especialidad = (int)drc["anio_especialidad"],
                                  desc_especialidad = (string)drc["desc_especialidad"],
                                  desc_plan = (string)drc["desc_plan"],
                                  id_plan = (int)drc["id_plan"]
                              });
            return View(comisiones);
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
                Session["Message"] = "No tienes suficientes permisos para crear comisiones.";
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(ComisionModel comision)
        {

            try
            {
                    var cl = new ComisionLogic();
                    var comisionNueva = new Comision { IDPlan = comision.id_plan, AnioEspecialidad = comision.anio_especialidad, Descripcion = comision.desc_comision, State = BusinessEntity.States.New };
                    cl.Save(comisionNueva);
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
                    var cl = new ComisionLogic();
                    var comision = cl.GetOne(id);
                    var com = new ComisionModel { id_comision = id, desc_comision = comision.Descripcion, anio_especialidad = comision.AnioEspecialidad, id_plan = comision.IDPlan };
                    var pl = new PlanesLogic();
                    var dtPlanes = pl.GetPlanes();
                    ViewBag.Planes = (from DataRow drp in dtPlanes.Rows
                                      select new PlanesModel()
                                      {
                                          id_especialidad = (int)drp["id_especialidad"],
                                          desc_especialidad = (string)drp["desc_especialidad"],
                                          desc_plan = (string)drp["desc_plan"],
                                          id_plan = (int)drp["id_plan"]
                                      });

                    return View(com);

                }
                else
                {
                    Session["Message"] = "No tienes suficientes permisos para editar comisiones.";
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
        public ActionResult Editar(ComisionModel comision)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                else
                {
                    var cl = new ComisionLogic();
                    var comisionEditada = new Comision { IDPlan = comision.id_plan, AnioEspecialidad = comision.anio_especialidad, Descripcion = comision.desc_comision, State = BusinessEntity.States.Modified, ID = comision.id_comision };
                    cl.Save(comisionEditada);
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
                    var cl = new ComisionLogic();
                    cl.Delete(id);
                    return RedirectToAction("Index");
                }
                else
                {
                    Session["Message"] = "No tienes suficientes permisos para eliminar comisiones.";
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}