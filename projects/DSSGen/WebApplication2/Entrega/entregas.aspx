﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="entregas.aspx.cs" Inherits="DSSGenNHibernate.Entrega.entregas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/utilities/maqueta_tabla.css" rel="stylesheet" 
        type="text/css" />
    <link href="../Styles/utilities/centrar_contenido.css" rel="stylesheet" 
        type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="CentrarContenido">
    <div class="ConInternoSinDisplay">
    <asp:Panel ID="Panel1" runat="server" CssClass="ContenedorInterno">
        <h1><asp:Label ID="Label_Asignatura" runat="server" Text="Listado de Entregas"></asp:Label></h1>
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
            <asp:Button ID="Button_Crear" runat="server" Text="Crear entrega" OnClick="Button_Crear_Click" />
            <asp:GridView ID="GridViewBolsas" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField HeaderText="Id" DataField="Id" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Apertura" DataField="Fecha_apertura" />
                    <asp:BoundField HeaderText="Cierre" DataField="Fecha_cierre" />
                    <asp:BoundField HeaderText="Puntuacion Maxima" DataField="Puntuacion_maxima" />
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

