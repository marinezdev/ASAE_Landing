using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Models
{
    public class Prospecto
    {
        public int Id { get; set; } 
        public Vacante Vacante { get; set; }    
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set;}
        public string ApellidoMaterno { get; set; }
        public string TelefonoCelular { get; set; }
        public string TelefonoFijo { get; set; }
        public string CorreElectronico { get; set; }
        public string Observaciones { get; set; }

        public DateTime FechaRegistro { get; set; }


        public ProspectoArchivo ProspectoArchivo { get; set; }
        public ProspectoExperiencia ProspectoExperiencia { get; set; }
    }
}
