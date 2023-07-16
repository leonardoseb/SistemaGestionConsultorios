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
    public class DaoTurnos
    {
        AccesoDatos ds = new AccesoDatos();

        public DataTable getTablaTurnos()
        {
            DataTable tabla = ds.ObtenerTabla("Turnos", "SELECT tur.Nro_Turno as [Nro_Turno],FORMAT(tur.Fecha_Tur, 'dd/MM/yyyy') as Fecha,tur.NumConsultorio_Tur as Consultorio,(prof.Nombre_Pr + ' ' + prof.Apellido_Pr) as [Nombre_Profesional],esp.Descripcion_Esp as Especialidad,(pac.Nombre_Pac + ' ' + pac.Apellido_Pac) as [Nombre_Paciente],pac.DNI_Pac as DNI,pac.ObraSocial_Pac as [Obra_Social],CASE tur.Estado_Tur WHEN 1 THEN 'Asignado' WHEN 0 THEN 'Cancelado' END AS Estado FROM Turnos tur INNER JOIN Profesionales prof ON prof.Matricula_Pr = tur.Matricula_Tur INNER JOIN Especialidades esp ON esp.CodEspecialidad_Esp = tur.CodEspecialidad_Tur INNER JOIN Pacientes pac ON pac.CodPaciente_Pac = tur.CodPaciente_Tur ORDER BY tur.Fecha_Tur ASC ");
            return tabla;
        }

        public DataTable getTablaTurnoFiltro(string turno)
        {
            DataTable tabla = ds.ObtenerTabla("Turnos", "SELECT * FROM turnos WHERE Nro_Turno LIKE '%" + turno + "%'");
            return tabla;
        }

        public DataTable getTablaTurnosPorMedicos(string matricula)
        {
            DataTable tabla = ds.ObtenerTabla("Turnos", "SELECT tur.Nro_Turno as [Nro_Turno],FORMAT(tur.Fecha_Tur, 'dd/MM/yyyy') as Fecha,tur.NumConsultorio_Tur as Consultorio,(prof.Nombre_Pr + ' ' + prof.Apellido_Pr) as [Nombre_Profesional],esp.Descripcion_Esp as Especialidad,(pac.Nombre_Pac + ' ' + pac.Apellido_Pac) as [Nombre_Paciente],pac.DNI_Pac as DNI,pac.ObraSocial_Pac as [Obra_Social],CASE tur.Estado_Tur WHEN 1 THEN 'Asignado' WHEN 0 THEN 'Cancelado' END AS Estado FROM Turnos tur INNER JOIN Profesionales prof ON prof.Matricula_Pr = tur.Matricula_Tur INNER JOIN Especialidades esp ON esp.CodEspecialidad_Esp = tur.CodEspecialidad_Tur INNER JOIN Pacientes pac ON pac.CodPaciente_Pac = tur.CodPaciente_Tur WHERE tur.Matricula_Tur = '" + matricula + "' ORDER BY tur.Fecha_Tur ASC");
            
            return tabla;
        }
        
        public DataTable getTablaTurnosPorMedicosFiltro (string turno)
        {
            DataTable tabla = ds.ObtenerTabla("Turnos", "SELECT * FROM turnos WHERE Nro_Turno LIKE '%" + turno + "%'");
            return tabla;
        }

        private void ArmarParametrosTurno(ref SqlCommand Comando, Turno tur)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = Comando.Parameters.Add("@MATRICULA_TUR", SqlDbType.Char, 5);
            SqlParametros.Value = tur.getMatricula_Tur();
            SqlParametros = Comando.Parameters.Add("@CODESPECIALIDAD_TUR", SqlDbType.Char, 5);
            SqlParametros.Value = tur.getCodEspecialidad_Tur();
            SqlParametros = Comando.Parameters.Add("@NUMCONSULTORIO_TUR", SqlDbType.Char, 15);
            SqlParametros.Value = tur.getNumConsultorio_Tur();
            SqlParametros = Comando.Parameters.Add("@CODPACIENTE_TUR", SqlDbType.Int);
            SqlParametros.Value = tur.getCodPaciente_Tur();
            SqlParametros = Comando.Parameters.Add("@FECHA_TUR", SqlDbType.DateTime);
            SqlParametros.Value = tur.getFecha_Tur();
            SqlParametros = Comando.Parameters.Add("@ESTADO_TUR", SqlDbType.Bit);
            SqlParametros.Value = tur.getEstado();
        }


        public int agregarTurno(Turno tur)
        {
            tur.setMatricula_Tur(tur.getMatricula_Tur());
            tur.setCodEspecialidad_Tur(tur.getCodEspecialidad_Tur());
            tur.setNumConsultorio_Tur(tur.getNumConsultorio_Tur());
            tur.setCodPaciente_Tur(tur.getCodPaciente_Tur());
            tur.setFecha(tur.getFecha_Tur());
            tur.setEstado(tur.getEstado());

            SqlCommand comando = new SqlCommand();
            ArmarParametrosTurno(ref comando, tur);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarTurno");
        }

        private void ArmarParametrosTurnolEliminar(ref SqlCommand Comando, Turno tur)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@NRO_TURNO", SqlDbType.Int);
            SqlParametros.Value = tur.geNroTurno_Tur();
        }

        public bool EliminarTurno(Turno tur)
        {
            SqlCommand Comando = new SqlCommand();
            ArmarParametrosTurnolEliminar(ref Comando, tur);
            AccesoDatos ad = new AccesoDatos();
            int FilasInsertadas = ad.EjecutarProcedimientoAlmacenado(Comando, "spEliminarTurno");
            if (FilasInsertadas == 1)
                return true;
            else
                return false;
        }
        public string buscarCodEspecialidad(string descrip)
        {
            string consulta = "SELECT CodEspecialidad_Esp FROM Especialidades WHERE Descripcion_Esp = '" + descrip + "'";

            string codEspecialidad = ds.buscarCodEspecialidad(consulta);

            return codEspecialidad;

        }

        public int buscarCodPaciente(string dni)
        {
            string consulta = "SELECT CodPaciente_Pac FROM Pacientes WHERE DNI_PAC = '" + dni + "'";

            int codEspecialidad = ds.buscarCodPaciente(consulta);

            return codEspecialidad;

        }

        public string buscarMatricula(string codEspecialidad)
        {
            string consulta = "SELECT Matricula_PxE FROM ProfesionalesXEspecialidades WHERE CodEspecialidad_PxE = '" + codEspecialidad + "'";

            string matricula = ds.buscarMatricula(consulta);

            return matricula;
        }

        public string buscarConsultorio(string especialidad)
        {
            string consulta = "SELECT NumConsultorio_Con FROM Consultorios WHERE CodEspec_Con  = '" + especialidad + "'";

            string consultorio = ds.buscarConsultorio(consulta);

            return consultorio;
        }




    }
}
