using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class Empleados
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Empleados> Empleados_Seleccionar_IdPuesto(Models.EmpresaPuestos empresaPuestos)
        {
            const string consulta = "RH.Empleados_Seleccionar_IdPuesto";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdPuesto", empresaPuestos.Id, SqlDbType.Int);

            List<Models.Empleados> resultado = new List<Models.Empleados>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Empleados>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
