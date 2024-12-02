using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public class CatColonias
    {
        Data.CatColonias _catColonias = new Data.CatColonias();

        public List<Models.Catalogos> Seleccionar(int Id)
        {
            List<Models.Catalogos> cat_colonias = _catColonias.Seleccionar(Id);
            return cat_colonias;
        }
    }
}
