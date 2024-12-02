using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public class Cat_JornadaTrabajo
    {
        Data.Cat_JornadaTrabajo _Cat_JornadaTrabajo = new Data.Cat_JornadaTrabajo();
        public List<Models.Cat_JornadaTrabajo> Cat_JornadaTrabajo_Seleccionar()
        {
            return _Cat_JornadaTrabajo.Cat_JornadaTrabajo_Seleccionar();
        }
    }
}
