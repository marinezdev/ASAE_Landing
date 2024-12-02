using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Models
{
    public class ClienteDirecciones
    {
        public int Id { get; set; }
        public Cat_Clientes Cat_Clientes { get; set; }
        public Cat_Colonias Cat_Colonias { get; set; }
        public string NumExterior { get; set; }
        public string NumInteriror { get; set; }
        public string Calle { get; set; }
        public string EntreCalles { get; set; }
        public string Referencias { get; set; }
        public string Direccion { get; set; }
    }
}
