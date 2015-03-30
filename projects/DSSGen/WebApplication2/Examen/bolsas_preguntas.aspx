<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="bolsas_preguntas.aspx.cs" Inherits="DSSGenNHibernate.Examen.bases" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="23px" style="margin-bottom: 0px">
        <asp:Label ID="Label_Asignatura" runat="server" Text="Asignatura"></asp:Label>
        <br />
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" style="margin-top: 0px">
    </asp:Panel>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
        CellPadding="4" DataSourceID="DataSourceBases">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" 
                SortExpression="Nombre" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" 
                SortExpression="Descripcion" />
            <asp:BoundField DataField="Fecha_creacion" HeaderText="Fecha_creacion" 
                SortExpression="Fecha_creacion" />
            <asp:BoundField DataField="Fecha_modificacion" HeaderText="Fecha_modificacion" 
                SortExpression="Fecha_modificacion" />
        </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />
    </asp:GridView>
    <asp:ObjectDataSource ID="DataSourceBases" runat="server" 
        SelectMethod="dameTodos" TypeName="Fachadas.Moodle.FachadaBolsaPreguntas">
        <SelectParameters>
            <asp:Parameter Name="first" Type="Int32" />
            <asp:Parameter Name="size" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </asp:Content>
