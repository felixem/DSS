<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="crear_pregunta.aspx.cs" Inherits="DSSGenNHibernate.Examen.crear_pregunta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/examen/centrar_contenido.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/examen/tabla_dos_columnas.css" rel="stylesheet" 
        type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="CentrarContenido">
    <asp:Panel ID="Panel1" runat="server" CssClass="ContenedorInterno">
        <asp:ValidationSummary ID="ValidationSummary" runat="server" 
            HeaderText="Se produjeron los siguientes errores:" ShowMessageBox="True" 
            ShowSummary="False" ValidationGroup="ValidarSeleccion" />
        <div class="row_textbox">
        <asp:Label ID="Label_Enunciado" runat="server" Text="Enunciado"></asp:Label>
        <asp:TextBox ID="TextBox_Enunciado" runat="server"
            Rows="3" TextMode="MultiLine" CssClass="position_textbox_right"></asp:TextBox>
        </div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEnunciado" runat="server" 
            ControlToValidate="TextBox_Enunciado" ErrorMessage="El enunciado es requerido" 
            ValidationGroup="ValidarSeleccion">*</asp:RequiredFieldValidator>
        <asp:Label ID="Label_CabeceraRespuestas" runat="server" 
            Text="Escribir las respuestas"></asp:Label>
        <div class="row_textbox">
        <asp:Label ID="Label_Opcion1" runat="server" Text="Opción 1"></asp:Label>
        <asp:TextBox ID="TextBox_Opcion1" CssClass="position_textbox_right" runat="server" 
                Rows="2" TextMode="MultiLine"></asp:TextBox>
        </div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorOpcion1" runat="server" 
            ControlToValidate="TextBox_Opcion1" ErrorMessage="La opción 1 es requerida" 
            ValidationGroup="ValidarSeleccion">*</asp:RequiredFieldValidator>
        <div class="row_textbox">
        <asp:Label ID="Label_Opcion2" runat="server" Text="Opción 2"></asp:Label>
        <asp:TextBox ID="TextBox_Opcion2" runat="server" CssClass="position_textbox_right" 
                Rows="2" TextMode="MultiLine"></asp:TextBox>
        </div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorOpcion2" runat="server" 
            ControlToValidate="TextBox_Opcion2" ErrorMessage="La opción 2 es requerida" 
            ValidationGroup="ValidarSeleccion">*</asp:RequiredFieldValidator>
        <div class="row_textbox">
        <asp:Label ID="Label_Opcion3" runat="server" Text="Opción 3"></asp:Label>
        <asp:TextBox ID="TextBox_Opcion3" runat="server" CssClass="position_textbox_right" 
                Rows="2" TextMode="MultiLine"></asp:TextBox>
        </div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorOpcion3" runat="server" 
            ControlToValidate="TextBox_Opcion3" ErrorMessage="La opción 3 es requerida" 
            ValidationGroup="ValidarSeleccion">*</asp:RequiredFieldValidator>
        <div class="row_textbox">
        <asp:Label ID="Label_Opcion4" runat="server" Text="Opción 4"></asp:Label>
        <asp:TextBox ID="TextBox_Opcion4" runat="server" CssClass="position_textbox_right" 
                Rows="2" TextMode="MultiLine"></asp:TextBox>
        </div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorOpcion4" runat="server" 
            ControlToValidate="TextBox_Opcion4" ErrorMessage="La opción 4 es requerida" 
            ValidationGroup="ValidarSeleccion">*</asp:RequiredFieldValidator>
        <div class="row_textbox">
        <asp:Label ID="Label_Explicacion" runat="server" Text="Explicacion"></asp:Label>
        <asp:TextBox ID="TextBox_Explicacion" runat="server" 
                CssClass="position_textbox_right" Rows="2" TextMode="MultiLine"></asp:TextBox>
        </div>
        <asp:Label ID="Label_SeleccionarOpcion" runat="server" 
            Text="Seleccionar opción correcta"></asp:Label>
        <asp:RadioButtonList Style="" ID="RadioButtonListOpciones" runat="server">
            <asp:ListItem Value="1">Opción 1</asp:ListItem>
            <asp:ListItem Value="2">Opción 2</asp:ListItem>
            <asp:ListItem Value="3">Opción 3</asp:ListItem>
            <asp:ListItem Value="4">Opción 4</asp:ListItem>
        </asp:RadioButtonList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorRadioButton" 
            runat="server" ControlToValidate="RadioButtonListOpciones" Display="None" 
            ErrorMessage="Error: Se requiere elegir como correcta una de las opciones" 
            ValidationGroup="ValidarSeleccion"></asp:RequiredFieldValidator>
        <div class="row_textbox">
        <asp:Button ID="Button_Guardar" runat="server" OnClick="Button_Guardar_Click" 
            Text="Guardar Pregunta" ValidationGroup="ValidarSeleccion" />
        <asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" Text="Cancelar" />
        </div>
        </asp:Panel>
    </div>
</asp:Content>
