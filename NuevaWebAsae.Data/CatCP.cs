using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class CatCP
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Catalogos> Seleccionar(int Id)
        {
            b.ExecuteCommandSP("Cat_CP_Seleccionar");
            b.AddParameter("@Id", Id, SqlDbType.Int);
            List<Models.Catalogos> resultado = new List<Models.Catalogos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Catalogos item = new Models.Catalogos()
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Nombre = reader["CP"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<Models.Direccion> Cat_CP_Busqueda(string CP)
        {
            b.ExecuteCommandSP("Cat_CP_Busqueda");
            b.AddParameter("@CP", CP, SqlDbType.NVarChar);
            List<Models.Direccion> resultado = new List<Models.Direccion>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Direccion item = new Models.Direccion()
                {
                    IdEstado = int.Parse(reader["IdEstado"].ToString()),
                    Estado = reader["Estado"].ToString(),
                    IdPoblacion = int.Parse(reader["IdPoblacion"].ToString()),
                    Poblacion = reader["Poblacion"].ToString(),
                    IdColonia = int.Parse(reader["IdColonia"].ToString()),
                    Colonia = reader["Colonia"].ToString(),
                    IdCP = int.Parse(reader["IdCP"].ToString()),
                    CP = reader["CP"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }
    }
}
