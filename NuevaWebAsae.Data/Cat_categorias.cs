using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class Cat_categorias
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.Cat_categorias> Seleccionar()
        {
            b.ExecuteCommandSP("Cat_categorias_Seleccionar");
            List<Models.Cat_categorias> resultado = new List<Models.Cat_categorias>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_categorias item = new Models.Cat_categorias()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString()
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<Models.Cat_categorias> Cat_categorias_Home_List()
        {
            b.ExecuteCommandSP("Cat_categorias_Home_List");
            List<Models.Cat_categorias> resultado = new List<Models.Cat_categorias>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_categorias item = new Models.Cat_categorias()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<Models.Cat_categorias> Cat_categorias_Vistas()
        {
            b.ExecuteCommandSP("Cat_categorias_Vistas");
            List<Models.Cat_categorias> resultado = new List<Models.Cat_categorias>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_categorias item = new Models.Cat_categorias()
                {
                    Nombre = reader["Nombre"].ToString(),
                    Total = Convert.ToInt32(reader["Total"].ToString()),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public Models.Cat_categorias NuevaCategoria(Models.Cat_categorias cat_Categorias)
        {
            b.ExecuteCommandSP("NuevaCategoria");
            b.AddParameter("@Nombre", cat_Categorias.Nombre, SqlDbType.NVarChar);
            Models.Cat_categorias resultado = new Models.Cat_categorias();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Resultado = Convert.ToInt32(reader["Resultado"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Cat_categorias> Categorias_Seleccionar()
        {
            b.ExecuteCommandSP("Categorias_Seleccionar");
            List<Models.Cat_categorias> resultado = new List<Models.Cat_categorias>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_categorias item = new Models.Cat_categorias()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    Activo = int.Parse(reader["Activo"].ToString()),
                    Total = int.Parse(reader["TOTAL"].ToString()),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public Models.Cat_categorias Categoria_Desactivar(Models.Cat_categorias cat_Categorias)
        {
            b.ExecuteCommandSP("Categoria_Desactivar");
            b.AddParameter("@Id", cat_Categorias.Id, SqlDbType.NVarChar);
            Models.Cat_categorias resultado = new Models.Cat_categorias();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Resultado = Convert.ToInt32(reader["Resultado"].ToString());
                resultado.ResultadoText = reader["ResultadoText"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public Models.Cat_categorias CategoriaActivar(Models.Cat_categorias cat_Categorias)
        {
            b.ExecuteCommandSP("CategoriaActivar");
            b.AddParameter("@Id", cat_Categorias.Id, SqlDbType.NVarChar);
            Models.Cat_categorias resultado = new Models.Cat_categorias();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Resultado = Convert.ToInt32(reader["Resultado"].ToString());
                resultado.ResultadoText = reader["ResultadoText"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

    }
}
