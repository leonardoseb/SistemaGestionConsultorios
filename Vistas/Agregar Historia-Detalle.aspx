<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Agregar Historia-Detalle.aspx.cs" Inherits="Vistas.Agregar_Historia_Detalle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style35 {
            width: 100%;
            height: 400px;
        }
        .auto-style36 {
            width: 252px;
        }
        .auto-style37 {
            width: 252px;
            height: 28px;
        }
        .auto-style38 {
            height: 28px;
            width: 364px;
        }
        .auto-style39 {
            width: 252px;
            height: 23px;
        }
        .auto-style40 {
            height: 23px;
            width: 364px;
        }
        .auto-style41 {
            width: 252px;
            height: 26px;
        }
        .auto-style42 {
            height: 26px;
            width: 364px;
        }
        .auto-style43 {
            width: 364px;
        }
    </style>
</head>
<body style="width: 520px; height: 280px">
    <form id="form1" runat="server">
            <table class="auto-style35">
                <tr>
                    <td class="auto-style36">Usuario Logueado: 
                    <asp:Label ID="lblUsuario" runat="server" Font-Bold="True"></asp:Label>
                        <br />
                        Tipo Usuario:
                        <asp:Label ID="lblTipoUsuario" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                    <td class="auto-style43">&nbsp;</td>
                    <td class="auto-style43">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style36">&nbsp;</td>
                    <td class="auto-style43">&nbsp;</td>
                    <td class="auto-style43">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style36">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/HistoriasClinicas.aspx">Volver a Gestion de Historias Clinicas</asp:HyperLink>
                    </td>
                    <td class="auto-style43">&nbsp;</td>
                    <td class="auto-style43">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style36">&nbsp;</td>
                    <td class="auto-style43">&nbsp;</td>
                    <td class="auto-style43">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style36">AGREGAR HISTORIA CLINICA<br />
                    (PASO
                    <asp:Label ID="lblPaso" runat="server"></asp:Label>
&nbsp;de 6)</td>
                    <td class="auto-style43">&nbsp;</td>
                    <td class="auto-style43">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style36">&nbsp;</td>
                    <td class="auto-style43">&nbsp;</td>
                    <td class="auto-style43">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style36">Ingrese DNI Paciente:</td>
                    <td class="auto-style43">
                        <asp:TextBox ID="txt_DNI_Paciente" runat="server" ></asp:TextBox>
                    <asp:Button ID="btnApaso2" runat="server" Text="Siguiente paso" OnClick="btnApaso2_Click" Width="118px" />
                        <br />
                    <asp:Label ID="lblValidarDni" runat="server"></asp:Label>
                        <asp:HyperLink ID="hpDarAlta" runat="server" NavigateUrl="~/Agregar Paciente.aspx">ALTA DE PACIENTE</asp:HyperLink>
                    </td>
                    <td class="auto-style43">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style36">Seleccionar especialidad:</td>
                    <td class="auto-style43">
                    <asp:DropDownList ID="ddlEspecialidad" runat="server" Height="22px" OnLoad="ddlEspecialidad_Load" Width="128px" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Button ID="btnApaso3" runat="server" Text="Siguiente paso" OnClick="btnApaso3_Click" Width="118px" />
                    </td>
                    <td class="auto-style43">
                        <asp:CompareValidator ID="cvEspecialidad" runat="server" ControlToValidate="ddlEspecialidad" ForeColor="Red" ValidationGroup="validacionPaso2" ValueToCompare="0">Seleccione una especialidad</asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style39">Seleccionar especialista:</td>
                    <td class="auto-style40">
                    <asp:DropDownList ID="ddlEspecialistas" runat="server" Height="22px" Width="128px">
                    </asp:DropDownList>
                    <asp:Button ID="btnApaso4" runat="server" Text="Siguiente paso" OnClick="btnApaso4_Click" Width="118px" />
                    </td>
                    <td class="auto-style40">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style41">Motivo de la consulta:</td>
                    <td class="auto-style42">
                        <asp:TextBox ID="txtMotivoConsulta" runat="server"></asp:TextBox>
                        <asp:Button ID="btnApaso5" runat="server" OnClick="btnApaso5_Click" Text="Siguiente paso" Width="118px" />
                    </td>
                    <td class="auto-style42">
                    </td>
                </tr>
                <tr>
                    <td class="auto-style41">Diagnostico:</td>
                    <td class="auto-style42">
                        <asp:TextBox ID="txtDiagnostico" runat="server"></asp:TextBox>
                        <asp:Button ID="btnApaso6" runat="server" OnClick="btnApaso6_Click" Text="Siguiente paso" Width="118px" />
                    </td>
                    <td class="auto-style42">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style36">Fecha de consulta:</td>
                    <td class="auto-style43">
                    <asp:Button ID="btnVerCalendario" runat="server" Text="Ver calendario" OnClick="btnVerCalendario_Click" />
                    <asp:Calendar ID="calTurno" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" OnSelectionChanged="calTurno_SelectionChanged" Width="220px">
                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                        <WeekendDayStyle BackColor="#CCCCFF" />
                    </asp:Calendar>
                    <asp:Label ID="lblFechaSeleccionada" runat="server" Text="Fecha seleccionada: "></asp:Label>
                    <asp:Label ID="lblFecha" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style43">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style36">
                        <asp:Label ID="lblmensaje" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style43">
                        <asp:Button ID="btn_Agregar_HC" runat="server" OnClick="btn_Agregar_HC_Click" Text="Crear Historia Clinica" Height="26px" />
                    </td>
                    <td class="auto-style43">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style36">&nbsp;</td>
                    <td class="auto-style43">
                        &nbsp;</td>
                    <td class="auto-style43">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style36">&nbsp;</td>
                    <td class="auto-style43">
                        <asp:Label ID="lbl_mensaje_HC" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style43">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style36">&nbsp;</td>
                    <td class="auto-style43">
                        &nbsp;</td>
                    <td class="auto-style43">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style37">&nbsp;</td>
                    <td class="auto-style38">
                    <asp:HyperLink ID="hpReingresar" runat="server" NavigateUrl="~/Agregar Historia-Detalle.aspx">Ingresar otra historia clinica</asp:HyperLink>
                    </td>
                    <td class="auto-style38">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style36">&nbsp;</td>
                    <td class="auto-style43">
                        &nbsp;</td>
                    <td class="auto-style43">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style36">&nbsp;</td>
                    <td class="auto-style43">
                        &nbsp;</td>
                    <td class="auto-style43">
                        &nbsp;</td>
                </tr>
            </table>
    </form>
</body>
</html>
