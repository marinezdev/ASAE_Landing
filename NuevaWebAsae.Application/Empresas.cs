using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public class Empresas
    {
        Data.Empresas _empresas =  new Data.Empresas();
        public Models.Empresas Empresas_Agregar(Models.Empresas empresas)
        {
            return _empresas.Empresas_Agregar(empresas);
        }
        public List<Models.Empresas> Empresas_Seleccionar()
        {
            return _empresas.Empresas_Seleccionar();
        }
    }
}
