<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Profile.Master" 
    AutoEventWireup="true" CodeBehind="EventProfile.aspx.cs" 
    Inherits="PucpConnectPresentacion.templates.EventProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .banner {
            height: 250px;
            background-size: cover;
            background-position: center;
            background-color: #f8f9fa;
            margin-bottom: 20px;
        }
        .event-header {
            background: white;
            padding: 25px;
            border-radius: 8px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
            margin-bottom: 20px;
        }
        .event-icon {
            font-size: 1.2rem;
            margin-right: 8px;
            color: #6c757d;
        }
        .participantes-section {
            margin-top: 30px;
        }
        .participante-card {
            display: flex;
            align-items: center;
            padding: 10px;
            border-bottom: 1px solid #eee;
        }
        .participante-img {
            width: 40px;
            height: 40px;
            border-radius: 50%;
            margin-right: 15px;
            background-color: #f8f9fa;
            display: flex;
            align-items: center;
            justify-content: center;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <!-- Banner del Evento con imagen local -->
        <div id="eventBanner" runat="server" class="banner"></div>
        
        <!-- Encabezado -->
        <div class="event-header">
            <h2><asp:Literal ID="litNombreEvento" runat="server" /></h2>
            
            <div class="my-3">
                <p><i class="fas fa-calendar-day event-icon"></i>
                   <strong>Fecha:</strong> <asp:Literal ID="litFechaEvento" runat="server" /></p>
                
                <p><i class="fas fa-map-marker-alt event-icon"></i>
                   <strong>Ubicación:</strong> <asp:Literal ID="litUbicacion" runat="server" /></p>
                
                <p><i class="fas fa-users event-icon"></i>
                   <strong>Participantes:</strong> <asp:Literal ID="litNumParticipantes" runat="server" /></p>
            </div>
            
            <asp:Button ID="btnAsistir" runat="server" 
                Text="Confirmar Asistencia" 
                CssClass="btn btn-primary px-4" 
                OnClick="btnAsistir_Click" />
                
            <asp:Button ID="btnCancelarAsistencia" runat="server" 
                Text="Cancelar Asistencia" 
                CssClass="btn btn-outline-danger px-4 ms-2" 
                Visible="false"
                OnClick="btnCancelarAsistencia_Click" />
        </div>
        
        <!-- Descripción -->
        <div class="card mb-4">
            <div class="card-body">
                <h4 class="card-title">Descripción del Evento</h4>
                <p class="card-text"><asp:Literal ID="litDescripcion" runat="server" /></p>
            </div>
        </div>

        <!-- Lista de Participantes -->
        <div class="card participantes-section">
            <div class="card-body">
                <h4 class="card-title mb-4">Participantes</h4>
                
                <asp:Repeater ID="rptParticipantes" runat="server">
                    <ItemTemplate>
                        <div class="participante-card">
                            <div class="participante-img">
                                <i class="fas fa-user"></i>
                            </div>
                            <div>
                                <h6 class="mb-0"><%# Eval("Nombre") %></h6>
                                <small class="text-muted"><%# Eval("Carrera") %></small>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                
                <asp:Panel ID="pnlNoParticipantes" runat="server" Visible="false" CssClass="text-center py-3">
                    <p class="text-muted">Aún no hay participantes confirmados</p>
                </asp:Panel>
            </div>
        </div>

        <!-- Mensaje de error -->
        <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger mt-3" Visible="false" />
        <asp:Label ID="lblSuccess" runat="server" CssClass="alert alert-success mt-3" Visible="false" />
    </div>
    
    <!-- Modal de Confirmación -->
    <div class="modal fade" id="confirmCancelModal" tabindex="-1" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Confirmar cancelación</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <p>¿Estás seguro que deseas cancelar tu asistencia al evento?</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">No, mantener asistencia</button>
                    <asp:Button ID="btnConfirmarCancelacion" runat="server" Text="Sí, cancelar asistencia" 
                        CssClass="btn btn-danger" OnClick="btnCancelarAsistencia_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>