using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.WebFinal.Models;
using Negocio;
using Entidades;

namespace UI.WebFinal.Controllers
{
    public class EspecialidadController : Controller
    {
        // GET: Especialidad
        public ActionResult Index()
        {
            var el = new EspecialidadLogic();
            var especialidades = el.GetAll().Select(x => new EspecialidadModel()
            {
                id_especialidad = x.ID,
                desc_especialidad = x.Descripcion
            });
                             
            return View(especialidades);

        }
    
        public ActionResult Agregar()
        {
            if (Session["nivel"].ToString() == "3")
                return View();
            else
            {
                Session["Message"] = "No tienes suficientes permisos para crear planes.";
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(especialidades e)
        {
            try
            {
                var pl = new EspecialidadLogic();
                var nuevaEsp = new Especialidad { Descripcion = e.desc_especialidad, State = BusinessEntity.States.New };
                pl.Save(nuevaEsp);
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
                    var el = new EspecialidadLogic();
                    var especialidad = el.GetOne(id);
                    var especialidadModel = new EspecialidadModel { id_especialidad = especialidad.ID, desc_especialidad = especialidad.Descripcion};
                    
                    return View(especialidadModel);
                }
                else
                {
                    Session["Message"] = "No tienes suficientes permisos para editar especialidades.";
                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                throw;
            }


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(especialidades e)
        {
            try
            {
       
                    var el = new EspecialidadLogic();
                    var especialidadEditada = new Especialidad { ID = e.id_especialidad, Descripcion = e.desc_especialidad, State = BusinessEntity.States.Modified };
                    el.Save(especialidadEditada);
                    return RedirectToAction("Index");
                
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
                    var el = new EspecialidadLogic();
                    el.Delete(id);
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
    }
}