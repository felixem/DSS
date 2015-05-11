<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="editar_entrega.aspx.cs" Inherits="DSSGenNHibernate.EntregaAlumno.editar_entrega" %>

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
        Realizar Entrega de Practica</h1>
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
        Rellenar datos de la entrega
    </p>
    <p class="style2">
        <asp:Label runat="server" ID="StatusLabel" Text="" />
    </p>
    <p class="style2">
        <asp:FileUpload ID="FileUploadControl" runat="server" />
    </p>
    <p class="style2">
        Comentarios
        <asp:TextBox ID="TextBox_Comentario" runat="server"></asp:TextBox>
    </p>
    <p class="style2">
        <asp:Button ID="Button_Modificar" runat="server" OnClick="Button_Modificar_Click" Text="Modificar Entrega"
            ValidationGroup="Registro" />
        &nbsp;
        <asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" Text="Volver" /></p>
</asp:Content>
