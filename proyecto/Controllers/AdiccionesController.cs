using proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto.Controllers
{
    public class AdiccionesController : Controller
    {
        // GET: Adicciones
        ProyectoProgra6Entities db = new ProyectoProgra6Entities();
        //OBTENER UNA LISTA DE LAS ADICCIONES DE POLIZAS DISPONIBLES
        public ActionResult Index()
        {
            try
            {
                var adicciones = db.sp_getAdicciones();
                return View(adicciones);
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }

        }
        //VISTA PARA CREAR UNA NUEVA COBERTURA
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }

        }

        //EL HTTPPOST PARA ENVIAR LA INFORMACION CON LOS QUE SE VAN A CREAR LA NUEVA ADICCION
        [HttpPost]
        public ActionResult Create(FormCollection myAdiccion)
        {
            try
            {
                db.sp_AgregarAdiccion(myAdiccion["Nombre"], myAdiccion["Codigo"]);
                return RedirectToAction("Index", "Adicciones");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        //LA VISTA DEL EDITAR PARA CARGAR LOS DATOS
        public ActionResult Editar(int idAdiccion)
        {
            try
            {
                Adiciones Adicion = (from c in db.Adiciones where idAdiccion == c.idAdiccion select c).First();
                return View(Adicion);
            }
            catch (Exception ex) 
            {
                return View(ex.Message);
            }


        }

        // HTTPPOST PARA ENVIAR LA INFORMACION DEL EDITAR 
        [HttpPost]
        public ActionResult Editar(int idAdiccion, FormCollection myAdiccion)
        {
            try
            {

                db.sp_ModificarAdiccion(Convert.ToInt32(myAdiccion["idAdiccion"]),myAdiccion["Nombre"], myAdiccion["Codigo"]);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //ELIMINAR ADICCIONES DE POLIZAS
        public ActionResult EliminarAdiccion(int idAdiccion)
        {
            try
            {
                db.sp_eliminarAdiccion(idAdiccion);
                return RedirectToAction("Index", "Adicciones");
            }
            catch(Exception ex)
            {
                TempData["Error"] = "Ocurrio un Error" + ex.Message;
                return View();
            }
        }
    }
}