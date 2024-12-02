using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public class EmpresaPuestos
    {
        Data.EmpresaPuestos _EmpresaPuestos = new Data.EmpresaPuestos();
        public List<Models.EmpresaPuestos> EmpresaPuestos_Seleccionar_IdDepartamento(Models.EmpresasDepartamento empresasDepartamento)
        {
            return _EmpresaPuestos.EmpresaPuestos_Seleccionar_IdDepartamento(empresasDepartamento);
        }
    }
}
