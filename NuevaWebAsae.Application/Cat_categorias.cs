using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public class Cat_categorias
    {
        Data.Cat_categorias _cat_Categorias = new Data.Cat_categorias();
        public List<Models.Cat_categorias> Seleccionar()
        {
            return _cat_Categorias.Seleccionar();
        }

        public List<Models.Cat_categorias> Cat_categorias_Home_List()
        {
            return _cat_Categorias.Cat_categorias_Home_List();
        }

        public List<Models.Cat_categorias> Cat_categorias_Vistas()
        {
            return _cat_Categorias.Cat_categorias_Vistas();
        }

        public Models.Cat_categorias NuevaCategoria(Models.Cat_categorias cat_Categorias)
        {
            return _cat_Categorias.NuevaCategoria(cat_Categorias);
        }

        public List<Models.Cat_categorias> Categorias_Seleccionar()
        {
            return _cat_Categorias.Categorias_Seleccionar();
        }

        public Models.Cat_categorias Categoria_Desactivar(Models.Cat_categorias cat_Categorias)
        {
            return _cat_Categorias.Categoria_Desactivar(cat_Categorias);
        }

        public Models.Cat_categorias CategoriaActivar(Models.Cat_categorias cat_Categorias)
        {
            return _cat_Categorias.CategoriaActivar(cat_Categorias);
        }
    }
}
