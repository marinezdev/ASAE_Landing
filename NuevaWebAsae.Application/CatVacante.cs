using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public class CatVacante
    {
        Data.CatVacante _catVacante= new Data.CatVacante();
        public List<Models.Catalogos> Cat_vacante_Seleccionar()
        {
            return _catVacante.Cat_vacante_Seleccionar();
        }
    }
}
