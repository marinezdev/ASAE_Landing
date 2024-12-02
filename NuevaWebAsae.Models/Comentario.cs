using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public int IdArticulo { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Comentarios { get; set; }
        
        public DateTime FechaRegistro { get; set; }

        public int Resultado { get; set; }
        public string ResultadoText { get; set; }
    }
}
