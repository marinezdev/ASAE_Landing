using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuevaWebAsae.Controllers
{
    public class SolucionesController : Controller
    {
        // GET: Soluciones
        //[Route("soluciones/software-de-gestion-de-proyectos-xpinnit")]  
        [Route("xpinnit")]
        public ActionResult Xpinnit()
        {
            return View();
        }
        [Route("jobctrl")]
        public ActionResult jobctrl()
        {
            return View();
        }

        [Route("hikvision")]
        public ActionResult hikvision()
        {
            return View();
        }

        [Route("soluciones/estados-de-cuenta-bancoppel")]
        public ActionResult BanCoppel()
        {
            return View();
        }

        [Route("asd")]
        public ActionResult Tickets()
        {
            return View();
        }

        [Route("asae-service-desk")]
        public ActionResult TicketsASD()
        {
            return View();
        }

        [Route("asae-service-desk-asd")]
        public ActionResult asd()
        {
            return View();
        }

        [Route("asd-itsm")]
        public ActionResult itsm()
        {
            return View();
        }

        [Route("oceanstor-dorado")]
        public ActionResult OceanstorDorado()
        {
            return View();
        }


        [Route("huawei-ideahub")]
        public ActionResult Ideahub()
        {
            return View();
        }
        [Route("corporativo-e-industria")]
        public ActionResult CorporativoIndustria()
        {
            return View();
        }
    }
}
