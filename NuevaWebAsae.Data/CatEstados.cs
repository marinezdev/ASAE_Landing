using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class CatEstados
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.Catalogos> Seleccionar()
        {
            b.ExecuteCommandSP("Cat_Estados_Seleccionar");
            List<Models.Catalogos> resultado = new List<Models.Catalogos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Catalogos item = new Models.Catalogos()
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Nombre = reader["Estado"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }
    }
}
