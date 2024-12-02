using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public  class Empleados
    {
        Data.Empleados _Empleados = new Data.Empleados();
        public List<Models.Empleados> Empleados_Seleccionar_IdPuesto(Models.EmpresaPuestos empresaPuestos)
        {
            return _Empleados.Empleados_Seleccionar_IdPuesto(empresaPuestos);
        }
    }
}
