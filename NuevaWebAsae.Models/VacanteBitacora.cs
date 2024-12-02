using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Models
{
    public class VacanteBitacora
    {
        public int Id { get; set; }
        public Vacante Vacante { get; set; }
        public Usuarios Usuarios { get; set; }
        public Cat_Operacion Cat_Operacion { get; set; }
        public string Nota { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
