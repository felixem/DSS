<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="alumnos_grupo_trabajo.aspx.cs" Inherits="DSSGenNHibernate.GrupoTrabajo.alumnos_grupo_trabajo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/utilities/maqueta_tabla.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/utilities/centrar_contenido.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="CentrarContenido">
        <div class="ConInternoSinDisplay">
            <asp:Panel ID="Panel1" runat="server" CssClass="ContenedorInterno">
                <h1><asp:Label ID="Label_Listado" runat="server" Text="Listado de Alumnos en el Grupo de Trabajo"></asp:Label></h1>
            </asp:Panel>
        </div>
        <asp:Panel ID="Panel2" runat="server" CssClass="ContenedorInterno">
            <div class="row_crear_alumno">
                <asp:Label ID="Label_NombreGrupo" runat="server" Text="Grupo:" Style="color: #000000"
                    CssClass="posicion_izquierda"></asp:Label>
                <asp:TextBox ID="TextBox_NomGrupo" runat="server" CssClass="posicion_derecha" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="row_crear_alumno">
                <asp:Label ID="Label_Capacidad" runat="server" Text="Inscritos:" Style="color: #000000" CssClass="posicion_izquierda"></asp:Label>
                <asp:TextBox ID="TextBox_Capacidad" runat="server" CssClass="posicion_derecha" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="">
                PageSize:
                <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageSize_Changed">
                    <asp:ListItem Text="10" Value="10" />
                    <asp:ListItem Text="25" Value="25" />
                    <asp:ListItem Text="50" Value="50" />
                </asp:DropDownList>
                <hr />
                <asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" Text="Volver" />
                <asp:Button ID="Button_Crear" runat="server" Text="Añadir Alumnos" OnClick="Button_Crear_Click" />
                <asp:GridView ID="GridViewBolsas" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField HeaderText="Email" DataField="Email" />
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Apellidos" DataField="Apellidos" />
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="lnkEliminar" OnClick="lnkEliminar_Click">Expulsar</asp:LinkButton>
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
