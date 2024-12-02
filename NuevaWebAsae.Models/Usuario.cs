using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Models
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NombreEmpresa { get; set; }
        public string CorreoEmpresa { get; set; }
        public string CorreoPersonal { get; set; }
        public string TelefonoMovil { get; set; }
        public string TelefonoLocal { get; set; }
        public string Clave { get; set; }
        public string Password { get; set; }
        public string Descripcion { get; set; }
        public string Evento { get; set; }
        public string Respuesta { get; set; }
        public string Ingreso { get; set; }
        public string Empresa { get; set; }

        public int Id { get; set; }
        public int IdRol { get; set; }
        public string usuario { get; set; }
        public string RutaAcceso { get; set; }
        public string ClaveSesion { get; set; }
        public bool Session { get; set; }
        public bool Result { get; set; }
    }

    public class NuevoUsuario
    {
        public List<Usuario> usuario { get; set; }
    }
}
