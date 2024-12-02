using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public  class EmpresasDepartamento
    {
        Data.EmpresasDepartamento _EmpresasDepartamento = new Data.EmpresasDepartamento();
        public List<Models.EmpresasDepartamento> EmpresasDepartamento_Seleccionar_IdEmpresa(Models.Empresas empresas)
        {
            return _EmpresasDepartamento.EmpresasDepartamento_Seleccionar_IdEmpresa(empresas);
        }
    }
}
