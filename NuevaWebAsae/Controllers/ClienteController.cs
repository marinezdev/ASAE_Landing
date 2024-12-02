using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuevaWebAsae.Controllers
{
    public class ClienteController : Controller
    {
        [HttpPost]
        public JsonResult Cat_Clientes_Listar_IdEmpresa(Models.Empresas empresas, Application.Cat_Clientes APCat_Clientes)
        {
            List<Models.Cat_Clientes> Clientes = APCat_Clientes.Cat_Clientes_Seleccionar_IdEmpresa(empresas);
            return Json(Clientes);
        }
    }
}
