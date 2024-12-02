using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class UsuarioResponsable
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.UsuarioResponsable> UsuarioResponsable_Seleccionar()
        {
            const string consulta = "RH.UsuarioResponsable_Seleccionar";
            b.ExecuteCommandSP(consulta);

            List<Models.UsuarioResponsable> resultado = new List<Models.UsuarioResponsable>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.UsuarioResponsable>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
