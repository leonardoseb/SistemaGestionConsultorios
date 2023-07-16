using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dao;
using Entidades;


namespace Negocio
{
    public class NegocioReporte
    {
        public string ContarxEsp(string especialidad)
        {

            DaoReportes daoR = new DaoReportes();
            return daoR.contarPacientesEsp(especialidad);

        }
        public string ContarxOS(string OS)
        {

            DaoReportes daoR = new DaoReportes();
            return daoR.contarPacientesOS(OS);

        }

        public SqlDataReader getObrasSociales()
        {
            DaoReportes dao = new DaoReportes();
            return dao.getObrasSociales();
        }

        public string ContarAtendidos(string fecha_inicial, string fecha_final)
        {

            DaoReportes daoR = new DaoReportes();
            return daoR.contarPacientesAtendidos(fecha_inicial, fecha_final);

        }

        public string ContarCancelados(string fecha_inicial, string fecha_final)
        {

            DaoReportes daoR = new DaoReportes();
            return daoR.contarPacientesCancelaron(fecha_inicial, fecha_final);

        }

    }
}