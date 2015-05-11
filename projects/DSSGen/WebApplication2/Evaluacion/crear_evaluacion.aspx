<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="crear_evaluacion.aspx.cs" Inherits="DSSGenNHibernate.Evaluacion.crear_evaluacion" %>
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
        Fecha de inicio:
                       <asp:DropDownList ID="ddlAno" runat="server" OnSelectedIndexChanged="ddlAno_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList> 
                         <asp:DropDownList ID="ddlMes" runat="server" OnSelectedIndexChanged="ddlMes_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlDia" runat="server" AutoPostBack="True">
                        </asp:DropDownList>
                       
                        
    </p>
    <p>
        Fecha de fin: 
                        <asp:DropDownList ID="ddlAnoC" runat="server" OnSelectedIndexChanged="ddlAnoC_SelectedIndexChanged"
                            AutoPostBack="True">
                       </asp:DropDownList>
                       <asp:DropDownList ID="ddlMesC" runat="server" OnSelectedIndexChanged="ddlMesC_SelectedIndexChanged"
                            AutoPostBack="True">
                       </asp:DropDownList>
                       <asp:DropDownList ID="ddlDiaC" runat="server" AutoPostBack="True">
                       </asp:DropDownList>
                       
                       
    </p>
    <p>
        Abierta 
        <asp:CheckBox ID="CheckBox_Abierta" runat="server" />
    </p>
    <p>
             Año academico
        <asp:DropDownList ID="DropDownList_Anyos" runat="server" 
                    AutoPostBack="True">
                </asp:DropDownList>
    </p>
    <p>
        <asp:Button ID="Button_RegControl" runat="server" OnClick="Button_Evaluacion_Click" Text="Crear"
                ValidationGroup="Registro" />
        <asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" Text="Volver"
                 />
        <asp:Button ID="Button_LimpCampos" runat="server" OnClick="Button_Clean_Click" Text="Limpiar Campos"
                 /></p>

</asp:Content>
