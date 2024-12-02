using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public class Cat_estados
    {
        Data.Cat_estados _Cat_estados = new Data.Cat_estados();
        public List<Models.Cat_estados> Cat_Estados_Seleccionar()
        {
            return _Cat_estados.Cat_Estados_Seleccionar();
        }
    }
}
