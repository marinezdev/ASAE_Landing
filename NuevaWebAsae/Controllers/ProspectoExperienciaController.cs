using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuevaWebAsae.Controllers
{
    public class ProspectoExperienciaController : Controller
    {
        [HttpPost]
        public JsonResult ProspectoExperiencia_Agregar_Lista(Models.ProspectoExperiencia prospectoExperiencia, Application.ProspectoExperiencia APprospectoExperiencia)
        {
            List<Models.ProspectoExperiencia> LstProspectoExperiencia = new List<Models.ProspectoExperiencia>();

            if (Session["LstProspectoExperiencia"] != null)
            {
                LstProspectoExperiencia = (List<Models.ProspectoExperiencia>)Session["LstProspectoExperiencia"];
            }
            prospectoExperiencia.Id = APprospectoExperiencia.ProspectoExperiencia_NuevoId().Id;
            LstProspectoExperiencia.Add(prospectoExperiencia);

            Session["LstProspectoExperiencia"] = LstProspectoExperiencia;

            return Json(LstProspectoExperiencia);
        }

        [HttpPost]
        public JsonResult ProspectoExperiencia_Eliminar_Lista(Models.ProspectoExperiencia prospectoExperiencia)
        {
            List<Models.ProspectoExperiencia> LstProspectoExperiencia = new List<Models.ProspectoExperiencia>();

            if (Session["LstProspectoExperiencia"] != null)
            {
                LstProspectoExperiencia = (List<Models.ProspectoExperiencia>)Session["LstProspectoExperiencia"];
            }

            for (int i = 0; i < LstProspectoExperiencia.Count; i++)
            {
                if (LstProspectoExperiencia[i].Id == prospectoExperiencia.Id)
                {
                    LstProspectoExperiencia.Remove(LstProspectoExperiencia[i]);
                }
            }

            Session["LstProspectoExperiencia"] = LstProspectoExperiencia;

            return Json(LstProspectoExperiencia);
        }

        [HttpPost]
        public JsonResult ProspectoExperiencia_Listar()
        {
            List<Models.ProspectoExperiencia> LstProspectoExperiencia = new List<Models.ProspectoExperiencia>();

            if (Session["LstProspectoExperiencia"] != null)
            {
                LstProspectoExperiencia = (List<Models.ProspectoExperiencia>)Session["LstProspectoExperiencia"];
            }

            return Json(LstProspectoExperiencia);
        }

        [HttpPost]
        public JsonResult ProspectoExperiencia_Listar_Id(Models.ProspectoExperiencia prospectoExperiencia, Application.ProspectoExperiencia AprospectoExperiencia)
        {
            List<Models.ProspectoExperiencia> RprospectoExperiencia = AprospectoExperiencia.ProspectoExperiencia_Listar_Id(prospectoExperiencia);

            return Json(RprospectoExperiencia);
        }


   
    }
}
