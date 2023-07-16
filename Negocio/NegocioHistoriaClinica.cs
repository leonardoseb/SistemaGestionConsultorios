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
    public class NegocioHistoriaClinica
    {
        public DataTable getTabla()
        {
            DaoHistoriaClinica dao = new DaoHistoriaClinica();
            return dao.getTablaHistoriasClinicas();
        }

        public DataTable getTablaHistoriaClinicaXProfesional(string matricula)
        {
            DaoHistoriaClinica dao = new DaoHistoriaClinica();
            return dao.getTablaHistoriaClinicaXProfesional(matricula);

        }
        public bool cargarHistoriaClinica(int codPaciente)
        {
            int cantFilas = 0;

            HistoriaClinica hc = new HistoriaClinica();
            hc.setCodPaciente_HC(codPaciente);
            

            DaoHistoriaClinica daoHC = new DaoHistoriaClinica();



            if (daoHC.existeHistoriaClinica(hc) == false)
            {
                cantFilas = daoHC.cargarHistoriaClinica(hc);
            }
            else
            {
                cantFilas = 1;
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

        public int buscarCodPaciente(string dni)
        {
            int codPaciente;

            DaoHistoriaClinica dao = new DaoHistoriaClinica();

            codPaciente = dao.buscarCodPaciente(dni);

            return codPaciente;

        }

        

    }
}
