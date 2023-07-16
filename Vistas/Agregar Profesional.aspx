    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Agregar Profesional.aspx.cs" Inherits="Vistas.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style2 {
            height: 23px;
        }
        .auto-style3 {
            height: 30px;
        }
        .auto-style4 {
            width: 202px;
        }
        .auto-style5 {
            height: 23px;
            width: 202px;
        }
        .auto-style6 {
            height: 30px;
            width: 202px;
        }
        .auto-style7 {
            width: 202px;
            height: 26px;
        }
        .auto-style8 {
            height: 26px;
        }
        .auto-style9 {
            width: 202px;
            height: 24px;
        }
        .auto-style10 {
            height: 24px;
        }
        .auto-style11 {
            width: 100%;
            height: 400px;
        }
        .auto-style12 {
            width: 202px;
            height: 56px;
        }
        .auto-style13 {
            height: 56px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style11">
                <tr>
                    <td>
        <table class="auto-style11">
            <tr>
                <td class="auto-style4">
                    Usuario Logueado: 
                    <asp:Label ID="lblUsuario" runat="server" Font-Bold="True"></asp:Label>
                        <br />
                        Tipo Usuario:
                        <asp:Label ID="lblTipoUsuario" runat="server" Font-Bold="True"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Profesionales.aspx">volver a Gestion de Profesionales</asp:HyperLink>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">ALTA DE PROFESIONAL</td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style8">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7" aria-disabled="False" aria-selected="undefined">Matricula:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtNumMatricula" runat="server" MaxLength="5"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtNumMatricula">Ingrese una matricula.</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">DNI:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; </td>
                <td>
                    <asp:TextBox ID="txtDNI_Pr" runat="server" MaxLength="8"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDNI_Pr">Ingrese un DNI.</asp:RequiredFieldValidator>
&nbsp;&nbsp;
                    <asp:RegularExpressionValidator ID="revTxtDni" runat="server" ControlToValidate="txtDNI_Pr" Font-Bold="False" ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="validacionPaso1">Ingrese solo numeros.</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Nombre:&nbsp;&nbsp;
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtNombre_Pr" runat="server" MaxLength="15"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre_Pr">Ingrese un nombre.</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Apellido:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; </td>
                <td>
                    <asp:TextBox ID="txtApellido_Pr" runat="server" style="margin-bottom: 0px" MaxLength="15"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtApellido_Pr">Ingrese un apellido.</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Especialidad:</td>
                <td class="auto-style3">
                    <asp:DropDownList ID="ddlEspecialidades" runat="server" OnLoad="ddlEspecialidades_Load">
                    </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:CompareValidator ID="cvEspecialidad" runat="server" ControlToValidate="ddlEspecialidades" ForeColor="Red" Operator="NotEqual" ValueToCompare="0">Seleccione una especialidad.</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; </td>
                <td class="auto-style10">
                    <asp:TextBox ID="txtEmail_Pr" runat="server" MaxLength="25"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtEmail_Pr">Ingrese un email.</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Telefono:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; </td>
                <td>
                    <asp:TextBox ID="txtTelefono_Pr" runat="server" MaxLength="25"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTelefono_Pr">Ingrese un telefono.</asp:RequiredFieldValidator>
&nbsp;&nbsp;
                    <asp:RegularExpressionValidator ID="revTxtDni0" runat="server" ControlToValidate="txtTelefono_Pr" Font-Bold="False" ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="validacionPaso1">Ingrese solo numeros.</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
   &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">
                    </td>
                <td class="auto-style13">
                    <asp:Button ID="btnAgregar_Pr" runat="server" Height="27px" Text="Agregar" OnClick="btnAgregar_Pr_Click" />
                    <br />
                    <asp:Label ID="lblMensajePr" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
