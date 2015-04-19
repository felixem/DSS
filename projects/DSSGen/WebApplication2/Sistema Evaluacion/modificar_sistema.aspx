<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="modificar_sistema.aspx.cs" Inherits="DSSGenNHibernate.Sistema_Evaluacion.modificar_sistema" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    Puntuación máxima<asp:TextBox ID="TextBox_Puntuacion" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TextBox_Puntuacion"
                Display="Dynamic" 
            ErrorMessage="Introduce la puntuación máxima" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" 
            runat="server" ControlToValidate="TextBox_Puntuacion"
                Display="Dynamic" ErrorMessage="Separar la puntuación por punto decimal" 
            ForeColor="Red" ValidationExpression="\d+\.\d+|\d+"
                ValidationGroup="Registro"></asp:RegularExpressionValidator>
                <p>
                <asp:Button ID="Button_ModificarControl" runat="server" OnClick="Button_Modificar_Click"
                Text="Modificar" ValidationGroup="Registro"  />
                &nbsp;
        <asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" Text="Volver"
                 /></p>
</asp:Content>
