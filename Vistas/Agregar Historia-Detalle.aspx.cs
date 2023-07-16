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
    public partial class Agregar_Historia_Detalle : System.Web.UI.Page
    {
        
        NegocioHistoriaClinica HC = new NegocioHistoriaClinica();
        NegocioDetalleHistoriaClinica DHC = new NegocioDetalleHistoriaClinica();
        NegocioEspecialidades espec = new NegocioEspecialidades();
        NegocioTurno tur = new NegocioTurno();
        NegocioProfesionales prof = new NegocioProfesionales();
        NegocioProfesionalesXEspecialidades pxe = new NegocioProfesionalesXEspecialidades();
        NegocioPaciente pac = new NegocioPaciente();

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {

                
                calTurno.Visible = false;
                lblFechaSeleccionada.Visible = false;
                ddlEspecialidad.Visible = false;
                ddlEspecialistas.Visible = false;
                btnVerCalendario.Visible = false;
                btn_Agregar_HC.Visible = false;
                lblValidarDni.Visible = false;
                hpDarAlta.Visible = false;
                btnApaso3.Visible = false;
                btnApaso4.Visible = false;
                btnApaso5.Visible = false;
                btnApaso6.Visible = false;
                hpReingresar.Visible = false;
                txtDiagnostico.Visible = false;
                txtMotivoConsulta.Visible = false;
            }

            if (Session["NombreUsuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            lblUsuario.Text = Session["NombreUsuario"].ToString();
            lblTipoUsuario.Text = Session["TipoUsuario"].ToString();
            lblPaso.Text = "1";
        }



        protected void btn_Agregar_HC_Click(object sender, EventArgs e)
        {
            Boolean estado1 = false;
            Boolean estado2 = false;

            int cod_Pac = HC.buscarCodPaciente(txt_DNI_Paciente.Text);

            int legajo = DHC.buscarLegajo(cod_Pac);
            string codEsp = ddlEspecialidad.SelectedItem.Value;
            string matricula = ddlEspecialistas.SelectedItem.Value;
            string motivoConsulta = txtMotivoConsulta.Text;
            string diagnostico = txtDiagnostico.Text;

            estado1 = HC.cargarHistoriaClinica(cod_Pac);

            lblmensaje.Text = legajo + matricula + codEsp + motivoConsulta + diagnostico;

            estado2 = DHC.cargarDetalleHistoriaClinica(legajo, matricula, codEsp, motivoConsulta, diagnostico, DateTime.Parse(lblFecha.Text));


            if (estado2 == true)
            { 
                lbl_mensaje_HC.Text = "HISTORIA CLINICA AGREGADA CON EXITO !!";
                limpiar();
                btn_Agregar_HC.Visible = false;
                hpReingresar.Visible = true;
            }
            else
            {
                lbl_mensaje_HC.Text = "No se pudo agregar";
            }
        }

        protected void btnVerCalendario_Click(object sender, EventArgs e)
        {
            calTurno.Visible = !calTurno.Visible;
        }

        protected void calTurno_SelectionChanged(object sender, EventArgs e)
        {
            lblFechaSeleccionada.Visible = true;
            lblFecha.Text = calTurno.SelectedDate.ToShortDateString();
        }

        protected void ddlEspecialidad_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlDataReader dr = espec.getEspecialidades();
                ddlEspecialidad.DataSource = dr;
                ddlEspecialidad.DataTextField = "Descripcion_Esp";
                ddlEspecialidad.DataValueField = "CodEspecialidad_Esp";
                ddlEspecialidad.DataBind();
                ddlEspecialidad.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
            }
        }

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            NegocioProfesionales prof = new NegocioProfesionales();

            string codEsp = ddlEspecialidad.SelectedItem.Value;

            SqlDataReader dr = prof.getProfesionales(codEsp);
            ddlEspecialistas.DataSource = dr;
            ddlEspecialistas.DataTextField = "Nombre_Pr";
            ddlEspecialistas.DataValueField = "Matricula_Pr";
            ddlEspecialistas.DataBind();
            ddlEspecialistas.Items.Insert(0, new ListItem("--Seleccionar--", "0"));

        }


        protected void btnApaso2_Click(object sender, EventArgs e)
        {
            string dni = txt_DNI_Paciente.Text;
            Session["DNIPaciente"] = txt_DNI_Paciente.Text;

            bool estado = pac.validarDNI(dni);

            if (estado == true)
            {
                ddlEspecialidad.Visible = true;
                btnApaso3.Visible = true;
                lblPaso.Text = "2";
                txt_DNI_Paciente.Enabled = false;
                lblValidarDni.Text = "";
                hpDarAlta.Visible = false;
                btnApaso2.Visible = false;

            }
            else
            {
                txt_DNI_Paciente.Enabled = true;
                lblValidarDni.Visible = true;
                lblValidarDni.Text = "El dni no existe, por favor vuelva a ingresar el DNI o de alta el paciente --->";
                hpDarAlta.Visible = true;
            }

        }

        protected void btnApaso3_Click(object sender, EventArgs e)
        {

            lblPaso.Text = "3";
            string especialidad = ddlEspecialidad.SelectedItem.ToString();
            Session["Especialidad"] = especialidad;

            string codEsp = ddlEspecialidad.SelectedItem.Value;
            btnApaso4.Visible = true;
            ddlEspecialistas.Visible = true;
            ddlEspecialidad.Enabled = false;
            btnApaso3.Visible = false;
        }

        protected void btnApaso4_Click(object sender, EventArgs e)
        {
            lblPaso.Text = "4";
            btnApaso4.Visible = false;
            ddlEspecialistas.Enabled = false;
            txtMotivoConsulta.Visible = true;
            btnApaso5.Visible = true;
            btnApaso4.Visible = false;
        }

        protected void btnApaso5_Click(object sender, EventArgs e)
        {
            lblPaso.Text = "5";
            txtDiagnostico.Visible = true;
            btnApaso6.Visible = true;
            txtMotivoConsulta.Enabled = false;
            btnApaso5.Visible = false;
            

        }

        protected void btnApaso6_Click(object sender, EventArgs e)
        {
            lblPaso.Text = "6";
            txtDiagnostico.Enabled = false;
            btnVerCalendario.Visible = true;
            btn_Agregar_HC.Visible = true;
            btnApaso6.Visible = false;


        }


        public void limpiar()
        {
            txt_DNI_Paciente.Text = "";
            lblFechaSeleccionada.Text = "";
            ddlEspecialidad.SelectedIndex = 0;
            ddlEspecialistas.SelectedIndex = 0;
            lblFecha.Text = "";
            txtDiagnostico.Text = "";
            txtMotivoConsulta.Text = "";
            calTurno.Visible = false;
            btnVerCalendario.Visible = false;
        }


    }
}