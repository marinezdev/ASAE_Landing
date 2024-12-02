using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class CatColonias
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Catalogos> Seleccionar(int Id)
        {
            b.ExecuteCommandSP("Cat_Colonias_Seleccionar");
            b.AddParameter("@IdPolacion", Id, SqlDbType.Int);
            List<Models.Catalogos> resultado = new List<Models.Catalogos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Catalogos item = new Models.Catalogos()
                {
                    Id = int.Parse(reader["IdCP"].ToString()),
                    Nombre = reader["Colonia"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }
    }
}
