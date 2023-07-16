using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class DaoProfesionales
    {
        AccesoDatos ds = new AccesoDatos();

        public DataTable getTablaProfesionables()
        {
            DataTable tabla = ds.ObtenerTabla("Profesionales", "SELECT prof.Matricula_Pr,prof.DNI_Pr,prof.Nombre_Pr, prof.Apellido_Pr,prof.Email_Pr,prof.Telefono_Pr, CASE prof.Estado_Pr WHEN 1 THEN 'Alta' WHEN 0 THEN 'Baja' END AS Estado_Pr FROM Profesionales prof");
            return tabla;
        }

        public DataTable getTablaProfesionalesFiltro(string dni)
        {
            DataTable tabla = ds.ObtenerTabla("Profesionales", "SELECT * FROM Profesionales WHERE DNI_Pr LIKE '%" + dni + "%'");
            return tabla;
        }

        public DataTable getTablaProfesional(string matricula)
        {
            DataTable tabla = ds.ObtenerTabla("Profesionales", "SELECT prof.Matricula_Pr,prof.DNI_Pr,prof.Nombre_Pr, prof.Apellido_Pr,prof.Email_Pr,prof.Telefono_Pr, CASE prof.Estado_Pr WHEN 1 THEN 'Alta' WHEN 0 THEN 'Baja' END AS Estado_Pr FROM Profesionales prof WHERE Matricula_Pr = '" + matricula + "'");
            return tabla;
        }

        private void ArmarParametrosProfesional(ref SqlCommand Comando, Profesional pr)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@MATRICULA_PR", SqlDbType.Char,5);
            SqlParametros.Value = pr.getMatricula_Pr();
            SqlParametros = Comando.Parameters.Add("@DNI_PR", SqlDbType.Char,8);
            SqlParametros.Value = pr.getDNI_Pr();
            SqlParametros = Comando.Parameters.Add("@NOMBRE_PR", SqlDbType.VarChar,15);
            SqlParametros.Value = pr.getNombre_Pr();
            SqlParametros = Comando.Parameters.Add("@APELLIDO_PR", SqlDbType.VarChar,15);
            SqlParametros.Value = pr.getApellido_Pr();
            SqlParametros = Comando.Parameters.Add("@EMAIL_PR", SqlDbType.VarChar,25);
            SqlParametros.Value = pr.getEmail_Pr();
            SqlParametros = Comando.Parameters.Add("@TELEFONO_PR", SqlDbType.Char,8);
            SqlParametros.Value = pr.getTelefono_Pr();
            SqlParametros = Comando.Parameters.Add("@ESTADO_PR", SqlDbType.Bit, 1);
            SqlParametros.Value = pr.getEstado();
        }
        

        public int agregarProfesional(Profesional pr)
        {
            pr.setMatricula_Pr(pr.getMatricula_Pr());
            pr.setDNI_Pr(pr.getDNI_Pr());
            pr.setNombre_Pr(pr.getNombre_Pr());
            pr.setApellido_Pr(pr.getApellido_Pr());
            pr.setEmail_Pr(pr.getEmail_Pr());
            pr.setTelefono_Pr(pr.getTelefono_Pr());

            SqlCommand comando = new SqlCommand();
            ArmarParametrosProfesional(ref comando, pr);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarProfesional");
        }

        public Boolean existeProfesional(Profesional pr)
        {
            String consulta = "Select * from Profesionales where Matricula_Pr ='" + pr.getMatricula_Pr() + "'";
            return ds.existe(consulta);
        }

        

        private void ArmarParametrosProfesionalEliminar(ref SqlCommand Comando, Profesional prof)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@MATRICULA_PR", SqlDbType.Char,5);
            SqlParametros.Value = prof.getMatricula_Pr();
        }

        public bool ActualizarProfesional(Profesional prof)
        {
            SqlCommand Comando = new SqlCommand();
            ArmarParametrosProfesional(ref Comando, prof);
            AccesoDatos ad = new AccesoDatos();
            int FilasInsertadas = ad.EjecutarProcedimientoAlmacenado(Comando, "spActualizarProfesional");
            if (FilasInsertadas == 1)
                return true;
            else
                return false;
        }

        public bool EliminarProfesional(Profesional prof)
        {
            SqlCommand Comando = new SqlCommand();
            ArmarParametrosProfesionalEliminar(ref Comando, prof);
            AccesoDatos ad = new AccesoDatos();
            int FilasInsertadas = ad.EjecutarProcedimientoAlmacenado(Comando, "spEliminarProfesional");
            if (FilasInsertadas == 1)
                return true;
            else
                return false;
        }

        public SqlDataReader getProfesionales(string codEsp)
        {

            String consulta = "select Matricula_Pr,(Nombre_Pr + ' ' + Apellido_Pr) AS Nombre_Pr from profesionales pr inner join ProfesionalesXEspecialidades pxe on pxe.Matricula_PxE = pr.Matricula_Pr where CodEspecialidad_PxE='" + codEsp + "'";

            return ds.ObtenerEspecialidades(consulta);
        }


    }
}
