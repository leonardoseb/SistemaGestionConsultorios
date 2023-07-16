using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Dao;
using System.Data;

namespace Negocio
{
    public class NegocioUsuario
    {
       public bool ValidarIngreso(string user, string pass)
        {
            DaoUsuarios dao = new DaoUsuarios();

            bool resultado = dao.validarPassword(user, pass);

            if (resultado == true)
            {
                return true;
            }

            return false;
        }

        public string buscarTipoUsuario(string user)
        {
            string tipoUsuario;

            DaoUsuarios dao = new DaoUsuarios();

            tipoUsuario = dao.buscarTipoUsuario(user);
            
            return tipoUsuario;

        }
    }
}
