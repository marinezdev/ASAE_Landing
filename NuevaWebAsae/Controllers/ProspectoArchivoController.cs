using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuevaWebAsae.Controllers
{
    public class ProspectoArchivoController : Controller
    {
        [HttpPost]
        public JsonResult ProspectoArchivo_Agregar_Lista(Models.ProspectoArchivo prospectoArchivo)
        {
            Session["ProspectoArchivo"] = prospectoArchivo;
            return Json(prospectoArchivo);
        }

        [HttpPost]
        public JsonResult ProspectoArchivo_Eliminar_Lista(Models.ProspectoArchivo prospectoArchivo)
        {
            Session["ProspectoArchivo"] = null;
            return Json(prospectoArchivo);
        }

        [HttpPost]
        public JsonResult ProspectoArchivo_Consultar_Lista()
        {
            Models.ProspectoArchivo _prospectoArchivo = new Models.ProspectoArchivo();
            Models.ProspectoArchivo _prospectoArchivo2 = new Models.ProspectoArchivo();
            string DirectorioURL = "";
            if (Session["ProspectoArchivo"] != null)
            {
                _prospectoArchivo = (Models.ProspectoArchivo)Session["ProspectoArchivo"];
            }

            DirectorioURL = System.Web.HttpContext.Current.Request.Url.Authority + "\\PDF\\Prospectos\\" + _prospectoArchivo.NmArchivo;
            _prospectoArchivo2.NmArchivo = DirectorioURL;
            _prospectoArchivo2.NmOriginal = _prospectoArchivo.NmOriginal;
            return Json(_prospectoArchivo2);
        }

        [HttpPost]
        public JsonResult ProspectoArchivo_Consultar_Listas(Models.ProspectoArchivo prospectoArchivo)
        {
            Models.ProspectoArchivo _prospectoArchivo = new Models.ProspectoArchivo();
            Models.ProspectoArchivo _prospectoArchivo2 = new Models.ProspectoArchivo();
            string DirectorioURL = "";
       
            _prospectoArchivo = prospectoArchivo;
            

            DirectorioURL = System.Web.HttpContext.Current.Request.Url.Authority + "\\PDF\\Prospectos\\" + _prospectoArchivo.NmArchivo;
            _prospectoArchivo2.NmArchivo = DirectorioURL;
            _prospectoArchivo2.NmOriginal = _prospectoArchivo.NmOriginal;
            return Json(_prospectoArchivo2);
        }

        [HttpPost]
        public JsonResult ProspectoArchivo_Seleccionar_Id(Models.ProspectoArchivo prospectoArchivo, Application.ProspectoArchivo APProspectoArchivo)
        {
            Models.ProspectoArchivo dbProspectoArchivo = APProspectoArchivo.ProspectoArchivo_Seleccionar_Id(prospectoArchivo);
            return Json(dbProspectoArchivo);
        }
    }
}
