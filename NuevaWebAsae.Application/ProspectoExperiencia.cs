using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public class ProspectoExperiencia
    {
        Data.ControlArchivo _ControlArchivo = new Data.ControlArchivo();
        Data.ProspectoExperiencia _ProspectoExperiencia = new Data.ProspectoExperiencia();
        public Models.ProspectoExperiencia ProspectoExperiencia_NuevoId()
        {
            Models.ProspectoExperiencia _ProspectoExperiencia = new Models.ProspectoExperiencia();
            Models.ControlArchivo archivo = _ControlArchivo.NuevoArchivo();
            _ProspectoExperiencia.Id = archivo.Id;
            return _ProspectoExperiencia;
        }

        public List<Models.ProspectoExperiencia> ProspectoExperiencia_Seleccionar_IdProspecto(Models.Prospecto prospecto)
        {
            return _ProspectoExperiencia.ProspectoExperiencia_Seleccionar_IdProspecto(prospecto);
        }

        public Models.ProspectoExperiencia ProspectoExperiencia_Agregar(Models.ProspectoExperiencia prospectoExperiencia)
        {
            return _ProspectoExperiencia.ProspectoExperiencia_Agregar(prospectoExperiencia);
        }

        public List <Models.ProspectoExperiencia> ProspectoExperiencia_Listar_Id(Models.ProspectoExperiencia prospectoExperiencia)
        {
            return _ProspectoExperiencia.ProspectoExperiencia_Listar_Id(prospectoExperiencia);
        }
    }
}
