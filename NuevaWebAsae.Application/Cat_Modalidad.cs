using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public class Cat_Modalidad
    {
        Data.Cat_Modalidad _Cat_Modalidad = new Data.Cat_Modalidad();
        public List<Models.Cat_Modalidad> Cat_Modalidad_Seleccionar()
        {
            return _Cat_Modalidad.Cat_Modalidad_Seleccionar();
        }
    }
}
