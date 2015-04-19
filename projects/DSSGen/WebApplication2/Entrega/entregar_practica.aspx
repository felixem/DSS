<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="entregar_practica.aspx.cs" Inherits="DSSGenNHibernate.Entrega.entregar_practica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Styles/submenu/login.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/utilities/tabla_dos_columnas.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style2
        {
            color: #000000;
        }
    </style>
    <script type="text/javascript">
        function comprueba() {
            return confirm("Confirme el envío");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="InicioSesion">
        <h1>
            Subir Imagen</h1>
        <div id="mainSubirImagen" class="mainSubirImagen">
            <div id="centrarImagenProvisional" class="centrarImagen">
                <asp:Image ID="ImagenProvisional" runat="server" Height="240px" Width="277px" />
            </div>
            <div id="botonesSubirImagen">
                <asp:FileUpload ID="FileUploadControl" runat="server" />
                <asp:Button runat="server" ID="GuardarCambios" Text="Guardar Cambios" OnClick="GuardarCambios_Click"
                    OnClientClick="return comprueba();" />
                <asp:Button runat="server" ID="UploadButton" Text="Subir" OnClick="UploadButton_Click" />
                <div id="cajaStatusLabel">
                    <asp:Label runat="server" ID="StatusLabel" Text="Estado de subida: " /></div>
            </div>
        </div>
    </div>
</asp:Content>
