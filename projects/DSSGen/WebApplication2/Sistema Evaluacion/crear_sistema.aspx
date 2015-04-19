<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="crear_sistema.aspx.cs" Inherits="DSSGenNHibernate.Sistema_Evaluacion.crear_sistema" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        Año academico
        <asp:DropDownList ID="DropDownList_Anyos" runat="server" 
                    OnSelectedIndexChanged="DropDownList_Anyos_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
    </p>
    <p>
        Asignatura
        <asp:DropDownList ID="DropDownList_AsignaturasAnyo" runat="server" 
                    OnSelectedIndexChanged="DropDownList_AsignaturasAnyo_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>

    </p>
    <p>Evaluación
        <asp:DropDownList ID="DropDownList_Evaluacion" runat="server" 
                    OnSelectedIndexChanged="DropDownList_Evaluacion_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList></p>
    Puntuación máxima<asp:TextBox ID="TextBox_Puntuacion" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TextBox_Puntuacion"
                Display="Dynamic" 
            ErrorMessage="Introduce la puntuación máxima" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" 
            runat="server" ControlToValidate="TextBox_Puntuacion"
                Display="Dynamic" ErrorMessage="Separar la puntuación por punto decimal" 
            ForeColor="Red" ValidationExpression="\d+\.\d+|\d+"
                ValidationGroup="Registro"></asp:RegularExpressionValidator>
                <p></p>
        <asp:Button ID="Button_RegSistema" runat="server" OnClick="Button_RegSistema_Click" Text="Crear"
                ValidationGroup="Registro" />
        <asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" Text="Volver"
                 />
        <asp:Button ID="Button_LimpCampos" runat="server" OnClick="Button_Clean_Click" Text="Limpiar Campos"
                 /></p>
</asp:Content>
