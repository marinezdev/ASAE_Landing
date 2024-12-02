using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuevaWebAsae.Controllers
{
    public class ClienteDireccionesController : Controller
    {
        [HttpPost]
        public JsonResult ClienteDirecciones_Agregar(Models.ClienteDirecciones clienteDireciones, Application.ClienteDireciones APclienteDireciones)
        {
            Models.ClienteDirecciones DBClienteDireciones = APclienteDireciones.ClienteDirecciones_Agregar(clienteDireciones);
            return Json(DBClienteDireciones);
        }

        [HttpPost]
        public JsonResult ClienteDirecciones_Seleccionar_IdCliente(Models.Cat_Clientes cat_Clientes, Application.ClienteDireciones APclienteDireciones)
        {
            List<Models.ClienteDirecciones> DBClienteDireciones = APclienteDireciones.ClienteDirecciones_Seleccionar_IdCliente(cat_Clientes);
            return Json(DBClienteDireciones);
        }
    }
}
