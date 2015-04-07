<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="crear_asignatura.aspx.cs" Inherits="DSSGenNHibernate.Asignatura.crear_asignatura" %>

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
        Crear Asignatura
    </h1>
    <div class="CentrarContenido">
        <div class="ContenedorInternoNoPanel">
            <p class="style2">
                Rellene los siguientes campos</p>
            <div class="row_crear_alumno">
                <asp:Label ID="LabelCod_Asig" runat="server" Text="Código de Asignatura:" CssClass="posicion_izquierda"></asp:Label>
                <asp:TextBox ID="TextBox_CodAsig" runat="server" CssClass="posicion_derecha"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox_CodAsig"
                Display="Dynamic" ErrorMessage="Introduce Código" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <div class="row_crear_alumno">
                <asp:Label ID="Label_NombreAsig" runat="server" Text="Nombre:" Style="color: #000000"
                    CssClass="posicion_izquierda"></asp:Label>
                <asp:TextBox ID="TextBox_NomAsig" runat="server" CssClass="posicion_derecha"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox_NomAsig"
                Display="Dynamic" ErrorMessage="Introduce Nombre" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <div class="row_crear_alumno">
                <asp:Label ID="Label_DescAsig" runat="server" Text="Descripción:" CssClass="posicion_izquierda"></asp:Label>
                <asp:TextBox ID="TextBox_DescAsig" runat="server" CssClass="posicion_derecha"></asp:TextBox>
            </div>
            <div class="row_crear_alumno">
                <asp:Label ID="Label_OptativaAsig" runat="server" Text="Optativa:" CssClass="posicion_izquierda"></asp:Label>
                <asp:CheckBox ID="CheckBox_OptativaAsig" runat="server" CssClass="posicion_derecha">
                </asp:CheckBox>
            </div>
            <div class="row_crear_alumno">
                <asp:Label ID="Label_VigenteAsig" runat="server" Text="Vigente:" CssClass="posicion_izquierda"></asp:Label>
                <asp:CheckBox ID="CheckBox_VigenteAsig" runat="server" 
                    CssClass="posicion_derecha" Checked="True"></asp:CheckBox>
            </div>
        </div>
        <div class="row_crear_alumno_buttons">
            <asp:Button ID="Button_CrearAsig" runat="server" OnClick="Button_CrearAsig_Click" Text="Crear"
                ValidationGroup="Registro" CssClass="posicion_izquierda" />
            <asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" Text="Cancelar"
                CssClass="posicion_central" />
            <asp:Button ID="Button_LimpCampos" runat="server" OnClick="Button_Clean_Click" Text="Limpiar Campos"
                CssClass="posicion_derecha" />
        </div>
    </div>
</asp:Content>
