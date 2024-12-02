using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class ProspectoExperiencia
    {
        ManejoDatos b = new ManejoDatos();
        public Models.ProspectoExperiencia ProspectoExperiencia_Agregar(Models.ProspectoExperiencia prospectoExperiencia)
        {
            const string consulta = "RH.ProspectoExperiencia_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdProspecto", prospectoExperiencia.Prospecto.Id, SqlDbType.Int);
            b.AddParameter("@Cargo", prospectoExperiencia.Cargo, SqlDbType.NVarChar);
            b.AddParameter("@NombreEmpresa", prospectoExperiencia.NombreEmpresa, SqlDbType.NVarChar);
            b.AddParameter("@Funciones", prospectoExperiencia.Funciones, SqlDbType.NVarChar);
            b.AddParameter("@SueldoInicial", prospectoExperiencia.SueldoInicial, SqlDbType.Float);
            b.AddParameter("@SueldoFinal", prospectoExperiencia.SueldoFinal, SqlDbType.Float);
            b.AddParameter("@TrabajoActivo", prospectoExperiencia.TrabajoActivo, SqlDbType.Int);
            b.AddParameter("@FechaInicio", prospectoExperiencia.FechaInicio, SqlDbType.Date);
            b.AddParameter("@FechaTermino", prospectoExperiencia.FechaTermino, SqlDbType.Date);

            Models.ProspectoExperiencia resultado = new Models.ProspectoExperiencia();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ProspectoExperiencia>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.ProspectoExperiencia> ProspectoExperiencia_Listar_Id(Models.ProspectoExperiencia prospectoExperiencia)
        {
            const string consulta = "RH.ProspectoExperiencia_Listar_Id";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", prospectoExperiencia.Id, SqlDbType.Int);

            List<Models.ProspectoExperiencia> resultado = new List<Models.ProspectoExperiencia>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.ProspectoExperiencia>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.ProspectoExperiencia> ProspectoExperiencia_Seleccionar_IdProspecto(Models.Prospecto prospecto)
        {
            const string consulta = "RH.ProspectoExperiencia_Seleccionar_IdProspecto";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdProspecto", prospecto.Id, SqlDbType.Int);

            List<Models.ProspectoExperiencia> resultado = new List<Models.ProspectoExperiencia>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.ProspectoExperiencia>>(reader.GetValue(0).ToString());
            }
            b.CloseConnection();
            return resultado;
        }
    }
}
