using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public class ClienteDireciones
    {
        Data.ClienteDirecciones _ClienteDireciones = new Data.ClienteDirecciones();

        public Models.ClienteDirecciones ClienteDirecciones_Agregar(Models.ClienteDirecciones clienteDireciones)
        {
            return _ClienteDireciones.ClienteDirecciones_Agregar(clienteDireciones);
        }

        public List<Models.ClienteDirecciones> ClienteDirecciones_Seleccionar_IdCliente(Models.Cat_Clientes cat_Clientes)
        {
            return _ClienteDireciones.ClienteDirecciones_Seleccionar_IdCliente(cat_Clientes);
        }
    }
}
