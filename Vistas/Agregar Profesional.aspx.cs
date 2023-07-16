using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.Data;
using System.Data.SqlClient;

namespace Vistas
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        NegocioProfesionales neg = new NegocioProfesionales();
        NegocioProfesionalesXEspecialidades pxe = new NegocioProfesionalesXEspecialidades();
        NegocioEspecialidades esp = new NegocioEspecialidades();

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            lblUsuario.Text = Session["NombreUsuario"].ToString();
            lblTipoUsuario.Text = Session["TipoUsuario"].ToString();
        }

        protected void btnAgregar_Pr_Click(object sender, EventArgs e)
        {
            Boolean estado = false;
           
            estado = neg.agregarProfesional(txtNumMatricula.Text, txtDNI_Pr.Text, txtNombre_Pr.Text, txtApellido_Pr.Text, txtEmail_Pr.Text, txtTelefono_Pr.Text);

            Boolean estado2 = false;

            string codEspecialidad = ddlEspecialidades.SelectedItem.Value;

            estado2 = pxe.agregarProfesionalXEspecialidad(txtNumMatricula.Text, codEspecialidad);


            if (estado2 == true)
            {
                lblMensajePr.Text = "Profesional agregado con exito";
                limpiarTextBox();
            }
            else
            {
                lblMensajePr.Text = "No se pudo agregar, datos faltantes";
            }


        }
        public void limpiarTextBox()
        {
            txtNumMatricula.Text = "";
            txtDNI_Pr.Text = "";
            txtNombre_Pr.Text = "";
            txtApellido_Pr.Text = "";
            txtEmail_Pr.Text = "";
            txtTelefono_Pr.Text = "";
            ddlEspecialidades.SelectedIndex = 0;
        }

        protected void ddlEspecialidades_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlDataReader dr = esp.getEspecialidades();
                ddlEspecialidades.DataSource = dr;
                ddlEspecialidades.DataTextField = "Descripcion_Esp";
                ddlEspecialidades.DataValueField = "CodEspecialidad_Esp";
                ddlEspecialidades.DataBind();
                ddlEspecialidades.Items.Insert(0, new ListItem("--Seleccionar--", "0"));

            }

        }

        protected void ddlEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}