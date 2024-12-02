using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Models
{
    public class Imagen
    {
        public int Id { get; set; }
        public int IdArticulo { get; set; }
        public int IdArchivo { get; set; }
        public string NmImagen { get; set; }
        public string NmOriginal { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public int Activo { get; set; }
    }
}
