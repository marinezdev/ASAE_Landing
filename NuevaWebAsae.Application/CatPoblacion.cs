using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public class CatPoblacion
    {
        Data.CatPoblacion _catPoblacion = new Data.CatPoblacion();

        public List<Models.Catalogos> Seleccionar(int Id)
        {
            List<Models.Catalogos> cat_poblacion = _catPoblacion.Seleccionar(Id);
            return cat_poblacion;
        }
    }
}
