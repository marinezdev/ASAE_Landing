using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public class Articulo
    {
        Data.Articulo _Articulo = new Data.Articulo();
        public Models.Articulo NuevoArticulo(Models.Articulo articulo)
        {
            return _Articulo.NuevoArticulo(articulo);
        }

        public Models.Articulo Articulo_Actualizar(Models.Articulo articulo)
        {
            return _Articulo.Articulo_Actualizar(articulo);
        }

        public Models.Articulo Articulo_Selecionar_Id(Models.Articulo articulo)
        {
            return _Articulo.Articulo_Selecionar_Id(articulo);
        }

        public Models.Articulo Articulo_Desactivar(Models.Articulo articulo)
        {
            return _Articulo.Articulo_Desactivar(articulo);
        }

        public string Articulo_Contenido()
        {
            List<Models.Articulo> Articulos = _Articulo.Articulo_Seleccionar();
            string contenido = "";

            int fila = 1;
            foreach (var dt in Articulos)
            {
                if (fila == 1)
                {
                    contenido += "<div class='row'>";
                }

                if (fila <= 4)
                {
                    string imagen = dt.Imagen.Replace("\\", "/");
                    string authorImg = dt.Imagen.Substring(0, imagen.Length - 4);

                    contenido +=
                    "<div class='col-xl-4 col-md-6 mb-xl-0 mb-4'>" +
                        "<div class='card card-blog card-plain'>" +
                            "<div class='position-relative'>" +
                                "<a class='d-block shadow-xl border-radius-xl'>" +
                                    "<img src='https://" + authorImg + "_4.jpg' alt='img-blur-shadow' class='img-fluid shadow border-radius-xl'>" +
                                "</a>" +
                            "</div>" +
                            "<div class='card-body px-1 pb-0'>" +
                                "<p class='text-gradient text-dark mb-2 text-sm'>" + dt.FechaRegistro + "</p>" +
                                "<a href='javascript:;'>" +
                                    "<h5>" +
                                    dt.Titulo +
                                    "</h5>" +
                                "</a>" +
                                "<p class='mb-4 text-sm'>" +
                                    dt.Resumen +
                                "</p>" +
                                "<div class='d-flex align-items-center justify-content-between'>" +
                                    "<button type='button' class='btn btn-outline-info btn-sm mb-0' onclick='MostrarArticulo(" + dt.Id + ")'>Ver artículo</button>" +
                                     "<button type='button' class='btn btn-outline-primary btn-sm mb-0' onclick='Editar(" + dt.Id + ")'>Editar </button>" +
                                "</div>" +
                            "</div>" +
                            "<br><br>" +
                        "</div>" +
                    "</div>";
                    fila += 1;
                }

                if (fila == 4)
                {
                    contenido += "</div>";
                    fila = 1;
                }
            }


            return contenido;
        }

        public string Articulo_Contenido_IdCategoria(int Id)
        {
            List<Models.Articulo> Articulos = _Articulo.Articulo_Seleccionar_IdCategoria(Id);
            string contenido = "";

            int fila = 1;
            foreach (var dt in Articulos)
            {
                if (fila == 1)
                {
                    contenido += "<div class='row'>";
                }

                if (fila <= 4)
                {
                    string imagen = dt.Imagen.Replace("\\", "/");
                    string authorImg = dt.Imagen.Substring(0, imagen.Length - 4);

                    contenido +=
                    "<div class='col-xl-4 col-md-6 mb-xl-0 mb-4'>" +
                        "<div class='card card-blog card-plain'>" +
                            "<div class='position-relative'>" +
                                "<a class='d-block shadow-xl border-radius-xl'>" +
                                    "<img src='https://" + authorImg + "_4.jpg' alt='img-blur-shadow' class='img-fluid shadow border-radius-xl'>" +
                                "</a>" +
                            "</div>" +
                            "<div class='card-body px-1 pb-0'>" +
                                "<p class='text-gradient text-dark mb-2 text-sm'>" + dt.FechaRegistro + "</p>" +
                                "<a href='javascript:;'>" +
                                    "<h5>" +
                                    dt.Titulo +
                                    "</h5>" +
                                "</a>" +
                                "<p class='mb-4 text-sm'>" +
                                    dt.Resumen +
                                "</p>" +
                                "<div class='d-flex align-items-center justify-content-between'>" +
                                    "<button type='button' class='btn btn-outline-info btn-sm mb-0' onclick='MostrarArticulo(" + dt.Id + ")'>Ver artículo</button>" +
                                     "<button type='button' class='btn btn-outline-primary btn-sm mb-0' onclick='Editar(" + dt.Id + ")'>Editar </button>" +
                                "</div>" +
                            "</div>" +
                            "<br><br>" +
                        "</div>" +
                    "</div>";
                    fila += 1;
                }

                if (fila == 4)
                {
                    contenido += "</div>";
                    fila = 1;
                }
            }


            return contenido;
        }

        public List<Models.Articulo> Articulo_Seleccionar()
        {
            return _Articulo.Articulo_Seleccionar();
        }

        public List<Models.Articulo> Articulo_Categoria_Total()
        {
            return _Articulo.Articulo_Categoria_Total();
        }

        public List<Models.Articulo> Articulos_Vistos_Mes()
        {
            return _Articulo.Articulos_Vistos_Mes();
        }


        public List<Models.Articulo> Articulo_Blog_Home()
        {
            return _Articulo.Articulo_Blog_Home();
        }
        public List<Models.Articulo> Articulo_Top()
        {
            return _Articulo.Articulo_Top();
        }

        public List<Models.Articulo> Articulo_Home_List()
        {
            return _Articulo.Articulo_Home_List();
        }

        public List<Models.Articulo> Articulo_Listar_Top5()
        {
            return _Articulo.Articulo_Listar_Top5();
        }
        public List<Models.Articulo> Articulo_Listar_Top2()
        {
            return _Articulo.Articulo_Listar_Top2();
        }

        public string  Articulo_Home_ListRamdom()
        {
            List<Models.Articulo> Articulos = _Articulo.Articulo_Home_ListRamdom();
            string ArtiucloSlider = "";
            string ListArticulo = "";
            string Contenido = "";

            int cont = 0;

            foreach(var dt in Articulos)
            {
                string imagen = dt.Imagen.Replace("\\", "/");
                string authorImg = dt.Imagen.Substring(0, imagen.Length - 4);

                if(cont < 3)
                {
                    ArtiucloSlider += "<div class='single-blog-post'>" +
                                        "<div class='post-thumbnail'>" +
                                            "<img src='https://" + authorImg + "_4.jpg' alt=''>" +
                                            "<div class='post-cta'><a href='#' onclick='Categoria(" + dt.IdCategoria + ")'> " + dt.Categoria + " </a></div> " +
                                        "</div >" +
                                        "<div class='post-content'>" +
                                            "<a href = '#' onclick='Post(" + dt.Id + ")' class='headline'>" +
                                                "<h5>" + dt.Titulo + "</h5>" +
                                            "</a>" +
                                            "<p>" + dt.Resumen + " ...</p>" +
                                            "<div class='post-meta'>" +
                                                "<p><a href = '#' class='post-author'>" + dt.Autor + "</a> el <a href='#' class='post-date'>" + dt.FechaRegistro + "</a></p>" +
                                            "</div>" +
                                        "</div>" +
                                    "</div>";
                }
                else
                {
                    ListArticulo +=
                        "<div class='single-blog-post post-style-2 d-flex align-items-center wow fadeInUpBig' data-wow-delay='0.2s'>" +
                            "<div class='post-thumbnail'>" +
                                "<img src='https://" + authorImg + "_6.jpg' alt=''>" +
                            "</div>" +
                            "<div class='post-content'>" +
                                "<a href='#' onclick='Post(" + dt.Id + ")' class='headline'>" +
                                    "<h5>" + dt.Titulo + "</h5>" +
                                "</a>" +
                                "<div class='post-meta'>" +
                                    "<p><a href = '#' class='post-author'>" + dt.Autor + "</a> el <a href='#' class='post-date'>" + dt.FechaRegistro + "</a></p>" +
                                "</div>" +
                            "</div>" +
                        "</div>";
                }


    cont += 1;
            }

            Contenido =
                    "<div class='row'>" +
                        "<div class='col-12 col-md-6'>" +
                            "<div class='world-catagory-slider owl-carousel wow fadeInUpBig' data-wow-delay='0.1s'>" +
                                ArtiucloSlider +
                            "</div>" +
                        "</div>" +
                        "<div class='col-12 col-md-6'>" +
                               ListArticulo +
                        "</div>" +
                    "</div>";


            return Contenido;
        }

        public string Articulo_Listar_IdCategoria(int Id)
        {
            List<Models.Articulo> Articulos = _Articulo.Articulo_Listar_IdCategoria(Id);
            string Contenido = "";
            string Articulo = "";
            string ListArticulo = "";


            int count = 0;
            if (Articulos.Count > 0)
            {
                foreach (var dt in Articulos)
                {
                    string imagen = dt.Imagen.Replace("\\", "/");
                    string authorImg = dt.Imagen.Substring(0, imagen.Length - 4);

                    if (count > 0)
                    {
                        ListArticulo +=
                        "<div class='single-blog-post post-style-2 d-flex align-items-center'>" +
                            "<div class='post-thumbnail'>" +
                                "<img src='https://" + authorImg + "_6.jpg' alt=''>" +
                            "</div>" +
                            "<div class='post-content'>" +
                                "<a href='#' onclick='Post(" + dt.Id + ")' class='headline'>" +
                                    "<h5>" + dt.Titulo + "</h5>" +
                                "</a>" +
                                "<div class='post-meta'>" +
                                    "<p><a href='#' class='post-author'>" + dt.Autor + "</a> on <a href='#' class='post-date'>" + dt.FechaRegistro + "</a></p>" +
                                "</div>" +
                            "</div>" +
                        "</div>";
                    }
                    else
                    {
                        Articulo =
                        "<div class='single-blog-post'>" +
                           "<div class='post-thumbnail'>" +
                               "<img src='https://" + authorImg + "_4.jpg' alt=''>" +
                               "<div class='post-cta'><a href='#' onclick='Categoria(" + dt.IdCategoria + ")'>" + dt.Categoria + "</a></div> " +
                           "</div>" +
                           "<div class='post-content'>" +
                               "<a href='#' onclick='Post(" + dt.Id + ")' class='headline'>" +
                                   "<h5>" + dt.Titulo + "</h5>" +
                               "</a>" +
                               "<p>" + dt.Resumen + " ...</p>" +
                               "<div class='post-meta'>" +
                                   "<p><a href='#' class='post-author'>" + dt.Autor + "</a> on <a href='#' class='post-date'>" + dt.FechaRegistro + "</a></p>" +
                               "</div>" +
                           "</div>" +
                       "</div>";
                    }
                    count += 1;
                }
            }
            else
            {
                Articulo = "<p>Por el momento no hay artículos disponibles </p>";
                ListArticulo = "<p>Sin artículos </p>";
            }
            


            Contenido =
            "<div class='row'>" +
                "<div class='col-12 col-md-6'>" +
                   Articulo +
                "</div>" +

                "<div class='col-12 col-md-6'>" +
                    ListArticulo +
                "</div>" +
            "</div>";

            return Contenido;
        }


        public string Articulo_Home_ListTendencia()
        {
            List<Models.Articulo> Articulos = _Articulo.Articulo_Home_ListTendencia();
            string Contenido = "";
            string Articulo = "";
            string ListArticulos = "";


            int count = 1;
            int lista = 0;
            foreach(var dt in Articulos)
            {
                string imagen = dt.Imagen.Replace("\\", "/");
                string authorImg = dt.Imagen.Substring(0, imagen.Length - 4);

                if (count < 3)
                {
                    Articulo +=
                    "<div class='col-12 col-md-6'>" +
                        "<!-- Single Blog Post -->" +
                        "<div class='single-blog-post wow fadeInUpBig' data-wow-delay='0.2s'>" +
                            "<div class='post-thumbnail'>" +
                                "<img src='https://" + authorImg + "_4.jpg' alt=''>" +
                                "<div class='post-cta'><a href='#' onclick='Categoria(" + dt.IdCategoria + ")'>" + dt.Categoria + "</a></div> " +
                            "</div> " +
                            "<div class='post-content'>" +
                                "<a href='#' onclick='Post(" + dt.Id + ")' class='headline'>" +
                                    "<h5>" + dt.Titulo + "</h5>" +
                                "</a>" +
                                "<p>" + dt.Resumen + "...</p>" +
                                "<div class='post-meta'>" +
                                    "<p><a href='#' class='post-author'>" + dt.Autor + "</a> on <a href='#' class='post-date'>" + dt.FechaRegistro + "</a></p>" +
                                "</div>" +
                            "</div>" +
                        "</div>" +
                    "</div>";

                }
                else
                {
                    if(lista == 0)
                    {
                        ListArticulos +=
                        "<div class='single-cata-slide'>" +
                            "<div class='row'>"; 
                    }

                    if (lista < 3)
                    {
                        ListArticulos +=
                        "<div class='col-12 col-md-6'>" +
                            "<!-- Single Blog Post -->" +
                            "<div class='single-blog-post post-style-2 d-flex align-items-center mb-1'>" +
                                "<!-- Post Thumbnail -->" +
                                "<div class='post-thumbnail'>" +
                                    "<img src='https://" + authorImg + "_6.jpg' alt=''>" +
                                "</div>" +
                                "<!-- Post Content -->" +
                                "<div class='post-content'>" +
                                    "<a href='#' onclick='Post(" + dt.Id + ")' class='headline'>" +
                                        "<h5>" + dt.Titulo + "</h5>" +
                                    "</a>" +
                                    "<!-- Post Meta -->" +
                                    "<div class='post-meta'>" +
                                        "<p><a href='#' class='post-author'>" + dt.Autor + "</a> on <a href='#' class='post-date'>" + dt.FechaRegistro + "</a></p>" +
                                    "</div>" +
                                "</div>" +
                            "</div>" +
                        "</div>";

                        lista += 1;

                        if (count == Articulos.Count )
                        {
                            ListArticulos +=
                                "</div>" +
                            "</div>";
                        }

                        
                    }
                    else
                    {
                        ListArticulos +=
                        "<div class='col-12 col-md-6'>" +
                            "<!-- Single Blog Post -->" +
                            "<div class='single-blog-post post-style-2 d-flex align-items-center mb-1'>" +
                                "<!-- Post Thumbnail -->" +
                                "<div class='post-thumbnail'>" +
                                    "<img src='https://" + authorImg + "_6.jpg' alt=''>" +
                                "</div>" +
                                "<!-- Post Content -->" +
                                "<div class='post-content'>" +
                                    "<a href='#' onclick='Post(" + dt.Id + ")' class='headline'>" +
                                        "<h5>" + dt.Titulo + "</h5>" +
                                    "</a>" +
                                    "<!-- Post Meta -->" +
                                    "<div class='post-meta'>" +
                                        "<p><a href='#' class='post-author'>" + dt.Autor + "</a> on <a href='#' class='post-date'>" + dt.FechaRegistro + "</a></p>" +
                                    "</div>" +
                                "</div>" +
                            "</div>" +
                        "</div>";

                        ListArticulos +=
                                "</div>" +
                            "</div>";

                        lista = 0;
                    }
                }
                count += 1;
            }






            //ListArticulos =
            //"<!-- ========= Single Catagory Slide ========= -->" +
            //"<div class='single-cata-slide'>" +
            //    "<div class='row'>" +
            //        "<div class='col-12 col-md-6'>" +
            //            "<!-- Single Blog Post -->" +
            //            "<div class='single-blog-post post-style-2 d-flex align-items-center mb-1'>" +
            //                "<!-- Post Thumbnail -->" +
            //                "<div class='post-thumbnail'>" +
            //                    "<img src='img/blog-img/b14.jpg' alt=''>" +
            //                "</div>" +
            //                "<!-- Post Content -->" +
            //                "<div class='post-content'>" +
            //                    "<a href='#' class='headline'>" +
            //                        "<h5>How Did van Gogh’s Turbulent Mind Depict One of the Most</h5>" +
            //                    "</a>" +
            //                    "<!-- Post Meta -->" +
            //                    "<div class='post-meta'>" +
            //                        "<p><a href='#' class='post-author'>Katy Liu</a> on <a href='#' class='post-date'>Sep 29, 2017 at 9:48 am</a></p>" +
            //                    "</div>" +
            //                "</div>" +
            //            "</div>" +
            //        "</div>" +
            //        "<div class='col-12 col-md-6'>" +
            //            "<!-- Single Blog Post -->" +
            //            "<div class='single-blog-post post-style-2 d-flex align-items-center mb-1'>" +
            //                "<!-- Post Thumbnail -->" +
            //                "<div class='post-thumbnail'>" +
            //                    "<img src='img/blog-img/b15.jpg' alt=''>" +
            //                "</div>" +
            //                "<!-- Post Content -->" +
            //                "<div class='post-content'>" +
            //                    "<a href='#' class='headline'>" +
            //                        "<h5>How Did van Gogh’s Turbulent Mind Depict One of the Most</h5>" +
            //                    "</a>" +
            //                    "<!-- Post Meta -->" +
            //                    "<div class='post-meta'>" +
            //                        "<p><a href='#' class='post-author'>Katy Liu</a> on <a href='#' class='post-date'>Sep 29, 2017 at 9:48 am</a></p>" +
            //                    "</div>" +
            //                "</div>" +
            //            "</div>" +
            //        "</div>" +
            //        "<div class='col-12 col-md-6'>" +
            //            "<!-- Single Blog Post -->" +
            //            "<div class='single-blog-post post-style-2 d-flex align-items-center mb-1'>" +
            //                "<!-- Post Thumbnail -->" +
            //                "<div class='post-thumbnail'>" +
            //                    "<img src='img/blog-img/b16.jpg' alt=''>" +
            //                "</div>" +
            //                "<!-- Post Content -->" +
            //                "<div class='post-content'>" +
            //                    "<a href='#' class='headline'>" +
            //                        "<h5>How Did van Gogh’s Turbulent Mind Depict One of the Most</h5>" +
            //                    "</a>" +
            //                    "<!-- Post Meta -->" +
            //                    "<div class='post-meta'>" +
            //                        "<p><a href='#' class='post-author'>Katy Liu</a> on <a href='#' class='post-date'>Sep 29, 2017 at 9:48 am</a></p>" +
            //                    "</div>" +
            //                "</div>" +
            //            "</div>" +
            //        "</div>" +
            //        "<div class='col-12 col-md-6'>" +
            //            "<!-- Single Blog Post -->" +
            //            "<div class='single-blog-post post-style-2 d-flex align-items-center mb-1'>" +
            //                "<!-- Post Thumbnail -->" +
            //                "<div class='post-thumbnail'>" +
            //                    "<img src='img/blog-img/b17.jpg' alt=''>" +
            //                "</div>" +
            //                "<!-- Post Content -->" +
            //                "<div class='post-content'>" +
            //                    "<a href='#' class='headline'>" +
            //                        "<h5>How Did van Gogh’s Turbulent Mind Depict One of the Most</h5>" +
            //                    "</a>" +
            //                    "<!-- Post Meta -->" +
            //                    "<div class='post-meta'>" +
            //                        "<p><a href='#' class='post-author'>Katy Liu</a> on <a href='#' class='post-date'>Sep 29, 2017 at 9:48 am</a></p>" +
            //                    "</div>" +
            //                "</div>" +
            //            "</div>" +
            //        "</div>" +
            //    "</div>" +
            //"</div>" +
            //"<!-- ========= Single Catagory Slide ========= -->" +
            //"<div class='single-cata-slide'>" +
            //    "<div class='row'>" +
            //        "<div class='col-12 col-md-6'>" +
            //            "<!-- Single Blog Post -->" +
            //            "<div class='single-blog-post post-style-2 d-flex align-items-center mb-1'>" +
            //                "<!-- Post Thumbnail -->" +
            //                "<div class='post-thumbnail'>" +
            //                    "<img src='img/blog-img/b17.jpg' alt=''>" +
            //                "</div>" +
            //                "<!-- Post Content -->" +
            //                "<div class='post-content'>" +
            //                    "<a href='#' class='headline'>" +
            //                        "<h5>How Did van Gogh’s Turbulent Mind Depict One of the Most</h5>" +
            //                    "</a>" +
            //                    "<!-- Post Meta -->" +
            //                    "<div class='post-meta'>" +
            //                        "<p><a href='#' class='post-author'>Katy Liu</a> on <a href='#' class='post-date'>Sep 29, 2017 at 9:48 am</a></p>" +
            //                    "</div>" +
            //                "</div>" +
            //            "</div>" +
            //       "</div>" +
            //        "<div class='col-12 col-md-6'>" +
            //            "<!-- Single Blog Post -->" +
            //            "<div class='single-blog-post post-style-2 d-flex align-items-center mb-1'>" +
            //                "<!-- Post Thumbnail -->" +
            //                "<div class='post-thumbnail'>" +
            //                    "<img src='img/blog-img/b15.jpg' alt=''>" +
            //                "</div>" +
            //                "<!-- Post Content -->" +
            //                "<div class='post-content'>" +
            //                    "<a href='#' class='headline'>" +
            //                        "<h5>How Did van Gogh’s Turbulent Mind Depict One of the Most</h5>" +
            //                    "</a>" +
            //                    "<!-- Post Meta -->" +
            //                    "<div class='post-meta'>" +
            //                        "<p><a href='#' class='post-author'>Katy Liu</a> on <a href='#' class='post-date'>Sep 29, 2017 at 9:48 am</a></p>" +
            //                    "</div>" +
            //                "</div>" +
            //            "</div>" +
            //        "</div>" +
            //        "<div class='col-12 col-md-6'>" +
            //            "<!-- Single Blog Post -->" +
            //            "<div class='single-blog-post post-style-2 d-flex align-items-center mb-1'>" +
            //                "<!-- Post Thumbnail -->" +
            //                "<div class='post-thumbnail'>" +
            //                    "<img src='img/blog-img/b14.jpg' alt=''>" +
            //                "</div>" +
            //                "<!-- Post Content -->" +
            //                "<div class='post-content'>" +
            //                    "<a href='#' class='headline'>" +
            //                        "<h5>How Did van Gogh’s Turbulent Mind Depict One of the Most</h5>" +
            //                    "</a>" +
            //                    "<!-- Post Meta -->" +
            //                    "<div class='post-meta'>" +
            //                        "<p><a href='#' class='post-author'>Katy Liu</a> on <a href='#' class='post-date'>Sep 29, 2017 at 9:48 am</a></p>" +
            //                    "</div>" +
            //                "</div>" +
            //            "</div>" +
            //        "</div>" +
            //        "<div class='col-12 col-md-6'>" +
            //            "<!-- Single Blog Post -->" +
            //            "<div class='single-blog-post post-style-2 d-flex align-items-center mb-1'>" +
            //                "<!-- Post Thumbnail -->" +
            //                "<div class='post-thumbnail'>" +
            //                    "<img src='img/blog-img/b16.jpg' alt=''>" +
            //                "</div>" +
            //                "<!-- Post Content -->" +
            //                "<div class='post-content'>" +
            //                    "<a href='#' class='headline'>" +
            //                        "<h5>How Did van Gogh’s Turbulent Mind Depict One of the Most</h5>" +
            //                    "</a>" +
            //                    "<!-- Post Meta -->" +
            //                    "<div class='post-meta'>" +
            //                        "<p><a href='#' class='post-author'>Katy Liu</a> on <a href='#' class='post-date'>Sep 29, 2017 at 9:48 am</a></p>" +
            //                    "</div>" +
            //                "</div>" +
            //            "</div>" +
            //        "</div>" +
            //    "</div>" +
            //"</div>";

















            Contenido =
            "<div class='world-catagory-area mt-50'>" +
                "<ul class='nav nav-tabs' id='myTab2' role='tablist'>" +
                    "<li class='title'>Tendencias </li>" +
                    "<li class='nav-item'>" +
                        "<a class='nav-link active' id='tab10' data-toggle='tab' href='#world-tab-10' role='tab' aria-controls='world-tab-10' aria-selected='true'>Todo</a>" +
                    "</li>" +
                "</ul>" +
                "<div class='tab-content' id='myTabContent2'>" +
                    "<div class='tab-pane fade show active' id='world-tab-10' role='tabpanel' aria-labelledby='tab10'>" +
                        "<div class='row'>" +
                            Articulo +
                            "<div class='col-12'>" +
                                "<div class='world-catagory-slider2 owl-carousel wow fadeInUpBig' data-wow-delay='0.4s'>" +
                                    ListArticulos +

            //                                    "<!-- ========= Single Catagory Slide ========= -->" +
            //"<div class='single-cata-slide'>" +
            //    "<div class='row'>" +
            //        "<div class='col-12 col-md-6'>" +
            //            "<!-- Single Blog Post -->" +
            //            "<div class='single-blog-post post-style-2 d-flex align-items-center mb-1'>" +
            //                "<!-- Post Thumbnail -->" +
            //                "<div class='post-thumbnail'>" +
            //                    "<img src='img/blog-img/b17.jpg' alt=''>" +
            //                "</div>" +
            //                "<!-- Post Content -->" +
            //                "<div class='post-content'>" +
            //                    "<a href='#' class='headline'>" +
            //                        "<h5>How Did van Gogh’s Turbulent Mind Depict One of the Most</h5>" +
            //                    "</a>" +
            //                    "<!-- Post Meta -->" +
            //                    "<div class='post-meta'>" +
            //                        "<p><a href='#' class='post-author'>Katy Liu</a> on <a href='#' class='post-date'>Sep 29, 2017 at 9:48 am</a></p>" +
            //                    "</div>" +
            //                "</div>" +
            //            "</div>" +
            //       "</div>" +
            //        "<div class='col-12 col-md-6'>" +
            //            "<!-- Single Blog Post -->" +
            //            "<div class='single-blog-post post-style-2 d-flex align-items-center mb-1'>" +
            //                "<!-- Post Thumbnail -->" +
            //                "<div class='post-thumbnail'>" +
            //                    "<img src='img/blog-img/b15.jpg' alt=''>" +
            //                "</div>" +
            //                "<!-- Post Content -->" +
            //                "<div class='post-content'>" +
            //                    "<a href='#' class='headline'>" +
            //                        "<h5>How Did van Gogh’s Turbulent Mind Depict One of the Most</h5>" +
            //                    "</a>" +
            //                    "<!-- Post Meta -->" +
            //                    "<div class='post-meta'>" +
            //                        "<p><a href='#' class='post-author'>Katy Liu</a> on <a href='#' class='post-date'>Sep 29, 2017 at 9:48 am</a></p>" +
            //                    "</div>" +
            //                "</div>" +
            //            "</div>" +
            //        "</div>" +
            //        "<div class='col-12 col-md-6'>" +
            //            "<!-- Single Blog Post -->" +
            //            "<div class='single-blog-post post-style-2 d-flex align-items-center mb-1'>" +
            //                "<!-- Post Thumbnail -->" +
            //                "<div class='post-thumbnail'>" +
            //                    "<img src='img/blog-img/b14.jpg' alt=''>" +
            //                "</div>" +
            //                "<!-- Post Content -->" +
            //                "<div class='post-content'>" +
            //                    "<a href='#' class='headline'>" +
            //                        "<h5>How Did van Gogh’s Turbulent Mind Depict One of the Most</h5>" +
            //                    "</a>" +
            //                    "<!-- Post Meta -->" +
            //                    "<div class='post-meta'>" +
            //                        "<p><a href='#' class='post-author'>Katy Liu</a> on <a href='#' class='post-date'>Sep 29, 2017 at 9:48 am</a></p>" +
            //                    "</div>" +
            //                "</div>" +
            //            "</div>" +
            //        "</div>" +
            //        "<div class='col-12 col-md-6'>" +
            //            "<!-- Single Blog Post -->" +
            //            "<div class='single-blog-post post-style-2 d-flex align-items-center mb-1'>" +
            //                "<!-- Post Thumbnail -->" +
            //                "<div class='post-thumbnail'>" +
            //                    "<img src='img/blog-img/b16.jpg' alt=''>" +
            //                "</div>" +
            //                "<!-- Post Content -->" +
            //                "<div class='post-content'>" +
            //                    "<a href='#' class='headline'>" +
            //                        "<h5>How Did van Gogh’s Turbulent Mind Depict One of the Most</h5>" +
            //                    "</a>" +
            //                    "<!-- Post Meta -->" +
            //                    "<div class='post-meta'>" +
            //                        "<p><a href='#' class='post-author'>Katy Liu</a> on <a href='#' class='post-date'>Sep 29, 2017 at 9:48 am</a></p>" +
            //                    "</div>" +
            //                "</div>" +
            //            "</div>" +
            //        "</div>" +
            //    "</div>" +
            //"</div>"+


                                "</div>" +
                            "</div>" +
                        "</div>" +
                    "</div>" +
                "</div>" +
            "</div>";



            return Contenido;
        }

        public Models.Articulo Articulo_Seleccionar_Id(int Id)
        {
            return _Articulo.Articulo_Seleccionar_Id(Id);
        }

        public List<Models.Articulo> Articulo_Selecionar_IdCategoria(int Id)
        {
            return _Articulo.Articulo_Selecionar_IdCategoria(Id);
        }

        public Models.Articulo Articulo_Vista_Agregar(Models.Articulo articulo)
        {
            return _Articulo.Articulo_Vista_Agregar(articulo);
        }

        public Models.Articulo Articulo_Vista_IdArticulo(int Id)
        {
            return _Articulo.Articulo_Vista_IdArticulo(Id);
        }
    }
}
