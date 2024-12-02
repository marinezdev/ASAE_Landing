using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class ProspectoCorreo
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.ProspectoCorreo> ProspectoCorreo_Seleccionar_IdProspecto(Models.Prospecto prospecto)
        {
            const string consulta = "RH.ProspectoCorreo_Seleccionar_IdProspecto";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdProspecto", prospecto.Id, SqlDbType.Int);

            List<Models.ProspectoCorreo> resultado = new List<Models.ProspectoCorreo>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.ProspectoCorreo>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
