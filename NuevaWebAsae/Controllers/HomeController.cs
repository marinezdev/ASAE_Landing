using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuevaWebAsae.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        //[Route("web/usuarios-y-asociados/intranet")]
        public ActionResult intranet()
        {
            return View();
        }

        [Route("web/usuarios-y-asociados/intranet")]
        public ActionResult intranet2()
        {
            return View();
        }

        [Route("herramientas-y-articulos/eventos-y-clasificaciones")]
        public ActionResult Eventos()
        {
            return View();
        }

        [Route("asae-consultores/quien-es-asae-consultores")]
        public ActionResult Asae()
        {
            return View();
        }

        [Route("asae-consultores/historia-asae-consultores")]
        public ActionResult Historia()
        {
            return View();
        }

        [Route("asae-consultores/experiencia-asae-consultores")]
        public ActionResult Experiencia()
        {
            return View();
        }

        [Route("asae-consultores/aviso-de-privacidad")]
        public ActionResult AvisoPrivacidad()
        {
            return View();
        }


        
    }
}