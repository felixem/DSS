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
    <h1>Calificar Entrega Alumno</h1>
    <div class="CentrarContenido" style="width: 450px;">
    <div class="ContenedorInterno">
    <div class="row_textbox_medium">
        <div class="posicion_izquierda">CodEntrega</div>
        <asp:TextBox ID="TextBox_Cod" runat="server" CssClass="position_derecha_locked"
                    ReadOnly="True"></asp:TextBox>
    </div>
    <div class="row_textbox_medium">
        <div class="posicion_izquierda">Nombre Alumno</div>
        <asp:TextBox ID="TextBox_NomAlu" runat="server" CssClass="position_derecha_locked"
                    ReadOnly="True" Width="185px"></asp:TextBox>
    </div>
    <div class="row_textbox_medium">
        <div class="posicion_izquierda">Apellidos Alumno</div>
        <asp:TextBox ID="TextBox_ApeAlu" runat="server" CssClass="position_derecha_locked"
                    ReadOnly="True"></asp:TextBox>
    </div>
    <div class="row_textbox_medium">
        <div class="posicion_izquierda">DNI</div>
        <asp:TextBox ID="TextBox_Dni" runat="server" CssClass="position_derecha_locked"
                    ReadOnly="True"></asp:TextBox>
    </div>
    <div class="row_textbox_medium">
        <div class="posicion_izquierda">Comentarios Alumno</div>
        <asp:TextBox ID="TextBox_ComentAlu" runat="server" CssClass="position_derecha_locked"
                    ReadOnly="True" Width="200px" Rows="2" TextMode="MultiLine"></asp:TextBox>
    </div>
    <div class="row_textbox_medium">
        <div class="posicion_izquierda">Nota </div>
        <asp:TextBox ID="TextBox_Nota" CssClass="posicion_derecha" runat="server"></asp:TextBox>
    </div>
    <div class="row_textbox_medium">
        <div class="posicion_izquierda">Corregido</div>
        <asp:CheckBox CssClass="posicion_derecha" ID="CheckBox_Corregido" runat="server" />
    </div>
    <div class="row_textbox_medium">
        <div class="posicion_izquierda">Comentarios Profesor </div>
        <asp:TextBox ID="TextBox_ComentProf" 
            runat="server" CssClass="posicion_derecha" Width="200px" Rows="2" 
            TextMode="MultiLine"></asp:TextBox>
    </div>
    <div class="row_textbox_medium">
        <div class="posicion_izquierda">Descargar Entrega</div>
        <asp:Button ID="Button_descargar" runat="server" OnClick="Button_Descargar_Click" CssClass="posicion_derecha" Text="Bajar Archivo" Width="130px" />
    </div>
    <div class="row_textbox_medium">
        <asp:Button ID="Button_Calificar" runat="server" OnClick="Button_Calificar_Click" CssClass="posicion_izquierda"
                Text="Calificar" ValidationGroup="Registro"  />
                &nbsp;
        <asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" Text="Volver" CssClass="posicion_derecha"
                 />
    </div>
        </div>
        </div>
</asp:Content>
