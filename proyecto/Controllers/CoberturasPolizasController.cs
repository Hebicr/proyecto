using Newtonsoft.Json.Linq;
using proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ProyectoProgra6.Controllers
{
    public class CoberturasPolizasController : Controller
    {
        ProyectoProgra6Entities db = new ProyectoProgra6Entities();
        //OBTENER UNA LISTA DE LAS COBERTURAS DE POLIZAS DISPONIBLES
        public ActionResult Index()
        {
            var coberturas = db.sp_getClientesDDL();
            return View(coberturas);
        }
        //VISTA PARA CREAR UNA NUEVA COBERTURA
        public ActionResult Create()
        {
            return View();
        }

        //EL HTTPPOST PARA ENVIAR LA INFORMACION CON LOS QUE SE VAN A CREAR LA NUEVA COBERTURA
        [HttpPost]
        public ActionResult Create(FormCollection myCobertura)
        {
            try
            {

                db.sp_AgregarCobertura(myCobertura["Nombre"], myCobertura["Descripcion"], Convert.ToDecimal(myCobertura["Porcentaje"]));
                return RedirectToAction("Index", "CoberturasPolizas");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        //LA VISTA DEL EDITAR PARA CARGAR LOS DATOS
        public ActionResult Editar(int idCoberturaPoliza)
        {
            CoberturaPolizas cobertura  = (from c in db.CoberturaPolizas where idCoberturaPoliza == c.idCoberturaPoliza select c).First();
            return View(cobertura);

            //var cobertura = db.sp_getCoberturaPolizasEditar(idCoberturaPoliza);
            //return View(cobertura);
        }

        // HTTPPOST PARA ENVIAR LA INFORMACION DEL EDITAR 
        [HttpPost]
        public ActionResult Editar(int idCoberturaPoliza, FormCollection myCobertura)
        {
            try
            {
                db.sp_ModificarCobertura(Convert.ToInt32(myCobertura["idCoberturaPoliza"]),myCobertura["Nombre"], myCobertura["Descripcion"], Convert.ToDecimal(myCobertura["Porcentaje"]));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //ELIMINAR COBERTURAS DE POLIZAS
        public ActionResult EliminarCobertura(int idCoberturaPoliza)
        {
            try
            {
                db.sp_eliminarCobertura(idCoberturaPoliza);
                return RedirectToAction("Index", "CoberturasPolizas");
            }
            catch
            {
                return View();
            }
        }

    }
}

