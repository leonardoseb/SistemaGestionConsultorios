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
    public class DaoDetalleHistoriasClinicas
    {
        AccesoDatos ds = new AccesoDatos();

        public DataTable getTablaDetalleHistoriasClinicas()
        {
            DataTable tabla = ds.ObtenerTabla("DetalleHistoriasClinicas", "SELECT * FROM DetalleHistoriasClinicas");
            return tabla;
        }

        public DataTable getTablaDetalleHistoriasClinicasxLegajo(string Legajo)
        {
            DataTable tabla = ds.ObtenerTabla("DetalleHistoriasClinicas", "SELECT Descripcion_Esp, MotivoConsulta_DHC, Diagnostico_DHC, FechaConsulta_DHC, Descripcion_Esp FROM DetalleHistoriasClinicas JOIN Especialidades ON CodEspecialidad_DHC = CodEspecialidad_Esp WHERE Legajo_DHC ='" + Legajo + "'");
            return tabla;
        }


        private void ArmarParametrosDetalleHistoriaClinica(ref SqlCommand Comando, DetalleHistoriaClinica dhc)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = Comando.Parameters.Add("@LEGAJO_DHC", SqlDbType.Int);
            SqlParametros.Value = dhc.getLegajo_DHC();
            SqlParametros = Comando.Parameters.Add("@MATRICULA_DHC", SqlDbType.Char, 5);
            SqlParametros.Value = dhc.getMatricula_DHC();
            SqlParametros = Comando.Parameters.Add("@CODESPECIALIDAD_DHC", SqlDbType.Char,7);
            SqlParametros.Value = dhc.getCodEspecialidad_DHC(); 
            SqlParametros = Comando.Parameters.Add("@MOTIVOCONSULTA_DHC", SqlDbType.VarChar, 50);
            SqlParametros.Value = dhc.getMotivoConsulta();
            SqlParametros = Comando.Parameters.Add("@DIAGNOSTICO_DHC", SqlDbType.VarChar, 50);
            SqlParametros.Value = dhc.getDiagnostico();
            SqlParametros = Comando.Parameters.Add("@FECHACONSULTA_DHC", SqlDbType.DateTime);
            SqlParametros.Value = dhc.getFechaConsulta_DHC();
        }

        public int CargarDetalleHistoriaClinica(DetalleHistoriaClinica dhc)
        {
            dhc.setLegajo_DHC(dhc.getLegajo_DHC());
            dhc.setMatricula_DHC(dhc.getMatricula_DHC());
            dhc.setCodEspecialidad_DHC(dhc.getCodEspecialidad_DHC());
            dhc.setMotivoConsulta(dhc.getMotivoConsulta());
            dhc.setDiagnostico(dhc.getDiagnostico());
            dhc.setFechaConsulta_DHC(dhc.getFechaConsulta_DHC());
            

            SqlCommand comando = new SqlCommand();
            ArmarParametrosDetalleHistoriaClinica(ref comando, dhc);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarHistoriaClinica_Detalle");
        }


        public string buscarMatricula(string codEspecialidad)
        {
            string consulta = "SELECT Matricula_PxE FROM ProfesionalesXEspecialidades WHERE CodEspecialidad_PxE = '" + codEspecialidad + "'";

            string matricula = ds.buscarMatricula(consulta);

            return matricula;
        }

        public int buscarLegajo(int codPac)
        {
            string consulta = "SELECT Legajo_HC FROM HistoriasClinicas WHERE CodPaciente_HC ='" + codPac + "'";

            int codPaciente = ds.buscarCodPaciente(consulta);

            return codPaciente;
        }
    }
}
