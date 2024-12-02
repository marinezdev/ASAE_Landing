using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public class ProspectoArchivo
    {
        Data.ProspectoArchivo _ProspectoArchivo = new Data.ProspectoArchivo();
        public Models.ProspectoArchivo ProspectoArchivo_Agregar(Models.ProspectoArchivo prospectoArchivo)
        {
            return _ProspectoArchivo.ProspectoArchivo_Agregar(prospectoArchivo);
        }

        public List<Models.ProspectoArchivo> ProspectoArchivo_Seleccionar_IdProspecto(Models.Prospecto prospecto)
        {
            return _ProspectoArchivo.ProspectoArchivo_Seleccionar_IdProspecto(prospecto);
        }
        public Models.ProspectoArchivo ProspectoArchivo_Seleccionar_Id(Models.ProspectoArchivo prospectoArchivo)
        {
            return _ProspectoArchivo.ProspectoArchivo_Seleccionar_Id(prospectoArchivo);
        }
    }
}
