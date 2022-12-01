using proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            List<Adicione> adiccionList = db.Adiciones.ToList();
            ViewBag.adiccionList = new SelectList(adiccionList, "idAdiccion", "Nombre");



            return View();
        }
    }
}