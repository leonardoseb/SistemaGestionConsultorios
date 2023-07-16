using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProfesionalXEspecialidad
    {
        private string Matricula_PxE;
        private string CodEspecialidad_PxE;

        public ProfesionalXEspecialidad()
        { }

        public string getMatricula_PxE1()
        {
            return Matricula_PxE;
        }

        public void setMatricula_PxE(string matri)
        {
            Matricula_PxE = matri;
        }

        public string getCodEspecialidad_PxE()
        {
            return CodEspecialidad_PxE;
        }

        public void setCodEspecialidad_PxE(string cod)
        {
            CodEspecialidad_PxE = cod;
        }


    }
}
