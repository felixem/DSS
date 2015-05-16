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
        Editar Entrega de Practica</h1>
    <div class="CentrarContenido" style="width: 450px;">
    <div class="ContenedorInterno">    
    <p class="style2">
    <div class="row_textbox_medium">
        Detalles de la practica
        </div>
    </p>
    <p class="style2">
    <div class="row_textbox_medium">
        Practica<asp:TextBox ID="TextBox_Nom" runat="server" CssClass="position_derecha_locked" ReadOnly="True"></asp:TextBox>
    </div>
    </p>
    <p class="style2">
    <div class="row_textbox_medium">
        Descripcion<asp:TextBox ID="TextBox_Desc" runat="server" CssClass="position_derecha_locked" ReadOnly="True"></asp:TextBox>
    </div>
    </p>
    <p class="style2">
    <div class="row_textbox_medium">
        Fecha Apertura
        <asp:TextBox ID="TextBox_Apertu" runat="server" CssClass="position_derecha_locked" ReadOnly="True"></asp:TextBox>
    </div>
    </p>
    <p class="style2">
    <div class="row_textbox_medium">
        Fecha Cierre
        <asp:TextBox ID="TextBox_Cierre" runat="server" CssClass="position_derecha_locked" ReadOnly="True"></asp:TextBox>
    </div>
    </p>
    <p class="style2">
    <div class="row_textbox_medium">
        Puntuación Máxima
        <asp:TextBox ID="TextBox_Punt" runat="server" CssClass="position_derecha_locked" ReadOnly="True"></asp:TextBox>
    </div>
    </p>
    <p class="style2">
    <div class="row_textbox_medium">
        Rellenar datos de la entrega
        </div>
    </p>
    <p class="style2">
    <div class="row_textbox_medium">
        <asp:Label runat="server" ID="StatusLabel" Font-Bold="True" ForeColor="Red" />
    </div>
    </p>
    <p class="style2">
    <div class="row_textbox_medium">
        <asp:FileUpload ID="FileUploadControl" runat="server" />
    </div>
    </p>
    <p class="style2">
    <div class="row_textbox_medium">
        Comentarios
        <asp:TextBox ID="TextBox_Comentario" CssClass="posicion_derecha" runat="server"></asp:TextBox>
    </div>
    </p>
    <p class="style2">
    <div class="row_textbox_medium">
        <asp:Button ID="Button_Modificar" runat="server" OnClick="Button_Modificar_Click" CssClass="posicion_izquierda" Text="Modificar Entrega"
            ValidationGroup="Registro" />
        &nbsp;
        <asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" CssClass="posicion_derecha" Text="Volver" />
        </div>
        </p>
        </div>
        </div>
</asp:Content>
