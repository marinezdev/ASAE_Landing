using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class Usuarios
    {
        ManejoDatos b = new ManejoDatos();

        public Models.Mensaje AsaeWebUsuarioAgregar(Models.Usuario usuario)
        {
            b.ExecuteCommandSP("AsaeWebUsuarioAgregar");
            b.AddParameter("@Nombre", usuario.Nombre, SqlDbType.NVarChar);
            b.AddParameter("@ApellidoPaterno", usuario.ApellidoPaterno, SqlDbType.NVarChar);
            b.AddParameter("@ApellidoMaterno", usuario.ApellidoMaterno, SqlDbType.NVarChar);
            b.AddParameter("@NombreEmpresa", usuario.NombreEmpresa, SqlDbType.NVarChar);
            b.AddParameter("@CorreoEmpresa", usuario.CorreoEmpresa, SqlDbType.NVarChar);
            b.AddParameter("@CorreoPersonal", usuario.CorreoPersonal, SqlDbType.NVarChar);
            b.AddParameter("@TelefonoMovil", usuario.TelefonoMovil, SqlDbType.NVarChar);
            b.AddParameter("@TelefonoLocal", usuario.TelefonoLocal, SqlDbType.NVarChar);
            b.AddParameter("@Ingreso", usuario.Ingreso, SqlDbType.NVarChar);
            b.AddParameter("@Evento", usuario.Evento, SqlDbType.NVarChar);

            Models.Mensaje resultado = new Models.Mensaje();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Token = reader["Token"].ToString();
                resultado.Email = reader["Email"].ToString();
                resultado.RespuestaText = reader["RespuestaText"].ToString();
                resultado.Respuesta = Convert.ToInt16(reader["Respuesta"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.Mensaje AsaeWebUsuarioBuscar(Models.Usuario usuario)
        {
            b.ExecuteCommandSP("AsaeWebUsuarioBuscar");
            b.AddParameter("@CorreoPersonal", usuario.CorreoPersonal, SqlDbType.NVarChar);
            b.AddParameter("@Evento", usuario.Evento, SqlDbType.NVarChar);

            Models.Mensaje resultado = new Models.Mensaje();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Token = reader["Token"].ToString();
                resultado.Email = reader["Email"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.Usuario AsaeWebUsuario_consulta_Token(string Token)
        {
            b.ExecuteCommandSP("AsaeWebUsuario_consulta_Token");
            b.AddParameter("@Token", Token, SqlDbType.NVarChar);

            Models.Usuario resultado = new Models.Usuario();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Nombre = reader["Nombre"].ToString();
                resultado.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                resultado.ApellidoMaterno = reader["ApellidoMaterno"].ToString();
                resultado.NombreEmpresa = reader["NombreEmpresa"].ToString();
                resultado.CorreoEmpresa = reader["CorreoEmpresa"].ToString();
                resultado.CorreoPersonal = reader["CorreoPersonal"].ToString();
                resultado.TelefonoMovil = reader["TelefonoMovil"].ToString();
                resultado.TelefonoLocal = reader["TelefonoLocal"].ToString();
                resultado.Clave = reader["Clave"].ToString();
                resultado.Password = reader["Password"].ToString();
                resultado.Descripcion = reader["Descripcion"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.Usuario AsaeWebUsuario_Selecionar_Token(string Token)
        {
            b.ExecuteCommandSP("AsaeWebUsuario_Selecionar_Token");
            b.AddParameter("@Token", Token, SqlDbType.NVarChar);

            Models.Usuario resultado = new Models.Usuario();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Nombre = reader["Nombre"].ToString();
                resultado.ApellidoPaterno = reader["ApellidoPaterno"].ToString();
                resultado.ApellidoMaterno = reader["ApellidoMaterno"].ToString();
                resultado.NombreEmpresa = reader["NombreEmpresa"].ToString();
                resultado.CorreoEmpresa = reader["CorreoEmpresa"].ToString();
                resultado.CorreoPersonal = reader["CorreoPersonal"].ToString();
                resultado.TelefonoMovil = reader["TelefonoMovil"].ToString();
                resultado.TelefonoLocal = reader["TelefonoLocal"].ToString();
                resultado.Clave = reader["Clave"].ToString();
                resultado.Password = reader["Password"].ToString();
                resultado.Descripcion = reader["Descripcion"].ToString();
                resultado.Respuesta = reader["Respuesta"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Mensaje AsaeWebUsuarioMensaje(Models.Email usuario)
        {
            b.ExecuteCommandSP("AsaeWebUsuarioMensaje");
            b.AddParameter("@nombre", usuario.nombre, SqlDbType.NVarChar);
            b.AddParameter("@email", usuario.email, SqlDbType.NVarChar);
            b.AddParameter("@asunto", usuario.asunto, SqlDbType.NVarChar);
            b.AddParameter("@mensaje", usuario.mensaje, SqlDbType.NVarChar);

            Models.Mensaje resultado = new Models.Mensaje();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.RespuestaText = reader["RespuestaText"].ToString();
                resultado.Respuesta = Convert.ToInt16(reader["Respuesta"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Mensaje AsaeWebUsuarioMensajeApp(Models.Email usuario)
        {
            b.ExecuteCommandSP("AsaeWebUsuarioMensajeApp");
            b.AddParameter("@nombre", usuario.nombre, SqlDbType.NVarChar);
            b.AddParameter("@email", usuario.email, SqlDbType.NVarChar);
            b.AddParameter("@asunto", usuario.asunto, SqlDbType.NVarChar);
            b.AddParameter("@mensaje", usuario.mensaje, SqlDbType.NVarChar);
            b.AddParameter("@telefono", usuario.telefono, SqlDbType.NVarChar);
            b.AddParameter("@telefonolocal", usuario.telefonolocal, SqlDbType.NVarChar);
            b.AddParameter("@Empresa", usuario.Empresa, SqlDbType.NVarChar);
            b.AddParameter("@App", usuario.App, SqlDbType.Int);

            Models.Mensaje resultado = new Models.Mensaje();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.RespuestaText = reader["RespuestaText"].ToString();
                resultado.Respuesta = Convert.ToInt16(reader["Respuesta"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        //public Models.Mensaje AsaeWebSolicitudesApp(Models.Email usuario)
        //{
        //    b.ExecuteCommandSP("AsaeWebSolicitudesApp");
        //    b.AddParameter("@nombre", usuario.nombre, SqlDbType.NVarChar);
        //    b.AddParameter("@email", usuario.email, SqlDbType.NVarChar);
        //    b.AddParameter("@telefono", usuario.telefono, SqlDbType.NVarChar);
        //    b.AddParameter("@telefonolocal", usuario.telefonolocal, SqlDbType.NVarChar);
        //    b.AddParameter("@App", usuario.App, SqlDbType.Int);

        //    Models.Mensaje resultado = new Models.Mensaje();
        //    var reader = b.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        resultado.RespuestaText = reader["RespuestaText"].ToString();
        //        resultado.Respuesta = Convert.ToInt16(reader["Respuesta"].ToString());
        //    }
        //    reader = null;
        //    b.ConnectionCloseToTransaction();
        //    return resultado;
        //}


        public Models.Mensaje AsaeWebSolicitudesApp(Models.Email usuario)
        {
            b.ExecuteCommandSP("AsaeWebSolicitudesApp");
            b.AddParameter("@nombre", usuario.nombre, SqlDbType.NVarChar);
            b.AddParameter("@email", usuario.email, SqlDbType.NVarChar);
            b.AddParameter("@telefono", usuario.telefono, SqlDbType.NVarChar);
            b.AddParameter("@telefonolocal", usuario.telefonolocal, SqlDbType.NVarChar);
            b.AddParameter("@Empresa", usuario.Empresa, SqlDbType.NVarChar);
            b.AddParameter("@App", usuario.App, SqlDbType.Int);

            Models.Mensaje resultado = new Models.Mensaje();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.RespuestaText = reader["RespuestaText"].ToString();
                resultado.Respuesta = Convert.ToInt16(reader["Respuesta"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Mensaje AsaeWebSolicitudDW(Models.Email usuario)
        {
            b.ExecuteCommandSP("AsaeWebSolicitudDW");
            b.AddParameter("@nombre", usuario.nombre, SqlDbType.NVarChar);
            b.AddParameter("@email", usuario.email, SqlDbType.NVarChar);
            b.AddParameter("@telefono", usuario.telefono, SqlDbType.NVarChar);
            b.AddParameter("@telefonolocal", usuario.telefonolocal, SqlDbType.NVarChar);
            b.AddParameter("@Empresa", usuario.Empresa, SqlDbType.NVarChar);
            b.AddParameter("@IdSeccion", usuario.App, SqlDbType.Int);

            Models.Mensaje resultado = new Models.Mensaje();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.RespuestaText = reader["RespuestaText"].ToString();
                resultado.Respuesta = Convert.ToInt16(reader["Respuesta"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.Mensaje CookieDW_Seleccionar(Models.Usuario usuario)
        {
            b.ExecuteCommandSP("CookieDW_Seleccionar");
            b.AddParameter("@Clave", usuario.Clave, SqlDbType.NVarChar);
            b.AddParameter("@Descripcion", usuario.Ingreso, SqlDbType.NVarChar);

            Models.Mensaje resultado = new Models.Mensaje();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.RespuestaText = reader["RespuestaText"].ToString();
                resultado.Respuesta = Convert.ToInt16(reader["Respuesta"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }




        public Models.Mensaje AsaeWebUsuarioSuscribir(Models.Email usuario)
        {
            b.ExecuteCommandSP("AsaeWebUsuarioSuscribir");
            b.AddParameter("@nombre", usuario.nombre, SqlDbType.NVarChar);
            b.AddParameter("@email", usuario.email, SqlDbType.NVarChar);

            Models.Mensaje resultado = new Models.Mensaje();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.RespuestaText = reader["RespuestaText"].ToString();
                resultado.Respuesta = Convert.ToInt16(reader["Respuesta"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }




        /************************************************************************************************************************/
        /************************************************************************************************************************/

        public Models.Usuario Usuario_Login_IniciarSesion(Models.Usuario usuario)
        {
            b.ExecuteCommandSP("Usuario_Login_IniciarSesion");
            b.AddParameter("@Usuario", usuario.usuario, SqlDbType.NVarChar);
            b.AddParameter("@Password", usuario.Password, SqlDbType.NVarChar);
            b.AddParameter("@Session", usuario.Session, SqlDbType.Bit);
            Models.Usuario resultado = new Models.Usuario();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
                resultado.Nombre = reader["Nombre"].ToString();
                resultado.RutaAcceso = reader["RutaAcceso"].ToString();
                resultado.ClaveSesion = reader["ClaveSesion"].ToString();
                resultado.IdRol = Convert.ToInt32(reader["IdRol"].ToString());
            }
            b.CloseConnection();
            return resultado;
        }

        public Models.Usuario Usuario_Login_ClaveSesion(Models.Usuario usuario)
        {
            b.ExecuteCommandSP("Usuario_Login_ClaveSesion");
            b.AddParameter("@ClaveSesion", usuario.ClaveSesion, SqlDbType.NVarChar);
            Models.Usuario resultado = new Models.Usuario();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
                resultado.Nombre = reader["Nombre"].ToString();
                resultado.RutaAcceso = reader["RutaAcceso"].ToString();
                resultado.ClaveSesion = reader["ClaveSesion"].ToString();
                resultado.IdRol = Convert.ToInt32(reader["IdRol"].ToString());
            }
            b.CloseConnection();
            return resultado;
        }
    }
}
