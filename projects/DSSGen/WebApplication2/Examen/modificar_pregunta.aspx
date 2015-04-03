<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="modificar_pregunta.aspx.cs" Inherits="DSSGenNHibernate.Examen.modificar_pregunta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="505px">
        <asp:ValidationSummary ID="ValidationSummary" runat="server" 
            HeaderText="Se produjeron los siguientes errores:" ShowMessageBox="True" 
            ShowSummary="False" ValidationGroup="ValidarSeleccion" />
        <asp:Label ID="Label_Enunciado" runat="server" Text="Enunciado"></asp:Label>
        <asp:TextBox ID="TextBox_Enunciado" runat="server" Height="64px" Width="386px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEnunciado" runat="server" 
            ControlToValidate="TextBox_Enunciado" ErrorMessage="El enunciado es requerido" 
            ValidationGroup="ValidarSeleccion">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label_CabeceraRespuestas" runat="server" 
            Text="Escribir las respuestas"></asp:Label>
        <br />
        <asp:Label ID="Label_Opcion1" runat="server" Text="Opción 1"></asp:Label>
        <asp:TextBox ID="TextBox_Opcion1" runat="server" Height="46px" Width="392px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorOpcion1" runat="server" 
            ControlToValidate="TextBox_Opcion1" ErrorMessage="La opción 1 es requerida" 
            ValidationGroup="ValidarSeleccion">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label_Opcion2" runat="server" Text="Opción 2"></asp:Label>
        <asp:TextBox ID="TextBox_Opcion2" runat="server" Height="42px" Width="392px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorOpcion2" runat="server" 
            ControlToValidate="TextBox_Opcion2" ErrorMessage="La opción 2 es requerida" 
            ValidationGroup="ValidarSeleccion">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label_Opcion3" runat="server" Text="Opción 3"></asp:Label>
        <asp:TextBox ID="TextBox_Opcion3" runat="server" Height="42px" Width="391px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorOpcion3" runat="server" 
            ControlToValidate="TextBox_Opcion3" ErrorMessage="La opción 3 es requerida" 
            ValidationGroup="ValidarSeleccion">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label_Opcion4" runat="server" Text="Opción 4"></asp:Label>
        <asp:TextBox ID="TextBox_Opcion4" runat="server" Height="34px" Width="391px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorOpcion4" runat="server" 
            ControlToValidate="TextBox_Opcion4" ErrorMessage="La opción 4 es requerida" 
            ValidationGroup="ValidarSeleccion">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label_Explicacion" runat="server" Text="Explicacion"></asp:Label>
        <asp:TextBox ID="TextBox_Explicacion" runat="server" Height="34px" 
            Width="370px"></asp:TextBox>
        <br />
        <asp:Label ID="Label_SeleccionarOpcion" runat="server" 
            Text="Seleccionar opción correcta"></asp:Label>
        <asp:RadioButtonList ID="RadioButtonListOpciones" runat="server">
            <asp:ListItem Value="1">Opción 1</asp:ListItem>
            <asp:ListItem Value="2">Opción 2</asp:ListItem>
            <asp:ListItem Value="3">Opción 3</asp:ListItem>
            <asp:ListItem Value="4">Opción 4</asp:ListItem>
        </asp:RadioButtonList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorRadioButton" 
            runat="server" ControlToValidate="RadioButtonListOpciones" Display="None" 
            ErrorMessage="Error: Se requiere elegir como correcta una de las opciones" 
            ValidationGroup="ValidarSeleccion"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="Button_Guardar" runat="server" OnClick="Button_Guardar_Click" 
            Text="Guardar Pregunta" ValidationGroup="ValidarSeleccion" />
        <asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" Text="Cancelar" />
        <br />
        <br />
    </asp:Panel>
</asp:Content>
