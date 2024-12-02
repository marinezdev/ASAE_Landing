using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class Articulo
    {
        ManejoDatos b = new ManejoDatos();
        public Models.Articulo NuevoArticulo(Models.Articulo articulo)
        {
            b.ExecuteCommandSP("Articulo_Registrar");
            b.AddParameter("@IdCategoria", articulo.IdCategoria, SqlDbType.Int);
            b.AddParameter("@Titulo", articulo.Titulo, SqlDbType.NVarChar);
            b.AddParameter("@Autor", articulo.Autor, SqlDbType.NVarChar);
            b.AddParameter("@Resumen", articulo.Resumen, SqlDbType.NVarChar);
            b.AddParameter("@Contenido", articulo.Contenido, SqlDbType.NVarChar);
            b.AddParameter("@IdUsuario", articulo.IdUsuario, SqlDbType.Int);
            Models.Articulo resultado = new Models.Articulo();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Resultado = Convert.ToInt32(reader["Resultado"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Articulo Articulo_Actualizar(Models.Articulo articulo)
        {
            b.ExecuteCommandSP("Articulo_Actualizar");
            b.AddParameter("@Id", articulo.Id, SqlDbType.Int);
            b.AddParameter("@IdCategoria", articulo.IdCategoria, SqlDbType.Int);
            b.AddParameter("@Titulo", articulo.Titulo, SqlDbType.NVarChar);
            b.AddParameter("@Autor", articulo.Autor, SqlDbType.NVarChar);
            b.AddParameter("@Resumen", articulo.Resumen, SqlDbType.NVarChar);
            b.AddParameter("@Contenido", articulo.Contenido, SqlDbType.NVarChar);
            Models.Articulo resultado = new Models.Articulo();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Resultado = Convert.ToInt32(reader["Resultado"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Articulo Articulo_Selecionar_Id(Models.Articulo articulo)
        {
            b.ExecuteCommandSP("Articulo_Selecionar_Id");
            b.AddParameter("@Id", articulo.Id, SqlDbType.Int);
            Models.Articulo resultado = new Models.Articulo();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader["Id"].ToString());
                resultado.Titulo = reader["Titulo"].ToString();
                resultado.Autor = reader["Autor"].ToString();
                resultado.Contenido = reader["Contenido"].ToString();
                resultado.Categoria = reader["Categoria"].ToString();
                resultado.IdCategoria = int.Parse(reader["IdCategoria"].ToString());
                resultado.Resumen = reader["Resumen"].ToString();
                resultado.Imagen = reader["Imagen"].ToString();
                resultado.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.Articulo Articulo_Desactivar(Models.Articulo articulo)
        {
            b.ExecuteCommandSP("Articulo_Desactivar");
            b.AddParameter("@Id", articulo.Id, SqlDbType.Int);
            Models.Articulo resultado = new Models.Articulo();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Resultado = int.Parse(reader["Resultado"].ToString());
                resultado.ResultadoText = reader["ResultadoText"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Articulo> Articulo_Seleccionar()
        {
            b.ExecuteCommandSP("Articulo_Seleccionar");
            List<Models.Articulo> resultado = new List<Models.Articulo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Articulo item = new Models.Articulo()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    Titulo = reader["Titulo"].ToString(),
                    Resumen = reader["Resumen"].ToString(),
                    Autor = reader["Autor"].ToString(),
                    FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"].ToString()),
                    Activo = int.Parse(reader["Activo"].ToString()),
                    UsuarioS = reader["Usuario"].ToString(),
                    Imagen = reader["Imagen"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<Models.Articulo> Articulo_Seleccionar_IdCategoria (int Id)
        {
            b.ExecuteCommandSP("Articulo_Seleccionar_IdCategoria");
            b.AddParameter("@Id", Id, SqlDbType.Int);
            List<Models.Articulo> resultado = new List<Models.Articulo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Articulo item = new Models.Articulo()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    Titulo = reader["Titulo"].ToString(),
                    Resumen = reader["Resumen"].ToString(),
                    Autor = reader["Autor"].ToString(),
                    FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"].ToString()),
                    Activo = int.Parse(reader["Activo"].ToString()),
                    UsuarioS = reader["Usuario"].ToString(),
                    Imagen = reader["Imagen"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<Models.Articulo> Articulo_Categoria_Total()
        {
            b.ExecuteCommandSP("Articulo_Categoria_Total");
            List<Models.Articulo> resultado = new List<Models.Articulo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Articulo item = new Models.Articulo()
                {
                    Nombre = reader["Nombre"].ToString(),
                    Total = int.Parse(reader["Total"].ToString()),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<Models.Articulo> Articulos_Vistos_Mes()
        {
            b.ExecuteCommandSP("Articulos_Vistos_Mes");
            List<Models.Articulo> resultado = new List<Models.Articulo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Articulo item = new Models.Articulo()
                {
                    Dia = reader["Dia"].ToString(),
                    Total = int.Parse(reader["Total"].ToString()),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }


        public List<Models.Articulo> Articulo_Blog_Home()
        {
            b.ExecuteCommandSP("Articulo_Blog_Home");
            List<Models.Articulo> resultado = new List<Models.Articulo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Articulo item = new Models.Articulo()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Categoria = reader["Categoria"].ToString(),
                    Imagen = reader["Imagen"].ToString(),
                    Titulo = reader["Titulo"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<Models.Articulo> Articulo_Top()
        {
            b.ExecuteCommandSP("Articulo_Top");
            List<Models.Articulo> resultado = new List<Models.Articulo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Articulo item = new Models.Articulo()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Imagen = reader["Imagen"].ToString(),
                    Titulo = reader["Titulo"].ToString(),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<Models.Articulo> Articulo_Home_List()
        {
            b.ExecuteCommandSP("Articulo_Home_List");
            List<Models.Articulo> resultado = new List<Models.Articulo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Articulo item = new Models.Articulo()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Titulo = reader["Titulo"].ToString(),
                    Resumen = reader["Resumen"].ToString(),
                    Autor = reader["Autor"].ToString(),
                    Imagen = reader["Imagen"].ToString(),
                    FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"].ToString()),
                    Categoria = reader["Categoria"].ToString(),
                    IdCategoria = Convert.ToInt32(reader["IdCategoria"].ToString()),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<Models.Articulo> Articulo_Listar_Top5()
        {
            b.ExecuteCommandSP("Articulo_Listar_Top5");
            List<Models.Articulo> resultado = new List<Models.Articulo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Articulo item = new Models.Articulo()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Titulo = reader["Titulo"].ToString(),
                    Autor = reader["Autor"].ToString(),
                    Resumen = reader["Resumen"].ToString(),
                    Imagen = reader["Imagen"].ToString(),
                    FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"].ToString()),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<Models.Articulo> Articulo_Listar_Top2()
        {
            b.ExecuteCommandSP("Articulo_Listar_Top2");
            List<Models.Articulo> resultado = new List<Models.Articulo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Articulo item = new Models.Articulo()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Titulo = reader["Titulo"].ToString(),
                    Autor = reader["Autor"].ToString(),
                    Resumen = reader["Resumen"].ToString(),
                    Imagen = reader["Imagen"].ToString(),
                    Categoria = reader["Categoria"].ToString(),
                    IdCategoria = Convert.ToInt32(reader["IdCategoria"].ToString()),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<Models.Articulo> Articulo_Home_ListRamdom()
        {
            b.ExecuteCommandSP("Articulo_Home_ListRamdom");
            List<Models.Articulo> resultado = new List<Models.Articulo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Articulo item = new Models.Articulo()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Titulo = reader["Titulo"].ToString(),
                    Autor = reader["Autor"].ToString(),
                    Resumen = reader["Resumen"].ToString(),
                    Imagen = reader["Imagen"].ToString(),
                    Categoria = reader["Categoria"].ToString(),
                    IdCategoria = Convert.ToInt32(reader["IdCategoria"].ToString()),
                    FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"].ToString()),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }


        public List<Models.Articulo> Articulo_Listar_IdCategoria(int Id)
        {
            b.ExecuteCommandSP("Articulo_Listar_IdCategoria");
            b.AddParameter("@Id", Id, SqlDbType.Int);
            List<Models.Articulo> resultado = new List<Models.Articulo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Articulo item = new Models.Articulo()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Titulo = reader["Titulo"].ToString(),
                    Autor = reader["Autor"].ToString(),
                    Resumen = reader["Resumen"].ToString(),
                    Imagen = reader["Imagen"].ToString(),
                    Categoria = reader["Categoria"].ToString(),
                    IdCategoria = Convert.ToInt32(reader["IdCategoria"].ToString()),
                    FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"].ToString()),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public List<Models.Articulo> Articulo_Home_ListTendencia()
        {
            b.ExecuteCommandSP("Articulo_Home_ListTendencia");
            List<Models.Articulo> resultado = new List<Models.Articulo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Articulo item = new Models.Articulo()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Titulo = reader["Titulo"].ToString(),
                    Autor = reader["Autor"].ToString(),
                    Resumen = reader["Resumen"].ToString(),
                    Imagen = reader["Imagen"].ToString(),
                    Categoria = reader["Categoria"].ToString(),
                    IdCategoria = Convert.ToInt32(reader["IdCategoria"].ToString()),
                    FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"].ToString()),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public Models.Articulo Articulo_Seleccionar_Id(int Id)
        {
            b.ExecuteCommandSP("Articulo_Seleccionar_Id");
            b.AddParameter("@Id", Id, SqlDbType.Int);
            Models.Articulo resultado = new Models.Articulo();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader["Id"].ToString());
                resultado.Titulo = reader["Titulo"].ToString();
                resultado.Autor = reader["Autor"].ToString();
                resultado.Contenido = reader["Contenido"].ToString();
                resultado.Imagen = reader["Imagen"].ToString();
                resultado.Categoria = reader["Categoria"].ToString();
                resultado.IdCategoria = Convert.ToInt32(reader["IdCategoria"].ToString());
                resultado.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Articulo> Articulo_Selecionar_IdCategoria(int Id)
        {
            b.ExecuteCommandSP("Articulo_Selecionar_IdCategoria");
            b.AddParameter("@Id", Id, SqlDbType.Int);
            List<Models.Articulo> resultado = new List<Models.Articulo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Articulo item = new Models.Articulo()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Titulo = reader["Titulo"].ToString(),
                    Autor = reader["Autor"].ToString(),
                    Resumen = reader["Resumen"].ToString(),
                    Imagen = reader["Imagen"].ToString(),
                    Categoria = reader["Categoria"].ToString(),
                    FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"].ToString()),
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

        public Models.Articulo Articulo_Vista_Agregar(Models.Articulo articulo)
        {
            b.ExecuteCommandSP("Articulo_Vista_Agregar");
            b.AddParameter("@Idarticulo", articulo.Id, SqlDbType.Int);
            b.AddParameter("@Clave", articulo.Clave, SqlDbType.NVarChar);
            Models.Articulo resultado = new Models.Articulo();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader["IdArticulo"].ToString());
                resultado.Clave = reader["Clave"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Articulo Articulo_Vista_IdArticulo(int Id)
        {
            b.ExecuteCommandSP("Articulo_Vista_IdArticulo");
            b.AddParameter("@Id", Id, SqlDbType.Int);
            Models.Articulo resultado = new Models.Articulo();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Total = int.Parse(reader["Total"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
