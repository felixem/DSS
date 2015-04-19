﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="modificar_evaluacion.aspx.cs" Inherits="DSSGenNHibernate.Evaluacion.modificar_evaluacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <p>
        Nombre de la evaluación: <asp:TextBox ID="TextBox_Nombre" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox_Nombre"
                Display="Dynamic" ErrorMessage="Introduce nombre de evaluación" 
            ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
    </p>
    <p>
        Fecha de inicio: <asp:TextBox ID="TextBox_FechaI" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox_FechaI"
                Display="Dynamic" ErrorMessage="Introduce fecha inicio evaluación" 
            ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
            runat="server" ControlToValidate="TextBox_FechaI"
                Display="Dynamic" ErrorMessage="Formato fecha inválida Formato:(MM/DD/AAAA NN:NN:NN (AM/PM))" 
            ForeColor="Red" ValidationExpression="\d{2}/\d{2}/\d{4}\s\d{2}:\d{2}:\d{2}\sAM|\d{2}/\d{2}/\d{4}\s\d{2}:\d{2}:\d{2}\sPM"
                ValidationGroup="Registro"></asp:RegularExpressionValidator>
            <asp:CustomValidator ID="CustomValidator1" runat="server" OnServerValidate="ComprobarFecha"
                ControlToValidate="TextBox_FechaF" Display="Dynamic" ErrorMessage="Fecha incorrecta revise día, mes, año y hora introducida Formato:(MM/DD/AAAA NN:NN:NN (AM/PM))"
                ForeColor="Red" ValidationGroup="Registro"></asp:CustomValidator> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox_FechaF"
                Display="Dynamic" ErrorMessage="Introduce fecha inicio evaluación" 
            ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
            runat="server" ControlToValidate="TextBox_FechaI"
                Display="Dynamic" ErrorMessage="Formato fecha inválida Formato:(MM/DD/AAAA NN:NN:NN (AM/PM))" 
            ForeColor="Red" ValidationExpression="\d{2}/\d{2}/\d{4}\s\d{2}:\d{2}:\d{2}\sAM|\d{2}/\d{2}/\d{4}\s\d{2}:\d{2}:\d{2}\sPM"
                ValidationGroup="Registro"></asp:RegularExpressionValidator>
            <asp:CustomValidator ID="CustomValidator3" runat="server" OnServerValidate="ComprobarFecha"
                ControlToValidate="TextBox_FechaF" Display="Dynamic" ErrorMessage="Fecha incorrecta revise día, mes, año y hora introducida Formato:(MM/DD/AAAA NN:NN:NN (AM/PM))"
                ForeColor="Red" ValidationGroup="Registro"></asp:CustomValidator>
    </p>
    <p>
        Fecha de fin: <asp:TextBox ID="TextBox_FechaF" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBox_FechaF"
                Display="Dynamic" ErrorMessage="Introduce fecha fin evaluación" 
            ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" 
            runat="server" ControlToValidate="TextBox_FechaF"
                Display="Dynamic" ErrorMessage="Formato fecha inválida Formato:(MM/DD/AAAA NN:NN:NN (AM/PM))" 
            ForeColor="Red" ValidationExpression="\d{2}/\d{2}/\d{4}\s\d{2}:\d{2}:\d{2}\sAM|\d{2}/\d{2}/\d{4}\s\d{2}:\d{2}:\d{2}\sPM"
                ValidationGroup="Registro"></asp:RegularExpressionValidator>
            <asp:CustomValidator ID="CustomValidator2" runat="server" OnServerValidate="ComprobarFecha"
                ControlToValidate="TextBox_FechaF" Display="Dynamic" ErrorMessage="Fecha incorrecta revise día, mes, año y hora introducida Formato:(MM/DD/AAAA NN:NN:NN (AM/PM))"
                ForeColor="Red" ValidationGroup="Registro"></asp:CustomValidator>
        </p>
    <p>
        Abierta 
        <asp:CheckBox ID="CheckBox_Abierta" runat="server" />
    </p>
    <p>
        <asp:Button ID="Button_ModificarEvaluacion" runat="server" OnClick="Button_Modificar_Click"
                Text="Modificar" ValidationGroup="Registro"  />
                &nbsp;
        <asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" Text="Volver"
                 /></p>
    </p>
</asp:Content>
