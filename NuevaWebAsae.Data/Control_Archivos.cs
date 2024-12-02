using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class Control_Archivos
    {
        ManejoDatos b = new ManejoDatos();
        public Models.Control_Archivos NuevoArchivo()
        {
            b.ExecuteCommandSP("Control_Archivos_Id");

            Models.Control_Archivos resultado = new Models.Control_Archivos();
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
