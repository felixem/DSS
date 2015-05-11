<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="modificar_control.aspx.cs" Inherits="DSSGenNHibernate.Control.modificar_control" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="../Styles/submenu/login.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/utilities/tabla_dos_columnas.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style2
        {
            color: #000000;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1>
        Modificar Control</h1>
    <div class="CentrarContenido">
    <div class="ContenedorInterno">
    <p class="style2">
    <div class="row_modificar_alumno">
        Año Academico
                <asp:TextBox ID="TextBox_Anyo" runat="server" 
                    ReadOnly="True" CssClass="position_derecha_locked"></asp:TextBox>
                    </div>
    </p>
    <p class="style2">
    <div class="row_modificar_alumno">
        Asignatura
                <asp:TextBox ID="TextBox_Asignatura" runat="server"
                    ReadOnly="True" Width="173px" CssClass="position_derecha_locked"></asp:TextBox>
                    </div>
    </p>
    <p class="style2">
    <div class="row_modificar_alumno">
        Evaluación
                <asp:TextBox ID="TextBox_Evaluacion" runat="server"
                    ReadOnly="True" CssClass="position_derecha_locked"></asp:TextBox>
                    </div>
    </p>
    <p class="style2">
    <div class="row_modificar_alumno">
        Cod Control
                <asp:TextBox ID="TextBox_CodControl" runat="server"
                    ReadOnly="True" CssClass="position_derecha_locked"></asp:TextBox>
                    </div>
    </p>
    <p class="style2">
    <div class="row_modificar_alumno">
        Nombre <asp:TextBox ID="TextBox_Nom" runat="server" CssClass="posicion_derecha"></asp:TextBox>
        </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox_Nom"
                Display="Dynamic" ErrorMessage="Introduce Nombre" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBox_Nom"
                Display="Dynamic" ErrorMessage="Introduce nombre válido" ForeColor="Red" ValidationExpression="\D+"
                ValidationGroup="Registro"></asp:RegularExpressionValidator>
    </p>
    <p class="style2">
    <div class="row_modificar_alumno">
        Descripción <asp:TextBox ID="TextBox_Desc" runat="server" CssClass="posicion_derecha"></asp:TextBox>
        </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox_Desc"
                Display="Dynamic" ErrorMessage="Introduce Descripcion" ForeColor="Red" 
            ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" 
            runat="server" ControlToValidate="TextBox_Desc"
                Display="Dynamic" ErrorMessage="Introduce descripcion válida" 
            ForeColor="Red" ValidationExpression="\D+"
                ValidationGroup="Registro"></asp:RegularExpressionValidator>
    </p>
    <p class="style2">
    <div class="row_modificar_alumno">
        Fecha Apertura <asp:TextBox ID="TextBox_Apertura" runat="server" CssClass="posicion_derecha"></asp:TextBox>
        </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox_Apertura"
                Display="Dynamic" ErrorMessage="Introduce Fecha Apertura" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox_Apertura"
                Display="Dynamic" ErrorMessage="Formato fecha inválida Formato:(MM/DD/AAAA NN:NN:NN (AM/PM))" ForeColor="Red" ValidationExpression="\d{2}/\d{2}/\d{4}\s\d{2}:\d{2}:\d{2}\sAM|\d{2}/\d{2}/\d{4}\s\d{2}:\d{2}:\d{2}\sPM"
                ValidationGroup="Registro"></asp:RegularExpressionValidator>
            <asp:CustomValidator ID="CustomValidator1" runat="server" OnServerValidate="ComprobarFecha"
                ControlToValidate="TextBox_Apertura" Display="Dynamic" ErrorMessage="Fecha incorrecta revise día, mes, año y hora introducida Formato:(MM/DD/AAAA NN:NN:NN (AM/PM))"
                ForeColor="Red" ValidationGroup="Registro"></asp:CustomValidator>
    </p>
    <p class="style2">
    <div class="row_modificar_alumno">
        Fecha Cierre <asp:TextBox ID="TextBox_Cierre" runat="server" CssClass="posicion_derecha"></asp:TextBox>
        </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBox_Cierre"
                Display="Dynamic" ErrorMessage="Introduce Fecha Cierre" 
            ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" 
            runat="server" ControlToValidate="TextBox_Cierre"
                Display="Dynamic" ErrorMessage="Formato fecha inválida Formato:(MM/DD/AAAA NN:NN:NN (AM/PM))" 
            ForeColor="Red" ValidationExpression="\d{2}/\d{2}/\d{4}\s\d{2}:\d{2}:\d{2}\sAM|\d{2}/\d{2}/\d{4}\s\d{2}:\d{2}:\d{2}\sPM"
                ValidationGroup="Registro"></asp:RegularExpressionValidator>
            <asp:CustomValidator ID="CustomValidator2" runat="server" OnServerValidate="ComprobarFecha"
                ControlToValidate="TextBox_Cierre" Display="Dynamic" ErrorMessage="Fecha incorrecta revise día, mes, año y hora introducida Formato:(MM/DD/AAAA NN:NN:NN (AM/PM))"
                ForeColor="Red" ValidationGroup="Registro"></asp:CustomValidator>
    </p>
    <p class="style2">
    <div class="row_modificar_alumno">
        Duración <asp:TextBox ID="TextBox_Duracion" CssClass="posicion_derecha" runat="server"></asp:TextBox>
        </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextBox_Duracion"
                Display="Dynamic" ErrorMessage="Introduce la duración del control en minutos" ForeColor="Red" 
            ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" 
            runat="server" ControlToValidate="TextBox_Duracion"
                Display="Dynamic" ErrorMessage="Introduce la duración del control en minutos"
            ForeColor="Red" ValidationExpression="\d+"
                ValidationGroup="Registro"></asp:RegularExpressionValidator>
    </p>
    <p class="style2">
    <div class="row_modificar_alumno">
        Puntuación <asp:TextBox ID="TextBox_PuntMax" CssClass="posicion_derecha" runat="server"></asp:TextBox>
        </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TextBox_PuntMax"
                Display="Dynamic" 
            ErrorMessage="Introduce la puntuación máxima del control" ForeColor="Red" 
            ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" 
            runat="server" ControlToValidate="TextBox_PuntMax"
                Display="Dynamic" ErrorMessage="Separar la puntuación por punto decimal" 
            ForeColor="Red" ValidationExpression="\d+\.\d+|\d+"
                ValidationGroup="Registro"></asp:RegularExpressionValidator>
    </p>
    <p class="style2">
    <div class="row_modificar_alumno">
        Penalización por fallo<asp:TextBox ID="TextBox_Penalizacion" CssClass="posicion_derecha" runat="server"></asp:TextBox>
        </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TextBox_Penalizacion"
                Display="Dynamic" 
            ErrorMessage="Introduce la penalización por fallo del control" ForeColor="Red" 
            ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" 
            runat="server" ControlToValidate="TextBox_Penalizacion"
                Display="Dynamic" ErrorMessage="Separar la penalización por punto decimal" 
            ForeColor="Red" ValidationExpression="\d+\.\d+|\d+"
                ValidationGroup="Registro"></asp:RegularExpressionValidator>
    </p>
    <p class="style2">
    <div class="row_modificar_alumno">
        <asp:Button ID="Button_ModificarControl" runat="server" OnClick="Button_Modificar_Click"
                Text="Modificar" ValidationGroup="Registro"  CssClass="posicion_izquierda"/>
                &nbsp;
        <asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" CssClass="posicion_derecha" Text="Volver"
                 />
                 </div>
                 </p>
                 </div>
                 </div>
</asp:Content>
