using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Models
{
    public class ProspectoArchivo
    {
        public int Id { get; set; }
        public Prospecto Prospecto { get; set; }
        public Cat_TipoArchivo Cat_TipoArchivo { get; set; }
        public string NmArchivo { get; set; }
        public string NmOriginal { get; set; }
        public string Extencion { get; set; }
        public int Referencia { get; set; }
    }
}
