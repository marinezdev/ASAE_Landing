using Newtonsoft.Json;
using NuevaWebAsae.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevaWebAsae.Data
{
    public class Vacante
    {
        ManejoDatos b = new ManejoDatos();
        public Models.Vacante Vacante_Agregar(Models.Vacante vacante)
        {
            const string consulta = "RH.Vacante_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdPuesto", vacante.EmpresaPuestos.Id, SqlDbType.Int);
            b.AddParameter("@IdProyecto", vacante.Cat_ProyectoServicios.Id, SqlDbType.Int);
            b.AddParameter("@IdClienteDireccion", vacante.ClienteDirecciones.Id, SqlDbType.Int);
            b.AddParameter("@IdEsquemaContratacion", vacante.Cat_EsquemaContratacion.Id, SqlDbType.Int);
            b.AddParameter("@IdModalidad", vacante.Cat_Modalidad.Id, SqlDbType.Int);
            b.AddParameter("@IdJornada", vacante.Cat_JornadaTrabajo.Id, SqlDbType.Int);
            b.AddParameter("@IdUsuario", vacante.Usuario.Id, SqlDbType.Int);
            b.AddParameter("@Titulo", vacante.Titulo, SqlDbType.NVarChar);
            b.AddParameter("@Salario", vacante.Salario, SqlDbType.Int);
            b.AddParameter("@SalarioInicial", vacante.SalarioInicial, SqlDbType.Float);
            b.AddParameter("@SalarioFinal", vacante.SalarioFinal, SqlDbType.Float);
            b.AddParameter("@FechaCierre", vacante.FechaCierre, SqlDbType.Date);

            b.AddParameter("@IdEmpleadoBaja", vacante.IdEmpleadoBaja, SqlDbType.Int);
            b.AddParameter("@IdMotivosBaja", vacante.Cat_MotivosBajaEmpleado.Id, SqlDbType.Int);
            b.AddParameter("@FechaBaja", vacante.FechaBaja, SqlDbType.Date);

            b.AddParameter("@Contenido", vacante.Contenido, SqlDbType.NVarChar);
            b.AddParameter("@Notificacion", vacante.Notificacion, SqlDbType.Int);

            Models.Vacante resultado = new Models.Vacante();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Vacante>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Vacante> Vacante_Seleccionar_General()
        {
            const string consulta = "RH.Vacante_Seleccionar_General";
            b.ExecuteCommandSP(consulta);

            List<Models.Vacante> resultado = new List<Models.Vacante>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Vacante>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Vacante> Vacante_Seleccionar(Models.Usuario usuario)
        {
            const string consulta = "RH.Vacante_Seleccionar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdUsuario", usuario.Id, SqlDbType.Int);

            List<Models.Vacante> resultado = new List<Models.Vacante>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Vacante>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Vacante> PlantillaVacante_Listar()
        {
            const string consulta = "PlantillaVacante_Listar";
            b.ExecuteCommandSP(consulta);

            List<Models.Vacante> resultado = new List<Models.Vacante>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Vacante>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.Vacante Vacante_Seleccionar_Id(Models.Vacante vacante)
        {
            const string consulta = "RH.Vacante_Seleccionar_Id";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", vacante.Id, SqlDbType.Int);

            Models.Vacante resultado = new Models.Vacante();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Vacante>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Vacante Vacante_Seleccionar_IdVacante(Models.Vacante vacante)
        {
            const string consulta = "RH.Prospectos_Listar_IdVacante";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", vacante.Id, SqlDbType.Int);

            Models.Vacante resultado = new Models.Vacante();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Vacante>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.Vacante> Vacante_Seleccionar_Top3()
        {
            const string consulta = "RH.Vacante_Seleccionar_Top3";
            b.ExecuteCommandSP(consulta);

            List<Models.Vacante> resultado = new List<Models.Vacante>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Vacante>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Usuario Vacantes_Seleccionar_Usuario(Models.Vacante vacante)
        {
            const string consulta = "RH.Vacantes_Seleccionar_Usuario";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", vacante.Id, SqlDbType.Int);

            Models.Usuario resultado = new Models.Usuario();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Usuario>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Vacante Vacante_Pintar_Id(Models.Vacante vacante)
        {
            const string consulta = "RH.Vacante_Pintar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", vacante.Id, SqlDbType.Int);

            Models.Vacante resultado = new Models.Vacante();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Vacante>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Vacante Vacante_Consultar(Models.Vacante vacante)
        {
            const string consulta = "RH.EmpresaDepartamento_Id";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", vacante.EmpresaPuestos.Id, SqlDbType.Int);

            Models.Vacante resultado = new Models.Vacante();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Vacante>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Vacante Vacante_ConsultarProyecto(Models.Vacante vacante)
        {
            const string consulta = "RH.Cliente_IdProyecto";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", vacante.Cat_ProyectoServicios.Id, SqlDbType.Int);

            Models.Vacante resultado = new Models.Vacante();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Vacante>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Vacante Vacante_Actualizar(Models.Vacante vacante)
        {
            const string consulta = "RH.Vacante_Actualizar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", vacante.Id, SqlDbType.Int);

            b.AddParameter("@IdPuesto", vacante.EmpresaPuestos.Id, SqlDbType.Int);
            b.AddParameter("@IdProyecto", vacante.Cat_ProyectoServicios.Id, SqlDbType.Int);
            b.AddParameter("@IdClienteDireccion", vacante.ClienteDirecciones.Id, SqlDbType.Int);
            b.AddParameter("@IdEsquemaContratacion", vacante.Cat_EsquemaContratacion.Id, SqlDbType.Int);
            b.AddParameter("@IdModalidad", vacante.Cat_Modalidad.Id, SqlDbType.Int);
            b.AddParameter("@IdJornada", vacante.Cat_JornadaTrabajo.Id, SqlDbType.Int);
            b.AddParameter("@IdUsuario", vacante.Usuario.Id, SqlDbType.Int);
            b.AddParameter("@Titulo", vacante.Titulo, SqlDbType.NVarChar);
            b.AddParameter("@Salario", vacante.Salario, SqlDbType.Int);
            b.AddParameter("@SalarioInicial", vacante.SalarioInicial, SqlDbType.Float);
            b.AddParameter("@SalarioFinal", vacante.SalarioFinal, SqlDbType.Float);
            b.AddParameter("@FechaCierre", vacante.FechaCierre, SqlDbType.Date);

            b.AddParameter("@IdEmpleadoBaja", vacante.IdEmpleadoBaja, SqlDbType.Int);
            b.AddParameter("@IdMotivosBaja", vacante.Cat_MotivosBajaEmpleado.Id, SqlDbType.Int);
            b.AddParameter("@FechaBaja", vacante.FechaBaja, SqlDbType.Date);

            b.AddParameter("@Contenido", vacante.Contenido, SqlDbType.NVarChar);
            b.AddParameter("@Notificacion", vacante.Notificacion, SqlDbType.Int);

            Models.Vacante resultado = new Models.Vacante();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Vacante>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Vacante PlantillaVacante_Listar_Id(Models.Vacante vacante)
        {
            const string consulta = "PlantillaVacante_Listar_Id";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", vacante.Id, SqlDbType.Int);

            Models.Vacante resultado = new Models.Vacante();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Vacante>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

    }
}
