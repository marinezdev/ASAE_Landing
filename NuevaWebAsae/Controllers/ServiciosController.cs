using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuevaWebAsae.Controllers
{
    public class ServiciosController : Controller
    {
        // GET: Servicios
        [Route("servicios/servicios-administrados-de-impresion")]
        public ActionResult Impresion()
        {
            return View();
        }

        [Route("servicios/servicios-administracion-de-infraestructura")]
        public ActionResult Infraestructura()
        {
            return View();
        }
        [Route("servicios/servicios-de-gestion-documental")]
        public ActionResult Documental()
        {
            return View();
        }

        [Route("servicios/servicios-en-la-nube")]
        public ActionResult NUBE()
        {
            return View();
        }

        [Route("servicios/servicios-en-telecomunicaciones")]
        public ActionResult Telecomunicaciones()
        {
            return View();
        }

        [Route("servicios/servicios-soporte-y-mantenimiento-multivendor")]
        public ActionResult Soporte()
        {
            return View();
        }

        [Route("bantotal")]
        public ActionResult BanTotal()
        {
            return View();
        }


        //[Route("servicios/seguridad")]
        public ActionResult Seguridad()
        {
            return View();
        }

    }
}
