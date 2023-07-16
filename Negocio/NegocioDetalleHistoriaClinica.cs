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
    public class NegocioDetalleHistoriaClinica
    {
        public DataTable getTabla()
        {
            DaoDetalleHistoriasClinicas dao = new DaoDetalleHistoriasClinicas();
            return dao.getTablaDetalleHistoriasClinicas();
        }

        public DataTable getTablaXLegajo(string Legajo)
        {
            DaoDetalleHistoriasClinicas dao = new DaoDetalleHistoriasClinicas();
            return dao.getTablaDetalleHistoriasClinicasxLegajo(Legajo);
        }

        public bool cargarDetalleHistoriaClinica(int legajo, string matricula, string codEspecialidad, string motivoConsulta, string diagnostico, DateTime fecha)
        {
            int cantFilas;

            DetalleHistoriaClinica dhc = new DetalleHistoriaClinica();
            DaoDetalleHistoriasClinicas daoDHC = new DaoDetalleHistoriasClinicas();

            dhc.setLegajo_DHC(legajo);
            dhc.setMatricula_DHC(matricula);
            dhc.setCodEspecialidad_DHC(codEspecialidad);
            dhc.setMotivoConsulta(motivoConsulta);
            dhc.setDiagnostico(diagnostico);
            dhc.setFechaConsulta_DHC(fecha);

                        
            cantFilas = daoDHC.CargarDetalleHistoriaClinica(dhc);

            if(cantFilas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string buscarMatricula(string codEspecialidad)
        {
            string matricula;

            DaoDetalleHistoriasClinicas dao = new DaoDetalleHistoriasClinicas();

            matricula = dao.buscarMatricula(codEspecialidad);

            return matricula;
        }

        public int buscarLegajo(int codPac)
        {
            int codPaciente; 

            DaoDetalleHistoriasClinicas dao = new DaoDetalleHistoriasClinicas();

            codPaciente = dao.buscarLegajo(codPac);

            return codPaciente;
        }

    }
}
