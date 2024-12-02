using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class EmpresasDepartamento
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.EmpresasDepartamento> EmpresasDepartamento_Seleccionar_IdEmpresa(Models.Empresas empresas)
        {
            const string consulta = "RH.EmpresasDepartamento_Seleccionar_IdEmpresa";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdEmpresa", empresas.Id, SqlDbType.Int);

            List<Models.EmpresasDepartamento> resultado = new List<Models.EmpresasDepartamento>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.EmpresasDepartamento>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
