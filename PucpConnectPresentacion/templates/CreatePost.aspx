<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Create.Master" AutoEventWireup="true" CodeBehind="CreatePost.aspx.cs" Inherits="PucpConnectPresentacion.templates.CreatePost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Crear Nueva Publicación
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h5 class="mb-4 fw-semibold">Crear Nueva Publicación</h5>

    <!-- Área de publicación -->
    <div class="mb-4">
        <label class="form-label fw-semibold text-primary">Contenido</label>
        <asp:TextBox ID="txtContenido" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="6" placeholder="Ingresa publicación..."></asp:TextBox>
    </div>

    <!-- Multimedia y etiquetado -->
    <div class="row g-3">
        <!-- Multimedia -->
        <div class="col-md-6">
            <label class="form-label fw-semibold text-primary">Multimedia</label>
            <div class="input-group">
                <asp:FileUpload ID="fuImagen" runat="server" CssClass="form-control" />
            </div>
        </div>

        <!-- Línea divisoria + Etiquetar Contactos -->
        <div class="col-md-6 border-start ps-4">
            <label class="form-label fw-semibold">Etiquetar Contacto:</label>
            <div class="form-check">
                <asp:CheckBox ID="chkDavid" runat="server" CssClass="form-check-input" />
                <label class="form-check-label" for="chkDavid">
                    <i class="bi bi-person-circle me-1"></i> David Allasi
                </label>
            </div>
            <div class="form-check">
                <asp:CheckBox ID="chkMiguel" runat="server" CssClass="form-check-input" />
                <label class="form-check-label" for="chkMiguel">
                    <i class="bi bi-person-circle me-1"></i> Miguel Galvez
                </label>
            </div>
        </div>
    </div>

    <!-- Botón Crear -->
    <div class="d-flex justify-content-end mt-4">
        <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="btn btn-primary px-4 rounded-pill" />
    </div>
</asp:Content>