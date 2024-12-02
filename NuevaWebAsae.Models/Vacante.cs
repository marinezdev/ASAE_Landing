using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Models
{
    public class Vacante
    {
        public int Id { get; set; }
        public EmpresaPuestos EmpresaPuestos { get; set; }
        public Cat_ProyectoServicios Cat_ProyectoServicios { get; set; }
        public Cat_EsquemaContratacion Cat_EsquemaContratacion { get; set; }
        public ClienteDirecciones ClienteDirecciones { get; set; }
        public Cat_Modalidad Cat_Modalidad { get; set; }
        public Cat_JornadaTrabajo Cat_JornadaTrabajo { get; set; }
        public Cat_MotivosBajaEmpleado Cat_MotivosBajaEmpleado { get; set; }
        public Usuario Usuario { get; set; }
        public Empleados Empleados { get; set; }
        public string Titulo { get; set; }
        public int Salario { get; set; }
        public float SalarioInicial { get; set; }
        public float SalarioFinal { get; set; }
        public DateTime FechaCierre { get; set; }
        public int IdEmpleadoBaja { get; set; }
        public DateTime FechaBaja { get; set; }
        public string Contenido { get; set; }
        public int Notificacion { get; set; }
        public string FechaRegistro { get; set; }
        public int Prospecto { get; set; }

        public string img { get; set; }
    }
}
