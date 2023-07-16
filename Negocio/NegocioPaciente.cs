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
    public class NegocioPaciente
    {
        public DataTable getTabla()
        {
            DaoPacientes dao = new DaoPacientes();
            return dao.getTablaPacientes();
        }

        public DataTable getTablaPacientes(string dni)
        {
            DaoPacientes dao = new DaoPacientes();
            return dao.getTablaPacientesFiltro(dni);
        }

        public String ObtenerDatosPaciente(string dni)
        {
            DaoPacientes dao = new DaoPacientes();

            string NombreyApellido = dao.ObtenerDatosPaciente(dni);

            return NombreyApellido;
        }

        public bool agregarPaciente(string dni, string nombre, string ape, string obrasoc, string direc, string tel, string email)
        {
            int cantFilas = 0;

            Paciente pac = new Paciente();
            pac.setDNI_Pac(dni);
            pac.setNombre_Pac(nombre);
            pac.setApellido_Pac(ape);
            pac.setObraSocial_Pac(obrasoc);
            pac.setDireccion_Pac(direc);
            pac.setTelefono_Pac(tel);
            pac.setEmail_Pac(email);

            DaoPacientes daoP = new DaoPacientes();

            if (daoP.existePaciente(pac) == false)
            {
                cantFilas = daoP.agregarPaciente(pac);
            }

            if (cantFilas == 1)
            {
                return true;
            }   
            else
            {
                return false;
            }
               
        }

        public bool EliminarPaciente(string dni)
        {
            DaoPacientes dao = new DaoPacientes();
            Paciente pac = new Paciente();

            pac.setDNI_Pac(dni);
            bool op = dao.EliminarPaciente(pac);
            if (op == true)
                return true;
            else
                return false;
        }

        public bool actualizarPaciente(string dni, string nombre, string ape, string obrasoc, string direc, string tel, string email, bool estado)
        {
            DaoPacientes dao = new DaoPacientes();
            Paciente pac = new Paciente();

            pac.setDNI_Pac(dni);
            pac.setNombre_Pac(nombre);
            pac.setApellido_Pac(ape);
            pac.setObraSocial_Pac(obrasoc);
            pac.setDireccion_Pac(direc);
            pac.setTelefono_Pac(tel);
            pac.setEmail_Pac(email);
            pac.setEstado(estado);

            bool op = dao.ActualizarPaciente(pac);
            if (op == true)
                return true;
            else
                return false;
        }

        public bool validarDNI(string dni)
        {
            DaoPacientes dao = new DaoPacientes();
            Paciente pac = new Paciente();
            pac.setDNI_Pac(dni);

            bool existe = dao.existePaciente(pac);

            if (existe == true)
                return true;
            else
                return false;
        }
    }

    
}
