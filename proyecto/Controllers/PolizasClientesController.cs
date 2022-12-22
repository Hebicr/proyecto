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
                var polizasClientes = db.sp_Selecionar_Polizas_Admin().ToList();
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
        //CARGA LA VISTA INDEX DE KendoGridAdiciones
        public ActionResult KendoGridAdiciones()
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
        //CARGA LA VISTA INDEX DE KendoGridAdicionesxCliente
        public ActionResult KendoGridAdicionesxCliente()
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
        public ActionResult GetDataAdiciones()
        {
            try
            {
                var adiciones = db.sp_getAdiccionesxClientes().ToList();
                return Json(adiciones, JsonRequestBehavior.AllowGet);
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
        //PROCEDIMIENTO PARA CARGAR UN KENDO GRID
        public ActionResult GetDataAdicionesxCliente()
        {
            try
            {
                var id_Cliente = Session["clientelogID"];
                var adiciones = db.sp_getAdiccionesxCliente((int)id_Cliente).ToList();
                return Json(adiciones, JsonRequestBehavior.AllowGet);
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
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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

        public ActionResult Delete(int id)
        {
            return View();
        }


        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
    }
}
