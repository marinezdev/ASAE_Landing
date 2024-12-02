using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Models
{
    public class Articulo
    {
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Resumen { get; set; }
        public string Contenido { get; set; }
        public int IdUsuario { get; set; }

        public int Usuario { get; set; }
        public string UsuarioS { get; set; }
        public int Resultado { get; set; }
        public string ResultadoText { get; set; }


        public string Clave { get; set; }

        public string Imagen { get; set; }
        public string Categoria { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Activo { get; set; }
        public int Total { get; set; }
        public string Dia { get; set; }
    }
}
