using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class DaoUsuarios
    {
        AccesoDatos ds = new AccesoDatos();

        public Boolean validarPassword(string user, string pass)
        {
            string consulta = "SELECT * FROM Usuarios WHERE NombreUsuario = '" + user + "'AND Password = '" + pass + "'";  
            
            return ds.existe(consulta);
        }

        public string buscarTipoUsuario(string user)
        {
            string consulta = "SELECT TipoUsuario FROM Usuarios WHERE NombreUsuario = '" + user +"'";

            string tipoUsuario = ds.buscarTipoUsuario(consulta);

            return tipoUsuario;

        }

    }
}
