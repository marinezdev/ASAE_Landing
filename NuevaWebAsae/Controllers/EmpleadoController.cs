using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuevaWebAsae.Controllers
{
    public class EmpleadoController : Controller
    {
        [HttpPost]
        public JsonResult Empleados_Seleccionar_IdPuesto(Models.EmpresaPuestos empresaPuestos, Application.Empleados APEmpleados)
        {
            List<Models.Empleados> ListEmpleados = APEmpleados.Empleados_Seleccionar_IdPuesto(empresaPuestos);
            return Json(ListEmpleados);
        }
    }
}
