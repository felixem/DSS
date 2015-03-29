<%@ Page Title="Iniciar sesión" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="../Styles/submenu/login.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>
        Iniciar sesión
    </h1>
    <p>
        Especifique su nombre de usuario y contraseña.
        <asp:HyperLink ID="RegisterHyperLink" runat="server" ForeColor="Black">Regístrese</asp:HyperLink>
&nbsp;si no tiene una cuenta.
        </p>
    <asp:ValidationSummary ID="SumarioValidacion" runat="server" 
        CssClass="failureNotification" ValidationGroup="LoginUsuario"/>

<asp:Panel ID="panelLogin" runat="server" DefaultButton="LoginUser$LoginButton">
    <asp:Login ID="LoginUser" runat="server" EnableViewState="false" 
        RenderOuterTable="false" onauthenticate="LoginUser_Authenticate">
        <LayoutTemplate>
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>Información de cuenta</legend>
                    <p>
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nombre de usuario:</asp:Label>
                        <asp:TextBox ID="UserName" runat="server" CssClass="LabelLogin" 
                            ValidationGroup="LoginUsuario"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                             CssClass="failureNotification" 
                            ErrorMessage="Introduce el nombre de usuario." ToolTip="Introduce el nombre de usuario." 
                             ValidationGroup="LoginUsuario">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:</asp:Label>
                        <asp:TextBox ID="Password" runat="server" CssClass="LabelLogin" 
                            TextMode="Password" ValidationGroup="LoginUsuario"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                            ControlToValidate="Password" CssClass="failureNotification" 
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