using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class Cat_EsquemaContratacion
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Cat_EsquemaContratacion> Cat_EsquemaContratacion_Seleccionar()
        {
            const string consulta = "RH.Cat_EsquemaContratacion_Seleccionar";
            b.ExecuteCommandSP(consulta);

            List<Models.Cat_EsquemaContratacion> resultado = new List<Models.Cat_EsquemaContratacion>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Cat_EsquemaContratacion>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
