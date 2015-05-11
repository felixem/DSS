<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="detalles_entrega_alumno.aspx.cs" Inherits="DSSGenNHibernate.EntregaAlumno.detalles_entrega_alumno" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="../Styles/submenu/login.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/utilities/tabla_dos_columnas.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/utilities/centrar_contenido.css" rel="stylesheet" 
        type="text/css" />
    <style type="text/css">
        .style2
        {
            color: #000000;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="CentrarContenido" style="width: 450px;">
    <div class="ContenedorInterno">
    <h1>
        Detalles de la Entrega de Practica</h1>
    <div style="margin:10px;">
        Detalles de la practica
    </div>
    <div class="row_textbox_medium">
        <div class="posicion_izquierda">Practica</div>
        <asp:TextBox CssClass="position_derecha_locked" ID="TextBox_Nom" runat="server" ReadOnly="True"></asp:TextBox>
    </div>
    <div class="row_textbox_medium">
        <div class="posicion_izquierda">Descripcion</div>
        <asp:TextBox ID="TextBox_Desc" runat="server" CssClass="position_derecha_locked" ReadOnly="True"></asp:TextBox>
    </div>
    <div class="row_textbox_medium">
        <div class="posicion_izquierda">Fecha Apertura</div>
        <asp:TextBox ID="TextBox_Apertu" runat="server" CssClass="position_derecha_locked" ReadOnly="True"></asp:TextBox>
    </div>
    <div class="row_textbox_medium">
        <div class="posicion_izquierda">Fecha Cierre</div>
        <asp:TextBox ID="TextBox_Cierre" runat="server" CssClass="position_derecha_locked" ReadOnly="True"></asp:TextBox>
    </div>
    <div class="row_textbox_medium">
        <div class="posicion_izquierda">Puntuación Máxima</div>
        <asp:TextBox ID="TextBox_Punt" runat="server" CssClass="position_derecha_locked" ReadOnly="True"></asp:TextBox>
    </div>
    <div class="row_textbox_medium">
        <div class="posicion_izquierda">Detalles específicos de tu entrega</div>
    </div>
    <div class="row_textbox_medium">
        <div class="posicion_izquierda">Tus Comentarios</div>
        <asp:TextBox ID="TextBox_ComentarioAlumno" runat="server" CssClass="position_derecha_locked" ReadOnly="True"></asp:TextBox>
    </div>
    <div class="row_textbox_medium">
        <div class="posicion_izquierda">Nombre del archivo</div>
        <asp:TextBox ID="TextBox_NombreArchivo" runat="server" CssClass="position_derecha_locked" ReadOnly="True"></asp:TextBox>
        <asp:Button ID="Button_Descargar" runat="server" OnClick="Button_Descargar_Click" Text="Descargar" />
    </div>
    <div class="row_textbox_medium">
        <div class="posicion_izquierda">Corregido</div>
        <asp:Image ID="Img_Corregido" CssClass="posicion_derecha" runat="server"></asp:Image>
    </div>
    <div class="row_textbox_medium">
        <div class="posicion_izquierda">Nota</div>
        <asp:TextBox ID="TextBox_Nota" runat="server" CssClass="position_derecha_locked" ReadOnly="True"></asp:TextBox>
    </div>
    <div class="row_textbox_medium">
        <div class="posicion_izquierda">Comentarios del Profesor</div>
        <asp:TextBox ID="TextBox_ComentarioProfesor" CssClass="position_derecha_locked" ReadOnly="True" runat="server"></asp:TextBox>
    </div>
    <div class="row_textbox_medium">
        <asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" Text="Volver" />
        <asp:Button ID="Button_Modificar" runat="server" OnClick="Button_Editar_Click" Text="Modificar" />
    </div>
    </div>
    </div>
</asp:Content>
