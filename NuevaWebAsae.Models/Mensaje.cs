using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Models
{
    public class Mensaje
    {
        public string Token { get; set; }
        public string Email { get; set; }
        public string RespuestaText { get; set; }
        public int Respuesta { get; set; }
        public bool Validacion { get; set; }
    }
}
