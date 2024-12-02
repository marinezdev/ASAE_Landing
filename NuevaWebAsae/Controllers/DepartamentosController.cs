using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuevaWebAsae.Controllers
{
    public class DepartamentosController : Controller
    {
        [HttpPost]
        public JsonResult Departamentos_Seleccionar_IdEmpresa(Models.Empresas empresas, Application.EmpresasDepartamento APempresasDepartamento)
        {
            List<Models.EmpresasDepartamento> departamentos = APempresasDepartamento.EmpresasDepartamento_Seleccionar_IdEmpresa(empresas);
            return Json(departamentos);
        }
    }
}
