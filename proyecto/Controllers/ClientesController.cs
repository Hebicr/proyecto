using proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Collections.Specialized.BitVector32;

namespace proyecto.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        
        ProyectoProgra6Entities db = new ProyectoProgra6Entities();
        
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult Adicciones()
        {
            
           // ViewBag.AdiccionesU = db.sp_getAdiccionesxClienteC();
           return View();

        }
        public ActionResult InsertarAdiccion()
        {
            //var idUsuario = Session["usuario"];
            List<Adiciones> adiccionList = db.Adiciones.ToList();
            ViewBag.adiccionList = new SelectList(adiccionList, "idAdiccion", "Nombre");
            return View();
        }
        public ActionResult InsertarAdicciones(int idCliente,int idAdicion)
        {
            try
            {
                db.sp_insertAdiccionCliente(idCliente, idAdicion);
                return RedirectToAction("Adicciones", "Clientes");
            }
            catch
            {
                return View();
            }

        }

        public ActionResult EliminarAdiccion(int idCliente,int idAdicion)
        {
            try
            {
                db.sp_eliminarAdiccionCliente(idAdicion, idCliente);
                return RedirectToAction("Adicciones", "Clientes");
            }
            catch
            {
                return View();
            }
        }
    }
}