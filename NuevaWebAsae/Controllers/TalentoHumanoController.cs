using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuevaWebAsae.Controllers
{
    public class TalentoHumanoController : Controller
    {
        [Route("talento-humano")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
