<%@ Page Title="Eventos" Language="C#" MasterPageFile="~/Masters/SectionLayout.Master" 
    AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="PucpConnectPresentacion.templates.Events" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .event-card {
            border-radius: 8px;
            overflow: hidden;
            box-shadow: 0 2px 8px rgba(0,0,0,0.1);
            transition: all 0.3s ease;
            height: 100%;
        }
        .event-card:hover {
            transform: translateY(-5px);
            box-shadow: 0 5px 15px rgba(0,0,0,0.2);
        }
        .event-img {
            height: 160px;
            object-fit: cover;
            width: 100%;
        }
        .interest-badge {
            display: inline-block;
            background: #e9ecef;
            padding: 3px 8px;
            border-radius: 10px;
            font-size: 12px;
            margin: 2px;
        }
        .filter-chip {
            cursor: pointer;
            padding: 5px 15px;
            border-radius: 20px;
            background: #f8f9fa;
            border: 1px solid #dee2e6;
            margin: 3px;
        }
        .filter-chip:hover, .filter-chip.active {
            background: #0d6efd;
            color: white;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container py-4">
        <h2 class="mb-4">Eventos PUCP</h2>
        
        <!-- Filtro activo -->
        <asp:Panel ID="pnlFiltroActivo" runat="server" Visible="false" CssClass="mb-3">
            <div class="d-flex align-items-center">
                <span class="me-2">Filtro:</span>
                <span class="badge bg-primary me-2"><asp:Label ID="lblFiltroActivo" runat="server" /></span>
                <asp:LinkButton runat="server" OnClick="LimpiarFiltro" CssClass="text-danger">
                    <i class="fas fa-times"></i> Limpiar
                </asp:LinkButton>
            </div>
        </asp:Panel>
        
        <!-- Filtros -->
        <div class="mb-4">
            <h5 class="mb-2">Filtrar por interés:</h5>
            <div class="d-flex flex-wrap">
                <asp:Repeater ID="rptFiltrosIntereses" runat="server" OnItemCommand="FiltrarPorInteres">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" 
                            CommandArgument='<%# Eval("id") %>'
                            CssClass="filter-chip"
                            Text='<%# Eval("nombre") %>' />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        
        <!-- Resultados -->
        <asp:Panel ID="pnlEventos" runat="server">
            <div class="row">
                <asp:Repeater ID="rptEventos" runat="server">
                    <ItemTemplate>
                        <div class="col-md-4 mb-4">
                            <div class="card h-100 event-card">
                                <img src='<%# ObtenerRutaImagen(Eval("imagen")) %>' class="event-img" />
                                <div class="card-body">
                                    <h5><%# Eval("nombre") %></h5>
                                    <p class="text-muted">
                                        <i class="far fa-calendar-alt"></i> <%# FormatearFecha(Eval("fechaString")) %>
                                    </p>
                                    <p><%# Eval("descripcion") %></p>
                                    
                                    <div class="mb-3">
                                        <asp:Repeater runat="server" DataSource='<%# ObtenerInteresesEvento(Container.DataItem) %>'>
                                            <ItemTemplate>
                                                <span class="interest-badge"><%# Eval("nombre") %></span>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    
                                    <a href='<%# "EventProfile.aspx?id=" + Eval("idEvento") %>' 
                                       class="btn btn-primary btn-sm">
                                        Ver detalles
                                    </a>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </asp:Panel>
        
        <!-- Sin resultados -->
        <asp:Panel ID="pnlNoEventos" runat="server" Visible="false" CssClass="text-center py-5">
            <i class="far fa-calendar-times fa-3x text-muted mb-3"></i>
            <h4 class="mb-3"><asp:Label ID="lblNoResultados" runat="server" /></h4>
            <asp:Button runat="server" Text="Mostrar todos" OnClick="LimpiarFiltro" 
                CssClass="btn btn-outline-primary" />
        </asp:Panel>
        
        <!-- Error -->
        <asp:Label ID="lblError" runat="server" Visible="false" 
            CssClass="alert alert-danger d-block mt-3" />
    </div>
</asp:Content>