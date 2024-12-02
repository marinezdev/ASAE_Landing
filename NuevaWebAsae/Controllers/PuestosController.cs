using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuevaWebAsae.Controllers
{
    public class PuestosController : Controller
    {
        [HttpPost]
        public JsonResult Departamentos_Seleccionar_IdDepartamento(Models.EmpresasDepartamento empresasDepartamento, Application.EmpresaPuestos APEmpresaPuestos)
        {
            List<Models.EmpresaPuestos> departamentos = APEmpresaPuestos.EmpresaPuestos_Seleccionar_IdDepartamento(empresasDepartamento);
            return Json(departamentos);
        }
    }
}
