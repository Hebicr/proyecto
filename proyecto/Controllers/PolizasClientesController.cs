using proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto.Controllers
{
    public class PolizasClientesController : Controller
    {
        ProyectoProgra6Entities db = new ProyectoProgra6Entities();
        //CARGA LA VISTA INDEX DE POLIZASCLIENTES
        public ActionResult Index()
        {
            try
            {
                var polizasClientes = db.sp_Selecionar_Polizas_Todas().ToList();
                return View(polizasClientes);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Ocurrio un Error" + ex.Message;
                return View();
            }
        }
        //CARGA LA VISTA INDEX DE KendoGridPolizas
        public ActionResult KendoGridPolizas()
        {
            try
            {
                return View();
            }catch(Exception ex)
            {
                TempData["Error"] = "Ocurrio un Error" + ex.Message;
                return View();
            }
        }
        //CARGA LA VISTA INDEX DE KendoGridPoliza
        public ActionResult KendoGridPoliza()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Ocurrio un Error" + ex.Message;
                return View();
            }
        }
        //PROCEDIMIENTO PARA CARGAR UN KENDO GRID
        public ActionResult GetDataPolizas()
        {
            try
            {
                var polizasClientes = db.sp_getPolizasClientes().ToList();
                return Json(polizasClientes, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Ocurrio un Error" + ex.Message;
                return View();
            }

        }
        //PROCEDIMIENTO PARA CARGAR UN KENDO GRID
        public ActionResult GetDataPoliza()
        {
            try
            {
                var id_Cliente = Session["clientelogID"];
                var polizasClientes = db.sp_getPolizasCliente((int)id_Cliente).ToList();
                return Json(polizasClientes, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Ocurrio un Error" + ex.Message;
                return View();
            }

        }
        //PROCEDIMIENTO PARA CARGAR LOS DETALLES DE LAS POLIZAS
        public ActionResult Details(int id)
        {
            try
            {
                sp_Selecionar_Polizas_Admin_Detalles_Id_Result listaPolizas = (from c in db.sp_Selecionar_Polizas_Admin_Detalles_Id() where id == c.idRegistroPoliza select c).First();
                return View(listaPolizas);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Ocurrio un Error" + ex.Message;
                return View();
            }
           
        }
        //RETORNA LA VISTA CREATE DE POLIZAS
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                sp_Selecionar_Polizas_Modelo_Result polizaU = (from c in db.sp_Selecionar_Polizas_Modelo() where id == c.idRegistroPoliza select c).First();
                int idC = polizaU.idCliente;
                var cantAdiciones = db.sp_Selecionar_Cantidad_Adiciones_Cliente(idC).ToList();
                ViewBag.cantAdiciones = cantAdiciones[0];
                List<CoberturaPolizas> coberturaList = db.CoberturaPolizas.ToList();
                ViewBag.coberturas = new SelectList(coberturaList, "idCoberturaPoliza", "Nombre");

                return View(polizaU);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Ocurrio un Error" + ex.Message;
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                db.sp_Actualizar_Poliza(Convert.ToInt32(collection["idRegistroPoliza"]), Convert.ToInt32(collection["idCoberturaPoliza"]), Convert.ToDecimal(collection["montoAsegurado"]), Convert.ToDecimal(collection["porcentajeCobertura"]), Convert.ToInt32(collection["numeroAdiciones"]), Convert.ToDecimal(collection["montoAdiciones"]), Convert.ToDecimal(collection["primaAntesImpuestos"]), Convert.ToDecimal(collection["impuestos"]), Convert.ToDecimal(collection["primaFinal"]), Convert.ToDateTime(collection["fechaVencimiento"]));

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["Error"] = "Ocurrio un Error" + ex.Message;
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

        public ActionResult Delete(int id)
        {
            try
            {
                sp_Selecionar_Polizas_Admin_Detalles_Id_Result listaPolizas = (from c in db.sp_Selecionar_Polizas_Admin_Detalles_Id() where id == c.idRegistroPoliza select c).First();
                return View(listaPolizas);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Ocurrio un Error" + ex.Message;
                return View();
            }
        }


        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
               
                db.sp_Borrar_Poliza(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex) 
            {
                TempData["Error"] = "Ocurrio un Error" + ex.Message;
                return View();
            }
        }
    }
}
