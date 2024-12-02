using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class AsaeWebSeccion
    {
        ManejoDatos b = new ManejoDatos();

        public Models.Catalogos AsaeWebSeccion_Seleccionar_Descripcion(string Descripcion)
        {
            b.ExecuteCommandSP("AsaeWebSeccion_Seleccionar_Descripcion");
            b.AddParameter("@Descripcion", Descripcion, SqlDbType.NVarChar);

            Models.Catalogos resultado = new Models.Catalogos();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
