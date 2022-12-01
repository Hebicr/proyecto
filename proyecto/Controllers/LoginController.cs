using proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ProyectoProgra6.Controllers
{
    public class LoginController : Controller
    {
        ProyectoProgra6Entities db = new ProyectoProgra6Entities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Registro()
        {
            List<Provincia> provinciasList = db.Provincias.ToList();
            ViewBag.provinciasList = new SelectList(provinciasList, "id_Provincia", "nombre");

            List<Genero> generoList = db.Generoes.ToList();
            ViewBag.generoList = new SelectList(generoList, "id", "genero1");

            return View();
        }

        [HttpPost]
        public ActionResult Registro(FormCollection myCliente)
        {
            List<Provincia> provinciasList = db.Provincias.ToList();
            ViewBag.provinciasList = new SelectList(provinciasList, "id_Provincia", "nombre");

            List<Genero> generoList = db.Generoes.ToList();
            ViewBag.generoList = new SelectList(generoList, "id", "genero1");

            try
            {
                var result = db.sp_Inserta_Clientes(myCliente["Cedula"], int.Parse(myCliente["Genero"]), Convert.ToDateTime(myCliente["FechadeNacimiento"]), myCliente["Nombre"], myCliente["PrimerApellido"], myCliente["SegundoApellido"], myCliente["DireccionFisica"], myCliente["TelefonoPrincipal"], myCliente["TelefonoSecundario"],
                                                    myCliente["CorreoElectronico"], int.Parse(myCliente["id_Provincia"]), int.Parse(myCliente["id_Canton"]), int.Parse(myCliente["id_Distrito"]));

                var result2 = result.ToList();

                if (result2.Count() == 1) {

                    ViewData["Mensaje"] = "Registro Exitoso Usuario :"+result2[0].usuario +" Contrasena :" + result2[0].contrasena;

                    return View();
                } else {
                    ViewData["Mensaje"] = "Cedula Ya esta Registrada" ;
                    return View();
                }
                
                //return View();
            }
            catch (Exception ex)
            {
                //return Content("Ocurrio un error : " + ex.Message);
                ViewData["Mensaje"] = "Ocurrio un error : " + ex.Message;
                return View();
            }
        }

        public JsonResult GetCantones(int id_Provincia)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Canton> cantonList = db.Cantons.Where(x => x.id_Provincia == id_Provincia).ToList();
            //ViewBag.cantons = cantonList;
            return Json(cantonList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDistritos(int id_Canton)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Distrito> distritoList = db.Distritoes.Where(x => x.id_Canton == id_Canton).ToList();
            //ViewBag.cantons = cantonList;
            return Json(distritoList, JsonRequestBehavior.AllowGet);
        }

        
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
                    ViewData["Mensaje"] = "Credenciales NO Validas";
                    return View();
                }

                //return View();
            }
            catch (Exception ex)
            {
                //return Content("Ocurrio un error : " + ex.Message);
                ViewData["Mensaje"] = "Ocurrio un error : " + ex.Message;
                return View();
            }

        }

        void EnciarCorreo(string user,string pass)
        {
            try {
                //Se definen variables
                String para;
                string asunto;
                string mensaje;
                string apellido1;
                string apellido2;
                string nombreC;
                para = collection["correo"];
                apellido1 = collection["Apellido1"];
                apellido2 = collection["Apellido2"];
                nombreC = collection["Nombre"];
                asunto = "Credenciales Equipo Siglo XXI";
                mensaje = "Estimado cliente: " + apellido1 + " " + apellido2 + " " + nombreC + ", gracias por  confiar en Seguros del Equipo del Siglo XXI." + "Adjunto encontrará sus credenciales de acceso a la plataforma Equipo Siglo XXI." + " " + "Para nosotros es un placer servirle. " + "A continuación, sus credenciales para ingresar a la aplicación: http://localhost:61823/";



                MailMessage correo = new MailMessage(); //variable de tipo mailmessage  se usan para construir mensajes de correo electrónico que se transmiten a un servidor SMTP para su entrega mediante la SmtpClient clase
                correo.From = new MailAddress("fabiolarojas1429@gmail.com"); //correo que nuestro software utilizará para enviar los correos
                correo.To.Add(para);
                correo.Subject = asunto;
                correo.Body = mensaje;
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal; //prioridad

                //configuración del servidor smpt PROVEEDOR GMAIL PUERTO 25

                SmtpClient smtp = new SmtpClient();//La SmtpClient se usa para enviar correo electrónico a un servidor SMTP para su entrega. 
                smtp.Host = "smtp.gmail.com"; //hOST
                smtp.Port = 25; //PUERTO DEL PROVEEDOR ES VARIABLE
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;

                string sCuentaCorreo = "fabiolarojas1429@gmail.com";
                string sPassword = "yrxyswtjekdqqlee";
                smtp.Credentials = new System.Net.NetworkCredential(sCuentaCorreo, sPassword);

                smtp.Send(correo);
                RedirectToAction("Login");
            } catch (Exception ex) {
                ViewData["Mensaje"] = "Ocurrio un error : " + ex.Message;
            }
        }
    }
}