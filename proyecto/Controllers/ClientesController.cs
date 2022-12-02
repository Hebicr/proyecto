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
            
           ViewBag.AdiccionesU = db.sp_getAdiccionesxClienteC((int)Session["usuario"]);
           return View();

        }
        public ActionResult InsertarAdiccion()
        {
            //var idUsuario = Session["usuario"];
            List<Adiciones> adiccionList = db.Adiciones.ToList();
            ViewBag.adiccionList = new SelectList(adiccionList, "idAdiccion", "Nombre");
            ViewBag.AdiccionesU = db.sp_getAdiccionesxClienteC((int)Session["usuario"]);
            return View();
        }
        public ActionResult InsertarAdicciones(int idCliente,int idAdicion)
        {
            
            try
            {
                Nullable<int> myValue = db.sp_insertAdiccionCliente(idCliente, idAdicion);
                int result = myValue.Value;
                //var result = db.sp_insertAdiccionCliente(idCliente, idAdicion);
                return RedirectToAction("InsertarAdiccion", "Clientes");
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = "Ocurrio un Error al guardar el registro " +ex.Message;
                return View();
            }

        }

        public ActionResult EliminarAdiccion(int idCliente,int idAdicion)
        {
            try
            {
                db.sp_eliminarAdiccionCliente(idAdicion, idCliente);
                return RedirectToAction("InsertarAdiccion", "Clientes");
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = "Ocurrio un Error al eliminar el registro " +ex.Message;
                return View();
            }
        }
    }
}