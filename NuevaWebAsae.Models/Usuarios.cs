using System;
namespace NuevaWebAsae.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public Personas Personas { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdRol { get; set; }
        public string NombreRol { get; set; }
        public string RutaAcceso { get; set; }
        public string Ruta { get; set; }
        public string Mensaje { get; set; }

        public string ClaveCoo { get; set; }
        public bool Session { get; set; }


    }
}

