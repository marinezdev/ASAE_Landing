using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuevaWebAsae.Controllers
{
    public class EventosController : Controller
    {
        // GET: Eventos
        [Route("renta-espacios-corporativos")]
        public ActionResult Index()
        {
            return View();
        }
        [Route("eventos-corporativos")]
        public ActionResult Eventos()
        {
            return View();
        }
    }
}
