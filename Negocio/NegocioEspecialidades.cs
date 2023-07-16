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
    public class NegocioEspecialidades
    {
        public SqlDataReader getEspecialidades()
        {

            Dao.DaoEspecialidades dao = new DaoEspecialidades();

            return dao.getEspecialidades();
        }


        public string buscarCodEspecialidad(string user)
        {
            string codEspecialidad;

            DaoEspecialidades dao = new DaoEspecialidades();

            codEspecialidad = dao.buscarCodEspecialidad(user);

            return codEspecialidad;

        }
    }
}
