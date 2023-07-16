using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        NegocioPaciente neg = new NegocioPaciente();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            lblUsuario.Text = Session["NombreUsuario"].ToString();
            lblTipoUsuario.Text = Session["TipoUsuario"].ToString();
        }

        protected void btnAgregar_Pac_Click(object sender, EventArgs e)
        {
            Boolean estado = false;
            estado = neg.agregarPaciente(txtDNI_Pac.Text, txtNombre_Pac.Text, txtApellido_Pac.Text, txtObraSocial_Pac.Text, txtDireccion_Pac.Text, txtTelefono_Pac.Text, txtEmail_Pac.Text);
            if (estado == true)
            {
                lblMensaje.Text = "Paciente agregado con exito";
                limpiarTextBox();
            }
            else
            {
                lblMensaje.Text = "No se pudo agregar, datos faltantes";
            }

        }

        public void limpiarTextBox()
        {
            txtDNI_Pac.Text = "";
            txtNombre_Pac.Text = "";
            txtApellido_Pac.Text = "";
            txtObraSocial_Pac.Text = "";
            txtDireccion_Pac.Text = "";
            txtTelefono_Pac.Text = "";
            txtEmail_Pac.Text = "";
        }


    }
}