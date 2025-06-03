<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Create.Master" AutoEventWireup="true" CodeBehind="CreateEvent.aspx.cs" Inherits="PucpConnectPresentacion.templates.CreateEvent" %>
<asp:Content ID="TitleContent" ContentPlaceHolderID="TitleContent" runat="server">
    Crear Nuevo Evento
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <h5 class="fw-bold mb-4">Crear Nuevo Evento</h5>
    <div class="row">
        <!-- Izquierda -->
        <div class="col-md-6 border-end">
            <div class="mb-3">
                <label class="text-primary fw-semibold">Nombre del evento</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control border-0 border-bottom rounded-0" placeholder="Escriba el nombre del evento" />
            </div>
            <div class="row">
                <div class="col-md-6 mb-3">
                    <label>Fecha evento</label>
                    <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="Date" CssClass="form-control" />
                </div>
                <div class="col-md-6 mb-3">
                    <label>Fecha fin</label>
                    <asp:TextBox ID="txtFechaFin" runat="server" TextMode="Date" CssClass="form-control" />
                </div>
                <div class="col-md-6 mb-3">
                    <label>Hora inicio</label>
                    <asp:TextBox ID="txtHoraInicio" runat="server" TextMode="Time" CssClass="form-control" />
                </div>
                <div class="col-md-6 mb-3">
                    <label>Hora fin</label>
                    <asp:TextBox ID="txtHoraFin" runat="server" TextMode="Time" CssClass="form-control" />
                </div>
            </div>
            <div class="mb-3">
                <label>Ubicación</label>
                <asp:TextBox ID="txtUbicacion" runat="server" CssClass="form-control border-0 border-bottom rounded-0" />
            </div>
            <div class="mb-3">
                <label>¿Presencial o Virtual?</label>
                <asp:DropDownList ID="ddlModalidad" runat="server" CssClass="form-select">
                    <asp:ListItem Text="Presencial" Value="Presencial" />
                    <asp:ListItem Text="Virtual" Value="Virtual" />
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label class="d-block">Privacidad</label>
                <div class="form-check">
                    <asp:RadioButton ID="rbPrivado" runat="server" GroupName="Privacidad" CssClass="form-check-input" />
                    <label class="form-check-label">Privado</label>
                </div>
                <div class="form-check">
                    <asp:RadioButton ID="rbPublico" runat="server" GroupName="Privacidad" CssClass="form-check-input" />
                    <label class="form-check-label">Público</label>
                </div>
                <div class="form-check">
                    <asp:RadioButton ID="rbGrupo" runat="server" GroupName="Privacidad" CssClass="form-check-input" />
                    <label class="form-check-label">Grupo</label>
                </div>
            </div>
        </div>

        <!-- Derecha -->
        <div class="col-md-6">
            <div class="mb-3">
                <label>Sobre el evento...</label>
                <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="8" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:FileUpload ID="fuImagen" runat="server" CssClass="form-control" />
                <small class="text-primary d-block mt-1">
                    <i class="bi bi-image"></i> Agregar imagen
                </small>
            </div>
            <div class="text-end">
                <asp:Button ID="btnCrear" runat="server" CssClass="btn btn-primary rounded-pill px-4 fw-bold" Text="Crear" />
            </div>
        </div>
    </div>
</asp:Content>