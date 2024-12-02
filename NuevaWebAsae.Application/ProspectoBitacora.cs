using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public class ProspectoBitacora
    {
        Data.ProspectoBitacora _ProspectoBitacora = new Data.ProspectoBitacora();
        public List<Models.ProspectoBitacora> ProspectoBitacora_Seleccionar_IdProspecto(Models.Prospecto prospecto)
        {
            return _ProspectoBitacora.ProspectoBitacora_Seleccionar_IdProspecto(prospecto);
        }
    }
}
