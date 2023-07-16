using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class HistoriaClinica
    {
        private int CodPaciente_HC;
        public HistoriaClinica()
        {

        }

        public int getCodPaciente_HC()
        {
            return CodPaciente_HC;
        }
        public void setCodPaciente_HC(int codPaciente_HC)
        {
            CodPaciente_HC = codPaciente_HC;
        }
        
    }
}
