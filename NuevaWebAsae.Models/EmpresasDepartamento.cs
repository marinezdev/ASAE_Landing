using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Models
{
    public class EmpresasDepartamento
    {
        public int Id { get; set; }
        public Empresas Empresas { get; set; }
        public string Nombre { get; set; }
    }
}
