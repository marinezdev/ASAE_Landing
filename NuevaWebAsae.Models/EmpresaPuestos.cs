using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Models
{
    public class EmpresaPuestos
    {
        public int Id { get; set; }
        public EmpresasDepartamento EmpresasDepartamento { get; set; }
        public string Nombre { get; set; }
    }
}
