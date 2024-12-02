using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public class CatEstados
    {
        Data.CatEstados _catEstados = new Data.CatEstados();

        public List<Models.Catalogos> Seleccionar()
        {
            List<Models.Catalogos> cat_estados = _catEstados.Seleccionar();
            return cat_estados;
        }
    }
}
