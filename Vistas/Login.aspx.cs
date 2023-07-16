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
    public partial class Login : System.Web.UI.Page
    {
        NegocioUsuario neg = new NegocioUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
          
                if (neg.ValidarIngreso(txtUsuario.Text, txtPassword.Text))
                {
                    string tipoUsuario;

                    tipoUsuario = neg.buscarTipoUsuario(txtUsuario.Text);
                    Session["NombreUsuario"] = txtUsuario.Text;
                    Session["TipoUsuario"] = tipoUsuario;
                    Response.Redirect("Turnos.aspx");
                }
                else
                {
                lblMensaje.Text = "DATOS INCORRECTOS.";         
                }
            }
    }
}