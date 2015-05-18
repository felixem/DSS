<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="realizar_entrega.aspx.cs" Inherits="DSSGenNHibernate.EntregaAlumno.realizar_entrega" %>

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
    <div class="CentrarContenido">
    <div class="ContenedorInterno">
    <p class="style2">
    <div class="row_modificar_alumno">
        Detalles de la practica</div>
    </p>
    <p class="style2">
    <div class="row_modificar_alumno">
        Practica<asp:TextBox ID="TextBox_Nom" runat="server" CssClass="position_derecha_locked" ReadOnly="True"></asp:TextBox>
        </div>
    </p>
    <p class="style2">
    <div class="row_modificar_alumno">
        Descripcion<asp:TextBox ID="TextBox_Desc" runat="server" CssClass="position_derecha_locked" ReadOnly="True"></asp:TextBox>
        </div>
    </p>
    <p class="style2">
    <div class="row_modificar_alumno">
        Fecha Apertura
        <asp:TextBox ID="TextBox_Apertu" runat="server" CssClass="position_derecha_locked" ReadOnly="True"></asp:TextBox>
        </div>
    </p>
    <p class="style2">
    <div class="row_modificar_alumno">
        Fecha Cierre
        <asp:TextBox ID="TextBox_Cierre" runat="server" CssClass="position_derecha_locked" ReadOnly="True"></asp:TextBox>
        </div>
    </p>
    <p class="style2">
    <div class="row_modificar_alumno">
        Puntuación Máxima
        <asp:TextBox ID="TextBox_Punt" runat="server" CssClass="position_derecha_locked" ReadOnly="True"></asp:TextBox>
        </div>
    </p>
    <p class="style2">
    <div class="row_modificar_alumno">
        Rellenar datos de la entrega</div>
    </p>
    <p class="style2">
        <asp:Label runat="server" ID="StatusLabel" ForeColor="Red" 
            CssClass="posicion_izquierda" Font-Bold="True" />
    </p>
    <p class="style2">
    <div class="row_modificar_alumno">
        <asp:FileUpload ID="FileUploadControl" CssClass="posicion_izquierda" runat="server" />
        </div>
    </p>
    <p class="style2">
    <div class="row_modificar_alumno">
        <div class="posicion_izquierda" style="margin-top:15px">
            Comentarios
        </div>
        <asp:TextBox ID="TextBox_Comentario" CssClass="posicion_derecha" runat="server" 
            Rows="2" TextMode="MultiLine"></asp:TextBox>
        </div>
    </p>
    <p class="style2">
    <div class="row_modificar_alumno">
        <asp:Button ID="Button_Entregar" runat="server" CssClass="posicion_izquierda" OnClick="Button_Entregar_Click" Text="Realizar Entrega"
            ValidationGroup="Registro" />
        &nbsp;
        <asp:Button ID="Button_Cancelar" runat="server" CssClass="posicion_derecha" OnClick="Button_Cancelar_Click" Text="Volver" />
        </div>
        </p>
        </div>
        </div>
</asp:Content>
