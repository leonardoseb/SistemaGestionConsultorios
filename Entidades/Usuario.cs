using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        private int IdUsuario;
        private string nombreUsuario;
        private string password;
        private string tipoUsuario;

        public Usuario()
        { }

        public int IdUsuario1 { get => IdUsuario; set => IdUsuario = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Password { get => password; set => password = value; }
        public string TipoUsuario { get => tipoUsuario; set => tipoUsuario = value; }
    }
}
