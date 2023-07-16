using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Turno
    {
        private int NroTurno_Tur;
        private string Matricula_Tur;
        private string CodEspecialidad_Tur;
        private string NumConsultorio_Tur;
        private int CodPaciente_Tur;
        private DateTime Fecha_Tur;
        private bool Estado_Tur;

        public Turno()
        { }

        public int geNroTurno_Tur()
        {

            return NroTurno_Tur;
        }
        public void setNroTurno_Tur(int nro)
        {
            NroTurno_Tur = nro;
        }

        public string getMatricula_Tur()
        {
            
            return Matricula_Tur;
        }
        public void setMatricula_Tur(string nro_matri)
        {
            Matricula_Tur = nro_matri;
        }

        public String getCodEspecialidad_Tur()
        {
            return CodEspecialidad_Tur;
        }
        public void setCodEspecialidad_Tur(String codEspecialidad_Tur)
        {
            CodEspecialidad_Tur = codEspecialidad_Tur;
        }

        public String getNumConsultorio_Tur()
        {
            return NumConsultorio_Tur;
        }
        public void setNumConsultorio_Tur(String numConsultorio_Tur)
        {
            NumConsultorio_Tur = numConsultorio_Tur; 
        }

        public int getCodPaciente_Tur()
        {
            return CodPaciente_Tur;
        }
        public void setCodPaciente_Tur(int codPaciente_Tur)
        {
            CodPaciente_Tur = codPaciente_Tur;
        }

        public DateTime getFecha_Tur()
        {
            return Fecha_Tur;
        }
        public void setFecha(DateTime fecha)
        {
            Fecha_Tur = fecha;
        }


        public bool getEstado()
        {
            return Estado_Tur;
        }

        public void setEstado(bool estado)
        {
            Estado_Tur = estado;
        }

            
    }
}
