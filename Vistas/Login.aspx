<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vistas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 153px;
        }
        .auto-style3 {
            width: 153px;
            height: 26px;
        }
        .auto-style4 {
            height: 26px;
        }
        .auto-style5 {
            width: 153px;
            height: 118px;
        }
        .auto-style6 {
            height: 118px;
        }
        .auto-style7 {
            width: 153px;
            height: 56px;
        }
        .auto-style8 {
            height: 56px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Ingreso al sistema</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Usuario:</td>
                    <td>
                        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Contraseña:</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        </td>
                    <td class="auto-style8">
                        <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" Width="105px" Height="29px" />
                        <br />
                        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <br />
                        USUARIO ADMIN<br />
                        usuario: admin<br />
                        contraseña: 1234<br />
                        <br />
                        USUARIO PROFESIONAL<br />
                        usuario: Nro Matricula<br />
                        contraseña: 1234</td>
                    <td class="auto-style6">
                        &nbsp;&nbsp;&nbsp;
                        &nbsp;<br />
                        <br />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
