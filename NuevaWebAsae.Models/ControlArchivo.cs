using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Models
{
    public class ControlArchivo
    {
        public int Id { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Activo { get; set; }
        public string Clave { get; set; }
    }
}
