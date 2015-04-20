<%@ Page Title="Iniciar sesión" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="WebApplication2.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="../Styles/submenu/login.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div class="CentrarContenido">
    <div class="ContenedorInterno">
    <h1>
        Iniciar sesión
    </h1>
    <p>
        Especifique su nombre de usuario y contraseña.
        </p>
    <asp:ValidationSummary ID="SumarioValidacion" runat="server" ValidationGroup="LoginUsuario" ForeColor="Red" />
    </div>
</div>
<asp:Panel ID="panelLogin" runat="server" DefaultButton="LoginUser$LoginButton">
    <asp:Login ID="LoginUser" CssClass="LoginContainer" runat="server" EnableViewState="false" 
        RenderOuterTable="true" onauthenticate="LoginUser_Authenticate">
        <LayoutTemplate>
            <div class="accountInfo">
                <fieldset class="login">
                    <p>
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nombre de usuario:</asp:Label>
                        <asp:TextBox ID="UserName" runat="server"
                            ValidationGroup="LoginUsuario"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                            ErrorMessage="Introduce el nombre de usuario." ToolTip="Introduce el nombre de usuario." 
                             ValidationGroup="LoginUsuario">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:</asp:Label>
                        <asp:TextBox ID="Password" runat="server"
                            TextMode="Password" ValidationGroup="LoginUsuario"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                            ControlToValidate="Password"
                            ErrorMessage="Introduce una contraseña" ToolTip="Introduce una contraseña" 
                            ValidationGroup="LoginUsuario" Display="Dynamic">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" 
                            Text="Iniciar sesión" ValidationGroup="LoginUsuario" />
                    </p>
                </fieldset>
                </div>
        </LayoutTemplate>
    </asp:Login>
 </asp:Panel> 
 <a runat="server" id="Visor"></a>
</asp:Content>