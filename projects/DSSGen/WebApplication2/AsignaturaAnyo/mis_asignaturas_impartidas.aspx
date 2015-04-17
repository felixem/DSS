<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="mis_asignaturas_impartidas.aspx.cs" Inherits="DSSGenNHibernate.AsignaturaAnyo.mis_asignaturas_impartidas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/utilities/maqueta_tabla.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/utilities/centrar_contenido.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="CentrarContenido">
        <div class="ConInternoSinDisplay">
            <asp:Panel ID="Panel1" runat="server" CssClass="ContenedorInterno">
                <asp:Label ID="Label_Asignatura" runat="server" Text="Listado de Asignaturas impartidas"></asp:Label>
            </asp:Panel>
        </div>
        <div class="row_crear_alumno">
            <asp:Label ID="Label_Anyo" runat="server" Text="Año académico" CssClass="posicion_izquierda"></asp:Label>
            <asp:DropDownList ID="DropDownList_Anyos" runat="server" CssClass="posicion_derecha"
                OnSelectedIndexChanged="DropDownList_Anyos_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>
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
                <asp:Button ID="Button_Crear" runat="server" Text="Registrar Asignatura en Año" OnClick="Button_Crear_Click" />
                <asp:GridView ID="GridViewBolsas" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField HeaderText="Id" DataField="Id" />
                        <asp:BoundField HeaderText="Curso" DataField="Asignatura.Curso.Nombre" />
                        <asp:BoundField HeaderText="Código" DataField="Asignatura.Cod_asignatura" />
                        <asp:BoundField HeaderText="Nombre" DataField="Asignatura.Nombre" />
                        <asp:BoundField HeaderText="Descripción" DataField="Asignatura.Descripcion" />
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="linkAlumnos" OnClick="lnkAlumnos_Click">Matriculados</asp:LinkButton>
                                <asp:LinkButton runat="server" ID="linkGrupos" OnClick="lnkGrupos_Click">Grupos</asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lnkEliminar" OnClick="lnkEliminar_Click">Desvincular</asp:LinkButton>
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
