<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="modificar_entrega.aspx.cs" Inherits="DSSGenNHibernate.Entrega.modificar_entrega" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="../Styles/submenu/login.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/utilities/tabla_dos_columnas.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/utilities/centrar_contenido.css" rel="stylesheet" 
        type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1 style="margin-left:-25px;">
        Modificar Entrega</h1>
    <div class="CentrarContenido" style="width: 450px;">
    <div class="ContenedorInterno">
        <div class="row_textbox_medium">
            <div class="posicion_izquierda">Año Academico</div>
            <asp:TextBox ID="TextBox_Anyo" runat="server" CssClass="position_derecha_locked"
                    ReadOnly="True"></asp:TextBox>
        </div>
    
        <div class="row_textbox_medium">
        <div class="posicion_izquierda">Asignatura</div>
                <asp:TextBox ID="TextBox_Asignatura" runat="server" CssClass="position_derecha_locked"
                    ReadOnly="True"  Width="185px"></asp:TextBox>
        </div>
    
    <div class="row_textbox_medium">
        <div class="posicion_izquierda">Evaluación</div>
        <asp:TextBox ID="TextBox_Evaluacion" runat="server" CssClass="position_derecha_locked"
                    ReadOnly="True"></asp:TextBox>
    </div>
    <div class="row_textbox_medium">
        <div class="posicion_izquierda">Profesor</div>
        <asp:TextBox ID="TextBox_Profesor" runat="server" CssClass="position_derecha_locked"
                    ReadOnly="True"></asp:TextBox>
    </div>
    <div class="row_textbox_medium">
        <div class="posicion_izquierda">Cod Entrega</div>
        <asp:TextBox ID="TextBox_CodEntrega" runat="server" CssClass="position_derecha_locked"
                    ReadOnly="True"></asp:TextBox>
    </div>
    <div class="row_textbox_medium">
        <div class="posicion_izquierda">Nombre</div>
        <div class="posicion_derecha"><asp:TextBox ID="TextBox_Nom" runat="server"></asp:TextBox></div>
     </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox_Nom"
                Display="Dynamic" ErrorMessage="Introduce Nombre" ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBox_Nom"
                Display="Dynamic" ErrorMessage="Introduce nombre válido" ForeColor="Red" ValidationExpression="\D+"
                ValidationGroup="Registro"></asp:RegularExpressionValidator>
    
    <div class="row_textbox_medium">
        <div class="posicion_izquierda">Descripcion</div>
        <div class="posicion_derecha"><asp:TextBox ID="TextBox_Desc" runat="server"></asp:TextBox></div>
    </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox_Desc"
                Display="Dynamic" ErrorMessage="Introduce Descripcion" ForeColor="Red" 
            ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" 
            runat="server" ControlToValidate="TextBox_Desc"
                Display="Dynamic" ErrorMessage="Introduce descripcion válida" 
            ForeColor="Red" ValidationExpression="\D+"
                ValidationGroup="Registro"></asp:RegularExpressionValidator>
    <p class="style2">
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
        <div class="posicion_derecha"><asp:TextBox ID="TextBox_Punt" runat="server"></asp:TextBox></div>
    </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TextBox_Punt"
                Display="Dynamic" 
            ErrorMessage="Introduce la puntuación máxima de la entrega" ForeColor="Red" 
            ValidationGroup="Registro"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" 
            runat="server" ControlToValidate="TextBox_Punt"
                Display="Dynamic" ErrorMessage="Separar la puntuación por punto decimal" 
            ForeColor="Red" ValidationExpression="\d+\.\d+|\d+"
                ValidationGroup="Registro"></asp:RegularExpressionValidator>
    
    <div class="row_textbox_medium">
        <asp:Button ID="Button_Modificar" runat="server" OnClick="Button_Modificar_Click" CssClass="posicion_izquierda"
                Text="Modificar" ValidationGroup="Registro"  />
                &nbsp;
        <asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" Text="Volver" CssClass="posicion_derecha"
                 />
    </div>

    </div>
    </div>
</asp:Content>
