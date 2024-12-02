using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public class Imagen
    {
        Data.Imagen _imagen = new Data.Imagen();
        public Models.Imagen Imagen_Registrar(Models.Imagen imagen)
        {
            return _imagen.Imagen_Registrar(imagen);
        }
    }
}
