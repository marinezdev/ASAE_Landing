using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class CatVacante
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.Catalogos> Cat_vacante_Seleccionar()
        {
            b.ExecuteCommandSP("Cat_vacante_Seleccionar");
            List<Models.Catalogos> resultado = new List<Models.Catalogos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Catalogos item = new Models.Catalogos()
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Nombre = reader["Nombre"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }
    }
}
