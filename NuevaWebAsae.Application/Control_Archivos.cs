using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public class Control_Archivos
    {
        Data.Control_Archivos _Control_Archivos = new Data.Control_Archivos();
        public Models.Control_Archivos NuevoArchivo()
        {
            return _Control_Archivos.NuevoArchivo();
        }
    }
}
