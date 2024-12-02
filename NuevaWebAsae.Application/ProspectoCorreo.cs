using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public class ProspectoCorreo
    {
        Data.ProspectoCorreo _ProspectoCorreo = new Data.ProspectoCorreo();
        public List<Models.ProspectoCorreo> ProspectoCorreo_Seleccionar_IdProspecto(Models.Prospecto prospecto)
        {
            return _ProspectoCorreo.ProspectoCorreo_Seleccionar_IdProspecto(prospecto);
        }
    }
}
