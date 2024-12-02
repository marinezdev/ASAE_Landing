using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net.Mail;
using System.Net.Security;
using System.Net;

namespace NuevaWebAsae.Application
{
    public class Vacante
    {
        Data.Vacante _vacante = new Data.Vacante();
        Data.UsuarioResponsable _UsuarioResponsable = new Data.UsuarioResponsable();

        public Models.Vacante Vacante_Agregar(Models.Vacante vacante)
        {
            Models.Vacante dbvacante = new Models.Vacante();
            dbvacante = _vacante.Vacante_Agregar(vacante);
            // ENVIO DE CORREO ELECTRONICO
          
            if (dbvacante.Id > 0)
            {
                List<Models.UsuarioResponsable> dbUsuarioResposble = _UsuarioResponsable.UsuarioResponsable_Seleccionar();

                if (dbUsuarioResposble != null)
                {
                    foreach (Models.UsuarioResponsable usuarioResponsable in dbUsuarioResposble)
                    {
                        EmailEnvioNuevaVacante(usuarioResponsable, dbvacante);
                    }
                }
            }
            return dbvacante;
        }

        public bool EmailEnvioNuevaVacante(Models.UsuarioResponsable usuarioResponsable, Models.Vacante dbvacante)
        {
            bool result =  false;
            string Messenger = "";

            string host = "mail.asae.com.mx";
            int puerto = 25;
            string usuario = "soporte-aplicaciones@asae.com.mx";
            string contra = "$%65hgy#19_";
            string pCorreo = usuarioResponsable.Email.Trim();

            MailMessage correo = new MailMessage();
            correo.To.Add(new MailAddress(pCorreo));
            correo.From = new MailAddress(usuario, "ASAE CONSULTORES, S.A DE C.V");
            correo.Subject = "Nueva vacante registrada: " + dbvacante.Titulo;
            correo.Body = NuevaVacanteFormato2(dbvacante);

            correo.IsBodyHtml = true;
            correo.Priority = MailPriority.Normal;

            SmtpClient smtp = new SmtpClient(host, puerto);
            smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(usuario, contra);

            ServicePointManager.ServerCertificateValidationCallback =
               delegate (object s
                   , System.Security.Cryptography.X509Certificates.X509Certificate certificate
                   , System.Security.Cryptography.X509Certificates.X509Chain chai
                   , SslPolicyErrors sslPolicyErrors)
               {
                   return true;
               };
            try
            {
                smtp.Send(correo);
                correo.Dispose();
                result = true;
            }
            catch (Exception ex)
            {
                Messenger = "Error: " + ex.Message;
            }
            return result;
        }
        public string NuevaVacanteFormato2(Models.Vacante vacante)
        {
            Models.Vacante dbVacante = _vacante.Vacante_Seleccionar_Id(vacante);
            List<Models.Vacante> ListVacante = new List<Models.Vacante>();
            ListVacante = _vacante.Vacante_Seleccionar_Top3();

            string host = HttpContext.Current.Request.Url.Authority;
            Models.URL Url = new Models.URL();
            Url.UrlVaible = dbVacante.Id.ToString();
            string IdVacante = Application.Cifrado.Encriptar(Url.UrlVaible);

            string vacantes = "";
            foreach (Models.Vacante _vacante in ListVacante)
            {
                vacantes += "							  <tr style='border-bottom: 1px solid rgba(0,0,0,.05);'>" +
                            " 								<td valign='middle' width='70%' style='text-align:left; padding: 0 2.5em;'>" +
                            "  									<div class='product-entry'>" +
                            "  										<br><img src='https://www.asae.com.mx/01/AsaeLogo_Email.png' alt='' style='width: 100px; max-width: 600px; height: auto; margin-bottom: 20px; display: block;'>" +
                            "  										<div class='text'>" +
                            "  											<h3 style='line-height: 1.2;'>" + _vacante.Titulo + "</h3>" +
                            "  											<span>Fecha publicación: " + _vacante.FechaRegistro + "</span>" +
                            "  											<p>" + _vacante.Cat_ProyectoServicios.Cat_Clientes.Nombre + " - " + _vacante.Cat_ProyectoServicios.Nombre + "</p>" +
                            "  										</div>" +
                            "  									</div>" +
                            "  								</td>" +
                            "  								<td valign='middle' width='30%' style='text-align:center; padding-right: 2.5em;'>" +
                            "  									<span class='price' style='color: #000000; font-size: 20px; display: block;'> " + _vacante.Prospecto + "</span>" +
                            "  									<span style='display: block;'>Prospectos</span>" +
                            "  									<span><a href='https://rechumanos.asae.com.mx/Vacantes/Vacante?Id=" + _vacante.Id + "' class='btn btn-primary'>Mostrar</a></span>" +
                            "  								</td>" +
                            "							  </tr>";
            }


            string Html = $@"
                    <!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
                    <html xmlns=""http://www.w3.org/1999/xhtml"" xmlns:o=""urn:schemas-microsoft-com:office:office"">
                     <head>
                      <meta charset=""UTF-8"">
                      <meta content=""width=device-width, initial-scale=1"" name=""viewport"">
                      <meta name=""x-apple-disable-message-reformatting"">
                      <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
                      <meta content=""telephone=no"" name=""format-detection"">
                      <title>Nuevo mensaje</title><!--[if (mso 16)]>
                        <style type=""text/css"">
                        a {{text-decoration: none;}}
                        </style>
                        <![endif]--><!--[if gte mso 9]><style>sup {{ font-size: 100% !important; }}</style><![endif]--><!--[if gte mso 9]>
                    <xml>
                        <o:OfficeDocumentSettings>
                        <o:AllowPNG></o:AllowPNG>
                        <o:PixelsPerInch>96</o:PixelsPerInch>
                        </o:OfficeDocumentSettings>
                    </xml>
                    <![endif]--><!--[if !mso]><!-- -->
                      <link href=""https://fonts.googleapis.com/css2?family=Orbitron&display=swap"" rel=""stylesheet""><!--<![endif]-->
                      <style type=""text/css"">
                    #outlook a {{
	                    padding:0;
                    }}
                    .es-button {{
	                    mso-style-priority:100!important;
	                    text-decoration:none!important;
                    }}
                    a[x-apple-data-detectors] {{
	                    color:inherit!important;
	                    text-decoration:none!important;
	                    font-size:inherit!important;
	                    font-family:inherit!important;
	                    font-weight:inherit!important;
	                    line-height:inherit!important;
                    }}
                    .es-desk-hidden {{
	                    display:none;
	                    float:left;
	                    overflow:hidden;
	                    width:0;
	                    max-height:0;
	                    line-height:0;
	                    mso-hide:all;
                    }}
                    @media only screen and (max-width:600px) {{p, ul li, ol li, a {{ line-height:150%!important }} h1, h2, h3, h1 a, h2 a, h3 a {{ line-height:120% }} h1 {{ font-size:30px!important; text-align:left }} h2 {{ font-size:24px!important; text-align:left }} h3 {{ font-size:20px!important; text-align:left }} .es-header-body h1 a, .es-content-body h1 a, .es-footer-body h1 a {{ font-size:30px!important; text-align:left }} 
                    .es-header-body h2 a, .es-content-body h2 a, .es-footer-body h2 a {{ font-size:24px!important; text-align:left }} .es-header-body h3 a, .es-content-body h3 a, .es-footer-body h3 a {{ font-size:20px!important; text-align:left }} .es-menu td a {{ font-size:14px!important }} .es-header-body p, .es-header-body ul li, .es-header-body ol li, .es-header-body a {{ font-size:14px!important }} .es-content-body p, 
                    .es-content-body ul li, .es-content-body ol li, .es-content-body a {{ font-size:14px!important }} .es-footer-body p, .es-footer-body ul li, .es-footer-body ol li, .es-footer-body a {{ font-size:14px!important }} .es-infoblock p, .es-infoblock ul li, .es-infoblock ol li, .es-infoblock a {{ font-size:12px!important }} *[class=""gmail-fix""] {{ display:none!important }} .es-m-txt-c, .es-m-txt-c h1, .es-m-txt-c h2, 
                    .es-m-txt-c h3 {{ text-align:center!important }} .es-m-txt-r, .es-m-txt-r h1, .es-m-txt-r h2, .es-m-txt-r h3 {{ text-align:right!important }} .es-m-txt-l, .es-m-txt-l h1, .es-m-txt-l h2, .es-m-txt-l h3 {{ text-align:left!important }} .es-m-txt-r img, .es-m-txt-c img, .es-m-txt-l img {{ display:inline!important }} .es-button-border {{ display:inline-block!important }} a.es-button, 
                    button.es-button {{ font-size:18px!important; display:inline-block!important }} .es-adaptive table, .es-left, .es-right {{ width:100%!important }} .es-content table, .es-header table, .es-footer table, .es-content, .es-footer, .es-header {{ width:100%!important; max-width:600px!important }} .es-adapt-td {{ display:block!important; width:100%!important }} .adapt-img {{ width:100%!important; height:auto!important }} 
                    .es-m-p0 {{ padding:0!important }} .es-m-p0r {{ padding-right:0!important }} .es-m-p0l {{ padding-left:0!important }} .es-m-p0t {{ padding-top:0!important }} .es-m-p0b {{ padding-bottom:0!important }} .es-m-p20b {{ padding-bottom:20px!important }} .es-mobile-hidden, .es-hidden {{ display:none!important }} 
                    tr.es-desk-hidden, td.es-desk-hidden, table.es-desk-hidden {{ width:auto!important; overflow:visible!important; float:none!important; max-height:inherit!important; line-height:inherit!important }} tr.es-desk-hidden {{ display:table-row!important }} table.es-desk-hidden {{ display:table!important }} td.es-desk-menu-hidden {{ display:table-cell!important }} .es-menu td {{ width:1%!important }} 
                    table.es-table-not-adapt, .esd-block-html table {{ width:auto!important }} table.es-social {{ display:inline-block!important }} table.es-social td {{ display:inline-block!important }} .es-desk-hidden {{ display:table-row!important; width:auto!important; overflow:visible!important; max-height:inherit!important }} .es-m-p5 {{ padding:5px!important }} .es-m-p5t {{ padding-top:5px!important }} 
                    .es-m-p5b {{ padding-bottom:5px!important }} .es-m-p5r {{ padding-right:5px!important }} .es-m-p5l {{ padding-left:5px!important }} .es-m-p10 {{ padding:10px!important }} .es-m-p10t {{ padding-top:10px!important }} .es-m-p10b {{ padding-bottom:10px!important }} .es-m-p10r {{ padding-right:10px!important }} .es-m-p10l {{ padding-left:10px!important }} .es-m-p15 {{ padding:15px!important }} 
                    .es-m-p15t {{ padding-top:15px!important }} .es-m-p15b {{ padding-bottom:15px!important }} .es-m-p15r {{ padding-right:15px!important }} .es-m-p15l {{ padding-left:15px!important }} .es-m-p20 {{ padding:20px!important }} .es-m-p20t {{ padding-top:20px!important }} .es-m-p20r {{ padding-right:20px!important }} .es-m-p20l {{ padding-left:20px!important }} .es-m-p25 {{ padding:25px!important }} 
                    .es-m-p25t {{ padding-top:25px!important }} .es-m-p25b {{ padding-bottom:25px!important }} .es-m-p25r {{ padding-right:25px!important }} .es-m-p25l {{ padding-left:25px!important }} .es-m-p30 {{ padding:30px!important }} .es-m-p30t {{ padding-top:30px!important }} .es-m-p30b {{ padding-bottom:30px!important }} .es-m-p30r {{ padding-right:30px!important }} .es-m-p30l {{ padding-left:30px!important }} 
                    .es-m-p35 {{ padding:35px!important }} .es-m-p35t {{ padding-top:35px!important }} .es-m-p35b {{ padding-bottom:35px!important }} .es-m-p35r {{ padding-right:35px!important }} .es-m-p35l {{ padding-left:35px!important }} .es-m-p40 {{ padding:40px!important }} .es-m-p40t {{ padding-top:40px!important }} .es-m-p40b {{ padding-bottom:40px!important }} .es-m-p40r {{ padding-right:40px!important }} 
                    .es-m-p40l {{ padding-left:40px!important }} }}
                    </style>
                     </head>
                     <body style=""width:100%;font-family:arial, 'helvetica neue', helvetica, sans-serif;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;padding:0;Margin:0"">
                      <div class=""es-wrapper-color"" style=""background-color:#EFEFEF""><!--[if gte mso 9]>
			                    <v:background xmlns:v=""urn:schemas-microsoft-com:vml"" fill=""t"">
				                    <v:fill type=""tile"" color=""#efefef"" origin=""0.5, 0"" position=""0.5, 0""></v:fill>
			                    </v:background>
		                    <![endif]-->
                       <table class=""es-wrapper"" width=""100%"" cellspacing=""0"" cellpadding=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;padding:0;Margin:0;width:100%;height:100%;background-repeat:repeat;background-position:center top;background-color:#EFEFEF"">
                         <tr>
                          <td valign=""top"" style=""padding:0;Margin:0"">
                           <table class=""es-content"" cellspacing=""0"" cellpadding=""0"" align=""center"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%"">
                             <tr>
                              <td align=""center"" style=""padding:0;Margin:0"">
                               <table class=""es-content-body"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#cfe2f3;width:600px"" cellspacing=""0"" cellpadding=""0"" bgcolor=""#cfe2f3"" align=""center"">
                                 <tr>
                                  <td align=""left"" style=""padding:0;Margin:0"">
                                   <table width=""100%"" cellspacing=""0"" cellpadding=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                     <tr>
                                      <td class=""es-m-p0r es-m-p20b"" valign=""top"" align=""center"" style=""padding:0;Margin:0;width:600px"">
                                       <table width=""100%"" cellspacing=""0"" cellpadding=""0"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                         <tr>
                                          <td align=""center"" style=""padding:0;Margin:0;position:relative""><a target=""_blank""  style=""-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;text-decoration:underline;color:#068FC1;font-size:14px""><img class=""adapt-img"" src=""https://mcbihx.stripocdn.email/content/guids/bannerImgGuid/images/image16953231768215542.png"" alt=""World tourism day"" title=""World tourism day"" width=""600"" style=""display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic"" height=""384""></a></td>
                                         </tr>
                                       </table></td>
                                     </tr>
                                   </table></td>
                                 </tr>
                               </table></td>
                             </tr>
                           </table>
                           <table cellpadding=""0"" cellspacing=""0"" class=""es-content"" align=""center"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%"">
                             <tr>
                              <td align=""center"" style=""padding:0;Margin:0"">
                               <table bgcolor=""#ffffff"" class=""es-content-body"" align=""center"" cellpadding=""0"" cellspacing=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px"">
                                 <tr>
                                  <td align=""left"" style=""Margin:0;padding-top:20px;padding-left:20px;padding-right:20px;padding-bottom:30px"">
                                   <table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                     <tr>
                                      <td align=""center"" valign=""top"" style=""padding:0;Margin:0;width:560px"">
                                       <table cellpadding=""0"" cellspacing=""0"" width=""100%"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                         <tr>
                                            <td align=""left"" class=""es-m-txt-c es-m-p0r es-m-p0l"" style=""padding:0;Margin:0;padding-left:40px;padding-right:40px"">
                                                <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:39px;color:#455A64;font-size:26px;text-align:center"">
                                                    <strong> Nueva vacante registrada </strong>
                                                </p>
                                                <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:center"">
                                                    <br>
                                                </p>
                                                <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:justify"">
                                                    Se solicita de su apoyo para iniciar el proceso de reclutamiento de esta nueva vacante: 
                                                </p>
                                                <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:center"">
                                                    <strong>' { dbVacante.Titulo } ' </strong> <br>
                                                </p>
                                                <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px;text-align:left"">
                                                    Consulta los detalles de la vacante en el siguiente link: <br> 
                                                    <a href='https://www.asae.com.mx/Vacantes/InfoVacante?Id={ IdVacante }'> https://www.asae.com.mx/Vacantes/InfoVacante?Id={ IdVacante } </a>
                                                    <br>
                                                </p>
                                                <p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px"">
                                                    <br><br>
                                                </p>
                                            </td>
                                         </tr>
                                       </table></td>
                                     </tr>
                                   </table></td>
                                 </tr>
             
                               </table></td>
                             </tr>
                           </table>
                           <table cellpadding=""0"" cellspacing=""0"" class=""es-content"" align=""center"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%"">
                             <tr>
                              <td align=""center"" style=""padding:0;Margin:0"">
                               <table bgcolor=""#ffffff"" class=""es-content-body"" align=""center"" cellpadding=""0"" cellspacing=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px"">
                                 <tr>
                                  <td align=""left"" style=""padding:0;Margin:0;padding-left:20px;padding-right:20px"">
                                   <table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                     <tr>
                                      <td align=""center"" valign=""top"" style=""padding:0;Margin:0;width:560px"">
                                       <table cellpadding=""0"" cellspacing=""0"" width=""100%"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                         <tr>
                                          <td align=""center"" style=""padding:0;Margin:0;font-size:0"">
                                           <table border=""0"" width=""100%"" height=""100%"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                             <tr>
                                              <td style=""padding:0;Margin:0;border-bottom:1px solid #9cd3ec;background:unset;height:1px;width:100%;margin:0px""></td>
                                             </tr>
                                           </table></td>
                                         </tr>
                                       </table></td>
                                     </tr>
                                   </table></td>
                                 </tr>
                                 <tr>
                                 </table>
                                </td>
                             </tr>
                           </table>


                          
                           <table cellpadding=""0"" cellspacing=""0"" class=""es-content"" align=""center"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%"">
                             <tr>
                              <td align=""center"" style=""padding:0;Margin:0"">
                               <table bgcolor=""#ffffff"" class=""es-content-body"" align=""center"" cellpadding=""0"" cellspacing=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px"">
                                 <tr>
                                  <td align=""left"" style=""Margin:0;padding-top:20px;padding-left:20px;padding-right:20px;padding-bottom:30px"">
                                   <table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                     <tr>
                                      <td align=""center"" valign=""top"" style=""padding:0;Margin:0;width:560px"">
                                        <table cellpadding=""0"" cellspacing=""0"" width=""100%"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                        {
                                            vacantes
                                        }
                                        </table></td>
                                     </tr>
                                   </table></td>
                                 </tr>
             
                               </table></td>
                             </tr>
                           </table>
                            
                            

                            <table cellpadding=""0"" cellspacing=""0"" class=""es-content"" align=""center"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%"">
                             <tr>
                              <td align=""center"" style=""padding:0;Margin:0"">
                               <table bgcolor=""#ffffff"" class=""es-content-body"" align=""center"" cellpadding=""0"" cellspacing=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px"">
                                 <tr>
                                  <td align=""left"" style=""padding:0;Margin:0;padding-left:20px;padding-right:20px"">
                                   <table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                     <tr>
                                      <td align=""center"" valign=""top"" style=""padding:0;Margin:0;width:560px"">
                                       <table cellpadding=""0"" cellspacing=""0"" width=""100%"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                         <tr>
                                          <td align=""center"" style=""padding:0;Margin:0;font-size:0"">
                                           <table border=""0"" width=""100%"" height=""100%"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                             <tr>
                                              <td style=""padding:0;Margin:0;border-bottom:1px solid #9cd3ec;background:unset;height:1px;width:100%;margin:0px""></td>
                                             </tr>
                                           </table></td>
                                         </tr>
                                       </table></td>
                                     </tr>
                                   </table></td>
                                 </tr>
                                 <tr>
                                 </table>
                                </td>
                             </tr>
                           </table>
                           <table cellpadding=""0"" cellspacing=""0"" class=""es-footer"" align=""center"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%;background-color:transparent;background-repeat:repeat;background-position:center top"">
                             <tr>
                              <td align=""center"" style=""padding:0;Margin:0"">
                               <table bgcolor=""#ffffff"" class=""es-footer-body"" align=""center"" cellpadding=""0"" cellspacing=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px"">
                                 <tr>
                                  <td align=""left"" style=""Margin:0;padding-bottom:20px;padding-left:20px;padding-right:20px;padding-top:40px"">
                                   <table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                     <tr>
                                      <td align=""center"" valign=""top"" style=""padding:0;Margin:0;width:560px"">
                                       <table cellpadding=""0"" cellspacing=""0"" width=""100%"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                         <tr>
                                          <td align=""center"" style=""padding:0;Margin:0""><p style=""Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:arial, 'helvetica neue', helvetica, sans-serif;line-height:21px;color:#455A64;font-size:14px"">Este correo es de carácter informativo, favor de no responder a esta dirección de correo, ya que no se encuentra habilitada para recibir mensajes. Si necesitas ayuda o deseas contactarnos ponemos a su disposición a los teléfonos correspondientes.</p></td>
                                         </tr>
                                       </table></td>
                                     </tr>
                                   </table></td>
                                 </tr>
                                 <tr>
                                  <td align=""left"" style=""Margin:0;padding-left:20px;padding-right:20px;padding-top:30px;padding-bottom:30px"">
                                   <table cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                     <tr>
                                      <td align=""left"" style=""padding:0;Margin:0;width:560px"">
                                       <table cellpadding=""0"" cellspacing=""0"" width=""100%"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                                         <tr>
                                          <td align=""center"" class=""es-infoblock made_with"" style=""padding:0;Margin:0;line-height:14px;font-size:0px;color:#CCCCCC""><a target=""_blank""  style=""-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;text-decoration:underline;color:#CCCCCC;font-size:12px""><img src=""https://mcbihx.stripocdn.email/content/guids/CABINET_dd9638105a0e16e64bb51094f748e01204c98b514c82e3a56b420241fe394548/images/asaelogo_kRs.png"" alt width=""125"" style=""display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic"" height=""52""></a></td>
                                         </tr>
                                       </table></td>
                                     </tr>
                                   </table></td>
                                 </tr>
                               </table></td>
                             </tr>
                           </table></td>
                         </tr>
                       </table>
                      </div>
                     </body>
                    </html>
                    ";

            return Html;
        }
        public List<Models.Vacante> Vacante_Seleccionar_General()
        {
            return _vacante.Vacante_Seleccionar_General();
        }
        public List<Models.Vacante> Vacante_Seleccionar(Models.Usuario usuario)
        {
            return _vacante.Vacante_Seleccionar(usuario);
        }
        public Models.Vacante Vacante_Seleccionar_Id(Models.Vacante vacante)
        {
            return _vacante.Vacante_Seleccionar_Id(vacante);
        }
        public Models.Vacante Vacante_Pintar_Id(Models.Vacante vacante)
        {
            return _vacante.Vacante_Pintar_Id(vacante);
        }
        public Models.Vacante Vacante_Consultar(Models.Vacante vacante)
        {
            return _vacante.Vacante_Consultar(vacante);
        }
        public Models.Vacante Vacante_ConsultarProyecto(Models.Vacante vacante)
        {
            return _vacante.Vacante_ConsultarProyecto(vacante);
        }
        public Models.Vacante Vacante_Actualizar(Models.Vacante vacante)
        {
            Models.Vacante dbvacante = new Models.Vacante();
            dbvacante = _vacante.Vacante_Actualizar(vacante);
            return dbvacante;
        }
        public List<Models.Vacante> PlantillaVacante_Listar()
        {
            return _vacante.PlantillaVacante_Listar();
        }
        public Models.Vacante PlantillaVacante_Listar_Id(Models.Vacante vacante)
        {
            return _vacante.PlantillaVacante_Listar_Id(vacante);
        }
    }
}
