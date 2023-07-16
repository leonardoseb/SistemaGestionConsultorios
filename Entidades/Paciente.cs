using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paciente
    {
        
        private string DNI_Pac;
        private string Nombre_Pac;
        private string Apellido_Pac;
        private string ObraSocial_Pac;
        private string Direccion_Pac;
        private string Telefono_Pac;
        private string Email_Pac;
        private bool Estado_Pac;

        public Paciente()
        {

        }

        public string getDNI_Pac()
        {
            return DNI_Pac;
        }
        public void setDNI_Pac(string dni_Pac)
        {
            DNI_Pac = dni_Pac;
        }
        public string getNombre_Pac()
        {
            return Nombre_Pac;
        }
        public void setNombre_Pac(string nombre_Pac)
        {
            Nombre_Pac = nombre_Pac;
        }
        public string getApellido_Pac()
        {
            return Apellido_Pac;
        }
        public void setApellido_Pac(string apellido_Pac)
        {
            Apellido_Pac = apellido_Pac;
        }

        public string getObraSocial_Pac()
        {
            return ObraSocial_Pac;
        }
        public void setObraSocial_Pac(string obraSocial_Pac)
        {
            ObraSocial_Pac = obraSocial_Pac;
        }

        public string getDireccion_Pac()
        {
            return Direccion_Pac;
        }
        public void setDireccion_Pac(string direccion_Pac)
        {
            Direccion_Pac = direccion_Pac;
        }

        public string getTelefono_Pac()
        {
            return Telefono_Pac;
        }
        public void setTelefono_Pac(string telefono_Pac)
        {
            Telefono_Pac = telefono_Pac;
        }

        public string getEmail_Pac()
        {
            return Email_Pac;
        }
        public void setEmail_Pac(string email_Pac)
        {
            Email_Pac = email_Pac;
        }

        public bool getEstado()
        {
            return Estado_Pac;
        }

        public void setEstado(bool estado)
        {
            Estado_Pac = estado;
        }


    }
}


