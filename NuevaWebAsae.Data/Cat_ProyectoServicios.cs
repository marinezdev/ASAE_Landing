using Newtonsoft.Json;
using NuevaWebAsae.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class Cat_ProyectoServicios
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Cat_ProyectoServicios> Cat_ProyectoServicios_Seleccionar_IdCliente(Models.Cat_Clientes cat_Clientes)
        {
            const string consulta = "RH.Cat_ProyectoServicios_Seleccionar_IdCliente";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdCliente", cat_Clientes.Id, SqlDbType.Int);

            List<Models.Cat_ProyectoServicios> resultado = new List<Models.Cat_ProyectoServicios>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Cat_ProyectoServicios>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
