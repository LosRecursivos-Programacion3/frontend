<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/ProfileSettings.Master" AutoEventWireup="true" CodeBehind="ProfileModify.aspx.cs" Inherits="PucpConnectPresentacion.templates.ProfileModify" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="profile-config-form">
        <h2 class="mb-4">Configuración de Perfil</h2>

        <asp:Label ID="lblNombre" runat="server" Text="Nombre completo:" CssClass="form-label"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />

        <asp:Label ID="lblDescripcion" runat="server" Text="Descripción:" CssClass="form-label"></asp:Label>
        <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" />

        <asp:Label ID="lblEspecialidades" runat="server" Text="Especialidades:" CssClass="form-label"></asp:Label>
        <asp:TextBox ID="txtEspecialidades" runat="server" CssClass="form-control" />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="btnGuardar mt-3" />
    </div>
</asp:Content>
