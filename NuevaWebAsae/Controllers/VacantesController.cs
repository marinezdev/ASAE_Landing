using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NuevaWebAsae.Models;
using System.Web.Mvc;
using System.Xml.Linq;
using NuevaWebAsae.Application;

namespace NuevaWebAsae.Controllers
{
    public class VacantesController : Controller
    {
        Models.Usuario SesionUsuario = (Models.Usuario)System.Web.HttpContext.Current.Session["Sesion"];

        // GET: Vacantes
        public ActionResult Index(Application.Vacante APVacante)
        {
            List<Models.Vacante> dbVacantes = APVacante.Vacante_Seleccionar_General();
            ViewBag.Vacantes = dbVacantes;
            return View();
        }

        public ActionResult InfoVacante(Application.Vacante APVacante)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                int Id = Convert.ToInt32(Application.Cifrado.Desencriptar(Request.QueryString["Id"]));

                Models.Vacante vacante = new Models.Vacante();
                vacante.Id = Id;

                Models.Vacante respuesta = APVacante.Vacante_Seleccionar_Id(vacante);

                ViewBag.vacante = respuesta;

                return View();
            }
            else { return RedirectToAction("Index", "Home"); }
        }
        public ActionResult Work(Application.Vacante APvacante, Application.Prospecto APprospecto)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            if (Sesion(url))
            {
                ViewBag.Vacante = APvacante.Vacante_Seleccionar(SesionUsuario);
                ViewBag.Prospectos = APprospecto.Prospecto_Seleccionar();
                ViewBag.Usuario = SesionUsuario;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Adm");
            }
        }
        public ActionResult Vacantes(Application.Vacante APVacante)
        {
            List<Models.Vacante> dbVacantes = APVacante.Vacante_Seleccionar(SesionUsuario);

            ViewBag.Vacantes = dbVacantes;
            return View();
        }
        public ActionResult VacanteEditar(Application.Vacante APVacante, Application.Empresas APempresas, Application.Cat_Clientes APcat_Clientes, Application.Cat_EsquemaContratacion APCat_EsquemaContratacion, Application.Cat_estados APcat_Estados, Application.Cat_Modalidad APcat_Modalidad, Application.Cat_JornadaTrabajo APcat_JornadaTrabajo, Application.Cat_MotivosBajaEmpleado APcat_MotivosBajaEmpleado)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            if (Sesion(url))
            {
                if (!String.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    int Id = Convert.ToInt32(Application.Cifrado.Desencriptar(Request.QueryString["Id"]));

                    Models.Vacante vacante = new Models.Vacante();
                    vacante.Id = Id;

                    Models.Vacante respuesta = APVacante.Vacante_Pintar_Id(vacante);

                    ViewBag.vacante = respuesta;

                    List<Models.Empresas> empresas = APempresas.Empresas_Seleccionar();
                    List<Models.Cat_Clientes> cat_Clientes = APcat_Clientes.Cat_Clientes_Seleccionar();
                    List<Models.Cat_EsquemaContratacion> cat_EsquemaContratacion = APCat_EsquemaContratacion.Cat_EsquemaContratacion_Seleccionar();
                    List<Models.Cat_estados> cat_Estados = APcat_Estados.Cat_Estados_Seleccionar();
                    List<Models.Cat_Modalidad> cat_Modalidad = APcat_Modalidad.Cat_Modalidad_Seleccionar();
                    List<Models.Cat_JornadaTrabajo> cat_JornadaTrabajo = APcat_JornadaTrabajo.Cat_JornadaTrabajo_Seleccionar();
                    List<Models.Cat_MotivosBajaEmpleado> cat_MotivosBajaEmpleado = APcat_MotivosBajaEmpleado.Cat_MotivosBajaEmpleado_Seleccionar();

                    ViewBag.Empresas = empresas;
                    ViewBag.Clientes = cat_Clientes;
                    ViewBag.EsquemaContratacion = cat_EsquemaContratacion;
                    ViewBag.Estados = cat_Estados;
                    ViewBag.Modalidad = cat_Modalidad;
                    ViewBag.JornadaTrabajo = cat_JornadaTrabajo;
                    ViewBag.MotivosBajaEmpleado = cat_MotivosBajaEmpleado;

                    return View();
                }
                else { return RedirectToAction("Index", "Home"); }
            }
            else
            {
                return RedirectToAction("Index", "Adm");
            }
        }
        public ActionResult NewWork(Application.Empresas APempresas, Application.Cat_Clientes APcat_Clientes, Application.Cat_EsquemaContratacion APCat_EsquemaContratacion, Application.Cat_estados APcat_Estados, Application.Cat_Modalidad APcat_Modalidad, Application.Cat_JornadaTrabajo APcat_JornadaTrabajo, Application.Cat_MotivosBajaEmpleado APcat_MotivosBajaEmpleado, Application.Vacante APVacante)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            if (Sesion(url))
            {
                if (!String.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    int Id = Convert.ToInt32(Application.Cifrado.Desencriptar(Request.QueryString["Id"]));

                    Models.Vacante vacante = new Models.Vacante();
                    vacante.Id = Id;
                    Models.Vacante dbVacantes = APVacante.PlantillaVacante_Listar_Id(vacante);
                    ViewBag.VacantesPlantilla = dbVacantes;
                }

                if (!String.IsNullOrEmpty(Request.QueryString["IdS"]))
                {
                    int Id = Convert.ToInt32(Application.Cifrado.Desencriptar(Request.QueryString["IdS"]));

                    Models.Vacante vacante = new Models.Vacante();
                    vacante.Id = Id;

                    Models.Vacante respuesta = APVacante.Vacante_Pintar_Id(vacante);

                    ViewBag.vacante = respuesta;
                }

                List<Models.Empresas> empresas = APempresas.Empresas_Seleccionar();
                List<Models.Cat_Clientes> cat_Clientes = APcat_Clientes.Cat_Clientes_Seleccionar();
                List<Models.Cat_EsquemaContratacion> cat_EsquemaContratacion = APCat_EsquemaContratacion.Cat_EsquemaContratacion_Seleccionar();
                List<Models.Cat_estados> cat_Estados = APcat_Estados.Cat_Estados_Seleccionar();
                List<Models.Cat_Modalidad> cat_Modalidad = APcat_Modalidad.Cat_Modalidad_Seleccionar();
                List<Models.Cat_JornadaTrabajo> cat_JornadaTrabajo = APcat_JornadaTrabajo.Cat_JornadaTrabajo_Seleccionar();
                List<Models.Cat_MotivosBajaEmpleado> cat_MotivosBajaEmpleado = APcat_MotivosBajaEmpleado.Cat_MotivosBajaEmpleado_Seleccionar();

                ViewBag.Empresas = empresas;
                ViewBag.Clientes = cat_Clientes;
                ViewBag.EsquemaContratacion = cat_EsquemaContratacion;
                ViewBag.Estados = cat_Estados;
                ViewBag.Modalidad = cat_Modalidad;
                ViewBag.JornadaTrabajo = cat_JornadaTrabajo;
                ViewBag.MotivosBajaEmpleado = cat_MotivosBajaEmpleado;

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Adm");
            }
        }

        public ActionResult MostrarVacante(Application.Vacante APVacante, Application.Prospecto AProspecto,Application.VacanteBitacora APvacanteBitacora,
            Application.VacanteNota APvacanteNota, Application.ProspectoEntrevista APprospectoEntrevista)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            if (Sesion(url))
            {
                if (!String.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    int Id = Convert.ToInt32(Application.Cifrado.Desencriptar(Request.QueryString["Id"]));
                    Models.Vacante vacante = new Models.Vacante();
                    vacante.Id = Id;
                    Models.Vacante respuesta = APVacante.Vacante_Seleccionar_Id(vacante);
                    List<Models.Prospecto> Rprospecto = AProspecto.Prospectos_Listar_IdVacante(vacante);
                    ViewBag.vacante = respuesta;
                    ViewBag.Prospecto = Rprospecto;



                    List<Models.VacanteBitacora> ListvacanteBitacora = APvacanteBitacora.VacanteBitacora_Seleccionar_IdVacante(vacante);
                    List<Models.VacanteNota> ListVacanteNota = APvacanteNota.VacanteNota_Seleccionar_IdVacante(vacante);
                    List<Models.ProspectoEntrevista> ListProspectoEntrevista = APprospectoEntrevista.ProspectoEntrevista_Seleccionar_IdVacante(vacante);

                    ViewBag.Bitacora = ListvacanteBitacora;
                    ViewBag.VacanteNota = ListVacanteNota;
                    ViewBag.Entrevistas = ListProspectoEntrevista;

                    return View();
                }
                else { return RedirectToAction("Index", "Home"); }
            }
            else
            {
                return RedirectToAction("Index", "Adm");
            }
        }


        public ActionResult VacantePredisenio(Application.Vacante APVacante)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            if (Sesion(url))
            {
                List<Models.Vacante> dbVacantes = APVacante.PlantillaVacante_Listar();
                ViewBag.Vacantes = dbVacantes;

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Adm");
            }
        }

        [HttpPost]
        public JsonResult Vacante_Agregar(Models.Vacante vacante, Application.Vacante APVacante)
        {
            Models.Vacante _vacante = new Models.Vacante();
            vacante.Usuario = SesionUsuario;
            _vacante = APVacante.Vacante_Agregar(vacante);
            return Json(_vacante);
        }

        [HttpPost]
        public JsonResult Vacante_Seleccionar_Id(Models.Vacante vacante, Application.Vacante Appvacante)
        {
            Models.Vacante respuesta = Appvacante.Vacante_Seleccionar_Id(vacante);

            return Json(respuesta);
        }

        [HttpPost]
        public JsonResult Vacante_Consultar(Models.Vacante vacante, Application.Vacante Appvacante)
        {
            Models.Vacante respuesta = Appvacante.Vacante_Consultar(vacante);

            return Json(respuesta);
        }

        [HttpPost]
        public JsonResult Vacante_ConsultarProyecto(Models.Vacante vacante, Application.Vacante Appvacante)
        {
            Models.Vacante respuesta = Appvacante.Vacante_ConsultarProyecto(vacante);

            return Json(respuesta);
        }

        [HttpPost]
        public JsonResult Vacante_Actualizar(Models.Vacante vacante, Application.Vacante APVacante)
        {
            Models.Vacante _vacante = new Models.Vacante();
            vacante.Usuario = SesionUsuario;
            _vacante = APVacante.Vacante_Actualizar(vacante);
            return Json(_vacante);
        }

        [HttpPost]
        public JsonResult Prospectos_Listar_Id(Models.Prospecto prospecto, Application.Prospecto AProspecto)
        {
            Models.Prospecto Rprospecto = AProspecto.Prospectos_Listar_Id(prospecto);

            return Json(Rprospecto);
        }

        [HttpPost]
        public JsonResult Vacante_Actualizar_nota(Models.VacanteNota VacanteNota, Application.VacanteNota APPVacanteNota)
        {
            Models.VacanteNota R = new Models.VacanteNota();

            VacanteNota.Usuario = SesionUsuario;
            R = APPVacanteNota.Vacante_Actualizar_nota(VacanteNota);
            return Json(R);
        }

        [HttpPost]
        public JsonResult PlantillaVacante_Listar_Id(Models.Vacante vacante, Application.Vacante APVacante)
        {
            Models.Vacante dbVacantes = APVacante.PlantillaVacante_Listar_Id(vacante);

            return Json(dbVacantes);
        }

        [HttpPost]
        public JsonResult Vacante_Actualizar_entrevista(Models.VacanteNota VacanteNota, Application.VacanteNota APPVacanteNota)
        {
            Models.VacanteNota R = new Models.VacanteNota();

            VacanteNota.Usuario = SesionUsuario;
            R = APPVacanteNota.Vacante_Actualizar_entrevista(VacanteNota);
            return Json(R);
        }

        public bool Sesion(string url)
        {
            bool result = false;
            Application.Menu menu = new Application.Menu();

            if (menu.ValidacionPagina(SesionUsuario, url))
            {
                result = true;
            }
            return result;
        }
    }
}
