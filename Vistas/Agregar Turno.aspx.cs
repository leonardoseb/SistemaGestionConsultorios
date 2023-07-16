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
    public partial class WebForm4 : System.Web.UI.Page
    {
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
                ocultarControles();
            }

            if (Session["NombreUsuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            lblUsuario.Text = Session["NombreUsuario"].ToString();
            lblTipoUsuario.Text = Session["TipoUsuario"].ToString();
            lblPaso.Text = "1";

        }

        protected void btnVerCalendario_Click(object sender, EventArgs e)
        {
            calTurno.Visible = !calTurno.Visible;
            lblPaso.Text = "4";
        }

        protected void calTurno_SelectionChanged(object sender, EventArgs e)
        {
            lblFechaSeleccionada.Visible = true;
            lblFecha.Text = calTurno.SelectedDate.ToShortDateString();
            lblFechaSeleccionada.Visible = true;
            btnApaso5.Visible = true;
            lblPaso.Text = "4";
            txtFecha.Enabled = false;
            txtFecha.Text = lblFecha.Text;
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

        protected void btnAgregarTurno_Click(object sender, EventArgs e)
        {
            Boolean estado = false;

            string codEsp = ddlEspecialidad.SelectedItem.Value;
            string matricula = ddlEspecialistas.SelectedItem.Value;
            int codPaciente = tur.buscarCodPaciente(txtDNIPac.Text);
            string numConsultorio = tur.buscarConsultorio(codEsp);

            estado = tur.agregarTurno(matricula, codEsp, numConsultorio, codPaciente, DateTime.Parse(lblFecha.Text), true);

            if (estado == true)
            {
                lblMensajeTur.Text = "TURNO AGREGADO CON EXITO !!";
                limpiar();
                btnAgregarTurno.Visible = false;
                hpReingresar.Visible = true;
                lblFechaSeleccionada.Visible = true;
                lblFecha.Visible = true;
            }
            else
            {
                lblMensajeTur.Text = "No se pudo agregar, datos faltantes";
            }
        }


        protected void btnApaso2_Click(object sender, EventArgs e)
        {
            string dni = txtDNIPac.Text;

            bool estado = pac.validarDNI(dni);
 
            if (estado == true)
            {
                ddlEspecialidad.Visible = true;
                btnApaso3.Visible = true;
                lblPaso.Text = "2";
                txtDNIPac.Enabled = false;
                lblValidarDni.Text = "";
                hpDarAlta.Visible = false;
                btnApaso2.Visible = false;
            }
            else
            {
                txtDNIPac.Enabled = true;
                lblValidarDni.Visible = true;
                lblValidarDni.Text = "El dni no existe, por favor vuelva a ingresar el DNI o de alta el paciente --->";
                hpDarAlta.Visible = true;
            }
        }

        protected void btnApaso3_Click(object sender, EventArgs e)
        {

            lblPaso.Text = "3";
            btnApaso4.Visible = true;
            ddlEspecialistas.Visible = true;
            ddlEspecialidad.Enabled = false;
            btnApaso3.Visible = false;
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

        protected void btnApaso4_Click(object sender, EventArgs e)
        {
            lblPaso.Text = "4";
            btnApaso4.Visible = false;
            ddlEspecialistas.Enabled = false;
            btnVerCalendario.Visible = true;
            btnApaso5.Visible = false;
        }

        protected void btnApaso5_Click(object sender, EventArgs e)
        {
            completarLabelDatosTurno();
            lblPaso.Text = "5";
            btnAgregarTurno.Visible = true;
            btnVerCalendario.Visible = false;
            calTurno.Visible = false;
            lblSeleccionarFecha.Visible = false;
            btnApaso5.Visible = false;

        }


        protected void calTurno_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < System.DateTime.Today)
            {
                e.Day.IsSelectable = false;
            }

            if (e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
            {
                e.Day.IsSelectable = false;
            }

        }


        // FUNCIONES 

        public void limpiar()
        {
            txtDNIPac.Text = "";
            lblFechaSeleccionada.Text = "";
            ddlEspecialidad.SelectedIndex = 0;
            ddlEspecialistas.SelectedIndex = 0;
            lblFecha.Text = "";
            calTurno.Visible = false;
            btnVerCalendario.Visible = false;
        }

        void ocultarControles()
        {
            calTurno.Visible = false;
            lblFechaSeleccionada.Visible = false;
            ddlEspecialidad.Visible = false;
            ddlEspecialistas.Visible = false;
            btnVerCalendario.Visible = false;
            btnAgregarTurno.Visible = false;
            lblValidarDni.Visible = false;
            hpDarAlta.Visible = false;
            btnApaso3.Visible = false;
            btnApaso4.Visible = false;
            btnApaso5.Visible = false;
            hpReingresar.Visible = false;
            lblTituloDatos.Visible = false;
            txtFecha.Visible = false;
        }


        void completarLabelDatosTurno()
        {
            lblDatosTurno.Text += "DNI DEL PACIENTE: " + txtDNIPac.Text + "</br>";
            lblDatosTurno.Text += "NOMBRE Y APELLIDO DEL PACIENTE: " + pac.ObtenerDatosPaciente(txtDNIPac.Text) + "</br>";
            lblDatosTurno.Text += "ESPECIALIDAD: " + ddlEspecialidad.SelectedItem.ToString() + "</br>";
            lblDatosTurno.Text += "MEDICO: " + ddlEspecialistas.SelectedItem.ToString() + "</br>";
            lblDatosTurno.Text += "FECHA: " + lblFecha.Text + "</br>"; 
            lblDatosTurno.Text += "Nro CONSULTORIO: " + tur.buscarConsultorio(ddlEspecialidad.SelectedItem.Value) + "</br>";
        }
    }
}