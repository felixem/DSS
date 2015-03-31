﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="bolsas_preguntas.aspx.cs" Inherits="DSSGenNHibernate.Examen.bases" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="23px" style="margin-bottom: 0px">
        <asp:Label ID="Label_Asignatura" runat="server" Text="Asignatura"></asp:Label>
        <br />
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" style="margin-top: 0px">
    <div>
        PageSize:
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageSize_Changed">
            <asp:ListItem Text="10" Value="10" />
            <asp:ListItem Text="25" Value="25" />
            <asp:ListItem Text="50" Value="50" />
        </asp:DropDownList>
        <hr />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField HeaderText="Id" DataField="Id" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:CommandField ShowCancelButton="False" ShowEditButton="True" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Repeater ID="rptPager" runat="server">
        <ItemTemplate>
            <asp:LinkButton ID="lnkPage" runat="server" Text = '<%#Eval("Text") %>' CommandArgument = '<%# Eval("Value") %>' Enabled = '<%# Eval("Enabled") %>' OnClick = "Page_Changed"></asp:LinkButton>
        </ItemTemplate>
        </asp:Repeater>
    </div>
    </asp:Panel>
    </asp:Content>
