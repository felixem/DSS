<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="acceso_grupotrabajo.aspx.cs" Inherits="DSSGenNHibernate.GrupoTrabajo.acceso_grupotrabajo" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="../Styles/submenu/login.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/utilities/tabla_dos_columnas.css" rel="stylesheet" 
        type="text/css" />
    <style type="text/css">
        .style2
        {
            color: #000000;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>
        Modificar Grupo de Trabajo</h1>
    <div class="CentrarContenido">
        <div class="ContenedorInternoNoPanel">
            <p class="style2">
                Rellene los siguientes campos</p>
            <div class="row_crear_alumno">
                <asp:Label ID="Label_Anyo" runat="server" Text="Año académico" CssClass="posicion_izquierda"></asp:Label>
                <asp:TextBox ID="TextBox_Anyo" runat="server" CssClass="position_derecha_locked" 
                    ReadOnly="True"></asp:TextBox>
            </div>
            <div class="row_crear_alumno">
                <asp:Label ID="Label_Asignatura" runat="server" Text="Asignatura" CssClass="posicion_izquierda"></asp:Label>
                <asp:TextBox ID="TextBox_Asignatura" runat="server" CssClass="position_derecha_locked" 
                    ReadOnly="True"></asp:TextBox>
            </div>
            <div class="row_crear_alumno">
                <asp:Label ID="LabelCod_Grupo" runat="server" Text="Código de Grupo:" CssClass="posicion_izquierda"></asp:Label>
                <asp:TextBox ID="TextBox_CodGrupo" runat="server" CssClass="position_derecha_locked" ReadOnly="true"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox_CodGrupo"
                Display="Dynamic" ErrorMessage="Introduce Código" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
            
        <div class="row_crear_alumno">
            <asp:Label ID="Label_Capacidad" runat="server" Text="Capacidad:" CssClass="posicion_izquierda"></asp:Label>
            <asp:TextBox ID="TextBox_Capacidad" runat="server" CssClass="position_derecha_locked" ReadOnly="true"></asp:TextBox>
        </div>

            <div class="row_crear_alumno">
                <asp:Label ID="Label_NombreGrupo" runat="server" Text="Nombre:" Style="color: #000000"
                    CssClass="posicion_izquierda"></asp:Label>
                <asp:TextBox ID="TextBox_NomGrupo" runat="server" CssClass="position_derecha_locked" ReadOnly="true"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox_NomGrupo"
                Display="Dynamic" ErrorMessage="Introduce Nombre" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <div class="row_crear_alumno">
                <asp:Label ID="Label_DescGrupo" runat="server" Text="Descripción:" CssClass="posicion_izquierda"></asp:Label>
                <asp:TextBox ID="TextBox_DescGrupo" runat="server" CssClass="position_derecha_locked" ReadOnly="true"></asp:TextBox>
            </div>
            <div class="row_crear_alumno">
                <asp:Label ID="Label_Pass" runat="server" Text="Contraseña:" CssClass="posicion_izquierda"></asp:Label>
                <asp:TextBox ID="TextBox_Pass" runat="server" CssClass="posicion_derecha" TextMode="Password"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox_Pass"
                Display="Dynamic" ErrorMessage="Introduce Contraseña" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
        </div>
        <div class="row_crear_alumno_buttons">
            <asp:Button ID="Button_AccederGrupo" runat="server" OnClick="Button_AccederGrupo_Click"
                Text="Acceder" ValidationGroup="Registro" CssClass="posicion_izquierda" />
            <asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" Text="Volver"
                CssClass="posicion_derecha" />
        </div>
    </div>
</asp:Content>
