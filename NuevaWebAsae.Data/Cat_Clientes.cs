using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class Cat_Clientes
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.Cat_Clientes> Cat_Clientes_Seleccionar()
        {
            const string consulta = "RH.Cat_Clientes_Seleccionar";
            b.ExecuteCommandSP(consulta);

            List<Models.Cat_Clientes> resultado = new List<Models.Cat_Clientes>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Cat_Clientes>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Cat_Clientes> Cat_Clientes_Seleccionar_IdEmpresa(Models.Empresas empresas)
        {
            const string consulta = "RH.Cat_Clientes_Seleccionar_IdEmpresa";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdEmpresa", empresas.Id, SqlDbType.VarChar);

            List<Models.Cat_Clientes> resultado = new List<Models.Cat_Clientes>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Cat_Clientes>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
