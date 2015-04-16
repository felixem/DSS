<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="crear_asignaturaanyo.aspx.cs" Inherits="DSSGenNHibernate.AsignaturaAnyo.crear_asignaturaanyo" %>

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
        Vincular Asignatura con Año Académico</h1>
    <div class="CentrarContenido">
        <div class="ContenedorInternoNoPanel">
            <p class="style2">
                Rellene los siguientes campos</p>
            <div class="row_crear_alumno">
                <asp:Label ID="Label_Anyo" runat="server" Text="Año académico" CssClass="posicion_izquierda"></asp:Label>
                <asp:DropDownList ID="DropDownList_Anyos" runat="server" CssClass="posicion_derecha" OnSelectedIndexChanged="DropDownList_Anyos_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
            </div>
            <div class="row_crear_alumno">
                <asp:Label ID="Label_Asignatura" runat="server" Text="Asignatura" CssClass="posicion_izquierda"></asp:Label>
                <asp:DropDownList ID="DropDownList_Asignaturas" runat="server" CssClass="posicion_derecha">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row_crear_alumno_buttons">
            <asp:Button ID="Button_Crear" runat="server" OnClick="Button_Crear_Click"
                Text="Crear" ValidationGroup="Vincular" CssClass="posicion_izquierda" />
            <asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" Text="Volver"
                CssClass="posicion_central" />
        </div>
    </div>
</asp:Content>
