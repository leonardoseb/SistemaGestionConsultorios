using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Profesional
    {

        private string Matricula_Pr;
        private string DNI_Pr;
        private string Nombre_Pr;
        private string Apellido_Pr;
        private string Email_Pr;
        private string Telefono_Pr;
        private bool Estado_Pr;


        public Profesional()
        { }

        public string getMatricula_Pr()
        {
            return Matricula_Pr;
        }
        public void setMatricula_Pr(string matricula_Pr)
        {
            Matricula_Pr = matricula_Pr;
        }

        public string getDNI_Pr()
        {
            return DNI_Pr;
        }
        public void setDNI_Pr(string dni_Pr)
        {
            DNI_Pr = dni_Pr;
        }

        public string getNombre_Pr()
        {
            return Nombre_Pr;
        }
        public void setNombre_Pr(string nombre_Pr)
        {
            Nombre_Pr = nombre_Pr;
        }

        public string getApellido_Pr()
        {
            return Apellido_Pr;
        }
        public void setApellido_Pr(string apellido_Pr)
        {
            Apellido_Pr = apellido_Pr;
        }


        public string getEmail_Pr()
        {
            return Email_Pr;
        }
        public void setEmail_Pr(string email_Pr)
        {
            Email_Pr = email_Pr;
        }

        public string getTelefono_Pr()
        {
            return Telefono_Pr;
        }
        public void setTelefono_Pr(string telefono_Pr)
        {
            Telefono_Pr = telefono_Pr;
        }

        public bool getEstado()
        {
            return Estado_Pr;
        }

        public void setEstado(bool estado)
        {
            Estado_Pr = estado;
        }
    }
}
