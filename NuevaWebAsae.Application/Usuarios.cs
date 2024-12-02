using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mime;

namespace NuevaWebAsae.Application
{
    
    public class Usuarios
    {
        Data.Usuarios dtUser = new Data.Usuarios();
		Data.AsaeWebSeccion dtAsaeWebSeccion = new Data.AsaeWebSeccion();

		public Models.Mensaje AsaeWebUsuarioAgregar(Models.Usuario usuario)
        {
            Models.Mensaje mensaje = new Models.Mensaje();

			mensaje = validar(usuario);

			if(mensaje.Respuesta == 1)
			{
				mensaje = dtUser.AsaeWebUsuarioAgregar(usuario);
				WSCorreo.CorreoSoapClient correo1 = new WSCorreo.CorreoSoapClient();

				// MANDAR CORREO 
				if (mensaje.Respuesta == 1)
				{
					Models.Usuario usuario1 = dtUser.AsaeWebUsuario_consulta_Token(mensaje.Token);
					if (correo1.CorreoMetPrivado("mail.asae.com.mx", 25, "soporte-aplicaciones@asae.com.mx", "$%65hgy#19_", mensaje.Email, "Asae consultores S.A. de C.V.", "Confirmación de conferencia web", NewUserHTML(usuario1, mensaje.Token)) == "Correo enviado")
					{
						mensaje.RespuestaText = "Se ha enviado un correo electrónico a " + mensaje.Email + " para confirmar tu participación, además de información sobre el evento.";
					}
				}
			}
            return mensaje;
        }
		public Models.Mensaje AsaeWebUsuarioBuscar(Models.Usuario usuario)
		{
			Models.Mensaje mensaje = new Models.Mensaje();
			mensaje = dtUser.AsaeWebUsuarioBuscar(usuario);
			WSCorreo.CorreoSoapClient correo1 = new WSCorreo.CorreoSoapClient();
			// MANDAR CORREO 
			if (mensaje.Token.Length > 5)
			{
				Models.Usuario usuario1 = dtUser.AsaeWebUsuario_consulta_Token(mensaje.Token);
				if (correo1.CorreoMetPrivado("mail.asae.com.mx", 25, "soporte-aplicaciones@asae.com.mx", "$%65hgy#19_", mensaje.Email, "Asae consultores S.A. de C.V.", "Confirmación de conferencia web", NewUserHTML(usuario1, mensaje.Token)) == "Correo enviado")
				{
					mensaje.Respuesta = 1;
					mensaje.RespuestaText = "Se ha enviado un correo electrónico a " + mensaje.Email + " para confirmar tu participación, además de información sobre el evento.";
				}
			}
			else{
				mensaje.Respuesta = 0;
			}

			return mensaje;
		}
		public Models.Usuario AsaeWebUsuario_Selecionar_Token(string Token)
		{
			Models.Usuario usuario = dtUser.AsaeWebUsuario_Selecionar_Token(Token);
			return usuario;
		}
		private string NewUserHTML(Models.Usuario usuario, string token)
		{
			string body = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
								"<html xmlns:v='urn:schemas-microsoft-com:vml'>" +
								"<head>" +
									"<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />" +
									"<meta name='viewport' content='width=device-width; initial-scale=1.0; maximum-scale=1.0;' />" +
									
									"<link href='https://fonts.googleapis.com/css?family=Nunito+Sans:200,300,400,600,700' rel='stylesheet'>" +
									"<!--<![endif]-->" +
									"<title>Asae Consultores S.A de C.V</title>" +
									"<style type='text/css'>" +
										"body {" +
											"width: 100%;" +
											"background-color: #ffffff;" +
											"margin: 0;" +
											"padding: 0;" +
											"-webkit-font-smoothing: antialiased;" +
											"mso-margin-top-alt: 0px;" +
											"mso-margin-bottom-alt: 0px;" +
											"mso-padding-alt: 0px 0px 0px 0px;" +
											"font-family: 'Proxima Nova',-apple-system,'Helvetica Neue',Helvetica,Roboto,Arial,sans-serif;" +
										"}" +
										"* {" +
											"-ms-text-size-adjust: 100%;" +
											"-webkit-text-size-adjust: 100%;" +
										"}" +
										"div[style*='margin: 16px 0'] {" +
											"margin: 0 !important;" +
										"}" +

										"table," +
										"td {" +
											"mso-table-lspace: 0pt !important;" +
											"mso-table-rspace: 0pt !important;" +
										"}" +

										"table {" +
											"border-spacing: 0 !important;" +
											"border-collapse: collapse !important;" +
											"table-layout: fixed !important;" +
											"margin: 0 auto !important;" +
										"}" +

										"img {" +
											"-ms-interpolation-mode:bicubic;" +
										"}" +
										"a {" +
											"text-decoration: none;" +
										"}" +
										"h1, h2, h3, h4, h5, h6 {" +
											"font-family: 'Nunito Sans', sans-serif;" +
											"color: #000000;" +
											"margin-top: 0;" +
										"}" +

										".logo h1{" +
											"margin: 0;" +
										"}" +
										".logo h1 a{" +
											"color: #0aaa42;" +
											"font-size: 20px;" +
											"font-weight: 700;" +
											"font-family: 'Nunito Sans', sans-serif;" +
										"}" +
									"</style>" +
								"</head>" +
									"<body class='respond' leftmargin='0' topmargin='0' marginwidth='0' marginheight='0'>" +
									"<!-- header -->" +
									"<table border='0' width='100%' cellpadding='0' cellspacing='0' bgcolor='ffffff'>" +
										"<tr>" +
											"<td align='center' style='background-color: #f1f1f1;'>" +
												"<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' class='container590'>" +
													"<tr>" +
														"<td align='center'>" +
															"<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff;'>" +
																"<tr>" +
																	"<td align='center' style='padding: 1em 2.5em;'>" +
																		"<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
																			"<tr>" +
																				"<td width='45%' class='logo' style='text-align: left; padding: 20px'>" +
																					"<h1><a href='https://www.asae.com.mx/'>Asae Consultores</a></h1>" +
																				  "</td>" +
																				  "<td width='55%' class='logo' style='text-align: right;'>" +
																					"<table width='100%' border='0' cellpadding='0' cellspacing='0' style='border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;' class='container590 hide'>" +
																						"<tr>" +
																							"<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500; '>" +
																								"<a href='https://www.asae.com.mx/' style='color: #adadad;'>Inicio </a>" +
																							"</td>" +
																							"<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
																								"<a href='#' style='color: #adadad;'>Experiencia </a>" +
																							"</td>" +
																							"<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
																								"<a href='https://www.asae.com.mx/#feature' style='color: #adadad;'>Servicios </a>" +
																							"</td>" +
																							"<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
																								"<a href='https://www.asae.com.mx/contacto/atencion-a-clientes' style='color: #adadad;'>Contacto </a>" +
																							"</td>" +
																						"</tr>" +
																					"</table>" +
																				  "</td>" +
																			"</tr>" +
																		"</table>" +
																	"</td>" +
																"</tr>" +
																"<tr>" +
																	"<td align='center' valign='middle' class='hero bg_white' style=' background: #f1f1f1; position: relative; z-index: 0;'>" +
																	   "<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																			"<tr>" +
																				"<td valign='middle' width='50%'>" +
																				  "<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																					"<tr>" +
																					  "<td>" +
																						"<img src='https://www.asae.com.mx/01/JobCTRL/bg_1.jpg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
																					  "</td>" +
																					"</tr>" +
																				  "</table>" +
																			"</td>" +
																			"<td valign='middle' width='50%' style='background: #f1f1f1;'>" +
																			  "<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																				"<tr>" +
																				  "<td class='text' style='text-align: left; padding: 20px 30px;'>" +
																						"<h2 style='color: #0aaa42; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.4; text-align: center;'>Gracias por registrarte.</h2>" +
																						"<p style='font-size: 14px; line-height: 2; color: #6b6b6b; text-align: center;'> Por favor confirma tu participación, da un clic en el botón para <strong>confirmar tu asistencia</strong>.</p>" +
																						"<p><a href='https://www.asae.com.mx/conferencia-web/registro-de-asistencia/confirmacion?dt=" + token + "' style='border-radius: 5px;background: #0aaa42; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;' >Confirmar asistencia </a></p>" +
																				  "</td>" +
																				"</tr>" +
																			  "</table>" +
																			"</td>" +
																			"</tr>" +
																		"</table>" +
																	"</td>" +
																"</tr>" +
																"<tr>" +
																	"<td align='center' style=''>" +
																		"<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
																			"<tr>" +
																				"<td align='center' style='padding: 1em 4em;'>" +
																					"<h2 style='color: #0aaa42; font-size: 28px; margin-top: 0; line-height: 3; font-weight: 400;'>Información registrada.</h2>" +
																					"<p style='font-size: 14px; line-height: 1.8; color: #a5a5a5;'> Te agradecemos que nos hayas contactado, confirma tu cita y te mostraremos algunas recomendaciones para la conferencia web. Si requieres más información, <br> llama al <strong> 55 4644 4239 </strong> o al tel. <strong> 55 5322 0500 </strong></p>" +
																				"</td>" +
																			"</tr>" +
																			"<tr>" +
																				"<td>" +
																					"<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
																						"<tr>" +
																						  "<td valign='top' width='100%' style='padding-top: 20px;  padding: 5px 15px; ' class='services'>" +
																							"<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																							  "<tr>" +
																								"<td class='icon' colspan='2' style='margin-top: 0; font-size: 13px; text-align: center;'>" +
																								  "<img src='https://www.asae.com.mx/01/001-diet.png' alt='' style='width: 50px; max-width: 600px; height: auto; margin: auto; display: block;'>" +
																								  "<br>" +
																								"</td>" +
																							  "</tr>" +
																							  "<tr>" +
																								"<td style='margin-top: 0; font-size: 13px; text-align: center; background-color: #dcdcdc'>" +
																									"<p>Nombre </p>" +
																								"</td>" +
																								 "<td style='margin-top: 0; font-size: 13px; text-align: center; color: #0aaa42; background-color: #d2d2d2'>" +
																									"<p>" + usuario.Nombre + " " + usuario.ApellidoPaterno + " " + usuario.ApellidoMaterno + "</p>" +
																								"</td>" +
																							  "</tr>" +
																							  "<tr>" +
																								"<td style='margin-top: 0; font-size: 13px; text-align: center; background-color: #dcdcdc'>" +
																									"<p>Empresa </p>" +
																								"</td>" +
																								 "<td style='margin-top: 0; font-size: 13px; text-align: center; color: #9E9E9E; background-color: #f3f3f3'>" +
																									"<p>" + usuario.NombreEmpresa + "</p>" +
																								"</td>" +
																							  "</tr>" +
																							  "<tr>" +
																								"<td style='margin-top: 0; font-size: 13px; text-align: center; background-color: #dcdcdc'>" +
																									"<p>Correo Empresa  </p>" +
																								"</td>" +
																								"<td style='margin-top: 0; font-size: 13px; text-align: center; color: #9E9E9E; background-color: #f3f3f3'>" +
																									"<p>" + usuario.CorreoEmpresa + "</p>" +
																								"</td>" +
																							  "</tr>" +
																								"<tr>" +
																									"<td style='margin-top: 0; font-size: 13px; text-align: center; background-color: #dcdcdc'>" +
																										"<p>Correo personal  </p>" +
																									"</td>" +
																									"<td style='margin-top: 0; font-size: 13px; text-align: center; color: #0aaa42; background-color: #d2d2d2'>" +
																										"<p>" + usuario.CorreoPersonal + "</p>" +
																									"</td>" +
																								"</tr>" +
																								"<tr>" +
																									"<td style='margin-top: 0; font-size: 13px; text-align: center; background-color: #dcdcdc'>" +
																										"<p>Teléfono móvil </p>" +
																									"</td>" +
																									"<td style='margin-top: 0; font-size: 13px; text-align: center; color: #9E9E9E; background-color: #f3f3f3'>" +
																										"<p>" + usuario.TelefonoMovil + "</p>" +
																									"</td>" +
																								"</tr>" +
																								"<tr>" +
																									"<td style='margin-top: 0; font-size: 13px; text-align: center; background-color: #dcdcdc'>" +
																										"<p>Teléfono local </p> " +
																									"</td>" +
																									"<td style='margin-top: 0; font-size: 13px; text-align: center; color: #9E9E9E; background-color: #f3f3f3'>" +
																										"<p>" + usuario.TelefonoLocal + "</p>" +
																									"</td>" +
																								"</tr>" +
																								"<tr>" +
																									"<td style='margin-top: 0; font-size: 13px; text-align: center; background-color: #dcdcdc'>" +
																										"<p>Credenciales de acceso </p>" +
																									"</td>" +
																									"<td style='margin-top: 0; font-size: 13px; text-align: center; color: #0aaa42; background-color: #d2d2d2'>" +
																										"<p>ID de reunión: " + usuario.Clave + "</p>" +
																										"<p>" + usuario.Password + "</p>" +
																									"</td>" +
																								"</tr>" +
																								"<tr>" +
																									"<td style='margin-top: 0; font-size: 13px; text-align: center; background-color: #dcdcdc'>" +
																										"<p>Información adicional  </p>" +
																									"</td>" +
																									"<td style='margin-top: 0; font-size: 13px; text-align: center; color: #0aaa42; background-color: #d2d2d2'>" +
																										"<p> " + usuario.Descripcion + "</p>" +
																									"</td>" +
																								"</tr>" +
																							"</table>" +
																						  "</td>" +
																						"</tr>" +
																					"</table>" +
																				"</td>" +
																			"<tr>" +
																		"</table>" +
																	"</td>" +
																"</tr>" +
																"<tr>" +
																	"<td  style=' background: #f1f1f1;    padding: 2.5em;'>" +
																		"<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
																			"<tr>" +
																				"<td valign='middle' width='50%'>" +
																					"<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																						"<tr>" +
																							"<td>" +
																								"<img src='https://www.asae.com.mx/01/about.jpg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
																							"</td>" +
																						"</tr>" +
																					"</table>" +
																				"</td>" +
																				"<td valign='middle' width='50%'>" +
																					"<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																						"<tr>" +
																							"<td class='text-services' style='text-align: left; padding-left:25px;'>" +
																								"<div class='heading-section'>" +
																									"<h2 style='color: #0aaa42; font-size: 28px; margin-top: 0; line-height: 1.4; font-weight: 400; text-align: center;'>ACERCA DE NOSOTROS</h2>" +
																									"<p style='font-size: 14px; line-height: 1.8; color: #a5a5a5;'>Nos hemos consolidado como una organización integradora de tecnología, abarcando productos y servicios ...</p>" +
																									"<p><a href='https://www.asae.com.mx/' style='border-radius: 5px;background: #0aaa42; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
																								"</div>" +
																							"</td>" +
																						"</tr>" +
																					"</table>" +
																				"</td>" +
																			"</tr>" +
																		"</table>" +
																	"</td>" +
																"</tr>" +
																"<tr>" +
																	"<td>" +
																		"<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
																			"<tr>" +
																				"<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #F44336;'>" +
																					"<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																						"<tr>" +
																							"<td class='counter-text'>" +
																								"<span class='num'></span>" +
																							"</td>" +
																						"</tr>" +
																					"</table>" +
																				"</td>" +
																				"<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #0aaa42;'>" +
																					"<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																						"<tr>" +
																							"<td class='counter-text'>" +
																								"<span class='num'></span>" +
																							"</td>" +
																						"</tr>" +
																					"</table>" +
																				"</td>" +
																				"<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #FF9800;'>" +
																					"<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																						"<tr>" +
																							"<td class='counter-text'>" +
																								"<span class='num'></span>" +
																							"</td>" +
																						"</tr>" +
																					"</table>" +
																				"</td>" +
																			"</tr>" +
																		"</table>" +
																	"</td>" +
																"</tr>" +
																"<tr>" +
																	"<td>" +
																		"<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
																			"<tr>" +
																				"<td align='center' style='padding: 1em 4em;'>" +
																					"<br><br>" +
																					"<h2 style='color: #000000; font-size: 28px; margin-top: 0; font-weight: 400;'>LAS MEJORES HERRAMIENTAS EN LA ADMINISTRACIÓN Y CONTROL DE PROYECTOS</h2>" +
																					"<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'>INCREMENTA EL 30 PORCIENTO DE PRODUCTIVIDAD, CON HERRAMIENTAS QUE ANALIZAN Y MIDEN EL TIEMPO DE TRABAJO DE TU PERSONAL.</p>" +
																				"</td>" +
																			"</tr>" +
																		"</table>" +
																	"</td>" +
																"<tr>" +
																"<tr>" +
																	"<td style='padding: 2.5em;'>" +
																		"<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
																			"<tr>" +
																				"<td valign='top' width='50%' style='padding-top: 20px;'>" +
																					"<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
																						"<tr>" +
																							"<td>" +
																								"<img src='https://www.asae.com.mx/01/blog-1.jpg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
																							"</td>" +
																						"</tr>" +
																						"<tr>" +
																							"<td class='text-services' style='text-align: left;'>" +
																								"<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400;'>JobCTRL </h3>" +
																								"<p style='text-transform: uppercase; font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Software para documentar analizar mejorar el tiempo de trabajo.</span></p>" +
																								"<p style='color: #b9b9b9; line-height: 1.8;'>Beneficios en todos los niveles de la organización.</p>" +
																								"<p><a href='https://www.asae.com.mx/soluciones/software-para-documentar-analizar-mejorar-el-tiempo-de-trabajo' style='border-radius: 5px;background: #00afc5; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
																							"</td>" +
																						"</tr>" +
																					"</table>" +
																				"</td>" +
								"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
								"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
								"														<tr>" +
								"															<td>" +
								"																<img src='https://www.asae.com.mx/01/huawei.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
								"															</td>" +
								"														</tr>" +
								"														<tr>" +
								"															<td class='text-services' style='text-align: left;'>" +
								"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>Huawei-Ideahub</h3>" +
								"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>El nuevo estilo de oficina inteligente. </span></p>		" +
								"																<p><a href='https://www.asae.com.mx/huawei-ideahub' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
								"															</td>" +
								"														</tr>" +
								"													</table>" +
								"												</td>" +
																			"</tr>" +
																		"</table>" +
																	"</td>" +
																"</tr>" +
																"<tr>" +
																	"<td style='padding: 2.5em; background: #000000; color: #9E9E9E'>" +
																		"<table align='center' role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
																				"<tr>" +
																					"<td valign='middle' class='bg_black footer email-section'>" +
																						"<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
																							"<tr>" +
																								"<td width='100%' style='text-align: center;'>" +
																									"<p style='font-size: 22px; margin-top: 0;'>Dirección: Margaritas 426, Álvaro Obregón, Ciudad de México</p>" +
																								"</td>" +
																							"</tr>" +
																							"<tr>" +
																								"<td width='100%' style='text-align: center;'>" +
																									"<p style='margin-top: 0; font-size: 14px; '>¿Quieres recibir más correos electrónicos con nuestras nuevas herramientas y promociones? Usted puede <a href='https://www.asae.com.mx/contacto/atencion-a-clientes' style='font-size: 14px; color: #00afc5;'>contactarnos aquí</a></p>" +
																								"</td>" +
																							"</tr>" +
																							"<tr>" +
																								"<td width='100%' style='text-align: center;'>" +
																									"<table>" +
																										"<tr>" +
																											"<td>" +
																												"<img src='https://www.asae.com.mx/01/004-twitter-logo.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
																											"</td>" +
																											"<td>" +
																												"<img src='https://www.asae.com.mx/01/005-facebook.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
																											"</td>" +
																											"<td>" +
																												"<img src='https://www.asae.com.mx/01/006-instagram-logo.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
																											"</td>" +
																										"</tr>" +
																									"</table>" +

																								"</td>" +
																							"</tr>" +
																					"</table>" +
																					"</td>" +
																				"</tr>" +
																			  "</table>" +
																	"</td>" +
																"</tr>" +
															"</table>" +
														"</td>" +
													"</tr>" +
													"<tr>" +
														"<td height='25' style='font-size: 25px; line-height: 25px;'>&nbsp;</td>" +
													"</tr>" +
												"</table>" +
											"</td>" +
										"</tr>" +
									"</table>" +
									"<!-- end header -->" +
									"</body>" +
								"</html>" +

					   "";
			return body;
		}

		/***********************************************************************************************************/
		public Models.Mensaje AsaeWebUsuarioAgregarXpinnit(Models.Usuario usuario)
		{
			Models.Mensaje mensaje = new Models.Mensaje();

			mensaje = validar(usuario);

			if (mensaje.Respuesta == 1)
			{
				mensaje = dtUser.AsaeWebUsuarioAgregar(usuario);
				WSCorreo.CorreoSoapClient correo1 = new WSCorreo.CorreoSoapClient();

				// MANDAR CORREO 
				if (mensaje.Respuesta == 1)
				{
					Models.Usuario usuario1 = dtUser.AsaeWebUsuario_consulta_Token(mensaje.Token);
					if (correo1.CorreoMetPrivado("mail.asae.com.mx", 25, "soporte-aplicaciones@asae.com.mx", "$%65hgy#19_", mensaje.Email, "Asae consultores S.A. de C.V.", "Confirmación de conferencia web", NewUserHTMLXpinnit(usuario1, mensaje.Token)) == "Correo enviado")
					{
						mensaje.RespuestaText = "Se ha enviado un correo electrónico a " + mensaje.Email + " para confirmar tu participación, además de información sobre el evento.";
					}
				}
			}
			return mensaje;
		}
		public Models.Mensaje AsaeWebUsuarioBuscarXpinnit(Models.Usuario usuario)
		{
			Models.Mensaje mensaje = new Models.Mensaje();
			mensaje = dtUser.AsaeWebUsuarioBuscar(usuario);
			WSCorreo.CorreoSoapClient correo1 = new WSCorreo.CorreoSoapClient();
			// MANDAR CORREO 
			if (mensaje.Token.Length > 5)
			{
				Models.Usuario usuario1 = dtUser.AsaeWebUsuario_consulta_Token(mensaje.Token);
				if (correo1.CorreoMetPrivado("mail.asae.com.mx", 25, "soporte-aplicaciones@asae.com.mx", "$%65hgy#19_", mensaje.Email, "Asae consultores S.A. de C.V.", "Confirmación de conferencia web", NewUserHTMLXpinnit(usuario1, mensaje.Token)) == "Correo enviado")
				{
					mensaje.Respuesta = 1;
					mensaje.RespuestaText = "Se ha enviado un correo electrónico a " + mensaje.Email + " para confirmar tu participación, además de información sobre el evento.";
				}
			}
			else
			{
				mensaje.Respuesta = 0;
			}

			return mensaje;
		}
		private string NewUserHTMLXpinnit(Models.Usuario usuario, string token)
		{
			string body = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
								"<html xmlns:v='urn:schemas-microsoft-com:vml'>" +
								"<head>" +
									"<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />" +
									"<meta name='viewport' content='width=device-width; initial-scale=1.0; maximum-scale=1.0;' />" +
									
									"<link href='https://fonts.googleapis.com/css?family=Nunito+Sans:200,300,400,600,700' rel='stylesheet'>" +
									"<!--<![endif]-->" +
									"<title>Asae Consultores S.A de C.V</title>" +
									"<style type='text/css'>" +
										"body {" +
											"width: 100%;" +
											"background-color: #ffffff;" +
											"margin: 0;" +
											"padding: 0;" +
											"-webkit-font-smoothing: antialiased;" +
											"mso-margin-top-alt: 0px;" +
											"mso-margin-bottom-alt: 0px;" +
											"mso-padding-alt: 0px 0px 0px 0px;" +
											"font-family: 'Proxima Nova',-apple-system,'Helvetica Neue',Helvetica,Roboto,Arial,sans-serif;" +
										"}" +
										"* {" +
											"-ms-text-size-adjust: 100%;" +
											"-webkit-text-size-adjust: 100%;" +
										"}" +
										"div[style*='margin: 16px 0'] {" +
											"margin: 0 !important;" +
										"}" +

										"table," +
										"td {" +
											"mso-table-lspace: 0pt !important;" +
											"mso-table-rspace: 0pt !important;" +
										"}" +

										"table {" +
											"border-spacing: 0 !important;" +
											"border-collapse: collapse !important;" +
											"table-layout: fixed !important;" +
											"margin: 0 auto !important;" +
										"}" +

										"img {" +
											"-ms-interpolation-mode:bicubic;" +
										"}" +
										"a {" +
											"text-decoration: none;" +
										"}" +
										"h1, h2, h3, h4, h5, h6 {" +
											"font-family: 'Nunito Sans', sans-serif;" +
											"color: #000000;" +
											"margin-top: 0;" +
										"}" +

										".logo h1{" +
											"margin: 0;" +
										"}" +
										".logo h1 a{" +
											"color: #3b3a38;" +
											"font-size: 20px;" +
											"font-weight: 700;" +
											"font-family: 'Nunito Sans', sans-serif;" +
										"}" +
									"</style>" +
								"</head>" +
									"<body class='respond' leftmargin='0' topmargin='0' marginwidth='0' marginheight='0'>" +
									"<!-- header -->" +
									"<table border='0' width='100%' cellpadding='0' cellspacing='0' bgcolor='ffffff'>" +
										"<tr>" +
											"<td align='center' style='background-color: #f1f1f1;'>" +
												"<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' class='container590'>" +
													"<tr>" +
														"<td align='center'>" +
															"<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff;'>" +
																"<tr>" +
																	"<td align='center' style='padding: 1em 2.5em;'>" +
																		"<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
																			"<tr>" +
																				"<td width='45%' class='logo' style='text-align: left; padding: 20px'>" +
																					"<h1><a href='https://www.asae.com.mx/'>Asae Consultores</a></h1>" +
																				  "</td>" +
																				  "<td width='55%' class='logo' style='text-align: right;'>" +
																					"<table width='100%' border='0' cellpadding='0' cellspacing='0' style='border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;' class='container590 hide'>" +
																						"<tr>" +
																							"<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500; '>" +
																								"<a href='https://www.asae.com.mx/' style='color: #adadad;'>Inicio </a>" +
																							"</td>" +
																							"<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
																								"<a href='#' style='color: #adadad;'>Experiencia </a>" +
																							"</td>" +
																							"<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
																								"<a href='https://www.asae.com.mx/#feature' style='color: #adadad;'>Servicios </a>" +
																							"</td>" +
																							"<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
																								"<a href='https://www.asae.com.mx/contacto/atencion-a-clientes' style='color: #adadad;'>Contacto </a>" +
																							"</td>" +
																						"</tr>" +
																					"</table>" +
																				  "</td>" +
																			"</tr>" +
																		"</table>" +
																	"</td>" +
																"</tr>" +
																"<tr>" +
																	"<td align='center' valign='middle' class='hero bg_white' style=' background: #f1f1f1; position: relative; z-index: 0;'>" +
																	   "<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																			"<tr>" +
																				"<td valign='middle' width='50%'>" +
																				  "<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																					"<tr>" +
																					  "<td>" +
																						"<img src='https://www.asae.com.mx/01/Xpinnit/bg_1.jpg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
																					  "</td>" +
																					"</tr>" +
																				  "</table>" +
																			"</td>" +
																			"<td valign='middle' width='50%' style='background: #f1f1f1;'>" +
																			  "<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																				"<tr>" +
																				  "<td class='text' style='text-align: left; padding: 20px 30px;'>" +
																						"<h2 style='color: #0aaa42; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.4; text-align: center;'>Gracias por registrarte.</h2>" +
																						"<p style='font-size: 14px; line-height: 2; color: #6b6b6b; text-align: center;'> Por favor confirma tu participación, da un clic en el botón para <strong>confirmar tu asistencia</strong>.</p>" +
																						"<p><a href='https://www.asae.com.mx/conferencia-web/registro-de-asistencia/Confirmacion-xpinnit?dt=" + token + "' style='border-radius: 5px;background: #0aaa42; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;' >Confirmar asistencia </a></p>" +
																				  "</td>" +
																				"</tr>" +
																			  "</table>" +
																			"</td>" +
																			"</tr>" +
																		"</table>" +
																	"</td>" +
																"</tr>" +
																"<tr>" +
																	"<td align='center' style=''>" +
																		"<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
																			"<tr>" +
																				"<td align='center' style='padding: 1em 4em;'>" +
																					"<h2 style='color: #0aaa42; font-size: 28px; margin-top: 0; line-height: 3; font-weight: 400;'>Información registrada.</h2>" +
																					"<p style='font-size: 14px; line-height: 1.8; color: #a5a5a5;'> Te agradecemos que nos hayas contactado, confirma tu cita y te mostraremos algunas recomendaciones para la conferencia web. Si requieres más información, <br> llama al  tel. <strong> 55 5322 0500 </strong></p>" +
																				"</td>" +
																			"</tr>" +
																			"<tr>" +
																				"<td>" +
																					"<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
																						"<tr>" +
																						  "<td valign='top' width='100%' style='padding-top: 20px;  padding: 5px 15px; ' class='services'>" +
																							"<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																							  "<tr>" +
																								"<td class='icon' colspan='2' style='margin-top: 0; font-size: 13px; text-align: center;'>" +
																								  "<img src='https://www.asae.com.mx/01/001-diet.png' alt='' style='width: 50px; max-width: 600px; height: auto; margin: auto; display: block;'>" +
																								  "<br>" +
																								"</td>" +
																							  "</tr>" +
																							  "<tr>" +
																								"<td style='margin-top: 0; font-size: 13px; text-align: center; background-color: #dcdcdc'>" +
																									"<p>Nombre </p>" +
																								"</td>" +
																								 "<td style='margin-top: 0; font-size: 13px; text-align: center; color: #0aaa42; background-color: #d2d2d2'>" +
																									"<p>" + usuario.Nombre + " " + usuario.ApellidoPaterno + " " + usuario.ApellidoMaterno + "</p>" +
																								"</td>" +
																							  "</tr>" +
																							  "<tr>" +
																								"<td style='margin-top: 0; font-size: 13px; text-align: center; background-color: #dcdcdc'>" +
																									"<p>Empresa </p>" +
																								"</td>" +
																								 "<td style='margin-top: 0; font-size: 13px; text-align: center; color: #9E9E9E; background-color: #f3f3f3'>" +
																									"<p>" + usuario.NombreEmpresa + "</p>" +
																								"</td>" +
																							  "</tr>" +
																							  "<tr>" +
																								"<td style='margin-top: 0; font-size: 13px; text-align: center; background-color: #dcdcdc'>" +
																									"<p>Correo Empresa  </p>" +
																								"</td>" +
																								"<td style='margin-top: 0; font-size: 13px; text-align: center; color: #9E9E9E; background-color: #f3f3f3'>" +
																									"<p>" + usuario.CorreoEmpresa + "</p>" +
																								"</td>" +
																							  "</tr>" +
																								"<tr>" +
																									"<td style='margin-top: 0; font-size: 13px; text-align: center; background-color: #dcdcdc'>" +
																										"<p>Correo personal  </p>" +
																									"</td>" +
																									"<td style='margin-top: 0; font-size: 13px; text-align: center; color: #0aaa42; background-color: #d2d2d2'>" +
																										"<p>" + usuario.CorreoPersonal + "</p>" +
																									"</td>" +
																								"</tr>" +
																								"<tr>" +
																									"<td style='margin-top: 0; font-size: 13px; text-align: center; background-color: #dcdcdc'>" +
																										"<p>Teléfono móvil </p>" +
																									"</td>" +
																									"<td style='margin-top: 0; font-size: 13px; text-align: center; color: #9E9E9E; background-color: #f3f3f3'>" +
																										"<p>" + usuario.TelefonoMovil + "</p>" +
																									"</td>" +
																								"</tr>" +
																								"<tr>" +
																									"<td style='margin-top: 0; font-size: 13px; text-align: center; background-color: #dcdcdc'>" +
																										"<p>Teléfono local </p> " +
																									"</td>" +
																									"<td style='margin-top: 0; font-size: 13px; text-align: center; color: #9E9E9E; background-color: #f3f3f3'>" +
																										"<p>" + usuario.TelefonoLocal + "</p>" +
																									"</td>" +
																								"</tr>" +
																								"<tr>" +
																									"<td style='margin-top: 0; font-size: 13px; text-align: center; background-color: #dcdcdc'>" +
																										"<p>Credenciales de acceso </p>" +
																									"</td>" +
																									"<td style='margin-top: 0; font-size: 13px; text-align: center; color: #0aaa42; background-color: #d2d2d2'>" +
																										"<p>ID de reunión: " + usuario.Clave + "</p>" +
																										"<p>" + usuario.Password + "</p>" +
																									"</td>" +
																								"</tr>" +
																								"<tr>" +
																									"<td style='margin-top: 0; font-size: 13px; text-align: center; background-color: #dcdcdc'>" +
																										"<p>Información adicional  </p>" +
																									"</td>" +
																									"<td style='margin-top: 0; font-size: 13px; text-align: center; color: #0aaa42; background-color: #d2d2d2'>" +
																										"<p> " + usuario.Descripcion + "</p>" +
																									"</td>" +
																								"</tr>" +
																							"</table>" +
																						  "</td>" +
																						"</tr>" +
																					"</table>" +
																				"</td>" +
																			"<tr>" +
																		"</table>" +
																	"</td>" +
																"</tr>" +
																"<tr>" +
																	"<td  style=' background: #f1f1f1;    padding: 2.5em;'>" +
																		"<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
																			"<tr>" +
																				"<td valign='middle' width='50%'>" +
																					"<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																						"<tr>" +
																							"<td>" +
																								"<img src='https://www.asae.com.mx/01/about.jpg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
																							"</td>" +
																						"</tr>" +
																					"</table>" +
																				"</td>" +
																				"<td valign='middle' width='50%'>" +
																					"<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																						"<tr>" +
																							"<td class='text-services' style='text-align: left; padding-left:25px;'>" +
																								"<div class='heading-section'>" +
																									"<h2 style='color: #0aaa42; font-size: 28px; margin-top: 0; line-height: 1.4; font-weight: 400; text-align: center;'>ACERCA DE NOSOTROS</h2>" +
																									"<p style='font-size: 14px; line-height: 1.8; color: #a5a5a5;'>Nos hemos consolidado como una organización integradora de tecnología, abarcando productos y servicios ...</p>" +
																									"<p><a href='https://www.asae.com.mx/' style='border-radius: 5px;background: #0aaa42; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
																								"</div>" +
																							"</td>" +
																						"</tr>" +
																					"</table>" +
																				"</td>" +
																			"</tr>" +
																		"</table>" +
																	"</td>" +
																"</tr>" +
																"<tr>" +
																	"<td>" +
																		"<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
																			"<tr>" +
																				"<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #019033;'>" +
																					"<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																						"<tr>" +
																							"<td class='counter-text'>" +
																								"<span class='num'></span>" +
																							"</td>" +
																						"</tr>" +
																					"</table>" +
																				"</td>" +
																				"<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #0aaa42;'>" +
																					"<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																						"<tr>" +
																							"<td class='counter-text'>" +
																								"<span class='num'></span>" +
																							"</td>" +
																						"</tr>" +
																					"</table>" +
																				"</td>" +
																				"<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #7bbf1d;'>" +
																					"<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																						"<tr>" +
																							"<td class='counter-text'>" +
																								"<span class='num'></span>" +
																							"</td>" +
																						"</tr>" +
																					"</table>" +
																				"</td>" +
																			"</tr>" +
																		"</table>" +
																	"</td>" +
																"</tr>" +
																"<tr>" +
																	"<td>" +
																		"<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
																			"<tr>" +
																				"<td align='center' style='padding: 1em 4em;'>" +
																					"<br><br>" +
																					"<h2 style='color: #000000; font-size: 28px; margin-top: 0; font-weight: 400;'>LAS MEJORES HERRAMIENTAS EN LA ADMINISTRACIÓN Y CONTROL DE PROYECTOS</h2>" +
																					"<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'>INCREMENTA EL 30 PORCIENTO DE PRODUCTIVIDAD, CON HERRAMIENTAS QUE ANALIZAN Y MIDEN EL TIEMPO DE TRABAJO DE TU PERSONAL.</p>" +
																				"</td>" +
																			"</tr>" +
																		"</table>" +
																	"</td>" +
																"<tr>" +
																"<tr>" +
																	"<td style='padding: 2.5em;'>" +
																		"<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
																			"<tr>" +
																				"<td valign='top' width='50%' style='padding-top: 20px;'>" +
																					"<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
																						"<tr>" +
																							"<td>" +
																								"<img src='https://www.asae.com.mx/01/blog-1.jpg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
																							"</td>" +
																						"</tr>" +
																						"<tr>" +
																							"<td class='text-services' style='text-align: left;'>" +
																								"<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400;'>JobCTRL </h3>" +
																								"<p style='text-transform: uppercase; font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Software para documentar analizar mejorar el tiempo de trabajo.</span></p>" +
																								"<p style='color: #b9b9b9; line-height: 1.8;'>Beneficios en todos los niveles de la organización.</p>" +
																								"<p><a href='https://www.asae.com.mx/soluciones/software-para-documentar-analizar-mejorar-el-tiempo-de-trabajo' style='border-radius: 5px;background: #00afc5; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
																							"</td>" +
																						"</tr>" +
																					"</table>" +
																				"</td>" +
																				"<td valign='top' width='50%' style='padding-top: 20px;'>" +
																					"<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
																						"<tr>" +
																							"<td>" +
																								"<img src='https://www.asae.com.mx/01/blog-2.jpg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
																							"</td>" +
																						"</tr>" +
																						"<tr>" +
																							"<td class='text-services' style='text-align: left;'>" +
																								"<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>Xpinnit</h3>" +
																								"<p style='text-transform: uppercase; font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Software de gestión de proyectos </span></p>" +
																								"<p style='color: #b9b9b9; line-height: 1.8;'>Programa tus tareas con la temporalidad que necesites.</p>" +
																								"<p><a href='https://www.asae.com.mx/soluciones/software-de-gestion-de-proyectos-xpinnit' style='border-radius: 5px;background: #00afc5; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
																							"</td>" +
																						"</tr>" +
																					"</table>" +
																				"</td>" +
																			"</tr>" +
																		"</table>" +
																	"</td>" +
																"</tr>" +
																"<tr>" +
																	"<td style='padding: 2.5em; background: #000000; color: #9E9E9E'>" +
																		"<table align='center' role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
																				"<tr>" +
																					"<td valign='middle' class='bg_black footer email-section'>" +
																						"<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
																							"<tr>" +
																								"<td width='100%' style='text-align: center;'>" +
																									"<p style='font-size: 22px; margin-top: 0;'>Dirección: Margaritas 426, Álvaro Obregón, Ciudad de México</p>" +
																								"</td>" +
																							"</tr>" +
																							"<tr>" +
																								"<td width='100%' style='text-align: center;'>" +
																									"<p style='margin-top: 0; font-size: 14px; '>¿Quieres recibir más correos electrónicos con nuestras nuevas herramientas y promociones? Usted puede <a href='https://www.asae.com.mx/contacto/atencion-a-clientes' style='font-size: 14px; color: #00afc5;'>contactarnos aquí</a></p>" +
																								"</td>" +
																							"</tr>" +
																							"<tr>" +
																								"<td width='100%' style='text-align: center;'>" +
																									"<table>" +
																										"<tr>" +
																											"<td>" +
																												"<img src='https://www.asae.com.mx/01/004-twitter-logo.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
																											"</td>" +
																											"<td>" +
																												"<img src='https://www.asae.com.mx/01/005-facebook.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
																											"</td>" +
																											"<td>" +
																												"<img src='https://www.asae.com.mx/01/006-instagram-logo.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
																											"</td>" +
																										"</tr>" +
																									"</table>" +

																								"</td>" +
																							"</tr>" +
																					"</table>" +
																					"</td>" +
																				"</tr>" +
																			  "</table>" +
																	"</td>" +
																"</tr>" +
															"</table>" +
														"</td>" +
													"</tr>" +
													"<tr>" +
														"<td height='25' style='font-size: 25px; line-height: 25px;'>&nbsp;</td>" +
													"</tr>" +
												"</table>" +
											"</td>" +
										"</tr>" +
									"</table>" +
									"<!-- end header -->" +
									"</body>" +
								"</html>" +

					   "";
			return body;
		}


		/***********************************************************************************************************/
		private Models.Mensaje validar(Models.Usuario usuario)
		{
			Models.Mensaje mensaje = new Models.Mensaje();
			mensaje.Respuesta = 0;

			if (texto(usuario.Nombre))
			{
				if (texto(usuario.ApellidoPaterno))
				{
					//if (texto(usuario.ApellidoMaterno))
					//{
						if (telefono(usuario.TelefonoMovil))
						{
							mensaje.Respuesta = 1;
						}
						else
						{
							mensaje.RespuestaText = "Número telefónico incorrecto ";
						}
					//}
					//else
					//{
					//	mensaje.RespuestaText = "El texto colocado en tu apellido materno es demasiado pequeño";
					//}
				}
				else
				{
					mensaje.RespuestaText = "El texto colocado en tu apellido paterno es demasiado pequeño";
				}
			}
			else
			{
				mensaje.RespuestaText = "El texto colocado en nombre es demasiado pequeño";
			}
			return mensaje;
		}
		private bool texto(string texto)
		{
			bool respuesta = false;
			if (texto.Length <= 2)
			{
				respuesta = false;
			}
			else
			{
				respuesta = true;
			}
			return respuesta;
		}
		private bool telefono(string telefono)
		{
			bool respuesta = false;
			if (telefono.Length <= 7 || telefono.Length > 13)
			{
				respuesta = false;
			}
			else
			{
				respuesta = true;
			}
			return respuesta;
		}




		/************************************************************************************************************/
		/************************************************************************************************************/

		public Models.Mensaje AsaeWebSolicitudDemoASD(Models.Usuario usuario)
		{
			Models.Mensaje mensaje = new Models.Mensaje();
			mensaje = ValidarSolicitud(usuario);

			if (mensaje.Respuesta == 1)
			{
				Models.Email email = new Models.Email();
				email.nombre = usuario.Nombre;
				email.email = usuario.CorreoPersonal;
				email.asunto = "Solicitud de demo gratis - ASD";
				email.mensaje = "";
				email.telefono = usuario.TelefonoMovil;
				email.telefonolocal = usuario.TelefonoLocal;
				email.App = 2;

				mensaje = dtUser.AsaeWebSolicitudesApp(email);

				if (mensaje.Respuesta == 1)
				{
					mensaje.RespuestaText = NuevaSolicitudDemoASD(usuario);
				}
			}
			return mensaje;
		}

		public string NuevaSolicitudDemoASD(Models.Usuario Musuario)
		{
			string respuesta = "";

			string host = "mail.asae.com.mx";
			int puerto = 25;
			string usuario = "asae_contactanos@asae.com.mx";
			string contra = "A$ae2018$$_";
			string pCorreo = Musuario.CorreoPersonal.ToString().Trim();

			MailMessage correo = new MailMessage();
			correo.To.Add(new MailAddress(pCorreo));
			correo.CC.Add("magdalena.ornelas@asae.com.mx");
			correo.From = new MailAddress(usuario, "ASAE CONSULTORES, S.A DE C.V");
			correo.Subject = "Solicitud de demo gratis - ASAE SERVICE DESK (ASD)";
			correo.Body = HTMLDemoASD();

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
				respuesta = "ok";
			}
			catch (Exception ex)
			{
				respuesta = "Error: " + ex.Message;
			}

			return respuesta;
		}

		public string HTMLDemoASD()
		{
			string HTML = "";
			HTML += " " +
			"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
			"<html xmlns:v='urn:schemas-microsoft-com:vml'>" +
			"<head>" +
				"<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />" +
				"<meta name='viewport' content='width=device-width; initial-scale=1.0; maximum-scale=1.0;' />" +
				
				"<link href='https://fonts.googleapis.com/css?family=Nunito+Sans:200,300,400,600,700' rel='stylesheet'>" +
				"<!--<![endif]-->" +
				"<title>Asae Consultores S.A de C.V</title>" +
				"<style type='text/css'>" +
				"	body {" +
			"			width: 100%;" +
			"			background-color: #ffffff;" +
			"			margin: 0;" +
			"			padding: 0;" +
			"			-webkit-font-smoothing: antialiased;" +
			"			mso-margin-top-alt: 0px;" +
			"			mso-margin-bottom-alt: 0px;" +
			"			mso-padding-alt: 0px 0px 0px 0px;" +
			"			font-family: 'Nunito Sans', sans-serif;" +
			"		}" +
			"		* {" +
			"			-ms-text-size-adjust: 100%;" +
			"			-webkit-text-size-adjust: 100%;" +
			"		}" +
			"		div[style*='margin: 16px 0'] {" +
			"			margin: 0 !important;" +
			"		}" +

			"		table," +
			"		td {" +
			"			mso-table-lspace: 0pt !important;" +
			"			mso-table-rspace: 0pt !important;" +
			"		}" +

			"		table {" +
			"			border-spacing: 0 !important;" +
			"			border-collapse: collapse !important;" +
			"			table-layout: fixed !important;" +
			"			margin: 0 auto !important;" +
			"		}" +

			"		img {" +
			"			-ms-interpolation-mode:bicubic;" +
			"		}" +
			"		a {" +
			"			text-decoration: none;" +
			"		}" +
			"		h1, h2, h3, h4, h5, h6 {" +
			"			font-family: 'Nunito Sans', sans-serif;" +
			"			color: #000000;" +
			"			margin-top: 0;" +
			"		}" +

			"		.logo h1{" +
			"			margin: 0;" +
			"		}" +
			"		.logo h1 a{" +
			"			color: #797979;" +
			"			font-size: 20px;" +
			"			font-weight: 700;" +
			"			font-family: 'Nunito Sans', sans-serif;" +
			"		}" +

			"	</style>" +
			"</head>" +
			"	<body class='respond' leftmargin='0' topmargin='0' marginwidth='0' marginheight='0'>" +
			"	<!-- header -->" +
			"	<table border='0' width='100%' cellpadding='0' cellspacing='0' bgcolor='ffffff'>" +
			"		<tr>" +
			"			<td align='center' style='background-color: #f1f1f1;'>" +
			"				<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' class='container590'>" +
			"					<tr>" +
			"						<td align='center'>" +
			"							<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff;'>" +
			"								<tr>" +
			"									<td align='center' style='padding: 1em 2.5em;'>" +
			"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
			"											<tr>" +
			"												<td width='16%' class='logo' style='text-align: left; padding: 10px'>" +
			"													<h1><a style='color: #000; font-size: 10px; font-weight: 700; text-transform: uppercase;' href='https://www.asae.com.mx/'><img src='https://www.asae.com.mx/images/Tickets/LogoAsae.png' alt='' style='width: 100%; max-width: 500px; height: auto; margin: auto; display: block;'></a></h1>" +
			"												  </td>" +
			"												  <td width='55%' class='logo' style='text-align: right;'>" +
			"													<table width='100%' border='0' cellpadding='0' cellspacing='0' style='border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;' class='container590 hide'>" +
			"														<tr>" +
			"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500; '>" +
			"																<a href='https://www.asae.com.mx/' style='color: #adadad;'>Inicio </a>" +
			"															</td>" +
			"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
			"																<a href='https://www.asae.com.mx/asd' style='color: #adadad;'>ASD </a>" +
			"															</td>" +
			"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
			"																<a href='https://www.asae.com.mx/contacto/atencion-a-clientes' style='color: #adadad;'>Contacto </a>" +
			"															</td>" +
			"														</tr>" +
			"													</table>" +
			"												  </td>" +
			"											</tr>" +
			"										</table>" +
			"									</td>" +
			"								</tr>" +
			"								<tr>" +
			"									<td align='center' style=''>" +
			"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #fafafa; padding: 0.5em;'>" +
			"											<tr>" +
			"												<td align='center' style='padding: 0em 4em;'>" +
			"													<P style='font-size: 32px;color: #418bcc; font-size: 32px; '><strong>ASAE SERVICE DESK (ASD)</strong></P>" +
			"												</td>" +
			"											</tr>" +
			"											<tr>" +
			"												<td>" +
			"												</td>" +
			"											<tr>" +
			"										</table>" +
			"									</td>" +
			"								</tr>" +
			"								<tr>" +
			"									<td>" +
			"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
			"											<tr>" +
			"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #026fa0;'>" +
			"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
			"														<tr>" +
			"															<td class='counter-text'>" +
			"																<span class='num'></span>" +
			"															</td>" +
			"														</tr>" +
			"													</table>" +
			"												</td>" +
			"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #009baf;'>" +
			"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
			"														<tr>" +
			"															<td class='counter-text'>" +
			"																<span class='num'></span>" +
			"															</td>" +
			"														</tr>" +
			"													</table>" +
			"												</td>" +
			"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #00BCD4;'>" +
			"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
			"														<tr>" +
			"															<td class='counter-text'>" +
			"																<span class='num'></span>" +
			"															</td>" +
			"														</tr>" +
			"													</table>" +
			"												</td>" +
			"											</tr>" +
			"										</table>" +
			"									</td>" +
			"								</tr>" +
			"								<tr>" +
			"									<td align='center' style=''>" +
			"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 1.5em;'>" +
			"											<tr>" +
			"												<td align='center' style='padding: 1em 4em;'>" +
			"												</td>" +
			"											</tr>" +
			"											<tr>" +
			"												<td>" +
			"												</td>" +
			"											<tr>" +
			"										</table>" +
			"									</td>" +
			"								</tr>" +
			"								<tr>" +
			"									<td align='center' style=''>" +
			"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
			"											<tr>" +
			"												<td align='center' style='padding: 1em 4em;'>" +
			"													<p style='color: #03A9F4; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.3;'> " +
			"													Te agradecemos que nos hayas contactado, en breve un ejecutivo se comunicara contigo para atender tu solicitud y brindarte una demo totalmente gratis.</p>" +
			"													<br>" +
			"												</td>" +
			"											</tr>" +
			"											<tr>" +
			"												<td>" +
			"												</td>" +
			"											<tr>" +
			"										</table>" +
			"									</td>" +
			"								</tr>" +
			"								<tr>" +
			"									<td align='center' style=''>" +
			"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 1.5em;'>" +
			"											<tr>" +
			"												<td align='center' style='padding: 1em 4em;'>" +
			"												</td>" +
			"											</tr>" +
			"											<tr>" +
			"												<td>	" +
			"												</td>" +
			"											<tr>" +
			"										</table>" +
			"									</td>" +
			"								</tr>" +
			"								<tr>" +
			"									<td align='center' valign='middle' class='hero bg_white' style=' position: relative; z-index: 0;'>" +
			"									  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
			"											<tr>" +
			"												<td valign='middle' width='50%' >" +
			"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
			"													<tr>" +
			"													  <td class='text' style='text-align: left; padding: 20px 30px;'>" +
			"															<h2 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>¿Conoces en que estatus se encuentra cualquier incidente de soporte TI en tu organización?</h2>" +
			"															<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'> <strong>ASAE SERVICE DESK (ASD)</strong> ayuda a gerentes de TI a garantizar la continuidad de los servicios de TI dentro de la organización, llevando el control de cada incidente de soporte técnico en una sola plataforma.</p>" +
			"															<p><a href='https://www.asae.com.mx/asd' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
			"													  </td>" +
			"													</tr>" +
			"												  </table>" +
			"												</td>" +
			"												<td valign='middle' width='50%'>" +
			"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
			"													<tr>" +
			"													  <td>" +
			"														<img src='https://www.asae.com.mx/images/Tickets/Banner2.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
			"													  </td>" +
			"													</tr>" +
			"												  </table>" +
			"												</td>" +
			"											</tr>" +
			"										</table>" +
			"									</td>" +
			"								</tr>" +
			"								<tr>" +
			"									<td>" +
			"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
			"											<tr>" +
			"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #026fa0;'>" +
			"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
			"														<tr>" +
			"															<td class='counter-text'>" +
			"																<span class='num'></span>" +
			"															</td>" +
			"														</tr>" +
			"													</table>" +
			"												</td>" +
			"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #009baf;'>" +
			"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
			"														<tr>" +
			"															<td class='counter-text'>" +
			"																<span class='num'></span>" +
			"															</td>" +
			"														</tr>" +
			"													</table>" +
			"												</td>" +
			"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #00BCD4;'>" +
			"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
			"														<tr>" +
			"															<td class='counter-text'>" +
			"																<span class='num'></span>" +
			"															</td>" +
			"														</tr>" +
			"													</table>" +
			"												</td>" +
			"											</tr>" +
			"										</table>" +
			"									</td>" +
			"								</tr>" +
			"								<tr>" +
			"									<td>" +
			"										<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
			"											<tr>" +
			"												<td align='center' style='padding: 1em 4em;'>" +
			"													<br><br>" +
			"													<h2 style='color: #000000; font-size: 28px; margin-top: 0; font-weight: 400;'>LAS MEJORES HERRAMIENTAS EN LA ADMINISTRACIÓN Y CONTROL DE PROYECTOS</h2>" +
			"													<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'>Incrementa el 30 por ciento de productividad, con herramientas que analizan y miden el tiempo de trabajo de tu personal.</p>" +
			"												</td>" +
			"											</tr>" +
			"										</table>" +
			"									</td>" +
			"								<tr>" +
			"								<tr>" +
			"									<td style='padding: 1em;'>" +
			"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
			"											<tr>" +
			"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
			"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
			"														<tr>" +
			"															<td>" +
			"																<img src='https://www.asae.com.mx/01/blog-1.jpg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
			"															</td>" +
			"														</tr>" +
			"														<tr>" +
			"															<td class='text-services' style='text-align: left;'>" +
			"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400;'>JobCTRL </h3>" +
			"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Software para documentar analizar mejorar el tiempo de trabajo.</span></p>		" +
			"																<p><a href='https://www.asae.com.mx/jobctrl' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
			"															</td>" +
			"														</tr>" +
			"													</table>" +
			"												</td>" +
			"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
			"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
			"														<tr>" +
			"															<td>" +
			"																<img src='https://www.asae.com.mx/01/huawei.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
			"															</td>" +
			"														</tr>" +
			"														<tr>" +
			"															<td class='text-services' style='text-align: left;'>" +
			"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>Huawei-Ideahub</h3>" +
			"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>El nuevo estilo de oficina inteligente. </span></p>		" +
			"																<p><a href='https://www.asae.com.mx/huawei-ideahub' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
			"															</td>" +
			"														</tr>" +
			"													</table>" +
			"												</td>" +
			"											</tr>" +
			"										</table>" +
			"									</td>" +
			"								</tr>" +
			"								<tr>" +
			"									<td style='padding: 2.5em; background: #000000; color: #9E9E9E'>" +
			"										<table align='center' role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
			"												<tr>" +
			"													<td valign='middle' class='bg_black footer email-section'>" +
			"														<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
			"															<tr>" +
			"																<td width='100%' style='text-align: center;'>" +
			"																	<p style='font-size: 22px; margin-top: 0;'>Dirección: Margaritas 426, Álvaro Obregón, Ciudad de México</p>" +
			"																</td>" +
			"															</tr>" +
			"															<tr>" +
			"																<td width='100%' style='text-align: center;'>" +
			"																	<p style='margin-top: 0; font-size: 14px; '>¿Quieres recibir más correos electrónicos con nuestras nuevas herramientas y promociones? Usted puede <a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='font-size: 14px; color: #00afc5;'>Darse de alta aquí</a></p>" +
			"																</td>" +
			"															</tr>" +
			"															<tr>" +
			"																<td width='100%' style='text-align: center;'>" +
			"																	<table>" +
			"																		<tr>" +
			"																			<td>" +
			"																				<a href='https://twitter.com/asaeconsultores'>" +
			"																					<img src='https://www.asae.com.mx/01/004-twitter-logo.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
			"																				</a>" +
			"																			</td>" +
			"																			<td>" +
			"																				<a href='https://www.facebook.com/AsaeConsultoresMX/'>" +
			"																					<img src='https://www.asae.com.mx/01/005-facebook.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
			"																				</a>" +
			"																			</td>" +
			"																		</tr>" +
			"																	</table>" +
			"																</td>" +
			"															</tr>" +
			"													</table>" +
			"													</td>" +
			"												</tr>" +
			"											  </table>" +
			"									</td>" +
			"								</tr>" +
			"							</table>" +
			"						</td>" +
			"					</tr>" +
			"					<tr>" +
			"						<td height='25' style='font-size: 25px; line-height: 25px;'>&nbsp;</td>" +
			"					</tr>" +
			"				</table>" +
			"			</td>" +
			"		</tr>" +
			"	</table>" +
			"	<!-- end header -->" +
			"	</body>" +
			"</html>";


			return HTML;
		}


		/************************************************************************************************************/
		/************************************************************************************************************/

		public Models.Mensaje AsaeWebSolicitudDemoJOBCTRL(Models.Usuario usuario)
		{
			Models.Mensaje mensaje = new Models.Mensaje();
			mensaje = ValidarSolicitud(usuario);

			if (mensaje.Respuesta == 1)
			{
				Models.Email email = new Models.Email();
				email.nombre = usuario.Nombre;
				email.email = usuario.CorreoPersonal;
				email.asunto = "Solicitud de demo gratis - JOBCTRL";
				email.mensaje = "";
				email.telefono = usuario.TelefonoMovil;
				email.telefonolocal = usuario.TelefonoLocal;
				email.App = 3;

				mensaje = dtUser.AsaeWebSolicitudesApp(email);

				if (mensaje.Respuesta == 1)
				{
					mensaje.RespuestaText = NuevaSolicitudDemoJOBCTRL(usuario);
				}
			}
			return mensaje;
		}

		public string NuevaSolicitudDemoJOBCTRL(Models.Usuario Musuario)
		{
			string respuesta = "";

			string host = "mail.asae.com.mx";
			int puerto = 25;
			string usuario = "asae_contactanos@asae.com.mx";
			string contra = "A$ae2018$$_";
			string pCorreo = Musuario.CorreoPersonal.ToString().Trim();

			MailMessage correo = new MailMessage();
			correo.To.Add(new MailAddress(pCorreo));
			correo.CC.Add("oscar.maldonado@asae.com.mx");
			correo.From = new MailAddress(usuario, "ASAE CONSULTORES, S.A DE C.V");
			correo.Subject = "Solicitud de demo gratis - JOBCTRL";
			correo.Body = HTMLDemoJOBCTRL();

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
				respuesta = "ok";
			}
			catch (Exception ex)
			{
				respuesta = "Error: " + ex.Message;
			}

			return respuesta;
		}

		public string HTMLDemoJOBCTRL()
        {
			string HTML = "";
			HTML += "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
			"<html xmlns:v='urn:schemas-microsoft-com:vml'>" +
			"<head>" +
				"<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />" +
				"<meta name='viewport' content='width=device-width; initial-scale=1.0; maximum-scale=1.0;' />" +
				
				"<link href='https://fonts.googleapis.com/css?family=Nunito+Sans:200,300,400,600,700' rel='stylesheet'>" +
				"<!--<![endif]-->" +
				"<title>Asae Consultores S.A de C.V</title>" +
				"<style type='text/css'>" +
				"	body {" +
			"			width: 100%;" +
			"			background-color: #ffffff;" +
			"			margin: 0;" +
			"			padding: 0;" +
			"			-webkit-font-smoothing: antialiased;" +
			"			mso-margin-top-alt: 0px;" +
			"			mso-margin-bottom-alt: 0px;" +
			"			mso-padding-alt: 0px 0px 0px 0px;" +
			"			font-family: 'Nunito Sans', sans-serif;" +
			"		}" +
			"		* {" +
			"			-ms-text-size-adjust: 100%;" +
			"			-webkit-text-size-adjust: 100%;" +
			"		}" +
			"		div[style*='margin: 16px 0'] {" +
			"			margin: 0 !important;" +
			"		}" +

			"		table," +
			"		td {" +
			"			mso-table-lspace: 0pt !important;" +
			"			mso-table-rspace: 0pt !important;" +
			"		}" +

			"		table {" +
			"			border-spacing: 0 !important;" +
			"			border-collapse: collapse !important;" +
			"			table-layout: fixed !important;" +
			"			margin: 0 auto !important;" +
			"		}" +

			"		img {" +
			"			-ms-interpolation-mode:bicubic;" +
			"		}" +
			"		a {" +
			"			text-decoration: none;" +
			"		}" +
			"		h1, h2, h3, h4, h5, h6 {" +
			"			font-family: 'Nunito Sans', sans-serif;" +
			"			color: #000000;" +
			"			margin-top: 0;" +
			"		}" +

			"		.logo h1{" +
			"			margin: 0;" +
			"		}" +
			"		.logo h1 a{" +
			"			color: #797979;" +
			"			font-size: 20px;" +
			"			font-weight: 700;" +
			"			font-family: 'Nunito Sans', sans-serif;" +
			"		}" +

			"	</style>" +
			"		</head>" +
			"			<body class='respond' leftmargin='0' topmargin='0' marginwidth='0' marginheight='0'>" +
			"			<!-- header -->" +
			"			<table border='0' width='100%' cellpadding='0' cellspacing='0' bgcolor='ffffff'>" +
			"				<tr>" +
			"					<td align='center' style='background-color: #f1f1f1;'>" +
			"						<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' class='container590'>" +
			"							<tr>" +
			"								<td align='center'>" +
			"									<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff;'>" +
			"										<tr>" +
			"											<td align='center' style='padding: 1em 2.5em;'>" +
			"												<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
			"													<tr>" +
			"														<td width='16%' class='logo' style='text-align: left; padding: 10px'>" +
			"															<h1><a style='color: #000; font-size: 10px; font-weight: 700; text-transform: uppercase;' href='https://www.asae.com.mx/'><img src='https://www.asae.com.mx/images/Tickets/LogoAsae.png' alt='' style='width: 100%; max-width: 500px; height: auto; margin: auto; display: block;'></a></h1>" +
			"														  </td>" +
			"														  <td width='55%' class='logo' style='text-align: right;'>" +
			"															<table width='100%' border='0' cellpadding='0' cellspacing='0' style='border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;' class='container590 hide'>" +
			"																<tr>" +
			"																	<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500; '>" +
			"																		<a href='https://www.asae.com.mx/' style='color: #adadad;'>Inicio </a>" +
			"																	</td>" +
			"																	<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
			"																		<a href='https://www.asae.com.mx/jobctrl' style='color: #adadad;'>JobCTRL </a>" +
			"																	</td>" +
			"																	<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
			"																		<a href='https://www.asae.com.mx/contacto/atencion-a-clientes' style='color: #adadad;'>Contacto </a>" +
			"																	</td>" +
			"																</tr>" +
			"															</table>" +
			"														  </td>" +
			"													</tr>" +
			"												</table>" +
			"											</td>" +
			"										</tr>" +
			"										<tr>" +
			"											<td align='center' valign='middle' class='hero bg_white' style=' position: relative; z-index: 0;'>" +
			"											  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
			"													<tr>" +
			"														<td valign='middle' width='50%'>" +
			"														  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
			"															<tr>" +
			"															  <td>" +
			"																<img src='https://www.asae.com.mx/01/JobCTRL/Flexibilidad_Control.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
			"															  </td>" +
			"															</tr>" +
			"														  </table>" +
			"													</td>" +
			"													<td valign='middle' width='50%' >" +
			"													  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
			"														<tr>" +
			"														  <td class='text' style='text-align: left; padding: 20px 30px;'>" +
			"																<h2 style='color: #FF6600; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.3;'>Gracias por enviar tu mensaje </h2>" +
			"																<p style='font-size: 14px; line-height: 1.5; color: #676466;'> Suscríbete y recibe nuestras ultimas noticias y promociones en las mejores herramientas en soluciones TI.</p>" +
			"																<p><a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='border-radius: 5px;background: #FF6600; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;' >Suscribirme</a></p>" +
			"														  </td>" +
			"														</tr>" +
			"													  </table>" +
			"													</td>" +
			"													</tr>" +
			"												</table>" +
			"											</td>" +
			"										</tr>" +

			"										<tr>" +
			"											<td align='center' style=''>" +
			"												<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 2.5em;'>" +
			"													<tr>" +
			"														<td align='center' style='padding: 1em 4em;'>" +
			"															<p style='font-size: 19px; color: #FF6600;'> " +
			"															Te agradecemos que nos hayas contactado, en breve un ejecutivo te contactara para atender tus dudas y / o comentarios.</p>" +
			"														</td>" +
			"													</tr>" +
			"													<tr>" +
			"														<td>" +

			"														</td>" +
			"													<tr>" +
			"												</table>" +
			"											</td>" +
			"										</tr>" +
			"										<tr>" +
			"											<td  style='    padding: 2.5em;'>" +
			"												<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
			"													<tr>" +
			"														<td valign='middle' width='50%'>" +
			"															<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
			"																<tr>" +
			"																	<td>" +
			"																		<img src='https://www.asae.com.mx/01/JobCTRL/LogoJobCtrl_trans.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
			"																	</td>" +
			"																</tr>" +
			"															</table>" +
			"														</td>" +
			"														<td valign='middle' width='50%'>" +
			"															<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
			"																<tr>" +
			"																	<td class='text-services' style='text-align: left; padding-left:25px;'>" +
			"																		<div class='heading-section'>" +
			"																			<h2 style='color: #676466; font-size: 21px; font-weight: 300;margin-top: 0; line-height: 1.3; font-weight: 400;'>Equipos de colaboradores en Home Office más productivos.</h2>" +
			"																			<p style='font-size: 12px; line-height: 1.8; color: #b9b9b9;'><strong>JOBCTRL</strong> Documenta las tareas, actividades y desempeño en tiempo real en una sola plataforma.</p>" +
			"																			<p><a href='https://www.asae.com.mx/jobctrl' style='border-radius: 5px;background: #FF6600; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
			"																		</div>" +
			"																	</td>" +
			"																</tr>" +
			"															</table>" +
			"														</td>" +
			"													</tr>" +
			"												</table>" +
			"											</td>" +
			"										</tr>" +
			"										<tr>" +
			"											<td>" +
			"												<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
			"													<tr>" +
			"														<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #026fa0;'>" +
			"															<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
			"																<tr>" +
			"																	<td class='counter-text'>" +
			"																		<span class='num'></span>" +
			"																	</td>" +
			"																</tr>" +
			"															</table>" +
			"														</td>" +
			"														<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #009baf;'>" +
			"															<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
			"																<tr>" +
			"																	<td class='counter-text'>" +
			"																		<span class='num'></span>" +
			"																	</td>" +
			"																</tr>" +
			"															</table>" +
			"														</td>" +
			"														<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #00BCD4;'>" +
			"															<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
			"																<tr>" +
			"																	<td class='counter-text'>" +
			"																		<span class='num'></span>" +
			"																	</td>" +
			"																</tr>" +
			"															</table>" +
			"														</td>" +
			"													</tr>" +
			"												</table>" +
			"											</td>" +
			"										</tr>" +
			"										<tr>" +
			"											<td>" +
			"												<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
			"													<tr>" +
			"														<td align='center' style='padding: 1em 4em;'>" +
			"															<br><br>" +
			"															<h2 style='color: #000000; font-size: 28px; margin-top: 0; font-weight: 400;'>LAS MEJORES HERRAMIENTAS EN LA ADMINISTRACIÓN Y CONTROL DE PROYECTOS</h2>" +
			"															<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'>Incrementa el 30 por ciento de productividad, con herramientas que analizan y miden el tiempo de trabajo de tu personal.</p>" +
			"														</td>" +
			"													</tr>" +
			"												</table>" +
			"											</td>" +
			"										</tr>" +
			"										<tr>" +
			"											<td style='padding: 1em;'>" +
			"												<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
			"													<tr>" +
			"														<td valign='top' width='50%' style='padding-top: 20px;'>" +
			"															<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
			"																<tr>" +
			"																	<td>" +
			"																		<br>" +
			"																		<img src='https://www.asae.com.mx/images/Tickets/Banner2.png' alt='' style='width: 90%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
			"																	</td>" +
			"																</tr>" +
			"																<tr>" +
			"																	<td class='text-services' style='text-align: left;'>" +
			"																		<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400;'>Asae Service Desk (ASD) </h3>" +
			"																		<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Ayuda a gerentes de TI a garantizar la continuidad de los servicios de TI dentro de la organización.</span></p>" +
			"																		<p><a href='https://www.asae.com.mx/asd' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
			"																	</td>" +
			"																</tr>" +
			"															</table>" +
			"														</td>" +
			"														<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/huawei.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>Huawei-Ideahub</h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>El nuevo estilo de oficina inteligente. </span></p>		" +
					"																<p><a href='https://www.asae.com.mx/huawei-ideahub' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
			"													</tr>" +
			"												</table>" +
			"											</td>" +
			"										</tr>" +
			"										<tr>" +
			"											<td style='padding: 2.5em; background: #000000; color: #9E9E9E'>" +
			"												<table align='center' role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
			"														<tr>" +
			"															<td valign='middle' class='bg_black footer email-section'>" +
			"																<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
			"																	<tr>" +
			"																		<td width='100%' style='text-align: center;'>" +
			"																			<p style='font-size: 22px; margin-top: 0;'>Dirección: Margaritas 426, Álvaro Obregón, Ciudad de México</p>" +
			"																		</td>" +
			"																	</tr>" +
			"																	<tr>" +
			"																		<td width='100%' style='text-align: center;'>" +
			"																			<p style='margin-top: 0; font-size: 14px; '>¿Quieres recibir más correos electrónicos con nuestras nuevas herramientas y promociones? Usted puede <a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='font-size: 14px; color: #00afc5;'>Darse de alta aquí</a></p>" +
			"																		</td>" +
			"																	</tr>" +
			"																	<tr>" +
			"																		<td width='100%' style='text-align: center;'>" +
			"																			<table>" +
			"																				<tr>" +
			"																					<td>" +
			"																						<a href='https://twitter.com/asaeconsultores'>" +
			"																							<img src='https://www.asae.com.mx/01/004-twitter-logo.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
			"																						</a>" +
			"																					</td>" +
			"																					<td>" +
			"																						<a href='https://www.facebook.com/AsaeConsultoresMX/'>" +
			"																							<img src='https://www.asae.com.mx/01/005-facebook.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
			"																						</a>" +
			"																					</td>" +
			"																				</tr>" +
			"																			</table>" +

			"																		</td>" +
			"																	</tr>" +
			"															</table>" +
			"															</td>" +
			"														</tr>" +
			"													  </table>" +
			"											</td>" +
			"										</tr>" +
			"									</table>" +
			"								</td>" +
			"							</tr>" +
			"							<tr>" +
			"								<td height='25' style='font-size: 25px; line-height: 25px;'>&nbsp;</td>" +
			"							</tr>" +
			"						</table>" +
			"					</td>" +
			"				</tr>" +
			"			</table>" +
			"			<!-- end header -->" +
			"			</body>" +
			"		</html>";

			return HTML;

		}

		/************************************************************************************************************/
		/************************************************************************************************************/

		/************************************************************************************************************/
		/************************************************************************************************************/

		public Models.Mensaje AsaeWebSolicitudDemoHikvision(Models.Usuario usuario)
		{
			Models.Mensaje mensaje = new Models.Mensaje();
			mensaje = ValidarSolicitud(usuario);

			if (mensaje.Respuesta == 1)
			{
				Models.Email email = new Models.Email();
				email.nombre = usuario.Nombre;
				email.email = usuario.CorreoPersonal;
				email.asunto = "Solicitud de cotización - Hikvision";
				email.mensaje = "";
				email.telefono = usuario.TelefonoMovil;
				email.telefonolocal = usuario.TelefonoLocal;
				email.App = 4;

				mensaje = dtUser.AsaeWebSolicitudesApp(email);

				if (mensaje.Respuesta == 1)
				{
					mensaje.RespuestaText = NuevaSolicitudDemoHikvision(usuario);
				}
			}
			return mensaje;
		}

		public string NuevaSolicitudDemoHikvision(Models.Usuario Musuario)
		{
			string respuesta = "";

			string host = "mail.asae.com.mx";
			int puerto = 25;
			string usuario = "asae_contactanos@asae.com.mx";
			string contra = "A$ae2018$$_";
			string pCorreo = Musuario.CorreoPersonal.ToString().Trim();

			MailMessage correo = new MailMessage();
			correo.To.Add(new MailAddress(pCorreo));
			correo.CC.Add("gabriel.cruz@asaeop.com.mx");
			correo.From = new MailAddress(usuario, "ASAE CONSULTORES, S.A DE C.V");
			correo.Subject = "Solicitud de cotización - Hikvision";
			correo.Body = HTMLDemoHikvision();

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
				respuesta = "ok";
			}
			catch (Exception ex)
			{
				respuesta = "Error: " + ex.Message;
			}

			return respuesta;
		}

		public string HTMLDemoHikvision()
		{
			string HTML = "";
			HTML += "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
					"<html xmlns:v='urn:schemas-microsoft-com:vml'>" +
					"<head>" +
					"	<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />" +
					"	<meta name='viewport' content='width=device-width; initial-scale=1.0; maximum-scale=1.0;' />" +
					
					"	<link href='https://fonts.googleapis.com/css?family=Nunito+Sans:200,300,400,600,700' rel='stylesheet'>" +
					"	<!--<![endif]-->" +
					"	<title>Asae Consultores S.A de C.V</title>" +
					"	<style type='text/css'>" +
					"		body {" +
					"			width: 100%;" +
					"			background-color: #ffffff;" +
					"			margin: 0;" +
					"			padding: 0;" +
					"			-webkit-font-smoothing: antialiased;" +
					"			mso-margin-top-alt: 0px;" +
					"			mso-margin-bottom-alt: 0px;" +
					"			mso-padding-alt: 0px 0px 0px 0px;" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"		}" +
					"		* {" +
					"			-ms-text-size-adjust: 100%;" +
					"			-webkit-text-size-adjust: 100%;" +
					"		}" +
					"		div[style*='margin: 16px 0'] {" +
					"			margin: 0 !important;" +
					"		}" +

					"		table," +
					"		td {" +
					"			mso-table-lspace: 0pt !important;" +
					"			mso-table-rspace: 0pt !important;" +
					"		}" +

					"		table {" +
					"			border-spacing: 0 !important;" +
					"			border-collapse: collapse !important;" +
					"			table-layout: fixed !important;" +
					"			margin: 0 auto !important;" +
					"		}" +

					"		img {" +
					"			-ms-interpolation-mode:bicubic;" +
					"		}" +
					"		a {" +
					"			text-decoration: none;" +
					"		}" +
					"		h1, h2, h3, h4, h5, h6 {" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"			color: #000000;" +
					"			margin-top: 0;" +
					"		}" +

					"		.logo h1{" +
					"			margin: 0;" +
					"		}" +
					"		.logo h1 a{" +
					"			color: #797979;" +
					"			font-size: 20px;" +
					"			font-weight: 700;" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"		}" +

					"	</style>" +
					"</head>" +
					"	<body class='respond' leftmargin='0' topmargin='0' marginwidth='0' marginheight='0'>" +
					"	<!-- header -->" +
					"	<table border='0' width='100%' cellpadding='0' cellspacing='0' bgcolor='ffffff'>" +
					"		<tr>" +
					"			<td align='center' style='background-color: #f1f1f1;'>" +
					"				<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' class='container590'>" +
					"					<tr>" +
					"						<td align='center'>" +
					"							<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff;'>" +
					"								<tr>" +
					"									<td align='center' style='padding: 1em 2.5em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td width='16%' class='logo' style='text-align: left; padding: 10px'>" +
					"													<h1><a style='color: #000; font-size: 10px; font-weight: 700; text-transform: uppercase;' href='https://www.asae.com.mx/'><img src='https://www.asae.com.mx/images/Tickets/LogoAsae.png' alt='' style='width: 100%; max-width: 500px; height: auto; margin: auto; display: block;'></a></h1>" +
					"												  </td>" +
					"												  <td width='55%' class='logo' style='text-align: right;'>" +
					"													<table width='100%' border='0' cellpadding='0' cellspacing='0' style='border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;' class='container590 hide'>" +
					"														<tr>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500; '>" +
					"																<a href='https://www.asae.com.mx/' style='color: #adadad;'>Inicio </a>" +
					"															</td>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
					"																<a href='https://www.asae.com.mx/hikvision' style='color: #adadad;'>Hikvision </a>" +
					"															</td>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
					"																<a href='https://www.asae.com.mx/contacto/atencion-a-clientes' style='color: #adadad;'>Contacto </a>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												  </td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #fafafa; padding: 0.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 0em 4em;'>" +
					"													<P style='font-size: 32px;color: #b53c3c; font-size: 32px; '><strong>Hikvision</strong></P>" +
					"												</td>" +
					"											</tr>" +
					"											<tr>" +
					"												<td>" +
					"												</td>" +
					"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #b53c3c;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #d25050;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #ef7777;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 1.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"												</td>" +
					"											</tr>" +
					"											<tr>" +
					"												<td>" +
					"												</td>" +
					"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"													<p style='color: #b53c3c; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.3;'>" +
					"													Te agradecemos que nos hayas contactado, en breve un ejecutivo se comunicara contigo para atender tu solicitud y brindarte una cotización totalmente gratis.</p>" +
					"													<br>" +
					"												</td>" +
					"											</tr>" +
					"											<tr>" +
					"												<td>" +
					"												</td>" +
					"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 1.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"												</td>" +
					"											</tr>" +
					"											<tr>" +
					"												<td>" +
					"												</td>" +
					"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' valign='middle' class='hero bg_white' style=' position: relative; z-index: 0;'>" +
					"									  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%' >" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td class='text' style='text-align: left; padding: 20px 30px;'>" +
					"															<h2 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>Sistemas de seguridad y monitoreo inteligente para complejos residenciales</h2>" +
					"															<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'> <strong>Elimine falsas alarmas, riesgos de intrusos y visitantes desconocidos en un solo sistema de videvigilancia.</p>" +
					"															<p><a href='https://www.asae.com.mx/hikvision' style='border-radius: 5px;background: #b53c3c; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"												</td>" +
					"												<td valign='middle' width='50%'>" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td>" +
					"														<img src='https://www.asae.com.mx/01/Hikvision/camaras-de-vigilancia-hikvsion.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #b53c3c;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #d25050;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #ef7777;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"													<br><br>" +
					"													<h2 style='color: #000000; font-size: 28px; margin-top: 0; font-weight: 400;'>LAS MEJORES HERRAMIENTAS EN LA ADMINISTRACIÓN Y CONTROL DE PROYECTOS</h2>" +
					"													<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'>Incrementa el 30 por ciento de productividad, con herramientas que analizan y miden el tiempo de trabajo de tu personal.</p>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								<tr>" +
					"								<tr>" +
					"									<td style='padding: 1em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/blog-1.jpg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400;'>JobCTRL </h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Software para documentar analizar mejorar el tiempo de trabajo.</span></p>		" +
					"																<p><a href='https://www.asae.com.mx/jobctrl' style='border-radius: 5px;background: #b53c3c; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/huawei.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>Huawei-Ideahub</h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>El nuevo estilo de oficina inteligente. </span></p>		" +
					"																<p><a href='https://www.asae.com.mx/huawei-ideahub' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td style='padding: 2.5em; background: #000000; color: #9E9E9E'>" +
					"										<table align='center' role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
					"												<tr>" +
					"													<td valign='middle' class='bg_black footer email-section'>" +
					"														<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<p style='font-size: 22px; margin-top: 0;'>Dirección: Margaritas 426, Álvaro Obregón, Ciudad de México</p>" +
					"																</td>" +
					"															</tr>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<p style='margin-top: 0; font-size: 14px; '>¿Quieres recibir más correos electrónicos con nuestras nuevas herramientas y promociones? Usted puede <a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='font-size: 14px; color: #00afc5;'>Darse de alta aquí</a></p>" +
					"																</td>" +
					"															</tr>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<table>" +
					"																		<tr>" +
					"																			<td>" +
					"																				<a href='https://twitter.com/asaeconsultores'>" +
					"																					<img src='https://www.asae.com.mx/01/004-twitter-logo.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
					"																				</a>" +
					"																			</td>" +
					"																			<td>" +
					"																				<a href='https://www.facebook.com/AsaeConsultoresMX/'>" +
					"																					<img src='https://www.asae.com.mx/01/005-facebook.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
					"																				</a>" +
					"																			</td>" +
					"																		</tr>" +
					"																	</table>" +
					"																</td>" +
					"															</tr>" +
					"													</table>" +
					"													</td>" +
					"												</tr>" +
					"											  </table>" +
					"									</td>" +
					"								</tr>" +
					"							</table>" +
					"						</td>" +
					"					</tr>" +
					"					<tr>" +
					"						<td height='25' style='font-size: 25px; line-height: 25px;'>&nbsp;</td>" +
					"					</tr>" +
					"				</table>" +
					"			</td>" +
					"		</tr>" +
					"	</table>" +
					"	<!-- end header -->" +
					"	</body>" +
					"</html>";

			return HTML;

		}

		/************************************************************************************************************/
		/************************************************************************************************************/
		/************************************************************************************************************/
		/************************************************************************************************************/

		public Models.Mensaje AsaeWebSolicitudDemoHuawei(Models.Usuario usuario)
		{
			Models.Mensaje mensaje = new Models.Mensaje();
			mensaje = ValidarSolicitud(usuario);

			if (mensaje.Respuesta == 1)
			{
				Models.Email email = new Models.Email();
				email.nombre = usuario.Nombre;
				email.email = usuario.CorreoPersonal;
				email.asunto = "Solicitud de Cotización - Centro de datos all-flash OceanStor Dorado V6";
				email.mensaje = "";
				email.telefono = usuario.TelefonoMovil;
				email.telefonolocal = usuario.TelefonoLocal;
				email.App = 5;

                mensaje = dtUser.AsaeWebSolicitudesApp(email);

                if (mensaje.Respuesta == 1)
                {
                    mensaje.RespuestaText = NuevaSolicitudDemoHuawei(usuario);
                }
            }
			return mensaje;
		}

		public string NuevaSolicitudDemoHuawei(Models.Usuario Musuario)
		{
			string respuesta = "";

			string host = "mail.asae.com.mx";
			int puerto = 25;
			string usuario = "asae_contactanos@asae.com.mx";
			string contra = "A$ae2018$$_";
			string pCorreo = Musuario.CorreoPersonal.ToString().Trim();

			MailMessage correo = new MailMessage();
			correo.To.Add(new MailAddress(pCorreo));
			correo.CC.Add("gabriel.cruz@asaeop.com.mx");
			correo.From = new MailAddress(usuario, "ASAE CONSULTORES, S.A DE C.V");
			correo.Subject = "Solicitud de Cotización - Centro de datos all-flash OceanStor Dorado V6";
			correo.Body = HTMLDemoHuawei();

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
				respuesta = "ok";
			}
			catch (Exception ex)
			{
				respuesta = "Error: " + ex.Message;
			}

			return respuesta;
		}

		public string HTMLDemoHuawei()
		{
			string HTML = "";
			HTML += "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
					"<html xmlns:v='urn:schemas-microsoft-com:vml'>" +
					"<head>" +
					"	<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />" +
					"	<meta name='viewport' content='width=device-width; initial-scale=1.0; maximum-scale=1.0;' />" +
					
					"	<link href='https://fonts.googleapis.com/css?family=Nunito+Sans:200,300,400,600,700' rel='stylesheet'>" +
					"	<!--<![endif]-->" +
					"	<title>Asae Consultores S.A de C.V</title>" +
					"	<style type='text/css'>" +
					"		body {" +
					"			width: 100%;" +
					"			background-color: #ffffff;" +
					"			margin: 0;" +
					"			padding: 0;" +
					"			-webkit-font-smoothing: antialiased;" +
					"			mso-margin-top-alt: 0px;" +
					"			mso-margin-bottom-alt: 0px;" +
					"			mso-padding-alt: 0px 0px 0px 0px;" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"		}" +
					"		* {" +
					"			-ms-text-size-adjust: 100%;" +
					"			-webkit-text-size-adjust: 100%;" +
					"		}" +
					"		div[style*='margin: 16px 0'] {" +
					"			margin: 0 !important;" +
					"		}" +

					"		table," +
					"		td {" +
					"			mso-table-lspace: 0pt !important;" +
					"			mso-table-rspace: 0pt !important;" +
					"		}" +

					"		table {" +
					"			border-spacing: 0 !important;" +
					"			border-collapse: collapse !important;" +
					"			table-layout: fixed !important;" +
					"			margin: 0 auto !important;" +
					"		}" +

					"		img {" +
					"			-ms-interpolation-mode:bicubic;" +
					"		}" +
					"		a {" +
					"			text-decoration: none;" +
					"		}" +
					"		h1, h2, h3, h4, h5, h6 {" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"			color: #000000;" +
					"			margin-top: 0;" +
					"		}" +

					"		.logo h1{" +
					"			margin: 0;" +
					"		}" +
					"		.logo h1 a{" +
					"			color: #797979;" +
					"			font-size: 20px;" +
					"			font-weight: 700;" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"		}" +

					"	</style>" +
					"</head>" +
					"	<body class='respond' leftmargin='0' topmargin='0' marginwidth='0' marginheight='0'>" +
					"	<!-- header -->" +
					"	<table border='0' width='100%' cellpadding='0' cellspacing='0' bgcolor='ffffff'>" +
					"		<tr>" +
					"			<td align='center' style='background-color: #f1f1f1;'>" +
					"				<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' class='container590'>" +
					"					<tr>" +
					"						<td align='center'>" +
					"							<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff;'>" +
					"								<tr>" +
					"									<td align='center' style='padding: 1em 2.5em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td width='16%' class='logo' style='text-align: left; padding: 10px'>" +
					"													<h1><a style='color: #000; font-size: 10px; font-weight: 700; text-transform: uppercase;' href='https://www.asae.com.mx/'><img src='https://www.asae.com.mx/images/Tickets/LogoAsae.png' alt='' style='width: 100%; max-width: 500px; height: auto; margin: auto; display: block;'></a></h1>" +
					"												  </td>" +
					"												  <td width='55%' class='logo' style='text-align: right;'>" +
					"													<table width='100%' border='0' cellpadding='0' cellspacing='0' style='border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;' class='container590 hide'>" +
					"														<tr>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500; '>" +
					"																<a href='https://www.asae.com.mx/' style='color: #adadad;'>Inicio </a>" +
					"															</td>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
					"																<a href='https://www.asae.com.mx/oceanstor-dorado' style='color: #adadad;'>Hikvision </a>" +
					"															</td>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
					"																<a href='https://www.asae.com.mx/contacto/atencion-a-clientes' style='color: #adadad;'>Contacto </a>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												  </td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #fafafa; padding: 0.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 0em 4em;'>" +
					"													<P style='font-size: 32px;color: #223C60; font-size: 32px; '><strong>Centro de datos all-flash OceanStor Dorado V6 </strong></P>" +
					"												</td>" +
					"											</tr>" +
					"											<tr>" +
					"												<td>" +
					"												</td>" +
					"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #223C60;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #375B8C;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #4777B9;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 1.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"												</td>" +
					"											</tr>" +
					"											<tr>" +
					"												<td>" +
					"												</td>" +
					"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"													<p style='color: #223C60; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.3;'>" +
					"													Te agradecemos que nos hayas contactado, en breve un ejecutivo se comunicara contigo para atender tu solicitud y brindarte una cotización totalmente gratis.</p>" +
					"													<br>" +
					"												</td>" +
					"											</tr>" +
					"											<tr>" +
					"												<td>" +
					"												</td>" +
					"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 1.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"												</td>" +
					"											</tr>" +
					"											<tr>" +
					"												<td>" +
					"												</td>" +
					"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' valign='middle' class='hero bg_white' style=' position: relative; z-index: 0;'>" +
					"									  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%' >" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td class='text' style='text-align: left; padding: 20px 30px;'>" +
					"															<h2 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>Aloje sus datos en un entorno más rápido, más ecológico y más confiable. Diseñado para servicios de misión crítica.</h2>" +
					"															<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'> <strong>Más rápido que nunca con innovadoras arquitecturas y hardware.</p>" +
					"															<p><a href='https://www.asae.com.mx/oceanstor-dorado' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"												</td>" +
					"												<td valign='middle' width='50%'>" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td>" +
					"														<img src='https://www.asae.com.mx/01/oceanstor-dorado/OceanstorDoradoV6.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #223C60;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #375B8C;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #4777B9;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"													<br><br>" +
					"													<h2 style='color: #000000; font-size: 28px; margin-top: 0; font-weight: 400;'>LAS MEJORES HERRAMIENTAS EN LA ADMINISTRACIÓN Y CONTROL DE PROYECTOS</h2>" +
					"													<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'>Incrementa el 30 por ciento de productividad, con herramientas que analizan y miden el tiempo de trabajo de tu personal.</p>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								<tr>" +
					"								<tr>" +
					"									<td style='padding: 1em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/blog-1.jpg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400;'>JobCTRL </h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Software para documentar analizar mejorar el tiempo de trabajo.</span></p>		" +
					"																<p><a href='https://www.asae.com.mx/jobctrl' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/oficinas.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>Eventos Corporativos</h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Haz tus eventos corporativos en un entorno inteligente y dinámico </span></p>		" +
					"																<p><a href='https://www.asae.com.mx/eventos-corporativos' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td style='padding: 2.5em; background: #000000; color: #9E9E9E'>" +
					"										<table align='center' role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
					"												<tr>" +
					"													<td valign='middle' class='bg_black footer email-section'>" +
					"														<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<p style='font-size: 22px; margin-top: 0;'>Dirección: Margaritas 426, Álvaro Obregón, Ciudad de México</p>" +
					"																</td>" +
					"															</tr>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<p style='margin-top: 0; font-size: 14px; '>¿Quieres recibir más correos electrónicos con nuestras nuevas herramientas y promociones? Usted puede <a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='font-size: 14px; color: #00afc5;'>Darse de alta aquí</a></p>" +
					"																</td>" +
					"															</tr>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<table>" +
					"																		<tr>" +
					"																			<td>" +
					"																				<a href='https://twitter.com/asaeconsultores'>" +
					"																					<img src='https://www.asae.com.mx/01/004-twitter-logo.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
					"																				</a>" +
					"																			</td>" +
					"																			<td>" +
					"																				<a href='https://www.facebook.com/AsaeConsultoresMX/'>" +
					"																					<img src='https://www.asae.com.mx/01/005-facebook.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
					"																				</a>" +
					"																			</td>" +
					"																		</tr>" +
					"																	</table>" +
					"																</td>" +
					"															</tr>" +
					"													</table>" +
					"													</td>" +
					"												</tr>" +
					"											  </table>" +
					"									</td>" +
					"								</tr>" +
					"							</table>" +
					"						</td>" +
					"					</tr>" +
					"					<tr>" +
					"						<td height='25' style='font-size: 25px; line-height: 25px;'>&nbsp;</td>" +
					"					</tr>" +
					"				</table>" +
					"			</td>" +
					"		</tr>" +
					"	</table>" +
					"	<!-- end header -->" +
					"	</body>" +
					"</html>";

			return HTML;

		}

		/************************************************************************************************************/
		/************************************************************************************************************/
		/************************************************************************************************************/
		/************************************************************************************************************/

		public Models.Mensaje AsaeWebSolicitudDemoIdeaHub(Models.Usuario usuario)
		{
			Models.Mensaje mensaje = new Models.Mensaje();
			mensaje = ValidarSolicitud(usuario);

			if (mensaje.Respuesta == 1)
			{
				Models.Email email = new Models.Email();
				email.nombre = usuario.Nombre;
				email.email = usuario.CorreoPersonal;
				email.asunto = "Solicitud de Cotización - IdeaHub";
				email.mensaje = "";
				email.telefono = usuario.TelefonoMovil;
				email.telefonolocal = usuario.TelefonoLocal;
				email.App = 6;

				mensaje = dtUser.AsaeWebSolicitudesApp(email);

				if (mensaje.Respuesta == 1)
				{
					mensaje.RespuestaText = NuevaSolicitudDemoIdeaHub(usuario);
				}
			}
			return mensaje;
		}

		public string NuevaSolicitudDemoIdeaHub(Models.Usuario Musuario)
		{
			string respuesta = "";

			string host = "mail.asae.com.mx";
			int puerto = 25;
			string usuario = "asae_contactanos@asae.com.mx";
			string contra = "A$ae2018$$_";
			string pCorreo = Musuario.CorreoPersonal.ToString().Trim();

			MailMessage correo = new MailMessage();
			correo.To.Add(new MailAddress(pCorreo));
			correo.CC.Add("gabriel.cruz@asaeop.com.mx");
			correo.From = new MailAddress(usuario, "ASAE CONSULTORES, S.A DE C.V");
			correo.Subject = "Solicitud de Cotización - IdeaHub";
			correo.Body = HTMLDemoIdeaHub();

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
				respuesta = "ok";
			}
			catch (Exception ex)
			{
				respuesta = "Error: " + ex.Message;
			}

			return respuesta;
		}

		public string HTMLDemoIdeaHub()
		{
			string HTML = "";
			HTML += "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
					"<html xmlns:v='urn:schemas-microsoft-com:vml'>" +
					"<head>" +
					"	<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />" +
					"	<meta name='viewport' content='width=device-width; initial-scale=1.0; maximum-scale=1.0;' />" +
					
					"	<link href='https://fonts.googleapis.com/css?family=Nunito+Sans:200,300,400,600,700' rel='stylesheet'>" +
					"	<!--<![endif]-->" +
					"	<title>Asae Consultores S.A de C.V</title>" +
					"	<style type='text/css'>" +
					"		body {" +
					"			width: 100%;" +
					"			background-color: #ffffff;" +
					"			margin: 0;" +
					"			padding: 0;" +
					"			-webkit-font-smoothing: antialiased;" +
					"			mso-margin-top-alt: 0px;" +
					"			mso-margin-bottom-alt: 0px;" +
					"			mso-padding-alt: 0px 0px 0px 0px;" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"		}" +
					"		* {" +
					"			-ms-text-size-adjust: 100%;" +
					"			-webkit-text-size-adjust: 100%;" +
					"		}" +
					"		div[style*='margin: 16px 0'] {" +
					"			margin: 0 !important;" +
					"		}" +

					"		table," +
					"		td {" +
					"			mso-table-lspace: 0pt !important;" +
					"			mso-table-rspace: 0pt !important;" +
					"		}" +

					"		table {" +
					"			border-spacing: 0 !important;" +
					"			border-collapse: collapse !important;" +
					"			table-layout: fixed !important;" +
					"			margin: 0 auto !important;" +
					"		}" +

					"		img {" +
					"			-ms-interpolation-mode:bicubic;" +
					"		}" +
					"		a {" +
					"			text-decoration: none;" +
					"		}" +
					"		h1, h2, h3, h4, h5, h6 {" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"			color: #000000;" +
					"			margin-top: 0;" +
					"		}" +

					"		.logo h1{" +
					"			margin: 0;" +
					"		}" +
					"		.logo h1 a{" +
					"			color: #797979;" +
					"			font-size: 20px;" +
					"			font-weight: 700;" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"		}" +

					"	</style>" +
					"</head>" +
					"	<body class='respond' leftmargin='0' topmargin='0' marginwidth='0' marginheight='0'>" +
					"	<!-- header -->" +
					"	<table border='0' width='100%' cellpadding='0' cellspacing='0' bgcolor='ffffff'>" +
					"		<tr>" +
					"			<td align='center' style='background-color: #f1f1f1;'>" +
					"				<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' class='container590'>" +
					"					<tr>" +
					"						<td align='center'>" +
					"							<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff;'>" +
					"								<tr>" +
					"									<td align='center' style='padding: 1em 2.5em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td width='16%' class='logo' style='text-align: left; padding: 10px'>" +
					"													<h1><a style='color: #000; font-size: 10px; font-weight: 700; text-transform: uppercase;' href='https://www.asae.com.mx/'><img src='https://www.asae.com.mx/images/Tickets/LogoAsae.png' alt='' style='width: 100%; max-width: 500px; height: auto; margin: auto; display: block;'></a></h1>" +
					"												  </td>" +
					"												  <td width='55%' class='logo' style='text-align: right;'>" +
					"													<table width='100%' border='0' cellpadding='0' cellspacing='0' style='border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;' class='container590 hide'>" +
					"														<tr>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500; '>" +
					"																<a href='https://www.asae.com.mx/' style='color: #adadad;'>Inicio </a>" +
					"															</td>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
					"																<a href='https://www.asae.com.mx/huawei-ideahub' style='color: #adadad;'>IdeaHub </a>" +
					"															</td>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
					"																<a href='https://www.asae.com.mx/contacto/atencion-a-clientes' style='color: #adadad;'>Contacto </a>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												  </td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #fafafa; padding: 0.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 0em 4em;'>" +
					"													<P style='font-size: 32px;color: #223C60; font-size: 32px; '><strong>IdeaHub </strong></P>" +
					"												</td>" +
					"											</tr>" +
					"											<tr>" +
					"												<td>" +
					"												</td>" +
					"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #223C60;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #355C91;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #3171C7;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 1.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"												</td>" +
					"											</tr>" +
					"											<tr>" +
					"												<td>" +
					"												</td>" +
					"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"													<p style='color: #223C60; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.3;'>" +
					"													Te agradecemos que nos hayas contactado, en breve un ejecutivo se comunicara contigo para atender tu solicitud y brindarte una cotización totalmente gratis.</p>" +
					"													<br>" +
					"												</td>" +
					"											</tr>" +
					"											<tr>" +
					"												<td>" +
					"												</td>" +
					"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 1.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"												</td>" +
					"											</tr>" +
					"											<tr>" +
					"												<td>" +
					"												</td>" +
					"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' valign='middle' class='hero bg_white' style=' position: relative; z-index: 0;'>" +
					"									  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%' >" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td class='text' style='text-align: left; padding: 20px 30px;'>" +
					"															<h2 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>IdeaHub de Huawei, una herramienta de productividad para la oficina inteligente, Incluye escritura inteligente, </h2>" +
					"															<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'> <strong>videoconferencias de alta definición (HD) y uso compartido inalámbrico.</p>" +
					"															<p><a href='https://www.asae.com.mx/huawei-ideahub' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"												</td>" +
					"												<td valign='middle' width='50%'>" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td>" +
					"														<img src='https://www.asae.com.mx/01/Ideahub/ideahub.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #223C60;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #355C91;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #3171C7;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"													<br><br>" +
					"													<h2 style='color: #000000; font-size: 28px; margin-top: 0; font-weight: 400;'>LAS MEJORES HERRAMIENTAS EN LA ADMINISTRACIÓN Y CONTROL DE PROYECTOS</h2>" +
					"													<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'>Incrementa el 30 por ciento de productividad, con herramientas que analizan y miden el tiempo de trabajo de tu personal.</p>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								<tr>" +
					"								<tr>" +
					"									<td style='padding: 1em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/blog-1.jpg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400;'>JobCTRL </h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Software para documentar analizar mejorar el tiempo de trabajo.</span></p>		" +
					"																<p><a href='https://www.asae.com.mx/jobctrl' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/oficinas.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>Eventos Corporativos</h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Haz tus eventos corporativos en un entorno inteligente y dinámico </span></p>		" +
					"																<p><a href='https://www.asae.com.mx/eventos-corporativos' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td style='padding: 2.5em; background: #000000; color: #9E9E9E'>" +
					"										<table align='center' role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
					"												<tr>" +
					"													<td valign='middle' class='bg_black footer email-section'>" +
					"														<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<p style='font-size: 22px; margin-top: 0;'>Dirección: Margaritas 426, Álvaro Obregón, Ciudad de México</p>" +
					"																</td>" +
					"															</tr>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<p style='margin-top: 0; font-size: 14px; '>¿Quieres recibir más correos electrónicos con nuestras nuevas herramientas y promociones? Usted puede <a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='font-size: 14px; color: #00afc5;'>Darse de alta aquí</a></p>" +
					"																</td>" +
					"															</tr>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<table>" +
					"																		<tr>" +
					"																			<td>" +
					"																				<a href='https://twitter.com/asaeconsultores'>" +
					"																					<img src='https://www.asae.com.mx/01/004-twitter-logo.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
					"																				</a>" +
					"																			</td>" +
					"																			<td>" +
					"																				<a href='https://www.facebook.com/AsaeConsultoresMX/'>" +
					"																					<img src='https://www.asae.com.mx/01/005-facebook.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
					"																				</a>" +
					"																			</td>" +
					"																		</tr>" +
					"																	</table>" +
					"																</td>" +
					"															</tr>" +
					"													</table>" +
					"													</td>" +
					"												</tr>" +
					"											  </table>" +
					"									</td>" +
					"								</tr>" +
					"							</table>" +
					"						</td>" +
					"					</tr>" +
					"					<tr>" +
					"						<td height='25' style='font-size: 25px; line-height: 25px;'>&nbsp;</td>" +
					"					</tr>" +
					"				</table>" +
					"			</td>" +
					"		</tr>" +
					"	</table>" +
					"	<!-- end header -->" +
					"	</body>" +
					"</html>";

			return HTML;

		}



		/************************************************************************************************************/
		/************************************************************************************************************/

		/************************************************************************************************************/
		/************************************************************************************************************/

		public Models.Mensaje AsaeWebSolicitudDemoCorporativoIndustrial(Models.Usuario usuario)
		{
			Models.Mensaje mensaje = new Models.Mensaje();
			mensaje = ValidarSolicitud(usuario);

			if (mensaje.Respuesta == 1)
			{
				Models.Email email = new Models.Email();
				email.nombre = usuario.Nombre;
				email.email = usuario.CorreoPersonal;
				email.asunto = "Solicitud de cotización - Corporativo e industrial";
				email.mensaje = "";
				email.telefono = usuario.TelefonoMovil;
				email.telefonolocal = usuario.TelefonoLocal;
				email.App = 7;

				mensaje = dtUser.AsaeWebSolicitudesApp(email);

				if (mensaje.Respuesta == 1)
				{
					mensaje.RespuestaText = NuevaSolicitudDemoCorporativoIndustrial(usuario);
				}
			}
			return mensaje;
		}

		public string NuevaSolicitudDemoCorporativoIndustrial(Models.Usuario Musuario)
		{
			string respuesta = "";

			string host = "mail.asae.com.mx";
			int puerto = 25;
			string usuario = "asae_contactanos@asae.com.mx";
			string contra = "A$ae2018$$_";
			string pCorreo = Musuario.CorreoPersonal.ToString().Trim();

			MailMessage correo = new MailMessage();
			correo.To.Add(new MailAddress(pCorreo));
			correo.CC.Add("valdemar.gonzales@asaeop.com.mx");
			correo.From = new MailAddress(usuario, "ASAE CONSULTORES, S.A DE C.V");
			correo.Subject = "Solicitud de cotización - Corporativo e industrial";
			correo.Body = HTMLDemoHikvision();

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
				respuesta = "ok";
			}
			catch (Exception ex)
			{
				respuesta = "Error: " + ex.Message;
			}

			return respuesta;
		}

		public string HTMLDemoCorporativoIndustrial()
		{
			string HTML = "";
			HTML += "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
					"<html xmlns:v='urn:schemas-microsoft-com:vml'>" +
					"<head>" +
					"	<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />" +
					"	<meta name='viewport' content='width=device-width; initial-scale=1.0; maximum-scale=1.0;' />" +
					
					"	<link href='https://fonts.googleapis.com/css?family=Nunito+Sans:200,300,400,600,700' rel='stylesheet'>" +
					"	<!--<![endif]-->" +
					"	<title>Asae Consultores S.A de C.V</title>" +
					"	<style type='text/css'>" +
					"		body {" +
					"			width: 100%;" +
					"			background-color: #ffffff;" +
					"			margin: 0;" +
					"			padding: 0;" +
					"			-webkit-font-smoothing: antialiased;" +
					"			mso-margin-top-alt: 0px;" +
					"			mso-margin-bottom-alt: 0px;" +
					"			mso-padding-alt: 0px 0px 0px 0px;" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"		}" +
					"		* {" +
					"			-ms-text-size-adjust: 100%;" +
					"			-webkit-text-size-adjust: 100%;" +
					"		}" +
					"		div[style*='margin: 16px 0'] {" +
					"			margin: 0 !important;" +
					"		}" +

					"		table," +
					"		td {" +
					"			mso-table-lspace: 0pt !important;" +
					"			mso-table-rspace: 0pt !important;" +
					"		}" +

					"		table {" +
					"			border-spacing: 0 !important;" +
					"			border-collapse: collapse !important;" +
					"			table-layout: fixed !important;" +
					"			margin: 0 auto !important;" +
					"		}" +

					"		img {" +
					"			-ms-interpolation-mode:bicubic;" +
					"		}" +
					"		a {" +
					"			text-decoration: none;" +
					"		}" +
					"		h1, h2, h3, h4, h5, h6 {" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"			color: #000000;" +
					"			margin-top: 0;" +
					"		}" +

					"		.logo h1{" +
					"			margin: 0;" +
					"		}" +
					"		.logo h1 a{" +
					"			color: #797979;" +
					"			font-size: 20px;" +
					"			font-weight: 700;" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"		}" +

					"	</style>" +
					"</head>" +
					"	<body class='respond' leftmargin='0' topmargin='0' marginwidth='0' marginheight='0'>" +
					"	<!-- header -->" +
					"	<table border='0' width='100%' cellpadding='0' cellspacing='0' bgcolor='ffffff'>" +
					"		<tr>" +
					"			<td align='center' style='background-color: #f1f1f1;'>" +
					"				<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' class='container590'>" +
					"					<tr>" +
					"						<td align='center'>" +
					"							<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff;'>" +
					"								<tr>" +
					"									<td align='center' style='padding: 1em 2.5em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td width='16%' class='logo' style='text-align: left; padding: 10px'>" +
					"													<h1><a style='color: #000; font-size: 10px; font-weight: 700; text-transform: uppercase;' href='https://www.asae.com.mx/'><img src='https://www.asae.com.mx/images/Tickets/LogoAsae.png' alt='' style='width: 100%; max-width: 500px; height: auto; margin: auto; display: block;'></a></h1>" +
					"												  </td>" +
					"												  <td width='55%' class='logo' style='text-align: right;'>" +
					"													<table width='100%' border='0' cellpadding='0' cellspacing='0' style='border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;' class='container590 hide'>" +
					"														<tr>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500; '>" +
					"																<a href='https://www.asae.com.mx/' style='color: #adadad;'>Inicio </a>" +
					"															</td>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
					"																<a href='https://www.asae.com.mx/corporativo-e-industria' style='color: #adadad;'>Corporativo e industria </a>" +
					"															</td>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
					"																<a href='https://www.asae.com.mx/contacto/atencion-a-clientes' style='color: #adadad;'>Contacto </a>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												  </td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #fafafa; padding: 0.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 0em 4em;'>" +
					"													<P style='font-size: 32px;color: #b53c3c; font-size: 32px; '><strong>Corporativo e industria</strong></P>" +
					"												</td>" +
					"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #b53c3c;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #d25050;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #ef7777;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 1.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"												</td>" +
					"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"													<p style='color: #b53c3c; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.3;'>" +
					"													Te agradecemos que nos hayas contactado, en breve un ejecutivo se comunicara contigo para atender tu solicitud y brindarte una cotización totalmente gratis.</p>" +
					"													<br>" +
					"												</td>" +
					"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					//"								<tr>" +
					//"									<td align='center' style=''>" +
					//"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 1.5em;'>" +
					//"											<tr>" +
					//"												<td align='center' style='padding: 1em 4em;'>" +
					//"												</td>" +
					//"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					//"										</table>" +
					//"									</td>" +
					//"								</tr>" +
					"								<tr>" +
					"									<td align='center' valign='middle' class='hero bg_white' style=' position: relative; z-index: 0;'>" +
					"									  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%' >" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td class='text' style='text-align: left; padding: 20px 30px;'>" +
					"															<h2 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>Grandes productos, grandes socios.</h2>" +
					"															<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'> <strong>Proveedor líder mundial de productos y soluciones de videovigilancia. Un socio enfocado en todas las demandas de videovigilancia del mercado de seguridad global.</p>" +
					"															<p><a href='https://www.asae.com.mx/corporativo-e-industria' style='border-radius: 5px;background: #b53c3c; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"												</td>" +
					"												<td valign='middle' width='50%'>" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td>" +
					"														<img src='https://www.asae.com.mx/01/Hikvision/camaras-de-vigilancia-hikvsion.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #b53c3c;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #d25050;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #ef7777;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"													<br><br>" +
					"													<h2 style='color: #000000; font-size: 28px; margin-top: 0; font-weight: 400;'>LAS MEJORES HERRAMIENTAS EN LA ADMINISTRACIÓN Y CONTROL DE PROYECTOS</h2>" +
					"													<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'>Incrementa el 30 por ciento de productividad, con herramientas que analizan y miden el tiempo de trabajo de tu personal.</p>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								<tr>" +
					"								<tr>" +
					"									<td style='padding: 1em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/blog-1.jpg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400;'>JobCTRL </h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Software para documentar analizar mejorar el tiempo de trabajo.</span></p>		" +
					"																<p><a href='https://www.asae.com.mx/jobctrl' style='border-radius: 5px;background: #b53c3c; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/huawei.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>Huawei-Ideahub</h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>El nuevo estilo de oficina inteligente. </span></p>		" +
					"																<p><a href='https://www.asae.com.mx/huawei-ideahub' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td style='padding: 2.5em; background: #000000; color: #9E9E9E'>" +
					"										<table align='center' role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
					"												<tr>" +
					"													<td valign='middle' class='bg_black footer email-section'>" +
					"														<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<p style='font-size: 22px; margin-top: 0;'>Dirección: Margaritas 426, Álvaro Obregón, Ciudad de México</p>" +
					"																</td>" +
					"															</tr>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<p style='margin-top: 0; font-size: 14px; '>¿Quieres recibir más correos electrónicos con nuestras nuevas herramientas y promociones? Usted puede <a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='font-size: 14px; color: #00afc5;'>Darse de alta aquí</a></p>" +
					"																</td>" +
					"															</tr>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<table>" +
					"																		<tr>" +
					"																			<td>" +
					"																				<a href='https://twitter.com/asaeconsultores'>" +
					"																					<img src='https://www.asae.com.mx/01/004-twitter-logo.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
					"																				</a>" +
					"																			</td>" +
					"																			<td>" +
					"																				<a href='https://www.facebook.com/AsaeConsultoresMX/'>" +
					"																					<img src='https://www.asae.com.mx/01/005-facebook.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
					"																				</a>" +
					"																			</td>" +
					"																		</tr>" +
					"																	</table>" +
					"																</td>" +
					"															</tr>" +
					"													</table>" +
					"													</td>" +
					"												</tr>" +
					"											  </table>" +
					"									</td>" +
					"								</tr>" +
					"							</table>" +
					"						</td>" +
					"					</tr>" +
					"					<tr>" +
					"						<td height='25' style='font-size: 25px; line-height: 25px;'>&nbsp;</td>" +
					"					</tr>" +
					"				</table>" +
					"			</td>" +
					"		</tr>" +
					"	</table>" +
					"	<!-- end header -->" +
					"	</body>" +
					"</html>";

			return HTML;

		}


		/************************************************************************************************************/
		/************************************************************************************************************/

		public Models.Mensaje AsaeWebSolicitudInformacionServiciosSoluciones(Models.Usuario usuario)
		{
			Models.Mensaje mensaje = new Models.Mensaje();
			mensaje = ValidarSolicitud(usuario);

			if (mensaje.Respuesta == 1)
			{
				Models.Email email = new Models.Email();
				email.nombre = usuario.Nombre;
				email.email = usuario.CorreoPersonal;
				email.asunto = "Solicitud de información - Soluciones tecnológicas para tu empresa ";
				email.mensaje = "";
				email.telefono = usuario.TelefonoMovil;
				email.telefonolocal = usuario.TelefonoLocal;
				email.Empresa = usuario.Empresa;
				email.App = 28;

				mensaje = dtUser.AsaeWebSolicitudesApp(email);

				if (mensaje.Respuesta == 1)
				{
					mensaje.RespuestaText = NuevaSolicitudInformacionServiciosSoluciones(usuario);
				}
			}
			return mensaje;
		}

		public string NuevaSolicitudInformacionServiciosSoluciones(Models.Usuario Musuario)
		{
			string respuesta = "";

			string host = "mail.asae.com.mx";
			int puerto = 25;
			string usuario = "asae_contactanos@asae.com.mx";
			string contra = "A$ae2018$$_";
			string pCorreo = Musuario.CorreoPersonal.ToString().Trim();

			MailMessage correo = new MailMessage();
			correo.To.Add(new MailAddress(pCorreo));
			correo.CC.Add("asae_contactanos@asae.com.mx");
			correo.CC.Add("francisco.acevedo@asae.com.mx");
			correo.From = new MailAddress(usuario, "ASAE CONSULTORES, S.A DE C.V");
			correo.Subject = "Solicitud de información - Soluciones tecnológicas para tu empresa ";
			correo.Body = HTMLInformacionServiciosSoluciones();

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
				respuesta = "ok";
			}
			catch (Exception ex)
			{
				respuesta = "Error: " + ex.Message;
			}

			return respuesta;
		}

		public string HTMLInformacionServiciosSoluciones()
		{
			string HTML = "";
			HTML += "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
					"<html xmlns:v='urn:schemas-microsoft-com:vml'>" +
					"<head>" +
					"	<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />" +
					"	<meta name='viewport' content='width=device-width; initial-scale=1.0; maximum-scale=1.0;' />" +

					"	<link href='https://fonts.googleapis.com/css?family=Nunito+Sans:200,300,400,600,700' rel='stylesheet'>" +
					"	<!--<![endif]-->" +
					"	<title>Asae Consultores S.A de C.V</title>" +
					"	<style type='text/css'>" +
					"		body {" +
					"			width: 100%;" +
					"			background-color: #ffffff;" +
					"			margin: 0;" +
					"			padding: 0;" +
					"			-webkit-font-smoothing: antialiased;" +
					"			mso-margin-top-alt: 0px;" +
					"			mso-margin-bottom-alt: 0px;" +
					"			mso-padding-alt: 0px 0px 0px 0px;" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"		}" +
					"		* {" +
					"			-ms-text-size-adjust: 100%;" +
					"			-webkit-text-size-adjust: 100%;" +
					"		}" +
					"		div[style*='margin: 16px 0'] {" +
					"			margin: 0 !important;" +
					"		}" +

					"		table," +
					"		td {" +
					"			mso-table-lspace: 0pt !important;" +
					"			mso-table-rspace: 0pt !important;" +
					"		}" +

					"		table {" +
					"			border-spacing: 0 !important;" +
					"			border-collapse: collapse !important;" +
					"			table-layout: fixed !important;" +
					"			margin: 0 auto !important;" +
					"		}" +

					"		img {" +
					"			-ms-interpolation-mode:bicubic;" +
					"		}" +
					"		a {" +
					"			text-decoration: none;" +
					"		}" +
					"		h1, h2, h3, h4, h5, h6 {" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"			color: #000000;" +
					"			margin-top: 0;" +
					"		}" +

					"		.logo h1{" +
					"			margin: 0;" +
					"		}" +
					"		.logo h1 a{" +
					"			color: #797979;" +
					"			font-size: 20px;" +
					"			font-weight: 700;" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"		}" +

					"	</style>" +
					"</head>" +
					"	<body class='respond' leftmargin='0' topmargin='0' marginwidth='0' marginheight='0'>" +
					"	<!-- header -->" +
					"	<table border='0' width='100%' cellpadding='0' cellspacing='0' bgcolor='ffffff'>" +
					"		<tr>" +
					"			<td align='center' style='background-color: #f1f1f1;'>" +
					"				<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' class='container590'>" +
					"					<tr>" +
					"						<td align='center'>" +
					"							<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff;'>" +
					"								<tr>" +
					"									<td align='center' style='padding: 1em 2.5em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td width='16%' class='logo' style='text-align: left; padding: 10px'>" +
					"													<h1><a style='color: #000; font-size: 10px; font-weight: 700; text-transform: uppercase;' href='https://www.asae.com.mx/'><img src='https://www.asae.com.mx/images/Tickets/LogoAsae.png' alt='' style='width: 100%; max-width: 500px; height: auto; margin: auto; display: block;'></a></h1>" +
					"												  </td>" +
					"												  <td width='55%' class='logo' style='text-align: right;'>" +
					"													<table width='100%' border='0' cellpadding='0' cellspacing='0' style='border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;' class='container590 hide'>" +
					"														<tr>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500; '>" +
					"																<a href='https://www.asae.com.mx/' style='color: #adadad;'>Inicio </a>" +
					"															</td>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
					"																<a href='https://www.asae.com.mx/servicios-y-soluciones' style='color: #adadad;'>Soluciones tecnológicas para tu empresa </a>" +
					"															</td>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
					"																<a href='https://www.asae.com.mx/contacto/atencion-a-clientes' style='color: #adadad;'>Contacto </a>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												  </td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #fafafa; padding: 0.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 0em 4em;'>" +
					"													<P style='font-size: 32px;color: #316192; font-size: 32px; '><strong>Soluciones tecnológicas para tu empresa</strong></P>" +
					"												</td>" +
					"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #316192;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #387ABD;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #4391E0;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 1.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"												</td>" +
					"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"													<p style='color: #316192; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.3;'>" +
					"													Te agradecemos que nos hayas contactado, en breve un ejecutivo se comunicara contigo para atender tu solicitud y brindarte una cotización totalmente gratis.</p>" +
					"													<br>" +
					"												</td>" +
					"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					//"								<tr>" +
					//"									<td align='center' style=''>" +
					//"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 1.5em;'>" +
					//"											<tr>" +
					//"												<td align='center' style='padding: 1em 4em;'>" +
					//"												</td>" +
					//"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					//"										</table>" +
					//"									</td>" +
					//"								</tr>" +
					"								<tr>" +
					"									<td align='center' valign='middle' class='hero bg_white' style=' position: relative; z-index: 0;'>" +
					"									  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%' >" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td class='text' style='text-align: left; padding: 20px 30px;'>" +
					"															<h2 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>Grandes productos, grandes socios.</h2>" +
					"															<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'> <strong>Somos la empresa #1 integradora de tecnología para empresas nacionales e internacionales, abarcando productos y servicios para mercados verticales y soluciones horizontales ...</p>" +
					"															<p><a href='https://www.asae.com.mx/servicios-y-soluciones' style='border-radius: 5px;background: #316192; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"												</td>" +
					"												<td valign='middle' width='50%'>" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td>" +
					"														<img src='https://www.asae.com.mx/01/ServiciosSoluciones/edificios.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #316192;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #387ABD;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #4391E0;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					//"								<tr>" +
					//"									<td>" +
					//"										<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
					//"											<tr>" +
					//"												<td align='center' style='padding: 1em 4em;'>" +
					//"													<br><br>" +
					//"													<h2 style='color: #000000; font-size: 28px; margin-top: 0; font-weight: 400;'>LAS MEJORES HERRAMIENTAS EN LA ADMINISTRACIÓN Y CONTROL DE PROYECTOS</h2>" +
					//"													<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'>Incrementa el 30 por ciento de productividad, con herramientas que analizan y miden el tiempo de trabajo de tu personal.</p>" +
					//"												</td>" +
					//"											</tr>" +
					//"										</table>" +
					//"									</td>" +
					//"								<tr>" +
					"								<tr>" +
					"									<td style='padding: 1em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/oficinas.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>Eventos Corporativos</h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Haz tus eventos corporativos en un entorno inteligente y dinámico </span></p>		" +
					"																<p><a href='https://www.asae.com.mx/eventos-corporativos' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/huawei.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>Huawei-Ideahub</h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>El nuevo estilo de oficina inteligente. </span></p>		" +
					"																<p><a href='https://www.asae.com.mx/huawei-ideahub' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td style='padding: 2.5em; background: #000000; color: #9E9E9E'>" +
					"										<table align='center' role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
					"												<tr>" +
					"													<td valign='middle' class='bg_black footer email-section'>" +
					"														<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<p style='font-size: 22px; margin-top: 0;'>Dirección: Margaritas 426, Álvaro Obregón, Ciudad de México</p>" +
					"																</td>" +
					"															</tr>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<p style='margin-top: 0; font-size: 14px; '>¿Quieres recibir más correos electrónicos con nuestras nuevas herramientas y promociones? Usted puede <a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='font-size: 14px; color: #00afc5;'>Darse de alta aquí</a></p>" +
					"																</td>" +
					"															</tr>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<table>" +
					"																		<tr>" +
					"																			<td>" +
					"																				<a href='https://twitter.com/asaeconsultores'>" +
					"																					<img src='https://www.asae.com.mx/01/004-twitter-logo.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
					"																				</a>" +
					"																			</td>" +
					"																			<td>" +
					"																				<a href='https://www.facebook.com/AsaeConsultoresMX/'>" +
					"																					<img src='https://www.asae.com.mx/01/005-facebook.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
					"																				</a>" +
					"																			</td>" +
					"																		</tr>" +
					"																	</table>" +
					"																</td>" +
					"															</tr>" +
					"													</table>" +
					"													</td>" +
					"												</tr>" +
					"											  </table>" +
					"									</td>" +
					"								</tr>" +
					"							</table>" +
					"						</td>" +
					"					</tr>" +
					"					<tr>" +
					"						<td height='25' style='font-size: 25px; line-height: 25px;'>&nbsp;</td>" +
					"					</tr>" +
					"				</table>" +
					"			</td>" +
					"		</tr>" +
					"	</table>" +
					"	<!-- end header -->" +
					"	</body>" +
					"</html>";

			return HTML;

		}


		/************************************************************************************************************/
		/************************************************************************************************************/

		public Models.Mensaje AsaeWebSolicitudInformacionTalentoHumano(Models.Usuario usuario)
		{
			Models.Mensaje mensaje = new Models.Mensaje();
			mensaje = ValidarSolicitud(usuario);

			if (mensaje.Respuesta == 1)
			{
				Models.Email email = new Models.Email();
				email.nombre = usuario.Nombre;
				email.email = usuario.CorreoPersonal;
				email.asunto = "Solicitud de información - reclutamos al mejor personal de ti para tu negocio ";
				email.mensaje = "";
				email.telefono = usuario.TelefonoMovil;
				email.telefonolocal = usuario.TelefonoLocal;
				email.Empresa = usuario.Empresa;
				email.App = 33;

				mensaje = dtUser.AsaeWebSolicitudesApp(email);

				if (mensaje.Respuesta == 1)
				{
					mensaje.RespuestaText = NuevaSolicitudInformacionTalentoHumano(usuario);
				}
			}
			return mensaje;
		}

		public string NuevaSolicitudInformacionTalentoHumano(Models.Usuario Musuario)
		{
			string respuesta = "";

			string host = "mail.asae.com.mx";
			int puerto = 25;
			string usuario = "asae_contactanos@asae.com.mx";
			string contra = "A$ae2018$$_";
			string pCorreo = Musuario.CorreoPersonal.ToString().Trim();

			MailMessage correo = new MailMessage();
			correo.To.Add(new MailAddress(pCorreo));
            correo.CC.Add("asae_contactanos@asae.com.mx");
			correo.CC.Add("francisco.acevedo@asae.com.mx");
			correo.From = new MailAddress(usuario, "ASAE CONSULTORES, S.A DE C.V");
			correo.Subject = "Solicitud de información - reclutamos al mejor personal de ti para tu negocio ";
			correo.Body = HTMLInformacionTalentoHumano();

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
				respuesta = "ok";
			}
			catch (Exception ex)
			{
				respuesta = "Error: " + ex.Message;
			}

			return respuesta;
		}

		public string HTMLInformacionTalentoHumano()
		{
			string HTML = "";
			HTML += "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
					"<html xmlns:v='urn:schemas-microsoft-com:vml'>" +
					"<head>" +
					"	<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />" +
					"	<meta name='viewport' content='width=device-width; initial-scale=1.0; maximum-scale=1.0;' />" +

					"	<link href='https://fonts.googleapis.com/css?family=Nunito+Sans:200,300,400,600,700' rel='stylesheet'>" +
					"	<!--<![endif]-->" +
					"	<title>Asae Consultores S.A de C.V</title>" +
					"	<style type='text/css'>" +
					"		body {" +
					"			width: 100%;" +
					"			background-color: #ffffff;" +
					"			margin: 0;" +
					"			padding: 0;" +
					"			-webkit-font-smoothing: antialiased;" +
					"			mso-margin-top-alt: 0px;" +
					"			mso-margin-bottom-alt: 0px;" +
					"			mso-padding-alt: 0px 0px 0px 0px;" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"		}" +
					"		* {" +
					"			-ms-text-size-adjust: 100%;" +
					"			-webkit-text-size-adjust: 100%;" +
					"		}" +
					"		div[style*='margin: 16px 0'] {" +
					"			margin: 0 !important;" +
					"		}" +

					"		table," +
					"		td {" +
					"			mso-table-lspace: 0pt !important;" +
					"			mso-table-rspace: 0pt !important;" +
					"		}" +

					"		table {" +
					"			border-spacing: 0 !important;" +
					"			border-collapse: collapse !important;" +
					"			table-layout: fixed !important;" +
					"			margin: 0 auto !important;" +
					"		}" +

					"		img {" +
					"			-ms-interpolation-mode:bicubic;" +
					"		}" +
					"		a {" +
					"			text-decoration: none;" +
					"		}" +
					"		h1, h2, h3, h4, h5, h6 {" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"			color: #000000;" +
					"			margin-top: 0;" +
					"		}" +

					"		.logo h1{" +
					"			margin: 0;" +
					"		}" +
					"		.logo h1 a{" +
					"			color: #797979;" +
					"			font-size: 20px;" +
					"			font-weight: 700;" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"		}" +

					"	</style>" +
					"</head>" +
					"	<body class='respond' leftmargin='0' topmargin='0' marginwidth='0' marginheight='0'>" +
					"	<!-- header -->" +
					"	<table border='0' width='100%' cellpadding='0' cellspacing='0' bgcolor='ffffff'>" +
					"		<tr>" +
					"			<td align='center' style='background-color: #f1f1f1;'>" +
					"				<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' class='container590'>" +
					"					<tr>" +
					"						<td align='center'>" +
					"							<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff;'>" +
					"								<tr>" +
					"									<td align='center' style='padding: 1em 2.5em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td width='16%' class='logo' style='text-align: left; padding: 10px'>" +
					"													<h1><a style='color: #000; font-size: 10px; font-weight: 700; text-transform: uppercase;' href='https://www.asae.com.mx/'><img src='https://www.asae.com.mx/images/Tickets/LogoAsae.png' alt='' style='width: 100%; max-width: 500px; height: auto; margin: auto; display: block;'></a></h1>" +
					"												  </td>" +
					"												  <td width='55%' class='logo' style='text-align: right;'>" +
					"													<table width='100%' border='0' cellpadding='0' cellspacing='0' style='border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;' class='container590 hide'>" +
					"														<tr>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500; '>" +
					"																<a href='https://www.asae.com.mx/' style='color: #adadad;'>Inicio </a>" +
					"															</td>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
					"																<a href='https://www.asae.com.mx/talento-humano' style='color: #adadad;'>¡RECLUTAMOS AL MEJOR PERSONAL DE TI PARA TU NEGOCIO! </a>" +
					"															</td>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
					"																<a href='https://www.asae.com.mx/contacto/atencion-a-clientes' style='color: #adadad;'>Contacto </a>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												  </td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #fafafa; padding: 0.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 0em 4em;'>" +
					"													<P style='font-size: 32px;color: #316192; font-size: 32px; '><strong>¡RECLUTAMOS AL MEJOR PERSONAL DE TI PARA TU NEGOCIO!</ strong></P>" +
					"												</td>" +
					"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #316192;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #387ABD;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #4391E0;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 1.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"												</td>" +
					"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"													<p style='color: #316192; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.3;'>" +
					"													Te agradecemos que nos hayas contactado, en breve un ejecutivo se comunicara contigo para atender tu solicitud y brindarte una cotización totalmente gratis.</p>" +
					"													<br>" +
					"												</td>" +
					"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					//"								<tr>" +
					//"									<td align='center' style=''>" +
					//"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 1.5em;'>" +
					//"											<tr>" +
					//"												<td align='center' style='padding: 1em 4em;'>" +
					//"												</td>" +
					//"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					//"										</table>" +
					//"									</td>" +
					//"								</tr>" +
					"								<tr>" +
					"									<td align='center' valign='middle' class='hero bg_white' style=' position: relative; z-index: 0;'>" +
					"									  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%' >" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td class='text' style='text-align: left; padding: 20px 30px;'>" +
					"															<h2 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>Grandes productos, grandes socios.</h2>" +
					"															<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'> <strong>Somos la empresa de reclutamiento más ágil y efectiva en México, con más de 30 años de experiencia colocando personal especializado en empresas nacionales e internacionales ...</p>" +
					"															<p><a href='https://www.asae.com.mx/talento-humano' style='border-radius: 5px;background: #316192; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"												</td>" +
					"												<td valign='middle' width='50%'>" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td>" +
					"														<img src='https://www.asae.com.mx/01/TalentoHumano/s.jpg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #316192;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #387ABD;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #4391E0;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					//"								<tr>" +
					//"									<td>" +
					//"										<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
					//"											<tr>" +
					//"												<td align='center' style='padding: 1em 4em;'>" +
					//"													<br><br>" +
					//"													<h2 style='color: #000000; font-size: 28px; margin-top: 0; font-weight: 400;'>LAS MEJORES HERRAMIENTAS EN LA ADMINISTRACIÓN Y CONTROL DE PROYECTOS</h2>" +
					//"													<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'>Incrementa el 30 por ciento de productividad, con herramientas que analizan y miden el tiempo de trabajo de tu personal.</p>" +
					//"												</td>" +
					//"											</tr>" +
					//"										</table>" +
					//"									</td>" +
					//"								<tr>" +
					"								<tr>" +
					"									<td style='padding: 1em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/oficinas.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>Eventos Corporativos</h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Haz tus eventos corporativos en un entorno inteligente y dinámico </span></p>		" +
					"																<p><a href='https://www.asae.com.mx/eventos-corporativos' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/huawei.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>Huawei-Ideahub</h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>El nuevo estilo de oficina inteligente. </span></p>		" +
					"																<p><a href='https://www.asae.com.mx/huawei-ideahub' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td style='padding: 2.5em; background: #000000; color: #9E9E9E'>" +
					"										<table align='center' role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
					"												<tr>" +
					"													<td valign='middle' class='bg_black footer email-section'>" +
					"														<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<p style='font-size: 22px; margin-top: 0;'>Dirección: Margaritas 426, Álvaro Obregón, Ciudad de México</p>" +
					"																</td>" +
					"															</tr>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<p style='margin-top: 0; font-size: 14px; '>¿Quieres recibir más correos electrónicos con nuestras nuevas herramientas y promociones? Usted puede <a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='font-size: 14px; color: #00afc5;'>Darse de alta aquí</a></p>" +
					"																</td>" +
					"															</tr>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<table>" +
					"																		<tr>" +
					"																			<td>" +
					"																				<a href='https://twitter.com/asaeconsultores'>" +
					"																					<img src='https://www.asae.com.mx/01/004-twitter-logo.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
					"																				</a>" +
					"																			</td>" +
					"																			<td>" +
					"																				<a href='https://www.facebook.com/AsaeConsultoresMX/'>" +
					"																					<img src='https://www.asae.com.mx/01/005-facebook.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
					"																				</a>" +
					"																			</td>" +
					"																		</tr>" +
					"																	</table>" +
					"																</td>" +
					"															</tr>" +
					"													</table>" +
					"													</td>" +
					"												</tr>" +
					"											  </table>" +
					"									</td>" +
					"								</tr>" +
					"							</table>" +
					"						</td>" +
					"					</tr>" +
					"					<tr>" +
					"						<td height='25' style='font-size: 25px; line-height: 25px;'>&nbsp;</td>" +
					"					</tr>" +
					"				</table>" +
					"			</td>" +
					"		</tr>" +
					"	</table>" +
					"	<!-- end header -->" +
					"	</body>" +
					"</html>";

			return HTML;

		}



		/************************************************************************************************************/
		/************************************************************************************************************/

		public Models.Mensaje AsaeWebSolicitudEventosCorporativos(Models.Usuario usuario)
		{
			Models.Mensaje mensaje = new Models.Mensaje();
			mensaje = ValidarSolicitud(usuario);

			if (mensaje.Respuesta == 1)
			{
				Models.Email email = new Models.Email();
				email.nombre = usuario.Nombre;
				email.email = usuario.CorreoPersonal;
				email.asunto = "Solicitud - Renta Espacios Corporativos";
				email.mensaje = "";
				email.telefono = usuario.TelefonoMovil;
				email.telefonolocal = usuario.TelefonoLocal;
				email.App = 27;

				mensaje = dtUser.AsaeWebSolicitudesApp(email);

				if (mensaje.Respuesta == 1)
				{
					mensaje.RespuestaText = NuevaSolicitudEventosCorporativos(usuario);
				}
			}
			return mensaje;
		}

		public string NuevaSolicitudEventosCorporativos(Models.Usuario Musuario)
		{
			string respuesta = "";

			string host = "mail.asae.com.mx";
			int puerto = 25;
			string usuario = "asae_contactanos@asae.com.mx";
			string contra = "A$ae2018$$_";
			string pCorreo = Musuario.CorreoPersonal.ToString().Trim();

			MailMessage correo = new MailMessage();
			correo.To.Add(new MailAddress(pCorreo));
			//correo.CC.Add("gabriel.cruz@asaeop.com.mx");
			correo.From = new MailAddress(usuario, "ASAE CONSULTORES, S.A DE C.V");
			correo.Subject = "Solicitud - Renta Espacios Corporativos";
			correo.Body = HTMLEventosCorporativosl();

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
				respuesta = "ok";
			}
			catch (Exception ex)
			{
				respuesta = "Error: " + ex.Message;
			}

			return respuesta;
		}

		public string HTMLEventosCorporativosl()
		{
			string HTML = "";
			HTML += "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
					"<html xmlns:v='urn:schemas-microsoft-com:vml'>" +
					"<head>" +
					"	<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />" +
					"	<meta name='viewport' content='width=device-width; initial-scale=1.0; maximum-scale=1.0;' />" +

					"	<link href='https://fonts.googleapis.com/css?family=Nunito+Sans:200,300,400,600,700' rel='stylesheet'>" +
					"	<!--<![endif]-->" +
					"	<title>Asae Consultores S.A de C.V</title>" +
					"	<style type='text/css'>" +
					"		body {" +
					"			width: 100%;" +
					"			background-color: #ffffff;" +
					"			margin: 0;" +
					"			padding: 0;" +
					"			-webkit-font-smoothing: antialiased;" +
					"			mso-margin-top-alt: 0px;" +
					"			mso-margin-bottom-alt: 0px;" +
					"			mso-padding-alt: 0px 0px 0px 0px;" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"		}" +
					"		* {" +
					"			-ms-text-size-adjust: 100%;" +
					"			-webkit-text-size-adjust: 100%;" +
					"		}" +
					"		div[style*='margin: 16px 0'] {" +
					"			margin: 0 !important;" +
					"		}" +

					"		table," +
					"		td {" +
					"			mso-table-lspace: 0pt !important;" +
					"			mso-table-rspace: 0pt !important;" +
					"		}" +

					"		table {" +
					"			border-spacing: 0 !important;" +
					"			border-collapse: collapse !important;" +
					"			table-layout: fixed !important;" +
					"			margin: 0 auto !important;" +
					"		}" +

					"		img {" +
					"			-ms-interpolation-mode:bicubic;" +
					"		}" +
					"		a {" +
					"			text-decoration: none;" +
					"		}" +
					"		h1, h2, h3, h4, h5, h6 {" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"			color: #000000;" +
					"			margin-top: 0;" +
					"		}" +

					"		.logo h1{" +
					"			margin: 0;" +
					"		}" +
					"		.logo h1 a{" +
					"			color: #797979;" +
					"			font-size: 20px;" +
					"			font-weight: 700;" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"		}" +

					"	</style>" +
					"</head>" +
					"	<body class='respond' leftmargin='0' topmargin='0' marginwidth='0' marginheight='0'>" +
					"	<!-- header -->" +
					"	<table border='0' width='100%' cellpadding='0' cellspacing='0' bgcolor='ffffff'>" +
					"		<tr>" +
					"			<td align='center' style='background-color: #f1f1f1;'>" +
					"				<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' class='container590'>" +
					"					<tr>" +
					"						<td align='center'>" +
					"							<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff;'>" +
					"								<tr>" +
					"									<td align='center' style='padding: 1em 2.5em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td width='16%' class='logo' style='text-align: left; padding: 10px'>" +
					"													<h1><a style='color: #000; font-size: 10px; font-weight: 700; text-transform: uppercase;' href='https://www.asae.com.mx/'><img src='https://www.asae.com.mx/images/Tickets/LogoAsae.png' alt='' style='width: 100%; max-width: 500px; height: auto; margin: auto; display: block;'></a></h1>" +
					"												  </td>" +
					"												  <td width='55%' class='logo' style='text-align: right;'>" +
					"													<table width='100%' border='0' cellpadding='0' cellspacing='0' style='border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;' class='container590 hide'>" +
					"														<tr>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500; '>" +
					"																<a href='https://www.asae.com.mx/' style='color: #adadad;'>Inicio </a>" +
					"															</td>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
					"																<a href='https://www.asae.com.mx/renta-espacios-corporativos' style='color: #adadad;'> Renta espacios corporativos </a>" +
					"															</td>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
					"																<a href='https://www.asae.com.mx/contacto/atencion-a-clientes' style='color: #adadad;'>Contacto </a>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												  </td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #fafafa; padding: 0.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 0em 4em;'>" +
					"													<P style='font-size: 32px;color: #223C60; font-size: 32px; '><strong>Renta De Espacios Corporativos</strong></P>" +
					"												</td>" +
					"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #223C60;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #38639F;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #3F7FD8;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					//"								<tr>" +
					//"									<td align='center' style=''>" +
					//"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 1.5em;'>" +
					//"											<tr>" +
					//"												<td align='center' style='padding: 1em 4em;'>" +
					//"												</td>" +
					//"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					//"										</table>" +
					//"									</td>" +
					//"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"													<p style='color: #223C60; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.3;'>" +
					"													Te agradecemos que nos hayas contactado, en breve un ejecutivo se comunicara contigo para atender tu solicitud.</p>" +
					"													<br>" +
					"												</td>" +
					"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 1.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"												</td>" +
					"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' valign='middle' class='hero bg_white' style=' position: relative; z-index: 0;'>" +
					"									  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%' >" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td class='text' style='text-align: left; padding: 20px 30px;'>" +
					"															<h2 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>Haz tus eventos corporativos en un entorno inteligente y dinámico.</h2>" +
					"															<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'> <strong>En ASAE tenemos espacios para todo tipo de eventos corporativos. </p>" +
					"															<p><a href='https://www.asae.com.mx/renta-espacios-corporativos' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"												</td>" +
					"												<td valign='middle' width='50%'>" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td>" +
					"														<img src='https://www.asae.com.mx/01/EventosCorporativos/salas.jpg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #223C60;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #38639F;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #3F7FD8;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"													<br><br>" +
					"													<h2 style='color: #000000; font-size: 28px; margin-top: 0; font-weight: 400;'>LAS MEJORES HERRAMIENTAS EN LA ADMINISTRACIÓN Y CONTROL DE PROYECTOS</h2>" +
					"													<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'>Incrementa el 30 por ciento de productividad, con herramientas que analizan y miden el tiempo de trabajo de tu personal.</p>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								<tr>" +
					"								<tr>" +
					"									<td style='padding: 1em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/blog-1.jpg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400;'>JobCTRL </h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Software para documentar analizar mejorar el tiempo de trabajo.</span></p>		" +
					"																<p><a href='https://www.asae.com.mx/jobctrl' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/huawei.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>Huawei-Ideahub</h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>El nuevo estilo de oficina inteligente. </span></p>		" +
					"																<p><a href='https://www.asae.com.mx/huawei-ideahub' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td style='padding: 2.5em; background: #000000; color: #9E9E9E'>" +
					"										<table align='center' role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
					"												<tr>" +
					"													<td valign='middle' class='bg_black footer email-section'>" +
					"														<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<p style='font-size: 22px; margin-top: 0;'>Dirección: Margaritas 426, Álvaro Obregón, Ciudad de México</p>" +
					"																</td>" +
					"															</tr>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<p style='margin-top: 0; font-size: 14px; '>¿Quieres recibir más correos electrónicos con nuestras nuevas herramientas y promociones? Usted puede <a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='font-size: 14px; color: #00afc5;'>Darse de alta aquí</a></p>" +
					"																</td>" +
					"															</tr>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<table>" +
					"																		<tr>" +
					"																			<td>" +
					"																				<a href='https://twitter.com/asaeconsultores'>" +
					"																					<img src='https://www.asae.com.mx/01/004-twitter-logo.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
					"																				</a>" +
					"																			</td>" +
					"																			<td>" +
					"																				<a href='https://www.facebook.com/AsaeConsultoresMX/'>" +
					"																					<img src='https://www.asae.com.mx/01/005-facebook.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
					"																				</a>" +
					"																			</td>" +
					"																		</tr>" +
					"																	</table>" +
					"																</td>" +
					"															</tr>" +
					"													</table>" +
					"													</td>" +
					"												</tr>" +
					"											  </table>" +
					"									</td>" +
					"								</tr>" +
					"							</table>" +
					"						</td>" +
					"					</tr>" +
					"					<tr>" +
					"						<td height='25' style='font-size: 25px; line-height: 25px;'>&nbsp;</td>" +
					"					</tr>" +
					"				</table>" +
					"			</td>" +
					"		</tr>" +
					"	</table>" +
					"	<!-- end header -->" +
					"	</body>" +
					"</html>";

			return HTML;

		}

		/************************************************************************************************************/
		/************************************************************************************************************/
		private Models.Mensaje ValidarSolicitud(Models.Usuario usuario)
		{
			Models.Mensaje mensaje = new Models.Mensaje();
			mensaje.Respuesta = 0;

			if (texto(usuario.Nombre))
			{
				if (telefono(usuario.TelefonoMovil))
				{
					if (usuario.TelefonoLocal.Length > 0)
					{
						if (telefono(usuario.TelefonoLocal))
						{
							mensaje.Respuesta = 1;
						}
						else
						{
							mensaje.RespuestaText = "Número telefónico incorrecto ";
						}
					}
					else
					{
						mensaje.Respuesta = 1;
					}
				}
				else
				{
					mensaje.RespuestaText = "Número telefónico incorrecto ";
				}
			}
			else
			{
				mensaje.RespuestaText = "El texto colocado en nombre es demasiado pequeño";
			}
			return mensaje;
		}

		private Models.Mensaje ValidarSolicitudCatalogoPrecios(Models.Usuario usuario)
		{
			Models.Mensaje mensaje = new Models.Mensaje();
			mensaje.Respuesta = 0;

			if (texto(usuario.Nombre))
			{
				mensaje.Respuesta = 1;
			}
			else
			{
				mensaje.RespuestaText = "El texto colocado en nombre es demasiado pequeño";
			}
			return mensaje;
		}

		/************************************************************************************************************/
		/************************************************************************************************************/

		public Models.Mensaje AsaeWebSolicitudDW(Models.Usuario usuario)
		{
			Models.Mensaje mensaje = new Models.Mensaje();
			mensaje = ValidarSolicitud(usuario);

			if (mensaje.Respuesta == 1)
			{
				Models.Email email = new Models.Email();
                email.nombre = usuario.Nombre;
                email.email = usuario.CorreoPersonal;
                email.telefono = usuario.TelefonoMovil;
                email.telefonolocal = usuario.TelefonoLocal;
				email.Empresa = usuario.Empresa;

				email.App = dtAsaeWebSeccion.AsaeWebSeccion_Seleccionar_Descripcion(usuario.Ingreso).Id;

                mensaje = dtUser.AsaeWebSolicitudDW(email);

				if (mensaje.Respuesta == 1)
				{
					 EnvioCorreoDW(usuario, email.App);
				}


			}
			return mensaje;
		}

		public string EnvioCorreoDW(Models.Usuario Musuario, int id)
        {
			string result = "";
			string copia = "";
			if(id == 28 || id == 33)
            {
				copia = "francisco.acevedo@asae.com.mx";
			}

			result = NuevaSolicitudDW(Musuario, copia);
			return result;
		}

		public string NuevaSolicitudDW(Models.Usuario Musuario, string copia)
		{
			string respuesta = "";

			string host = "mail.asae.com.mx";
			int puerto = 25;
			string usuario = "asae_contactanos@asae.com.mx";
			string contra = "A$ae2018$$_";
			string pCorreo = Musuario.CorreoPersonal.ToString().Trim();

			MailMessage correo = new MailMessage();
			correo.To.Add(new MailAddress(pCorreo));
			correo.CC.Add("asae_contactanos@asae.com.mx");
            if (copia.Length > 0)
            {
				correo.CC.Add(copia);
			}
			correo.From = new MailAddress(usuario, "ASAE CONSULTORES, S.A DE C.V");
			correo.Subject = "Nueva descarga de información web Asae consultores";
			correo.Body = AsaeWebSolicitudDWHTML(Musuario);

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
				respuesta = "ok";
			}
			catch (Exception ex)
			{
				respuesta = "Error: " + ex.Message;
			}

			return respuesta;
		}

		private string AsaeWebSolicitudDWHTML(Models.Usuario usuario)
		{
			string body = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
								"<html xmlns:v='urn:schemas-microsoft-com:vml'>" +
								"<head>" +
									"<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />" +
									"<meta name='viewport' content='width=device-width; initial-scale=1.0; maximum-scale=1.0;' />" +

									"<link href='https://fonts.googleapis.com/css?family=Nunito+Sans:200,300,400,600,700' rel='stylesheet'>" +
									"<!--<![endif]-->" +
									"<title>Asae Consultores S.A de C.V</title>" +
									"<style type='text/css'>" +
										"body {" +
											"width: 100%;" +
											"background-color: #ffffff;" +
											"margin: 0;" +
											"padding: 0;" +
											"-webkit-font-smoothing: antialiased;" +
											"mso-margin-top-alt: 0px;" +
											"mso-margin-bottom-alt: 0px;" +
											"mso-padding-alt: 0px 0px 0px 0px;" +
											"font-family: 'Proxima Nova',-apple-system,'Helvetica Neue',Helvetica,Roboto,Arial,sans-serif;" +
										"}" +
										"* {" +
											"-ms-text-size-adjust: 100%;" +
											"-webkit-text-size-adjust: 100%;" +
										"}" +
										"div[style*='margin: 16px 0'] {" +
											"margin: 0 !important;" +
										"}" +

										"table," +
										"td {" +
											"mso-table-lspace: 0pt !important;" +
											"mso-table-rspace: 0pt !important;" +
										"}" +

										"table {" +
											"border-spacing: 0 !important;" +
											"border-collapse: collapse !important;" +
											"table-layout: fixed !important;" +
											"margin: 0 auto !important;" +
										"}" +

										"img {" +
											"-ms-interpolation-mode:bicubic;" +
										"}" +
										"a {" +
											"text-decoration: none;" +
										"}" +
										"h1, h2, h3, h4, h5, h6 {" +
											"font-family: 'Nunito Sans', sans-serif;" +
											"color: #000000;" +
											"margin-top: 0;" +
										"}" +

										".logo h1{" +
											"margin: 0;" +
										"}" +
										".logo h1 a{" +
											"color: #3b3a38;" +
											"font-size: 20px;" +
											"font-weight: 700;" +
											"font-family: 'Nunito Sans', sans-serif;" +
										"}" +
									"</style>" +
								"</head>" +
									"<body class='respond' leftmargin='0' topmargin='0' marginwidth='0' marginheight='0'>" +
									"<!-- header -->" +
									"<table border='0' width='100%' cellpadding='0' cellspacing='0' bgcolor='ffffff'>" +
										"<tr>" +
											"<td align='center' style='background-color: #f1f1f1;'>" +
												"<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' class='container590'>" +
													"<tr>" +
														"<td align='center'>" +
															"<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff;'>" +
																"<tr>" +
																	"<td align='center' style='padding: 1em 2.5em;'>" +
																		"<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
																			"<tr>" +
																				"<td width='45%' class='logo' style='text-align: left; padding: 20px'>" +
																					"<h1><a href='https://www.asae.com.mx/'>Asae Consultores</a></h1>" +
																				  "</td>" +
																				  "<td width='55%' class='logo' style='text-align: right;'>" +
																				  "</td>" +
																			"</tr>" +
																		"</table>" +
																	"</td>" +
																"</tr>" +
																"<tr>" +
																	"<td align='center' valign='middle' class='hero bg_white' style=' background: #f1f1f1; position: relative; z-index: 0;'>" +
																	   "<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																			"<td valign='middle' width='50%' style='background: #f1f1f1;'>" +
																			  "<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																				"<tr>" +
																				  "<td class='text' style='text-align: left; padding: 20px 30px;'>" +
																						"<h2 style='color: #4282c3; font-size: 25px; margin-bottom: 0; font-weight: 200; line-height: 1.4; text-align: center;'>Nueva descarga de información web Asae consultores.</h2>" +
																				  "</td>" +
																				"</tr>" +
																			  "</table>" +
																			"</td>" +
																			"</tr>" +
																		"</table>" +
																	"</td>" +
																"</tr>" +
																"<tr>" +
																	"<td align='center' style=''>" +
																		"<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
																			"<tr>" +
																				"<td align='center' style='padding: 1em 4em;'>" +
																					"<h2 style='color: #4282c3; font-size: 20px; margin-top: 0; line-height: 3; font-weight: 400;'>Información registrada.</h2>" +
																					"<p style='font-size: 14px; line-height: 1.8; color: #a5a5a5;'>   La información fue descargada de la sección,  <strong> " + usuario.Ingreso + "  </strong></p>" +
																				"</td>" +
																			"</tr>" +
																			"<tr>" +
																				"<td>" +
																					"<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
																						"<tr>" +
																						  "<td valign='top' width='100%' style='padding-top: 20px;  padding: 5px 15px; ' class='services'>" +
																							"<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																							  "<tr>" +
																								"<td class='icon' colspan='2' style='margin-top: 0; font-size: 13px; text-align: center;'>" +
																								  "<img src='https://www.asae.com.mx/01/001-diet.png' alt='' style='width: 50px; max-width: 600px; height: auto; margin: auto; display: block;'>" +
																								  "<br>" +
																								  "<br>" +
																								"</td>" +
																							  "</tr>" +
																							  "<tr>" +
																								"<td style='margin-top: 0; font-size: 18px; text-align: center; background-color: #dcdcdc'>" +
																									"<p>Nombre </p>" +
																								"</td>" +
																								 "<td style='margin-top: 0; font-size: 18px; text-align: center; color: #878787; background-color: #dcdcdc'>" +
																									"<p>" + usuario.Nombre + "</p>" +
																								"</td>" +
																							  "</tr>" +
																							  "<tr>" +
																								"<td style='margin-top: 0; font-size: 18px; text-align: center; background-color: #dcdcdc'>" +
																									"<p>Empresa </p>" +
																								"</td>" +
																								 "<td style='margin-top: 0; font-size: 18px; text-align: center; color: #9E9E9E; background-color: #f3f3f3'>" +
																									"<p>" + usuario.Empresa + "</p>" +
																								"</td>" +
																							  "</tr>" +
																								"<tr>" +
																									"<td style='margin-top: 0; font-size: 18px; text-align: center; background-color: #dcdcdc'>" +
																										"<p>Correo personal  </p>" +
																									"</td>" +
																									"<td style='margin-top: 0; font-size: 18px; text-align: center; color: #dcdcdc; background-color: #d2d2d2'>" +
																										"<p>" + usuario.CorreoPersonal + "</p>" +
																									"</td>" +
																								"</tr>" +
																								"<tr>" +
																									"<td style='margin-top: 0; font-size: 18px; text-align: center; background-color: #dcdcdc'>" +
																										"<p>Teléfono móvil </p>" +
																									"</td>" +
																									"<td style='margin-top: 0; font-size: 18px; text-align: center; color: #9E9E9E; background-color: #f3f3f3'>" +
																										"<p>" + usuario.TelefonoMovil + "</p>" +
																									"</td>" +
																								"</tr>" +
																							"</table>" +
																						  "</td>" +
																						"</tr>" +
																					"</table>" +
																				"</td>" +
																			"<tr>" +
																		"</table>" +
																	"</td>" +
																"</tr>" +
																"<tr>" +
																	"<td>" +
																		"<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
																			"<tr>" +
																				"<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #015C90;'>" +
																					"<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																						"<tr>" +
																							"<td class='counter-text'>" +
																								"<span class='num'></span>" +
																							"</td>" +
																						"</tr>" +
																					"</table>" +
																				"</td>" +
																				"<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #0077BB;'>" +
																					"<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																						"<tr>" +
																							"<td class='counter-text'>" +
																								"<span class='num'></span>" +
																							"</td>" +
																						"</tr>" +
																					"</table>" +
																				"</td>" +
																				"<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #148CD1;'>" +
																					"<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																						"<tr>" +
																							"<td class='counter-text'>" +
																								"<span class='num'></span>" +
																							"</td>" +
																						"</tr>" +
																					"</table>" +
																				"</td>" +
																			"</tr>" +
																		"</table>" +
																	"</td>" +
																"</tr>" +
																
																"<tr>" +
																	"<td style='padding: 2.5em; background: #000000; color: #9E9E9E'>" +
																		"<table align='center' role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
																				"<tr>" +
																					"<td valign='middle' class='bg_black footer email-section'>" +
																						"<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
																							"<tr>" +
																								"<td width='100%' style='text-align: center;'>" +
																									"<p style='font-size: 18px; margin-top: 0;'><br></p>" +
																								"</td>" +
																							"</tr>" +
																							"<tr>" +
																								"<td width='100%' style='text-align: center;'>" +
																									

																								"</td>" +
																							"</tr>" +
																					"</table>" +
																					"</td>" +
																				"</tr>" +
																			  "</table>" +
																	"</td>" +
																"</tr>" +
															"</table>" +
														"</td>" +
													"</tr>" +
													"<tr>" +
														"<td height='25' style='font-size: 25px; line-height: 25px;'>&nbsp;</td>" +
													"</tr>" +
												"</table>" +
											"</td>" +
										"</tr>" +
									"</table>" +
									"<!-- end header -->" +
									"</body>" +
								"</html>" +

					   "";
			return body;
		}

		public Models.Mensaje CookieDW_Seleccionar(Models.Usuario usuario)
		{
			Models.Mensaje mensaje = new Models.Mensaje();

			mensaje = dtUser.CookieDW_Seleccionar(usuario);

			return mensaje;
		}




		/********************************************************************************************************************************************************************************************/
		/********************************************************************************************************************************************************************************************/
		public Models.Usuario Usuario_Login_IniciarSesion(Models.Usuario usuario)
		{
			return dtUser.Usuario_Login_IniciarSesion(usuario);
		}

		public Models.Usuario Usuario_Login_ClaveSesion(Models.Usuario usuario)
		{
			return dtUser.Usuario_Login_ClaveSesion(usuario);
		}




		/************************************************************************************************************/
		/************************************************************************************************************/
		/************************************************************************************************************/
		/************************************************************************************************************/

		public Models.Mensaje AsaeWebSolicitudPreciosIdeaHub(Models.Usuario usuario, string DirectorioArchivo)
		{
			Models.Mensaje mensaje = new Models.Mensaje();
			mensaje = ValidarSolicitudCatalogoPrecios(usuario);
			
			if (mensaje.Respuesta == 1)
			{
				Models.Email email = new Models.Email();
				email.nombre = usuario.Nombre;
				email.email = usuario.CorreoPersonal;
				email.asunto = "Solicitud de precios - IdeaHub";
				email.mensaje = "";
				email.telefono = usuario.TelefonoMovil;
				email.telefonolocal = usuario.TelefonoLocal;
				email.App = 6;

				mensaje = dtUser.AsaeWebSolicitudesApp(email);

				if (mensaje.Respuesta == 1)
				{
					mensaje.RespuestaText = NuevaSolicitudPreciosIdeaHub(usuario, DirectorioArchivo);
				}
			}
			return mensaje;
		}

		public string NuevaSolicitudPreciosIdeaHub(Models.Usuario Musuario, string DirectorioArchivo)
		{
			string respuesta = "";

			string host = "mail.asae.com.mx";
			int puerto = 25;
			string usuario = "asae_contactanos@asae.com.mx";
			string contra = "A$ae2018$$_";
			string pCorreo = Musuario.CorreoPersonal.ToString().Trim();


			string file = DirectorioArchivo;

			// Create  the file attachment for this email message.
			Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
			// Add time stamp information for the file.
			ContentDisposition disposition = data.ContentDisposition;
			disposition.CreationDate = System.IO.File.GetCreationTime(file);
			disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
			disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
			// Add the file attachment to this email message.
			


			MailMessage correo = new MailMessage();
			correo.To.Add(new MailAddress(pCorreo));
			correo.CC.Add("gabriel.cruz@asaeop.com.mx");
			correo.From = new MailAddress(usuario, "ASAE CONSULTORES, S.A DE C.V");
			correo.Subject = "Solicitud de precios - IdeaHub";
			correo.Body = HTMLPreciosIdeaHub();
			correo.Attachments.Add(data);

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
				respuesta = "ok";
			}
			catch (Exception ex)
			{
				respuesta = "Error: " + ex.Message;
			}

			return respuesta;
		}

		public string HTMLPreciosIdeaHub()
		{
			string HTML = "";
			HTML += "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
					"<html xmlns:v='urn:schemas-microsoft-com:vml'>" +
					"<head>" +
					"	<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />" +
					"	<meta name='viewport' content='width=device-width; initial-scale=1.0; maximum-scale=1.0;' />" +

					"	<link href='https://fonts.googleapis.com/css?family=Nunito+Sans:200,300,400,600,700' rel='stylesheet'>" +
					"	<!--<![endif]-->" +
					"	<title>Asae Consultores S.A de C.V</title>" +
					"	<style type='text/css'>" +
					"		body {" +
					"			width: 100%;" +
					"			background-color: #ffffff;" +
					"			margin: 0;" +
					"			padding: 0;" +
					"			-webkit-font-smoothing: antialiased;" +
					"			mso-margin-top-alt: 0px;" +
					"			mso-margin-bottom-alt: 0px;" +
					"			mso-padding-alt: 0px 0px 0px 0px;" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"		}" +
					"		* {" +
					"			-ms-text-size-adjust: 100%;" +
					"			-webkit-text-size-adjust: 100%;" +
					"		}" +
					"		div[style*='margin: 16px 0'] {" +
					"			margin: 0 !important;" +
					"		}" +

					"		table," +
					"		td {" +
					"			mso-table-lspace: 0pt !important;" +
					"			mso-table-rspace: 0pt !important;" +
					"		}" +

					"		table {" +
					"			border-spacing: 0 !important;" +
					"			border-collapse: collapse !important;" +
					"			table-layout: fixed !important;" +
					"			margin: 0 auto !important;" +
					"		}" +

					"		img {" +
					"			-ms-interpolation-mode:bicubic;" +
					"		}" +
					"		a {" +
					"			text-decoration: none;" +
					"		}" +
					"		h1, h2, h3, h4, h5, h6 {" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"			color: #000000;" +
					"			margin-top: 0;" +
					"		}" +

					"		.logo h1{" +
					"			margin: 0;" +
					"		}" +
					"		.logo h1 a{" +
					"			color: #797979;" +
					"			font-size: 20px;" +
					"			font-weight: 700;" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"		}" +

					"	</style>" +
					"</head>" +
					"	<body class='respond' leftmargin='0' topmargin='0' marginwidth='0' marginheight='0'>" +
					"	<!-- header -->" +
					"	<table border='0' width='100%' cellpadding='0' cellspacing='0' bgcolor='ffffff'>" +
					"		<tr>" +
					"			<td align='center' style='background-color: #f1f1f1;'>" +
					"				<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' class='container590'>" +
					"					<tr>" +
					"						<td align='center'>" +
					"							<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff;'>" +
					"								<tr>" +
					"									<td align='center' style='padding: 1em 2.5em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td width='16%' class='logo' style='text-align: left; padding: 10px'>" +
					"													<h1><a style='color: #000; font-size: 10px; font-weight: 700; text-transform: uppercase;' href='https://www.asae.com.mx/'><img src='https://www.asae.com.mx/images/Tickets/LogoAsae.png' alt='' style='width: 100%; max-width: 500px; height: auto; margin: auto; display: block;'></a></h1>" +
					"												  </td>" +
					"												  <td width='55%' class='logo' style='text-align: right;'>" +
					"													<table width='100%' border='0' cellpadding='0' cellspacing='0' style='border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;' class='container590 hide'>" +
					"														<tr>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500; '>" +
					"																<a href='https://www.asae.com.mx/' style='color: #adadad;'>Inicio </a>" +
					"															</td>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
					"																<a href='https://www.asae.com.mx/huawei-ideahub' style='color: #adadad;'>IdeaHub </a>" +
					"															</td>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
					"																<a href='https://www.asae.com.mx/contacto/atencion-a-clientes' style='color: #adadad;'>Contacto </a>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												  </td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #fafafa; padding: 0.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 0em 4em;'>" +
					"													<P style='font-size: 32px;color: #223C60; font-size: 32px; '><strong>IdeaHub </strong></P>" +
					"												</td>" +
					"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #223C60;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #355C91;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #3171C7;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 1.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"												</td>" +
					"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"													<p style='color: #223C60; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.3;'>" +
					"													Te agradecemos que nos hayas contactado, el cátalo de cotización viene adjunto al correo.</p>" +
					"													<br>" +
					"												</td>" +
					"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					//"								<tr>" +
					//"									<td align='center' style=''>" +
					//"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 1.5em;'>" +
					//"											<tr>" +
					//"												<td align='center' style='padding: 1em 4em;'>" +
					//"												</td>" +
					//"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					//"										</table>" +
					//"									</td>" +
					//"								</tr>" +
					"								<tr>" +
					"									<td align='center' valign='middle' class='hero bg_white' style=' position: relative; z-index: 0;'>" +
					"									  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%' >" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td class='text' style='text-align: left; padding: 20px 30px;'>" +
					"															<h2 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>IdeaHub de Huawei, una herramienta de productividad para la oficina inteligente, Incluye escritura inteligente, </h2>" +
					"															<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'> <strong>videoconferencias de alta definición (HD) y uso compartido inalámbrico.</p>" +
					"															<p><a href='https://www.asae.com.mx/huawei-ideahub' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"												</td>" +
					"												<td valign='middle' width='50%'>" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td>" +
					"														<img src='https://www.asae.com.mx/01/Ideahub/ideahub.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #223C60;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #355C91;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #3171C7;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"													<br><br>" +
					"													<h2 style='color: #000000; font-size: 28px; margin-top: 0; font-weight: 400;'>LAS MEJORES HERRAMIENTAS EN LA ADMINISTRACIÓN Y CONTROL DE PROYECTOS</h2>" +
					"													<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'>Incrementa el 30 por ciento de productividad, con herramientas que analizan y miden el tiempo de trabajo de tu personal.</p>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								<tr>" +
					"								<tr>" +
					"									<td style='padding: 1em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/blog-1.jpg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400;'>JobCTRL </h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Software para documentar analizar mejorar el tiempo de trabajo.</span></p>		" +
					"																<p><a href='https://www.asae.com.mx/jobctrl' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/oficinas.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>Eventos Corporativos</h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Haz tus eventos corporativos en un entorno inteligente y dinámico </span></p>		" +
					"																<p><a href='https://www.asae.com.mx/eventos-corporativos' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td style='padding: 2.5em; background: #000000; color: #9E9E9E'>" +
					"										<table align='center' role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
					"												<tr>" +
					"													<td valign='middle' class='bg_black footer email-section'>" +
					"														<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<p style='font-size: 22px; margin-top: 0;'>Dirección: Margaritas 426, Álvaro Obregón, Ciudad de México</p>" +
					"																</td>" +
					"															</tr>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<p style='margin-top: 0; font-size: 14px; '>¿Quieres recibir más correos electrónicos con nuestras nuevas herramientas y promociones? Usted puede <a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='font-size: 14px; color: #00afc5;'>Darse de alta aquí</a></p>" +
					"																</td>" +
					"															</tr>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<table>" +
					"																		<tr>" +
					"																			<td>" +
					"																				<a href='https://twitter.com/asaeconsultores'>" +
					"																					<img src='https://www.asae.com.mx/01/004-twitter-logo.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
					"																				</a>" +
					"																			</td>" +
					"																			<td>" +
					"																				<a href='https://www.facebook.com/AsaeConsultoresMX/'>" +
					"																					<img src='https://www.asae.com.mx/01/005-facebook.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
					"																				</a>" +
					"																			</td>" +
					"																		</tr>" +
					"																	</table>" +
					"																</td>" +
					"															</tr>" +
					"													</table>" +
					"													</td>" +
					"												</tr>" +
					"											  </table>" +
					"									</td>" +
					"								</tr>" +
					"							</table>" +
					"						</td>" +
					"					</tr>" +
					"					<tr>" +
					"						<td height='25' style='font-size: 25px; line-height: 25px;'>&nbsp;</td>" +
					"					</tr>" +
					"				</table>" +
					"			</td>" +
					"		</tr>" +
					"	</table>" +
					"	<!-- end header -->" +
					"	</body>" +
					"</html>";

			return HTML;

		}

		/************************************************************************************************************/
		/************************************************************************************************************/
		/************************************************************************************************************/
		/************************************************************************************************************/

		public Models.Mensaje AsaeWebSolicitudPreciosEventosCorporativos(Models.Usuario usuario, string DirectorioArchivo)
		{
			Models.Mensaje mensaje = new Models.Mensaje();
			mensaje = ValidarSolicitudCatalogoPrecios(usuario);

			if (mensaje.Respuesta == 1)
			{
				Models.Email email = new Models.Email();
				email.nombre = usuario.Nombre;
				email.email = usuario.CorreoPersonal;
				email.asunto = "Solicitud de precios - Renta De Espacios Corporativos";
				email.mensaje = "";
				email.telefono = usuario.TelefonoMovil;
				email.telefonolocal = usuario.TelefonoLocal;
				email.App = 27;

				mensaje = dtUser.AsaeWebSolicitudesApp(email);

				if (mensaje.Respuesta == 1)
				{
					mensaje.RespuestaText = NuevaSolicitudPreciosEventosCorporativos(usuario, DirectorioArchivo);
				}
			}
			return mensaje;
		}

		public string NuevaSolicitudPreciosEventosCorporativos(Models.Usuario Musuario, string DirectorioArchivo)
		{
			string respuesta = "";

			string host = "mail.asae.com.mx";
			int puerto = 25;
			string usuario = "asae_contactanos@asae.com.mx";
			string contra = "A$ae2018$$_";
			string pCorreo = Musuario.CorreoPersonal.ToString().Trim();


			string file = DirectorioArchivo;

			// Create  the file attachment for this email message.
			Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
			// Add time stamp information for the file.
			ContentDisposition disposition = data.ContentDisposition;
			disposition.CreationDate = System.IO.File.GetCreationTime(file);
			disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
			disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
			// Add the file attachment to this email message.

			MailMessage correo = new MailMessage();
			correo.To.Add(new MailAddress(pCorreo));
            correo.CC.Add("gabriel.cruz@asaeop.com.mx");
            correo.From = new MailAddress(usuario, "ASAE CONSULTORES, S.A DE C.V");
			correo.Subject = "Solicitud de precios - Eventos corporativos";
			correo.Body = HTMLPreciosEventosCorporativos();
			correo.Attachments.Add(data);

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
				respuesta = "ok";
			}
			catch (Exception ex)
			{
				respuesta = "Error: " + ex.Message;
			}

			return respuesta;
		}

		public string HTMLPreciosEventosCorporativos()
		{
			string HTML = "";
			HTML += "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
					"<html xmlns:v='urn:schemas-microsoft-com:vml'>" +
					"<head>" +
					"	<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />" +
					"	<meta name='viewport' content='width=device-width; initial-scale=1.0; maximum-scale=1.0;' />" +

					"	<link href='https://fonts.googleapis.com/css?family=Nunito+Sans:200,300,400,600,700' rel='stylesheet'>" +
					"	<!--<![endif]-->" +
					"	<title>Asae Consultores S.A de C.V</title>" +
					"	<style type='text/css'>" +
					"		body {" +
					"			width: 100%;" +
					"			background-color: #ffffff;" +
					"			margin: 0;" +
					"			padding: 0;" +
					"			-webkit-font-smoothing: antialiased;" +
					"			mso-margin-top-alt: 0px;" +
					"			mso-margin-bottom-alt: 0px;" +
					"			mso-padding-alt: 0px 0px 0px 0px;" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"		}" +
					"		* {" +
					"			-ms-text-size-adjust: 100%;" +
					"			-webkit-text-size-adjust: 100%;" +
					"		}" +
					"		div[style*='margin: 16px 0'] {" +
					"			margin: 0 !important;" +
					"		}" +

					"		table," +
					"		td {" +
					"			mso-table-lspace: 0pt !important;" +
					"			mso-table-rspace: 0pt !important;" +
					"		}" +

					"		table {" +
					"			border-spacing: 0 !important;" +
					"			border-collapse: collapse !important;" +
					"			table-layout: fixed !important;" +
					"			margin: 0 auto !important;" +
					"		}" +

					"		img {" +
					"			-ms-interpolation-mode:bicubic;" +
					"		}" +
					"		a {" +
					"			text-decoration: none;" +
					"		}" +
					"		h1, h2, h3, h4, h5, h6 {" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"			color: #000000;" +
					"			margin-top: 0;" +
					"		}" +

					"		.logo h1{" +
					"			margin: 0;" +
					"		}" +
					"		.logo h1 a{" +
					"			color: #797979;" +
					"			font-size: 20px;" +
					"			font-weight: 700;" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"		}" +

					"	</style>" +
					"</head>" +
					"	<body class='respond' leftmargin='0' topmargin='0' marginwidth='0' marginheight='0'>" +
					"	<!-- header -->" +
					"	<table border='0' width='100%' cellpadding='0' cellspacing='0' bgcolor='ffffff'>" +
					"		<tr>" +
					"			<td align='center' style='background-color: #f1f1f1;'>" +
					"				<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' class='container590'>" +
					"					<tr>" +
					"						<td align='center'>" +
					"							<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff;'>" +
					"								<tr>" +
					"									<td align='center' style='padding: 1em 2.5em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td width='16%' class='logo' style='text-align: left; padding: 10px'>" +
					"													<h1><a style='color: #000; font-size: 10px; font-weight: 700; text-transform: uppercase;' href='https://www.asae.com.mx/'><img src='https://www.asae.com.mx/images/Tickets/LogoAsae.png' alt='' style='width: 100%; max-width: 500px; height: auto; margin: auto; display: block;'></a></h1>" +
					"												  </td>" +
					"												  <td width='55%' class='logo' style='text-align: right;'>" +
					"													<table width='100%' border='0' cellpadding='0' cellspacing='0' style='border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;' class='container590 hide'>" +
					"														<tr>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500; '>" +
					"																<a href='https://www.asae.com.mx/' style='color: #adadad;'>Inicio </a>" +
					"															</td>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
					"																<a href='https://www.asae.com.mx/renta-espacios-corporativos' style='color: #adadad;'> Renta espacios corporativos </a>" +
					"															</td>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
					"																<a href='https://www.asae.com.mx/contacto/atencion-a-clientes' style='color: #adadad;'>Contacto </a>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												  </td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #fafafa; padding: 0.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 0em 4em;'>" +
					"													<P style='font-size: 32px;color: #223C60; font-size: 32px; '><strong>Renta de Espacios Corporativo </strong></P>" +
					"												</td>" +
					"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #223C60;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #38639F;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #3F7FD8;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 1.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"												</td>" +
					"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"													<p style='color: #223C60; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.3;'>" +
					"													Te agradecemos que nos hayas contactado, el cátalo de cotización viene adjunto al correo.</p>" +
					"													<br>" +
					"												</td>" +
					"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 1.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"												</td>" +
					"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' valign='middle' class='hero bg_white' style=' position: relative; z-index: 0;'>" +
					"									  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%' >" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td class='text' style='text-align: left; padding: 20px 30px;'>" +
					"															<h2 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>En ASAE tenemos espacios para todotipo de eventos corporativos. </h2>" +
					"															<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'> <strong>Haz tus eventos corporativos en un entorno inteligente y dinámico.</p>" +
					"															<p><a href='https://www.asae.com.mx/renta-espacios-corporativos' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"												</td>" +
					"												<td valign='middle' width='50%'>" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td>" +
					"														<img src='https://www.asae.com.mx/01/EventosCorporativos/salas.jpg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #223C60;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #38639F;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #3F7FD8;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"													<br><br>" +
					"													<h2 style='color: #000000; font-size: 28px; margin-top: 0; font-weight: 400;'>LAS MEJORES HERRAMIENTAS EN LA ADMINISTRACIÓN Y CONTROL DE PROYECTOS</h2>" +
					"													<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'>Incrementa el 30 por ciento de productividad, con herramientas que analizan y miden el tiempo de trabajo de tu personal.</p>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								<tr>" +
					"								<tr>" +
					"									<td style='padding: 1em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/blog-1.jpg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400;'>JobCTRL </h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Software para documentar analizar mejorar el tiempo de trabajo.</span></p>		" +
					"																<p><a href='https://www.asae.com.mx/jobctrl' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/huawei.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>Huawei-Ideahub</h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>El nuevo estilo de oficina inteligente. </span></p>		" +
					"																<p><a href='https://www.asae.com.mx/huawei-ideahub' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td style='padding: 2.5em; background: #000000; color: #9E9E9E'>" +
					"										<table align='center' role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
					"												<tr>" +
					"													<td valign='middle' class='bg_black footer email-section'>" +
					"														<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<p style='font-size: 22px; margin-top: 0;'>Dirección: Margaritas 426, Álvaro Obregón, Ciudad de México</p>" +
					"																</td>" +
					"															</tr>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<p style='margin-top: 0; font-size: 14px; '>¿Quieres recibir más correos electrónicos con nuestras nuevas herramientas y promociones? Usted puede <a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='font-size: 14px; color: #00afc5;'>Darse de alta aquí</a></p>" +
					"																</td>" +
					"															</tr>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<table>" +
					"																		<tr>" +
					"																			<td>" +
					"																				<a href='https://twitter.com/asaeconsultores'>" +
					"																					<img src='https://www.asae.com.mx/01/004-twitter-logo.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
					"																				</a>" +
					"																			</td>" +
					"																			<td>" +
					"																				<a href='https://www.facebook.com/AsaeConsultoresMX/'>" +
					"																					<img src='https://www.asae.com.mx/01/005-facebook.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
					"																				</a>" +
					"																			</td>" +
					"																		</tr>" +
					"																	</table>" +
					"																</td>" +
					"															</tr>" +
					"													</table>" +
					"													</td>" +
					"												</tr>" +
					"											  </table>" +
					"									</td>" +
					"								</tr>" +
					"							</table>" +
					"						</td>" +
					"					</tr>" +
					"					<tr>" +
					"						<td height='25' style='font-size: 25px; line-height: 25px;'>&nbsp;</td>" +
					"					</tr>" +
					"				</table>" +
					"			</td>" +
					"		</tr>" +
					"	</table>" +
					"	<!-- end header -->" +
					"	</body>" +
					"</html>";

			return HTML;

		}

		/************************************************************************************************************/
		/************************************************************************************************************/

		public Models.Mensaje AsaeWebSolicitudBanTotal(Models.Usuario usuario)
		{
			Models.Mensaje mensaje = new Models.Mensaje();
			mensaje = ValidarSolicitud(usuario);

			if (mensaje.Respuesta == 1)
			{
				Models.Email email = new Models.Email();
				email.nombre = usuario.Nombre;
				email.email = usuario.CorreoPersonal;
				email.asunto = "Solicitud - BanTotal";
				email.mensaje = "";
				email.telefono = usuario.TelefonoMovil;
				email.telefonolocal = usuario.TelefonoLocal;
				email.App = 26;

				mensaje = dtUser.AsaeWebSolicitudesApp(email);

				if (mensaje.Respuesta == 1)
				{
					mensaje.RespuestaText = NuevaSolicitudBanTotal(usuario);
				}
			}
			return mensaje;
		}

		public string NuevaSolicitudBanTotal(Models.Usuario Musuario)
		{
			string respuesta = "";

			string host = "mail.asae.com.mx";
			int puerto = 25;
			string usuario = "asae_contactanos@asae.com.mx";
			string contra = "A$ae2018$$_";
			string pCorreo = Musuario.CorreoPersonal.ToString().Trim();

			MailMessage correo = new MailMessage();
			correo.To.Add(new MailAddress(pCorreo));
			correo.CC.Add("oscar.maldonado@asae.com.mx");
			correo.From = new MailAddress(usuario, "ASAE CONSULTORES, S.A DE C.V");
			correo.Subject = "Solicitud - BanTotal";
			correo.Body = HTMLBanTotal();

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
				respuesta = "ok";
			}
			catch (Exception ex)
			{
				respuesta = "Error: " + ex.Message;
			}

			return respuesta;
		}

		public string HTMLBanTotal()
		{
			string HTML = "";
			HTML += "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
					"<html xmlns:v='urn:schemas-microsoft-com:vml'>" +
					"<head>" +
					"	<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />" +
					"	<meta name='viewport' content='width=device-width; initial-scale=1.0; maximum-scale=1.0;' />" +

					"	<link href='https://fonts.googleapis.com/css?family=Nunito+Sans:200,300,400,600,700' rel='stylesheet'>" +
					"	<!--<![endif]-->" +
					"	<title>Asae Consultores S.A de C.V</title>" +
					"	<style type='text/css'>" +
					"		body {" +
					"			width: 100%;" +
					"			background-color: #ffffff;" +
					"			margin: 0;" +
					"			padding: 0;" +
					"			-webkit-font-smoothing: antialiased;" +
					"			mso-margin-top-alt: 0px;" +
					"			mso-margin-bottom-alt: 0px;" +
					"			mso-padding-alt: 0px 0px 0px 0px;" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"		}" +
					"		* {" +
					"			-ms-text-size-adjust: 100%;" +
					"			-webkit-text-size-adjust: 100%;" +
					"		}" +
					"		div[style*='margin: 16px 0'] {" +
					"			margin: 0 !important;" +
					"		}" +

					"		table," +
					"		td {" +
					"			mso-table-lspace: 0pt !important;" +
					"			mso-table-rspace: 0pt !important;" +
					"		}" +

					"		table {" +
					"			border-spacing: 0 !important;" +
					"			border-collapse: collapse !important;" +
					"			table-layout: fixed !important;" +
					"			margin: 0 auto !important;" +
					"		}" +

					"		img {" +
					"			-ms-interpolation-mode:bicubic;" +
					"		}" +
					"		a {" +
					"			text-decoration: none;" +
					"		}" +
					"		h1, h2, h3, h4, h5, h6 {" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"			color: #000000;" +
					"			margin-top: 0;" +
					"		}" +

					"		.logo h1{" +
					"			margin: 0;" +
					"		}" +
					"		.logo h1 a{" +
					"			color: #797979;" +
					"			font-size: 20px;" +
					"			font-weight: 700;" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"		}" +

					"	</style>" +
					"</head>" +
					"	<body class='respond' leftmargin='0' topmargin='0' marginwidth='0' marginheight='0'>" +
					"	<!-- header -->" +
					"	<table border='0' width='100%' cellpadding='0' cellspacing='0' bgcolor='ffffff'>" +
					"		<tr>" +
					"			<td align='center' style='background-color: #f1f1f1;'>" +
					"				<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' class='container590'>" +
					"					<tr>" +
					"						<td align='center'>" +
					"							<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff;'>" +
					"								<tr>" +
					"									<td align='center' style='padding: 1em 2.5em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td width='16%' class='logo' style='text-align: left; padding: 10px'>" +
					"													<h1><a style='color: #000; font-size: 10px; font-weight: 700; text-transform: uppercase;' href='https://www.asae.com.mx/'><img src='https://www.asae.com.mx/images/Tickets/LogoAsae.png' alt='' style='width: 100%; max-width: 500px; height: auto; margin: auto; display: block;'></a></h1>" +
					"												  </td>" +
					"												  <td width='55%' class='logo' style='text-align: right;'>" +
					"													<table width='100%' border='0' cellpadding='0' cellspacing='0' style='border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;' class='container590 hide'>" +
					"														<tr>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500; '>" +
					"																<a href='https://www.asae.com.mx/' style='color: #adadad;'>Inicio </a>" +
					"															</td>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
					"																<a href='https://www.asae.com.mx/bantotal' style='color: #adadad;'> BanTotal </a>" +
					"															</td>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
					"																<a href='https://www.asae.com.mx/contacto/atencion-a-clientes' style='color: #adadad;'>Contacto </a>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												  </td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #fafafa; padding: 0.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 0em 4em;'>" +
					"													<P style='font-size: 32px;color: #223C60; font-size: 32px; '><strong>BanTotal</strong></P>" +
					"												</td>" +
					"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #223C60;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #38639F;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #3F7FD8;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					//"								<tr>" +
					//"									<td align='center' style=''>" +
					//"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 1.5em;'>" +
					//"											<tr>" +
					//"												<td align='center' style='padding: 1em 4em;'>" +
					//"												</td>" +
					//"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					//"										</table>" +
					//"									</td>" +
					//"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"													<p style='color: #223C60; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.3;'>" +
					"													Te agradecemos que nos hayas contactado, en breve un ejecutivo se comunicara contigo para atender tu solicitud.</p>" +
					"													<br>" +
					"												</td>" +
					"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					//"								<tr>" +
					//"									<td align='center' style=''>" +
					//"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 1.5em;'>" +
					//"											<tr>" +
					//"												<td align='center' style='padding: 1em 4em;'>" +
					//"												</td>" +
					//"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					//"										</table>" +
					//"									</td>" +
					//"								</tr>" +
					"								<tr>" +
					"									<td align='center' valign='middle' class='hero bg_white' style=' position: relative; z-index: 0;'>" +
					"									  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%' >" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td class='text' style='text-align: left; padding: 20px 30px;'>" +
					"															<h2 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>La plataforma bancaria completamente centrada en el cliente.</h2>" +
					"															<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'> <strong>Bantotal es la solución líder en latinoamérica que resuelve la operativa de misión crítica de las Instituciones Financieras en forma simple, completa y precisa.</p>" +
					"															<p><a href='https://www.asae.com.mx/bantotal' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"												</td>" +
					"												<td valign='middle' width='50%'>" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td>" +
					"														<img src='https://www.asae.com.mx/01/BanTotal/imageCorreo.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #223C60;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #38639F;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #3F7FD8;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"													<br><br>" +
					"													<h2 style='color: #000000; font-size: 28px; margin-top: 0; font-weight: 400;'>LAS MEJORES HERRAMIENTAS EN LA ADMINISTRACIÓN Y CONTROL DE PROYECTOS</h2>" +
					"													<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'>Incrementa el 30 por ciento de productividad, con herramientas que analizan y miden el tiempo de trabajo de tu personal.</p>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								<tr>" +
					"								<tr>" +
					"									<td style='padding: 1em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/blog-1.jpg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400;'>JobCTRL </h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Software para documentar analizar mejorar el tiempo de trabajo.</span></p>		" +
					"																<p><a href='https://www.asae.com.mx/jobctrl' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/huawei.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>Huawei-Ideahub</h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>El nuevo estilo de oficina inteligente. </span></p>		" +
					"																<p><a href='https://www.asae.com.mx/huawei-ideahub' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td style='padding: 2.5em; background: #000000; color: #9E9E9E'>" +
					"										<table align='center' role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
					"												<tr>" +
					"													<td valign='middle' class='bg_black footer email-section'>" +
					"														<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<p style='font-size: 22px; margin-top: 0;'>Dirección: Margaritas 426, Álvaro Obregón, Ciudad de México</p>" +
					"																</td>" +
					"															</tr>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<p style='margin-top: 0; font-size: 14px; '>¿Quieres recibir más correos electrónicos con nuestras nuevas herramientas y promociones? Usted puede <a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='font-size: 14px; color: #00afc5;'>Darse de alta aquí</a></p>" +
					"																</td>" +
					"															</tr>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<table>" +
					"																		<tr>" +
					"																			<td>" +
					"																				<a href='https://twitter.com/asaeconsultores'>" +
					"																					<img src='https://www.asae.com.mx/01/004-twitter-logo.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
					"																				</a>" +
					"																			</td>" +
					"																			<td>" +
					"																				<a href='https://www.facebook.com/AsaeConsultoresMX/'>" +
					"																					<img src='https://www.asae.com.mx/01/005-facebook.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
					"																				</a>" +
					"																			</td>" +
					"																		</tr>" +
					"																	</table>" +
					"																</td>" +
					"															</tr>" +
					"													</table>" +
					"													</td>" +
					"												</tr>" +
					"											  </table>" +
					"									</td>" +
					"								</tr>" +
					"							</table>" +
					"						</td>" +
					"					</tr>" +
					"					<tr>" +
					"						<td height='25' style='font-size: 25px; line-height: 25px;'>&nbsp;</td>" +
					"					</tr>" +
					"				</table>" +
					"			</td>" +
					"		</tr>" +
					"	</table>" +
					"	<!-- end header -->" +
					"	</body>" +
					"</html>";

			return HTML;

		}

        /************************************************************************************************************/

        public Models.Mensaje AsaeWebSolicitudBanTotalAMSOFIPO(Models.Usuario usuario)
        {
            Models.Mensaje mensaje = new Models.Mensaje();
            mensaje = ValidarSolicitud(usuario);

            if (mensaje.Respuesta == 1)
            {
                Models.Email email = new Models.Email();
                email.nombre = usuario.Nombre;
                email.email = usuario.CorreoPersonal;
                email.asunto = "Solicitud - BanTotal patrocinador en AMSOFIPO 2023";
                email.mensaje = "";
                email.telefono = usuario.TelefonoMovil;
                email.telefonolocal = usuario.TelefonoLocal;
                email.App = 26;

                mensaje = dtUser.AsaeWebSolicitudesApp(email);

                if (mensaje.Respuesta == 1)
                {
                    mensaje.RespuestaText = NuevaSolicitudBanTotalAMSOFIPO(usuario);
                }
            }
            return mensaje;
        }

        public string NuevaSolicitudBanTotalAMSOFIPO(Models.Usuario Musuario)
        {
            string respuesta = "";

            string host = "mail.asae.com.mx";
            int puerto = 25;
            string usuario = "asae_contactanos@asae.com.mx";
            string contra = "A$ae2018$$_";
            string pCorreo = Musuario.CorreoPersonal.ToString().Trim();

            MailMessage correo = new MailMessage();
            correo.To.Add(new MailAddress(pCorreo));
            correo.CC.Add("oscar.maldonado@asae.com.mx");
            correo.CC.Add("marisela.savinon@asae.com.mx");
            correo.From = new MailAddress(usuario, "ASAE CONSULTORES, S.A DE C.V");
            correo.Subject = "Solicitud - BanTotal patrocinador en AMSOFIPO 2023";
            correo.Body = HTMLBanTotalAMSOFIPO(Musuario);

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
                respuesta = "ok";
            }
            catch (Exception ex)
            {
                respuesta = "Error: " + ex.Message;
            }

            return respuesta;
        }

        public string HTMLBanTotalAMSOFIPO(Models.Usuario Musuario)
        {
            string HTML = "";
            HTML += "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
                    "<html xmlns:v='urn:schemas-microsoft-com:vml'>" +
                    "<head>" +
                    "	<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />" +
                    "	<meta name='viewport' content='width=device-width; initial-scale=1.0; maximum-scale=1.0;' />" +

                    "	<link href='https://fonts.googleapis.com/css?family=Nunito+Sans:200,300,400,600,700' rel='stylesheet'>" +
                    "	<!--<![endif]-->" +
                    "	<title>Asae Consultores S.A de C.V</title>" +
                    "	<style type='text/css'>" +
                    "		body {" +
                    "			width: 100%;" +
                    "			background-color: #ffffff;" +
                    "			margin: 0;" +
                    "			padding: 0;" +
                    "			-webkit-font-smoothing: antialiased;" +
                    "			mso-margin-top-alt: 0px;" +
                    "			mso-margin-bottom-alt: 0px;" +
                    "			mso-padding-alt: 0px 0px 0px 0px;" +
                    "			font-family: 'Nunito Sans', sans-serif;" +
                    "		}" +
                    "		* {" +
                    "			-ms-text-size-adjust: 100%;" +
                    "			-webkit-text-size-adjust: 100%;" +
                    "		}" +
                    "		div[style*='margin: 16px 0'] {" +
                    "			margin: 0 !important;" +
                    "		}" +

                    "		table," +
                    "		td {" +
                    "			mso-table-lspace: 0pt !important;" +
                    "			mso-table-rspace: 0pt !important;" +
                    "		}" +

                    "		table {" +
                    "			border-spacing: 0 !important;" +
                    "			border-collapse: collapse !important;" +
                    "			table-layout: fixed !important;" +
                    "			margin: 0 auto !important;" +
                    "		}" +

                    "		img {" +
                    "			-ms-interpolation-mode:bicubic;" +
                    "		}" +
                    "		a {" +
                    "			text-decoration: none;" +
                    "		}" +
                    "		h1, h2, h3, h4, h5, h6 {" +
                    "			font-family: 'Nunito Sans', sans-serif;" +
                    "			color: #000000;" +
                    "			margin-top: 0;" +
                    "		}" +

                    "		.logo h1{" +
                    "			margin: 0;" +
                    "		}" +
                    "		.logo h1 a{" +
                    "			color: #797979;" +
                    "			font-size: 20px;" +
                    "			font-weight: 700;" +
                    "			font-family: 'Nunito Sans', sans-serif;" +
                    "		}" +

                    "	</style>" +
                    "</head>" +
                    "	<body class='respond' leftmargin='0' topmargin='0' marginwidth='0' marginheight='0'>" +
                    "	<!-- header -->" +
                    "	<table border='0' width='100%' cellpadding='0' cellspacing='0' bgcolor='ffffff'>" +
                    "		<tr>" +
                    "			<td align='center' style='background-color: #f1f1f1;'>" +
                    "				<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' class='container590'>" +
                    "					<tr>" +
                    "						<td align='center'>" +
                    "							<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff;'>" +
                    "								<tr>" +
                    "									<td align='center' style='padding: 1em 2.5em;'>" +
                    "										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
                    "											<tr>" +
                    "												<td width='16%' class='logo' style='text-align: left; padding: 10px'>" +
                    "													<h1><a style='color: #000; font-size: 10px; font-weight: 700; text-transform: uppercase;' href='https://www.asae.com.mx/'><img src='https://www.asae.com.mx/images/Tickets/LogoAsae.png' alt='' style='width: 100%; max-width: 500px; height: auto; margin: auto; display: block;'></a></h1>" +
                    "												  </td>" +
                    "												  <td width='55%' class='logo' style='text-align: right;'>" +
                    "													<table width='100%' border='0' cellpadding='0' cellspacing='0' style='border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;' class='container590 hide'>" +
                    "														<tr>" +
                    "															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500; '>" +
                    "																<a href='https://www.asae.com.mx/' style='color: #adadad;'>Inicio </a>" +
                    "															</td>" +
                    "															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
                    "																<a href='https://www.asae.com.mx/bantotal' style='color: #adadad;'> BanTotal </a>" +
                    "															</td>" +
                    "															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
                    "																<a href='https://www.asae.com.mx/contacto/atencion-a-clientes' style='color: #adadad;'>Contacto </a>" +
                    "															</td>" +
                    "														</tr>" +
                    "													</table>" +
                    "												  </td>" +
                    "											</tr>" +
                    "										</table>" +
                    "									</td>" +
                    "								</tr>" +
                    "								<tr>" +
                    "									<td align='center' style=''>" +
                    "										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #fafafa; padding: 0.5em;'>" +
                    "											<tr>" +
                    "												<td align='center' style='padding: 0em 4em;'>" +
                    "													<P style='font-size: 32px;color: #223C60; font-size: 32px; '><strong>BanTotal</strong></P>" +
                    "												</td>" +
                    "											</tr>" +
                    //"											<tr>" +
                    //"												<td>" +
                    //"												</td>" +
                    //"											<tr>" +
                    "										</table>" +
                    "									</td>" +
                    "								</tr>" +
                    "								<tr>" +
                    "									<td>" +
                    "										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
                    "											<tr>" +
                    "												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #223C60;'>" +
                    "													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
                    "														<tr>" +
                    "															<td class='counter-text'>" +
                    "																<span class='num'></span>" +
                    "															</td>" +
                    "														</tr>" +
                    "													</table>" +
                    "												</td>" +
                    "												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #38639F;'>" +
                    "													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
                    "														<tr>" +
                    "															<td class='counter-text'>" +
                    "																<span class='num'></span>" +
                    "															</td>" +
                    "														</tr>" +
                    "													</table>" +
                    "												</td>" +
                    "												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #3F7FD8;'>" +
                    "													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
                    "														<tr>" +
                    "															<td class='counter-text'>" +
                    "																<span class='num'></span>" +
                    "															</td>" +
                    "														</tr>" +
                    "													</table>" +
                    "												</td>" +
                    "											</tr>" +
                    "										</table>" +
                    "									</td>" +
                    "								</tr>" +
                    "								<tr>" +
                    "									<td align='center' style=''>" +
                    "										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 1.5em;'>" +
                    "											<tr>" +
                    "												<td align='center' style='padding: 1em 4em;'>" +
                    "													<p style = 'color: #223C60; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.3;' > " +
                    "													Te agradecemos que nos hayas contactado, en breve un ejecutivo se comunicara contigo para atender tu solicitud.</p>" +
                    "													<br>" +
                    "												</td>" +
                    "											</tr>" +
                    "											<tr>" +
                    "												<td>" +
                    "												</td>" +
                    "											<tr>" +
                    "										</table>" +
                    "									</td>" +
                    "								</tr>" +
                    "								<tr>" +
                    "									<td align='center' style=''>" +
                    "										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
                    "											<tr>" +
                    "												<td align='center' style='padding: 1em 4em;'>" +
                    "													<p style='color: #223C60; font-size: 12px; margin-bottom: 0; font-weight: 200; line-height: 1.3;'>" +
                    "													<strong> Información de contacto  </strong>.</p>" +
                    "													<p style='color: #223C60; font-size: 12px; margin-bottom: 0; font-weight: 200; line-height: 1.3;'>" +
                    "														<strong> Nombre: </strong> " + Musuario.Nombre + "<br>" +
                    "														<strong> Correo : </strong> " + Musuario.CorreoPersonal + "<br>" +
                    "														<strong> Teléfono  : </strong> " + Musuario.TelefonoMovil + "<br>" +
                    "													</p>" +
                    "													<br>" +
                    "												</td>" +
                    "											</tr>" +
                    //"											<tr>" +
                    //"												<td>" +
                    //"												</td>" +
                    //"											<tr>" +
                    "										</table>" +
                    "									</td>" +
                    "								</tr>" +
                    //"								<tr>" +
                    //"									<td align='center' style=''>" +
                    //"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 1.5em;'>" +
                    //"											<tr>" +
                    //"												<td align='center' style='padding: 1em 4em;'>" +
                    //"												</td>" +
                    //"											</tr>" +
                    //"											<tr>" +
                    //"												<td>" +
                    //"												</td>" +
                    //"											<tr>" +
                    //"										</table>" +
                    //"									</td>" +
                    //"								</tr>" +
                    "								<tr>" +
                    "									<td align='center' valign='middle' class='hero bg_white' style=' position: relative; z-index: 0;'>" +
                    "									  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
                    "											<tr>" +
                    "												<td valign='middle' width='100%'>" +
                    "												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
                    "													<tr>" +
                    "													  <td>" +
                    "														<img src='https://www.asae.com.mx/01/BanTotal/PatrocinadoASAE.jpeg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
                    "													  </td>" +
                    "													</tr>" +
                    "													<tr>" +
                    "													  <td class='text' style='text-align: left; padding: 20px 30px;'>" +
                    "														<p><a href='https://www.asae.com.mx/bantotal' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
                    "													  </td>" +
                    "													</tr>" +
                    "												  </table>" +
                    "												</td>" +
                    "											</tr>" +
                    "										</table>" +
                    "									</td>" +
                    "								</tr>" +
                    "								<tr>" +
                    "									<td>" +
                    "										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
                    "											<tr>" +
                    "												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #223C60;'>" +
                    "													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
                    "														<tr>" +
                    "															<td class='counter-text'>" +
                    "																<span class='num'></span>" +
                    "															</td>" +
                    "														</tr>" +
                    "													</table>" +
                    "												</td>" +
                    "												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #38639F;'>" +
                    "													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
                    "														<tr>" +
                    "															<td class='counter-text'>" +
                    "																<span class='num'></span>" +
                    "															</td>" +
                    "														</tr>" +
                    "													</table>" +
                    "												</td>" +
                    "												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #3F7FD8;'>" +
                    "													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
                    "														<tr>" +
                    "															<td class='counter-text'>" +
                    "																<span class='num'></span>" +
                    "															</td>" +
                    "														</tr>" +
                    "													</table>" +
                    "												</td>" +
                    "											</tr>" +
                    "										</table>" +
                    "									</td>" +
                    "								</tr>" +
                    //"								<tr>" +
                    //"									<td>" +
                    //"										<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
                    //"											<tr>" +
                    //"												<td align='center' style='padding: 1em 4em;'>" +
                    //"													<br><br>" +
                    //"													<h2 style='color: #000000; font-size: 28px; margin-top: 0; font-weight: 400;'>LAS MEJORES HERRAMIENTAS EN LA ADMINISTRACIÓN Y CONTROL DE PROYECTOS</h2>" +
                    //"													<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'>Incrementa el 30 por ciento de productividad, con herramientas que analizan y miden el tiempo de trabajo de tu personal.</p>" +
                    //"												</td>" +
                    //"											</tr>" +
                    //"										</table>" +
                    //"									</td>" +
                    //"								<tr>" +
                    "								<tr>" +
                    "									<td style='padding: 1em;'>" +
                    "										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
                    "											<tr>" +
                    //"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
                    //"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
                    //"														<tr>" +
                    //"															<td>" +
                    //"																<img src='https://www.asae.com.mx/01/blog-1.jpg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
                    //"															</td>" +
                    //"														</tr>" +
                    //"														<tr>" +
                    //"															<td class='text-services' style='text-align: left;'>" +
                    //"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400;'>JobCTRL </h3>" +
                    //"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Software para documentar analizar mejorar el tiempo de trabajo.</span></p>		" +
                    //"																<p><a href='https://www.asae.com.mx/jobctrl' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
                    //"															</td>" +
                    //"														</tr>" +
                    //"													</table>" +
                    //"												</td>" +
                    "												<td valign='top' width='50%' style='padding-top: 20px;'>" +
                    "													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
                    "														<tr>" +
                    "															<td>" +
                    "																<img src='https://www.asae.com.mx/01/huawei.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
                    "															</td>" +
                    "														</tr>" +
                    "														<tr>" +
                    "															<td class='text-services' style='text-align: left;'>" +
                    "																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>Huawei-Ideahub</h3>" +
                    "																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>El nuevo estilo de oficina inteligente. </span></p>		" +
                    "																<p><a href='https://www.asae.com.mx/huawei-ideahub' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
                    "															</td>" +
                    "														</tr>" +
                    "													</table>" +
                    "												</td>" +
                    "											</tr>" +
                    "										</table>" +
                    "									</td>" +
                    "								</tr>" +
                    "								<tr>" +
                    "									<td style='padding: 2.5em; background: #000000; color: #9E9E9E'>" +
                    "										<table align='center' role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
                    "												<tr>" +
                    "													<td valign='middle' class='bg_black footer email-section'>" +
                    "														<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
                    "															<tr>" +
                    "																<td width='100%' style='text-align: center;'>" +
                    "																	<p style='font-size: 22px; margin-top: 0;'>Dirección: Margaritas 426, Álvaro Obregón, Ciudad de México</p>" +
                    "																</td>" +
                    "															</tr>" +
                    "															<tr>" +
                    "																<td width='100%' style='text-align: center;'>" +
                    "																	<p style='margin-top: 0; font-size: 14px; '>¿Quieres recibir más correos electrónicos con nuestras nuevas herramientas y promociones? Usted puede <a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='font-size: 14px; color: #00afc5;'>Darse de alta aquí</a></p>" +
                    "																</td>" +
                    "															</tr>" +
                    "															<tr>" +
                    "																<td width='100%' style='text-align: center;'>" +
                    "																	<table>" +
                    "																		<tr>" +
                    "																			<td>" +
                    "																				<a href='https://twitter.com/asaeconsultores'>" +
                    "																					<img src='https://www.asae.com.mx/01/004-twitter-logo.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
                    "																				</a>" +
                    "																			</td>" +
                    "																			<td>" +
                    "																				<a href='https://www.facebook.com/AsaeConsultoresMX/'>" +
                    "																					<img src='https://www.asae.com.mx/01/005-facebook.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
                    "																				</a>" +
                    "																			</td>" +
                    "																		</tr>" +
                    "																	</table>" +
                    "																</td>" +
                    "															</tr>" +
                    "													</table>" +
                    "													</td>" +
                    "												</tr>" +
                    "											  </table>" +
                    "									</td>" +
                    "								</tr>" +
                    "							</table>" +
                    "						</td>" +
                    "					</tr>" +
                    "					<tr>" +
                    "						<td height='25' style='font-size: 25px; line-height: 25px;'>&nbsp;</td>" +
                    "					</tr>" +
                    "				</table>" +
                    "			</td>" +
                    "		</tr>" +
                    "	</table>" +
                    "	<!-- end header -->" +
                    "	</body>" +
                    "</html>";

            return HTML;

        }
        /************************************************************************************************************/
        /************************************************************************************************************/
        /************************************************************************************************************/
        /************************************************************************************************************/

        public Models.Mensaje AsaeWebSolicitudPreciosEventos(Models.Usuario usuario, string DirectorioArchivo)
		{
			Models.Mensaje mensaje = new Models.Mensaje();
			mensaje = ValidarSolicitudCatalogoPrecios(usuario);

			if (mensaje.Respuesta == 1)
			{
				Models.Email email = new Models.Email();
				email.nombre = usuario.Nombre;
				email.email = usuario.CorreoPersonal;
				email.asunto = "Paquetes disponibles - Eventos Corporativos";
				email.mensaje = "";
				email.telefono = usuario.TelefonoMovil;
				email.telefonolocal = usuario.TelefonoLocal;
				email.App = 25;

				mensaje = dtUser.AsaeWebSolicitudesApp(email);

				if (mensaje.Respuesta == 1)
				{
					mensaje.RespuestaText = NuevaSolicitudPreciosEventos(usuario, DirectorioArchivo);
				}
			}
			return mensaje;
		}

		public string NuevaSolicitudPreciosEventos(Models.Usuario Musuario, string DirectorioArchivo)
		{
			string respuesta = "";

			string host = "mail.asae.com.mx";
			int puerto = 25;
			string usuario = "asae_contactanos@asae.com.mx";
			string contra = "A$ae2018$$_";
			string pCorreo = Musuario.CorreoPersonal.ToString().Trim();


			string file = DirectorioArchivo;

			// Create  the file attachment for this email message.
			Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
			// Add time stamp information for the file.
			ContentDisposition disposition = data.ContentDisposition;
			disposition.CreationDate = System.IO.File.GetCreationTime(file);
			disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
			disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
			// Add the file attachment to this email message.

			MailMessage correo = new MailMessage();
			correo.To.Add(new MailAddress(pCorreo));
			correo.CC.Add("gabriel.cruz@asaeop.com.mx");
			correo.From = new MailAddress(usuario, "ASAE CONSULTORES, S.A DE C.V");
			correo.Subject = "Paquetes disponibles - Eventos Corporativos";
			correo.Body = HTMLPreciosEventos();
			correo.Attachments.Add(data);

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
				respuesta = "ok";
			}
			catch (Exception ex)
			{
				respuesta = "Error: " + ex.Message;
			}

			return respuesta;
		}

		public string HTMLPreciosEventos()
		{
			string HTML = "";
			HTML += "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
					"<html xmlns:v='urn:schemas-microsoft-com:vml'>" +
					"<head>" +
					"	<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />" +
					"	<meta name='viewport' content='width=device-width; initial-scale=1.0; maximum-scale=1.0;' />" +

					"	<link href='https://fonts.googleapis.com/css?family=Nunito+Sans:200,300,400,600,700' rel='stylesheet'>" +
					"	<!--<![endif]-->" +
					"	<title> Asae Consultores S.A de C.V </title>" +
					"	<style type='text/css'>" +
					"		body {" +
					"			width: 100%;" +
					"			background-color: #ffffff;" +
					"			margin: 0;" +
					"			padding: 0;" +
					"			-webkit-font-smoothing: antialiased;" +
					"			mso-margin-top-alt: 0px;" +
					"			mso-margin-bottom-alt: 0px;" +
					"			mso-padding-alt: 0px 0px 0px 0px;" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"		}" +
					"		* {" +
					"			-ms-text-size-adjust: 100%;" +
					"			-webkit-text-size-adjust: 100%;" +
					"		}" +
					"		div[style*='margin: 16px 0'] {" +
					"			margin: 0 !important;" +
					"		}" +

					"		table," +
					"		td {" +
					"			mso-table-lspace: 0pt !important;" +
					"			mso-table-rspace: 0pt !important;" +
					"		}" +

					"		table {" +
					"			border-spacing: 0 !important;" +
					"			border-collapse: collapse !important;" +
					"			table-layout: fixed !important;" +
					"			margin: 0 auto !important;" +
					"		}" +

					"		img {" +
					"			-ms-interpolation-mode:bicubic;" +
					"		}" +
					"		a {" +
					"			text-decoration: none;" +
					"		}" +
					"		h1, h2, h3, h4, h5, h6 {" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"			color: #000000;" +
					"			margin-top: 0;" +
					"		}" +

					"		.logo h1{" +
					"			margin: 0;" +
					"		}" +
					"		.logo h1 a{" +
					"			color: #797979;" +
					"			font-size: 20px;" +
					"			font-weight: 700;" +
					"			font-family: 'Nunito Sans', sans-serif;" +
					"		}" +

					"	</style>" +
					"</head>" +
					"	<body class='respond' leftmargin='0' topmargin='0' marginwidth='0' marginheight='0'>" +
					"	<!-- header -->" +
					"	<table border='0' width='100%' cellpadding='0' cellspacing='0' bgcolor='ffffff'>" +
					"		<tr>" +
					"			<td align='center' style='background-color: #f1f1f1;'>" +
					"				<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' class='container590'>" +
					"					<tr>" +
					"						<td align='center'>" +
					"							<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff;'>" +
					"								<tr>" +
					"									<td align='center' style='padding: 1em 2.5em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td width='16%' class='logo' style='text-align: left; padding: 10px'>" +
					"													<h1><a style='color: #000; font-size: 10px; font-weight: 700; text-transform: uppercase;' href='https://www.asae.com.mx/'><img src='https://www.asae.com.mx/images/Tickets/LogoAsae.png' alt='' style='width: 100%; max-width: 500px; height: auto; margin: auto; display: block;'></a></h1>" +
					"												  </td>" +
					"												  <td width='55%' class='logo' style='text-align: right;'>" +
					"													<table width='100%' border='0' cellpadding='0' cellspacing='0' style='border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;' class='container590 hide'>" +
					"														<tr>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500; '>" +
					"																<a href='https://www.asae.com.mx/' style='color: #adadad;'>Inicio </a>" +
					"															</td>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
					"																<a href='https://www.asae.com.mx/eventos-corporativos' style='color: #adadad;'> Eventos Corporativos</a>" +
					"															</td>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
					"																<a href='https://www.asae.com.mx/contacto/atencion-a-clientes' style='color: #adadad;'>Contacto </a>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												  </td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #fafafa; padding: 0.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 0em 4em;'>" +
					"													<P style='font-size: 32px;color: #223C60; font-size: 32px; '><strong>Haz tus eventos corporativos de fin de año en un entorno inteligente y dinámico </strong></P>" +
					"												</td>" +
					"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #223C60;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #38639F;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #3F7FD8;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 1.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"												</td>" +
					"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"													<p style='color: #223C60; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.3;'>" +
					"													Te agradecemos que nos hayas contactado, el cátalo de paquetes disponibles viene adjunto al correo.</p>" +
					"													<br>" +
					"												</td>" +
					"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 1.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"												</td>" +
					"											</tr>" +
					//"											<tr>" +
					//"												<td>" +
					//"												</td>" +
					//"											<tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td align='center' valign='middle' class='hero bg_white' style=' position: relative; z-index: 0;'>" +
					"									  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%' >" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td class='text' style='text-align: left; padding: 20px 30px;'>" +
					"															<h2 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>Consiente a tus clientes y convence a tus prospectos con un evento memorable en un espacio inspirador. </h2>" +
					"															<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'> <strong>Estamos preparados para acompañar tu evento con una selección deliciosa y amplia de alimentos y bebidas realizadas por un equipo de chefs profesionales.</p>" +
					"															<p><a href='https://www.asae.com.mx/eventos-corporativos' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"												</td>" +
					"												<td valign='middle' width='50%'>" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td>" +
					"														<img src='https://www.asae.com.mx/01/EventosCorporativos/Banquetes.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #223C60;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #38639F;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #3F7FD8;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='counter-text'>" +
					"																<span class='num'></span>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td>" +
					"										<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"													<br><br>" +
					"													<h2 style='color: #000000; font-size: 28px; margin-top: 0; font-weight: 400;'>LAS MEJORES HERRAMIENTAS EN LA ADMINISTRACIÓN Y CONTROL DE PROYECTOS</h2>" +
					"													<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'>Incrementa el 30 por ciento de productividad, con herramientas que analizan y miden el tiempo de trabajo de tu personal.</p>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								<tr>" +
					"								<tr>" +
					"									<td style='padding: 1em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/blog-1.jpg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400;'>JobCTRL </h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Software para documentar analizar mejorar el tiempo de trabajo.</span></p>		" +
					"																<p><a href='https://www.asae.com.mx/jobctrl' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/huawei.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>Huawei-Ideahub</h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>El nuevo estilo de oficina inteligente. </span></p>		" +
					"																<p><a href='https://www.asae.com.mx/huawei-ideahub' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +
					"								<tr>" +
					"									<td style='padding: 2.5em; background: #000000; color: #9E9E9E'>" +
					"										<table align='center' role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
					"												<tr>" +
					"													<td valign='middle' class='bg_black footer email-section'>" +
					"														<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<p style='font-size: 22px; margin-top: 0;'>Dirección: Margaritas 426, Álvaro Obregón, Ciudad de México</p>" +
					"																</td>" +
					"															</tr>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<p style='margin-top: 0; font-size: 14px; '>¿Quieres recibir más correos electrónicos con nuestras nuevas herramientas y promociones? Usted puede <a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='font-size: 14px; color: #00afc5;'>Darse de alta aquí</a></p>" +
					"																</td>" +
					"															</tr>" +
					"															<tr>" +
					"																<td width='100%' style='text-align: center;'>" +
					"																	<table>" +
					"																		<tr>" +
					"																			<td>" +
					"																				<a href='https://twitter.com/asaeconsultores'>" +
					"																					<img src='https://www.asae.com.mx/01/004-twitter-logo.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
					"																				</a>" +
					"																			</td>" +
					"																			<td>" +
					"																				<a href='https://www.facebook.com/AsaeConsultoresMX/'>" +
					"																					<img src='https://www.asae.com.mx/01/005-facebook.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
					"																				</a>" +
					"																			</td>" +
					"																		</tr>" +
					"																	</table>" +
					"																</td>" +
					"															</tr>" +
					"													</table>" +
					"													</td>" +
					"												</tr>" +
					"											  </table>" +
					"									</td>" +
					"								</tr>" +
					"							</table>" +
					"						</td>" +
					"					</tr>" +
					"					<tr>" +
					"						<td height='25' style='font-size: 25px; line-height: 25px;'>&nbsp;</td>" +
					"					</tr>" +
					"				</table>" +
					"			</td>" +
					"		</tr>" +
					"	</table>" +
					"	<!-- end header -->" +
					"	</body>" +
					"</html>";

			return HTML;

		}

        /************************************************************************************************************/
        /************************************************************************************************************/

        public Models.Mensaje AsaeWebSolicitudDemoAsaeASD(Models.Usuario usuario)
        {
            Models.Mensaje mensaje = new Models.Mensaje();
            mensaje = ValidarSolicitud(usuario);

            if (mensaje.Respuesta == 1)
            {
                Models.Email email = new Models.Email();
                email.nombre = usuario.Nombre;
                email.email = usuario.CorreoPersonal;
                email.asunto = "Solicitud de demo gratis - ASD";
                email.mensaje = "";
                email.telefono = usuario.TelefonoMovil;
                email.telefonolocal = usuario.TelefonoLocal;
                email.App = 2;

                mensaje = dtUser.AsaeWebSolicitudesApp(email);

                if (mensaje.Respuesta == 1)
                {
                    mensaje.RespuestaText = NuevaSolicitudDemoAsaeASD(usuario);
                }
            }
            return mensaje;
        }

        public string NuevaSolicitudDemoAsaeASD(Models.Usuario Musuario)
        {
            string respuesta = "";

            string host = "mail.asae.com.mx";
            int puerto = 25;
            string usuario = "asae_contactanos@asae.com.mx";
            string contra = "A$ae2018$$_";
            string pCorreo = Musuario.CorreoPersonal.ToString().Trim();

            MailMessage correo = new MailMessage();
            correo.To.Add(new MailAddress(pCorreo));
            correo.CC.Add("francisco.acevedo@asae.com.mx");
            correo.CC.Add("guillermo.rojas@asae.com.mx");
            correo.CC.Add("soporte-aplicaciones@asae.com.mx");
            correo.From = new MailAddress(usuario, "ASAE CONSULTORES, S.A DE C.V");
            correo.Subject = "Solicitud de demo gratis - ASAE SERVICE DESK (ASD)";
            correo.Body = HTMLDemoAsaeASD();

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
                respuesta = "ok";
            }
            catch (Exception ex)
            {
                respuesta = "Error: " + ex.Message;
            }

            return respuesta;
        }

        public string HTMLDemoAsaeASD()
        {
            string HTML = "";
            HTML += " " +
            "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
            "<html xmlns:v='urn:schemas-microsoft-com:vml'>" +
            "<head>" +
                "<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />" +
                "<meta name='viewport' content='width=device-width; initial-scale=1.0; maximum-scale=1.0;' />" +

                "<link href='https://fonts.googleapis.com/css?family=Nunito+Sans:200,300,400,600,700' rel='stylesheet'>" +
                "<!--<![endif]-->" +
                "<title>Asae Consultores S.A de C.V</title>" +
                "<style type='text/css'>" +
                "	body {" +
            "			width: 100%;" +
            "			background-color: #ffffff;" +
            "			margin: 0;" +
            "			padding: 0;" +
            "			-webkit-font-smoothing: antialiased;" +
            "			mso-margin-top-alt: 0px;" +
            "			mso-margin-bottom-alt: 0px;" +
            "			mso-padding-alt: 0px 0px 0px 0px;" +
            "			font-family: 'Nunito Sans', sans-serif;" +
            "		}" +
            "		* {" +
            "			-ms-text-size-adjust: 100%;" +
            "			-webkit-text-size-adjust: 100%;" +
            "		}" +
            "		div[style*='margin: 16px 0'] {" +
            "			margin: 0 !important;" +
            "		}" +

            "		table," +
            "		td {" +
            "			mso-table-lspace: 0pt !important;" +
            "			mso-table-rspace: 0pt !important;" +
            "		}" +

            "		table {" +
            "			border-spacing: 0 !important;" +
            "			border-collapse: collapse !important;" +
            "			table-layout: fixed !important;" +
            "			margin: 0 auto !important;" +
            "		}" +

            "		img {" +
            "			-ms-interpolation-mode:bicubic;" +
            "		}" +
            "		a {" +
            "			text-decoration: none;" +
            "		}" +
            "		h1, h2, h3, h4, h5, h6 {" +
            "			font-family: 'Nunito Sans', sans-serif;" +
            "			color: #000000;" +
            "			margin-top: 0;" +
            "		}" +

            "		.logo h1{" +
            "			margin: 0;" +
            "		}" +
            "		.logo h1 a{" +
            "			color: #797979;" +
            "			font-size: 20px;" +
            "			font-weight: 700;" +
            "			font-family: 'Nunito Sans', sans-serif;" +
            "		}" +

            "	</style>" +
            "</head>" +
            "	<body class='respond' leftmargin='0' topmargin='0' marginwidth='0' marginheight='0'>" +
            "	<!-- header -->" +
            "	<table border='0' width='100%' cellpadding='0' cellspacing='0' bgcolor='ffffff'>" +
            "		<tr>" +
            "			<td align='center' style='background-color: #f1f1f1;'>" +
            "				<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' class='container590'>" +
            "					<tr>" +
            "						<td align='center'>" +
            "							<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff;'>" +
            "								<tr>" +
            "									<td align='center' style='padding: 1em 2.5em;'>" +
            "										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
            "											<tr>" +
            "												<td width='16%' class='logo' style='text-align: left; padding: 10px'>" +
            "													<h1><a style='color: #000; font-size: 10px; font-weight: 700; text-transform: uppercase;' href='https://www.asae.com.mx/'><img src='https://www.asae.com.mx/images/Tickets/LogoAsae.png' alt='' style='width: 100%; max-width: 500px; height: auto; margin: auto; display: block;'></a></h1>" +
            "												  </td>" +
            "												  <td width='55%' class='logo' style='text-align: right;'>" +
            "													<table width='100%' border='0' cellpadding='0' cellspacing='0' style='border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;' class='container590 hide'>" +
            "														<tr>" +
            "															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500; '>" +
            "																<a href='https://www.asae.com.mx/' style='color: #adadad;'>Inicio </a>" +
            "															</td>" +
            "															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
            "																<a href='https://www.asae.com.mx/asd' style='color: #adadad;'>ASD </a>" +
            "															</td>" +
            "															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
            "																<a href='https://www.asae.com.mx/contacto/atencion-a-clientes' style='color: #adadad;'>Contacto </a>" +
            "															</td>" +
            "														</tr>" +
            "													</table>" +
            "												  </td>" +
            "											</tr>" +
            "										</table>" +
            "									</td>" +
            "								</tr>" +
            "								<tr>" +
            "									<td align='center' style=''>" +
            "										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #fafafa; padding: 0.5em;'>" +
            "											<tr>" +
            "												<td align='center' style='padding: 0em 4em;'>" +
            "													<P style='font-size: 32px;color: #418bcc; font-size: 32px; '><strong>ASAE SERVICE DESK (ASD)</strong></P>" +
            "												</td>" +
            "											</tr>" +
            "											<tr>" +
            "												<td>" +
            "												</td>" +
            "											<tr>" +
            "										</table>" +
            "									</td>" +
            "								</tr>" +
            "								<tr>" +
            "									<td>" +
            "										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
            "											<tr>" +
            "												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #026fa0;'>" +
            "													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
            "														<tr>" +
            "															<td class='counter-text'>" +
            "																<span class='num'></span>" +
            "															</td>" +
            "														</tr>" +
            "													</table>" +
            "												</td>" +
            "												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #009baf;'>" +
            "													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
            "														<tr>" +
            "															<td class='counter-text'>" +
            "																<span class='num'></span>" +
            "															</td>" +
            "														</tr>" +
            "													</table>" +
            "												</td>" +
            "												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #00BCD4;'>" +
            "													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
            "														<tr>" +
            "															<td class='counter-text'>" +
            "																<span class='num'></span>" +
            "															</td>" +
            "														</tr>" +
            "													</table>" +
            "												</td>" +
            "											</tr>" +
            "										</table>" +
            "									</td>" +
            "								</tr>" +
            "								<tr>" +
            "									<td align='center' style=''>" +
            "										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 1.5em;'>" +
            "											<tr>" +
            "												<td align='center' style='padding: 1em 4em;'>" +
            "												</td>" +
            "											</tr>" +
            "											<tr>" +
            "												<td>" +
            "												</td>" +
            "											<tr>" +
            "										</table>" +
            "									</td>" +
            "								</tr>" +
            "								<tr>" +
            "									<td align='center' style=''>" +
            "										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
            "											<tr>" +
            "												<td align='center' style='padding: 1em 4em;'>" +
            "													<p style='color: #03A9F4; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.3;'> " +
            "													Te agradecemos que nos hayas contactado, en breve un ejecutivo se comunicara contigo para atender tu solicitud y brindarte una demo totalmente gratis.</p>" +
            "													<br>" +
            "												</td>" +
            "											</tr>" +
            "											<tr>" +
            "												<td>" +
            "												</td>" +
            "											<tr>" +
            "										</table>" +
            "									</td>" +
            "								</tr>" +
            "								<tr>" +
            "									<td align='center' style=''>" +
            "										<table border='0'  width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 1.5em;'>" +
            "											<tr>" +
            "												<td align='center' style='padding: 1em 4em;'>" +
            "												</td>" +
            "											</tr>" +
            "											<tr>" +
            "												<td>	" +
            "												</td>" +
            "											<tr>" +
            "										</table>" +
            "									</td>" +
            "								</tr>" +
            "								<tr>" +
            "									<td align='center' valign='middle' class='hero bg_white' style=' position: relative; z-index: 0;'>" +
            "									  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
            "											<tr>" +
            "												<td valign='middle' width='50%' >" +
            "												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
            "													<tr>" +
            "													  <td class='text' style='text-align: left; padding: 20px 30px;'>" +
            "															<h2 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>¿Conoces en que estatus se encuentra cualquier incidente de soporte TI en tu organización?</h2>" +
            "															<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'> <strong>ASAE SERVICE DESK (ASD)</strong> ayuda a gerentes de TI a garantizar la continuidad de los servicios de TI dentro de la organización, llevando el control de cada incidente de soporte técnico en una sola plataforma.</p>" +
            "															<p><a href='https://www.asae.com.mx/asd' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
            "													  </td>" +
            "													</tr>" +
            "												  </table>" +
            "												</td>" +
            "												<td valign='middle' width='50%'>" +
            "												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
            "													<tr>" +
            "													  <td>" +
            "														<img src='https://www.asae.com.mx/images/Tickets/Banner2.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
            "													  </td>" +
            "													</tr>" +
            "												  </table>" +
            "												</td>" +
            "											</tr>" +
            "										</table>" +
            "									</td>" +
            "								</tr>" +
            "								<tr>" +
            "									<td>" +
            "										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
            "											<tr>" +
            "												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #026fa0;'>" +
            "													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
            "														<tr>" +
            "															<td class='counter-text'>" +
            "																<span class='num'></span>" +
            "															</td>" +
            "														</tr>" +
            "													</table>" +
            "												</td>" +
            "												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #009baf;'>" +
            "													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
            "														<tr>" +
            "															<td class='counter-text'>" +
            "																<span class='num'></span>" +
            "															</td>" +
            "														</tr>" +
            "													</table>" +
            "												</td>" +
            "												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #00BCD4;'>" +
            "													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
            "														<tr>" +
            "															<td class='counter-text'>" +
            "																<span class='num'></span>" +
            "															</td>" +
            "														</tr>" +
            "													</table>" +
            "												</td>" +
            "											</tr>" +
            "										</table>" +
            "									</td>" +
            "								</tr>" +
            "								<tr>" +
            "									<td>" +
            "										<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #ffffff; padding: 2.5em;'>" +
            "											<tr>" +
            "												<td align='center' style='padding: 1em 4em;'>" +
            "													<br><br>" +
            "													<h2 style='color: #000000; font-size: 28px; margin-top: 0; font-weight: 400;'>LAS MEJORES HERRAMIENTAS EN LA ADMINISTRACIÓN Y CONTROL DE PROYECTOS</h2>" +
            "													<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'>Incrementa el 30 por ciento de productividad, con herramientas que analizan y miden el tiempo de trabajo de tu personal.</p>" +
            "												</td>" +
            "											</tr>" +
            "										</table>" +
            "									</td>" +
            "								</tr>" +
            //"								<tr>" +
            //"									<td style='padding: 1em;'>" +
            //"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
            //"											<tr>" +
            //"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
            //"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
            //"														<tr>" +
            //"															<td>" +
            //"																<img src='https://www.asae.com.mx/01/blog-1.jpg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
            //"															</td>" +
            //"														</tr>" +
            //"														<tr>" +
            //"															<td class='text-services' style='text-align: left;'>" +
            //"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400;'>JobCTRL </h3>" +
            //"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Software para documentar analizar mejorar el tiempo de trabajo.</span></p>		" +
            //"																<p><a href='https://www.asae.com.mx/jobctrl' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
            //"															</td>" +
            //"														</tr>" +
            //"													</table>" +
            //"												</td>" +
            //"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
            //"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
            //"														<tr>" +
            //"															<td>" +
            //"																<img src='https://www.asae.com.mx/01/huawei.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
            //"															</td>" +
            //"														</tr>" +
            //"														<tr>" +
            //"															<td class='text-services' style='text-align: left;'>" +
            //"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>Huawei-Ideahub</h3>" +
            //"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>El nuevo estilo de oficina inteligente. </span></p>		" +
            //"																<p><a href='https://www.asae.com.mx/huawei-ideahub' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
            //"															</td>" +
            //"														</tr>" +
            //"													</table>" +
            //"												</td>" +
            //"											</tr>" +
            //"										</table>" +
            //"									</td>" +
            //"								</tr>" +
            "								<tr>" +
            "									<td style='padding: 2.5em; background: #000000; color: #9E9E9E'>" +
            "										<table align='center' role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
            "												<tr>" +
            "													<td valign='middle' class='bg_black footer email-section'>" +
            "														<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
            "															<tr>" +
            "																<td width='100%' style='text-align: center;'>" +
            "																	<p style='font-size: 22px; margin-top: 0;'>Dirección: Margaritas 426, Álvaro Obregón, Ciudad de México</p>" +
            "																</td>" +
            "															</tr>" +
            "															<tr>" +
            "																<td width='100%' style='text-align: center;'>" +
            "																	<p style='margin-top: 0; font-size: 14px; '>¿Quieres recibir más correos electrónicos con nuestras nuevas herramientas y promociones? Usted puede <a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='font-size: 14px; color: #00afc5;'>Darse de alta aquí</a></p>" +
            "																</td>" +
            "															</tr>" +
            "															<tr>" +
            "																<td width='100%' style='text-align: center;'>" +
            "																	<table>" +
            "																		<tr>" +
            "																			<td>" +
            "																				<a href='https://twitter.com/asaeconsultores'>" +
            "																					<img src='https://www.asae.com.mx/01/004-twitter-logo.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
            "																				</a>" +
            "																			</td>" +
            "																			<td>" +
            "																				<a href='https://www.facebook.com/AsaeConsultoresMX/'>" +
            "																					<img src='https://www.asae.com.mx/01/005-facebook.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
            "																				</a>" +
            "																			</td>" +
            "																		</tr>" +
            "																	</table>" +
            "																</td>" +
            "															</tr>" +
            "													</table>" +
            "													</td>" +
            "												</tr>" +
            "											  </table>" +
            "									</td>" +
            "								</tr>" +
            "							</table>" +
            "						</td>" +
            "					</tr>" +
            "					<tr>" +
            "						<td height='25' style='font-size: 25px; line-height: 25px;'>&nbsp;</td>" +
            "					</tr>" +
            "				</table>" +
            "			</td>" +
            "		</tr>" +
            "	</table>" +
            "	<!-- end header -->" +
            "	</body>" +
            "</html>";


            return HTML;
        }
    }
}
