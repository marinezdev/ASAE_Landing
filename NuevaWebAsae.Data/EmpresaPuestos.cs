using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class EmpresaPuestos
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.EmpresaPuestos> EmpresaPuestos_Seleccionar_IdDepartamento(Models.EmpresasDepartamento empresasDepartamento)
        {
            const string consulta = "RH.EmpresaPuestos_Seleccionar_IdDepartamento";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdDepartamento", empresasDepartamento.Id, SqlDbType.Int);

            List<Models.EmpresaPuestos> resultado = new List<Models.EmpresaPuestos>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.EmpresaPuestos>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
