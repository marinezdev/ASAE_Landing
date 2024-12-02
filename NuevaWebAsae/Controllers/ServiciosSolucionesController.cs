using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuevaWebAsae.Controllers
{
    public class ServiciosSolucionesController : Controller
    {
        // GET: ServiciosSoluciones
        [Route("servicios-y-soluciones")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
