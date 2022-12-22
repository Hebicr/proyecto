using proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ProyectoProgra6.Controllers
{
    public class LoginController : Controller
    {
        ProyectoProgra6Entities db = new ProyectoProgra6Entities();
        // GET: Login

        //RETORNA LA VISTA INDEX DE LOGIN
        public ActionResult Index()
        {
            return View();
        }
        //RETORNA LA VISTA LOGIN DE LOGIN
        public ActionResult Login()
        {
            return View();
        }
        //RETORNA LA VISTA DE REGISTRO
        public ActionResult Registro()
        {
            List<Provincia> provinciasList = db.Provincia.ToList();
            ViewBag.provinciasList = new SelectList(provinciasList, "id_Provincia", "nombre");

            List<Genero> generoList = db.Genero.ToList();
            ViewBag.generoList = new SelectList(generoList, "id", "genero1");

            return View();
        }
        //HTTPPOST DEL LA VISTA REGISTRO 
        [HttpPost]
        public ActionResult Registro(FormCollection myCliente)
        {
            List<Provincia> provinciasList = db.Provincia.ToList();
            ViewBag.provinciasList = new SelectList(provinciasList, "id_Provincia", "nombre");

            List<Genero> generoList = db.Genero.ToList();
            ViewBag.generoList = new SelectList(generoList, "id", "genero1");

            try
            {
                var result = db.sp_Inserta_Clientes(myCliente["Cedula"], int.Parse(myCliente["id_Genero"]), Convert.ToDateTime(myCliente["FechadeNacimiento"]), myCliente["Nombre"], myCliente["PrimerApellido"], myCliente["SegundoApellido"], myCliente["DireccionFisica"], myCliente["TelefonoPrincipal"], myCliente["TelefonoSecundario"],
                                                    myCliente["CorreoElectronico"], int.Parse(myCliente["id_Provincia"]), int.Parse(myCliente["id_Canton"]), int.Parse(myCliente["id_Distrito"]));

                var result2 = result.ToList();

                if (result2.Count() == 1) {
                    //EnviarCorreo(result2[0].usuario, result2[0].contrasena, result2[0].Nombre, result2[0].PrimerApellido, result2[0].SegundoApellido, result2[0].CorreoElectronico);
                    enviarCorreo2(result2[0].usuario, result2[0].contrasena, result2[0].Nombre, result2[0].PrimerApellido, result2[0].SegundoApellido, result2[0].CorreoElectronico);
                    ViewData["Mensaje"] = "Registro Exitoso, se le enviara un email con su informacion";
                    return View();
                    //TempData["info"] = "Registro Exitoso, se le enviara un email con su informacion";
                    //return RedirectToAction("Login", "Login");
                } else {
                    ViewData["Error"] = "Cedula Ya esta Registrada" ;
                    return View();
                }
                
                //return View();
            }
            catch (Exception ex)
            {
                //return Content("Ocurrio un error : " + ex.Message);
                ViewData["Error"] = "Ocurrio un error : " + ex.Message;
                return View();
            }
        }
        //OBTIENE LOS CANTONES PARA CARGAR LA VISTA
        public JsonResult GetCantones(int id_Provincia)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Canton> cantonList = db.Canton.Where(x => x.id_Provincia == id_Provincia).ToList();
            //ViewBag.cantons = cantonList;
            return Json(cantonList, JsonRequestBehavior.AllowGet);
        }
        //OBTIENE LOS DISTRITOS PARA CARGAR LA VISTA
        public JsonResult GetDistritos(int id_Canton)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Distrito> distritoList = db.Distrito.Where(x => x.id_Canton == id_Canton).ToList();
            //ViewBag.cantons = cantonList;
            return Json(distritoList, JsonRequestBehavior.AllowGet);
        }

        //HTTPPOST PARA INICIAR SESION
        [HttpPost]
        public ActionResult Login(string Usuario, string Password)
        {
            try
            {
                //var idUsuario = db.sp_Login(Usuario, Password).ToList();
                Nullable<int> myValue = db.sp_Login(Usuario, Password).FirstOrDefault();
                int idUsuario = myValue.Value;

                if (idUsuario != 0)
                {

                    Session["usuario"] = idUsuario;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["Error"] = "Credenciales NO Validas";
                    return View();
                }

                //return View();
            }
            catch (Exception ex)
            {
                //return Content("Ocurrio un error : " + ex.Message);
                ViewData["Error"] = "Ocurrio un error : " + ex.Message;
                return View();
            }

        }

       
        //PROCEDIMIENTO PARA ENVIAR CORREO
        void enviarCorreo2(string userU, string passU, string nombreU, string apellido1U, string apellido2U, string correoU) {
            var fromAddress = new MailAddress("stev.199279@gmail.com", "Equipo Siglo XXI");
            var toAddress = new MailAddress(correoU, "");
            const string fromPassword = "qzcpixbhupavxjmk";
            const string subject = "Credenciales Equipo Siglo XXI";
            string mensaje;
            mensaje = "Estimado cliente: " + apellido1U + " " + apellido2U + " " + nombreU + ", " +
                          "gracias por  confiar en Seguros del Equipo del Siglo XXI." + "\n" +
                          "Para nosotros es un placer servirle. " +
                          "A continuación, sus credenciales para ingresar a la aplicación " + "\n" + 
                          "Usuario: " +" (" + userU + ")"+ "\n" + "Contraseña: (" + passU + ")"+ "\n" + "http://localhost:61823/";
            string body = mensaje;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}