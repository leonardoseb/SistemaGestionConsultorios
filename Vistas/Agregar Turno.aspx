<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Agregar Turno.aspx.cs" Inherits="Vistas.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 971px;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style4 {
            width: 157px;
        }
        .auto-style6 {
            height: 23px;
            width: 157px;
        }
        .auto-style7 {
            width: 157px;
            height: 26px;
        }
        .auto-style8 {
            height: 26px;
        }
        .auto-style9 {
            width: 394px;
        }
        .auto-style10 {
            height: 23px;
            width: 394px;
        }
        .auto-style11 {
            width: 394px;
            height: 26px;
        }
        .auto-style12 {
            height: 3px;
            width: 157px;
        }
        .auto-style13 {
            height: 3px;
            width: 394px;
        }
        .auto-style14 {
            height: 3px;
        }
        .auto-style15 {
            height: 15px;
            width: 157px;
        }
        .auto-style16 {
            height: 15px;
            width: 394px;
        }
        .auto-style17 {
            height: 15px;
        }
        .auto-style18 {
            height: 5px;
            width: 157px;
        }
        .auto-style19 {
            height: 5px;
            width: 394px;
        }
        .auto-style20 {
            height: 5px;
        }
        .auto-style21 {
            height: 7px;
            width: 157px;
        }
        .auto-style22 {
            height: 7px;
            width: 394px;
        }
        .auto-style23 {
            height: 7px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server">
                Usuario Logueado:
                <asp:Label ID="lblUsuario" runat="server" Font-Bold="True"></asp:Label>
                <br />
                Tipo Usuario:
                <asp:Label ID="lblTipoUsuario" runat="server" Font-Bold="True"></asp:Label>
            </asp:Panel>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style21">
                    </td>
                <td class="auto-style22"></td>
                <td class="auto-style23"></td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Turnos.aspx">Volver a Turnos</asp:HyperLink>
                </td>
                <td class="auto-style9">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18"></td>
                <td class="auto-style19"></td>
                <td class="auto-style20"></td>
            </tr>
            <tr>
                <td class="auto-style4">AGREGAR TURNO
                    <br />
                    (PASO
                    <asp:Label ID="lblPaso" runat="server"></asp:Label>
&nbsp;de 5)</td>
                <td class="auto-style9">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12"></td>
                <td class="auto-style13">
                    </td>
                <td class="auto-style14"></td>
            </tr>
            <tr>
                <td class="auto-style6">PASO 1.</td>
                <td class="auto-style10">
                    </td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style7">Ingrese DNI del paciente:</td>
                <td class="auto-style11">
                    <asp:TextBox ID="txtDNIPac" runat="server" MaxLength="8"></asp:TextBox>
                &nbsp;&nbsp;
                    <asp:Button ID="btnApaso2" runat="server" Text="Siguiente paso" OnClick="btnApaso2_Click" Width="118px" ValidationGroup="validacionPaso1" />
                </td>
                <td class="auto-style8">
                    <asp:RegularExpressionValidator ID="revTxtDni" runat="server" ControlToValidate="txtDNIPac" Font-Bold="False" ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="validacionPaso1">Ingrese solo numeros.</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style7"></td>
                <td class="auto-style11">
                    <asp:Label ID="lblValidarDni" runat="server"></asp:Label>
&nbsp;<asp:HyperLink ID="hpDarAlta" runat="server" NavigateUrl="~/Agregar Paciente.aspx">ALTA DE PACIENTE</asp:HyperLink>
                </td>
                <td class="auto-style8"></td>
            </tr>
            <tr>
                <td class="auto-style7">PASO 2.</td>
                <td class="auto-style11">
                </td>
                <td class="auto-style8">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">Seleccionar especialidad:</td>
                <td class="auto-style11">
                    <asp:DropDownList ID="ddlEspecialidad" runat="server" Height="22px" OnLoad="ddlEspecialidad_Load" Width="128px" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Button ID="btnApaso3" runat="server" Text="Siguiente paso" OnClick="btnApaso3_Click" Width="118px" ValidationGroup="validacionPaso2" />
                </td>
                <td class="auto-style8">
                    <asp:CompareValidator ID="cvEspecialidad" runat="server" ControlToValidate="ddlEspecialidad" ForeColor="Red" Operator="NotEqual" ValidationGroup="validacionPaso2" ValueToCompare="0">Seleccione una especialidad</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style15"></td>
                <td class="auto-style16">
                    </td>
                <td class="auto-style17"></td>
            </tr>
            <tr>
                <td class="auto-style7">PASO 3.</td>
                <td class="auto-style11">
                </td>
                <td class="auto-style8">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">Seleccionar especialista:</td>
                <td class="auto-style11">
                    <asp:DropDownList ID="ddlEspecialistas" runat="server" Height="22px" Width="128px">
                    </asp:DropDownList>
                    <asp:Button ID="btnApaso4" runat="server" Text="Siguiente paso" OnClick="btnApaso4_Click" Width="118px" ValidationGroup="validacionPaso3" />
                </td>
                <td class="auto-style8">
                    <asp:CompareValidator ID="cvEspecialista" runat="server" ControlToValidate="ddlEspecialistas" ForeColor="Red" Operator="NotEqual" ValidationGroup="validacionPaso3" ValueToCompare="0">Seleccione un especialista</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style15"></td>
                <td class="auto-style16">
                    </td>
                <td class="auto-style17"></td>
            </tr>
            <tr>
                <td class="auto-style7">PASO 4.</td>
                <td class="auto-style11">
                    &nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="lblFechaSeleccionada" runat="server" Text="Fecha seleccionada: "></asp:Label>
                    </td>
                <td class="auto-style11">
                    <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
                    <asp:Label ID="lblFecha" runat="server"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnApaso5" runat="server" OnClick="btnApaso5_Click" Text="Siguiente paso" ValidationGroup="validacionPaso4" />
                </td>
                <td class="auto-style8">
                    <asp:RequiredFieldValidator ID="rfvCalendar" runat="server" ControlToValidate="txtFecha" ForeColor="Red" ValidationGroup="validacionPaso4">Seleccione una fecha.</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="lblSeleccionarFecha" runat="server" Text="Seleccionar fecha:"></asp:Label>
                </td>
                <td class="auto-style11">
                    <asp:Button ID="btnVerCalendario" runat="server" Text="Ver calendario" OnClick="btnVerCalendario_Click" />
                    <br />
                </td>
                <td class="auto-style8">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style11">
                    <asp:Calendar ID="calTurno" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" OnSelectionChanged="calTurno_SelectionChanged" Width="220px" OnDayRender="calTurno_DayRender">
                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                        <WeekendDayStyle BackColor="#CCCCFF" />
                    </asp:Calendar>
                </td>
                <td class="auto-style8">
                    <asp:ValidationSummary ID="vsConfirmarTurno" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style15"></td>
                <td class="auto-style16">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td class="auto-style17"></td>
            </tr>
            <tr>
                <td class="auto-style7">PASO 5.</td>
                <td class="auto-style11">
                    &nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7"></td>
                <td class="auto-style11">
                    <asp:Label ID="lblTituloDatos" runat="server">DATOS DEL TURNO</asp:Label>
                </td>
                <td class="auto-style8"></td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style11">
                    <asp:Label ID="lblDatosTurno" runat="server"></asp:Label>
                </td>
                <td class="auto-style8">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style9">
                    <asp:Button ID="btnAgregarTurno" runat="server" Text="Confirmar turno" OnClick="btnAgregarTurno_Click" OnClientClick="return confirm('Confirmar turno?');" />
                    <br />
                    <br />
                    <asp:Label ID="lblMensajeTur" runat="server"></asp:Label>
                    <br />
                    <br />
                    <asp:HyperLink ID="hpReingresar" runat="server" NavigateUrl="~/Agregar Turno.aspx">Ingresar otro turno</asp:HyperLink>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
    </form>
</body>
</html>
