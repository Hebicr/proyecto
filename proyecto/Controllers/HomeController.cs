using proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto.Controllers
{
    public class HomeController : Controller
    {
        ProyectoProgra6Entities db = new ProyectoProgra6Entities();

        //PROCEDIMIENTO QUE GENERA LA VISTA DE INDEX Y CARGA LA SESION
        public ActionResult Index()
        {
            try
            {
                if (Session["usuario"] != null)
                {
                    var idUsuario = Session["usuario"];
                    var clientelog = db.sp_Seleccionar_Cliente((int)idUsuario).ToList();
                    Session["clientelog"] = clientelog;
                    Session["clientelognombre"] = clientelog[0].Nombre;
                    Session["clientelogapellido1"] = clientelog[0].PrimerApellido;
                    Session["clientelogapellido2"] = clientelog[0].SegundoApellido;
                    Session["clientelogRol"] = clientelog[0].idRol;
                    Session["clientelogID"] = clientelog[0].id;

                    //ViewBag.clientelog = clientelog.ToList();
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = "Ocurrio un error : " + ex.Message;
                return View();
            }

        }
        //PROCEDIMIENTO QUE CARGA LA INFORMACION DEL CLIENTE
        public ActionResult InfoCliente()
        {
            try {
                var idUsuario = Session["usuario"];
                var infoCliente = db.sp_Seleccionar_Cliente((int)idUsuario).ToList();
                ViewBag.infoCliente = infoCliente;
                return View();
            }
            catch (Exception ex) {
                ViewData["Mensaje"] = "Ocurrio un error : " + ex.Message;
                return View();
            }
        
        }

        //PROCEDIMIENTO PARA CERRAR SESION
        public ActionResult LogOut()
        {
            try
            {
                Session["usuario"] = null;
                Session["clientelog"] = null;
                Session["clientelognombre"] = null;
                Session["clientelogapellido1"] = null;
                Session["clientelogapellido2"] = null;
                Session["clientelogRol"] = null;
                return RedirectToAction("Login", "Login");
            }
            catch(Exception ex)
            {
                ViewData["Mensaje"] = "Ocurrio un error : " + ex.Message;
                return View();
            }
            
        }

        //CARGA LA VISTA DE ABOUT
        public ActionResult About()
        {
            try
            {
                return View();
            }
            catch(Exception ex)
            {
                ViewData["Mensaje"] = "Ocurrio un error : " + ex.Message;
                return View();
            }
            
        }
        //CARGA LA VISTA DE CONTACT
        public ActionResult Contact()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = "Ocurrio un error : " + ex.Message;
                return View();
            }

        }
    }
}