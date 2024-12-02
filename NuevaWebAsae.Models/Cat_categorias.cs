using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Models
{
    public class Cat_categorias
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int Total { get; set; }
        public int Activo { get; set; }

        public int Resultado { get; set; }
        public string ResultadoText { get; set; }
    }
}
