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
    public class DaoEspecialidades
    {
        AccesoDatos ds = new AccesoDatos();

        public SqlDataReader getEspecialidades()
        {

            String consulta = "Select * from Especialidades";

            return ds.ObtenerEspecialidades(consulta);
        }

        public string buscarCodEspecialidad(string descrip)
        {
            string consulta = "SELECT CodEspecialidad_Esp FROM Especialidades WHERE Descripcion_Esp = '" + descrip + "'";

            string codEspecialidad = ds.buscarCodEspecialidad(consulta);

            return codEspecialidad;

        }
    }
}
