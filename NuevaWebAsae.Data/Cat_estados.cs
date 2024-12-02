using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class Cat_estados
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.Cat_estados> Cat_Estados_Seleccionar()
        {
            const string consulta = "RH.Cat_Estados_Seleccionar";
            b.ExecuteCommandSP(consulta);

            List<Models.Cat_estados> resultado = new List<Models.Cat_estados>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Cat_estados>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
