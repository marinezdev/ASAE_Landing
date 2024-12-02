using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuevaWebAsae.Controllers
{
    public class IntegracionTalentoController : Controller
    {
        //GET: IntegracionTalento
       [Route("integracion-de-talento")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("integracion-de-talento/reclutamiento-de-personal")]
        public ActionResult Reclutamiento()
        {
            return View();
        }

        [Route("integracion-de-talento/evaluaciones-psicometricas")]
        public ActionResult Evaluacion()
        {
            return View();
        }


        [Route("integracion-de-talento/administracion-de-nomina")]
        public ActionResult Nomina()
        {
            return View();
        }



    }
}
