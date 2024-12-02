using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Models
{
    public class Empleados
    {
        public int Id { get; set; }
        public Personas Personas { get; set; }
        public EmpresaPuestos EmpresaPuestos { get; set; }
    }
}
