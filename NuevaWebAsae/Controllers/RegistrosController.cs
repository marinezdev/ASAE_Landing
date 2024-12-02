using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuevaWebAsae.Controllers
{
    public class RegistrosController : Controller
    {
        // GET: Registros
        [Route("conferencia-web/registro-de-asistencia/jc360")]
        public ActionResult Index()
        {
            if (!String.IsNullOrEmpty(Request.QueryString["in"]))
            {
                if (Request.QueryString["in"].ToString() == "1")
                {
                    ViewBag.Ingreso = "1"; // CRM 
                }
                else if (Request.QueryString["in"].ToString() == "2")
                {
                    ViewBag.Ingreso = "2";  // FACEBOKK
                }
                else if (Request.QueryString["in"].ToString() == "3")
                {
                    ViewBag.Ingreso = "3"; // PAGINA WEB
                }
                else if (Request.QueryString["in"].ToString() == "4")
                {
                    ViewBag.Ingreso = "4"; // TODOS
                }
                else if (Request.QueryString["in"].ToString() == "5")
                {
                    ViewBag.Ingreso = "5";
                }

            }
            else
            {
                ViewBag.Ingreso = "3";
            }
            return View();
        }

        [HttpPost]
        public JsonResult NuevoRegistro(Models.NuevoUsuario nuevoUsuario, Application.Usuarios usuarios)
        {
            if (nuevoUsuario != null)
            {
                Models.Usuario usuario = new Models.Usuario();
                foreach (var dt in nuevoUsuario.usuario)
                {
                    usuario = dt;
                    if (usuario.ApellidoMaterno == null)
                    {
                        usuario.ApellidoMaterno = "";
                    }

                    if (usuario.NombreEmpresa == null)
                    {
                        usuario.NombreEmpresa = "";
                    }

                    if (usuario.CorreoEmpresa == null)
                    {
                        usuario.CorreoEmpresa = "";
                    }

                    if (usuario.TelefonoLocal == null)
                    {
                        usuario.TelefonoLocal = "";
                    }
                }
                return Json(usuarios.AsaeWebUsuarioAgregar(usuario));
            }
            else
            {
                return Json("An Error Has occoured");
            }

        }

        [HttpPost]
        public JsonResult EnviarCorreo(Models.NuevoUsuario nuevoUsuario, Application.Usuarios usuarios)
        {
            if (nuevoUsuario != null)
            {
                Models.Usuario usuario = new Models.Usuario();
                foreach (var dt in nuevoUsuario.usuario)
                {
                    usuario = dt;
                }
                return Json(usuarios.AsaeWebUsuarioBuscar(usuario));
            }
            else
            {
                return Json("An Error Has occoured");
            }

        }

        [Route("conferencia-web/registro-de-asistencia/confirmacion")]
        public ActionResult Confirmacion(Application.Usuarios usuarios)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["dt"]))
            {
                Models.Usuario usuario = usuarios.AsaeWebUsuario_Selecionar_Token(Request.QueryString["dt"].ToString());

                ViewBag.Nombre = usuario.Nombre.ToUpper();
                ViewBag.ApellidoPaterno = usuario.ApellidoPaterno.ToUpper();
                ViewBag.ApellidoMaterno = usuario.ApellidoMaterno.ToUpper();
                ViewBag.NombreEmpresa = usuario.NombreEmpresa.ToUpper();
                ViewBag.CorreoEmpresa = usuario.CorreoEmpresa;
                ViewBag.CorreoPersonal = usuario.CorreoPersonal;
                ViewBag.TelefonoMovil = usuario.TelefonoMovil;
                ViewBag.TelefonoLocal = usuario.TelefonoLocal;
                ViewBag.Clave = usuario.Clave;
                ViewBag.Password = usuario.Password;
                ViewBag.Descripcion = usuario.Descripcion;
                ViewBag.Respuesta = usuario.Respuesta;

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            
        }
        



        /***********************************************************************************************************/
        [Route("conferencia-web/registro-de-asistencia/xpinnit")]
        public ActionResult Xpinnit()
        {
            if (!String.IsNullOrEmpty(Request.QueryString["in"]))
            {
                if (Request.QueryString["in"].ToString() == "1")
                {
                    ViewBag.Ingreso = "1"; // CRM 
                }
                else if (Request.QueryString["in"].ToString() == "2")
                {
                    ViewBag.Ingreso = "2";  // FACEBOKK
                }
                else if (Request.QueryString["in"].ToString() == "3")
                {
                    ViewBag.Ingreso = "3"; // PAGINA WEB
                }
                else if (Request.QueryString["in"].ToString() == "4")
                {
                    ViewBag.Ingreso = "4"; // TODOS
                }
                else if (Request.QueryString["in"].ToString() == "5")
                {
                    ViewBag.Ingreso = "5";
                }

            }
            else
            {
                ViewBag.Ingreso = "3";
            }
            return View();
        }

        [HttpPost]
        public JsonResult NuevoRegistroXpinnit(Models.NuevoUsuario nuevoUsuario, Application.Usuarios usuarios)
        {
            if (nuevoUsuario != null)
            {
                Models.Usuario usuario = new Models.Usuario();
                foreach (var dt in nuevoUsuario.usuario)
                {
                    usuario = dt;
                    if (usuario.ApellidoMaterno == null)
                    {
                        usuario.ApellidoMaterno = "";
                    }

                    if (usuario.NombreEmpresa == null)
                    {
                        usuario.NombreEmpresa = "";
                    }

                    if (usuario.CorreoEmpresa == null)
                    {
                        usuario.CorreoEmpresa = "";
                    }

                    if (usuario.TelefonoLocal == null)
                    {
                        usuario.TelefonoLocal = "";
                    }
                }
                return Json(usuarios.AsaeWebUsuarioAgregarXpinnit(usuario));
            }
            else
            {
                return Json("An Error Has occoured");
            }

        }

        [HttpPost]
        public JsonResult EnviarCorreoXpinnit(Models.NuevoUsuario nuevoUsuario, Application.Usuarios usuarios)
        {
            if (nuevoUsuario != null)
            {
                Models.Usuario usuario = new Models.Usuario();
                foreach (var dt in nuevoUsuario.usuario)
                {
                    usuario = dt;
                }
                return Json(usuarios.AsaeWebUsuarioBuscarXpinnit(usuario));
            }
            else
            {
                return Json("An Error Has occoured");
            }

        }

        [Route("conferencia-web/registro-de-asistencia/confirmacion-xpinnit")]
        public ActionResult ConfirmacionXpinnit(Application.Usuarios usuarios)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["dt"]))
            {
                Models.Usuario usuario = usuarios.AsaeWebUsuario_Selecionar_Token(Request.QueryString["dt"].ToString());

                ViewBag.Nombre = usuario.Nombre.ToUpper();
                ViewBag.ApellidoPaterno = usuario.ApellidoPaterno.ToUpper();
                ViewBag.ApellidoMaterno = usuario.ApellidoMaterno.ToUpper();
                ViewBag.NombreEmpresa = usuario.NombreEmpresa.ToUpper();
                ViewBag.CorreoEmpresa = usuario.CorreoEmpresa;
                ViewBag.CorreoPersonal = usuario.CorreoPersonal;
                ViewBag.TelefonoMovil = usuario.TelefonoMovil;
                ViewBag.TelefonoLocal = usuario.TelefonoLocal;
                ViewBag.Clave = usuario.Clave;
                ViewBag.Password = usuario.Password;
                ViewBag.Descripcion = usuario.Descripcion;
                ViewBag.Respuesta = usuario.Respuesta;

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


        }


        /************************************************************************************************************/
        [Route("patrocinador-en-AMSOFIPO-2023")]
        public ActionResult BanTotal()
        {
            return View();
        }

        /************************************************************************************************************/
        [HttpPost]
        public JsonResult SolicitudASD(Models.NuevoUsuario nuevoUsuario, Application.Usuarios usuarios)
        {
            if (nuevoUsuario != null)
            {
                Models.Usuario usuario = new Models.Usuario();
                foreach (var dt in nuevoUsuario.usuario)
                {
                    usuario = dt;
                    
                    if (usuario.TelefonoLocal == null)
                    {
                        usuario.TelefonoLocal = "";
                    }
                }
                return Json(usuarios.AsaeWebSolicitudDemoASD(usuario));
            }
            else
            {
                return Json("An Error Has occoured");
            }

        }

        [HttpPost]
        public JsonResult SolicitudJOBCTRL(Models.NuevoUsuario nuevoUsuario, Application.Usuarios usuarios)
        {
            if (nuevoUsuario != null)
            {
                Models.Usuario usuario = new Models.Usuario();
                foreach (var dt in nuevoUsuario.usuario)
                {
                    usuario = dt;

                    if (usuario.TelefonoLocal == null)
                    {
                        usuario.TelefonoLocal = "";
                    }
                }
                return Json(usuarios.AsaeWebSolicitudDemoJOBCTRL(usuario));
            }
            else
            {
                return Json("An Error Has occoured");
            }

        }

        [HttpPost]
        public JsonResult SolicitudHikvision(Models.NuevoUsuario nuevoUsuario, Application.Usuarios usuarios)
        {
            if (nuevoUsuario != null)
            {
                Models.Usuario usuario = new Models.Usuario();
                foreach (var dt in nuevoUsuario.usuario)
                {
                    usuario = dt;

                    if (usuario.TelefonoLocal == null)
                    {
                        usuario.TelefonoLocal = "";
                    }
                }
                return Json(usuarios.AsaeWebSolicitudDemoHikvision(usuario));
            }
            else
            {
                return Json("An Error Has occoured");
            }

        }

        [HttpPost]
        public JsonResult SolicitudHuawei(Models.NuevoUsuario nuevoUsuario, Application.Usuarios usuarios)
        {
            if (nuevoUsuario != null)
            {
                Models.Usuario usuario = new Models.Usuario();
                foreach (var dt in nuevoUsuario.usuario)
                {
                    usuario = dt;

                    if (usuario.TelefonoLocal == null)
                    {
                        usuario.TelefonoLocal = "";
                    }
                }
                return Json(usuarios.AsaeWebSolicitudDemoHuawei(usuario));
            }
            else
            {
                return Json("An Error Has occoured");
            }

        }

        [HttpPost]
        public JsonResult SolicitudIdeaHub(Models.NuevoUsuario nuevoUsuario, Application.Usuarios usuarios)
        {
            if (nuevoUsuario != null)
            {
                Models.Usuario usuario = new Models.Usuario();
                foreach (var dt in nuevoUsuario.usuario)
                {
                    usuario = dt;

                    if (usuario.TelefonoLocal == null)
                    {
                        usuario.TelefonoLocal = "";
                    }
                }
                return Json(usuarios.AsaeWebSolicitudDemoIdeaHub(usuario));
            }
            else
            {
                return Json("An Error Has occoured");
            }

        }

        [HttpPost]
        public JsonResult SolicitudIdeaHubPrecios(Models.NuevoUsuario nuevoUsuario, Application.Usuarios usuarios)
        {
            

            if (nuevoUsuario != null)
            {
                Models.Usuario usuario = new Models.Usuario();

                foreach (var dt in nuevoUsuario.usuario)
                {
                    usuario = dt;

                    if (usuario.TelefonoMovil == null)
                    {
                        usuario.TelefonoMovil = "";
                    }

                    if (usuario.TelefonoLocal == null)
                    {
                        usuario.TelefonoLocal = "";
                    }
                }

                string DirectorioArchivo = Server.MapPath("~") + "\\images\\ideahub\\PUBLICO_COSTOS_IDEAHUB_MAS_RENTA.pdf";

                return Json(usuarios.AsaeWebSolicitudPreciosIdeaHub(usuario, DirectorioArchivo));
            }
            else
            {
                return Json("An Error Has occoured");
            }
        }

        [HttpPost]
        public JsonResult SolicitudCorporativoIndustrial(Models.NuevoUsuario nuevoUsuario, Application.Usuarios usuarios)
        {
            if (nuevoUsuario != null)
            {
                Models.Usuario usuario = new Models.Usuario();
                foreach (var dt in nuevoUsuario.usuario)
                {
                    usuario = dt;

                    if (usuario.TelefonoLocal == null)
                    {
                        usuario.TelefonoLocal = "";
                    }
                }
                return Json(usuarios.AsaeWebSolicitudDemoCorporativoIndustrial(usuario));
            }
            else
            {
                return Json("An Error Has occoured");
            }

        }

        [HttpPost]
        public JsonResult SolicitudServiciosSoluciones(Models.NuevoUsuario nuevoUsuario, Application.Usuarios usuarios)
        {
            if (nuevoUsuario != null)
            {
                Models.Usuario usuario = new Models.Usuario();
                foreach (var dt in nuevoUsuario.usuario)
                {
                    usuario = dt;

                    if (usuario.TelefonoLocal == null)
                    {
                        usuario.TelefonoLocal = "";
                    }
                }
                return Json(usuarios.AsaeWebSolicitudInformacionServiciosSoluciones(usuario));
            }
            else
            {
                return Json("An Error Has occoured");
            }

        }
        [HttpPost]
        public JsonResult SolicitudTalentoHumano(Models.NuevoUsuario nuevoUsuario, Application.Usuarios usuarios)
        {
            if (nuevoUsuario != null)
            {
                Models.Usuario usuario = new Models.Usuario();
                foreach (var dt in nuevoUsuario.usuario)
                {
                    usuario = dt;

                    if (usuario.TelefonoLocal == null)
                    {
                        usuario.TelefonoLocal = "";
                    }
                }
                return Json(usuarios.AsaeWebSolicitudInformacionTalentoHumano(usuario));
            }
            else
            {
                return Json("An Error Has occoured");
            }

        }

        [HttpPost]
        public JsonResult SolicitudEventoCorporativo(Models.NuevoUsuario nuevoUsuario, Application.Usuarios usuarios)
        {
            if (nuevoUsuario != null)
            {
                Models.Usuario usuario = new Models.Usuario();
                foreach (var dt in nuevoUsuario.usuario)
                {
                    usuario = dt;

                    if (usuario.TelefonoLocal == null)
                    {
                        usuario.TelefonoLocal = "";
                    }
                }
                return Json(usuarios.AsaeWebSolicitudEventosCorporativos(usuario));
            }
            else
            {
                return Json("An Error Has occoured");
            }

        }
        [HttpPost]
        public JsonResult SolicitudEventosPrecios(Models.NuevoUsuario nuevoUsuario, Application.Usuarios usuarios)
        {


            if (nuevoUsuario != null)
            {
                Models.Usuario usuario = new Models.Usuario();

                foreach (var dt in nuevoUsuario.usuario)
                {
                    usuario = dt;

                    if (usuario.TelefonoMovil == null)
                    {
                        usuario.TelefonoMovil = "";
                    }

                    if (usuario.TelefonoLocal == null)
                    {
                        usuario.TelefonoLocal = "";
                    }
                }

                string DirectorioArchivo = Server.MapPath("~") + "\\images\\Eventos\\Catalogo_de_precios_eventos_corporativos_Asae.pdf";

                return Json(usuarios.AsaeWebSolicitudPreciosEventosCorporativos(usuario, DirectorioArchivo));
            }
            else
            {
                return Json("An Error Has occoured");
            }
        }

        [HttpPost]
        public JsonResult SolicitudBanTotal(Models.NuevoUsuario nuevoUsuario, Application.Usuarios usuarios)
        {
            if (nuevoUsuario != null)
            {
                Models.Usuario usuario = new Models.Usuario();
                foreach (var dt in nuevoUsuario.usuario)
                {
                    usuario = dt;

                    if (usuario.TelefonoLocal == null)
                    {
                        usuario.TelefonoLocal = "";
                    }
                }
                return Json(usuarios.AsaeWebSolicitudBanTotal(usuario));
            }
            else
            {
                return Json("An Error Has occoured");
            }

        }

        [HttpPost]
        public JsonResult SolicitudBanTotalAMSOFIPO(Models.NuevoUsuario nuevoUsuario, Application.Usuarios usuarios)
        {
            if (nuevoUsuario != null)
            {
                Models.Usuario usuario = new Models.Usuario();
                foreach (var dt in nuevoUsuario.usuario)
                {
                    usuario = dt;

                    if (usuario.TelefonoLocal == null)
                    {
                        usuario.TelefonoLocal = "";
                    }
                }
                return Json(usuarios.AsaeWebSolicitudBanTotalAMSOFIPO(usuario));
            }
            else
            {
                return Json("An Error Has occoured");
            }

        }
        
        [HttpPost]
        public JsonResult SolicitudEventos(Models.NuevoUsuario nuevoUsuario, Application.Usuarios usuarios)
        {


            if (nuevoUsuario != null)
            {
                Models.Usuario usuario = new Models.Usuario();

                foreach (var dt in nuevoUsuario.usuario)
                {
                    usuario = dt;

                    if (usuario.TelefonoMovil == null)
                    {
                        usuario.TelefonoMovil = "";
                    }

                    if (usuario.TelefonoLocal == null)
                    {
                        usuario.TelefonoLocal = "";
                    }
                }

                string DirectorioArchivo = Server.MapPath("~") + "\\images\\Eventos\\Catalogo_de_preciosEspacios_Corporativos_ASAE_Consultores.pdf";

                return Json(usuarios.AsaeWebSolicitudPreciosEventos(usuario, DirectorioArchivo));
            }
            else
            {
                return Json("An Error Has occoured");
            }
        }

        /************************************************************************************************************/
        [HttpPost]
        public JsonResult SolicitudDW(Models.NuevoUsuario nuevoUsuario, Application.Usuarios usuarios)
        {
            if (nuevoUsuario != null)
            {
                Models.Usuario usuario = new Models.Usuario();
                foreach (var dt in nuevoUsuario.usuario)
                {
                    usuario = dt;

                    if (usuario.TelefonoLocal == null)
                    {
                        usuario.TelefonoLocal = "";
                    }
                }

                Models.Mensaje mensaje = usuarios.AsaeWebSolicitudDW(usuario);
                Models.Email email = new Models.Email();
                email.cookie = mensaje.RespuestaText;
                if (mensaje.RespuestaText.Length > 0)
                {
                    Session["SesionDW"] = email;
                    mensaje.Respuesta = 1;
                    mensaje.RespuestaText = "";
                }

                return Json(mensaje);
            }
            else
            {
                return Json("An Error Has occoured");
            }
        }

        [HttpPost]
        public JsonResult ComprobarSolicitudDW(Models.NuevoUsuario nuevoUsuario, Application.Usuarios usuarios)
        {
            Models.Email email = new Models.Email();
            Models.Usuario usuario = new Models.Usuario();
            Models.Mensaje mensaje = new Models.Mensaje();
            if (Session["SesionDW"] != null)
            {
                email = (Models.Email)Session["SesionDW"];
                usuario.Clave = email.cookie;
                usuario.Ingreso = nuevoUsuario.usuario[0].Ingreso;
                // REGISTRAMOS Y DESCARGAMOS 

                mensaje = usuarios.CookieDW_Seleccionar(usuario);

                //mensaje.Respuesta = 1;
            }
            else
            {
                mensaje.Respuesta = 0;
            }

            return Json(mensaje);
        }

        /*************************************************************************************************************/
        /************************************************************************************************************/
        [HttpPost]
        public JsonResult SolicitudAsaeASD(Models.NuevoUsuario nuevoUsuario, Application.Usuarios usuarios)
        {
            if (nuevoUsuario != null)
            {
                Models.Usuario usuario = new Models.Usuario();
                foreach (var dt in nuevoUsuario.usuario)
                {
                    usuario = dt;

                    if (usuario.TelefonoLocal == null)
                    {
                        usuario.TelefonoLocal = "";
                    }
                }
                return Json(usuarios.AsaeWebSolicitudDemoAsaeASD(usuario));
            }
            else
            {
                return Json("An Error Has occoured");
            }

        }


    }
}
