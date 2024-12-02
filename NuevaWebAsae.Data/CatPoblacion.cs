using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class CatPoblacion
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.Catalogos> Seleccionar(int Id)
        {
            b.ExecuteCommandSP("Cat_Poblaciones_Seleccionar");
            b.AddParameter("@IdEstado", Id, SqlDbType.Int);
            List<Models.Catalogos> resultado = new List<Models.Catalogos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Catalogos item = new Models.Catalogos()
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Nombre = reader["Poblacion"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }
    }
}
