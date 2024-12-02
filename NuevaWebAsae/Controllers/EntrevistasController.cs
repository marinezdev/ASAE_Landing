using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuevaWebAsae.Controllers
{
    public class EntrevistasController : Controller
    {
        // GET: Entrevistas
        public ActionResult EntrevistaAceptada(Application.Prospecto APprospecto, Application.Vacante APvacante, Application.ProspectoExperiencia APprospectoExperiencia, Application.ProspectoArchivo APprospectoArchivo,
            Application.ProspectoBitacora APprospectoBitacora, Application.ProspectoEntrevista APprospectoEntrevista, Application.ProspectoNota APprospectoNota, Application.ProspectoMensaje APprospectoMensaje,
            Application.ProspectoCorreo APprospectoCorreo)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["sold"]))
            {
                int Id = Convert.ToInt32(Application.Cifrado.Desencriptar(Request.QueryString["sold"]));
                
                Models.Prospecto prospecto = new Models.Prospecto();    
                prospecto.Id = Id;

                Models.ProspectoEntrevista prospectoEntrevista = APprospectoEntrevista.ProspectoEntrevista_Consulta_Fecha(prospecto);
                if (prospectoEntrevista.Id > 0)
                {
                    Models.Prospecto dbProspecto = APprospecto.Prospecto_Seleccionar_Id(prospecto);
                    Models.Vacante dbVacante = APvacante.Vacante_Seleccionar_Id(dbProspecto.Vacante);

                    List<Models.ProspectoExperiencia> ListProspectoExperiencia = APprospectoExperiencia.ProspectoExperiencia_Seleccionar_IdProspecto(dbProspecto);
                    List<Models.ProspectoArchivo> ListProspectoArchivo = APprospectoArchivo.ProspectoArchivo_Seleccionar_IdProspecto(dbProspecto);
                    List<Models.ProspectoBitacora> ListvacanteBitacora = APprospectoBitacora.ProspectoBitacora_Seleccionar_IdProspecto(dbProspecto);
                    List<Models.ProspectoEntrevista> ListProspectoEntrevista = APprospectoEntrevista.ProspectoEntrevista_Seleccionar_IdProspecto(dbProspecto);
                    List<Models.ProspectoNota> ListProspectoNota = APprospectoNota.ProspectoNota_Seleccionar_IdProspecto(dbProspecto);
                    List<Models.ProspectoMensaje> ListProspectoMensaje = APprospectoMensaje.ProspectoMensaje_Seleccionar_IdProspecto(dbProspecto);
                    List<Models.ProspectoCorreo> ListProspectoCorreo = APprospectoCorreo.ProspectoCorreo_Seleccionar_IdProspecto(dbProspecto);

                    ViewBag.Vacante = dbVacante;
                    ViewBag.Prospecto = dbProspecto;
                    ViewBag.Entrevista = prospectoEntrevista;

                    ViewBag.ProspectoExperiencia = ListProspectoExperiencia;
                    ViewBag.ProspectoArchivo = ListProspectoArchivo;

                    ViewBag.Bitacora = ListvacanteBitacora;
                    ViewBag.ProspectoNota = ListProspectoNota;
                    ViewBag.Entrevistas = ListProspectoEntrevista;
                    ViewBag.Mensajes = ListProspectoMensaje;
                    ViewBag.Correos = ListProspectoCorreo;

                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Vacantes");
                }
                
            }
            else { return RedirectToAction("Index", "Vacantes"); }
        }

        public ActionResult ReagendarEntrevista(Application.Prospecto APprospecto, Application.Vacante APvacante, Application.ProspectoExperiencia APprospectoExperiencia, Application.ProspectoArchivo APprospectoArchivo,
            Application.ProspectoBitacora APprospectoBitacora, Application.ProspectoEntrevista APprospectoEntrevista, Application.ProspectoNota APprospectoNota, Application.ProspectoMensaje APprospectoMensaje,
            Application.ProspectoCorreo APprospectoCorreo)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["sold"]))
            {
                int Id = Convert.ToInt32(Application.Cifrado.Desencriptar(Request.QueryString["sold"]));

                Models.Prospecto prospecto = new Models.Prospecto();
                prospecto.Id = Id;

                Models.ProspectoEntrevista prospectoEntrevista = APprospectoEntrevista.ProspectoEntrevista_Consulta_Fecha(prospecto);
                if (prospectoEntrevista.Id > 0)
                {
                    Models.Prospecto dbProspecto = APprospecto.Prospecto_Seleccionar_Id(prospecto);
                    Models.Vacante dbVacante = APvacante.Vacante_Seleccionar_Id(dbProspecto.Vacante);

                    List<Models.ProspectoExperiencia> ListProspectoExperiencia = APprospectoExperiencia.ProspectoExperiencia_Seleccionar_IdProspecto(dbProspecto);
                    List<Models.ProspectoArchivo> ListProspectoArchivo = APprospectoArchivo.ProspectoArchivo_Seleccionar_IdProspecto(dbProspecto);
                    List<Models.ProspectoBitacora> ListvacanteBitacora = APprospectoBitacora.ProspectoBitacora_Seleccionar_IdProspecto(dbProspecto);
                    List<Models.ProspectoEntrevista> ListProspectoEntrevista = APprospectoEntrevista.ProspectoEntrevista_Seleccionar_IdProspecto(dbProspecto);
                    List<Models.ProspectoNota> ListProspectoNota = APprospectoNota.ProspectoNota_Seleccionar_IdProspecto(dbProspecto);
                    List<Models.ProspectoMensaje> ListProspectoMensaje = APprospectoMensaje.ProspectoMensaje_Seleccionar_IdProspecto(dbProspecto);
                    List<Models.ProspectoCorreo> ListProspectoCorreo = APprospectoCorreo.ProspectoCorreo_Seleccionar_IdProspecto(dbProspecto);

                    ViewBag.Vacante = dbVacante;
                    ViewBag.Prospecto = dbProspecto;
                    ViewBag.Entrevista = prospectoEntrevista;

                    ViewBag.ProspectoExperiencia = ListProspectoExperiencia;
                    ViewBag.ProspectoArchivo = ListProspectoArchivo;

                    ViewBag.Bitacora = ListvacanteBitacora;
                    ViewBag.ProspectoNota = ListProspectoNota;
                    ViewBag.Entrevistas = ListProspectoEntrevista;
                    ViewBag.Mensajes = ListProspectoMensaje;
                    ViewBag.Correos = ListProspectoCorreo;

                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Vacantes");
                }

            }
            else { return RedirectToAction("Index", "Vacantes"); }
        }

        [HttpPost]
        public JsonResult ProspectoEntrevista_Aceptar_Entrevista(Models.ProspectoEntrevista prospectoEntrevista, Application.ProspectoEntrevista APProspectoEntrevista)
        {
            Models.ProspectoEntrevista dbProspectoEntrevista = APProspectoEntrevista.ProspectoEntrevista_Aceptar_Entrevista(prospectoEntrevista);
            return Json(dbProspectoEntrevista);
        }

        [HttpPost]
        public JsonResult ProspectoEntrevista_Agendar_Entrevista(Models.ProspectoEntrevista prospectoEntrevista, Application.ProspectoEntrevista APProspectoEntrevista)
        {
            Models.ProspectoEntrevista dbProspectoEntrevista = APProspectoEntrevista.ProspectoEntrevista_Agendar_Entrevista(prospectoEntrevista);
            return Json(dbProspectoEntrevista);
        }
    }
}
