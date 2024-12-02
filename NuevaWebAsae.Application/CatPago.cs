using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public class CatPago
    {
        Data.CatPago _catPago = new Data.CatPago();
        public List<Models.Catalogos> Cat_pago_Seleccionar()
        {
            return _catPago.Cat_pago_Seleccionar();
        }
    }
}
