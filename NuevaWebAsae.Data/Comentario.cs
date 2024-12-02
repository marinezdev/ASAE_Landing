using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class Comentario
    {
        ManejoDatos b = new ManejoDatos();
        public Models.Comentario Comentario_Agregar(Models.Comentario comentario)
        {
            b.ExecuteCommandSP("Comentario_Agregar");
            b.AddParameter("@IdArticulo", comentario.IdArticulo, SqlDbType.Int);
            b.AddParameter("@Nombre", comentario.Nombre, SqlDbType.NVarChar);
            b.AddParameter("@Email", comentario.Email, SqlDbType.NVarChar);
            b.AddParameter("@Comentario", comentario.Comentarios, SqlDbType.NVarChar);
            Models.Comentario resultado = new Models.Comentario();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Resultado = Convert.ToInt32(reader["Resultado"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Comentario Comentario_Desactivar(Models.Comentario comentario)
        {
            b.ExecuteCommandSP("Comentario_Desactivar");
            b.AddParameter("@Id", comentario.Id, SqlDbType.Int);
            Models.Comentario resultado = new Models.Comentario();
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

        public List<Models.Comentario> Comentario_Seleccionar_IdArticulo(int IdArticulo)
        {
            b.ExecuteCommandSP("Comentario_Seleccionar_IdArticulo");
            b.AddParameter("@IdArticulo", IdArticulo, SqlDbType.Int);
            List<Models.Comentario> resultado = new List<Models.Comentario>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Comentario item = new Models.Comentario()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    Comentarios = reader["Comentario"].ToString(),
                    Email = reader["Email"].ToString(),
                    FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"].ToString())
                };
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
        }

    }
}
