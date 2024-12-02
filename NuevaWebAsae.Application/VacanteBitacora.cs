using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public class VacanteBitacora
    {
        Data.VacanteBitacora _VacanteBitacora = new Data.VacanteBitacora();
        public List<Models.VacanteBitacora> VacanteBitacora_Seleccionar_IdVacante(Models.Vacante vacante)
        {
            return _VacanteBitacora.VacanteBitacora_Seleccionar_IdVacante(vacante);
        }
        public List<Models.Consultas.Actividad> VacanteBitacora_Actividad_Mes(Models.Vacante vacante)
        {
            return _VacanteBitacora.VacanteBitacora_Actividad_Mes(vacante);
        }
    }
}
