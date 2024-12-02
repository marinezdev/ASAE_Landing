using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuevaWebAsae.Controllers
{
    public class EmailController : Controller
    {
        [HttpPost]
        public JsonResult LlamarJson(Models.CorreoEmail correoEmail, Application.Email enviarCorreo)
        {
            if (correoEmail != null)
            {
                return Json(enviarCorreo.ProcesaDatos(correoEmail));
            }
            else
            {
                return Json("An Error Has occoured");
            }
        }


        [HttpPost]
        public JsonResult MensajeASD(Models.CorreoEmail correoEmail, Application.Email enviarCorreo)
        {
            if (correoEmail != null)
            {
                return Json(enviarCorreo.MensajeASD(correoEmail));
            }
            else
            {
                return Json("An Error Has occoured");
            }
        }

        [HttpPost]
        public JsonResult MensajeJOBCTRL(Models.CorreoEmail correoEmail, Application.Email enviarCorreo)
        {
            if (correoEmail != null)
            {
                return Json(enviarCorreo.MensajeJOBCTRL(correoEmail));
            }
            else
            {
                return Json("An Error Has occoured");
            }
        }

        [HttpPost]
        public JsonResult MensajeHikvision(Models.CorreoEmail correoEmail, Application.Email enviarCorreo)
        {
            if (correoEmail != null)
            {
                return Json(enviarCorreo.MensajeHikvision(correoEmail));
            }
            else
            {
                return Json("An Error Has occoured");
            }
        }

        [HttpPost]
        public JsonResult MensajeHuawei(Models.CorreoEmail correoEmail, Application.Email enviarCorreo)
        {
            if (correoEmail != null)
            {
                return Json(enviarCorreo.MensajeHuawei(correoEmail));
            }
            else
            {
                return Json("An Error Has occoured");
            }
        }

        [HttpPost]
        public JsonResult MensajeIdeaHub(Models.CorreoEmail correoEmail, Application.Email enviarCorreo)
        {
            if (correoEmail != null)
            {
                return Json(enviarCorreo.MensajeIdeaHub(correoEmail));
            }
            else
            {
                return Json("An Error Has occoured");
            }
        }


        [HttpPost]
        public JsonResult MensajeCorporativoIndustrial(Models.CorreoEmail correoEmail, Application.Email enviarCorreo)
        {
            if (correoEmail != null)
            {
                return Json(enviarCorreo.MensajeCorporativoIndustrial(correoEmail));
            }
            else
            {
                return Json("An Error Has occoured");
            }
        }

        [HttpPost]
        public JsonResult MensajeServiciosSoluciones(Models.CorreoEmail correoEmail, Application.Email enviarCorreo)
        {
            if (correoEmail != null)
            {
                return Json(enviarCorreo.MensajeServiciosSoluciones(correoEmail));
            }
            else
            {
                return Json("An Error Has occoured");
            }
        }

        [HttpPost]
        public JsonResult MensajeTalentoHumano(Models.CorreoEmail correoEmail, Application.Email enviarCorreo)
        {
            if (correoEmail != null)
            {
                return Json(enviarCorreo.MensajeTalentoHumano(correoEmail));
            }
            else
            {
                return Json("An Error Has occoured");
            }

        }

        [HttpPost]
        public JsonResult MensajeEventoCorporativo(Models.CorreoEmail correoEmail, Application.Email enviarCorreo)
        {
            if (correoEmail != null)
            {
                return Json(enviarCorreo.MensajeEventoCorporativo(correoEmail));
            }
            else
            {
                return Json("An Error Has occoured");
            }
        }


        [HttpPost]
        public JsonResult MensajeBanTotal(Models.CorreoEmail correoEmail, Application.Email enviarCorreo)
        {
            if (correoEmail != null)
            {
                return Json(enviarCorreo.MensajeBanTotal(correoEmail));
            }
            else
            {
                return Json("An Error Has occoured");
            }
        }

        [HttpPost]
        public JsonResult MensajeEventos(Models.CorreoEmail correoEmail, Application.Email enviarCorreo)
        {
            if (correoEmail != null)
            {
                return Json(enviarCorreo.MensajeEventos(correoEmail));
            }
            else
            {
                return Json("An Error Has occoured");
            }
        }

        [HttpPost]
        public JsonResult MensajeAsaeASD(Models.CorreoEmail correoEmail, Application.Email enviarCorreo)
        {
            if (correoEmail != null)
            {
                return Json(enviarCorreo.MensajeAsaeASD(correoEmail));
            }
            else
            {
                return Json("An Error Has occoured");
            }
        }

    }
}
