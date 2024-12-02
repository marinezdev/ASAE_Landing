using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class Imagen
    {
        ManejoDatos b = new ManejoDatos();
        public Models.Imagen Imagen_Registrar(Models.Imagen imagen)
        {
            b.ExecuteCommandSP("Imagen_Registrar");
            b.AddParameter("@IdArticulo", imagen.IdArticulo, SqlDbType.Int);
            b.AddParameter("@IdArchivo", imagen.IdArchivo, SqlDbType.Int);
            b.AddParameter("@NmImagen", imagen.NmImagen, SqlDbType.NVarChar);
            b.AddParameter("@NmOriginal", imagen.NmOriginal, SqlDbType.NVarChar);
            b.AddParameter("@Descripcion", imagen.Descripcion, SqlDbType.NVarChar);
            Models.Imagen resultado = new Models.Imagen();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
