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
    public partial class WebForm3 : System.Web.UI.Page
    {
   
            NegocioProfesionales neg = new Negocio.NegocioProfesionales();

            protected void Page_Load(object sender, EventArgs e)
            {

                Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

                if (!IsPostBack)
                {
  
                      if (Session["NombreUsuario"] == null)
                      {
                        Response.Redirect("Login.aspx");
                      }

                      lblUsuario.Text = Session["NombreUsuario"].ToString();
                      lblTipoUsuario.Text = Session["TipoUsuario"].ToString();

                    switch (lblTipoUsuario.Text)
                    {
                        case "Administrador":
                                            DataTable tablaProfesionales = neg.getTabla();
                                            grdProfesionales.DataSource = tablaProfesionales;
                                            grdProfesionales.DataBind();
                                            break;

                        case "Profesional":
                                            DataTable tablaProfesional = neg.getTablaProfesional(lblUsuario.Text);
                                            grdProfesionales.DataSource = tablaProfesional;
                                            grdProfesionales.DataBind();
                                            ocultarControles();

                                            break;
                    }
            }
            }

        protected void grdProfesionales_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string aux_matProfesional = ((Label)grdProfesionales.Rows[e.RowIndex].FindControl("lbl_pr_nro_matricula")).Text;

            neg.EliminarProfesional(aux_matProfesional);
        }

        protected void btnBuscar_Pr_Click(object sender, EventArgs e)
        {
            DataTable tablaProfesionales = neg.getTablaProfesionales(txtBuscarDNI_Pr.Text);
            grdProfesionales.DataSource = tablaProfesionales;
            grdProfesionales.DataBind();
        }

        void ocultarControles()
        {
            HyperLink4.Visible = false;
            HyperLink5.Visible = false;
            btnBuscar_Pr.Visible = false;
            txtBuscarDNI_Pr.Visible = false;
            lblMsj.Visible = false;
            lblMsj3.Visible = false;
        }

        protected void grdProfesionales_RowEditing(object sender, GridViewEditEventArgs e)
        {
            switch (lblTipoUsuario.Text)
            {
                case "Administrador":
                    grdProfesionales.EditIndex = e.NewEditIndex;
                    grdProfesionales.DataSource = neg.getTabla();
                    grdProfesionales.DataBind();
                    break;

                case "Profesional":
                    grdProfesionales.EditIndex = e.NewEditIndex;
                    grdProfesionales.DataSource = neg.getTablaProfesional(lblUsuario.Text);
                    grdProfesionales.DataBind();

                    break;
            }


        }

        protected void grdProfesionales_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            switch (lblTipoUsuario.Text)
            {
                case "Administrador":
                    grdProfesionales.EditIndex = -1;
                    grdProfesionales.DataSource = neg.getTabla();
                    grdProfesionales.DataBind();
                    break;

                case "Profesional":
                    grdProfesionales.EditIndex = -1;
                    grdProfesionales.DataSource = neg.getTablaProfesional(lblUsuario.Text);
                    grdProfesionales.DataBind();

                    break;
            }

        }

        protected void grdProfesionales_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {


            string aux_matriculaProfesional = ((Label)grdProfesionales.Rows[e.RowIndex].FindControl("lbl_matricula")).Text;
            string aux_dniProfesional = ((TextBox)grdProfesionales.Rows[e.RowIndex].FindControl("txt_dni")).Text;
            string aux_nombreProfesional = ((TextBox)grdProfesionales.Rows[e.RowIndex].FindControl("txt_nombre")).Text;
            string aux_apellidoProfesional = ((TextBox)grdProfesionales.Rows[e.RowIndex].FindControl("txt_apellido")).Text;
            string aux_emailProfesional = ((TextBox)grdProfesionales.Rows[e.RowIndex].FindControl("txt_email")).Text;
            string aux_telefonoProfesinal = ((TextBox)grdProfesionales.Rows[e.RowIndex].FindControl("txt_telefono")).Text;
            string aux_estadoProfesional = ((TextBox)grdProfesionales.Rows[e.RowIndex].FindControl("txt_estado")).Text;

            bool estado;

            if (aux_estadoProfesional == "Alta")
            {
                estado = true;
            }
            else estado = false;

            neg.actualizarProfesional(aux_matriculaProfesional, aux_dniProfesional, aux_nombreProfesional, aux_apellidoProfesional, aux_emailProfesional, aux_telefonoProfesinal, estado);

            switch (lblTipoUsuario.Text)
            {
                case "Administrador":

                    grdProfesionales.EditIndex = -1;
                    grdProfesionales.DataSource = neg.getTabla();
                    grdProfesionales.DataBind();

                    break;

                case "Profesional":

                    grdProfesionales.EditIndex = -1;
                    grdProfesionales.DataSource = neg.getTablaProfesional(lblUsuario.Text);
                    grdProfesionales.DataBind();

                    break;
            }


        }
    }
}