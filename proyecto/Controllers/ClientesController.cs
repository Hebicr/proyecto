using proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using static System.Collections.Specialized.BitVector32;

namespace proyecto.Controllers
{
    public class ClientesController : Controller
    {
        ProyectoProgra6Entities db = new ProyectoProgra6Entities();

        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Comprar(int idCliente)
        {
            TempData["idCliente"] = idCliente;
            var cantAdiciones = db.sp_Selecionar_Cantidad_Adiciones_Cliente(idCliente).ToList();
            ViewBag.cantAdiciones = cantAdiciones[0];
            List<CoberturaPolizas> coberturaList = db.CoberturaPolizas.ToList();
            ViewBag.coberturas = new SelectList(coberturaList, "idCoberturaPoliza", "Nombre");
            return View();
        }

        [HttpPost]
        public ActionResult ComprarPoliza(FormCollection newPoliza)
        {

            ///Calculos 

            return RedirectToAction("", "");
        }
        public ActionResult ClientesxPolizas()
        {

            try
            {
                var clientesList = db.sp_getClientesDDL();
                return View(clientesList);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        public ActionResult ClientesxAdiciones()
        {
            try
            {
                var clientesList = db.sp_getClientesDDL();
                return View(clientesList);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public ActionResult InsertarAdiccion(int idCliente)
        {
            try
            {
                List<Adiciones> adiccionList = db.Adiciones.ToList();
                TempData["idCliente"]= idCliente;
                ViewBag.adiccionList = new SelectList(adiccionList, "idAdiccion", "Nombre");
                ViewBag.AdiccionesU = db.sp_getAdiccionesxClienteC(idCliente);
                return View();
            }
            catch (Exception ex)
            {
                ViewData["Error"] = "Ocurrio un Error" + ex.Message;
                TempData["Error"] = "Ocurrio un Error" + ex.Message;
                return RedirectToAction("InsertarAdiccion", "Clientes");
            }

        }
        [HttpPost]
        public ActionResult InsertarAdicciones(FormCollection newAdicion)
        {
            int idCliente;
            try
            {
                idCliente = Convert.ToInt32(newAdicion["idCliente"]);
                Nullable<int> myValue = db.sp_insertAdiccionCliente(Convert.ToInt32(newAdicion["idCliente"]), Convert.ToInt32(newAdicion["idAdiccion"]));
                int result = myValue.Value;
                if (result == -1) {
                    //ViewData["Error"] = "Adiccion Ya esta Agregada";
                    TempData["Error"] = "Adiccion Ya esta Agregada";
                }


                List<Adiciones> adiccionList = db.Adiciones.ToList();
                ViewBag.adiccionList = new SelectList(adiccionList, "idAdiccion", "Nombre");
                ViewBag.AdiccionesU = db.sp_getAdiccionesxClienteC(idCliente);

                return RedirectToAction("InsertarAdiccion", new { idCliente = idCliente });
            }
            catch (Exception ex)
            {
                //ViewData["Error"] = "Ocurrio un Error al guardar el registro " + ex.Message;
                TempData["Error"] = "Ocurrio un Error al guardar el registro " + ex.Message;
                return RedirectToAction("InsertarAdiccion", "Clientes");
            }


        }

        public ActionResult EliminarAdiccion(int idCliente,int idAdicion)
        {
            try
            {
                db.sp_eliminarAdiccionCliente(idAdicion, idCliente);

                List<Adiciones> adiccionList = db.Adiciones.ToList();
                TempData["idCliente"] = idCliente;
                ViewBag.adiccionList = new SelectList(adiccionList, "idAdiccion", "Nombre");
                ViewBag.AdiccionesU = db.sp_getAdiccionesxClienteC(idCliente);
                return RedirectToAction("InsertarAdiccion", new { idCliente = idCliente });
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = "Ocurrio un Error al eliminar el registro " +ex.Message;
                return View();
            }
        }

        public ActionResult RetornaPorcentaje(int idCoberturaPoliza)
        {
            try
            {
                List<sp_getCoberturaPorcentaje_Result> porcentaje = db.sp_getCoberturaPorcentaje(idCoberturaPoliza).ToList();
                return Json(porcentaje, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = "Ocurrio un Error a conseguir el porcentaje " + ex.Message;
                return View();
            }
        }
        //public ActionResult ReporteClientes() {
        //    try { 

        //    } catch (Exception ex) {

        //    }
        //}
    }
}