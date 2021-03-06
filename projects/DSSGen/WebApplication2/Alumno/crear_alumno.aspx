﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="crear_alumno.aspx.cs" Inherits="DSSGenNHibernate.Alumno.crear_alumno" %>

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
        Alta de Alumno
    </h1>
    <div class="CentrarContenido">
        <div class="ContenedorInternoNoPanel">
            <p class="style2">
                Rellene los siguientes campos</p>
            <div class="row_crear_alumno">
                <asp:Label ID="LabelCod_Alu" runat="server" Text="Código Alumno:" CssClass="posicion_izquierda"></asp:Label>
                <asp:TextBox ID="TextBox_CodAlu" runat="server" CssClass="posicion_derecha"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox_CodAlu"
                Display="Dynamic" ErrorMessage="Introduce Código de Alumno" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox_CodAlu"
                Display="Dynamic" ErrorMessage="Introduce código válido (Numérico)" ForeColor="Red"
                ValidationExpression="\d+" ValidationGroup="Registro"></asp:RegularExpressionValidator>
            <div class="row_crear_alumno">
                <asp:Label ID="Label_CodExpediente" runat="server" Text="Código de Expediente:" CssClass="posicion_izquierda"></asp:Label>
                <asp:TextBox ID="TextBox_CodExpediente" runat="server" CssClass="posicion_derecha"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBox_CodExpediente"
                Display="Dynamic" ErrorMessage="Introduce Código de Expediente" ForeColor="Red"
                ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <div class="row_crear_alumno">
                <asp:Label ID="Label_ExpedienteAbierto" runat="server" Text="Expediente Abierto:"
                    CssClass="posicion_izquierda"></asp:Label>
                <asp:CheckBox ID="CheckBox_ExpedienteAbierto" runat="server" CssClass="posicion_derecha">
                </asp:CheckBox>
            </div>
            <div class="row_crear_alumno">
                <asp:Label ID="Label_NombreAlu" runat="server" Text="Nombre:" Style="color: #000000"
                    CssClass="posicion_izquierda"></asp:Label>
                <asp:TextBox ID="TextBox_NomAlu" runat="server" CssClass="posicion_derecha"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox_NomAlu"
                Display="Dynamic" ErrorMessage="Introduce Nombre" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBox_NomAlu"
                Display="Dynamic" ErrorMessage="Introduce nombre válido" ForeColor="Red" ValidationExpression="\D+"
                ValidationGroup="Registro"></asp:RegularExpressionValidator>
            <div class="row_crear_alumno">
                <asp:Label ID="Label_ApellAlu" runat="server" Text="Apellidos:" CssClass="posicion_izquierda"></asp:Label>
                <asp:TextBox ID="TextBox_ApellAlu" runat="server" CssClass="posicion_derecha"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox_ApellAlu"
                Display="Dynamic" ErrorMessage="Introduce Apellidos" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TextBox_ApellAlu"
                Display="Dynamic" ErrorMessage="Introduce apellido válido" ForeColor="Red" ValidationExpression="\D+"
                ValidationGroup="Registro"></asp:RegularExpressionValidator>
            <div class="row_crear_alumno">
                <asp:Label ID="Label_DNIAlu" runat="server" Text="DNI:" CssClass="posicion_izquierda"></asp:Label>
                <asp:TextBox ID="TextBox_DNIAlu" runat="server" CssClass="posicion_derecha"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox_DNIAlu"
                Display="Dynamic" ErrorMessage="Introduce DNI" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <div class="row_crear_alumno">
                <asp:Label ID="Label_EmailAlu" runat="server" Text="Correo:" CssClass="posicion_izquierda"></asp:Label>
                <asp:TextBox ID="TextBox_EmailAlu" runat="server" CssClass="posicion_derecha"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox_EmailAlu"
                Display="Dynamic" ErrorMessage="Introduce Correo" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox_EmailAlu"
                Display="Dynamic" ErrorMessage="Introduce correo válido" ForeColor="Red" ValidationExpression="\S+@\S+\.\S+"
                ValidationGroup="Registro"></asp:RegularExpressionValidator>
            <div class="row_crear_alumno">
                <asp:Label ID="Label_ContAlu" runat="server" Text="Contraseña:" CssClass="posicion_izquierda"></asp:Label>
                <asp:TextBox ID="TextBox_ContAlu" runat="server" CssClass="posicion_derecha" TextMode="Password"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox_ContAlu"
                Display="Dynamic" ErrorMessage="Introduce Contraseña" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <div class="row_crear_alumno">
                <asp:Label ID="Label_VContAlu" runat="server" Text="Repita Contraseña:" CssClass="posicion_izquierda"></asp:Label>
                <asp:TextBox ID="TextBox_VContAlu" runat="server" CssClass="posicion_derecha" TextMode="Password"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox_VContAlu"
                Display="Dynamic" ErrorMessage="Introduce Contraseña" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox_ContAlu"
                ControlToValidate="TextBox_VContAlu" Display="Dynamic" ErrorMessage="Contraseñas Diferentes"
                ForeColor="Red" ValidationGroup="Registro"></asp:CompareValidator>
            <div class="row_crear_alumno">
                <asp:Label ID="Label_NaciAlu" runat="server" Text="Fecha Nacimiento:"
                    CssClass="posicion_izquierda"></asp:Label>
                <div class="posicion_derecha">
                       <asp:DropDownList ID="ddlAno" runat="server" OnSelectedIndexChanged="ddlAno_SelectedIndexChanged" CssClass="posicion_derecha"
                            AutoPostBack="True">
                        </asp:DropDownList> 
                         <asp:DropDownList ID="ddlMes" runat="server" OnSelectedIndexChanged="ddlMes_SelectedIndexChanged" CssClass="posicion_derecha"
                            AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlDia" runat="server" CssClass="posicion_derecha" AutoPostBack="True">
                        </asp:DropDownList>
     </div>
            </div>
        </div>
        <div class="row_crear_alumno_buttons">
            <asp:Button ID="Button_RegAlu" runat="server" OnClick="Button_RegAlu_Click" Text="Registrar"
                ValidationGroup="Registro" CssClass="posicion_izquierda" />
            <asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" Text="Volver"
                CssClass="posicion_central" />
            <asp:Button ID="Button_LimpCampos" runat="server" OnClick="Button_Clean_Click" Text="Limpiar Campos"
                CssClass="posicion_derecha" />
        </div>
    </div>
</asp:Content>
