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
    public class DaoProfesionalesXEspecialidades
    {
        AccesoDatos ds = new AccesoDatos();

        private void ArmarParametrosProfesionalXEspecialidad(ref SqlCommand Comando, ProfesionalXEspecialidad pxe)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@MATRICULA_PXE", SqlDbType.Char, 5);
            SqlParametros.Value = pxe.getMatricula_PxE1();
            SqlParametros = Comando.Parameters.Add("@CODESPECIALIDAD_PXE", SqlDbType.Char, 5);
            SqlParametros.Value = pxe.getCodEspecialidad_PxE();
        }

        public int agregarProfesionalXEspecialidad(ProfesionalXEspecialidad pxe)
        {
            pxe.setMatricula_PxE(pxe.getMatricula_PxE1());
            pxe.setCodEspecialidad_PxE(pxe.getCodEspecialidad_PxE());

            SqlCommand comando = new SqlCommand();
            ArmarParametrosProfesionalXEspecialidad(ref comando, pxe);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarProfesionalXEspecialidad");
        }

        public Boolean existeProfesionalXEspecialidad(ProfesionalXEspecialidad pxe)
        {
            String consulta = "Select * from ProfesionalesXEspecialidades where Matricula_PxE ='" + pxe.getMatricula_PxE1() + "'";
            return ds.existe(consulta);
        }

        public SqlDataReader getEspecialistas()
        {

            String consulta = "Select * from Especialidades";

            return ds.ObtenerEspecialistas(consulta);
        }

    }
}
