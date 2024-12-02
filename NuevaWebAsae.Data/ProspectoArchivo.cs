using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class ProspectoArchivo
    {
        ManejoDatos b = new ManejoDatos();
        public Models.ProspectoArchivo ProspectoArchivo_Agregar(Models.ProspectoArchivo prospectoArchivo)
        {
            const string consulta = "RH.ProspectoArchivo_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdProspecto", prospectoArchivo.Prospecto.Id, SqlDbType.Int);
            b.AddParameter("@IdTipoArchivo", prospectoArchivo.Cat_TipoArchivo.Id, SqlDbType.Int);
            b.AddParameter("@NmArchivo", prospectoArchivo.NmArchivo, SqlDbType.NVarChar);
            b.AddParameter("@NmOriginal", prospectoArchivo.NmOriginal, SqlDbType.NVarChar);
            b.AddParameter("@Extencion", prospectoArchivo.Extencion, SqlDbType.NVarChar);

            Models.ProspectoArchivo resultado = new Models.ProspectoArchivo();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ProspectoArchivo>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.ProspectoArchivo> ProspectoArchivo_Seleccionar_IdProspecto(Models.Prospecto prospecto)
        {
            const string consulta = "RH.ProspectoArchivo_Seleccionar_IdProspecto";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdProspecto", prospecto.Id, SqlDbType.Int);

            List<Models.ProspectoArchivo> resultado = new List<Models.ProspectoArchivo>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.ProspectoArchivo>>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }
        public Models.ProspectoArchivo ProspectoArchivo_Seleccionar_Id(Models.ProspectoArchivo prospectoArchivo)
        {
            const string consulta = "RH.ProspectoArchivo_Seleccionar_Id";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", prospectoArchivo.Id, SqlDbType.Int);

            Models.ProspectoArchivo resultado = new Models.ProspectoArchivo();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ProspectoArchivo>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }
    }
}
