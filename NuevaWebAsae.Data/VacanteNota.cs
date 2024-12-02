using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class VacanteNota
    {
        ManejoDatos b = new ManejoDatos();

        public Models.VacanteNota VacanteNota_Agregar(Models.VacanteNota vacanteNota)
        {
            const string consulta = "RH.Vacantes.VacanteNota_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdVacante", vacanteNota.Vacante.Id, SqlDbType.Int);
            b.AddParameter("@IdUsuario", vacanteNota.Usuarios.Id, SqlDbType.Int);
            b.AddParameter("@Nota", vacanteNota.Nota, SqlDbType.VarChar);

            Models.VacanteNota resultado = new Models.VacanteNota();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.VacanteNota>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.VacanteNota> VacanteNota_Seleccionar_IdVacante(Models.Vacante vacante)
        {
            const string consulta = "RH.Vacantes.VacanteNota_Seleccionar_IdVacante";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdVacante", vacante.Id, SqlDbType.Int);

            List<Models.VacanteNota> resultado = new List<Models.VacanteNota>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.VacanteNota>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public Models.VacanteNota Vacante_Actualizar_nota(Models.VacanteNota vacanteNota)
        {
            const string consulta = "RH.Vacante_Actualizar_nota";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", vacanteNota.Id, SqlDbType.Int);
            b.AddParameter("@Nota", vacanteNota.Nota, SqlDbType.VarChar);
            b.AddParameter("@IdUsuario", vacanteNota.Usuario.Id, SqlDbType.Int);
            b.AddParameter("@IdVacante", vacanteNota.Vacante.Id, SqlDbType.Int);

            Models.VacanteNota resultado = new Models.VacanteNota();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.VacanteNota>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public Models.VacanteNota Vacante_Actualizar_entrevista(Models.VacanteNota vacanteNota)
        {
            const string consulta = "RH.Vacante_Actualizar_Entrevista";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", vacanteNota.Id, SqlDbType.Int);
            b.AddParameter("@Observaciones", vacanteNota.Nota, SqlDbType.VarChar);
            b.AddParameter("@IdUsuario", vacanteNota.Usuario.Id, SqlDbType.Int);
            b.AddParameter("@IdVacante", vacanteNota.Vacante.Id, SqlDbType.Int);

            Models.VacanteNota resultado = new Models.VacanteNota();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.VacanteNota>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }

}
