using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuevaWebAsae.Controllers
{
    public class AdmController : Controller
    {
        Models.Usuario SesionUsuario = (Models.Usuario)System.Web.HttpContext.Current.Session["Sesion"];

        // GET: Adm
        public ActionResult Index(Application.Usuarios usuarios)
        {
            Models.Usuario usuario = new Models.Usuario();

            if (Session["Sesion"] != null)
            {
                usuario = (Models.Usuario)Session["Sesion"];
                Models.Usuario dtUsuario = usuarios.Usuario_Login_ClaveSesion(usuario);

                if (dtUsuario.Id > 0)
                {
                    // SOLO INCIAR SESION
                    Session["Sesion"] = dtUsuario;
                    return RedirectToAction("dashboard", "Adm");

                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult IniciarSesion(Models.Usuario usuario, Application.Usuarios ApUsuario)
        {
            Models.Usuario dtUsuario = ApUsuario.Usuario_Login_IniciarSesion(usuario);

            if (dtUsuario.Id > 0)
            {
                if (dtUsuario.ClaveSesion == null)
                {
                    // SOLO INCIAR SESION
                    Session["Sesion"] = dtUsuario;
                }
                else
                {
                    // SESION Y COOKIE
                    Session["Sesion"] = dtUsuario;
                    Response.Cookies["SesionDT"].Value = dtUsuario.ClaveSesion;
                }
            }


            return Json(dtUsuario);
        }

        [HttpPost]
        public JsonResult CerrarSesion()
        {
            Models.Usuario DataUser = (Models.Usuario)System.Web.HttpContext.Current.Session["Sesion"];
            Response.Cookies["SesionDT"].Value = null;

            Session.Abandon();

            if (DataUser != null)
            {
                return Json(DataUser);
            }
            else
            {
                return Json("Ha ocurrido un problema!");
            }
        }

        public ActionResult dashboard(Application.Articulo articulo, Application.Cat_categorias cat_Categorias)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            if (Sesion(url))
            {
                List<Models.Articulo> dtLisArticulos = articulo.Articulo_Seleccionar();
                List<Models.Cat_categorias> dtCategoria = cat_Categorias.Cat_categorias_Vistas();
                List<Models.Articulo> dtActividad = articulo.Articulos_Vistos_Mes();

                int total = 0;
                string categoriaVista = "";
                if (dtCategoria.Count > 0)
                {
                    foreach (var dt in dtCategoria)
                    {
                        total += dt.Total;
                    }

                    categoriaVista = dtCategoria[0].Nombre + " - " + dtCategoria[0].Total;
                }
                ViewBag.Total = dtLisArticulos.Count;
                ViewBag.TotalVisualizaciones = total;
                ViewBag.Categoria = categoriaVista;
                ViewBag.Actividad = dtActividad;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Adm");
            }
            
        }

        public ActionResult dashboardblog(Application.Articulo articulo, Application.Cat_categorias cat_Categorias)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            if (Sesion(url))
            {
                List<Models.Articulo> dtLisArticulos = articulo.Articulo_Seleccionar();
                List<Models.Articulo> dtCTotal = articulo.Articulo_Categoria_Total();
                List<Models.Articulo> dtActividad = articulo.Articulos_Vistos_Mes();
                List<Models.Cat_categorias> dtCategoria = cat_Categorias.Cat_categorias_Vistas();

                ViewBag.Articulos = dtLisArticulos;
                ViewBag.CategoriasTotal = dtCTotal;
                ViewBag.Actividad = dtActividad;
                ViewBag.Categorias = dtCategoria;
                ViewBag.Total = dtLisArticulos.Count;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Adm");
            }
        }

        public ActionResult ConsultaArticulo(Application.Articulo articulo )
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            if (Sesion(url))
            {
                string dtArticulos = "";
                if (!String.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    int Id = 0;
                    Id = Convert.ToInt32(Request.QueryString["Id"]);
                    dtArticulos = articulo.Articulo_Contenido_IdCategoria(Id);
                }
                else
                {
                    dtArticulos = articulo.Articulo_Contenido();
                }
                
                ViewBag.Articulos = dtArticulos;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Adm");
            }
        }

        public ActionResult BlogEdit(Application.Cat_categorias cat_Categorias, Application.Articulo AParticulo)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            if (Sesion(url))
            {
                if (!String.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    int Id = 0;
                    try
                    {
                        Id = Convert.ToInt32(Request.QueryString["Id"]);
                        Models.Articulo articulo1 = new Models.Articulo();
                        articulo1.Id = Id;

                        Models.Articulo articulo = AParticulo.Articulo_Selecionar_Id(articulo1);

                        List<Models.Cat_categorias> dtCategoria = cat_Categorias.Seleccionar();
                        ViewBag.Categorias = dtCategoria;
                        ViewBag.Artiuclo = articulo;
                        ViewBag.Id = Id;
                        return View();
                    }
                    catch
                    {
                        return RedirectToAction("dashboardblog", "Adm");
                    }
                }
                else
                {
                    return RedirectToAction("dashboardblog", "Adm");
                }
            }
            else
            {
                return RedirectToAction("Index", "Adm");
            }
        }

        [HttpPost]
        public JsonResult BlogActualizar(Models.Articulo articulo, Application.Articulo ApArticulo)
        {
            Models.Articulo articulo1 = ApArticulo.Articulo_Actualizar(articulo);
            return Json(articulo1);
        }

        public ActionResult Categorias(Application.Cat_categorias cat_Categorias)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            if (Sesion(url))
            {
                List<Models.Cat_categorias> categorias = cat_Categorias.Categorias_Seleccionar();
                ViewBag.Categorias = categorias;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Adm");
            }
        }

        [HttpPost]
        public JsonResult DesactivarCategoria(Models.Cat_categorias cat_Categorias, Application.Cat_categorias ApCat_categorias)
        {
            Models.Cat_categorias articulo1 = ApCat_categorias.Categoria_Desactivar(cat_Categorias);
            return Json(articulo1);
        }

        [HttpPost]
        public JsonResult ActivarCategoria(Models.Cat_categorias cat_Categorias, Application.Cat_categorias ApCat_categorias)
        {
            Models.Cat_categorias articulo1 = ApCat_categorias.CategoriaActivar(cat_Categorias);
            return Json(articulo1);
        }


        public ActionResult BlogShow(Application.Cat_categorias cat_Categorias, Application.Articulo AParticulo, Application.Comentario APcomentario)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            if (Sesion(url))
            {
                if (!String.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    int Id = 0;
                    try
                    {
                        Id = Convert.ToInt32(Request.QueryString["Id"]);
                        Models.Articulo articulo1 = new Models.Articulo();
                        Models.Articulo articulo2 = new Models.Articulo();
                        articulo1.Id = Id;

                        Models.Articulo articulo = AParticulo.Articulo_Selecionar_Id(articulo1);
                        List<Models.Comentario> comentarios = APcomentario.Comentario_Seleccionar_IdArticuloTable(Id);
                        articulo2 = AParticulo.Articulo_Vista_IdArticulo(Id);

                        string imagen = articulo.Imagen.Replace("\\", "/");
                        string authorImg = articulo.Imagen.Substring(0, imagen.Length - 4);


                        ViewBag.Id = articulo.Id;
                        ViewBag.Categoria = articulo.Categoria;
                        ViewBag.Titulo = articulo.Titulo;
                        ViewBag.Resumen = articulo.Resumen;
                        ViewBag.Contenido = articulo.Contenido;
                        ViewBag.FechaRegistro = articulo.FechaRegistro;
                        ViewBag.Autor = articulo.Autor;
                        ViewBag.Imagen = "<img src='https://" + authorImg + ".jpg' alt='img-blur-shadow' class='img-fluid shadow border-radius-xl'>";
                        ViewBag.TotalVistas = articulo2.Total;
                        ViewBag.TotalComentarios = comentarios.Count;
                        ViewBag.Comentarios = comentarios;



                        return View();
                    }
                    catch
                    {
                        return RedirectToAction("dashboardblog", "Adm");
                    }
                }
                else
                {
                    return RedirectToAction("dashboardblog", "Adm");
                }
            }
            else
            {
                return RedirectToAction("Index", "Adm");
            }
        }

        [HttpPost]
        public JsonResult DesactivarArticulo(Models.Articulo articulo, Application.Articulo ApArticulo)
        {
            Models.Articulo articulo1 = ApArticulo.Articulo_Desactivar(articulo);
            return Json(articulo1);
        }

        [HttpPost]
        public JsonResult DesactivarComentario(Models.Comentario comentario, Application.Comentario ApComentario)
        {
            Models.Comentario comentario1 = ApComentario.Comentario_Desactivar(comentario);
            return Json(comentario1);
        }

        public ActionResult blog(Application.Cat_categorias cat_Categorias)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            if (Sesion(url))
            {
                List<Models.Cat_categorias> dtCategoria = cat_Categorias.Seleccionar();
                ViewBag.Categorias = dtCategoria;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Adm");
            }
        }

        [HttpPost]
        public JsonResult CargaImagen()
        {
            string DirectorioUsuario = Server.MapPath("~") + "\\BlogImagenes\\" + SesionUsuario.Id + "\\";
            string DirectorioURL = System.Web.HttpContext.Current.Request.Url.Authority + "\\BlogImagenes\\" + SesionUsuario.Id + "\\";

            Models.Imagen Imagen = new Models.Imagen();

            if (Session["Imagenes"] != null)
            {
                Imagen = (Models.Imagen)Session["Imagenes"];
            }

            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i];
                Models.Imagen _artiucloImg = new Models.Imagen();
                _artiucloImg = NuevoArchivo(file, DirectorioUsuario, DirectorioURL);

                if (_artiucloImg.NmImagen != null)
                {
                    Imagen = _artiucloImg;
                }
            }

            Session["Imagenes"] = Imagen;

            return Json(Imagen);
        }

        public Models.Imagen NuevoArchivo(HttpPostedFileBase Archivo, string DirectorioUsuario, string DirectorioURL)
        {
            Models.Imagen _inmueblesImg = new Models.Imagen();
            String FileExtension = Path.GetExtension(Archivo.FileName).ToLower();
            Application.Control_Archivos dtcontrol_Archivos = new Application.Control_Archivos();
            if (!Directory.Exists(DirectorioUsuario))
            {
                Directory.CreateDirectory(DirectorioUsuario);
            }

            if (".jpg".Contains(FileExtension) ^ ".png".Contains(FileExtension) ^ ".jpeg".Contains(FileExtension))
            {

                Models.Control_Archivos archivo = dtcontrol_Archivos.NuevoArchivo();
                string NombreArchivo = archivo.Id.ToString().PadLeft(12, '0');

                // IMAGEN SLIDER - POST
                Image image = ResizeImage(Image.FromStream(Archivo.InputStream, true, true), 1920, 1080);
                image.Save(DirectorioUsuario + NombreArchivo + ".jpg");

                Image image2 = ResizeImage(Image.FromStream(Archivo.InputStream, true, true), 70, 70);
                image2.Save(DirectorioUsuario + NombreArchivo + "_2" + ".jpg");

                Image image3 = ResizeImage(Image.FromStream(Archivo.InputStream, true, true), 318, 160);
                image3.Save(DirectorioUsuario + NombreArchivo + "_3" + ".jpg");

                Image image4 = ResizeImage(Image.FromStream(Archivo.InputStream, true, true), 350, 190);
                image4.Save(DirectorioUsuario + NombreArchivo + "_4" + ".jpg");

                Image image5 = ResizeImage(Image.FromStream(Archivo.InputStream, true, true), 200, 200);
                image5.Save(DirectorioUsuario + NombreArchivo + "_5" + ".jpg");

                Image image6 = ResizeImage(Image.FromStream(Archivo.InputStream, true, true), 97, 97);
                image6.Save(DirectorioUsuario + NombreArchivo + "_6" + ".jpg");


                //// TERCERA IMAGEN - CATEGORIAS
                //Rectangle cropRect = new Rectangle( 0, 0, 1920, 720);
                //Image image3 = cropImage(image, cropRect);
                //image3.Save(DirectorioUsuario + NombreArchivo + "_3" + ".jpg");

                //Image image4 = ResizeImage(Image.FromStream(Archivo.InputStream, true, true), 690, 407);
                //image4.Save(DirectorioUsuario + NombreArchivo + "_4" + ".jpg");

                //// TERCERA IMAGEN - CATEGORIAS
                //Rectangle cropRect2 = new Rectangle(0, 0, 690, 193);
                //Image image5 = cropImage(image4, cropRect2);
                //image5.Save(DirectorioUsuario + NombreArchivo + "_5" + ".jpg");


                _inmueblesImg.IdArchivo = archivo.Id;
                _inmueblesImg.NmImagen = NombreArchivo + FileExtension;
                _inmueblesImg.NmOriginal = Archivo.FileName;
                _inmueblesImg.Activo = 1;
                _inmueblesImg.Descripcion = DirectorioURL + NombreArchivo + ".jpg";

            }

            return _inmueblesImg;
        }

        public static Image ResizeImage(Image srcImage, int newWidth, int newHeight)
        {
            using (Bitmap imagenBitmap = new Bitmap(newWidth, newHeight, PixelFormat.Format32bppRgb))
            {
                imagenBitmap.SetResolution(
                   Convert.ToInt32(srcImage.HorizontalResolution),
                   Convert.ToInt32(srcImage.HorizontalResolution));

                using (Graphics imagenGraphics = Graphics.FromImage(imagenBitmap))
                {
                    imagenGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                    imagenGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    imagenGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    imagenGraphics.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight), new Rectangle(0, 0, srcImage.Width, srcImage.Height), GraphicsUnit.Pixel);
                    MemoryStream imagenMemoryStream = new MemoryStream();
                    imagenBitmap.Save(imagenMemoryStream, ImageFormat.Jpeg);
                    srcImage = Image.FromStream(imagenMemoryStream);
                }
            }
            return srcImage;
        }

        private static Image cropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            Bitmap bmpCrop = bmpImage.Clone(cropArea,
            bmpImage.PixelFormat);
            return (Image)(bmpCrop);
        }


        public JsonResult EliminarImagen(Models.Imagen imagen)
        {
            string DirectorioUsuario = Server.MapPath("~") + "\\BlogImagenes\\" + SesionUsuario.Id + "\\";
            Models.Imagen imagen1 = new Models.Imagen();
            if (Session["Imagenes"] != null)
            {
                imagen1 = (Models.Imagen)Session["Imagenes"];
            }

            if (imagen1.IdArchivo == imagen.IdArchivo)
            {
                System.IO.File.Delete(DirectorioUsuario + imagen1.NmImagen);
                imagen1.Activo = 0;
            }

            Session["Imagenes"] = null;

            

            return Json(imagen1);
        }

        public JsonResult NuevoArticulo(Models.Articulo articulo, Application.Articulo AParticulo, Application.Imagen APimagen)
        {
            articulo.IdUsuario = SesionUsuario.Id;
            Models.Imagen Imagen = new Models.Imagen();
            

            if (Session["Imagenes"] != null)
            {
                Imagen = (Models.Imagen)Session["Imagenes"];
            }

            if(Imagen.IdArchivo > 0)
            {
                articulo.IdUsuario = SesionUsuario.Id;

                if (articulo.Usuario == 1)
                {
                    articulo.Autor = SesionUsuario.Nombre;   
                }

                // REGISTRAR ARTICULO
                articulo.Resultado = AParticulo.NuevoArticulo(articulo).Resultado;
                if (articulo.Resultado > 0)
                {
                    articulo.Id = articulo.Resultado;
                    // REGISTRAR IMAGEN
                    Imagen.IdArticulo = articulo.Id;
                    APimagen.Imagen_Registrar(Imagen);
                    Session["Imagenes"] = null;
                }

            }
            else
            {
                articulo.Resultado = 0;
                articulo.ResultadoText = "Carga una imagen de portada. ";
            }

            
            return Json(articulo);
        }

        public ActionResult work(Application.Vacante vacante)
        {
            //List<Models.Vacante> dtLisVacantes = vacante.Vacante_Seleccionar();
            //ViewBag.Vacantes = dtLisVacantes;

            return View();
        }

        public ActionResult NewWork(Application.CatgoriaVacante catgoriaVacante, Application.CatEstados catEstados, Application.CatVacante catVacante, Application.CatPago catPago)
        {
            List<Models.CatgoriaVacante> dtCategoria = catgoriaVacante.Seleccionar();
            ViewBag.Categorias = dtCategoria;
            ViewBag.CatEstados = catEstados.Seleccionar();
            ViewBag.Vacante = catVacante.Cat_vacante_Seleccionar();
            ViewBag.Pago = catPago.Cat_pago_Seleccionar();
            return View();
        }

        [HttpPost]
        public JsonResult Consulta_DelegacionMunicipio(Models.Catalogos Catalogos, Application.CatPoblacion catPoblacion)
        {
            List<Models.Catalogos> Poblaciones = catPoblacion.Seleccionar(Catalogos.Id);
            return Json(Poblaciones);
        }


        [HttpPost]
        public JsonResult Consulta_Estados(Application.CatEstados catEstados)
        {
            List<Models.Catalogos> estados = catEstados.Seleccionar();
            return Json(estados);
        }

        [HttpPost]
        public JsonResult Consulta_Colonias(Models.Catalogos Catalogos, Application.CatColonias catColonias)
        {
            List<Models.Catalogos> Poblaciones = catColonias.Seleccionar(Catalogos.Id);
            return Json(Poblaciones);
        }

        [HttpPost]
        public JsonResult CP_Busqueda(Models.Catalogos Catalogos, Application.CatCP catCP)
        {
            List<Models.Direccion> Poblaciones = catCP.Cat_CP_Busqueda(Catalogos.Nombre);
            return Json(Poblaciones);
        }

        [HttpPost]
        public JsonResult Consulta_CP(Models.Catalogos Catalogos, Application.CatCP catCP)
        {
            List<Models.Catalogos> Poblaciones = catCP.Seleccionar(Catalogos.Id);
            return Json(Poblaciones);
        }

        [HttpPost]
        public JsonResult NuevaCategoria(Models.Cat_categorias cat_Categorias, Application.Cat_categorias APCatCategorias)
        {
            Models.Cat_categorias Nueva = APCatCategorias.NuevaCategoria(cat_Categorias);
            return Json(Nueva);
        }


        //public JsonResult NuevaVacante(Models.Vacante vacante, Application.Vacante APvacante)
        //{
        //    vacante.IdUsuario = SesionUsuario.Id;
        //    // REGISTRAR VACANTE
        //    vacante.Resultado = APvacante.NuevaVacante(vacante).Resultado;
        //    if (vacante.Resultado > 0)
        //    {
        //        vacante.Id = vacante.Resultado;
        //    }
        //    return Json(vacante);
        //}

        //public ActionResult VacanteEdit(Application.CatgoriaVacante catgoriaVacante, Application.Vacante APvacante)
        //{
        //    if (!String.IsNullOrEmpty(Request.QueryString["Id"]))
        //    {
        //        int Id = 0;
        //        try
        //        {
        //            Id = Convert.ToInt32(Request.QueryString["Id"]);
        //            Models.Vacante vacante = new Models.Vacante();
        //            vacante.Id = Id;

        //            Models.Vacante vacante1 = APvacante.Vacante_Selecionar_Id(vacante);

        //            List<Models.CatgoriaVacante> dtCategoria = catgoriaVacante.Seleccionar();
        //            ViewBag.Categorias = dtCategoria;
        //            ViewBag.Vacante = vacante1;

        //            return View();
        //        }
        //        catch
        //        {
        //            return RedirectToAction("work", "Adm");
        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("work", "Adm");
        //    }

        //}

        //public ActionResult ConsultarWork(Application.Vacante vacante)
        //{
        //    List<Models.Vacante> dtLisVacantes = vacante.Vacante_Seleccionar();

        //    ViewBag.Vacantes = dtLisVacantes;
        //    return View();
        //}

        public bool Sesion(string url)
        {
            bool result = false;
            Models.Usuario usuario = new Models.Usuario();
            Application.Menu menu = new Application.Menu();
            //Models.Usuario Usuairo = (Models.Usuario)System.Web.HttpContext.Current.Session["Sesion"];

            if (menu.ValidacionPagina(SesionUsuario, url))
            {
                 result = true;
            }
            return result;
        }
    }
}
