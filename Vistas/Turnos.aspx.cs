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
    public partial class WebForm1 : System.Web.UI.Page
    {

        NegocioTurno neg = new NegocioTurno();
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
                        DataTable tablaTurnos = neg.getTabla();
                        grdTurno.DataSource = tablaTurnos;
                        grdTurno.DataBind();
                        pnlProfesionales.Visible = false;
                        break;

                    case "Profesional":
                        DataTable tablaTurnosXProfesional = neg.getTablaTurnosPorMedicos(lblUsuario.Text);
                        grdTurno.DataSource = tablaTurnosXProfesional;
                        grdTurno.DataBind();
                        ocultarControles();
                        pnlProfesionales.Visible = true;
                        break;
                }
                

            }
        }

        protected void btnBuscar_Tur_Click(object sender, EventArgs e)
        {
            switch (lblTipoUsuario.Text)
            {
                case "Administrador":
                    DataTable tablaTurno = neg.getTablaTurno(txtBuscarTurno.Text);
                    grdTurno.DataSource = tablaTurno;
                    grdTurno.DataBind();
                    break;

                case "Profesional":
                    DataTable tablaTurnosXProfesional = neg.getTablaTurnosPorMedicos(txtBuscarTurno.Text);
                    grdTurno.DataSource = tablaTurnosXProfesional;
                    grdTurno.DataBind();
                    break;
            }

        }

        void ocultarControles()
        {
            HyperLink4.Visible = false;
            HyperLink5.Visible = false;
        }

        protected void grdTurno_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdTurno.EditIndex = e.NewEditIndex;
            grdTurno.DataSource = neg.getTabla();
            grdTurno.DataBind();
        }

        protected void grdTurno_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string aux_nroTurno = ((Label)grdTurno.Rows[e.RowIndex].FindControl("lbl_tur_nro")).Text;
            int nro = Int32.Parse(aux_nroTurno);
            neg.EliminarTurno(nro);
        }

        protected void grdTurno_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdTurno.EditIndex = -1;
            grdTurno.DataSource = neg.getTabla();
            grdTurno.DataBind();
        }
    }
}