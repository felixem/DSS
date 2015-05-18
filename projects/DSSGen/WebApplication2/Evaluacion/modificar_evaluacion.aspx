<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="modificar_evaluacion.aspx.cs" Inherits="DSSGenNHibernate.Evaluacion.modificar_evaluacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/utilities/centrar_contenido.css" rel="stylesheet" 
        type="text/css" />
    <link href="../Styles/utilities/tabla_dos_columnas.css" rel="stylesheet" 
        type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 
    <div class="CentrarContenido">
        <div class="ContenedorInterno">
        <div class="row_textbox_medium">
            <div class="posicion_izquierda">Nombre de la evaluación: </div>
            <div class="posicion_derecha"><asp:TextBox ID="TextBox_Nombre" runat="server"></asp:TextBox></div>
        </div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox_Nombre"
                Display="Dynamic" ErrorMessage="Introduce nombre de evaluación" 
            ForeColor="Red" ValidationGroup="Registro"></asp:RequiredFieldValidator>
        <div class="row_textbox_medium">
            <div class="posicion_izquierda">Fecha de inicio:</div>
            <div class="posicion_derecha">
                       <asp:DropDownList ID="ddlAno" runat="server" OnSelectedIndexChanged="ddlAno_SelectedIndexChanged" CssClass="posicion_derecha"
                            AutoPostBack="True">
                        </asp:DropDownList> 
                         <asp:DropDownList ID="ddlMes" runat="server" OnSelectedIndexChanged="ddlMes_SelectedIndexChanged" CssClass="posicion_derecha"
                            AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlDia" runat="server" AutoPostBack="True" CssClass="posicion_derecha" >
                        </asp:DropDownList>
            </div>
        </div>
                       
        <div class="row_textbox_medium">
            <div class="posicion_izquierda">Fecha de fin: </div>
            <div class="posicion_derecha">
                        <asp:DropDownList ID="ddlAnoC" runat="server" OnSelectedIndexChanged="ddlAnoC_SelectedIndexChanged" CssClass="posicion_derecha"
                            AutoPostBack="True">
                       </asp:DropDownList>
                       <asp:DropDownList ID="ddlMesC" runat="server" OnSelectedIndexChanged="ddlMesC_SelectedIndexChanged" CssClass="posicion_derecha"
                            AutoPostBack="True">
                       </asp:DropDownList>
                       <asp:DropDownList ID="ddlDiaC" runat="server" AutoPostBack="True" CssClass="posicion_derecha" >
                       </asp:DropDownList>
            </div>
        </div>
        
        <div class="row_textbox_medium">
            <div class="posicion_izquierda">Abierta 
            <asp:CheckBox ID="CheckBox_Abierta" runat="server" />
            </div>
        </div>
        <asp:Button ID="Button_ModificarEvaluacion" runat="server" OnClick="Button_Modificar_Click"
                Text="Modificar" ValidationGroup="Registro"  />
                &nbsp;
        <asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" Text="Volver"
                 />
    
    </div>
    </div>
</asp:Content>

