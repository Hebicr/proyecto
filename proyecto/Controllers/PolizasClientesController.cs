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
        // GET: PolizasClientes
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

        // GET: PolizasClientes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PolizasClientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PolizasClientes/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PolizasClientes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PolizasClientes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PolizasClientes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PolizasClientes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
