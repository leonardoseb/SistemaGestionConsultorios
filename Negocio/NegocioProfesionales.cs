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
    public class NegocioProfesionales
    {
        public DataTable getTabla()
        {
             DaoProfesionales dao = new DaoProfesionales();
                return dao.getTablaProfesionables();
        }

        public DataTable getTablaProfesionales(string dni)
        {
            DaoProfesionales dao = new DaoProfesionales();
            return dao.getTablaProfesionalesFiltro(dni);
        }

        public DataTable getTablaProfesional (string matricula)
        {
            DaoProfesionales dao = new DaoProfesionales();
            return dao.getTablaProfesional(matricula);
        }


        public bool agregarProfesional(string mat, string dni, string nombre, string ape, string email, string tel)
        {
            int cantFilas = 0;

            Profesional pr = new Profesional();
            pr.setMatricula_Pr(mat);
            pr.setDNI_Pr(dni);
            pr.setNombre_Pr(nombre);
            pr.setApellido_Pr(ape);
            pr.setEmail_Pr(email);
            pr.setTelefono_Pr(tel);

            DaoProfesionales daoP = new DaoProfesionales();

            if (daoP.existeProfesional(pr) == false)
            {
                cantFilas = daoP.agregarProfesional(pr);
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

        public bool EliminarProfesional(string mat)
        {
            DaoProfesionales dao = new DaoProfesionales();
            Profesional pr = new Profesional();

            pr.setMatricula_Pr(mat);
            bool op = dao.EliminarProfesional(pr);
            if (op == true)
                return true;
            else
                return false;
        }

        public SqlDataReader getProfesionales(string codEsp)
        {

            Dao.DaoProfesionales dao = new DaoProfesionales();

            return dao.getProfesionales(codEsp);
        }

        public bool actualizarProfesional(string mat, string dni, string nombre, string ape, string email, string tel, bool estado)
        {
            DaoProfesionales dao = new DaoProfesionales();
            Profesional pac = new Profesional();

            pac.setMatricula_Pr(mat);
            pac.setDNI_Pr(dni);
            pac.setNombre_Pr(nombre);
            pac.setApellido_Pr(ape);
            pac.setEmail_Pr(email);
            pac.setTelefono_Pr(tel);
            pac.setEstado(estado);

            bool op = dao.ActualizarProfesional(pac);
            if (op == true)
                return true;
            else
                return false;
        }


    }
}
