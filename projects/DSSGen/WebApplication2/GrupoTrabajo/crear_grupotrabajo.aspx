<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="crear_grupotrabajo.aspx.cs" Inherits="DSSGenNHibernate.GrupoTrabajo.crear_grupotrabajo" %>

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
        Crear Grupo de Trabajo</h1>
    <div class="CentrarContenido">
        <div class="ContenedorInternoNoPanel">
            <p class="style2">
                Rellene los siguientes campos</p>
            <div class="row_crear_alumno">
                <asp:Label ID="Label_Anyo" runat="server" Text="Año académico" CssClass="posicion_izquierda"></asp:Label>
                <asp:DropDownList ID="DropDownList_Anyos" runat="server" CssClass="posicion_derecha"
                    OnSelectedIndexChanged="DropDownList_Anyos_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="row_crear_alumno">
                <asp:Label ID="Label_Asignatura" runat="server" Text="Asignatura" CssClass="posicion_izquierda"></asp:Label>
                <asp:DropDownList ID="DropDownList_Asignaturas" runat="server" CssClass="posicion_derecha"
                    OnSelectedIndexChanged="DropDownList_Asignaturas_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="row_crear_alumno">
                <asp:Label ID="LabelCod_Grupo" runat="server" Text="Código de Grupo:" CssClass="posicion_izquierda"></asp:Label>
                <asp:TextBox ID="TextBox_CodGrupo" runat="server" CssClass="posicion_derecha"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox_CodGrupo"
                Display="Dynamic" ErrorMessage="Introduce Código" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <div class="row_crear_alumno">
                <asp:Label ID="Label_NombreGrupo" runat="server" Text="Nombre:" Style="color: #000000"
                    CssClass="posicion_izquierda"></asp:Label>
                <asp:TextBox ID="TextBox_NomGrupo" runat="server" CssClass="posicion_derecha"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox_NomGrupo"
                Display="Dynamic" ErrorMessage="Introduce Nombre" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <div class="row_crear_alumno">
                <asp:Label ID="Label_DescGrupo" runat="server" Text="Descripción:" CssClass="posicion_izquierda"></asp:Label>
                <asp:TextBox ID="TextBox_DescGrupo" runat="server" CssClass="posicion_derecha"></asp:TextBox>
            </div>
            <div class="row_crear_alumno">
                <asp:Label ID="Label_Pass" runat="server" Text="Contraseña:" CssClass="posicion_izquierda"></asp:Label>
                <asp:TextBox ID="TextBox_Pass" runat="server" CssClass="posicion_derecha" TextMode="Password"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox_Pass"
                Display="Dynamic" ErrorMessage="Introduce Contraseña" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <div class="row_crear_alumno">
                <asp:Label ID="Label_VPass" runat="server" Text="Repita Contraseña:" CssClass="posicion_izquierda"></asp:Label>
                <asp:TextBox ID="TextBox_VPass" runat="server" CssClass="posicion_derecha" TextMode="Password"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox_VPass"
                Display="Dynamic" ErrorMessage="Introduce Contraseña" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox_Pass"
                ControlToValidate="TextBox_VPass" Display="Dynamic" ErrorMessage="Contraseñas Diferentes"
                ForeColor="Red" ValidationGroup="Registro"></asp:CompareValidator>
        </div>
        <div class="row_crear_alumno">
            <asp:Label ID="Label_Capacidad" runat="server" Text="Capacidad:" CssClass="posicion_izquierda"></asp:Label>
            <asp:TextBox ID="TextBox_Capacidad" runat="server" CssClass="posicion_derecha"></asp:TextBox>
        </div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox_Capacidad"
            Display="Dynamic" ErrorMessage="Introduce Capacidad" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox_Capacidad"
            Display="Dynamic" ErrorMessage="Se esperaba valor numérico" ForeColor="Red" ValidationExpression="^\d+$"
            ValidationGroup="Registro"></asp:RegularExpressionValidator>
        <div class="row_crear_alumno_buttons">
            <asp:Button ID="Button_CrearGrupo" runat="server" OnClick="Button_CrearGrupo_Click"
                Text="Crear" ValidationGroup="Registro" CssClass="posicion_izquierda" />
            <asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" Text="Cancelar"
                CssClass="posicion_central" />
            <asp:Button ID="Button_LimpCampos" runat="server" OnClick="Button_Clean_Click" Text="Limpiar Campos"
                CssClass="posicion_derecha" />
        </div>
    </div>
</asp:Content>
