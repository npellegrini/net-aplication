using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UI.WebFinal.Models;
using Negocio;
using Entidades;

namespace UI.WebFinal.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        /*[AllowAnonymous]
        public ActionResult Usuarios()
        {
            return View("Index");
        }*/

        [HttpPost]
        [AllowAnonymous]
        public  ActionResult Usuarios()
        {
            var usuarioLogic = new UsuarioLogic();
            var email = Request.Form["email"].ToString();
            var password=Request.Form["password"].ToString();
            Usuario user = new Usuario();
            //string[] array = { email,password};
            //ViewData["datos"] = array;

            user = usuarioLogic.GetOneByEmail(email);
            if (email == user.Email)
            {
                if (password == user.Clave) {
                    Session["usuario"] = user.NombreUsuario;
                    Session["nivel"] = user.IDTipoPersona;
                    Session["id"] = user.ID;
                   // if(habilitado !+)

                    return RedirectToAction("Index");
                }
                else {
                    ViewData["error"] = "Usuario o contraseña incorrecta";

                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewData["error"] = "Usuario o contraseña incorrecta";

                return RedirectToAction("Index");
               
            }

        }

        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Index");
        }

        /*var email = Request.Form["email"].ToString();
        var password = Request.Form["password"].ToString();
        string[] array = { email, password };
        ViewData["datos"] = array;
           
            return View();*/
    }
}