<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Profile.Master" AutoEventWireup="true" CodeBehind="Profile-Events.aspx.cs" Inherits="PucpConnectPresentacion.templates.Profile_Events" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Contenido principal -->
    <div class="col-md-12 p-0">
        <!-- Cabecera -->
       <div class="banner">
            <img src="../Images/profile-banner-0.jpeg" alt="Foto perfil" />
        </div>
        <div class="p-4 information-box" background-size: cover;>
            <div class="d-flex align-items-center">
                <div class="col-img">
                    <div class="avatar">
                        <asp:Image ID="imgPerfil" runat="server" CssClass="rounded-circle me-3" AlternateText="Foto perfil" />
                    </div>
                </div>
                <div class="col-text">
                    <div>
                        <h4><asp:Label ID="lblNombrePerfil" runat="server" CssClass="fw-bold"></asp:Label><small> | <asp:Label ID="lblCarrera" runat="server" CssClass="text-muted" /></small></h4>
                        <p class="mb-0">
                            <asp:Label ID="lblBiografia" runat="server" CssClass="text-break" />
                        </p>
                    </div>
                </div>
                <div class="col-btn">
                         <div class="ms-auto">
                            <asp:LinkButton ID="lnkEditarPerfil" runat="server" PostBackUrl="EditProfile.aspx" CssClass="btn btn-outline-secondary" ToolTip="Editar Perfil">
                                <i class="fa-solid fa-gear"></i> Configurar
                            </asp:LinkButton> 
                         </div>    
                </div>
            </div>
        </div>

        <!-- Contenido de página -->
                <!-- Pestañas -->
        <ul class="nav nav-tabs mt-3 px-3 nav-distribuido">
            <li class="nav-item">
                <a class="nav-link" href="Profile.aspx">Publicaciones</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="Profile-Friends.aspx">Amigos</a>
            </li>
            <li class="nav-item">
                <a class="nav-link active" href="Profile-Events.aspx">Eventos</a>
            </li>
        </ul>

        <!-- Publicaciones -->
        <div class="p-4">
            <div class="row gy-4">
                <div class="col-md-6">
                    <div class="event-card bg-white">
                        <img src="../Images/baileton.jpg" alt="Baile" class="event-image" />
                        <div class="event-body">
                            <div class="event-top">
                                <div class="d-flex align-items-center gap-2">
                                    <span class="btn btn-asistir">
                                        <i class="fa-solid fa-circle-check"></i> Asistiré 
                                    </span>
                                </div>
                                <span class="event-date">15 de mayo</span>
                            </div>
                            <div class="event-title">Bailetón jueves cultural</div>
                            <div class="event-description">
                                ¡El ritmo se apodera del campus!<br />
                                Ven a mover el cuerpo, liberar el estrés y disfrutar de una tarde llena de música, baile y buena vibra.
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
