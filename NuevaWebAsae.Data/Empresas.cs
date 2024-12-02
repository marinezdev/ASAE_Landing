using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class Empresas
    {
        ManejoDatos b = new ManejoDatos();
        public Models.Empresas Empresas_Agregar(Models.Empresas empresas)
        {
            const string consulta = "RH.Empresas_Seleccionar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@RazonSocial", empresas.RazonSocial, SqlDbType.VarChar);
            b.AddParameter("@NombreComercial", empresas.NombreComercial, SqlDbType.VarChar);
            b.AddParameter("@Alias", empresas.Alias, SqlDbType.VarChar);
            b.AddParameter("@RFC", empresas.RFC, SqlDbType.VarChar);

            Models.Empresas resultado = new Models.Empresas();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Empresas>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.Empresas> Empresas_Seleccionar()
        {
            const string consulta = "RH.Empresas_Seleccionar";
            b.ExecuteCommandSP(consulta);

            List<Models.Empresas> resultado = new List<Models.Empresas>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Empresas>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
