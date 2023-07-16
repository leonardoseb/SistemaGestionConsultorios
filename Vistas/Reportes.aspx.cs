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
    public partial class Reportes : System.Web.UI.Page
    {
        NegocioReporte neg = new NegocioReporte();
        NegocioEspecialidades espec = new NegocioEspecialidades();
        NegocioReporte reporte = new NegocioReporte();


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

                        Calendar1.Visible = false;
                        Calendar2.Visible = false;
                        ddlDatos.Visible = false;
                        btn_fecha_final.Visible = false;
                        btn_fecha_inicial.Visible = false;
                        lblReporte5.Visible = false;
                        lblReporte6.Visible = false;
                        lblDato.Visible = false;
                        break;

                    case "Profesional":

                        Calendar1.Visible = false;
                        Calendar2.Visible = false;
                        ddlDatos.Visible = false;
                        btn_fecha_final.Visible = false;
                        btn_fecha_inicial.Visible = false;
                        lblReporte5.Visible = false;
                        lblReporte6.Visible = false;
                        lblDato.Visible = false;
                        HyperLink3.Visible = false;

                        break;
                }

            }
        }

        protected void btnReporte1_Click(object sender, EventArgs e)
        {

            if (ddlCriterio.SelectedItem.Value == "1")
            {
                string cantidad = neg.ContarAtendidos(lbl_fecha_final.Text, lbl_fecha_final.Text);
                lblReporte.Text = "Cantidad de turnos realizados: " + cantidad;
            }
            else if (ddlCriterio.SelectedItem.Value == "2")
            {
                string cantidad = neg.ContarCancelados(lbl_fecha_inicial.Text, lbl_fecha_final.Text);
                lblReporte.Text = "Cantidad de turnos cancelados: " + cantidad;
            }
            else if (ddlCriterio.SelectedItem.Value == "3")
            {
                string cantidad = reporte.ContarxEsp(ddlDatos.SelectedItem.Value);
                lblReporte.Text = "Cantidad de pacientes atendidos en " + ddlDatos.SelectedItem.Text + ": " + cantidad;
                lblReporte.Visible = true;
            }
            else if (ddlCriterio.SelectedItem.Value == "4")
            {
                string cantidad = reporte.ContarxOS(ddlDatos.SelectedItem.Text);
                lblReporte.Text = "Cantidad de pacientes con " + ddlDatos.SelectedItem.Text + ": " + cantidad;
                lblReporte.Visible = true;
            }


        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            lbl_fecha_inicial.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        protected void btn_fecha_inicial_Click(object sender, EventArgs e)
        {
            Calendar2.Visible = false;
            Calendar1.Visible = true;
        }

        protected void btn_fecha_final_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = false;
            Calendar2.Visible = true;
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            lbl_fecha_final.Text = Calendar2.SelectedDate.ToShortDateString();
        }

        protected void ddlCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((ddlCriterio.SelectedItem.Value == "1") || (ddlCriterio.SelectedItem.Value == "2"))
            {
                ddlDatos.Visible = true;
                btn_fecha_final.Visible = true;
                btn_fecha_inicial.Visible = true;
            }
            else if (ddlCriterio.SelectedItem.Value == "3")
            {

                btn_fecha_final.Visible = false;
                btn_fecha_inicial.Visible = false;

                ddlDatos.Visible = true;
                ddlDatos.Items.Clear();

                SqlDataReader dr = espec.getEspecialidades();
                ddlDatos.DataSource = dr;
                ddlDatos.DataTextField = "Descripcion_Esp";
                ddlDatos.DataValueField = "CodEspecialidad_Esp";
                ddlDatos.DataBind();
                ddlDatos.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
            }
            else if (ddlCriterio.SelectedItem.Value == "4")
            {
                btn_fecha_final.Visible = false;
                btn_fecha_inicial.Visible = false;
                ddlDatos.Visible = true;
                ddlDatos.Items.Clear();


                SqlDataReader dr = reporte.getObrasSociales();
                ddlDatos.DataSource = dr;
                ddlDatos.DataTextField = "ObraSocial_Pac";
                ddlDatos.DataBind();
                ddlDatos.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
            }
        }

        protected void btnSeleccionarCrit_Click(object sender, EventArgs e)
        {
            if ((ddlCriterio.SelectedItem.Value == "1") || (ddlCriterio.SelectedItem.Value == "2"))
            {
                ddlDatos.Visible = false;
                btn_fecha_final.Visible = true;
                btn_fecha_inicial.Visible = true;
                lbl_fecha_final.Visible = true;
                lbl_fecha_inicial.Visible = true;
                lblDato.Visible = false;
                lblReporte5.Visible = true;
                lblReporte6.Visible = true;
            }
            else if (ddlCriterio.SelectedItem.Value == "3")
            {

                btn_fecha_final.Visible = false;
                btn_fecha_inicial.Visible = false;
                lblReporte5.Visible = false;
                lblReporte6.Visible = false;
                lbl_fecha_final.Visible = false;
                lbl_fecha_inicial.Visible = false;
                ddlDatos.Visible = true;
                lblDato.Visible = true;
                ddlDatos.Items.Clear();
                SqlDataReader dr = espec.getEspecialidades();
                ddlDatos.DataSource = dr;
                ddlDatos.DataTextField = "Descripcion_Esp";
                ddlDatos.DataValueField = "CodEspecialidad_Esp";
                ddlDatos.DataBind();
                ddlDatos.Items.Insert(0, new ListItem("--Seleccionar Especialidad--", "0"));
            }
            else if (ddlCriterio.SelectedItem.Value == "4")
            {
                btn_fecha_final.Visible = false;
                btn_fecha_inicial.Visible = false;
                lblReporte5.Visible = false;
                lblReporte6.Visible = false;
                lbl_fecha_final.Visible = false;
                lbl_fecha_inicial.Visible = false;
                ddlDatos.Visible = true;
                lblDato.Visible = true;
                ddlDatos.Items.Clear();


                SqlDataReader dr = reporte.getObrasSociales();
                ddlDatos.DataSource = dr;
                ddlDatos.DataTextField = "ObraSocial_Pac";
                ddlDatos.DataValueField = "RowNum";
                ddlDatos.DataBind();
                ddlDatos.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
            }
        }

        protected void ddlDatos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}