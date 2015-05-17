<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="crear_entrega_asignatura.aspx.cs" Inherits="DSSGenNHibernate.Entrega.crear_entrega_asignatura" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="../Styles/submenu/login.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/utilities/tabla_dos_columnas.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/utilities/centrar_contenido.css" rel="stylesheet" 
        type="text/css" />
    <style type="text/css">
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <h1>
            Crear Entrega</h1>
    <div class="CentrarContenido">
        <div class="ContenedorInterno">
        <div class="row_margin_left">
            <div class="posicion_izquierda">Nombre</div>
            <div class="posicion_derecha"><asp:TextBox ID="TextBox_NomControl" runat="server"></asp:TextBox></div>
        </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox_NomControl"
                Display="Dynamic" ErrorMessage="Introduce Nombre" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBox_NomControl"
                Display="Dynamic" ErrorMessage="Introduce nombre válido" ForeColor="Red" ValidationExpression="\D+"
                ValidationGroup="Registro"></asp:RegularExpressionValidator>
    
        <div class="row_margin_left">
            <div class="posicion_izquierda">Descripcion</div>
            <div class="posicion_derecha"><asp:TextBox ID="TextBox_DescControl" runat="server"></asp:TextBox></div>
        </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox_DescControl"
                Display="Dynamic" ErrorMessage="Introduce Descripcion" ForeColor="Red" 
            ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" 
            runat="server" ControlToValidate="TextBox_DescControl"
                Display="Dynamic" ErrorMessage="Introduce descripcion válida" 
            ForeColor="Red" ValidationExpression="\D+"
                ValidationGroup="Registro"></asp:RegularExpressionValidator>
        
           <div class="row_modificar_alumno">
        Fecha Apertura 
        <div class="posicion_derecha">
            <asp:DropDownList ID="ddlAno" runat="server" AutoPostBack="True" CssClass="posicion_derecha"
                OnSelectedIndexChanged="ddlAno_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlMes" runat="server" AutoPostBack="True" CssClass="posicion_derecha"
                OnSelectedIndexChanged="ddlMes_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlDia" runat="server" AutoPostBack="True" CssClass="posicion_derecha" >
            </asp:DropDownList>
        </div>
    </div>
            </p>
    <p class="style2">
    <div class="row_modificar_alumno">
        Fecha Cierre 
        <div class="posicion_derecha">
            <asp:DropDownList ID="ddlAnoC" runat="server" AutoPostBack="True" 
                OnSelectedIndexChanged="ddlAnoC_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlMesC" runat="server" AutoPostBack="True" 
                OnSelectedIndexChanged="ddlMesC_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlDiaC" runat="server" AutoPostBack="True">
            </asp:DropDownList>
        </div>
        </div>
            </p>
    <p class="style2">
    <div class="row_modificar_alumno">
        <div class="posicion_izquierda">Puntuación </div>
        <div class="posicion_derecha"><asp:TextBox ID="TextBox_PuntControl" runat="server"></asp:TextBox></div>
        </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TextBox_PuntControl"
                Display="Dynamic" 
            ErrorMessage="Introduce la puntuación máxima de la entrega" ForeColor="Red" 
            ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" 
            runat="server" ControlToValidate="TextBox_PuntControl"
                Display="Dynamic" ErrorMessage="Separar la puntuación por punto decimal" 
            ForeColor="Red" ValidationExpression="\d+\.\d+|\d+"
                ValidationGroup="Registro"></asp:RegularExpressionValidator>
    <div class="row_margin_left">
        <div class="posicion_izquierda">Asignatura</div>
        <asp:TextBox ID="TextBox_Asignatura" runat="server"  CssClass="position_derecha_locked" 
                    ReadOnly="True" Width="171px"></asp:TextBox>
    </div>
    <div class="row_margin_left">
        <div class="posicion_izquierda">Evaluacion</div>
        <div class="posicion_derecha"><asp:DropDownList ID="DropDownList_SistemaEvaluacion" runat="server">
        </asp:DropDownList></div>
    </div>
        <asp:Button ID="Button_RegEntrega" runat="server" OnClick="Button_RegEntrega_Click" Text="Crear"
                ValidationGroup="Registro" />
        <asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" Text="Volver"
                 />
        <asp:Button ID="Button_LimpCampos" runat="server" OnClick="Button_Clean_Click" Text="Limpiar Campos"
                 />
    
    </div>
    </div>
</asp:Content>
