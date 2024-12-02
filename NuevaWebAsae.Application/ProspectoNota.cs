using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public class ProspectoNota
    {
        Data.ProspectoNota _ProspectoNota = new Data.ProspectoNota();
        public List<Models.ProspectoNota> ProspectoNota_Seleccionar_IdProspecto(Models.Prospecto prospecto)
        {
            return _ProspectoNota.ProspectoNota_Seleccionar_IdProspecto(prospecto);
        }
    }
}
