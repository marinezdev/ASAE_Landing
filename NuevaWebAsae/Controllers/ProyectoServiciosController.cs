using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuevaWebAsae.Controllers
{
    public class ProyectoServiciosController : Controller
    {
        [HttpPost]
        public JsonResult ProyectoServicios_Seleccionar_IdCliente(Models.Cat_Clientes cat_Clientes, Application.Cat_ProyectoServicios APCat_ProyectoServicios)
        {
            List<Models.Cat_ProyectoServicios> cat_ProyectoServicios = APCat_ProyectoServicios.Cat_ProyectoServicios_Seleccionar_IdCliente(cat_Clientes);
            return Json(cat_ProyectoServicios);
        }
    }
}
