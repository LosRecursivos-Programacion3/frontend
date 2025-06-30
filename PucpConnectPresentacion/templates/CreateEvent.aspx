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
        </div>

        <!-- Derecha -->
        <div class="col-md-6">
            <div class="mb-3">
                <label>Descripción del evento</label>
                <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="8" CssClass="form-control" />
            </div>
            
            <!-- Sección de Intereses -->
            <div class="mb-3">
                <label>Intereses relacionados</label>
                <div class="border p-2" style="max-height: 150px; overflow-y: auto;">
                    <asp:CheckBoxList ID="chkIntereses" runat="server">
                        <asp:ListItem Text="Tecnología" Value="1" />
                        <asp:ListItem Text="Deportes" Value="2" />
                        <asp:ListItem Text="Arte" Value="3" />
                        <asp:ListItem Text="Ciencia" Value="4" />
                        <asp:ListItem Text="Música" Value="5" />
                    </asp:CheckBoxList>
                </div>
            </div>
            
            <div class="text-end">
                <asp:Button ID="btnCrear" runat="server" CssClass="btn btn-primary rounded-pill px-4 fw-bold" Text="Crear" OnClick="btnCrear_Click" />
            </div>
        </div>
    </div>
    
    <!--Modal exitoso-->
    <div class="modal fade" id="successModal" tabindex="-1" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-success text-white">
                    <h5 class="modal-title">¡Éxito!</h5>
                    <button type="button" class="btn-close btn-close-white" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <p>El evento se ha creado correctamente.</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success" data-bs-dismiss="modal">Aceptar</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Script para mostrar el modal -->
    <script type="text/javascript">
        function showSuccessModal() {
            var myModal = new bootstrap.Modal(document.getElementById('successModal'), {
                keyboard: false
            });
            myModal.show();

            // Redirigir después de cerrar el modal
            document.getElementById('successModal').addEventListener('hidden.bs.modal', function () {
                window.location.href = 'Events.aspx';
            });
        }
    </script>
</asp:Content>