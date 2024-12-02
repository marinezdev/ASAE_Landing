using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class VacanteBitacora
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.VacanteBitacora> VacanteBitacora_Seleccionar_IdVacante(Models.Vacante vacante)
        {
            const string consulta = "RH.Vacantes.VacanteBitacora_Seleccionar_IdVacante";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdVacante", vacante.Id, SqlDbType.Int);

            List<Models.VacanteBitacora> resultado = new List<Models.VacanteBitacora>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.VacanteBitacora>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.Consultas.Actividad> VacanteBitacora_Actividad_Mes(Models.Vacante vacante)
        {
            const string consulta = "RH.Vacantes.VacanteBitacora_Actividad_Mes";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdVacante", vacante.Id, SqlDbType.Int);

            List<Models.Consultas.Actividad> resultado = new List<Models.Consultas.Actividad>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Consultas.Actividad>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
