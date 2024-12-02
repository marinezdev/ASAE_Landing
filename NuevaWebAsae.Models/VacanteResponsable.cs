using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Models
{
    public class VacanteResponsable
    {
        public int Id { get; set; }
        public Usuarios Usuarios;
        public Vacante Vacante { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Observaciones { get; set; }
    }
}
