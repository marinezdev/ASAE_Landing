using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public class VacanteNota
    {
        Data.VacanteNota _VacanteNota = new Data.VacanteNota();
        public Models.VacanteNota VacanteNota_Agregar(Models.VacanteNota vacanteNota)
        {
            return _VacanteNota.VacanteNota_Agregar(vacanteNota);
        }
        public List<Models.VacanteNota> VacanteNota_Seleccionar_IdVacante(Models.Vacante vacante)
        {
            return _VacanteNota.VacanteNota_Seleccionar_IdVacante(vacante);
        }

        public Models.VacanteNota Vacante_Actualizar_nota(Models.VacanteNota vacanteNota)
        {
            return _VacanteNota.Vacante_Actualizar_nota(vacanteNota);
        }
        public Models.VacanteNota Vacante_Actualizar_entrevista(Models.VacanteNota vacanteNota)
        {
            return _VacanteNota.Vacante_Actualizar_entrevista(vacanteNota);
        }
    }
}
