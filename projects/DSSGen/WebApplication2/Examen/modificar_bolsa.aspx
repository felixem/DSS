<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="modificar_bolsa.aspx.cs" Inherits="DSSGenNHibernate.Examen.modificar_bolsa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="301px">
        <asp:ValidationSummary ID="ValidationSummaryBolsa" runat="server" 
            ShowMessageBox="True" ShowSummary="False" ValidationGroup="GroupBolsa" />
        <asp:Label ID="Label_Nombre" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="TextBox_Nombre" runat="server" ValidationGroup="GroupBolsa"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Nombre" runat="server" 
            ControlToValidate="TextBox_Nombre" ErrorMessage="Se requiere un nombre" 
            ValidationGroup="GroupBolsa">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label_Descripcion" runat="server" Text="Descripcion"></asp:Label>
        <asp:TextBox ID="TextBox_Descripcion" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label_Asignatura" runat="server" Text="Asignatura"></asp:Label>
        <asp:DropDownList ID="DropDownList_Asignaturas" runat="server" 
            onselectedindexchanged="DropDownList_Asignaturas_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <asp:Button ID="Button_Guardar" runat="server" Text="Guardar bolsa" 
            ValidationGroup="GroupBolsa" OnClick = "Button_Guardar_Click" />
        <asp:Button ID="Button_Cancelar" runat="server" Text="Cancelar" OnClick="Button_Cancelar_Click"/>
        <br />
        <br />
        <div>
            PageSize:
            <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageSize_Changed">
                <asp:ListItem Text="10" Value="10" />
                <asp:ListItem Text="25" Value="25" />
                <asp:ListItem Text="50" Value="50" />
            </asp:DropDownList>
            <hr />
            <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" Text="Añadir Pregunta" />
            <asp:GridView ID="GridViewPreguntas" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField HeaderText="Id" DataField="Id" />
                    <asp:BoundField HeaderText="Contenido" DataField="Contenido" />
                    <asp:BoundField HeaderText="Respuesta correcta" DataField="Respuesta_correcta.Contenido" />
                    <asp:BoundField HeaderText="Explicación" DataField="Explicacion" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lnkEditar" OnClick="lnkEditar_Click">Editar</asp:LinkButton>
                            <asp:LinkButton runat="server" ID="lnkEliminar" OnClick="lnkEliminar_Click">Eliminar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Repeater ID="rptPager" runat="server">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                        Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </asp:Panel>
</asp:Content>
