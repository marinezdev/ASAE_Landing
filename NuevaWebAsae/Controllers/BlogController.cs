using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuevaWebAsae.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult Index(Application.Articulo articulo)
        {
            List<Models.Articulo> LisArtiuclo = articulo.Articulo_Blog_Home();



            //string home = "";
            //int Viw = 0;
            //foreach (var dt in LisArtiuclo)
            //{
            //    List<Models.Articulo> articulos = articulo.Articulo_Home_List(dt);
            //    home +=
            //    "<!-- Slider Item -->" +
            //    "<div class='owl-item'>" +
            //    "    <div class='home_slider_background' style='background-image: url(https://" + dt.Imagen.Replace("\\", "/") + "); '></div>" +
            //    "    <div class='home_slider_content_container'>" +
            //    "        <div class='container'>" +
            //    "            <div class='row'>" +
            //    "                <div class='col'>" +
            //    "                    <div class='home_slider_content'>" +
            //    "                        <div class='home_slider_item_category trans_200'><a href='category.html' class='trans_200'>" + dt.Categoria + "</a></div>" +
            //    "                        <div class='home_slider_item_title'>" +
            //    "                            <a href='post.html'>" + dt.Titulo + "</a>" +
            //    "                        </div>" +
            //    "                        <div class='home_slider_item_link'>" +
            //    "                            <a href='#' class='trans_200'>" +
            //    "                                Continuar leyendo " +
            //    "                                <svg version='1.1' id='link_arrow_1' xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' x='0px' y='0px' width='19px' height='13px' viewBox='0 0 19 13' enable-background='new 0 0 19 13' xml:space='preserve'>" +
            //    "                                <polygon fill='#FFFFFF' points='12.475,0 11.061,0 17.081,6.021 0,6.021 0,7.021 17.038,7.021 11.06,13 12.474,13 18.974,6.5 ' />" +
            //    "									</svg>" +
            //    "                            </a>" +
            //    "                        </div>" +
            //    "                    </div>" +
            //    "                </div>" +
            //    "            </div>" +
            //    "        </div>" +
            //    "    </div>" +


            //    "    <!-- Similar Posts -->" +
            //    "    <div class='similar_posts_container'>" +
            //    "        <div class='container'>" +
            //    "            <div class='row d-flex flex-row align-items-end'>";

            //    foreach (var dtArticulo  in articulos)
            //    {
            //        home +=
            //         "               <!-- Similar Post -->" +
            //         "               <div class='col-lg-3 col-md-6 similar_post_col'>" +
            //         "                   <div class='similar_post trans_200'>" +
            //         "                       <a href='post.html'>" + dtArticulo.Titulo + "</a>" +
            //         "                   </div>" +
            //         "               </div>";
            //    }



            //    home +=
            //     "           </div>" +
            //     "       </div>" +
            //     "       <div class='home_slider_next_container'>";
            //    //
            //    Viw = Viw + 1;
            //    if(Viw == 3)
            //    {
            //        string imagen = LisArtiuclo[0].Imagen.Replace("\\", "/");
            //        string authorName = imagen.Substring(0, imagen.Length - 4);

            //        home +=
            //    "           <div class='home_slider_next' style='background-image: url(https://" + authorName + "_2.jpg) '>" +
            //    "               <div class='home_slider_next_background trans_400'></div>" +
            //    "               <div class='home_slider_next_content trans_400'>" +
            //    "                   <div class='home_slider_next_title'>Siguiente</div>" +
            //    "                   <div class='home_slider_next_link'>" + LisArtiuclo[0].Titulo + "</div>" +
            //    "               </div>" +
            //    "           </div>";
            //    }
            //    else
            //    {
            //        string imagen = LisArtiuclo[Viw].Imagen.Replace("\\", "/");
            //        string authorName = imagen.Substring(0, imagen.Length - 4);

            //        home +=
            //    "           <div class='home_slider_next' style='background-image: url(https://" + authorName + "_2.jpg) '>" +
            //    "               <div class='home_slider_next_background trans_400'></div>" +
            //    "               <div class='home_slider_next_content trans_400'>" +
            //    "                   <div class='home_slider_next_title'>Siguiente</div>" +
            //    "                   <div class='home_slider_next_link'>" + LisArtiuclo[Viw].Titulo + "</div>" +
            //    "               </div>" +
            //    "           </div>";
            //    }





            //     //
            //     home +=
            //     "       </div>" +
            //     "   </div>" +
            //    "</div>";
            //}

            //ViewBag.Home = home;

            return View();
        }

        public ActionResult New(Application.Articulo articulo, Application.Cat_categorias cat_Categorias)
        {
            List<Models.Articulo> LisArtiuclo = articulo.Articulo_Blog_Home();
            List<Models.Articulo> ListTopArticulo = articulo.Articulo_Top();
            List<Models.Articulo> articulos = articulo.Articulo_Home_List();

            List<Models.Articulo> ListArtTop5 = articulo.Articulo_Listar_Top5();
            List<Models.Articulo> ListArtTop2 = articulo.Articulo_Listar_Top2();

            List<Models.Cat_categorias> ListCategoria = cat_Categorias.Cat_categorias_Home_List();
            string ListArtTopRamdom = articulo.Articulo_Home_ListRamdom();


            string Hero_Slider = "";
            string Post_Slider = "";
            string Blog_Post = "";
            string New_Articulo = "";
            string Articulo1 = "";
            string Articulo2 = "";
            string Articulo3 = "";

            string SListArtTop5 = "";
            string SListArtTop2 = "";

            int count = 0;
            foreach (var dt in LisArtiuclo)
            {
                count += +1;
                Hero_Slider += "<div class='single-hero-slide bg-img background-overlay' style='background-image: url(https://" + dt.Imagen.Replace("\\", "/") + ");'></div>";
                Post_Slider += "<div class='single-slide d-flex align-items-center'>" +
                                    "<div class='post-number'> " +
                                        "<p>" + count + "</p>" +
                                    "</div>" +
                                    "<div class='post-title'>" +
                                        "<a href='#' onclick='Post("+ dt.Id +")' > " + dt.Titulo + "</a>" +
                                    "</div>" +
                                "</div>";
            }

            foreach (var dt in ListTopArticulo)
            {
                string imagen3 = dt.Imagen.Replace("\\", "/");
                string authorImg3 = dt.Imagen.Substring(0, imagen3.Length - 4);

                Blog_Post +=
                "<div class='single-blog-post post-style-2 d-flex align-items-center widget-post'>" +
                    "<div class='post-thumbnail'>" +
                        "<img src='https://" + authorImg3 + "_2.jpg' alt=''>" +
                    "</div>" +
                    "<div class='post-content'>" +
                        "<a href='#' onclick='Post(" + dt.Id + ")' class='headline'>" +
                            "<h5 class='mb-0'>" + dt.Titulo + "</h5>" +
                        "</a>" +
                    "</div>" +
                "</div>";
            }

            if (LisArtiuclo.Count > 0)
            {
                string imagen2 = LisArtiuclo[0].Imagen.Replace("\\", "/");
                string authorImg2 = LisArtiuclo[0].Imagen.Substring(0, imagen2.Length - 4);

                New_Articulo =
                "<div class='single-blog-post todays-pick'>" +
                    "<div class='post-thumbnail'>" +
                        "<img src='https://" + authorImg2 + "_3.jpg' alt=''>" +
                    "</div>" +
                    "<div class='post-content px-0 pb-0'>" +
                        "<a href='#' onclick='Post(" + LisArtiuclo[0].Id + ")' class='headline'>" +
                            "<h5>" + LisArtiuclo[0].Titulo + "</h5>" +
                        "</a>" +
                    "</div>" +
                "</div>";
            }

            if (articulos.Count > 2)
            {
                string imagen1 = articulos[0].Imagen.Replace("\\", "/");
                string authorImg1 = articulos[0].Imagen.Substring(0, imagen1.Length - 4);
                Articulo1 =
                       "<div class='post-thumbnail'>" +
                            "<img src='https://" + authorImg1 + "_4.jpg' alt=''>" +
                            "<div class='post-content d-flex align-items-center justify-content-between'>" +
                                "<div class='post-tag'><a href='#' onclick='Categoria(" + articulos[0].IdCategoria + ")'>" + articulos[0].Categoria + "</a></div> " +
                                "<a href='#' onclick='Post(" + articulos[0].Id + ")' class='headline'>" +
                                    "<h5>" + articulos[0].Titulo + "</h5>" +
                                "</a>" +
                                "<div class='post-meta'>" +
                                    "<p><a href = '#' class='post-author'>" + articulos[0].Autor + "</a> el <a href='#' class='post-date'>" + articulos[0].FechaRegistro + "</a></p>" +
                                "</div>" +
                            "</div>" +
                        "</div>";

                string imagen2 = articulos[1].Imagen.Replace("\\", "/");
                string authorImg2 = articulos[1].Imagen.Substring(0, imagen1.Length - 4);
                Articulo2 =
                       "<div class='post-thumbnail'>" +
                            "<img src='https://" + authorImg2 + "_4.jpg' alt=''>" +
                            "<div class='post-content d-flex align-items-center justify-content-between'>" +
                                "<div class='post-tag'><a href='#' onclick='Categoria(" + articulos[1].IdCategoria + ")'>" + articulos[1].Categoria + "</a></div> " +
                                "<a href='#' onclick='Post(" + articulos[1].Id + ")' class='headline'>" +
                                    "<h5>" + articulos[1].Titulo + "</h5>" +
                                "</a>" +
                                "<div class='post-meta'>" +
                                    "<p><a href = '#' class='post-author'>" + articulos[0].Autor + "</a> el <a href='#' class='post-date'>" + articulos[1].FechaRegistro + "</a></p>" +
                                "</div>" +
                            "</div>" +
                        "</div>";

                string imagen3 = articulos[2].Imagen.Replace("\\", "/");
                string authorImg3 = articulos[2].Imagen.Substring(0, imagen1.Length - 4);
                Articulo3 =
                       "<div class='post-thumbnail'>" +
                            "<img src='https://" + authorImg3 + "_4.jpg' alt=''>" +
                            "<div class='post-content d-flex align-items-center justify-content-between'>" +
                                "<div class='post-tag'><a href='#' onclick='Categoria(" + articulos[2].IdCategoria + ")'>" + articulos[2].Categoria + "</a></div> " +
                                "<a href='#' onclick='Post(" + articulos[2].Id + ")' class='headline'>" +
                                    "<h5>" + articulos[2].Titulo + "</h5>" +
                                "</a>" +
                                "<div class='post-meta'>" +
                                    "<p><a href = '#' class='post-author'>" + articulos[0].Autor + "</a> el <a href='#' class='post-date'>" + articulos[2].FechaRegistro + "</a></p>" +
                                "</div>" +
                            "</div>" +
                        "</div>";
            }


            foreach (var dt in ListArtTop5)
            {
                string imagen = dt.Imagen.Replace("\\", "/");
                string authorImg = dt.Imagen.Substring(0, imagen.Length - 4);
                SListArtTop5 +=
                    "<div class='single-blog-post post-style-4 d-flex align-items-center wow fadeInUpBig' data-wow-delay='0.2s'>" +
                        "<div class='post-thumbnail'>" +
                            "<img src='https://" + authorImg + "_5.jpg' alt=''>" +
                        "</div>" +
                        "<div class='post-content'>" +
                            "<a href= '#' onclick='Post(" + dt.Id + ")' class='headline'>" +
                                "<h5>" + dt.Titulo + "</h5>" +
                            "</a>" +
                            "<p>" + dt.Resumen + " ... </p>" +
                            "<div class='post-meta'>" +
                                "<p><a href = '#' class='post-author'>" + dt.Autor + "</a> on<a href='#' class='post-date'>" + dt.FechaRegistro + "</a></p>" +
                            "</div>" +
                        "</div>" +
                   "</div>";
            }


            foreach (var dt in ListArtTop2)
            {
                string imagen = dt.Imagen.Replace("\\", "/");
                string authorImg = dt.Imagen.Substring(0, imagen.Length - 4);
                SListArtTop2 +=
                    "<div class='single-blog-post wow fadeInUpBig' data-wow-delay='0.2s'> " +
                            "<div class='post-thumbnail' > " +
                                "<img src='https://" + authorImg + "_4.jpg' alt=''>" +
                                "<div class='post-cta'><a href='#' onclick='Categoria(" + dt.IdCategoria + ")'> " + dt.Categoria + "</a></div> " +
                            "</div>" +
                            "<div class='post-content'> " +
                                "<a href='#' onclick='Post(" + dt.Id + ")' class='headline'> " +
                                    "<h5>" + dt.Titulo + "</h5>" +
                                "</a>" +
                                "<p>" + dt.Resumen + " ... </p>" +
                                "<div class='post-meta'> " +
                                    "<p><a href='#' class='post-author'> " + dt.Autor + "</a> on <a href='#' class='post-date'> " + dt.FechaRegistro + "</a></p>" +
                                "</div>" +
                            "</div>" +
                        "</div>";

            }


            int a = 0;
            int tab = 1;
            string tablaList = "";
            string SubMEnu = "";
            string ListSubMEnu = "";
            string myTabContent = "";

            foreach (var dt in ListCategoria)
            {
                if (a == 0)
                {
                    tablaList +=
                    "<li class='nav-item'>" +
                        "<a class='nav-link active' id='tab"+ tab + "' data-toggle='tab' href='#world-tab-" + tab + "' role='tab' aria-controls='world-tab-" + tab + "' aria-selected='true'>"+ dt.Nombre + "</a>" +
                    "</li>";

                    myTabContent += "<div class='tab-pane fade show active' id='world-tab-" + tab + "' role='tabpanel' aria-labelledby='tab" + tab + "'> " + ListArtTopRamdom + " " +
                                    "</div>";
                    a += 1;
                    tab += 1; 
                }
                else
                {
                    if(tab < 5)
                    {
                        tablaList +=
                        "<li class='nav-item'>" +
                            "<a class='nav-link' id='tab" + tab + "' data-toggle='tab' href='#world-tab-" + tab + "' role='tab' aria-controls='world-tab-" + tab + "' aria-selected='false'>" + dt.Nombre + "</a>" +
                        "</li>";

                        myTabContent += "<div class='tab-pane fade' id='world-tab-" + tab + "' role='tabpanel' aria-labelledby='tab" + tab + "'>" + articulo.Articulo_Listar_IdCategoria(dt.Id) + " " +
                                    "</div>";
                    }
                    else
                    {
                        ListSubMEnu += "<a class='nav-link' id='tab" + tab + "' data-toggle='tab' href='#world-tab-" + tab + "' role='tab' aria-controls='world-tab-" + tab + "' aria-selected='false'>" + dt.Nombre + "</a>";
                        myTabContent += "<div class='tab-pane fade' id='world-tab-" + tab + "' role='tabpanel' aria-labelledby='tab" + tab + "'>" + articulo.Articulo_Listar_IdCategoria(dt.Id) + " " +
                                    "</div>";
                    }
                    tab += 1;
                }
            }

            if(ListCategoria.Count > 5)
            {
                SubMEnu =
                "<li class='nav-item dropdown'>" +
                    "<a class='nav-link dropdown-toggle' data-toggle='dropdown' href='#' role='button' aria-haspopup='true' aria-expanded='false'>Más</a>" +
                    "<div class='dropdown-menu'>" +
                        ListSubMEnu +
                    "</div>" +
                "</li>";
            }
            
            string conte =
            "<div class='world-catagory-area'>" +
                "<ul class='nav nav-tabs' id='myTab' role='tablist'>" +
                    "<li class='title'>No te pierdas</li>" +
                    tablaList + SubMEnu
                    +
                "</ul>" +
                "<div class='tab-content' id='myTabContent'>" +
                    myTabContent +
                "</div>" +
            "</div>";


            string Tendencia = articulo.Articulo_Home_ListTendencia();




            ViewBag.Hero_Slider = Hero_Slider;
            ViewBag.Post_Slider = Post_Slider;
            ViewBag.Blog_Post = Blog_Post;
            ViewBag.New_Articulo = New_Articulo;
            ViewBag.Articulo1 = Articulo1;
            ViewBag.Articulo2 = Articulo2;
            ViewBag.Articulo3 = Articulo3;

            ViewBag.ListArtTop5 = SListArtTop5;
            ViewBag.ListArtTop2 = SListArtTop2;

            ViewBag.conte = conte;
            ViewBag.Tendencia = Tendencia;

            return View();
        }

        public ActionResult Post(Application.Articulo articulo, Application.Comentario comentario)
        {

            if (!String.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                try
                {
                    int Id = 0;
                    Id = Convert.ToInt32(Request.QueryString["Id"]);
                    Models.Articulo articulo1 = articulo.Articulo_Seleccionar_Id(Id);

                    if(articulo1.Id > 0)
                    {
                        // CONTADOR DE VISITAS
                        List<Models.Articulo> SesionArticulo = new List<Models.Articulo>();
                        Models.Articulo New_articulo = new Models.Articulo();
                        New_articulo.Id = Id;
                        New_articulo.Clave = "";

                        if (Session["ListArticulos"] != null)
                        {
                            SesionArticulo = (List<Models.Articulo>)Session["ListArticulos"];
                        }

                        if(SesionArticulo.Count > 0)
                        {
                            Models.Articulo articulo3 = new Models.Articulo();
                            bool Encontrado = false;

                            foreach(var dt in SesionArticulo)
                            {
                                if(dt.Id == Id)
                                {
                                    Encontrado = true;
                                    articulo3.Id = dt.Id;
                                    articulo3.Clave = dt.Clave;
                                }
                            }

                            if (Encontrado)
                            {
                                New_articulo = articulo.Articulo_Vista_Agregar(articulo3);
                            }
                            else
                            {
                                New_articulo = articulo.Articulo_Vista_Agregar(New_articulo);
                            }
                        }
                        else
                        {
                            New_articulo = articulo.Articulo_Vista_Agregar(New_articulo);    
                        }


                        if (New_articulo.Id > 0)
                        {
                            SesionArticulo.Add(New_articulo);
                        }
                        

                        Session["ListArticulos"] = SesionArticulo;



                       



                        List<Models.Articulo> LisArtiuclo = articulo.Articulo_Blog_Home();
                        List<Models.Articulo> ListTopArticulo = articulo.Articulo_Top();
                        List<Models.Articulo> articulos = articulo.Articulo_Home_List();
                        string  comentaros = comentario.Comentario_Seleccionar_IdArticulo(Id);

                        string Header = "";
                        string Blog = "";
                        string Blog_Post = "";
                        string New_Articulo = "";
                        string Articulo1 = "";
                        string Articulo2 = "";
                        string Articulo3 = "";

                        string imagen = articulo1.Imagen.Replace("\\", "/");
                        string authorImg = articulo1.Imagen.Substring(0, imagen.Length - 4);

                        Header =
                        "<div class='hero-area height-400 bg-img background-overlay' style='background-image: url(https://" + articulo1.Imagen.Replace("\\", "/") + ");'>" +
                            "<div class='container h-100'>" +
                                "<div class='row h-100 align-items-center justify-content-center'>" +
                                    "<div class='col-12 col-md-8 col-lg-6'>" +
                                        "<div class='single-blog-title text-center'>" +
                                            "<!-- Catagory -->" +
                                            "<div class='post-cta'><a href='#' onclick='Categoria(" + articulo1.IdCategoria + ")' >" + articulo1.Categoria + "</a></div>" +
                                            "<h3>" + articulo1.Titulo + "</h3>" +
                                        "</div>" +
                                    "</div>" +
                                "</div>" +
                            "</div>" +
                        "</div>";

                        Blog =
                        "<div class='post-meta'>" +
                            "<p><a href='#' class='post-author'>" + articulo1.Autor + "</a> on <a href='#' class='post-date'>" + articulo1.FechaRegistro + "</a></p>" +
                        "</div>" +
                        "<div class='post-content'>" +
                            articulo1.Contenido +
                            "<div class='post-meta second-part'>" +
                                "<p><a href='#' class='post-author'>" + articulo1.Autor + "</a> on <a href='#' class='post-date'>" + articulo1.FechaRegistro + "</a></p>" +
                            "</div>" +
                        "</div>";


                        foreach (var dt in ListTopArticulo)
                        {
                            string imagen3 = dt.Imagen.Replace("\\", "/");
                            string authorImg3 = dt.Imagen.Substring(0, imagen3.Length - 4);

                            Blog_Post +=
                            "<div class='single-blog-post post-style-2 d-flex align-items-center widget-post'>" +
                                "<div class='post-thumbnail'>" +
                                    "<img src='https://" + authorImg3 + "_2.jpg' alt=''>" +
                                "</div>" +
                                "<div class='post-content'>" +
                                    "<a href = '#' onclick='Post(" + dt.Id + ")' class='headline'>" +
                                        "<h5 class='mb-0'>" + dt.Titulo + "</h5>" +
                                    "</a>" +
                                "</div>" +
                            "</div>";
                        }

                        if (LisArtiuclo.Count > 0)
                        {
                            string imagen2 = LisArtiuclo[0].Imagen.Replace("\\", "/");
                            string authorImg2 = LisArtiuclo[0].Imagen.Substring(0, imagen2.Length - 4);

                            New_Articulo =
                            "<div class='single-blog-post todays-pick'>" +
                                "<div class='post-thumbnail'>" +
                                    "<img src='https://" + authorImg2 + "_3.jpg' alt=''>" +
                                "</div>" +
                                "<div class='post-content px-0 pb-0'>" +
                                    "<a href='#' onclick='Post(" + LisArtiuclo[0].Id + ")' class='headline'>" +
                                        "<h5>" + LisArtiuclo[0].Titulo + "</h5>" +
                                    "</a>" +
                                "</div>" +
                            "</div>";
                        }


                        if (articulos.Count > 2)
                        {
                            string imagen1 = articulos[0].Imagen.Replace("\\", "/");
                            string authorImg1 = articulos[0].Imagen.Substring(0, imagen1.Length - 4);
                            Articulo1 =
                            "<div class='single-blog-post'>" +
                                "<!-- Post Thumbnail -->" +
                                "<div class='post-thumbnail'>" +
                                    "<img src='https://" + authorImg1 + "_4.jpg' alt=''>" +
                                    "<!-- Catagory -->" +
                                    "<div class='post-cta'><a href='#' onclick='Categoria(" + articulos[0].IdCategoria + ")'>" + articulos[0].Categoria + "</a></div>" +
                                "</div>" +
                                "<!-- Post Content -->" +
                                "<div class='post-content'>" +
                                    "<a href='#' onclick='Post(" + articulos[0].Id + ")' class='headline'>" +
                                        "<h5>" + articulos[0].Titulo + "</h5>" +
                                    "</a>" +
                                    "<p>" + articulos[0].Resumen + " ...</p>" +
                                    "<!-- Post Meta -->" +
                                    "<div class='post-meta'>" +
                                        "<p><a href='#' class='post-author'>" + articulos[0].Autor + "</a> el <a href='#' class='post-date'>" + articulos[0].FechaRegistro + "</a></p>" +
                                    "</div>" +
                                "</div>" +
                            "</div>";

                            string imagen2 = articulos[1].Imagen.Replace("\\", "/");
                            string authorImg2 = articulos[1].Imagen.Substring(0, imagen1.Length - 4);
                            Articulo2 =
                                   "<div class='single-blog-post'>" +
                                    "<!-- Post Thumbnail -->" +
                                    "<div class='post-thumbnail'>" +
                                        "<img src='https://" + authorImg2 + "_4.jpg' alt=''>" +
                                        "<!-- Catagory -->" +
                                        "<div class='post-cta'><a href='#' onclick='Categoria(" + articulos[1].IdCategoria + ")'>" + articulos[1].Categoria + "</a></div>" +
                                    "</div>" +
                                    "<!-- Post Content -->" +
                                    "<div class='post-content'>" +
                                        "<a href='#' onclick='Post(" + articulos[1].Id + ")' class='headline'>" +
                                            "<h5>" + articulos[1].Titulo + "</h5>" +
                                        "</a>" +
                                        "<p>" + articulos[1].Resumen + " ...</p>" +
                                        "<!-- Post Meta -->" +
                                        "<div class='post-meta'>" +
                                            "<p><a href='#' class='post-author'>" + articulos[1].Autor + "</a> el <a href='#' class='post-date'>" + articulos[1].FechaRegistro + "</a></p>" +
                                        "</div>" +
                                    "</div>" +
                                "</div>";

                            string imagen3 = articulos[2].Imagen.Replace("\\", "/");
                            string authorImg3 = articulos[2].Imagen.Substring(0, imagen1.Length - 4);
                            Articulo3 =
                                   "<div class='single-blog-post'>" +
                                        "<!-- Post Thumbnail -->" +
                                        "<div class='post-thumbnail'>" +
                                            "<img src='https://" + authorImg3 + "_4.jpg' alt=''>" +
                                            "<!-- Catagory -->" +
                                            "<div class='post-cta'><a href='#' onclick='Categoria(" + articulos[2].IdCategoria + ")'>" + articulos[2].Categoria + "</a></div>" +
                                        "</div>" +
                                        "<!-- Post Content -->" +
                                        "<div class='post-content'>" +
                                            "<a href='#' onclick='Post(" + articulos[2].Id + ")' class='headline'>" +
                                                "<h5>" + articulos[2].Titulo + "</h5>" +
                                            "</a>" +
                                            "<p>" + articulos[2].Resumen + " ...</p>" +
                                            "<!-- Post Meta -->" +
                                            "<div class='post-meta'>" +
                                                "<p><a href='#' class='post-author'>" + articulos[2].Autor + "</a> el <a href='#' class='post-date'>" + articulos[2].FechaRegistro + "</a></p>" +
                                            "</div>" +
                                        "</div>" +
                                    "</div>";
                        }

                        ViewBag.Id = Id;

                        ViewBag.Header = Header;
                        ViewBag.Blog = Blog;
                        ViewBag.Blog_Post = Blog_Post;
                        ViewBag.New_Articulo = New_Articulo;

                        ViewBag.Articulo1 = Articulo1;
                        ViewBag.Articulo2 = Articulo2;
                        ViewBag.Articulo3 = Articulo3;

                        ViewBag.Comentarios = comentaros;
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("New", "Blog");
                    }
                    
                }
                catch
                {
                    return RedirectToAction("New", "Blog");
                }
            }
            else
            {
                return RedirectToAction("New", "Blog");
            }
        }

        public ActionResult Categoria(Application.Articulo articulo)
        {

            if (!String.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                try
                {
                    int Id = 0;
                    Id = Convert.ToInt32(Request.QueryString["Id"]);
                    List<Models.Articulo> dtArticulos = articulo.Articulo_Selecionar_IdCategoria(Id);

                    if (dtArticulos.Count > 0)
                    {
                        List<Models.Articulo> LisArtiuclo = articulo.Articulo_Blog_Home();
                        List<Models.Articulo> ListTopArticulo = articulo.Articulo_Top();
                        List<Models.Articulo> articulos = articulo.Articulo_Home_List();

                        string Header = "";
                        string Blog = "";
                        string Blog_Post = "";
                        string New_Articulo = "";
                        string Articulo1 = "";
                        string Articulo2 = "";
                        string Articulo3 = "";



                        Header =
                            "<div class='hero-area height-400 bg-img background-overlay' style='background-image: url(https://" + dtArticulos[0].Imagen.Replace("\\", "/") + ");'></div>";

                        Blog = "" +
                        "<div class='world-catagory-area'>" +
                            "<ul class='nav nav-tabs' id='myTab' role='tablist'>" +
                                "<li class='title'>Últimos artículos</li>" +
                                "<li class='nav-item'>" +
                                    "<a class='nav-link active' id='tab1' data-toggle='tab' href='#world-tab-1' role='tab' aria-controls='world-tab-1' aria-selected='true'>" + dtArticulos[0].Categoria + "</a>" +
                                "</li>" +
                            "</ul>" +

                            "<div class='tab-content' id='myTabContent'>" +
                                "<div class='tab-pane fade show active' id='world-tab-1' role='tabpanel' aria-labelledby='tab1'>";
                        foreach (var dt in dtArticulos)
                        {
                            string imagen = dt.Imagen.Replace("\\", "/");
                            string authorImg = dt.Imagen.Substring(0, imagen.Length - 4);

                            Blog +=
                            "<!-- Single Blog Post -->" +
                            "<div class='single-blog-post post-style-4 d-flex align-items-center'>" +
                                "<!-- Post Thumbnail -->" +
                                "<div class='post-thumbnail'>" +
                                    "<img src='https://" + authorImg + "_5.jpg' alt=''>" +
                                "</div>" +
                                "<!-- Post Content -->" +
                                "<div class='post-content'>" +
                                    "<a href='#' onclick='Post(" + dt.Id + ")' class='headline'>" +
                                        "<h5>" + dt.Titulo + "</h5>" +
                                    "</a>" +
                                    "<p>" + dt.Resumen + " ...</p>" +
                                    "<!-- Post Meta -->" +
                                    "<div class='post-meta'>" +
                                        "<p><a href='#' class='post-author'>" + dt.Autor + "</a> el <a href='#' class='post-date'>" + dt.FechaRegistro + "</a></p>" +
                                    "</div>" +
                                "</div>" +
                            "</div>";
                        }
                                    
                        Blog +=
                                "</div>" +
                            "</div>" +
                        "</div>";

                        foreach (var dt in ListTopArticulo)
                        {
                            string imagen3 = dt.Imagen.Replace("\\", "/");
                            string authorImg3 = dt.Imagen.Substring(0, imagen3.Length - 4);

                            Blog_Post +=
                            "<div class='single-blog-post post-style-2 d-flex align-items-center widget-post'>" +
                                "<div class='post-thumbnail'>" +
                                    "<img src='https://" + authorImg3 + "_2.jpg' alt=''>" +
                                "</div>" +
                                "<div class='post-content'>" +
                                    "<a href = '#' onclick='Post(" + dt.Id + ")' class='headline'>" +
                                        "<h5 class='mb-0'>" + dt.Titulo + "</h5>" +
                                    "</a>" +
                                "</div>" +
                            "</div>";
                        }

                        if (LisArtiuclo.Count > 0)
                        {
                            string imagen2 = LisArtiuclo[0].Imagen.Replace("\\", "/");
                            string authorImg2 = LisArtiuclo[0].Imagen.Substring(0, imagen2.Length - 4);

                            New_Articulo =
                            "<div class='single-blog-post todays-pick'>" +
                                "<div class='post-thumbnail'>" +
                                    "<img src='https://" + authorImg2 + "_3.jpg' alt=''>" +
                                "</div>" +
                                "<div class='post-content px-0 pb-0'>" +
                                    "<a href='#' onclick='Post(" + LisArtiuclo[0].Id + ")' class='headline'>" +
                                        "<h5>" + LisArtiuclo[0].Titulo + "</h5>" +
                                    "</a>" +
                                "</div>" +
                            "</div>";
                        }


                        if (articulos.Count > 2)
                        {
                            string imagen1 = articulos[0].Imagen.Replace("\\", "/");
                            string authorImg1 = articulos[0].Imagen.Substring(0, imagen1.Length - 4);
                            Articulo1 =
                            "<div class='single-blog-post'>" +
                                "<!-- Post Thumbnail -->" +
                                "<div class='post-thumbnail'>" +
                                    "<img src='https://" + authorImg1 + "_4.jpg' alt=''>" +
                                    "<!-- Catagory -->" +
                                    "<div class='post-cta'><a href='#' onclick='Categoria(" + articulos[0].IdCategoria + ")'>" + articulos[0].Categoria + "</a></div>" +
                                "</div>" +
                                "<!-- Post Content -->" +
                                "<div class='post-content'>" +
                                    "<a href='#' onclick='Post(" + articulos[0].Id + ")' class='headline'>" +
                                        "<h5>" + articulos[0].Titulo + "</h5>" +
                                    "</a>" +
                                    "<p>" + articulos[0].Resumen + " ...</p>" +
                                    "<!-- Post Meta -->" +
                                    "<div class='post-meta'>" +
                                        "<p><a href='#' class='post-author'>" + articulos[0].Autor + "</a> el <a href='#' class='post-date'>" + articulos[0].FechaRegistro + "</a></p>" +
                                    "</div>" +
                                "</div>" +
                            "</div>";

                            string imagen2 = articulos[1].Imagen.Replace("\\", "/");
                            string authorImg2 = articulos[1].Imagen.Substring(0, imagen1.Length - 4);
                            Articulo2 =
                                   "<div class='single-blog-post'>" +
                                    "<!-- Post Thumbnail -->" +
                                    "<div class='post-thumbnail'>" +
                                        "<img src='https://" + authorImg2 + "_4.jpg' alt=''>" +
                                        "<!-- Catagory -->" +
                                        "<div class='post-cta'><a href='#' onclick='Categoria(" + articulos[1].IdCategoria + ")'>" + articulos[1].Categoria + "</a></div>" +
                                    "</div>" +
                                    "<!-- Post Content -->" +
                                    "<div class='post-content'>" +
                                        "<a href='#' onclick='Post(" + articulos[1].Id + ")' class='headline'>" +
                                            "<h5>" + articulos[1].Titulo + "</h5>" +
                                        "</a>" +
                                        "<p>" + articulos[1].Resumen + " ...</p>" +
                                        "<!-- Post Meta -->" +
                                        "<div class='post-meta'>" +
                                            "<p><a href='#' class='post-author'>" + articulos[1].Autor + "</a> el <a href='#' class='post-date'>" + articulos[1].FechaRegistro + "</a></p>" +
                                        "</div>" +
                                    "</div>" +
                                "</div>";

                            string imagen3 = articulos[2].Imagen.Replace("\\", "/");
                            string authorImg3 = articulos[2].Imagen.Substring(0, imagen1.Length - 4);
                            Articulo3 =
                                   "<div class='single-blog-post'>" +
                                        "<!-- Post Thumbnail -->" +
                                        "<div class='post-thumbnail'>" +
                                            "<img src='https://" + authorImg3 + "_4.jpg' alt=''>" +
                                            "<!-- Catagory -->" +
                                            "<div class='post-cta'><a href='#' onclick='Categoria(" + articulos[2].IdCategoria + ")'>" + articulos[2].Categoria + "</a></div>" +
                                        "</div>" +
                                        "<!-- Post Content -->" +
                                        "<div class='post-content'>" +
                                            "<a href='#' onclick='Post(" + articulos[2].Id + ")' class='headline'>" +
                                                "<h5>" + articulos[2].Titulo + "</h5>" +
                                            "</a>" +
                                            "<p>" + articulos[2].Resumen + " ...</p>" +
                                            "<!-- Post Meta -->" +
                                            "<div class='post-meta'>" +
                                                "<p><a href='#' class='post-author'>" + articulos[2].Autor + "</a> el <a href='#' class='post-date'>" + articulos[2].FechaRegistro + "</a></p>" +
                                            "</div>" +
                                        "</div>" +
                                    "</div>";
                        }

                        ViewBag.Header = Header;
                        ViewBag.Blog = Blog;

                        ViewBag.Blog_Post = Blog_Post;
                        ViewBag.New_Articulo = New_Articulo;

                        ViewBag.Articulo1 = Articulo1;
                        ViewBag.Articulo2 = Articulo2;
                        ViewBag.Articulo3 = Articulo3;

                        return View();
                    }
                    else
                    {
                        return RedirectToAction("New", "Blog");
                    }

                }
                catch
                {
                    return RedirectToAction("New", "Blog");
                }
            }
            else
            {
                return RedirectToAction("New", "Blog");
            }
        }

        public JsonResult AgregarComentario(Models.Comentario comentario, Application.Comentario APcomentario)
        {
            // REGISTRAR VACANTE
            comentario.Resultado = APcomentario.Comentario_Agregar(comentario).Resultado;
            if (comentario.Resultado > 0)
            {
                comentario.Id = comentario.Resultado;
            }
            return Json(comentario);
        }
    }
}
