using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public class CatgoriaVacante
    {
        Data.CatgoriaVacante _catgoriaVacante = new Data.CatgoriaVacante();
        public List<Models.CatgoriaVacante> Seleccionar()
        {
            return _catgoriaVacante.Seleccionar();
        }
    }
}
