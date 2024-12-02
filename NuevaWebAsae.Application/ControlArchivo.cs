using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace NuevaWebAsae.Application
{
    public class ControlArchivo
    {
        Data.ControlArchivo _ControlArchivo = new Data.ControlArchivo();
        public Models.ProspectoArchivo NuevoArchivo(HttpPostedFile Archivo, string DirectorioUsuario)
        {
            Models.ProspectoArchivo _Archivo = new Models.ProspectoArchivo();
            String FileExtension = Path.GetExtension(Archivo.FileName).ToLower();

            if (!Directory.Exists(DirectorioUsuario))
            {
                Directory.CreateDirectory(DirectorioUsuario);
            }

            Models.ControlArchivo NuevoArchivo = _ControlArchivo.NuevoArchivo();
            string NombreArchivo = NuevoArchivo.Clave + NuevoArchivo.Id.ToString().PadLeft(12, '0');
            Archivo.SaveAs(DirectorioUsuario + NombreArchivo + FileExtension);
            _Archivo.Id = NuevoArchivo.Id;
            _Archivo.NmArchivo = NombreArchivo + FileExtension;
            _Archivo.NmOriginal = Archivo.FileName;
            _Archivo.Extencion = FileExtension;
            return _Archivo;
        }
    }
}
