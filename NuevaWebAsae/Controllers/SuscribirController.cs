using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuevaWebAsae.Controllers
{
    public class SuscribirController : Controller
    {
        [Route("registro/solicitud-de-suscripcion")]
        // GET: Suscribir
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult LlamarJson(Models.CorreoEmail correoEmail, Application.Email enviarCorreo)
        {
            if (correoEmail != null)
            {
                return Json(enviarCorreo.ProcesaDatosSuscribir(correoEmail));
            }
            else
            {
                return Json("An Error Has occoured");
            }
        }

    }
}
