using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NuevaWebAsae.Application
{
    public class validaciones
    {
        public string EvaludaEmail(Models.CorreoEmail model)
        {
            string respuesta = "";
            //if (telefono(model.email[0].telefono.ToString()))
            //{
            if (texto(model.email[0].nombre.ToString()))
            {
                if (texto(model.email[0].asunto.ToString()))
                {
                    if (texto(model.email[0].mensaje.ToString()))
                    {
                        string EncodedResponse = model.email[0].recaptcha.ToString();
                        bool IsCaptchaValid = (ReCaptchaClass.Validate(EncodedResponse) == "true" ? true : false);

                        if (IsCaptchaValid)
                        {
                            respuesta = "ok";
                        }
                        else
                        {
                            respuesta = "Validación de recaptcha invalido";
                        }
                        //respuesta = model.email[0].recaptcha.ToString();
                        //respuesta = "ok";
                    }
                    else
                    {
                        respuesta = "El texto colocado en el mensaje es demasiado pequeño";
                    }
                }
                else
                {
                    respuesta = "El texto colocado en asunto es demasiado pequeño";
                }
            }
            else
            {
                respuesta = "El texto colocado en nombre es demasiado pequeño";
            }
            //}
            //else
            //{
            //    respuesta = "Número telefónico incorrecto ";
            //}
            return respuesta;
        }

        public string EvaludaSuscribir(Models.CorreoEmail model)
        {
            string respuesta = "";
            
            if (texto(model.email[0].nombre.ToString()))
            {

                //string EncodedResponse = model.email[0].recaptcha.ToString();
                //bool IsCaptchaValid = (ReCaptchaClass.Validate(EncodedResponse) == "true" ? true : false);

                //if (IsCaptchaValid)
                //{
                    respuesta = "ok";
                //}
                //else
                //{
                //    respuesta = "Validación de recaptcha invalido";
                //}

            }
            else
            {
                respuesta = "El texto colocado en nombre es demasiado pequeño";
            }

            return respuesta;
        }

        public class ReCaptchaClass
        {
            public static string Validate(string EncodedResponse)
            {
                var client = new System.Net.WebClient();

                string PrivateKey = "6LdXFXcUAAAAAAjtXe_qGXj2b6tQ3tt8TQmO7cWj";

                var GoogleReply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", PrivateKey, EncodedResponse));

                var captchaResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ReCaptchaClass>(GoogleReply);

                return captchaResponse.Success.ToLower();
            }

            [JsonProperty("success")]
            public string Success
            {
                get { return m_Success; }
                set { m_Success = value; }
            }

            private string m_Success;
            [JsonProperty("error-codes")]
            public List<string> ErrorCodes
            {
                get { return m_ErrorCodes; }
                set { m_ErrorCodes = value; }
            }


            private List<string> m_ErrorCodes;
        }

        private bool correo(string correo)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(correo, expresion))
            {
                if (Regex.Replace(correo, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
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

        private bool texto(string texto)
        {
            bool respuesta = false;
            if (texto.Length <= 4)
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }
    }
}
