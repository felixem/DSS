<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="crear_entrega.aspx.cs" Inherits="DSSGenNHibernate.Entrega.crear_entrega" %>
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
    <h1 class="style2">
        Crear Entrega</h1>
    <div class="CentrarContenido" style="width: 450px;">
    <div class="ContenedorInterno">
    <div class="row_textbox_medium">
        <div class="posicion_izquierda">Nombre</div>
        <asp:TextBox ID="TextBox_NomControl" runat="server" CssClass="posicion_derecha"></asp:TextBox>
    </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox_NomControl"
                Display="Dynamic" ErrorMessage="Introduce Nombre" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBox_NomControl"
                Display="Dynamic" ErrorMessage="Introduce nombre válido" ForeColor="Red" ValidationExpression="\D+"
                ValidationGroup="Registro"></asp:RegularExpressionValidator>

    <div class="row_textbox_medium">
        <div class="posicion_izquierda">Descripcion</div>
        <asp:TextBox ID="TextBox_DescControl" runat="server" CssClass="posicion_derecha"></asp:TextBox>
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
            <asp:DropDownList ID="ddlDia" runat="server" AutoPostBack="True" CssClass="posicion_derecha">
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
        <asp:TextBox ID="TextBox_PuntControl" runat="server" CssClass="posicion_derecha"></asp:TextBox>
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
    
    <div class="row_textbox_medium">
        <div class="posicion_izquierda">Año academico</div>
        <asp:DropDownList ID="DropDownList_Anyos" runat="server" CssClass="posicion_derecha"
                    OnSelectedIndexChanged="DropDownList_Anyos_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
    </div>
    <div class="row_textbox_medium">
        <div class="posicion_izquierda">Asignatura</div>
        <asp:DropDownList ID="DropDownList_AsignaturasAnyo" runat="server" CssClass="posicion_derecha"
                    OnSelectedIndexChanged="DropDownList_AsignaturasAnyo_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
    </div>
    <div class="row_textbox_medium">
        <div class="posicion_izquierda">Evaluacion</div>
        <asp:DropDownList ID="DropDownList_SistemaEvaluacion" runat="server" CssClass="posicion_derecha">
        </asp:DropDownList>
    </div>
    <div class="row_textbox_medium">
        <div class="posicion_izquierda">Profesor</div>
        <asp:DropDownList ID="DropDownList_Profesores" CssClass="posicion_derecha" runat="server">
        </asp:DropDownList>
    </div>
    

        <asp:Button ID="Button_RegEntrega" runat="server" OnClick="Button_RegEntrega_Click" Text="Crear" CssClass="posicion_izquierda"
                ValidationGroup="Registro" />
        <asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" Text="Volver" CssClass="posicion_central"
                 />
        <asp:Button ID="Button_LimpCampos" runat="server" OnClick="Button_Clean_Click" Text="Limpiar Campos" CssClass="posicion_derecha"
                 />
    </div>
    </div>
</asp:Content>
