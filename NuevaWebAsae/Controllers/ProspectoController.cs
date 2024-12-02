using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NuevaWebAsae.Models;
using System.Xml.Linq;
using NuevaWebAsae.Application;

namespace NuevaWebAsae.Controllers
{
    public class ProspectoController : Controller
    {
        // GET: Prospecto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Solicitud(Application.Vacante APvacante)
        {
            Session["ProspectoArchivo"] = null;
            Session["LstProspectoExperiencia"] = null;
            
            if (!String.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                int Id = Convert.ToInt32(Application.Cifrado.Desencriptar(Request.QueryString["Id"]));
                Models.Vacante vacante = new Models.Vacante(); 
                vacante.Id = Id;

                Models.Vacante dbvacante = APvacante.Vacante_Seleccionar_Id(vacante);

                ViewBag.Vacante = dbvacante;

                return View();
            }
            else { return RedirectToAction("Index", "Vacantes"); }
        }

        [HttpPost]
        public JsonResult Prospecto_Agregar(Models.Prospecto prospecto, Application.Prospecto APprospecto, Application.ProspectoArchivo APprospectoArchivo, Application.ProspectoExperiencia APprospectoExperiencia)
        {
            Models.ProspectoArchivo _prospectoArchivo = new Models.ProspectoArchivo();
            List<Models.ProspectoExperiencia> LstProspectoExperiencia = new List<Models.ProspectoExperiencia>();


            Models.Prospecto dbprospecto = APprospecto.Prospecto_Agregar(prospecto);

            if (dbprospecto.Id > 0)
            {
                if (Session["ProspectoArchivo"] != null)
                {
                    _prospectoArchivo = (Models.ProspectoArchivo)Session["ProspectoArchivo"];
                    _prospectoArchivo.Prospecto = dbprospecto;
                    APprospectoArchivo.ProspectoArchivo_Agregar(_prospectoArchivo);
                }

                if (Session["LstProspectoExperiencia"] != null)
                {
                    LstProspectoExperiencia = (List<Models.ProspectoExperiencia>)Session["LstProspectoExperiencia"];
                    foreach (Models.ProspectoExperiencia ProspectoExperiencia in LstProspectoExperiencia)
                    {
                        ProspectoExperiencia.Prospecto = dbprospecto;
                        APprospectoExperiencia.ProspectoExperiencia_Agregar(ProspectoExperiencia);
                    }
                }

            }

            return Json(dbprospecto);
        }

    }
}
