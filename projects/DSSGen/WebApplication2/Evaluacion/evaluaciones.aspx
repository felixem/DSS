<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="evaluaciones.aspx.cs" Inherits="DSSGenNHibernate.Evaluacion.evaluaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageSize_Changed">
                <asp:ListItem Text="10" Value="10" />
                <asp:ListItem Text="25" Value="25" />
                <asp:ListItem Text="50" Value="50" />
            </asp:DropDownList>
            <hr />
            <asp:Button ID="Button_Crear" runat="server" Text="Crear control" OnClick="Button_Crear_Click" />
            <asp:GridView ID="GridViewBolsas" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField HeaderText="Id" DataField="Id" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Inicio" DataField="Inicio" />
                    <asp:BoundField HeaderText="Fin" DataField="Fin" />
                    <asp:BoundField HeaderText="Abierta" DataField="Abierta" />
                    <asp:BoundField HeaderText="Año académico" DataField="Anyo" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lnkEditar" OnClick="lnkEditar_Click">Editar</asp:LinkButton>
                            <asp:LinkButton runat="server" ID="lnkEliminar" OnClick="lnkEliminar_Click">Eliminar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Repeater ID="rptPager" runat="server">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                        Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                </ItemTemplate>
            </asp:Repeater>
</asp:Content>
