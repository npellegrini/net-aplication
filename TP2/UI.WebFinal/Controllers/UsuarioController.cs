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
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            Session["Message"] = "";
            if (Session["nivel"].ToString() == "3")
            {
                var ul = new UsuarioLogic();
                var dtUsuarios = ul.GetUsuarios();
                var usuarios = (from DataRow dru in dtUsuarios.Rows
                                select new UsuariosModel()
                                {
                                    id_usuario = (int)dru["id_usuario"],
                                    nombre = (string)dru["nombre"],
                                    apellido = (string)dru["apellido"],
                                    direccion = (string)dru["direccion"],
                                    email = (string)dru["email"],
                                    telefono = (string)dru["telefono"],
                                    // fecha_nac = dru.Field<DateTime>("fecha_nac"), //NO QUIERE PARSEAR LA FECHA
                                    legajo = (int)dru["legajo"],
                                    tipo_persona = (string)dru["descripcion"],
                                    desc_plan = (string)dru["desc_plan"],
                                    nombre_usuario = (string)dru["nombre_usuario"],
                                    habilitado = (bool)dru["habilitado"],
                                    desc_especialidad = (string)dru["desc_especialidad"]
                                });
                return View(usuarios);
            }
            else
            {
                return RedirectToAction("Editar", new { id = (int)Session["id"] });
            }

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
                var tpl = new TipoPersonaLogic();
                var tipos = tpl.GetAll().Select(x => new TipoPersonaModel()
                {
                    id_tipo_persona = x.ID,
                    descripcion = x.Descripcion
                });
                ViewBag.TiposPersona = tipos;
                return View();
            }
            else
            {
                Session["Message"] = "No tienes suficientes permisos para crear usuarios.";
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(UsuariosModel usu)
        {
            Session["errorEmail"] = "";
            Session["errorUsuario"] = "";
            Session["errorPasswd"] = "";


            try
            {

                var ul = new UsuarioLogic();
                var usuarioNuevo = new Usuario
                {
                    ID = usu.id_usuario,
                    Apellido = usu.apellido,
                    Nombre = usu.nombre,
                    NombreUsuario = usu.nombre_usuario,
                    Clave = usu.clave,
                    Direccion = usu.direccion,
                    Email = usu.email,
                    FechaNacimiento = usu.fecha_nac,
                    Habilitado = usu.habilitado,
                    IDTipoPersona = usu.id_tipo_persona,
                    Telefono = usu.telefono,
                    State = BusinessEntity.States.New
                };
                if (usu.id_tipo_persona == 1)
                {
                    usuarioNuevo.Legajo = usu.legajo;
                    usuarioNuevo.IDPlan = usu.id_plan;
                }
                if (usu.id_tipo_persona == 2)
                {
                    usuarioNuevo.Legajo = usu.legajo;
                }
                bool valid1 = false;
                bool valid2 = false;
                bool valid3 = false;
                if (ul.EmailValido(usuarioNuevo))
                {
                    valid1 = true;
                }
                else
                {
                    //email existe
                    Session["errorEmail"] = "Email existente";
                }
                if (ul.NombreUsuarioValido(usuarioNuevo))
                {
                    valid2 = true;
                }
                else
                {
                    Session["errorUsuario"] = "Usuario existente";
                }
                if (usu.clave == usu.confirmarClave)
                {
                    valid3 = true;
                }
                else
                {
                    Session["errorPasswd"] = "No coinciden las contraseñas";
                }
                if (valid1 && valid2 && valid3)
                {
                    ul.Save(usuarioNuevo);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(usu);
                }


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ActionResult Editar(int id)
        {
            //if (Session["nivel"].ToString() == "3")
            //{
            var ul = new UsuarioLogic();
            Usuario u = ul.GetOne(id);
            var pl = new PlanesLogic();
            var tpl = new TipoPersonaLogic();
            var el = new EspecialidadLogic();
            UsuariosModel um = new UsuariosModel
            {
                id_usuario = u.ID,
                nombre = u.Nombre,
                apellido = u.Apellido,
                direccion = u.Direccion,
                email = u.Email,
                telefono = u.Telefono,
                clave = "",
                fecha_nac = u.FechaNacimiento,
                legajo = u.Legajo,
                id_tipo_persona = u.IDTipoPersona,
                tipo_persona = tpl.GetOne(u.IDTipoPersona).Descripcion,
                id_plan = u.IDPlan,
                desc_plan = pl.GetOne(u.IDPlan).Descripcion,
                nombre_usuario = u.NombreUsuario,
                habilitado = u.Habilitado
            };

            var dtPlanes = pl.GetPlanes();
            ViewBag.Planes = (from DataRow drp in dtPlanes.Rows
                              select new PlanesModel()
                              {
                                  id_especialidad = (int)drp["id_especialidad"],
                                  desc_especialidad = (string)drp["desc_especialidad"],
                                  desc_plan = (string)drp["desc_plan"],
                                  id_plan = (int)drp["id_plan"],
                              });
            var tipos = tpl.GetAll().Select(x => new TipoPersonaModel()
            {
                id_tipo_persona = x.ID,
                descripcion = x.Descripcion
            });
            ViewBag.TiposPersona = tipos;
            return View(um);
            //}

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(UsuariosModel usu)
        {
            try
            {
                if (usu.clave == null)
                {
                    usu.clave = new UsuarioLogic().GetOne(usu.id_usuario).Clave;
                    usu.confirmarClave = usu.clave;
                }
                var ul = new UsuarioLogic();
                var usuarioEditado = new Usuario
                {
                    ID = usu.id_usuario,
                    Apellido = usu.apellido,
                    Nombre = usu.nombre,
                    NombreUsuario = usu.nombre_usuario,
                    Clave = usu.clave,
                    Direccion = usu.direccion,
                    Email = usu.email,
                    FechaNacimiento = usu.fecha_nac,
                    Habilitado = usu.habilitado,
                    IDTipoPersona = usu.id_tipo_persona,
                    Telefono = usu.telefono,
                    State = BusinessEntity.States.Modified
                };
                if (usu.id_tipo_persona == 1)
                {
                    usuarioEditado.Legajo = usu.legajo;
                    usuarioEditado.IDPlan = usu.id_plan;
                }
                if (usu.id_tipo_persona == 2)
                {
                    usuarioEditado.Legajo = usu.legajo;
                }
                bool valid1 = false;
                bool valid2 = false;
                bool valid3 = false;
                if (ul.EmailValido(usuarioEditado))
                {
                    valid1 = true;
                }
                else
                {
                    //email existe
                    Session["errorEmail"] = "Email existente";
                }
                if (ul.NombreUsuarioValido(usuarioEditado))
                {
                    valid2 = true;
                }
                else
                {
                    Session["errorUsuario"] = "Usuario existente";
                }
                if (usu.clave == usu.confirmarClave)
                {
                    valid3 = true;
                }
                else
                {
                    Session["errorPasswd"] = "No coinciden las contraseñas";
                }
                if (valid1 && valid2 && valid3)
                {
                    ul.Save(usuarioEditado);
                    return RedirectToAction("Index");
                }
                else
                {
                    var dtPlanes = new PlanesLogic().GetPlanes();
                    ViewBag.Planes = (from DataRow drp in dtPlanes.Rows
                                      select new PlanesModel()
                                      {
                                          id_especialidad = (int)drp["id_especialidad"],
                                          desc_especialidad = (string)drp["desc_especialidad"],
                                          desc_plan = (string)drp["desc_plan"],
                                          id_plan = (int)drp["id_plan"],
                                      });
                    var tipos = new TipoPersonaLogic().GetAll().Select(x => new TipoPersonaModel()
                    {
                        id_tipo_persona = x.ID,
                        descripcion = x.Descripcion
                    });
                    ViewBag.TiposPersona = tipos;
                    usu.clave = null;
                    return View(usu);
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
                    var ul = new UsuarioLogic();
                    ul.Delete(id);
                    return RedirectToAction("Index");
                }
                else
                {
                    Session["Message"] = "No tienes suficientes permisos para crear usuarios.";
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