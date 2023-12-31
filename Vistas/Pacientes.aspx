﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pacientes.aspx.cs" Inherits="Vistas.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            height: 23px;
            width: 320px;
        }
        .auto-style4 {
            width: 320px;
        }
        .auto-style7 {
            height: 43px;
            width: 320px;
        }
        .auto-style8 {
            height: 45px;
            width: 320px;
        }
        .auto-style9 {
            margin-left: 400px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3">
                    Usuario Logueado: 
                    <asp:Label ID="lblUsuario" runat="server" Font-Bold="True"></asp:Label>
                        <br />
                        Tipo Usuario:
                        <asp:Label ID="lblTipoUsuario" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Turnos.aspx">Gestion de turnos</asp:HyperLink>
                    </td>
                    <td class="auto-style3">
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Profesionales.aspx">Gestion de profesionales</asp:HyperLink>
                    </td>
                    <td class="auto-style3">
                        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Pacientes.aspx">Gestion de pacientes</asp:HyperLink>
                    </td>
                    <td class="auto-style3">
                        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/HistoriasClinicas.aspx">Historias Clinicas</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">
                        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Reportes.aspx">Reportes</asp:HyperLink>
                    </td>
                    <td class="auto-style8"></td>
                    <td class="auto-style8"></td>
                    <td class="auto-style8"></td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Agregar Paciente.aspx">Agregar Paciente</asp:HyperLink>
                    </td>
                    <td class="auto-style7">
                        &nbsp;</td>
                    <td class="auto-style7"></td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        &nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
            </table>
        </div>
        Ingrese DNI del paciente :
                        <asp:TextBox ID="txtBuscarDNI_Pac" runat="server" Width="128px"></asp:TextBox>
&nbsp;&nbsp;<asp:Button ID="btnBuscar_Pac" runat="server" Text="Buscar" OnClick="btnBuscar_Pac_Click" ValidationGroup="validaerDNI" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtBuscarDNI_Pac" ForeColor="Red" ValidationExpression="^\d+$">Solo se permite ingresar numeros</asp:RegularExpressionValidator>
        .&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBuscarDNI_Pac" ValidationGroup="validaerDNI">Porfavor, ingrese un DNI.</asp:RequiredFieldValidator>
                    <br />
        <div class="auto-style9">
        </div>
        <br />
        Listado de pacientes: 
        <br />
        <asp:GridView ID="grdPacientes" runat="server" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" OnRowDeleting="grdPacientes_RowDeleting" OnRowCancelingEdit="grdPacientes_RowCancelingEdit" OnRowEditing="grdPacientes_RowEditing" OnRowUpdating="grdPacientes_RowUpdating" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
            <Columns>
                <asp:TemplateField HeaderText="COD PACIENTE">
                    <EditItemTemplate>
                        <asp:Label ID="lbl_eit_codpaciente" runat="server" Text='<%# Bind("CodPaciente_Pac") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_codpaciente" runat="server" Text='<%# Bind("CodPaciente_Pac") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DNI ">
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_dni" runat="server" Text='<%# Bind("DNI_Pac") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_dni" runat="server" Text='<%# Bind("DNI_Pac") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="NOMBRE ">
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_nombre" runat="server" Text='<%# Bind("Nombre_Pac") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_nombre" runat="server" Text='<%# Bind("Nombre_Pac") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="APELLIDO">
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_apellido" runat="server" Text='<%# Bind("Apellido_Pac") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_apellido" runat="server" Text='<%# Bind("Apellido_Pac") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="OBRA SOCIAL">
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_obrasocial" runat="server" Text='<%# Bind("ObraSocial_Pac") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_obrasocial" runat="server" Text='<%# Bind("ObraSocial_Pac") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DIRECCION">
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_direccion" runat="server" Text='<%# Bind("Direccion_Pac") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_direccion" runat="server" Text='<%# Bind("Direccion_Pac") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="EMAIL">
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_email" runat="server" Text='<%# Bind("Email_Pac") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_email" runat="server" Text='<%# Bind("Email_Pac") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TELEFONO">
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_telefono" runat="server" Text='<%# Bind("Telefono_Pac") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_telefono" runat="server" Text='<%# Bind("Telefono_Pac") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ESTADO">
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_estado" runat="server" Text='<%# Bind("Estado_Pac") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_estado" runat="server" Text='<%# Bind("Estado_Pac") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        <br />
        <br />
        <br />
        &nbsp;&nbsp;
        <br />
        <br />
        <br />
        &nbsp;&nbsp;
        <br />
        <br />
    </form>
</body>
</html>
