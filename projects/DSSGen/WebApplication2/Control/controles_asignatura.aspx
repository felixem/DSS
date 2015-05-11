﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="controles_asignatura.aspx.cs" Inherits="DSSGenNHibernate.Control.controles_asignatura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/utilities/maqueta_tabla.css" rel="stylesheet" 
        type="text/css" />
    <link href="../Styles/utilities/centrar_contenido.css" rel="stylesheet" 
        type="text/css" />
    <style type="text/css">
        .posicion_derecha
        {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="CentrarContenido">
    <div class="ConInternoSinDisplay">
    <asp:Panel ID="Panel1" runat="server" CssClass="ContenedorInterno">
        <h1><asp:Label ID="Label_Asignatura" runat="server" Text="Listado de Controles"></asp:Label></h1>
    </asp:Panel>
    </div>
    <asp:Panel ID="Panel2" runat="server" CssClass="ContenedorInterno">
            <asp:Label ID="Label1" runat="server" Text="Asignatura" CssClass="posicion_izquierda"></asp:Label>
            <asp:TextBox ID="TextBox_Asignatura" runat="server" ReadOnly="True" Width="172px" CssClass="background_locked"></asp:TextBox>
        <div class="">
            PageSize:
            <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageSize_Changed">
                <asp:ListItem Text="10" Value="10" />
                <asp:ListItem Text="25" Value="25" />
                <asp:ListItem Text="50" Value="50" />
            </asp:DropDownList>
            <hr />
            <asp:Button ID="Button_Crear" runat="server" Text="Crear control" OnClick="Button_Crear_Click" />
            <asp:Button ID="Button_Cancelar" runat="server" OnClick="Button_Cancelar_Click" CssClass="posicion_derecha" Text="Volver"/>
            <asp:GridView ID="GridViewBolsas" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField HeaderText="Id" DataField="Id" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Apertura" DataField="Fecha_apertura" />
                    <asp:BoundField HeaderText="Cierre" DataField="Fecha_cierre" />
                    <asp:BoundField HeaderText="Duracion" DataField="Duracion_minutos" />
                    <asp:BoundField HeaderText="Puntuacion Maxima" DataField="Puntuacion_maxima" />
                    <asp:BoundField HeaderText="Penalizacion Fallo" DataField="Penalizacion_fallo" />
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

