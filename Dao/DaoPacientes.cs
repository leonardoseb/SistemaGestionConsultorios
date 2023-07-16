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
    public class DaoPacientes
    {
        AccesoDatos ds = new AccesoDatos();

         public DataTable getTablaPacientes()
        {
            DataTable tabla = ds.ObtenerTabla("Paciente", "SELECT pac.CodPaciente_Pac,pac.Nombre_Pac, pac.DNI_Pac,pac.Apellido_Pac,pac.ObraSocial_Pac,pac.Direccion_Pac,pac.Telefono_Pac,pac.Email_Pac, CASE pac.Estado_Pac WHEN 1 THEN 'Alta' WHEN 0 THEN 'Baja' END AS Estado_Pac FROM Pacientes pac");
            return tabla;
        }

        public DataTable getTablaPacientesFiltro(string dni)
        {
            DataTable tabla = ds.ObtenerTabla("Pacientes", "SELECT * FROM PACIENTES WHERE DNI_Pac LIKE '%" + dni + "%'");
            return tabla;
        }

        public string ObtenerDatosPaciente(string dni)
        {

            string consulta = "SELECT (Nombre_Pac + ' ' + Apellido_Pac) AS DatosPaciente_Pac FROM Pacientes WHERE DNI_Pac = '" + dni + "'";
            string NombreyApellido = ds.ObtenerDatosPacientes(consulta);
            return NombreyApellido;
        }

        private void ArmarParametrosPaciente(ref SqlCommand Comando, Paciente pac)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@DNI_PAC", SqlDbType.Char, 8);
            SqlParametros.Value = pac.getDNI_Pac();
            SqlParametros = Comando.Parameters.Add("@NOMBRE_PAC", SqlDbType.VarChar, 15);
            SqlParametros.Value = pac.getNombre_Pac();
            SqlParametros = Comando.Parameters.Add("@APELLIDO_PAC", SqlDbType.VarChar, 15);
            SqlParametros.Value = pac.getApellido_Pac();
            SqlParametros = Comando.Parameters.Add("@OBRASOCIAL_PAC", SqlDbType.VarChar, 15);
            SqlParametros.Value = pac.getObraSocial_Pac();
            SqlParametros = Comando.Parameters.Add("@DIRECCION_PAC", SqlDbType.VarChar, 25);
            SqlParametros.Value = pac.getDireccion_Pac();
            SqlParametros = Comando.Parameters.Add("@TELEFONO_PAC", SqlDbType.Char, 8);
            SqlParametros.Value = pac.getTelefono_Pac();
            SqlParametros = Comando.Parameters.Add("@EMAIL_PAC", SqlDbType.VarChar, 25);
            SqlParametros.Value = pac.getEmail_Pac();
            SqlParametros = Comando.Parameters.Add("@ESTADO_PAC", SqlDbType.Bit, 1);
            SqlParametros.Value = pac.getEstado();

        }

        public int agregarPaciente (Paciente pac)
        {
            pac.setDNI_Pac(pac.getDNI_Pac());
            pac.setNombre_Pac(pac.getNombre_Pac());
            pac.setApellido_Pac(pac.getApellido_Pac());
            pac.setObraSocial_Pac(pac.getObraSocial_Pac());
            pac.setDireccion_Pac(pac.getDireccion_Pac());
            pac.setTelefono_Pac(pac.getTelefono_Pac());
            pac.setEmail_Pac(pac.getEmail_Pac());

            SqlCommand comando = new SqlCommand();
            ArmarParametrosPaciente(ref comando, pac);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarPaciente");
        }

        public Boolean existePaciente(Paciente pac)
        {
            String consulta = "Select * from Pacientes where DNI_Pac ='" + pac.getDNI_Pac() + "'";
            return ds.existe(consulta);
        }

        private void ArmarParametrosPacienteEliminar(ref SqlCommand Comando, Paciente pac)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@DNI_PAC", SqlDbType.Char);
            SqlParametros.Value = pac.getDNI_Pac();
        }

        public bool ActualizarPaciente(Paciente pac)
        {
            SqlCommand Comando = new SqlCommand();
            ArmarParametrosPaciente(ref Comando, pac);
            AccesoDatos ad = new AccesoDatos();
            int FilasInsertadas = ad.EjecutarProcedimientoAlmacenado(Comando, "spActualizarPaciente");
            if (FilasInsertadas == 1)
                return true;
            else
                return false;
        }
        
        public bool EliminarPaciente(Paciente pac)
        {
            SqlCommand Comando = new SqlCommand();
            ArmarParametrosPacienteEliminar(ref Comando, pac);
            AccesoDatos ad = new AccesoDatos();
            int FilasInsertadas = ad.EjecutarProcedimientoAlmacenado(Comando, "spEliminarPaciente");
            if (FilasInsertadas == 1)
                return true;
            else
                return false;
        }

        public bool validarDNI(string dni)
        {
            DaoPacientes dao = new DaoPacientes();

            bool existe = dao.validarDNI(dni);

            if (existe == true)
                return true;
            else
                return false;
        }
    }

}
