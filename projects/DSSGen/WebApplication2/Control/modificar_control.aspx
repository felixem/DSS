<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="modificar_control.aspx.cs" Inherits="DSSGenNHibernate.Control.modificar_control" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="../Styles/submenu/login.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/utilities/tabla_dos_columnas.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style2
        {
            color: #000000;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1 class="style2">
        Modificar Control</h1>
    <p class="style2">
        Nombre<asp:TextBox ID="TextBox_Nom" runat="server"></asp:TextBox>
    </p>
    <p class="style2">
        Descripcion<asp:TextBox ID="TextBox_Desc" runat="server"></asp:TextBox>
    </p>
    <p class="style2">
        Apertura (MM/DD/AAAA)<asp:TextBox ID="TextBox_Apertura" runat="server"></asp:TextBox>
    </p>
    <p class="style2">
        Cierre (MM/DD/AAAA)<asp:TextBox ID="TextBox_Cierre" runat="server"></asp:TextBox>
    </p>
    <p class="style2">
        Duracion (int)<asp:TextBox ID="TextBox_Duracion" runat="server"></asp:TextBox>
    </p>
    <p class="style2">
        Puntuacion (float)<asp:TextBox ID="TextBox_PuntMax" runat="server"></asp:TextBox>
    </p>
    <p class="style2">
        Penalizacion (float)<asp:TextBox ID="TextBox_Penalizacion" runat="server"></asp:TextBox>
    </p>
    <p class="style2">
        <asp:Button ID="Button_ModificarControl" runat="server" OnClick="Button_Modificar_Click"
                Text="Modificar" ValidationGroup="Registro"  />
                &nbsp;
        <asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" Text="Volver"
                 /></p>
</asp:Content>
