<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="crear_control.aspx.cs" Inherits="DSSGenNHibernate.Control.crear_control" %>

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
        Crear Control</h1>
    <p class="style2">
        Nombre<asp:TextBox ID="TextBox_NomControl" runat="server"></asp:TextBox>
    </p>
    <p class="style2">
        Descripcion<asp:TextBox ID="TextBox_DescControl" runat="server"></asp:TextBox>
    </p>
    <p class="style2">
        Apertura (MM/DD/AAAA)<asp:TextBox ID="TextBox_ApertuControl" runat="server"></asp:TextBox>
    </p>
    <p class="style2">
        Cierre (MM/DD/AAAA)<asp:TextBox ID="TextBox_CierreControl" runat="server"></asp:TextBox>
    </p>
    <p class="style2">
        Duracion (int)<asp:TextBox ID="TextBox_DuraciControl" runat="server"></asp:TextBox>
    </p>
    <p class="style2">
        Puntuacion (float)<asp:TextBox ID="TextBox_PuntControl" runat="server"></asp:TextBox>
    </p>
    <p class="style2">
        Penalizacion (float)<asp:TextBox ID="TextBox_PenaControl" runat="server"></asp:TextBox>
    </p>
    <p class="style2">
        Sistema Evaluacion (int)<asp:TextBox ID="TextBox_SistemEvaControl" runat="server"></asp:TextBox>
    </p>
    <p class="style2">
        <asp:Button ID="Button_RegControl" runat="server" OnClick="Button_RegControl_Click" Text="Crear"
                ValidationGroup="Registro" CssClass="posicion_izquierda" />
    </p>
</asp:Content>