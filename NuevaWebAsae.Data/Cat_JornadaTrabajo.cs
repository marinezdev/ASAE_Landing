using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class Cat_JornadaTrabajo
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Cat_JornadaTrabajo> Cat_JornadaTrabajo_Seleccionar()
        {
            const string consulta = "RH.Cat_JornadaTrabajo_Seleccionar";
            b.ExecuteCommandSP(consulta);

            List<Models.Cat_JornadaTrabajo> resultado = new List<Models.Cat_JornadaTrabajo>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Cat_JornadaTrabajo>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
