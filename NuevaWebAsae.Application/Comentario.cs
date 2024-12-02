using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public class Comentario
    {
		private Data.Comentario _comentario = new Data.Comentario();

		public Models.Comentario Comentario_Agregar(Models.Comentario comentario)
		{
			return _comentario.Comentario_Agregar(comentario);
		}

		public Models.Comentario Comentario_Desactivar(Models.Comentario comentario)
		{
			return _comentario.Comentario_Desactivar(comentario);
		}

		public string Comentario_Seleccionar_IdArticulo(int IdArticulo)
		{
			string Comentarios = "";
			foreach (Models.Comentario dt in _comentario.Comentario_Seleccionar_IdArticulo(IdArticulo))
			{
				Comentarios = Comentarios + "<ol><!-- Single Comment Area --><li class='single_comment_area'><!-- Comment Content --><div class='comment-content'><!-- Comment Meta --><div class='comment-meta d-flex align-items-center justify-content-between'><p><a href='#' class='post-author'>" + dt.Nombre + "</a> on <a href='#' class='post-date'>" + dt.FechaRegistro.ToString() + "</a></p></div><p>" + dt.Comentarios + "</p></div></li></ol>";
			}
			return Comentarios;
		}

		public List<Models.Comentario> Comentario_Seleccionar_IdArticuloTable(int IdArticulo)
		{
			return _comentario.Comentario_Seleccionar_IdArticulo(IdArticulo);
		}

	}
}
