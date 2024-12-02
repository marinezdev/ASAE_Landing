using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public class Cat_ProyectoServicios
    {
        Data.Cat_ProyectoServicios  _ProyectoServicios =  new Data.Cat_ProyectoServicios();
        public List<Models.Cat_ProyectoServicios> Cat_ProyectoServicios_Seleccionar_IdCliente(Models.Cat_Clientes cat_Clientes)
        {
            return _ProyectoServicios.Cat_ProyectoServicios_Seleccionar_IdCliente(cat_Clientes);
        }
    }
}
