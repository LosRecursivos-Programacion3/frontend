<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Profile.Master" AutoEventWireup="true" CodeBehind="FriendRequests.aspx.cs" Inherits="PucpConnectPresentacion.templates.FriendRequests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .section-title {
            background-color: #0d326f;
            color: white;
            padding: 12px 20px;
            font-size: 1.2rem;
            font-weight: 600;
            border-radius: 12px 12px 0 0;
        }
        .card-container {
            background-color: #ffffff;
            border-radius: 0 0 12px 12px;
            padding: 20px;
            box-shadow: 0 2px 6px rgba(0,0,0,0.1);
            margin-bottom: 30px;
        }
        table {
            width: 100%;
        }
        .table td, .table th {
            vertical-align: middle;
        }
        .btn-action {
            margin: 0 3px;
        }
        .user-info {
            display: flex;
            align-items: center;
            gap: 10px;
        }

        .user-info img {
            width: 60px;
            height: 60px;
            object-fit: cover;
            border-radius: 50%;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="card shadow-sm rounded-4 overflow-hidden">
            <!-- Cabecera del perfil -->
            <div class="card-body d-flex align-items-center border-bottom">
                <asp:Image ID="imgPerfil" runat="server" CssClass="rounded-circle me-3" Width="60px" Height="60px" AlternateText="Foto perfil" />
                <div>
                    <h4 class="mb-0"><asp:Label ID="lblNombrePerfil" runat="server" CssClass="fw-bold"></asp:Label></h4>
                    <small class="text-muted">Solicitudes de amistad</small>
                </div>
            </div>

            <!-- Sección: Enviadas -->
            <div class="section-title">Solicitudes Enviadas</div>
            <div class="card-container">
                <asp:Label ID="lblSinSolicitudesEnviadas" runat="server" CssClass="text-center text-muted d-block my-3" Visible="false" Text="Usted no ha enviado solicitudes."></asp:Label>
                <asp:GridView ID="gvSolicitudesEnviadas" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" OnRowCommand="gvSolicitudesEnviadas_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Destinatario">
                            <ItemTemplate>
                                <div class="user-info">
                                    <img src='<%# Eval("fotoPerfilAlumnoDos", "../Images/{0}") %>' alt="Foto perfil" />
                                    <%# Eval("nombreAlumnoDos") %>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="fecha" HeaderText="Fecha de envío" HtmlEncode="false" />
                        <asp:TemplateField HeaderText="Acción">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnCancelar" runat="server" CommandName="Cancelar" CommandArgument='<%# Eval("idAmistad") %>' CssClass="btn btn-danger btn-sm">
                                    <i class="fas fa-trash"></i>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

            <!-- Sección: Recibidas -->
            <div class="section-title">Solicitudes Recibidas</div>
            <div class="card-container">
                <asp:Label ID="lblSinSolicitudesRecibidas" runat="server" CssClass="text-center text-muted d-block my-3" Visible="false" Text="Usted no tiene solicitudes pendientes."></asp:Label>
                <asp:GridView ID="gvSolicitudesRecibidas" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" OnRowCommand="gvSolicitudesRecibidas_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Remitente">
                            <ItemTemplate>
                                <div class="user-info">
                                    <img src='<%# Eval("fotoPerfilAlumnoUno", "../Images/{0}") %>' alt="Foto perfil" />
                                    <%# Eval("nombreAlumnoUno") %>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="fecha" HeaderText="Fecha de envío" HtmlEncode="false" />
                        <asp:TemplateField HeaderText="Acción">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnAceptar" runat="server" CommandName="Aceptar" CommandArgument='<%# Eval("idAmistad") %>' CssClass="btn btn-success btn-sm btn-action">
                                    <i class="fas fa-check"></i>
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnRechazar" runat="server" CommandName="Rechazar" CommandArgument='<%# Eval("idAmistad") %>' CssClass="btn btn-danger btn-sm btn-action">
                                    <i class="fas fa-times"></i>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>