using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public class ProspectoMensaje
    {
        Data.ProspectoMensaje _ProspectoMensaje = new Data.ProspectoMensaje();
        public List<Models.ProspectoMensaje> ProspectoMensaje_Seleccionar_IdProspecto(Models.Prospecto prospecto)
        {
            return _ProspectoMensaje.ProspectoMensaje_Seleccionar_IdProspecto(prospecto);
        }
    }
}
