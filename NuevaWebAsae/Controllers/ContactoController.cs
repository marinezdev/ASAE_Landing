using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuevaWebAsae.Controllers
{
    public class ContactoController : Controller
    {
        // GET: Contacto
        [Route("contacto/atencion-a-clientes")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
