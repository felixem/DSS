<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="modificar_profesor.aspx.cs" Inherits="DSSGenNHibernate.Profesor.modificar_profesor" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="../Styles/submenu/login.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/utilities/tabla_dos_columnas.css" rel="stylesheet" 
        type="text/css" />
    <style type="text/css">
        .style2
        {
            color: #000000;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>
        Modificar Profesor</h1>
    <div class="CentrarContenido">
    <p class="style2">
        Rellene los siguientes campos</p>
    <div class="row_modificar_alumno">
    <asp:Label ID="LabelCod_Prof" runat="server" Text="Código Profesor:" CssClass="posicion_izquierda"></asp:Label>
    <asp:TextBox ID="TextBox_CodProf" runat="server" ReadOnly="True" CssClass="position_derecha_locked"></asp:TextBox>
    </div>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="TextBox_CodProf" Display="Dynamic" 
        ErrorMessage="Introduce Código" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ControlToValidate="TextBox_CodProf" Display="Dynamic" 
        ErrorMessage="Introduce código válido (Numérico)" ForeColor="Red" 
        ValidationExpression="\d+" ValidationGroup="Registro"></asp:RegularExpressionValidator>
    <div class="row_modificar_alumno">
    <asp:Label ID="Label_NombreProf" runat="server" Text="Nombre:" CssClass="posicion_izquierda" 
        style="color: #000000"></asp:Label>
    <asp:TextBox ID="TextBox_NomProf" runat="server" CssClass="posicion_derecha"></asp:TextBox>
    </div>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="TextBox_NomProf" Display="Dynamic" 
        ErrorMessage="Introduce Nombre" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
        ControlToValidate="TextBox_NomProf" Display="Dynamic" 
        ErrorMessage="Introduce nombre válido" ForeColor="Red" 
        ValidationExpression="\D+" ValidationGroup="Registro"></asp:RegularExpressionValidator>
    <div class="row_modificar_alumno">
    <asp:Label ID="Label_ApellProf" runat="server" Text="Apellidos:"  CssClass="posicion_izquierda"></asp:Label>
    <asp:TextBox ID="TextBox_ApellProf" runat="server" CssClass="posicion_derecha"></asp:TextBox>
    </div>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="TextBox_ApellProf" Display="Dynamic" 
        ErrorMessage="Introduce Apellidos" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
        ControlToValidate="TextBox_ApellProf" Display="Dynamic" 
        ErrorMessage="Introduce apellido válido" ForeColor="Red" 
        ValidationExpression="\D+" ValidationGroup="Registro"></asp:RegularExpressionValidator>
    <div class="row_modificar_alumno">
    <asp:Label ID="Label_DNIProf" runat="server" Text="DNI:" CssClass="posicion_izquierda"></asp:Label>
    <asp:TextBox ID="TextBox_DNIProf" runat="server" CssClass="posicion_derecha"></asp:TextBox>
    </div>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ControlToValidate="TextBox_DNIProf" Display="Dynamic" 
        ErrorMessage="Introduce DNI" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
    <div class="row_modificar_alumno">
        <asp:Label ID="Label_EmailProf" runat="server" Text="Correo:" 
        CssClass="posicion_izquierda"></asp:Label>
        <asp:TextBox ID="TextBox_EmailProf" runat="server" ReadOnly="True" CssClass="position_derecha_locked"></asp:TextBox>
    </div>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
        ControlToValidate="TextBox_EmailProf" Display="Dynamic" 
        ErrorMessage="Introduce Correo" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
        ControlToValidate="TextBox_EmailProf" Display="Dynamic" 
        ErrorMessage="Introduce correo válido" ForeColor="Red" 
        ValidationExpression="\S+@\S+\.\S+" ValidationGroup="Registro"></asp:RegularExpressionValidator>

    <div class="row_modificar_alumno">
    <asp:Label ID="Label_NaciProf" runat="server" 
        Text="Fecha Nacimiento (MM/DD/AAAA):" CssClass="posicion_izquierda"></asp:Label>
    <div class="posicion_derecha">
                       <asp:DropDownList ID="ddlAno" runat="server" OnSelectedIndexChanged="ddlAno_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList> 
                         <asp:DropDownList ID="ddlMes" runat="server" OnSelectedIndexChanged="ddlMes_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlDia" runat="server" AutoPostBack="True">
                        </asp:DropDownList>
     </div>
    </div>
    <div class="row_modificar_alumno">
    <asp:Button ID="Button_Modificar" runat="server" onclick="Button_Modificar_Click" CssClass="posicion_izquierda"
        Text="Actualizar cambios" ValidationGroup="Registro" />
    <asp:Button ID="Button_Cancelar" runat="server" 
        onclick="Button_Cancelar_Click" Text="Volver" CssClass="posicion_derecha"/>
    </div>
    </div>
</asp:Content>
