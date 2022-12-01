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
        //OBTENER UNA LISTA DE LAS COBERTURAS DE POLIZAS DISPONIBLES
        public ActionResult Index()
        {
            var adicciones = db.sp_getAdicciones();
            return View(adicciones);
        }
        //VISTA PARA CREAR UNA NUEVA COBERTURA
        public ActionResult Create()
        {
            return View();
        }

        //EL HTTPPOST PARA ENVIAR LA INFORMACION CON LOS QUE SE VAN A CREAR LA NUEVA COBERTURA
        [HttpPost]
        public ActionResult Create(FormCollection myAdiccion)
        {
            try
            {
                Adiciones adiccion = new Adiciones();
                adiccion.Nombre = myAdiccion["Nombre"];
                adiccion.Codigo = myAdiccion["Codigo"];
                db.sp_AgregarAdiccion(adiccion.Nombre, adiccion.Codigo);

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
            //CoberturaPolizas cobertura  = (from c in db.CoberturaPolizas where idCoberturaPoliza == c.idCoberturaPoliza select c).First();
            //return View(cobertura);

            var adiccion = db.sp_getAdiccionEditar(idAdiccion);
            return View(adiccion);
        }

        // HTTPPOST PARA ENVIAR LA INFORMACION DEL EDITAR 
        [HttpPost]
        public ActionResult Editar(int idAdiccion, FormCollection myAdiccion)
        {
            try
            {
                Adiciones adiccion = new Adiciones();
                adiccion.idAdiccion = Convert.ToInt32(myAdiccion["idCoberturaPoliza"]);
                adiccion.Nombre = myAdiccion["Nombre"];
                adiccion.Codigo = myAdiccion["Codigo"];
                db.sp_ModificarAdiccion(adiccion.idAdiccion, adiccion.Nombre, adiccion.Codigo);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //ELIMINAR COBERTURAS DE POLIZAS
        public ActionResult EliminarAdiccion(int idAdiccion)
        {
            try
            {
                db.sp_eliminarAdiccion(idAdiccion);
                return RedirectToAction("Index", "Adicciones");
            }
            catch
            {
                return View();
            }
        }
    }
}