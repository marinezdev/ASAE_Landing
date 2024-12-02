using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class ControlArchivo
    {
        ManejoDatos b = new ManejoDatos();
        public Models.ControlArchivo NuevoArchivo()
        {
            const string consulta = "RH.Control_Archivos_Id";
            b.ExecuteCommandSP(consulta);

            Models.ControlArchivo resultado = new Models.ControlArchivo();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ControlArchivo>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
