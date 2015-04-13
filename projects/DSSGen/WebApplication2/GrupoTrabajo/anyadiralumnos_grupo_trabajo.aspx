<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="anyadiralumnos_grupo_trabajo.aspx.cs" Inherits="DSSGenNHibernate.GrupoTrabajo.anyadiralumnos_grupo_trabajo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/utilities/maqueta_tabla.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/utilities/centrar_contenido.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="CentrarContenido">
        <div class="ConInternoSinDisplay">
            <asp:Panel ID="Panel1" runat="server" CssClass="ContenedorInterno">
                <asp:Label ID="Label_Listado" runat="server" Text="Listado de Alumnos que pueden ser añadidos al Grupo de Trabajo"></asp:Label>
            </asp:Panel>
        </div>
        <asp:Panel ID="Panel2" runat="server" CssClass="ContenedorInterno">
            <div class="row_crear_alumno">
                <asp:Label ID="Label_Asignatura" runat="server" Text="Asignatura" CssClass="posicion_izquierda"></asp:Label>
                <asp:TextBox ID="TextBox_Asignatura" runat="server" CssClass="posicion_derecha" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="row_crear_alumno">
                <asp:Label ID="LabelCod_Grupo" runat="server" Text="Código de Grupo:" CssClass="posicion_izquierda"></asp:Label>
                <asp:TextBox ID="TextBox_CodGrupo" runat="server" CssClass="posicion_derecha" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="row_crear_alumno">
                <asp:Label ID="Label_NombreGrupo" runat="server" Text="Nombre:" Style="color: #000000"
                    CssClass="posicion_izquierda"></asp:Label>
                <asp:TextBox ID="TextBox_NomGrupo" runat="server" CssClass="posicion_derecha" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="row_crear_alumno">
                <asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" Text="Volver" />
            </div>
            <div class="">
                PageSize:
                <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageSize_Changed">
                    <asp:ListItem Text="10" Value="10" />
                    <asp:ListItem Text="25" Value="25" />
                    <asp:ListItem Text="50" Value="50" />
                </asp:DropDownList>
                <hr />
                <asp:GridView ID="GridViewBolsas" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField HeaderText="Email" DataField="Email" />
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Apellidos" DataField="Apellidos" />
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="lnkAnyadir" OnClick="lnkAnyadir_Click">Añadir</asp:LinkButton>
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
