<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="modificar_evaluacion.aspx.cs" Inherits="DSSGenNHibernate.Evaluacion.modificar_evaluacion" %>
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
        <asp:Button ID="Button_ModificarEvaluacion" runat="server" OnClick="Button_Modificar_Click"
                Text="Modificar" ValidationGroup="Registro"  />
                &nbsp;
        <asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" Text="Volver"
                 /></p>
    </p>
</asp:Content>

