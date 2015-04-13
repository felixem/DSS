<%@ Page Title="Cambiar contraseña" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="WebApplication2.Account.ChangePassword" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Cambiar contraseña
    </h1>
    <p>
        Use el formulario siguiente para cambiar la contraseña.
    </p>
    <p>
        Las contraseñas nuevas deben tener una longitud mínima de <%= Membership.MinRequiredPasswordLength %> caracteres.
    </p>
            <asp:ValidationSummary ID="ChangeUserPasswordValidationSummary" 
        runat="server" CssClass="failureNotification" 
                 ValidationGroup="RegisterUserValidationGroup"/>
            <asp:Label ID="r" runat="server" Text="Contraseña anterior"></asp:Label>
    <br />
    <asp:TextBox ID="T_Anterior" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" 
        runat="server" ControlToValidate="T_Anterior" 
                                     CssClass="failureNotification" 
                                    ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria." 
                                     ValidationGroup="RegisterUserValidationGroup" 
        Display="Dynamic">*</asp:RequiredFieldValidator>
                    <br />
    <br />
    <asp:Label ID="L_Nueva" runat="server" Text="Nueva contraseña"></asp:Label>
    <br />
    <asp:TextBox ID="T_nueva" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
        runat="server" ControlToValidate="T_nueva" 
                                     CssClass="failureNotification" 
                                    ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria." 
                                     ValidationGroup="RegisterUserValidationGroup" 
        Display="Dynamic">*</asp:RequiredFieldValidator>
                        

                    <br />
    <br />
    <asp:Label ID="L_Repetir" runat="server" Text="Repetir contraseña"></asp:Label>
    <br />
    <asp:TextBox ID="T_Repetir" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="T_nueva" 
                            CssClass="failureNotification" Display="Dynamic" 
                                     ErrorMessage="Confirmar contraseña es obligatorio." 
                            ID="ConfirmPasswordRequired" runat="server" 
                                     ToolTip="Confirmar contraseña es obligatorio." 
                            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                       <asp:CompareValidator ID="PasswordCompare" runat="server" 
                            ControlToCompare="T_nueva" ControlToValidate="T_Repetir" 
                                     CssClass="failureNotification" 
        Display="Dynamic" ErrorMessage="Contraseña y Confirmar contraseña deben coincidir."
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>
                    <br />
    <br />
                    <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" 
                        OnClick="Cancelar"  Text="Cancelar"/>
                    &nbsp;
                    <asp:Button ID="ChangePasswordPushButton" runat="server" 
                        Text="Cambiar contraseña" OnClick="Button_Change_Click"
                         ValidationGroup="RegisterUserValidationGroup"/>
                </asp:Content>
