using Newtonsoft.Json;
using NuevaWebAsae.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class Prospecto
    {
        ManejoDatos b = new ManejoDatos();
        public Models.Prospecto Prospecto_Agregar(Models.Prospecto prospecto)
        {
            const string consulta = "RH.Prospecto_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdVacante", prospecto.Vacante.Id, SqlDbType.Int);
            b.AddParameter("@Nombre", prospecto.Nombre, SqlDbType.NVarChar);
            b.AddParameter("@ApellidoPaterno", prospecto.ApellidoPaterno, SqlDbType.NVarChar);
            b.AddParameter("@ApellidoMaterno", prospecto.ApellidoMaterno, SqlDbType.NVarChar);
            b.AddParameter("@TelefonoCelular", prospecto.TelefonoCelular, SqlDbType.NVarChar);
            b.AddParameter("@TelefonoFijo", prospecto.TelefonoFijo, SqlDbType.NVarChar);
            b.AddParameter("@CorreElectronico", prospecto.CorreElectronico, SqlDbType.NVarChar);
            b.AddParameter("@Observaciones", prospecto.Observaciones, SqlDbType.NVarChar);
            

            Models.Prospecto resultado = new Models.Prospecto();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Prospecto>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.Prospecto Prospecto_Seleccionar_Id(Models.Prospecto prospecto)
        {
            const string consulta = "RH.Prospecto_Seleccionar_Id";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", prospecto.Id, SqlDbType.Int);
            Models.Prospecto resultado = new Models.Prospecto();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Prospecto>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Prospecto> Prospecto_Seleccionar()
        {
            const string consulta = "RH.Prospecto_Seleccionar";
            b.ExecuteCommandSP(consulta);

            List<Models.Prospecto> resultado = new List<Models.Prospecto>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Prospecto>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Prospecto Prospectos_Listar_Id(Models.Prospecto prospecto)
        {
            const string consulta = "RH.Prospectos_Listar_Id";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", prospecto.Id, SqlDbType.Int);

            Models.Prospecto resultado = new Models.Prospecto();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Prospecto>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Prospecto> Prospectos_Listar_IdVacante(Models.Vacante vacante)
        {
            const string consulta = "RH.Prospectos_Listar_IdVacante";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", vacante.Id, SqlDbType.Int);

            List<Models.Prospecto> resultado = new List<Models.Prospecto>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Prospecto>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
