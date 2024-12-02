using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuevaWebAsae.Controllers
{
    public class CapacitacionController : Controller
    {
        [Route("capacitacion")]
        // GET: Capacitacion
        public ActionResult Index()
        {
            return View();
        }
        [Route("capacitacion/capacitacion-empresarial")]
        public ActionResult Empresarial()
        {
            return View();
        }
        [Route("capacitacion/interpretaciones-de-normas")]
        public ActionResult InterpretacionesNormas()
        {
            return View();
        }
        [Route("capacitacion/office")]
        public ActionResult Office()
        {
            return View();
        }
        [Route("capacitacion/publico-en-general")]
        public ActionResult PublicoGeneral()
        {
            return View();
        }
    }
}
