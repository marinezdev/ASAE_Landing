using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class ProspectoMensaje
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.ProspectoMensaje> ProspectoMensaje_Seleccionar_IdProspecto(Models.Prospecto prospecto)
        {
            const string consulta = "RH.ProspectoMensaje_Seleccionar_IdProspecto";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdProspecto", prospecto.Id, SqlDbType.Int);

            List<Models.ProspectoMensaje> resultado = new List<Models.ProspectoMensaje>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.ProspectoMensaje>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
