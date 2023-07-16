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
    public partial class HistoriasClinicas : System.Web.UI.Page
    {
        NegocioHistoriaClinica neg = new Negocio.NegocioHistoriaClinica();
        NegocioDetalleHistoriaClinica neg2 = new NegocioDetalleHistoriaClinica();

        protected void Page_Load(object sender, EventArgs e)
        {
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
                        DataTable tablaHistoriasClinicas = neg.getTabla();
                        grdHistoriasClinicas.DataSource = tablaHistoriasClinicas;
                        grdHistoriasClinicas.DataBind();
                        break;

                    case "Profesional":
                        DataTable tablaHistoriasClinicasXProfesional = neg.getTablaHistoriaClinicaXProfesional(lblUsuario.Text);
                        grdHistoriasClinicas.DataSource = tablaHistoriasClinicasXProfesional;
                        grdHistoriasClinicas.DataBind();
                        ocultarControles();

                        break;
                }
            }

        }

        protected void grdHistoriasClinicas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "eventoDetalle")
            {
                // se hizo click sobre el boton 'Detalle'
                int fila = Convert.ToInt32(e.CommandArgument);

                lblMensaje.Text = "";
                lbl_detalles.Text = "";

                String s_hc_Legajo = ((Label)grdHistoriasClinicas.Rows[fila].FindControl("lbl_hc_Legajo")).Text;
                String s_hc_CodPaciente = ((Label)grdHistoriasClinicas.Rows[fila].FindControl("lbl_hc_CodigoPaciente")).Text;
                String s_hc_Nombre = ((Label)grdHistoriasClinicas.Rows[fila].FindControl("lbl_Nombre")).Text;
                String s_hc_Apellido = ((Label)grdHistoriasClinicas.Rows[fila].FindControl("lbl_Apellido")).Text;

                DataTable tablaDetallesHistoriasClinicas = neg2.getTablaXLegajo(s_hc_Legajo);
                lblMensaje.Text = "Se seleccionó la historia clinica de " +s_hc_Nombre +" "+s_hc_Apellido+". Legajo N° " + s_hc_Legajo + ". Codigo Paciente N° " + s_hc_CodPaciente;
                grdDetallesHistoriaClinica.DataSource = tablaDetallesHistoriasClinicas;
                grdDetallesHistoriaClinica.DataBind();
            }

            if(e.CommandName == "eventoNuevaConsulta")
            {
                // se hizo click sobre el boton 'Nueva Consulta'
                int fila = Convert.ToInt32(e.CommandArgument);

                String s_hc_CodPaciente = ((Label)grdHistoriasClinicas.Rows[fila].FindControl("lbl_hc_CodigoPaciente")).Text;

                Response.Redirect("AgregarDetalle.aspx?Cod=" + s_hc_CodPaciente);


            }
        }

            void ocultarControles()
            {
                HyperLink4.Visible = false;
            }


        }
}