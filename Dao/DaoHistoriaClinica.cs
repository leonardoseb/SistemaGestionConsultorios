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
    public class DaoHistoriaClinica
    {
        AccesoDatos ds = new AccesoDatos();

        public DataTable getTablaHistoriasClinicas()
        {
            DataTable tabla = ds.ObtenerTabla("HistoriasClinicas", "SELECT Legajo_HC, CodPaciente_HC, Nombre_Pac, Apellido_Pac FROM HistoriasClinicas INNER JOIN Pacientes ON CodPaciente_HC = CodPaciente_Pac");
            return tabla;

        }

        public DataTable getTablaHistoriaClinicaXProfesional(string matricula)
        {
            DataTable tabla = ds.ObtenerTabla("HistoriasClinicas", "SELECT Legajo_HC, CodPaciente_HC, Nombre_Pac, Apellido_Pac FROM HistoriasClinicas hc INNER JOIN DetalleHistoriasClinicas dhc ON dhc.Legajo_DHC = hc.Legajo_HC INNER JOIN Pacientes pac ON pac.CodPaciente_Pac = hc.CodPaciente_HC INNER JOIN Profesionales prof ON prof.Matricula_Pr = dhc.Matricula_DHC WHERE dhc.Matricula_DHC = '" + matricula + "'");
            return tabla;
        }


        private void ArmarParametrosHistoriaClinica(ref SqlCommand Comando, HistoriaClinica hc)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = Comando.Parameters.Add("@CODPACIENTE_HC", SqlDbType.Int);
            SqlParametros.Value = hc.getCodPaciente_HC();
            
        }

        public int cargarHistoriaClinica(HistoriaClinica hc)
        {
            hc.setCodPaciente_HC(hc.getCodPaciente_HC());
            
            SqlCommand comando = new SqlCommand();
            ArmarParametrosHistoriaClinica(ref comando, hc);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarHistoriaClinica");
        }

        public Boolean existeHistoriaClinica(HistoriaClinica hc)
        {
            String consulta = "SELECT * from HistoriasClinicas WHERE CodPaciente_HC = ' " + hc.getCodPaciente_HC() + "'";
            return ds.existe(consulta);
        }

        public int buscarCodPaciente(string dni)
        {
            string consulta = "SELECT CodPaciente_Pac FROM Pacientes WHERE DNI_PAC = '" + dni + "'";

            int codEspecialidad = ds.buscarCodPaciente(consulta);

            return codEspecialidad;

        }

    }
}
