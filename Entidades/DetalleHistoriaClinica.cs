using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleHistoriaClinica
    {
        private int Legajo_DHC;
        private string Matricula_DHC;
        private string CodEspecialidad_DHC;
        private string MotivoConsulta_DHC;
        private string Diagnostico_DHC;
        private DateTime FechaConsulta_DHC;

        public DetalleHistoriaClinica()
        {

        }

        public int getLegajo_DHC()
        {
            return Legajo_DHC;
        }
        public void setLegajo_DHC(int legajo)
        {
            Legajo_DHC = legajo;
        }
        public string getMatricula_DHC()
        {
            return Matricula_DHC;
        }
        public void setMatricula_DHC(string matricula)
        {
            Matricula_DHC = matricula;
        }    
        public string getCodEspecialidad_DHC()
        {
            return CodEspecialidad_DHC;
        }
        public void setCodEspecialidad_DHC(string codEspecialidad)
        {
            CodEspecialidad_DHC = codEspecialidad;
        }
        public string getMotivoConsulta()
        {
            return MotivoConsulta_DHC;
        }
        public void setMotivoConsulta(string motivo)
        {
            MotivoConsulta_DHC = motivo;
        }
        public string getDiagnostico()
        {
            return Diagnostico_DHC;
        }
        public void setDiagnostico(string diagnostic)
        {
            Diagnostico_DHC = diagnostic;
        }
        public DateTime getFechaConsulta_DHC()
        {
            return FechaConsulta_DHC;
        }
        public void setFechaConsulta_DHC(DateTime fecha)
        {
            FechaConsulta_DHC = fecha;
        }

    }
}
