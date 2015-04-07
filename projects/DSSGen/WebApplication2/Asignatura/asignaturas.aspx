<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="asignaturas.aspx.cs" Inherits="DSSGenNHibernate.Asignatura.asignaturas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/examen/maqueta_tabla.css" rel="stylesheet" 
        type="text/css" />
    <link href="../Styles/examen/centrar_contenido.css" rel="stylesheet" 
        type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="CentrarContenido">
    <div class="ConInternoSinDisplay">
    <asp:Panel ID="Panel1" runat="server" CssClass="ContenedorInterno">
        <asp:Label ID="Label_Asignatura" runat="server" Text="Listado de Alumnos"></asp:Label>
    </asp:Panel>
    </div>
    <asp:Panel ID="Panel2" runat="server" CssClass="ContenedorInterno">
        <div class="">
            PageSize:
            <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageSize_Changed">
                <asp:ListItem Text="10" Value="10" />
                <asp:ListItem Text="25" Value="25" />
                <asp:ListItem Text="50" Value="50" />
            </asp:DropDownList>
            <hr />
            <asp:Button ID="Button_Crear" runat="server" Text="Crear alumno" OnClick="Button_Crear_Click" />
            <asp:GridView ID="GridViewBolsas" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField HeaderText="Id" DataField="Id" />
                    <asp:BoundField HeaderText="Código de Asignatura" DataField="Cod_asignatura" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Optativa" DataField="Optativa" />
                    <asp:BoundField HeaderText="Vigente" DataField="Vigente" />
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
        </div>
    </asp:Panel>
    </div>
</asp:Content>
