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
    public class NegocioProfesionalesXEspecialidades
    {
        public DataTable getTabla()
        {
            DaoProfesionales dao = new DaoProfesionales();
            return dao.getTablaProfesionables();
        }

        public bool agregarProfesionalXEspecialidad(string mat, string cod)
        {
            int cantFilas = 0;

            ProfesionalXEspecialidad pxe = new ProfesionalXEspecialidad();
            pxe.setMatricula_PxE(mat);
            pxe.setCodEspecialidad_PxE(cod);


            DaoProfesionalesXEspecialidades daoPxE = new DaoProfesionalesXEspecialidades();

            if (daoPxE.existeProfesionalXEspecialidad(pxe) == false)
            {
                cantFilas = daoPxE.agregarProfesionalXEspecialidad(pxe);
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

        public SqlDataReader getEspecialistas()
        {

            DaoProfesionalesXEspecialidades daoPxE = new DaoProfesionalesXEspecialidades();

            return daoPxE.getEspecialistas();
        }

       

    }
}
