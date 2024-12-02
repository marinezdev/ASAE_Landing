using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public class Cat_Clientes
    {
        Data.Cat_Clientes _Cat_Clientes = new Data.Cat_Clientes();
        public List<Models.Cat_Clientes> Cat_Clientes_Seleccionar()
        {
            return _Cat_Clientes.Cat_Clientes_Seleccionar();
        }

        public List<Models.Cat_Clientes> Cat_Clientes_Seleccionar_IdEmpresa(Models.Empresas empresas)
        {
            return _Cat_Clientes.Cat_Clientes_Seleccionar_IdEmpresa(empresas);
        }
    }
}
