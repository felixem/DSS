<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="detalles_entrega_alumno.aspx.cs" Inherits="DSSGenNHibernate.EntregaAlumno.detalles_entrega_alumno" %>

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
        Detalles de la Entrega de Practica</h1>
    <p class="style2">
        Detalles de la practica
    </p>
    <p class="style2">
        Practica<asp:TextBox ID="TextBox_Nom" runat="server" ReadOnly="True"></asp:TextBox>
    </p>
    <p class="style2">
        Descripcion<asp:TextBox ID="TextBox_Desc" runat="server" ReadOnly="True"></asp:TextBox>
    </p>
    <p class="style2">
        Fecha Apertura
        <asp:TextBox ID="TextBox_Apertu" runat="server" ReadOnly="True"></asp:TextBox>
    </p>
    <p class="style2">
        Fecha Cierre
        <asp:TextBox ID="TextBox_Cierre" runat="server" ReadOnly="True"></asp:TextBox>
    </p>
    <p class="style2">
        Puntuación Máxima
        <asp:TextBox ID="TextBox_Punt" runat="server" ReadOnly="True"></asp:TextBox>
    </p>
    <p class="style2">
        Detalles específicos de tu entrega
    </p>
    <p class="style2">
        Tus Comentarios
        <asp:TextBox ID="TextBox_ComentarioAlumno" runat="server" ReadOnly="True"></asp:TextBox>
    </p>
    <p class="style2">
        Nombre del archivo
        <asp:TextBox ID="TextBox_NombreArchivo" runat="server" ReadOnly="True"></asp:TextBox>
        <asp:Button ID="Button_Descargar" runat="server" OnClick="Button_Descargar_Click" Text="Descargar" />
    </p>
    <p class="style2">
        Corregido
        <asp:Image ID="Img_Corregido" runat="server"></asp:Image>
    </p>
    <p class="style2">
        Nota
        <asp:TextBox ID="TextBox_Nota" runat="server" ReadOnly="True"></asp:TextBox>
    </p>
    <p class="style2">
        Comentarios del Profesor
        <asp:TextBox ID="TextBox_ComentarioProfesor" ReadOnly="True" runat="server"></asp:TextBox>
    </p>
    <p class="style2">
        <asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" Text="Volver" /></p>
</asp:Content>
