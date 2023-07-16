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
    public class DaoReportes
    {
        AccesoDatos ds = new AccesoDatos();

        public string contarPacientesEsp(string especialidad)
        {

            string consulta = "SELECT COUNT(*) FROM Turnos WHERE CodEspecialidad_Tur = '"+ especialidad + "'";
            string cantidad = ds.Contar(consulta);
            return cantidad;
        }


        public SqlDataReader getObrasSociales()
        {

            String consulta = "SELECT distinct ObraSocial_Pac, DENSE_RANK() OVER(ORDER BY  ObraSocial_Pac) AS RowNum FROM Pacientes";

            return ds.ObtenerObrasSociales(consulta);
        }

        public string contarPacientesOS(string OS)
        {

            string consulta = "SELECT COUNT (*) FROM Pacientes where ObraSocial_Pac = '" + OS + "'";
            string cantidad = ds.Contar(consulta);
            return cantidad;
        }

        public string contarPacientesAtendidos(string fecha_inicial, string fecha_final)
        {

            string consulta = "SELECT COUNT(*) FROM Turnos WHERE(Fecha_Tur >= CAST('" + fecha_inicial + "' AS datetime)) AND(Fecha_Tur <= CAST('" + fecha_final + "' AS datetime)) AND(Estado_Tur = 1)";
            string cantidad = ds.Contar(consulta);
            return cantidad;
        }

        public string contarPacientesCancelaron(string fecha_inicial, string fecha_final)
        {

            string consulta = "SELECT COUNT(*) FROM Turnos WHERE(Fecha_Tur >= CAST('" + fecha_inicial + "' AS datetime)) AND(Fecha_Tur <= CAST('" + fecha_final + "' AS datetime)) AND(Estado_Tur = 0)";
            string cantidad = ds.Contar(consulta);
            return cantidad;
        }
    }
}