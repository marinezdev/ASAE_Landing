using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class ClienteDirecciones
    {
        ManejoDatos b = new ManejoDatos();
        public Models.ClienteDirecciones ClienteDirecciones_Agregar(Models.ClienteDirecciones clienteDireciones)
        {
            const string consulta = "ClienteDirecciones_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdCliente", clienteDireciones.Cat_Clientes.Id, SqlDbType.Int);
            b.AddParameter("@IdColonia", clienteDireciones.Cat_Colonias.Id, SqlDbType.Int);
            b.AddParameter("@Calle", clienteDireciones.Calle, SqlDbType.VarChar);
            b.AddParameter("@NumExterior", clienteDireciones.NumExterior, SqlDbType.VarChar);
            b.AddParameter("@NumInteriror", clienteDireciones.NumInteriror, SqlDbType.VarChar);
            b.AddParameter("@EntreCalles", clienteDireciones.EntreCalles, SqlDbType.VarChar);
            b.AddParameter("@Referencias", clienteDireciones.Referencias, SqlDbType.VarChar);

            Models.ClienteDirecciones resultado = new Models.ClienteDirecciones();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ClienteDirecciones>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.ClienteDirecciones> ClienteDirecciones_Seleccionar_IdCliente(Models.Cat_Clientes cat_Clientes)
        {
            const string consulta = "RH.ClienteDirecciones_Seleccionar_IdCliente";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdCliente", cat_Clientes.Id, SqlDbType.Int);

            List<Models.ClienteDirecciones> resultado = new List<Models.ClienteDirecciones>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.ClienteDirecciones>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
