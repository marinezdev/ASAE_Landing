using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class Cat_MotivosBajaEmpleado
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.Cat_MotivosBajaEmpleado> Cat_MotivosBajaEmpleado_Seleccionar()
        {
            const string consulta = "RH.Cat_MotivosBajaEmpleado_Seleccionar";
            b.ExecuteCommandSP(consulta);

            List<Models.Cat_MotivosBajaEmpleado> resultado = new List<Models.Cat_MotivosBajaEmpleado>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Cat_MotivosBajaEmpleado>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

    }
}
