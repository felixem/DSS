<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="crear_alumno.aspx.cs" Inherits="DSSGenNHibernate.Alumno.crear_alumno" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="../Styles/submenu/login.css" rel="stylesheet" type="text/css" />
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
    <p class="style2">
        Rellene los siguientes campos</p>
    <asp:Label ID="LabelCod_Alu" runat="server" Text="Código Alumno:"></asp:Label>
    <asp:TextBox ID="TextBox_CodAlu" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="TextBox_CodAlu" Display="Dynamic" 
        ErrorMessage="Introduce Código" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ControlToValidate="TextBox_CodAlu" Display="Dynamic" 
        ErrorMessage="Introduce código válido (Numérico)" ForeColor="Red" 
        ValidationExpression="\d+" ValidationGroup="Registro"></asp:RegularExpressionValidator>
    <br />
    <br />
    <asp:Label ID="Label_NombreAlu" runat="server" Text="Nombre:" 
        style="color: #000000"></asp:Label>
    <asp:TextBox ID="TextBox_NomAlu" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="TextBox_NomAlu" Display="Dynamic" 
        ErrorMessage="Introduce Nombre" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
        ControlToValidate="TextBox_NomAlu" Display="Dynamic" 
        ErrorMessage="Introduce nombre válido" ForeColor="Red" 
        ValidationExpression="\D+" ValidationGroup="Registro"></asp:RegularExpressionValidator>
        <br />
    <br />
        <asp:Label ID="Label_ApellAlu" runat="server" Text="Apellidos:" 
        CssClass="style2"></asp:Label>
    <asp:TextBox ID="TextBox_ApellAlu" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="TextBox_ApellAlu" Display="Dynamic" 
        ErrorMessage="Introduce Apellidos" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
        ControlToValidate="TextBox_ApellAlu" Display="Dynamic" 
        ErrorMessage="Introduce apellido válido" ForeColor="Red" 
        ValidationExpression="\D+" ValidationGroup="Registro"></asp:RegularExpressionValidator>
    <br />
    <br />
    <asp:Label ID="Label_DNIAlu" runat="server" Text="DNI:" CssClass="style2"></asp:Label>
    <asp:TextBox ID="TextBox_DNIAlu" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ControlToValidate="TextBox_DNIAlu" Display="Dynamic" 
        ErrorMessage="Introduce DNI" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
        <br />
    <br />
        <asp:Label ID="Label_EmailAlu" runat="server" Text="Correo:" 
        CssClass="style2"></asp:Label>
        <asp:TextBox ID="TextBox_EmailAlu" runat="server"></asp:TextBox>

    &nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
        ControlToValidate="TextBox_EmailAlu" Display="Dynamic" 
        ErrorMessage="Introduce Correo" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
        ControlToValidate="TextBox_EmailAlu" Display="Dynamic" 
        ErrorMessage="Introduce correo válido" ForeColor="Red" 
        ValidationExpression="\S+@\S+\.\S+" ValidationGroup="Registro"></asp:RegularExpressionValidator>

    <br />
    <br />

    <asp:Label ID="Label_ContAlu" runat="server" Text="Contraseña:" 
        CssClass="style2"></asp:Label>
    <asp:TextBox ID="TextBox_ContAlu" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
        ControlToValidate="TextBox_ContAlu" Display="Dynamic" 
        ErrorMessage="Introduce Contraseña" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="Label_VContAlu" runat="server" Text="Repita Contraseña:" 
        CssClass="style2"></asp:Label>
    <asp:TextBox ID="TextBox_VContAlu" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
        ControlToValidate="TextBox_VContAlu" Display="Dynamic" 
        ErrorMessage="Introduce Contraseña" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CompareValidator1" runat="server" 
        ControlToCompare="TextBox_ContAlu" ControlToValidate="TextBox_VContAlu" 
        Display="Dynamic" ErrorMessage="Contraseñas Diferentes" ForeColor="Red" 
        ValidationGroup="Registro"></asp:CompareValidator>
    <br />
    <br />
    <asp:Label ID="Label_NaciAlu" runat="server" 
        Text="Fecha Nacimiento (MM/DD/AAAA):" CssClass="style2"></asp:Label>
    <asp:TextBox ID="TextBox_NaciAlu" runat="server"></asp:TextBox>

    &nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
        ControlToValidate="TextBox_NaciAlu" Display="Dynamic" 
        ErrorMessage="Introduce Fecha Nacimiento" ForeColor="Red" 
        ValidationGroup="Registro"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
        ControlToValidate="TextBox_NaciAlu" Display="Dynamic" 
        ErrorMessage="Formato fecha inválida" ForeColor="Red" 
        ValidationExpression="\d{2}/\d{2}/\d{4}" ValidationGroup="Registro"></asp:RegularExpressionValidator>
    <asp:CustomValidator ID="CustomValidator1" runat="server" 
        OnServerValidate="ComprobarFecha" ControlToValidate="TextBox_NaciAlu" 
        Display="Dynamic" 
        ErrorMessage="Fecha incorrecta revise día, mes y año introducido" ForeColor="Red" 
        ValidationGroup="Registro"></asp:CustomValidator>

    <br />
    <br />
    <br />
    <asp:Button ID="Button_RegAlu" runat="server" onclick="Button_RegAlu_Click" 
        Text="Registrar" ValidationGroup="Registro" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button_Cancelar" runat="server" 
        onclick="Button_Cancelar_Click" Text="Cancelar" />
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button_LimpCampos" runat="server" onclick="Button_Clean_Click" Text="Limpiar Campos" />
</asp:Content>
