using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public class Email
    {
		Data.Usuarios dtUser = new Data.Usuarios();

		public string ProcesaDatos(Models.CorreoEmail model)
		{
			string respuesta = "";
			/*respuesta = model.email[0].nombre.ToString();*/
			validaciones validaciones = new validaciones();
			if (validaciones.EvaludaEmail(model) == "ok")
			{
				try
				{
					dtUser.AsaeWebUsuarioMensaje(model.email[0]);
				}
				catch
				{

				}
				


				string host = "mail.asae.com.mx";
				int puerto = 25;
				string usuario = "asae_contactanos@asae.com.mx";
				string contra = "A$ae2018$$_";
				string pCorreo = model.email[0].email.ToString().Trim();

				MailMessage correo = new MailMessage();
				correo.To.Add(new MailAddress(pCorreo));
				correo.CC.Add("magdalena.ornelas@asae.com.mx");
				correo.From = new MailAddress(usuario, "ASAE CONSULTORES, S.A DE C.V");
				correo.Subject = model.email[0].asunto.ToString();
				correo.Body = "" +
					"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
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
								"color: #797979;" +
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
																					"<a href='https://www.asae.com.mx/asae-consultores/experiencia-asae-consultores' style='color: #adadad;'>Experiencia </a>" +
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
																			"<img src='https://www.asae.com.mx/01/bg_1.jpg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
																		  "</td>" +
																		"</tr>" +
																	  "</table>" +
																"</td>" +
																"<td valign='middle' width='50%' style='background: #f1f1f1;'>" +
																  "<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																	"<tr>" +
																	  "<td class='text' style='text-align: left; padding: 20px 30px;'>" +
																			"<h2 style='color: #03A9F4; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.4; text-align: center;'>Gracias por enviar tu mensaje </h2>" +
																			"<p style='font-size: 14px; line-height: 2; color: #6b6b6b; text-align: center;'> Suscríbete y recibe nuestras ultimas noticias y promociones en las mejores herramientas en soluciones TI.</p>" +
																			"<p><a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;' >Suscribirme</a></p>" +
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
																		"<h2 style='color: #03A9F4; font-size: 28px; margin-top: 0; line-height: 3; font-weight: 400;'>Información de mensaje.</h2>" +
																		"<p style='font-size: 14px; line-height: 1.8; color: #a5a5a5;'> Te agradecemos que nos hayas contactado, en breve un ejecutivo te llamara para atender tus dudas y / o comentarios.</p>" +
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
																					"<td style='margin-top: 0; font-size: 13px; text-align: center;'>" +
																						"<h3>Nombre </h3>" +
																					"</td>" +
																					 "<td style='margin-top: 0; font-size: 13px; text-align: center; color: #9E9E9E'>" +
																						"<p>"+ model.email[0].nombre + " </p>" +
																					"</td>" +
																				  "</tr>" +
																				  "<tr>" +
																					"<td style='margin-top: 0; font-size: 13px; text-align: center;'>" +
																						"<h3>Email </h3>" +
																					"</td>" +
																					 "<td style='margin-top: 0; font-size: 13px; text-align: center; color: #9E9E9E'>" +
																						"<p>" + model.email[0].email + "</p>" +
																					"</td>" +
																				  "</tr>" +
																				  "<tr>" +
																					"<td style='margin-top: 0; font-size: 13px; text-align: center;'>" +
																						"<h3>Mensaje  </h3>" +
																					"</td>" +
																					"<td style='margin-top: 0; font-size: 13px; text-align: center; color: #9E9E9E'>" +
																						"<p>" + model.email[0].mensaje + "</p>" +
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
																						"<h2 style='color: #03A9F4; font-size: 28px; margin-top: 0; line-height: 1.4; font-weight: 400; text-align: center;'>ACERCA DE NOSOTROS</h2>" +
																						"<p style='font-size: 14px; line-height: 1.8; color: #a5a5a5;'>Nos hemos consolidado como una organización integradora de tecnología, abarcando productos y servicios ...</p>" +
																						"<p><a href='https://www.asae.com.mx/' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
																					"</div>" +
																				"</td>" +
																			"</tr>" +
																		"</table>" +
																	"</td>" +
																"</tr>" +
															"</table>" +
														"</td" +
													"</tr>" +
													"<tr>" +
														"<td>" +
															"<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
																"<tr>" +
																	"<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #026fa0;'>" +
																		"<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																			"<tr>" +
																				"<td class='counter-text'>" +
																					"<span class='num'></span>" +
																				"</td>" +
																			"</tr>" +
																		"</table>" +
																	"</td>" +
																	"<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #009baf;'>" +
																		"<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																			"<tr>" +
																				"<td class='counter-text'>" +
																					"<span class='num'></span>" +
																				"</td>" +
																			"</tr>" +
																		"</table>" +
																	"</td>" +
																	"<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #00BCD4;'>" +
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
					"																<br>" +
					"																<img src='https://www.asae.com.mx/01/CorreTickets.png' alt='' style='width: 90%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400;'>Asae Service Desk (ASD) </h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Ayuda a gerentes de TI a garantizar la continuidad de los servicios de TI dentro de la organización.</span></p>" +

					"																<p><a href='https://www.asae.com.mx/asd' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
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
																						"<p style='margin-top: 0; font-size: 14px; '>¿Quieres recibir más correos electrónicos con nuestras nuevas herramientas y promociones? Usted puede <a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='font-size: 14px; color: #00afc5;'>Darse de alta aquí</a></p>" +
																					"</td>" +
																				"</tr>" +
																				"<tr>" +
																					"<td width='100%' style='text-align: center;'>" +
																						"<table>" +
																							"<tr>" +
																								"<td>" +
																									"<a href='https://twitter.com/asaeconsultores'>" +
																										"<img src='https://www.asae.com.mx/01/004-twitter-logo.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
																									"</a>" +
																								"</td>" +
																								"<td>" +
																									"<a href='https://www.facebook.com/AsaeConsultoresMX/'>" +
																										"<img src='https://www.asae.com.mx/01/005-facebook.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
																									"</a>"+
																								"</td>" +
																								//"<td>" +
																								//	"<img src='https://www.asae.com.mx/01/006-instagram-logo.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
																								//"</td>" +
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
			}
			else
			{
				respuesta = validaciones.EvaludaEmail(model);
			}

			return respuesta;
		}

		public string ProcesaDatosSuscribir(Models.CorreoEmail model)
		{
			string respuesta = "";
			validaciones validaciones = new validaciones();
			if (validaciones.EvaludaSuscribir(model) == "ok")
			{
				try
				{
					dtUser.AsaeWebUsuarioSuscribir(model.email[0]);
				}
				catch
				{
					respuesta = "ok";
				}
				respuesta = "ok";
			}
			else
			{
				respuesta = validaciones.EvaludaSuscribir(model);
			}

			return respuesta;
		}

		public string NuevoUsuario(Models.NuevoUsuario usuarios)
		{
			// REGISTRAR EL NUEVO USUARIO
			// ENVIAR NUEVO CORREO
			WSCorreo.CorreoSoapClient correo1 = new WSCorreo.CorreoSoapClient();

			foreach (var usuario in usuarios.usuario)
			{
				if (usuario != null)
				{
					if (correo1.CorreoMetPrivado("mail.asae.com.mx", 25, "soporte-aplicaciones@asae.com.mx", "$%65hgy#19_", "rogelio.orea@hotmail.com", "Servicios Inmobiliarios G", "Nuevo inmueble registrado", NewUserHTML()) == "Correo enviado")
					{

					}

				}
			}


			string respuesta = "";

			return respuesta;
		}

		public string NewUserHTML()
		{
			string mensaje = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
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
											"color: #FF5722;" +
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
																						"<h2 style='color: #FF5722; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.4; text-align: center;'>Gracias por registrarte.</h2>" +
																						"<p style='font-size: 14px; line-height: 2; color: #6b6b6b; text-align: center;'> Por favor confirma tu participación, da un clic en el botón para <strong>confirmar tu asistencia</strong>.</p>" +
																						"<p style='border-radius: 5px;background: #FF5722; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;' >Confirmar asistencia </a></p>" +
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
																					"<h2 style='color: #FF5722; font-size: 28px; margin-top: 0; line-height: 3; font-weight: 400;'>Información registrada.</h2>" +
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
																								 "<td style='margin-top: 0; font-size: 13px; text-align: center; color: #FF5722; background-color: #d2d2d2'>" +
																									"<p>rogelio rodriguez orea</p>" +
																								"</td>" +
																							  "</tr>" +
																							  "<tr>" +
																								"<td style='margin-top: 0; font-size: 13px; text-align: center; background-color: #dcdcdc'>" +
																									"<p>Empresa </p>" +
																								"</td>" +
																								 "<td style='margin-top: 0; font-size: 13px; text-align: center; color: #9E9E9E; background-color: #f3f3f3'>" +
																									"<p>Nombre Empresa</p>" +
																								"</td>" +
																							  "</tr>" +
																							  "<tr>" +
																								"<td style='margin-top: 0; font-size: 13px; text-align: center; background-color: #dcdcdc'>" +
																									"<p>Correo Empresa  </p>" +
																								"</td>" +
																								"<td style='margin-top: 0; font-size: 13px; text-align: center; color: #9E9E9E; background-color: #f3f3f3'>" +
																									"<p>correo@@</p>" +
																								"</td>" +
																							  "</tr>" +
																								"<tr>" +
																									"<td style='margin-top: 0; font-size: 13px; text-align: center; background-color: #dcdcdc'>" +
																										"<p>Correo personal  </p>" +
																									"</td>" +
																									"<td style='margin-top: 0; font-size: 13px; text-align: center; color: #FF5722; background-color: #d2d2d2'>" +
																										"<p>correo@@</p>" +
																									"</td>" +
																								"</tr>" +
																								"<tr>" +
																									"<td style='margin-top: 0; font-size: 13px; text-align: center; background-color: #dcdcdc'>" +
																										"<p>Teléfono móvil </p>" +
																									"</td>" +
																									"<td style='margin-top: 0; font-size: 13px; text-align: center; color: #9E9E9E; background-color: #f3f3f3'>" +
																										"<p>5465165</p>" +
																									"</td>" +
																								"</tr>" +
																								"<tr>" +
																									"<td style='margin-top: 0; font-size: 13px; text-align: center; background-color: #dcdcdc'>" +
																										"<p>Teléfono local </p> " +
																									"</td>" +
																									"<td style='margin-top: 0; font-size: 13px; text-align: center; color: #9E9E9E; background-color: #f3f3f3'>" +
																										"<p>524165413251</p>" +
																									"</td>" +
																								"</tr>" +
																								"<tr>" +
																									"<td style='margin-top: 0; font-size: 13px; text-align: center; background-color: #dcdcdc'>" +
																										"<p>Credenciales de acceso </p>" +
																									"</td>" +
																									"<td style='margin-top: 0; font-size: 13px; text-align: center; color: #FF5722; background-color: #d2d2d2'>" +
																										"<p>Información de credenciales</p>" +
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
																									"<h2 style='color: #FF5722; font-size: 28px; margin-top: 0; line-height: 1.4; font-weight: 400; text-align: center;'>ACERCA DE NOSOTROS</h2>" +
																									"<p style='font-size: 14px; line-height: 1.8; color: #a5a5a5;'>Nos hemos consolidado como una organización integradora de tecnología, abarcando productos y servicios ...</p>" +
																									"<p><a href='https://www.asae.com.mx/' style='border-radius: 5px;background: #FF5722; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
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
																				"<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #FF5722;'>" +
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
								"																<br>" +
								"																<img src='https://www.asae.com.mx/01/CorreTickets.png' alt='' style='width: 90%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
								"															</td>" +
								"														</tr>" +
								"														<tr>" +
								"															<td class='text-services' style='text-align: left;'>" +
								"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400;'>Asae Service Desk (ASD) </h3>" +
								"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Ayuda a gerentes de TI a garantizar la continuidad de los servicios de TI dentro de la organización.</span></p>" +

								"																<p><a href='https://www.asae.com.mx/asd' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
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
																									"<a href='https://twitter.com/asaeconsultores'>" +
																										"<img src='https://www.asae.com.mx/01/004-twitter-logo.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
																									"</a>" +
																								"</td>" +
																								"<td>" +
																									"<a href='https://www.facebook.com/AsaeConsultoresMX/'>" +
																										"<img src='https://www.asae.com.mx/01/005-facebook.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
																									"</a>" +
																								"</td>" +
																								//"<td>" +
																								//	"<img src='https://www.asae.com.mx/01/006-instagram-logo.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
																								//"</td>" +
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

			return mensaje;
		}


		/********************************************************************************************************************************************/
		/****************************************************  NUEVO DESARROLLO  ********************************************************************/
		/********************************************************************************************************************************************/

		public string MensajeASD(Models.CorreoEmail model)
		{
			string respuesta = "";
			validaciones validaciones = new validaciones();
			model.email[0].asunto = "Información ASAE SERVICE DESK (ASD)";
			model.email[0].App = 2;

			if (model.email[0].telefonolocal == null)
			{
				model.email[0].telefonolocal = "";
			}

			if (validaciones.EvaludaEmail(model) == "ok")
			{
				try
				{
					dtUser.AsaeWebUsuarioMensajeApp(model.email[0]);
				}
				catch
				{

				}

				string host = "mail.asae.com.mx";
				int puerto = 25;
				string usuario = "asae_contactanos@asae.com.mx";
				string contra = "A$ae2018$$_";
				string pCorreo = model.email[0].email.ToString().Trim();


				MailMessage correo = new MailMessage();
				correo.To.Add(new MailAddress(pCorreo));
				correo.CC.Add("magdalena.ornelas@asae.com.mx");
				correo.From = new MailAddress(usuario, "ASAE CONSULTORES, S.A DE C.V");
				correo.Subject = model.email[0].asunto.ToString();
				correo.Body = "" +
					"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
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
								"font-family: 'Nunito Sans', sans-serif;" +
							"}" +
							"* {" +
								"-ms-text-size-adjust: 100%;" +
								"-webkit-text-size-adjust: 100%;" +
							"}" +
							"div[style*='margin: 16px 0'] {" +
						"		margin: 0 !important;" +
						"	}" +

						"	table," +
						"	td {" +
						"		mso-table-lspace: 0pt !important;" +
						"		mso-table-rspace: 0pt !important;" +
						"	}" +

						"	table {" +
						"		border-spacing: 0 !important;" +
						"		border-collapse: collapse !important;" +
						"		table-layout: fixed !important;" +
						"		margin: 0 auto !important;" +
						"	}" +

						"	img {" +
						"		-ms-interpolation-mode:bicubic;" +
						"	}" +
						"	a {" +
						"		text-decoration: none;" +
						"	}" +
						"	h1, h2, h3, h4, h5, h6 {" +
						"		font-family: 'Nunito Sans', sans-serif;" +
						"		color: #000000;" +
						"		margin-top: 0;" +
						"	}" +

						"	.logo h1{" +
						"		margin: 0;" +
						"	}" +
						"	.logo h1 a{" +
						"		color: #797979;" +
						"		font-size: 20px;" +
						"		font-weight: 700;" +
						"		font-family: 'Nunito Sans', sans-serif;" +
						"	}" +

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
																	"<td width='16%' class='logo' style='text-align: left; padding: 10px'>" +
																		"<h1><a style='color: #000; font-size: 10px; font-weight: 700; text-transform: uppercase;' href='https://www.asae.com.mx/'><img src='https://www.asae.com.mx/images/Tickets/LogoAsae.png' alt='' style='width: 100%; max-width: 500px; height: auto; margin: auto; display: block;'></a></h1>" +
																	  "</td>" +
																	  "<td width='55%' class='logo' style='text-align: right;'>" +
																		"<table width='100%' border='0' cellpadding='0' cellspacing='0' style='border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;' class='container590 hide'>" +
																			"<tr>" +
																				"<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500; '>" +
																					"<a href='https://www.asae.com.mx/' style='color: #adadad;'>Inicio </a>" +
																				"</td>" +
																				"<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
																					"<a href='https://www.asae.com.mx/asd' style='color: #adadad;'>ASD </a>" +
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
														"<td align='center' valign='middle' class='hero bg_white' style=' position: relative; z-index: 0;'>" +
														  "<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																"<tr>" +
																	"<td valign='middle' width='50%'>" +
																	  "<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																		"<tr>" +
																		  "<td>" +
																			"<img src='https://www.asae.com.mx/images/Tickets/Banner2.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
																		  "</td>" +
																		"</tr>" +
																	  "</table>" +
																"</td>" +
																"<td valign='middle' width='50%' >" +
																  "<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																	"<tr>" +
																	  "<td class='text' style='text-align: left; padding: 20px 30px;'>" +
																			"<h2 style='color: #03A9F4; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.3;'>Gracias por enviar tu mensaje </h2>" +
																			"<p style='font-size: 14px; line-height: 1.5; color: #b9b9b9;'> Suscríbete y recibe nuestras ultimas noticias y promociones en las mejores herramientas en soluciones TI.</p>" +
																			"<p><a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;' >Suscribirme</a></p>" +
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
															"<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 2.5em;'>" +
																"<tr>" +
																	"<td align='center' style='padding: 1em 4em;'>" +
																		"<p style='font-size: 19px; color: #03A9F4;'> " +
																		"Te agradecemos que nos hayas contactado, en breve un ejecutivo te contactara para atender tus dudas y / o comentarios.</p>" +
																	"</td>" +
																"</tr>" +
																"<tr>" +
																	"<td>" +

																	"</td>" +
																"<tr>" +
															"</table>" +
														"</td>" +
													"</tr>" +
													"<tr>" +
														"<td  style='    padding: 2.5em;'>" +
															"<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
																"<tr>" +
																	"<td valign='middle' width='50%'>" +
																		"<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																			"<tr>" +
																				"<td>" +
																					"<img src='https://www.asae.com.mx/images/Tickets/Banner.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
																				"</td>" +
																			"</tr>" +
																		"</table>" +
																	"</td>" +
																	"<td valign='middle' width='50%'>" +
																		"<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																			"<tr>" +
																				"<td class='text-services' style='text-align: left; padding-left:25px;'>" +
																					"<div class='heading-section'>" +
																						"<h2 style='color: #676466; font-size: 21px; font-weight: 300;margin-top: 0; line-height: 1.3; font-weight: 400;'>¿Conoces en que estatus se encuentra cualquier incidente de soporte TI en tu organización?</h2>" +
																						"<p style='font-size: 12px; line-height: 1.8; color: #b9b9b9;'><strong>ASAE SERVICE DESK (ASD)</strong> ayuda a gerentes de TI a garantizar la continuidad de los servicios de TI dentro de la organización, llevando el control de cada incidente de soporte técnico en una sola plataforma.</p>" +
																						"<p><a href='https://www.asae.com.mx/asd' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
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
																	"<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #026fa0;'>" +
																		"<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																			"<tr>" +
																				"<td class='counter-text'>" +
																					"<span class='num'></span>" +
																				"</td>" +
																			"</tr>" +
																		"</table>" +
																	"</td>" +
																	"<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #009baf;'>" +
																		"<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
																			"<tr>" +
																				"<td class='counter-text'>" +
																					"<span class='num'></span>" +
																				"</td>" +
																			"</tr>" +
																		"</table>" +
																	"</td>" +
																	"<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #00BCD4;'>" +
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
																		"<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'>Incrementa el 30 por ciento de productividad, con herramientas que analizan y miden el tiempo de trabajo de tu personal.</p>" +
																	"</td>" +
																"</tr>" +
															"</table>" +
														"</td>" +
													"</tr>" +
													"<tr>" +
														"<td style='padding: 1em;'>" +
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
																					"<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Software para documentar analizar mejorar el tiempo de trabajo.</span></p>" +

																					"<p><a href='https://www.asae.com.mx/jobctrl' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
																				"</td>" +
																			"</tr>" +
																		"</table>" +
																	"</td>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<br>" +
					"																<img src='https://www.asae.com.mx/01/CorreTickets.png' alt='' style='width: 90%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400;'>Asae Service Desk (ASD) </h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Ayuda a gerentes de TI a garantizar la continuidad de los servicios de TI dentro de la organización.</span></p>" +

					"																<p><a href='https://www.asae.com.mx/asd' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
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
																						"<p style='margin-top: 0; font-size: 14px; '>¿Quieres recibir más correos electrónicos con nuestras nuevas herramientas y promociones? Usted puede <a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='font-size: 14px; color: #00afc5;'>Darse de alta aquí</a></p>" +
																					"</td>" +
																				"</tr>" +
																				"<tr>" +
																					"<td width='100%' style='text-align: center;'>" +
																						"<table>" +
																							"<tr>" +
																								"<td>" +
																									"<a href='https://twitter.com/asaeconsultores'>" +
																										"<img src='https://www.asae.com.mx/01/004-twitter-logo.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
																									"</a>" +
																								"</td>" +
																								"<td>" +
																									"<a href='https://www.facebook.com/AsaeConsultoresMX/'>" +
																										"<img src='https://www.asae.com.mx/01/005-facebook.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
																									"</a>" +
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
			}
			else
			{
				respuesta = validaciones.EvaludaEmail(model);
			}
			return respuesta;
		}

		public string MensajeJOBCTRL(Models.CorreoEmail model)
		{
			string respuesta = "";
			validaciones validaciones = new validaciones();
			model.email[0].asunto = "Información JOBCTRL";
			model.email[0].App = 3;

			if (model.email[0].telefonolocal == null)
			{
				model.email[0].telefonolocal = "";
			}

			if (validaciones.EvaludaEmail(model) == "ok")
			{
				try
				{
					dtUser.AsaeWebUsuarioMensajeApp(model.email[0]);
				}
				catch
				{

				}

				string host = "mail.asae.com.mx";
				int puerto = 25;
				string usuario = "asae_contactanos@asae.com.mx";
				string contra = "A$ae2018$$_";
				string pCorreo = model.email[0].email.ToString().Trim();

				MailMessage correo = new MailMessage();
				correo.To.Add(new MailAddress(pCorreo));
				correo.CC.Add("oscar.maldonado@asae.com.mx");
				correo.From = new MailAddress(usuario, "ASAE CONSULTORES, S.A DE C.V");
				correo.Subject = model.email[0].asunto.ToString();
				correo.Body = "" +
					"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
					"<html xmlns:v='urn:schemas-microsoft-com:vml'>" +
					"<head>" +
					"	<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />" +
					"	<meta name='viewport' content='width=device-width; initial-scale=1.0; maximum-scale=1.0;' />" +
					"	<link href='https://fonts.googleapis.com/css?family=Nunito+Sans:200,300,400,600,700' rel='stylesheet'>" +
					"	<!--<![endif]-->" +
					"	<title>Asae Consultores S.A de C.V</title>" +
					"	<style type='text/css'> " +
					"		body {" +
					"			width: 100%;" +
					"			background-color: #ffffff;" +
					"			margin: 0; " +
					"			padding: 0;" +
					"			-webkit-font-smoothing: antialiased;" +
					"			mso-margin-top-alt: 0px;" +
					"			mso-margin-bottom-alt: 0px;" +
					"			mso -padding-alt: 0px 0px 0px 0px;" +
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
					"													< h1><a style='color: #000; font-size: 10px; font-weight: 700; text-transform: uppercase;' href='https://www.asae.com.mx/'><img src='https://www.asae.com.mx/images/Tickets/LogoAsae.png' alt='' style='width: 100%; max-width: 500px; height: auto; margin: auto; display: block;'></a></h1>" +
					"												  </td>" +
					"												  <td width='55%' class='logo' style='text-align: right;'>" +
					"													<table width='100%' border='0' cellpadding='0' cellspacing='0' style='border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;' class='container590 hide'>" +
					"														<tr>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500; '>" +
					"																<a href='https://www.asae.com.mx/' style='color: #adadad;'>Inicio </a>" +
					"															</td>" +
					"															<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
					"																<a href='https://www.asae.com.mx/jobctrl' style='color: #adadad;'>JobCTRL </a>" +
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
					"									<td align='center' valign='middle' class='hero bg_white' style=' position: relative; z-index: 0;'>" +
					"									  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%'>" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td>" +
					"														<img src='https://www.asae.com.mx/01/JobCTRL/Flexibilidad_Control.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"											</td>" +
					"											<td valign='middle' width='50%' >" +
					"											  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"												<tr>" +
					"												  <td class='text' style='text-align: left; padding: 20px 30px;'>" +
					"														<h2 style='color: #FF6600; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.3;'>Gracias por enviar tu mensaje </h2>" +
					"														<p style='font-size: 14px; line-height: 1.5; color: #676466;'> Suscríbete y recibe nuestras ultimas noticias y promociones en las mejores herramientas en soluciones TI.</p>" +
					"														<p><a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='border-radius: 5px;background: #FF6600; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;' >Suscribirme</a></p>" +
					"												  </td>" +
					"												</tr>" +
					"											  </table>" +
					"											</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +

					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 2.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"													<p style='font-size: 19px; color: #FF6600;'>" +
					"													Te agradecemos que nos hayas contactado, en breve un ejecutivo te contactara para atender tus dudas y / o comentarios.</p>" +
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
					"									<td  style='    padding: 2.5em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/JobCTRL/LogoJobCtrl_trans.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='50%'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left; padding-left:25px;'>" +
					"																<div class='heading-section'>" +
					"																	<h2 style='color: #676466; font-size: 21px; font-weight: 300;margin-top: 0; line-height: 1.3; font-weight: 400;'>Equipos de colaboradores en Home Office más productivos.</h2>" +
					"																	<p style='font-size: 12px; line-height: 1.8; color: #b9b9b9;'><strong>JOBCTRL</strong> Documenta las tareas, actividades y desempeño en tiempo real en una sola plataforma.</p>" +
					"																	<p><a href='https://www.asae.com.mx/jobctrl' style='border-radius: 5px;background: #FF6600; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"																</div>" +
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
					"								<tr>" +
					"									<td style='padding: 1em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<br>" +
					"																<img src='https://www.asae.com.mx/01/CorreTickets.png' alt='' style='width: 90%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400;'>Asae Service Desk (ASD) </h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Ayuda a gerentes de TI a garantizar la continuidad de los servicios de TI dentro de la organización.</span></p>" +

					"																<p><a href='https://www.asae.com.mx/asd' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/blog-2.jpg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>Xpinnit</h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Software de gestión de proyectos </span></p>" +

					"																<p><a href='https://www.asae.com.mx/xpinnit' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
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
					"</html>" +
					   "";

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
			}
			else
			{
				respuesta = validaciones.EvaludaEmail(model);
			}
			return respuesta;
		}

		public string MensajeHikvision(Models.CorreoEmail model)
		{
			string respuesta = "";
			validaciones validaciones = new validaciones();
			model.email[0].asunto = "Información HIKVISION";
			model.email[0].App = 4;

			if (model.email[0].telefonolocal == null)
			{
				model.email[0].telefonolocal = "";
			}

			if (validaciones.EvaludaEmail(model) == "ok")
			{
				try
				{
					dtUser.AsaeWebUsuarioMensajeApp(model.email[0]);
				}
				catch
				{

				}

				string host = "mail.asae.com.mx";
				int puerto = 25;
				string usuario = "asae_contactanos@asae.com.mx";
				string contra = "A$ae2018$$_";
				string pCorreo = model.email[0].email.ToString().Trim();

				MailMessage correo = new MailMessage();
				correo.To.Add(new MailAddress(pCorreo));
				correo.CC.Add("gabriel.cruz@asaeop.com.mx");
				correo.From = new MailAddress(usuario, "ASAE CONSULTORES, S.A DE C.V");
				correo.Subject = model.email[0].asunto.ToString();
				correo.Body = "" +
					"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
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
					"									<td align='center' valign='middle' class='hero bg_white' style=' position: relative; z-index: 0;'>" +
					"									  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%'>" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td>" +
					"														<img src='https://www.asae.com.mx/01/Hikvision/camaras-de-vigilancia-hikvsion.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"											</td>" +
					"											<td valign='middle' width='50%' >" +
					"											  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"												<tr>" +
					"												  <td class='text' style='text-align: left; padding: 20px 30px;'>" +
					"														<h2 style='color: #b53c3c; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.3;'>Gracias por enviar tu mensaje </h2>" +
					"														<p style='font-size: 14px; line-height: 1.5; color: #676466;'> Suscríbete y recibe nuestras ultimas noticias y promociones en las mejores herramientas en soluciones TI.</p>" +
					"														<p><a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='border-radius: 5px;background: #b53c3c; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;' >Suscribirme</a></p>" +
					"												  </td>" +
					"												</tr>" +
					"											  </table>" +
					"											</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +

					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 2.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"													<p style='font-size: 19px; color: #b53c3c;'>" +
					"													Te agradecemos que nos hayas contactado, en breve un ejecutivo te contactara para atender tus dudas y / o comentarios.</p>" +
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
					"									<td  style='    padding: 2.5em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/Hikvision/Hikivision.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='50%'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left; padding-left:25px;'>" +
					"																<div class='heading-section'>" +
					"																	<h2 style='color: #676466; font-size: 21px; font-weight: 300;margin-top: 0; line-height: 1.3; font-weight: 400;'>Visibilidad total en complejos residenciales.</h2>" +
					"																	<p style='font-size: 12px; line-height: 1.8; color: #b9b9b9;'> Elimine falsas alarmas, riesgos de intrusos y visitantes desconocidos en un solo sistema de videvigilancia..</p>" +
					"																	<p><a href='https://www.asae.com.mx/hikvision' style='border-radius: 5px;background: #b53c3c; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"																</div>" +
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
					"								</tr>" +
					"								<tr>" +
					"									<td style='padding: 1em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<br>" +
					"																<img src='https://www.asae.com.mx/01/CorreTickets.png' alt='' style='width: 90%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400;'>Asae Service Desk (ASD) </h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Ayuda a gerentes de TI a garantizar la continuidad de los servicios de TI dentro de la organización.</span></p>" +

					"																<p><a href='https://www.asae.com.mx/asd' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/blog-1.jpg' alt='' style='width: 100%; max-width: 550px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>JobCTRL</h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Software para documentar analizar mejorar el tiempo de trabajo. </span></p>" +

					"																<p><a href='https://www.asae.com.mx/jobctrl' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
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
					"</html>" +
					   "";

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
			}
			else
			{
				respuesta = validaciones.EvaludaEmail(model);
			}
			return respuesta;
		}

		public string MensajeHuawei(Models.CorreoEmail model)
		{
			string respuesta = "";
			validaciones validaciones = new validaciones();
			model.email[0].asunto = "Información Centro de datos all-flash OceanStor Dorado V6";
			model.email[0].App = 5;

			if (model.email[0].telefonolocal == null)
			{
				model.email[0].telefonolocal = "";
			}

			if (validaciones.EvaludaEmail(model) == "ok")
			{
				try
				{
					dtUser.AsaeWebUsuarioMensajeApp(model.email[0]);
				}
				catch
				{

				}

				string host = "mail.asae.com.mx";
				int puerto = 25;
				string usuario = "asae_contactanos@asae.com.mx";
				string contra = "A$ae2018$$_";
				string pCorreo = model.email[0].email.ToString().Trim();

				MailMessage correo = new MailMessage();
				correo.To.Add(new MailAddress(pCorreo));
				correo.CC.Add("gabriel.cruz@asaeop.com.mx");
				correo.From = new MailAddress(usuario, "ASAE CONSULTORES, S.A DE C.V");
				correo.Subject = model.email[0].asunto.ToString();
				correo.Body = "" +
					"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
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
					"																<a href='https://www.asae.com.mx/oceanstor-dorado' style='color: #adadad;'>Oceanstor Dorado </a>" +
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
					"									<td align='center' valign='middle' class='hero bg_white' style=' position: relative; z-index: 0;'>" +
					"									  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%'>" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td>" +
					"														<img src='https://www.asae.com.mx/01/oceanstor-dorado/OceanstorDoradoV6.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"											</td>" +
					"											<td valign='middle' width='50%' >" +
					"											  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"												<tr>" +
					"												  <td class='text' style='text-align: left; padding: 20px 30px;'>" +
					"														<h2 style='color: #223C60; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.3;'>Gracias por enviar tu mensaje </h2>" +
					"														<p style='font-size: 14px; line-height: 1.5; color: #676466;'> Suscríbete y recibe nuestras ultimas noticias y promociones en las mejores herramientas en soluciones TI.</p>" +
					"														<p><a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;' >Suscribirme</a></p>" +
					"												  </td>" +
					"												</tr>" +
					"											  </table>" +
					"											</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +

					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 2.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"													<p style='font-size: 19px; color: #223C60;'>" +
					"													Te agradecemos que nos hayas contactado, en breve un ejecutivo te contactara para atender tus dudas y / o comentarios.</p>" +
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
					"									<td  style='    padding: 2.5em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/oceanstor-dorado/OceanstorDoradoV6.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='50%'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left; padding-left:25px;'>" +
					"																<div class='heading-section'>" +
					"																	<h2 style='color: #676466; font-size: 21px; font-weight: 300;margin-top: 0; line-height: 1.3; font-weight: 400;'>Aloje sus datos en un entorno más rápido, más ecológico y más confiable. Diseñado para servicios de misión crítica.</h2>" +
					"																	<p style='font-size: 12px; line-height: 1.8; color: #b9b9b9;'> Más rápido que nunca con innovadoras arquitecturas y hardware.</p>" +
					"																	<p><a href='https://www.asae.com.mx/oceanstor-dorado' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"																</div>" +
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
					"												<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #4473B5;'>" +
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
					"								<tr>" +
					"									<td style='padding: 1em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<br>" +
					"																<img src='https://www.asae.com.mx/01/CorreTickets.png' alt='' style='width: 90%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400;'>Asae Service Desk (ASD) </h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Ayuda a gerentes de TI a garantizar la continuidad de los servicios de TI dentro de la organización.</span></p>" +

					"																<p><a href='https://www.asae.com.mx/asd' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/blog-1.jpg' alt='' style='width: 100%; max-width: 550px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>JobCTRL</h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Software para documentar analizar mejorar el tiempo de trabajo. </span></p>" +

					"																<p><a href='https://www.asae.com.mx/jobctrl' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
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
					"</html>" +
					   "";

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
			}
			else
			{
				respuesta = validaciones.EvaludaEmail(model);
			}
			return respuesta;
		}

		public string MensajeIdeaHub(Models.CorreoEmail model)
		{
			string respuesta = "";
			validaciones validaciones = new validaciones();
			model.email[0].asunto = "Información IdeaHub de Huawei";
			model.email[0].App = 6;

			if (model.email[0].telefonolocal == null)
			{
				model.email[0].telefonolocal = "";
			}

			if (validaciones.EvaludaEmail(model) == "ok")
			{
				try
				{
					dtUser.AsaeWebUsuarioMensajeApp(model.email[0]);
				}
				catch
				{

				}

				string host = "mail.asae.com.mx";
				int puerto = 25;
				string usuario = "asae_contactanos@asae.com.mx";
				string contra = "A$ae2018$$_";
				string pCorreo = model.email[0].email.ToString().Trim();

				MailMessage correo = new MailMessage();
				correo.To.Add(new MailAddress(pCorreo));
				correo.CC.Add("gabriel.cruz@asaeop.com.mx");
				correo.From = new MailAddress(usuario, "ASAE CONSULTORES, S.A DE C.V");
				correo.Subject = model.email[0].asunto.ToString();
				correo.Body = "" +
					"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
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
					"									<td align='center' valign='middle' class='hero bg_white' style=' position: relative; z-index: 0;'>" +
					"									  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%'>" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td>" +
					"														<img src='https://www.asae.com.mx/01/Ideahub/ideahub.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"											</td>" +
					"											<td valign='middle' width='50%' >" +
					"											  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"												<tr>" +
					"												  <td class='text' style='text-align: left; padding: 20px 30px;'>" +
					"														<h2 style='color: #223C60; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.3;'>Gracias por enviar tu mensaje </h2>" +
					"														<p style='font-size: 14px; line-height: 1.5; color: #676466;'> Suscríbete y recibe nuestras ultimas noticias y promociones en las mejores herramientas en soluciones TI.</p>" +
					"														<p><a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;' >Suscribirme</a></p>" +
					"												  </td>" +
					"												</tr>" +
					"											  </table>" +
					"											</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +

					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 2.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"													<p style='font-size: 19px; color: #223C60;'>" +
					"													Te agradecemos que nos hayas contactado, en breve un ejecutivo te contactara para atender tus dudas y / o comentarios.</p>" +
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
					"									<td  style='    padding: 2.5em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/ideahub/ideahub.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='50%'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left; padding-left:25px;'>" +
					"																<div class='heading-section'>" +
					"																	<h2 style='color: #676466; font-size: 21px; font-weight: 300;margin-top: 0; line-height: 1.3; font-weight: 400;'>IdeaHub de Huawei, una herramienta de productividad para la oficina inteligente, Incluye escritura inteligente, </h2>" +
					"																	<p style='font-size: 12px; line-height: 1.8; color: #b9b9b9;'> videoconferencias de alta definición (HD) y uso compartido inalámbrico.</p>" +
					"																	<p><a href='https://www.asae.com.mx/huawei-ideahub' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"																</div>" +
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
					"								</tr>" +
					"								<tr>" +
					"									<td style='padding: 1em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<br>" +
					"																<img src='https://www.asae.com.mx/01/CorreTickets.png' alt='' style='width: 90%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400;'>Asae Service Desk (ASD) </h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Ayuda a gerentes de TI a garantizar la continuidad de los servicios de TI dentro de la organización.</span></p>" +

					"																<p><a href='https://www.asae.com.mx/asd' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/blog-1.jpg' alt='' style='width: 100%; max-width: 550px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>JobCTRL</h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Software para documentar analizar mejorar el tiempo de trabajo. </span></p>" +

					"																<p><a href='https://www.asae.com.mx/jobctrl' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
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
					"</html>" +
					   "";

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
			}
			else
			{
				respuesta = validaciones.EvaludaEmail(model);
			}
			return respuesta;
		}

		public string MensajeCorporativoIndustrial(Models.CorreoEmail model)
		{
			string respuesta = "";
			validaciones validaciones = new validaciones();
			model.email[0].asunto = "Información Corporativo e industrial";
			model.email[0].App = 7;

			if (model.email[0].telefonolocal == null)
			{
				model.email[0].telefonolocal = "";
			}

			if (validaciones.EvaludaEmail(model) == "ok")
			{
				try
				{
					dtUser.AsaeWebUsuarioMensajeApp(model.email[0]);
				}
				catch
				{

				}

				string host = "mail.asae.com.mx";
				int puerto = 25;
				string usuario = "asae_contactanos@asae.com.mx";
				string contra = "A$ae2018$$_";
				string pCorreo = model.email[0].email.ToString().Trim();

				MailMessage correo = new MailMessage();
				correo.To.Add(new MailAddress(pCorreo));
				correo.CC.Add("valdemar.gonzales@asaeop.com.mx");
				correo.From = new MailAddress(usuario, "ASAE CONSULTORES, S.A DE C.V");
				correo.Subject = model.email[0].asunto.ToString();
				correo.Body = "" +
					"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
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
					"																<a href='https://www.asae.com.mx/corporativo-e-industria' style='color: #adadad;'>Corporativo e industria  </a>" +
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
					"									<td align='center' valign='middle' class='hero bg_white' style=' position: relative; z-index: 0;'>" +
					"									  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%'>" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td>" +
					"														<img src='https://www.asae.com.mx/01/Hikvision/camaras-de-vigilancia-hikvsion.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"											</td>" +
					"											<td valign='middle' width='50%' >" +
					"											  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"												<tr>" +
					"												  <td class='text' style='text-align: left; padding: 20px 30px;'>" +
					"														<h2 style='color: #b53c3c; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.3;'>Gracias por enviar tu mensaje </h2>" +
					"														<p style='font-size: 14px; line-height: 1.5; color: #676466;'> Suscríbete y recibe nuestras ultimas noticias y promociones en las mejores herramientas en soluciones TI.</p>" +
					"														<p><a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='border-radius: 5px;background: #b53c3c; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;' >Suscribirme</a></p>" +
					"												  </td>" +
					"												</tr>" +
					"											  </table>" +
					"											</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +

					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 2.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"													<p style='font-size: 19px; color: #b53c3c;'>" +
					"													Te agradecemos que nos hayas contactado, en breve un ejecutivo te contactara para atender tus dudas y / o comentarios.</p>" +
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
					"									<td  style='    padding: 2.5em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/Hikvision/Hikivision.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='50%'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left; padding-left:25px;'>" +
					"																<div class='heading-section'>" +
					"																	<h2 style='color: #676466; font-size: 21px; font-weight: 300;margin-top: 0; line-height: 1.3; font-weight: 400;'>Grandes productos, grandes socios.</h2>" +
					"																	<p style='font-size: 12px; line-height: 1.8; color: #b9b9b9;'> Proveedor líder mundial de productos y soluciones de videovigilancia. Un socio enfocado en todas las demandas de videovigilancia del mercado de seguridad global.</p>" +
					"																	<p><a href='https://www.asae.com.mx/corporativo-e-industria' style='border-radius: 5px;background: #b53c3c; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"																</div>" +
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
					"								</tr>" +
					"								<tr>" +
					"									<td style='padding: 1em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<br>" +
					"																<img src='https://www.asae.com.mx/images/Tickets/Banner2.png' alt='' style='width: 90%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400;'>Asae Service Desk (ASD) </h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Ayuda a gerentes de TI a garantizar la continuidad de los servicios de TI dentro de la organización.</span></p>" +

					"																<p><a href='https://www.asae.com.mx/asd' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/blog-1.jpg' alt='' style='width: 100%; max-width: 550px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>JobCTRL</h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Software para documentar analizar mejorar el tiempo de trabajo. </span></p>" +

					"																<p><a href='https://www.asae.com.mx/jobctrl' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
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
					"</html>" +
					   "";

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
			}
			else
			{
				respuesta = validaciones.EvaludaEmail(model);
			}
			return respuesta;
		}

		public string MensajeServiciosSoluciones(Models.CorreoEmail model)
		{
			string respuesta = "";
			validaciones validaciones = new validaciones();
			model.email[0].asunto = "Soluciones tecnológicas para tu empresa";
			model.email[0].App = 28;

			if (model.email[0].telefonolocal == null)
			{
				model.email[0].telefonolocal = "";
			}

			if (validaciones.EvaludaEmail(model) == "ok")
			{
				try
				{
					dtUser.AsaeWebUsuarioMensajeApp(model.email[0]);
				}
				catch
				{

				}

				string host = "mail.asae.com.mx";
				int puerto = 25;
				string usuario = "asae_contactanos@asae.com.mx";
				string contra = "A$ae2018$$_";
				string pCorreo = model.email[0].email.ToString().Trim();

				MailMessage correo = new MailMessage();
				correo.To.Add(new MailAddress(pCorreo));
				correo.CC.Add("asae_contactanos@asae.com.mx");
				correo.CC.Add("francisco.acevedo@asae.com.mx");
				correo.From = new MailAddress(usuario, "ASAE CONSULTORES, S.A DE C.V");
				correo.Subject = model.email[0].asunto.ToString();
				correo.Body = "" +
					"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
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
					"									<td align='center' valign='middle' class='hero bg_white' style=' position: relative; z-index: 0;'>" +
					"									  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%'>" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td>" +
					"														<img src='https://www.asae.com.mx/01/ServiciosSoluciones/edificios.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"											</td>" +
					"											<td valign='middle' width='50%' >" +
					"											  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"												<tr>" +
					"												  <td class='text' style='text-align: left; padding: 20px 30px;'>" +
					"														<h2 style='color: #316192; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.3;'>Gracias por enviar tu mensaje </h2>" +
					"														<p style='font-size: 14px; line-height: 1.5; color: #676466;'> Suscríbete y recibe nuestras ultimas noticias y promociones en las mejores herramientas en soluciones TI.</p>" +
					"														<p><a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='border-radius: 5px;background: #316192; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;' >Suscribirme</a></p>" +
					"												  </td>" +
					"												</tr>" +
					"											  </table>" +
					"											</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +

					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 2.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"													<p style='font-size: 19px; color: #316192;'>" +
					"													Te agradecemos que nos hayas contactado, en breve un ejecutivo te contactara para atender tus dudas y / o comentarios.</p>" +
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
					"									<td  style='    padding: 2.5em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/ServiciosSoluciones/edificios.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='50%'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left; padding-left:25px;'>" +
					"																<div class='heading-section'>" +
					"																	<h2 style='color: #676466; font-size: 21px; font-weight: 300;margin-top: 0; line-height: 1.3; font-weight: 400;'>SOLUCIONES TECNOLÓGICAS PARA TU EMPRESA.</h2>" +
					"																	<p style='font-size: 12px; line-height: 1.8; color: #b9b9b9;'>Somos la empresa #1 integradora de tecnología para empresas nacionales e internacionales, abarcando productos y servicios para mercados verticales y soluciones horizontales.</p>" +
					"																	<p><a href='https://www.asae.com.mx/servicios-y-soluciones' style='border-radius: 5px;background: #316192; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"																</div>" +
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
					//"								</tr>" +
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
					"</html>" +
					   "";

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
			}
			else
			{
				respuesta = validaciones.EvaludaEmail(model);
			}
			return respuesta;
		}

		public string MensajeTalentoHumano(Models.CorreoEmail model)
		{
			string respuesta = "";
			validaciones validaciones = new validaciones();
			model.email[0].asunto = "Reclutamos al mejor personal de ti para tu negocio";
			model.email[0].App = 33;

			if (model.email[0].telefonolocal == null)
			{
				model.email[0].telefonolocal = "";
			}

			if (validaciones.EvaludaEmail(model) == "ok")
			{
				try
				{
					dtUser.AsaeWebUsuarioMensajeApp(model.email[0]);
				}
				catch
				{

				}

				string host = "mail.asae.com.mx";
				int puerto = 25;
				string usuario = "asae_contactanos@asae.com.mx";
				string contra = "A$ae2018$$_";
				string pCorreo = model.email[0].email.ToString().Trim();

				MailMessage correo = new MailMessage();
				correo.To.Add(new MailAddress(pCorreo));
				correo.CC.Add("asae_contactanos@asae.com.mx");
				correo.CC.Add("francisco.acevedo@asae.com.mx");
				correo.From = new MailAddress(usuario, "ASAE CONSULTORES, S.A DE C.V");
				correo.Subject = model.email[0].asunto.ToString();
				correo.Body = "" +
					"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
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
					"									<td align='center' valign='middle' class='hero bg_white' style=' position: relative; z-index: 0;'>" +
					"									  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%'>" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td>" +
					"														<img src='https://www.asae.com.mx/01/TalentoHumano/s.jpg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"											</td>" +
					"											<td valign='middle' width='50%' >" +
					"											  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"												<tr>" +
					"												  <td class='text' style='text-align: left; padding: 20px 30px;'>" +
					"														<h2 style='color: #316192; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.3;'>Gracias por enviar tu mensaje </h2>" +
					"														<p style='font-size: 14px; line-height: 1.5; color: #676466;'> Suscríbete y recibe nuestras ultimas noticias y promociones en las mejores herramientas en soluciones TI.</p>" +
					"														<p><a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='border-radius: 5px;background: #316192; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;' >Suscribirme</a></p>" +
					"												  </td>" +
					"												</tr>" +
					"											  </table>" +
					"											</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +

					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 2.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"													<p style='font-size: 19px; color: #316192;'>" +
					"													Te agradecemos que nos hayas contactado, en breve un ejecutivo te contactara para atender tus dudas y / o comentarios.</p>" +
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
					"									<td  style='    padding: 2.5em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/TalentoHumano/s.jpg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='50%'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left; padding-left:25px;'>" +
					"																<div class='heading-section'>" +
					"																	<h2 style='color: #676466; font-size: 21px; font-weight: 300;margin-top: 0; line-height: 1.3; font-weight: 400;'>¡RECLUTAMOS AL MEJOR PERSONAL DE TI PARA TU NEGOCIO!</h2>" +
					"																	<p style='font-size: 12px; line-height: 1.8; color: #b9b9b9;'> Somos la empresa de reclutamiento más ágil y efectiva en México, con más de 30 años de experiencia colocando personal especializado en empresas nacionales e internacionales.</p>" +
					"																	<p><a href='https://www.asae.com.mx/talento-humano' style='border-radius: 5px;background: #316192; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"																</div>" +
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
					//"								</tr>" +
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
					"</html>" +
					   "";

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
			}
			else
			{
				respuesta = validaciones.EvaludaEmail(model);
			}
			return respuesta;
		}

		public string MensajeEventoCorporativo(Models.CorreoEmail model)
		{
			string respuesta = "";
			validaciones validaciones = new validaciones();
			model.email[0].asunto = "Información renta de espacios corporativos";
			model.email[0].App = 27;

			if (model.email[0].telefonolocal == null)
			{
				model.email[0].telefonolocal = "";
			}

			if (validaciones.EvaludaEmail(model) == "ok")
			{
				try
				{
					dtUser.AsaeWebUsuarioMensajeApp(model.email[0]);
				}
				catch
				{

				}

				string host = "mail.asae.com.mx";
				int puerto = 25;
				string usuario = "asae_contactanos@asae.com.mx";
				string contra = "A$ae2018$$_";
				string pCorreo = model.email[0].email.ToString().Trim();

				MailMessage correo = new MailMessage();
				correo.To.Add(new MailAddress(pCorreo));
				correo.CC.Add("gabriel.cruz@asaeop.com.mx");
				correo.From = new MailAddress(usuario, "ASAE CONSULTORES, S.A DE C.V");
				correo.Subject = model.email[0].asunto.ToString();
				correo.Body = "" +
					"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
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
					"									<td align='center' valign='middle' class='hero bg_white' style=' position: relative; z-index: 0;'>" +
					"									  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%'>" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td>" +
					"														<img src='https://www.asae.com.mx/01/EventosCorporativos/salas.jpg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"											</td>" +
					"											<td valign='middle' width='50%' >" +
					"											  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"												<tr>" +
					"												  <td class='text' style='text-align: left; padding: 20px 30px;'>" +
					"														<h2 style='color: #223C60; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.3;'>Gracias por enviar tu mensaje </h2>" +
					"														<p style='font-size: 14px; line-height: 1.5; color: #676466;'> Suscríbete y recibe nuestras ultimas noticias y promociones en las mejores herramientas en soluciones TI.</p>" +
					"														<p><a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;' >Suscribirme</a></p>" +
					"												  </td>" +
					"												</tr>" +
					"											  </table>" +
					"											</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +

					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 2.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"													<p style='font-size: 19px; color: #223C60;'>" +
					"													Te agradecemos que nos hayas contactado, en breve un ejecutivo te contactara para atender tus dudas y / o comentarios.</p>" +
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
					"									<td  style='    padding: 2.5em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/EventosCorporativos/salas.jpg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='50%'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left; padding-left:25px;'>" +
					"																<div class='heading-section'>" +
					"																	<h2 style='color: #676466; font-size: 21px; font-weight: 300;margin-top: 0; line-height: 1.3; font-weight: 400;'>En ASAE tenemos espacios para todotipo de eventos corporativos.</h2>" +
					"																	<p style='font-size: 12px; line-height: 1.8; color: #b9b9b9;'> Haz tus eventos corporativos en un entorno inteligente y dinámico.</p>" +
					"																	<p><a href='https://www.asae.com.mx/renta-espacios-corporativos' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"																</div>" +
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
					"								</tr>" +
					"								<tr>" +
					"									<td style='padding: 1em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<br>" +
					"																<img src='https://www.asae.com.mx/01/CorreTickets.png' alt='' style='width: 90%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400;'>Asae Service Desk (ASD) </h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Ayuda a gerentes de TI a garantizar la continuidad de los servicios de TI dentro de la organización.</span></p>" +

					"																<p><a href='https://www.asae.com.mx/asd' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/blog-1.jpg' alt='' style='width: 100%; max-width: 550px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>JobCTRL</h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Software para documentar analizar mejorar el tiempo de trabajo. </span></p>" +

					"																<p><a href='https://www.asae.com.mx/jobctrl' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
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
					"</html>" +
					   "";

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
			}
			else
			{
				respuesta = validaciones.EvaludaEmail(model);
			}
			return respuesta;
		}

		public string MensajeBanTotal(Models.CorreoEmail model)
		{
			string respuesta = "";
			validaciones validaciones = new validaciones();
			model.email[0].asunto = "Información BanTotal";
			model.email[0].App = 26;

			if (model.email[0].telefonolocal == null)
			{
				model.email[0].telefonolocal = "";
			}

			if (validaciones.EvaludaEmail(model) == "ok")
			{
				try
				{
					dtUser.AsaeWebUsuarioMensajeApp(model.email[0]);
				}
				catch
				{

				}

				string host = "mail.asae.com.mx";
				int puerto = 25;
				string usuario = "asae_contactanos@asae.com.mx";
				string contra = "A$ae2018$$_";
				string pCorreo = model.email[0].email.ToString().Trim();

				MailMessage correo = new MailMessage();
				correo.To.Add(new MailAddress(pCorreo));
				correo.CC.Add("oscar.maldonado@asae.com.mx");
				correo.From = new MailAddress(usuario, "ASAE CONSULTORES, S.A DE C.V");
				correo.Subject = model.email[0].asunto.ToString();
				correo.Body = "" +
					"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
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
					"																<a href='https://www.asae.com.mx/bantotal' style='color: #adadad;'> BanTotal  </a>" +
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
					"									<td align='center' valign='middle' class='hero bg_white' style=' position: relative; z-index: 0;'>" +
					"									  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%'>" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td>" +
					"														<img src='https://www.asae.com.mx/01/BanTotal/imageCorreo.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"											</td>" +
					"											<td valign='middle' width='50%' >" +
					"											  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"												<tr>" +
					"												  <td class='text' style='text-align: left; padding: 20px 30px;'>" +
					"														<h2 style='color: #223C60; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.3;'>Gracias por enviar tu mensaje </h2>" +
					"														<p style='font-size: 14px; line-height: 1.5; color: #676466;'> Suscríbete y recibe nuestras ultimas noticias y promociones en las mejores herramientas en soluciones TI.</p>" +
					"														<p><a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;' >Suscribirme</a></p>" +
					"												  </td>" +
					"												</tr>" +
					"											  </table>" +
					"											</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +

					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 2.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"													<p style='font-size: 19px; color: #223C60;'>" +
					"													Te agradecemos que nos hayas contactado, en breve un ejecutivo te contactara para atender tus dudas y / o comentarios.</p>" +
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
					"									<td  style='    padding: 2.5em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/BanTotal/imageCorreo.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='50%'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left; padding-left:25px;'>" +
					"																<div class='heading-section'>" +
					"																	<h2 style='color: #676466; font-size: 21px; font-weight: 300;margin-top: 0; line-height: 1.3; font-weight: 400;'>La plataforma bancaria completamente centrada en el cliente.</h2>" +
					"																	<p style='font-size: 12px; line-height: 1.8; color: #b9b9b9;'> Bantotal es la solución líder en latinoamérica que resuelve la operativa de misión crítica de las Instituciones Financieras en forma simple, completa y precisa.</p>" +
					"																	<p><a href='https://www.asae.com.mx/bantotal' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"																</div>" +
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
					"								</tr>" +
					"								<tr>" +
					"									<td style='padding: 1em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<br>" +
					"																<img src='https://www.asae.com.mx/01/CorreTickets.png' alt='' style='width: 90%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400;'>Asae Service Desk (ASD) </h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Ayuda a gerentes de TI a garantizar la continuidad de los servicios de TI dentro de la organización.</span></p>" +

					"																<p><a href='https://www.asae.com.mx/asd' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/blog-1.jpg' alt='' style='width: 100%; max-width: 550px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>JobCTRL</h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Software para documentar analizar mejorar el tiempo de trabajo. </span></p>" +

					"																<p><a href='https://www.asae.com.mx/jobctrl' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
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
					"</html>" +
					   "";

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
			}
			else
			{
				respuesta = validaciones.EvaludaEmail(model);
			}
			return respuesta;
		}

		public string MensajeEventos(Models.CorreoEmail model)
		{
			string respuesta = "";
			validaciones validaciones = new validaciones();
			model.email[0].asunto = "Información de eventos corporativos";
			model.email[0].App = 25;

			if (model.email[0].telefonolocal == null)
			{
				model.email[0].telefonolocal = "";
			}

			if (validaciones.EvaludaEmail(model) == "ok")
			{
				try
				{
					dtUser.AsaeWebUsuarioMensajeApp(model.email[0]);
				}
				catch
				{

				}

				string host = "mail.asae.com.mx";
				int puerto = 25;
				string usuario = "asae_contactanos@asae.com.mx";
				string contra = "A$ae2018$$_";
				string pCorreo = model.email[0].email.ToString().Trim();

				MailMessage correo = new MailMessage();
				correo.To.Add(new MailAddress(pCorreo));
				correo.CC.Add("gabriel.cruz@asaeop.com.mx");
				correo.From = new MailAddress(usuario, "ASAE CONSULTORES, S.A DE C.V");
				correo.Subject = model.email[0].asunto.ToString();
				correo.Body = "" +
					"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
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
					"																<a href='https://www.asae.com.mx/eventos-corporativos' style='color: #adadad;'> Eventos Corporativos </a>" +
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
					"									<td align='center' valign='middle' class='hero bg_white' style=' position: relative; z-index: 0;'>" +
					"									  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%'>" +
					"												  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"													<tr>" +
					"													  <td>" +
					"														<img src='https://www.asae.com.mx/01/EventosCorporativos/Coffe.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"													  </td>" +
					"													</tr>" +
					"												  </table>" +
					"											</td>" +
					"											<td valign='middle' width='50%' >" +
					"											  <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"												<tr>" +
					"												  <td class='text' style='text-align: left; padding: 20px 30px;'>" +
					"														<h2 style='color: #223C60; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.3;'>Gracias por enviar tu mensaje </h2>" +
					"														<p style='font-size: 14px; line-height: 1.5; color: #676466;'> Suscríbete y recibe nuestras ultimas noticias y promociones en las mejores herramientas en soluciones TI.</p>" +
					"														<p><a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;' >Suscribirme</a></p>" +
					"												  </td>" +
					"												</tr>" +
					"											  </table>" +
					"											</td>" +
					"											</tr>" +
					"										</table>" +
					"									</td>" +
					"								</tr>" +

					"								<tr>" +
					"									<td align='center' style=''>" +
					"										<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 2.5em;'>" +
					"											<tr>" +
					"												<td align='center' style='padding: 1em 4em;'>" +
					"													<p style='font-size: 19px; color: #223C60;'>" +
					"													Te agradecemos que nos hayas contactado, en breve un ejecutivo te contactara para atender tus dudas y / o comentarios.</p>" +
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
					"									<td  style='    padding: 2.5em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='middle' width='50%'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/EventosCorporativos/Banquetes.jpg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='middle' width='50%'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left; padding-left:25px;'>" +
					"																<div class='heading-section'>" +
					"																	<h2 style='color: #676466; font-size: 21px; font-weight: 300;margin-top: 0; line-height: 1.3; font-weight: 400;'>Consiente a tus clientes y convence a tus prospectos con un evento memorable en un espacio inspirador.</h2>" +
					"																	<p style='font-size: 12px; line-height: 1.8; color: #b9b9b9;'> Estamos preparados para acompañar tu evento con una selección deliciosa y amplia de alimentos y bebidas realizadas por un equipo de chefs profesionales. </p>" +
					"																	<p><a href='https://www.asae.com.mx/eventos-corporativos' style='border-radius: 5px;background: #223C60; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"																</div>" +
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
					"								</tr>" +
					"								<tr>" +
					"									<td style='padding: 1em;'>" +
					"										<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
					"											<tr>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<br>" +
					"																<img src='https://www.asae.com.mx/01/CorreTickets.png' alt='' style='width: 90%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400;'>Asae Service Desk (ASD) </h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Ayuda a gerentes de TI a garantizar la continuidad de los servicios de TI dentro de la organización.</span></p>" +

					"																<p><a href='https://www.asae.com.mx/asd' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
					"															</td>" +
					"														</tr>" +
					"													</table>" +
					"												</td>" +
					"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
					"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
					"														<tr>" +
					"															<td>" +
					"																<img src='https://www.asae.com.mx/01/blog-1.jpg' alt='' style='width: 100%; max-width: 550px; height: auto; margin: auto; display: block;'>" +
					"															</td>" +
					"														</tr>" +
					"														<tr>" +
					"															<td class='text-services' style='text-align: left;'>" +
					"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400; '>JobCTRL</h3>" +
					"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Software para documentar analizar mejorar el tiempo de trabajo. </span></p>" +

					"																<p><a href='https://www.asae.com.mx/jobctrl' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
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
					"</html>" +
					   "";

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
			}
			else
			{
				respuesta = validaciones.EvaludaEmail(model);
			}
			return respuesta;
		}

        /********************************************************************************************************************************************/
        /********************************************************************************************************************************************/

        public string MensajeAsaeASD(Models.CorreoEmail model)
        {
            string respuesta = "";
            validaciones validaciones = new validaciones();
            model.email[0].asunto = "Información ASAE SERVICE DESK (ASD)";
            model.email[0].App = 2;

            if (model.email[0].telefonolocal == null)
            {
                model.email[0].telefonolocal = "";
            }

            if (validaciones.EvaludaEmail(model) == "ok")
            {
                try
                {
                    dtUser.AsaeWebUsuarioMensajeApp(model.email[0]);
                }
                catch
                {

                }

                string host = "mail.asae.com.mx";
                int puerto = 25;
                string usuario = "asae_contactanos@asae.com.mx";
                string contra = "A$ae2018$$_";
                string pCorreo = model.email[0].email.ToString().Trim();


                MailMessage correo = new MailMessage();
                correo.To.Add(new MailAddress(pCorreo));
                correo.CC.Add("francisco.acevedo@asae.com.mx");
                correo.CC.Add("guillermo.rojas@asae.com.mx");
				correo.CC.Add("soporte-aplicaciones@asae.com.mx");
                correo.From = new MailAddress(usuario, "ASAE CONSULTORES, S.A DE C.V");
                correo.Subject = model.email[0].asunto.ToString();
                correo.Body = "" +
                    "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
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
                                "font-family: 'Nunito Sans', sans-serif;" +
                            "}" +
                            "* {" +
                                "-ms-text-size-adjust: 100%;" +
                                "-webkit-text-size-adjust: 100%;" +
                            "}" +
                            "div[style*='margin: 16px 0'] {" +
                        "		margin: 0 !important;" +
                        "	}" +

                        "	table," +
                        "	td {" +
                        "		mso-table-lspace: 0pt !important;" +
                        "		mso-table-rspace: 0pt !important;" +
                        "	}" +

                        "	table {" +
                        "		border-spacing: 0 !important;" +
                        "		border-collapse: collapse !important;" +
                        "		table-layout: fixed !important;" +
                        "		margin: 0 auto !important;" +
                        "	}" +

                        "	img {" +
                        "		-ms-interpolation-mode:bicubic;" +
                        "	}" +
                        "	a {" +
                        "		text-decoration: none;" +
                        "	}" +
                        "	h1, h2, h3, h4, h5, h6 {" +
                        "		font-family: 'Nunito Sans', sans-serif;" +
                        "		color: #000000;" +
                        "		margin-top: 0;" +
                        "	}" +

                        "	.logo h1{" +
                        "		margin: 0;" +
                        "	}" +
                        "	.logo h1 a{" +
                        "		color: #797979;" +
                        "		font-size: 20px;" +
                        "		font-weight: 700;" +
                        "		font-family: 'Nunito Sans', sans-serif;" +
                        "	}" +

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
                                                                    "<td width='16%' class='logo' style='text-align: left; padding: 10px'>" +
                                                                        "<h1><a style='color: #000; font-size: 10px; font-weight: 700; text-transform: uppercase;' href='https://www.asae.com.mx/'><img src='https://www.asae.com.mx/images/Tickets/LogoAsae.png' alt='' style='width: 100%; max-width: 500px; height: auto; margin: auto; display: block;'></a></h1>" +
                                                                      "</td>" +
                                                                      "<td width='55%' class='logo' style='text-align: right;'>" +
                                                                        "<table width='100%' border='0' cellpadding='0' cellspacing='0' style='border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;' class='container590 hide'>" +
                                                                            "<tr>" +
                                                                                "<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500; '>" +
                                                                                    "<a href='https://www.asae.com.mx/' style='color: #adadad;'>Inicio </a>" +
                                                                                "</td>" +
                                                                                "<td  align='center' style='list-style: none; display: inline-block; margin-left: 5px; font-size: 13px; font-weight: 500;'>" +
                                                                                    "<a href='https://www.asae.com.mx/asd' style='color: #adadad;'>ASD </a>" +
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
                                                        "<td align='center' valign='middle' class='hero bg_white' style=' position: relative; z-index: 0;'>" +
                                                          "<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
                                                                "<tr>" +
                                                                    "<td valign='middle' width='50%'>" +
                                                                      "<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
                                                                        "<tr>" +
                                                                          "<td>" +
                                                                            "<img src='https://www.asae.com.mx/images/Tickets/Banner2.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
                                                                          "</td>" +
                                                                        "</tr>" +
                                                                      "</table>" +
                                                                "</td>" +
                                                                "<td valign='middle' width='50%' >" +
                                                                  "<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
                                                                    "<tr>" +
                                                                      "<td class='text' style='text-align: left; padding: 20px 30px;'>" +
                                                                            "<h2 style='color: #03A9F4; font-size: 32px; margin-bottom: 0; font-weight: 200; line-height: 1.3;'>Gracias por enviar tu mensaje </h2>" +
                                                                            "<p style='font-size: 14px; line-height: 1.5; color: #b9b9b9;'> Suscríbete y recibe nuestras ultimas noticias y promociones en las mejores herramientas en soluciones TI.</p>" +
                                                                            "<p><a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;' >Suscribirme</a></p>" +
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
                                                            "<table border='0' align='center' width='590' cellpadding='0' cellspacing='0' style='margin: auto; background: #f8f8f8; padding: 2.5em;'>" +
                                                                "<tr>" +
                                                                    "<td align='center' style='padding: 1em 4em;'>" +
                                                                        "<p style='font-size: 19px; color: #03A9F4;'> " +
                                                                        "Te agradecemos que nos hayas contactado, en breve un ejecutivo te contactara para atender tus dudas y / o comentarios.</p>" +
                                                                    "</td>" +
                                                                "</tr>" +
                                                                "<tr>" +
                                                                    "<td>" +

                                                                    "</td>" +
                                                                "<tr>" +
                                                            "</table>" +
                                                        "</td>" +
                                                    "</tr>" +
                                                    "<tr>" +
                                                        "<td  style='    padding: 2.5em;'>" +
                                                            "<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
                                                                "<tr>" +
                                                                    "<td valign='middle' width='50%'>" +
                                                                        "<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
                                                                            "<tr>" +
                                                                                "<td>" +
                                                                                    "<img src='https://www.asae.com.mx/images/Tickets/Banner.png' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
                                                                                "</td>" +
                                                                            "</tr>" +
                                                                        "</table>" +
                                                                    "</td>" +
                                                                    "<td valign='middle' width='50%'>" +
                                                                        "<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
                                                                            "<tr>" +
                                                                                "<td class='text-services' style='text-align: left; padding-left:25px;'>" +
                                                                                    "<div class='heading-section'>" +
                                                                                        "<h2 style='color: #676466; font-size: 21px; font-weight: 300;margin-top: 0; line-height: 1.3; font-weight: 400;'>¿Conoces en que estatus se encuentra cualquier incidente de soporte TI en tu organización?</h2>" +
                                                                                        "<p style='font-size: 12px; line-height: 1.8; color: #b9b9b9;'><strong>ASAE SERVICE DESK (ASD)</strong> ayuda a gerentes de TI a garantizar la continuidad de los servicios de TI dentro de la organización, llevando el control de cada incidente de soporte técnico en una sola plataforma.</p>" +
                                                                                        "<p><a href='https://www.asae.com.mx/asd' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
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
                                                                    "<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #026fa0;'>" +
                                                                        "<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
                                                                            "<tr>" +
                                                                                "<td class='counter-text'>" +
                                                                                    "<span class='num'></span>" +
                                                                                "</td>" +
                                                                            "</tr>" +
                                                                        "</table>" +
                                                                    "</td>" +
                                                                    "<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #009baf;'>" +
                                                                        "<table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
                                                                            "<tr>" +
                                                                                "<td class='counter-text'>" +
                                                                                    "<span class='num'></span>" +
                                                                                "</td>" +
                                                                            "</tr>" +
                                                                        "</table>" +
                                                                    "</td>" +
                                                                    "<td valign='middle' width='33.333%' style='padding: 2.8em 0; background-color: #00BCD4;'>" +
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
                                                                        "<p style='font-size: 15px; line-height: 1.8; color: #b9b9b9;'>Incrementa el 30 por ciento de productividad, con herramientas que analizan y miden el tiempo de trabajo de tu personal.</p>" +
                                                                    "</td>" +
                                                                "</tr>" +
                                                            "</table>" +
                                                        "</td>" +
                                                    "</tr>" +
                    //                                "<tr>" +
                    //                                    "<td style='padding: 1em;'>" +
                    //                                        "<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
                    //                                            "<tr>" +
                    //                                                "<td valign='top' width='50%' style='padding-top: 20px;'>" +
                    //                                                    "<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
                    //                                                        "<tr>" +
                    //                                                            "<td>" +
                    //                                                                "<img src='https://www.asae.com.mx/01/blog-1.jpg' alt='' style='width: 100%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
                    //                                                            "</td>" +
                    //                                                        "</tr>" +
                    //                                                        "<tr>" +
                    //                                                            "<td class='text-services' style='text-align: left;'>" +
                    //                                                                "<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400;'>JobCTRL </h3>" +
                    //                                                                "<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Software para documentar analizar mejorar el tiempo de trabajo.</span></p>" +

                    //                                                                "<p><a href='https://www.asae.com.mx/jobctrl' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
                    //                                                            "</td>" +
                    //                                                        "</tr>" +
                    //                                                    "</table>" +
                    //                                                "</td>" +
                    //"												<td valign='top' width='50%' style='padding-top: 20px;'>" +
                    //"													<table role='presentation' cellspacing='0' cellpadding='10' border='0' width='100%'>" +
                    //"														<tr>" +
                    //"															<td>" +
                    //"																<br>" +
                    //"																<img src='https://www.asae.com.mx/01/CorreTickets.png' alt='' style='width: 90%; max-width: 600px; height: auto; margin: auto; display: block;'>" +
                    //"															</td>" +
                    //"														</tr>" +
                    //"														<tr>" +
                    //"															<td class='text-services' style='text-align: left;'>" +
                    //"																<h3 style='margin-top: 0; line-height: 1.2; font-size: 20px; font-weight: 400;'>Asae Service Desk (ASD) </h3>" +
                    //"																<p style=' font-size: 14px; margin-top: 0; color: #b9b9b9; line-height: 1.8;'><span>Ayuda a gerentes de TI a garantizar la continuidad de los servicios de TI dentro de la organización.</span></p>" +

                    //"																<p><a href='https://www.asae.com.mx/asd' style='border-radius: 5px;background: #03A9F4; color: #fff; padding: 5px 15px; display: inline-block; font-size: 14px;  padding: 10px 30px;'>Leer más</a></p>" +
                    //"															</td>" +
                    //"														</tr>" +
                    //"													</table>" +
                    //"												</td>" +
                    //                                            "</tr>" +
                    //                                        "</table>" +
                    //                                    "</td>" +
                    //                                "</tr>" +
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
                                                                                        "<p style='margin-top: 0; font-size: 14px; '>¿Quieres recibir más correos electrónicos con nuestras nuevas herramientas y promociones? Usted puede <a href='https://www.asae.com.mx/registro/solicitud-de-suscripcion' style='font-size: 14px; color: #00afc5;'>Darse de alta aquí</a></p>" +
                                                                                    "</td>" +
                                                                                "</tr>" +
                                                                                "<tr>" +
                                                                                    "<td width='100%' style='text-align: center;'>" +
                                                                                        "<table>" +
                                                                                            "<tr>" +
                                                                                                "<td>" +
                                                                                                    "<a href='https://twitter.com/asaeconsultores'>" +
                                                                                                        "<img src='https://www.asae.com.mx/01/004-twitter-logo.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
                                                                                                    "</a>" +
                                                                                                "</td>" +
                                                                                                "<td>" +
                                                                                                    "<a href='https://www.facebook.com/AsaeConsultoresMX/'>" +
                                                                                                        "<img src='https://www.asae.com.mx/01/005-facebook.png' alt='' style='width: 24px; max-width: 600px; height: auto; display: block;'>" +
                                                                                                    "</a>" +
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
            }
            else
            {
                respuesta = validaciones.EvaludaEmail(model);
            }
            return respuesta;
        }
    }
}
