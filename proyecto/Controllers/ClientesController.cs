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

        //RETORNA LA VISTA INDEX DEL CONTROLLER CLIENTES
        public ActionResult Index()
        {
            try
            {
                var clientes = db.sp_getClientes();
                return View(clientes);
            }
            catch(Exception ex)
            {
                TempData["Error"] = "Ocurrio un Error" + ex.Message;
                return View();
            }

        }


        //RETORNA LA VISTA DEL PERFIL DEL CLIENTE
        public ActionResult PerfilCliente()
        {
            try
            {
                var id_Cliente = Session["clientelogID"];
                var Cliente = db.sp_getInformacion_Cliente((int)id_Cliente).ToList();
                return View(Cliente);
            }
            catch(Exception ex)
            {
                TempData["Error"] = "Ocurrio un Error" + ex.Message;
                return View();
            }

        }

        //RETORNA LA VISTA EDITAR CLIENTE
        public ActionResult EditarCliente(int idCliente)
        {
            try
            {
                Clientes Cliente = (from c in db.Clientes where idCliente == c.idCliente select c).First();
                return View(Cliente);
            }
            catch(Exception ex)
            {
                TempData["Error"] = "Ocurrio un Error" + ex.Message;
                return View();
            }


        }

        //EL HTTPPOST PARA GUARDAR EL UPDATE DEL CLIENTE
       [HttpPost]
        public ActionResult EditarCliente(FormCollection myCliente)
        {
            try
            {

                db.sp_ModificarCliente(Convert.ToInt32(myCliente["idCliente"]),myCliente["Cedula"], myCliente["Nombre"], myCliente["PrimerApellido"], myCliente["SegundoApellido"], myCliente["DireccionFisica"], myCliente["TelefonoPrincipal"], myCliente["TelefonoSecundario"], myCliente["CorreoElectronico"]);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Ocurrio un Error" + ex.Message;
                return View();
            }
        }
        //PROCEDIMIENTO PARA ELIMINAR CLIENTE
        public ActionResult EliminarCliente(int idUsuario)
        {
            try
            {
                db.sp_eliminarCliente(idUsuario);
                TempData["info"] = "Registro Eliminado exitosamente";
                return RedirectToAction("Index", "Clientes");
            }
            catch(Exception ex)
            {
                TempData["error"] = "Ocurrio un Error" + ex.Message;
                return View();
            }
        }
        //RETORNA LA VISTA DE COMPRAR POLIZAS
        public ActionResult Comprar(int idCliente)
        {
            

            try
            {
                TempData["idCliente"] = idCliente;
                var cantAdiciones = db.sp_Selecionar_Cantidad_Adiciones_Cliente(idCliente).ToList();
                ViewBag.cantAdiciones = cantAdiciones[0];
                List<CoberturaPolizas> coberturaList = db.CoberturaPolizas.ToList();
                ViewBag.coberturas = new SelectList(coberturaList, "idCoberturaPoliza", "Nombre");
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Ocurrio un Error" + ex.Message;
                return View();
            }
        }
        //HTTPPOST Y PROCEDIMIENTO PARA COMPRAR POLIZAS
        [HttpPost]
        public ActionResult ComprarPoliza(FormCollection newPoliza)
        {

            try
            {
                db.sp_Insertar_Polizas(Convert.ToInt32(newPoliza["idCoberturaPoliza"]), Convert.ToInt32(newPoliza["idCliente"]), Convert.ToDecimal(newPoliza["montoAsegurado"]), Convert.ToDecimal(newPoliza["Porcentaje"]), Convert.ToInt32(newPoliza["cantAdiciones1"]), Convert.ToDecimal(newPoliza["montoAdiciones"]), Convert.ToDecimal(newPoliza["primaAntesImpuestos"]), Convert.ToDecimal(newPoliza["impuestos"]), Convert.ToDecimal(newPoliza["primaFinal"]), Convert.ToDateTime(newPoliza["fechaVencimiento"]));
                TempData["Mensaje"] = "Poliza Agregada";
                //return View();
                return RedirectToAction("Index", "PolizasClientes");

            }
            catch (Exception ex)
            {

                TempData["Error"] = "Ocurrio un Error" + ex.Message;
                return RedirectToAction("Index", "PolizasClientes");
               //return View();
            }
        }
        //OBTIENE LA VISTA CON UNA LISTA DE CLIENTES 
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
        //OBTIENE LA VISTA CON UNA LISTA DE CLIENTES 
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
        //VISTA PARA AGREGAR ADICCIONES A UN CLIENTE
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

        //HTTPPOST PARA AGREGAR ADICCIONES
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
        //PROCEDIMIENTO PARA ELIMINAR ADICCIONES A UN CLIENTE
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
        //PROCEDIMIENTO QUE RETORNA EL PORCENTAJE 
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
    }
}