using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuevaWebAsae.Controllers
{
    public class SolucionesTIController : Controller
    {
        // GET: SolucionesTI
        [Route("soluciones-ti/desarrollo-de-soluciones-a-la-medida")]
        public ActionResult Desarrollo()
        {
            return View();
        }
        [Route("soluciones-ti/fabrica-de-software")]
        public ActionResult Fabrica()
        {
            return View();
        }
        [Route("soluciones-ti/fabrica-de-pruebas")]
        public ActionResult Pruebas()
        {
            return View();
        }

        [Route("soluciones-ti/administracion-de-proyectos")]
        public ActionResult Proyectos()
        {
            return View();
        }

        [Route("soluciones-ti/analisis-de-soluciones-para-mejora-de-procesos")]
        public ActionResult Procesos()
        {
            return View();
        }
        

    }
}


                        