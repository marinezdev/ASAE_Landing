using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class CatgoriaVacante
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.CatgoriaVacante> Seleccionar()
        {
            b.ExecuteCommandSP("Cat_CatgoriaVacante_Seleccionar");
            List<Models.CatgoriaVacante> resultado = new List<Models.CatgoriaVacante>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.CatgoriaVacante item = new Models.CatgoriaVacante()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }
    }
}
