<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="calificar.aspx.cs" Inherits="DSSGenNHibernate.EntregaAlumno.calificar" %>
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
    <h1>
        Calificar Entrega Alumno</h1>
    <p class="style2">
        CodEntrega
                <asp:TextBox ID="TextBox_Cod" runat="server" 
                    ReadOnly="True"></asp:TextBox>
    </p>
    <p class="style2">
        Nombre Alumno
                <asp:TextBox ID="TextBox_NomAlu" runat="server"
                    ReadOnly="True" Width="185px"></asp:TextBox>
            </p>
    <p class="style2">
        Apellidos Alumno
                <asp:TextBox ID="TextBox_ApeAlu" runat="server"
                    ReadOnly="True"></asp:TextBox>
            </p>
    <p class="style2">
        DNI
                <asp:TextBox ID="TextBox_Dni" runat="server"
                    ReadOnly="True"></asp:TextBox>
            </p>
    <p class="style2">
        Comentarios Alumno
                <asp:TextBox ID="TextBox_ComentAlu" runat="server"
                    ReadOnly="True" Width="685px"></asp:TextBox>
            </p>
    <p class="style2">
        Nota <asp:TextBox ID="TextBox_Nota" runat="server"></asp:TextBox>
    </p>
    <p class="style2">
        Corregido
        <asp:CheckBox ID="CheckBox_Corregido" runat="server" />
    </p>
    <p class="style2">
        Comentarios Profesor <asp:TextBox ID="TextBox_ComentProf" 
            runat="server" Width="679px"></asp:TextBox>
    </p>
    <p class="style2">
        &nbsp;Descargar Entrega
        <asp:Button ID="Button_descargar" runat="server" OnClick="Button_Descargar_Click" Text="Bajar Achivo" Width="130px" />
    </p>
    <p class="style2">
        <asp:Button ID="Button_Calificar" runat="server" OnClick="Button_Calificar_Click"
                Text="Calificar" ValidationGroup="Registro"  />
                &nbsp;
        <asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" Text="Volver"
                 /></p>
</asp:Content>
