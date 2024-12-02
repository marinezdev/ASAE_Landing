using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class ProspectoEntrevista
    {
        ManejoDatos b = new ManejoDatos();

        public Models.ProspectoEntrevista ProspectoEntrevista_Seleccionar_Id(Models.ProspectoEntrevista prospectoEntrevista)
        {
            const string consulta = "RH.ProspectoEntrevista_Seleccionar_Id";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", prospectoEntrevista.Id, SqlDbType.Int);

            Models.ProspectoEntrevista resultado = new Models.ProspectoEntrevista();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ProspectoEntrevista>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.ProspectoEntrevista ProspectoEntrevista_Consulta_Fecha(Models.Prospecto prospecto)
        {
            const string consulta = "RH.ProspectoEntrevista_Consulta_Fecha";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdProspecto", prospecto.Id, SqlDbType.Int);

            Models.ProspectoEntrevista resultado = new Models.ProspectoEntrevista();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ProspectoEntrevista>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.ProspectoEntrevista ProspectoEntrevista_Aceptar_Entrevista(Models.ProspectoEntrevista prospectoEntrevista)
        {
            const string consulta = "RH.ProspectoEntrevista_Aceptar_Entrevista";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdProspecto", prospectoEntrevista.Prospecto.Id, SqlDbType.Int);
            b.AddParameter("@IdEntrevista", prospectoEntrevista.Id, SqlDbType.Int);
            b.AddParameter("@Observaciones", prospectoEntrevista.Observaciones, SqlDbType.NVarChar);

            Models.ProspectoEntrevista resultado = new Models.ProspectoEntrevista();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ProspectoEntrevista>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.ProspectoEntrevista ProspectoEntrevista_Agendar_Entrevista(Models.ProspectoEntrevista prospectoEntrevista)
        {
            const string consulta = "RH.ProspectoEntrevista_Agendar_Entrevista";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdProspecto", prospectoEntrevista.Prospecto.Id, SqlDbType.Int);
            b.AddParameter("@IdEntrevista", prospectoEntrevista.Id, SqlDbType.Int);
            b.AddParameter("@Observaciones", prospectoEntrevista.Observaciones, SqlDbType.NVarChar);
            b.AddParameter("@FechaEntrevista", prospectoEntrevista.FechaEntrevista, SqlDbType.DateTime);

            Models.ProspectoEntrevista resultado = new Models.ProspectoEntrevista();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ProspectoEntrevista>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.ProspectoEntrevista> ProspectoEntrevista_Seleccionar_IdVacante(Models.Vacante vacante)
        {
            const string consulta = "RH.Vacantes.ProspectoEntrevista_Seleccionar_IdVacante";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdVacante", vacante.Id, SqlDbType.Int);

            List<Models.ProspectoEntrevista> resultado = new List<Models.ProspectoEntrevista>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.ProspectoEntrevista>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.ProspectoEntrevista> ProspectoEntrevista_Seleccionar_IdProspecto(Models.Prospecto prospecto)
        {
            const string consulta = "RH.Vacantes.ProspectoEntrevista_Seleccionar_IdProspecto";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdProspecto", prospecto.Id, SqlDbType.Int);

            List<Models.ProspectoEntrevista> resultado = new List<Models.ProspectoEntrevista>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.ProspectoEntrevista>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.VacanteResponsable ProspectoEntrevista_Seleccionar_Responsable(Models.ProspectoEntrevista prospectoEntrevista)
        {
            const string consulta = "RH.ProspectoEntrevista_Seleccionar_Responsable";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", prospectoEntrevista.Id, SqlDbType.Int);

            Models.VacanteResponsable resultado = new Models.VacanteResponsable();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.VacanteResponsable>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
