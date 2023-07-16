using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Negocio;

namespace Vistas
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        NegocioPaciente neg = new NegocioPaciente();
        NegocioEspecialidades espec = new NegocioEspecialidades();
        NegocioReporte reporte = new NegocioReporte();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {                DataTable tablaPacientes = neg.getTabla();
                grdPacientes.DataSource = tablaPacientes;
                grdPacientes.DataBind();

                if (Session["NombreUsuario"] == null)
                {
                    Response.Redirect("Login.aspx");
                }

                lblUsuario.Text = Session["NombreUsuario"].ToString();
                lblTipoUsuario.Text = Session["TipoUsuario"].ToString();

            }
        }
        protected void grdPacientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string aux_dniPaciente = ((Label)grdPacientes.Rows[e.RowIndex].FindControl("lbl_it_dni")).Text;

            neg.EliminarPaciente(aux_dniPaciente);
            grdPacientes.DataSource = neg.getTabla();
            grdPacientes.DataBind();


        }

        protected void grdPacientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdPacientes.EditIndex = e.NewEditIndex;
            grdPacientes.DataSource = neg.getTabla();
            grdPacientes.DataBind();

        }

        protected void grdPacientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdPacientes.EditIndex = -1;
            grdPacientes.DataSource = neg.getTabla();
            grdPacientes.DataBind();
        }

        protected void grdPacientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            string aux_dniPaciente = ((TextBox)grdPacientes.Rows[e.RowIndex].FindControl("txt_dni")).Text;
            string aux_nombrePaciente = ((TextBox)grdPacientes.Rows[e.RowIndex].FindControl("txt_nombre")).Text;
            string aux_apellidoPaciente = ((TextBox)grdPacientes.Rows[e.RowIndex].FindControl("txt_apellido")).Text;
            string aux_obrasocialPaciente = ((TextBox)grdPacientes.Rows[e.RowIndex].FindControl("txt_obrasocial")).Text;
            string aux_direccionPaciente = ((TextBox)grdPacientes.Rows[e.RowIndex].FindControl("txt_direccion")).Text;
            string aux_emailPaciente = ((TextBox)grdPacientes.Rows[e.RowIndex].FindControl("txt_email")).Text;
            string aux_telefonoPaciente = ((TextBox)grdPacientes.Rows[e.RowIndex].FindControl("txt_telefono")).Text;
            string aux_estadoPaciente = ((TextBox)grdPacientes.Rows[e.RowIndex].FindControl("txt_estado")).Text;

            bool estado;

            if (aux_estadoPaciente == "Alta")
            {
                estado = true;
            }
            else estado = false;
 
                 

            neg.actualizarPaciente(aux_dniPaciente, aux_nombrePaciente, aux_apellidoPaciente, aux_obrasocialPaciente, aux_direccionPaciente, aux_telefonoPaciente, aux_emailPaciente, estado);

            grdPacientes.EditIndex = -1;
            grdPacientes.DataSource = neg.getTabla();
            grdPacientes.DataBind();
        }

        protected void btnBuscar_Pac_Click(object sender, EventArgs e)
        {
            DataTable tablaPacientes = neg.getTablaPacientes(txtBuscarDNI_Pac.Text);
            grdPacientes.DataSource = tablaPacientes;
            grdPacientes.DataBind();
        }

        protected void ddlDatos_Load(object sender, EventArgs e)
        {

        }

        
    }
}