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
    public class NegocioTurno
    {
        public DataTable getTabla()
        {
            DaoTurnos dao = new DaoTurnos();
            return dao.getTablaTurnos();
        }

        public DataTable getTablaTurno(string turno)
        {
            DaoTurnos dao = new DaoTurnos();
            return dao.getTablaTurnoFiltro(turno);
        }

        public DataTable getTablaTurnosPorMedicos(string matricula)
        {
            DaoTurnos dao = new DaoTurnos();
            return dao.getTablaTurnosPorMedicos(matricula);
        }

        public DataTable getTablaTurnosPorMedicosFiltro(string turno)
        {
            DaoTurnos dao = new DaoTurnos();
            return dao.getTablaTurnosPorMedicosFiltro(turno);
        }

        public bool EliminarTurno(int nroTurno)
        {
            DaoTurnos dao = new DaoTurnos();
            Turno tur = new Turno();

            tur.setNroTurno_Tur(nroTurno);
            bool op = dao.EliminarTurno(tur);
            if (op == true)
                return true;
            else
                return false;
        }

        public bool agregarTurno(string mat, string codEsp, string numConsultorio, int codPac, DateTime fecha, bool estado)
        {
            Turno tur = new Turno();

            tur.setMatricula_Tur(mat);
            tur.setCodEspecialidad_Tur(codEsp);
            tur.setNumConsultorio_Tur(numConsultorio);
            tur.setCodPaciente_Tur(codPac);
            tur.setFecha(fecha);
            tur.setEstado(estado);

            DaoTurnos daoTur = new DaoTurnos();

            int cantFilas = 0;

            cantFilas = daoTur.agregarTurno(tur);

            if (cantFilas == 1)
            {
                return true;
            }
            else
            {
                return false;
            } 
           
        }

        public string buscarCodEspecialidad(string descripEsp)
        {
            string codEspecialidad;

            DaoTurnos dao = new DaoTurnos();

            codEspecialidad = dao.buscarCodEspecialidad(descripEsp);

            return codEspecialidad;

        }

        public int buscarCodPaciente(string dni)
        {
            int codPaciente;

            DaoTurnos dao = new DaoTurnos();

            codPaciente = dao.buscarCodPaciente(dni);

            return codPaciente;

        }

        public string buscarMatricula(string codEspecialidad)
        {
            string matricula;

            DaoTurnos dao = new DaoTurnos();

            matricula = dao.buscarMatricula(codEspecialidad);

            return matricula;
        }

        public string buscarConsultorio(string especialidad)
        {
            string consultorio;

            DaoTurnos dao = new DaoTurnos();

            consultorio = dao.buscarConsultorio(especialidad);

            return consultorio;
        }
    }
}
