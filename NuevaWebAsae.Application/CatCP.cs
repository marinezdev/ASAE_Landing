using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public class CatCP
    {
        Data.CatCP _catCP = new Data.CatCP();

        public List<Models.Catalogos> Seleccionar(int Id)
        {
            List<Models.Catalogos> cat_cp = _catCP.Seleccionar(Id);
            return cat_cp;
        }

        public List<Models.Direccion> Cat_CP_Busqueda(string CP)
        {
            List<Models.Direccion> direcciones = _catCP.Cat_CP_Busqueda(CP);
            return direcciones;
        }
    }
}
