<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Profile.Master" AutoEventWireup="true" CodeBehind="Profile-Friends.aspx.cs" Inherits="PucpConnectPresentacion.templates.Profile_Friends" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12 p-0">
        <!-- Cabecera -->
        <div class="banner">
            <img src="../Images/profile-banner-0.jpeg" alt="Foto perfil" />
        </div>
        <div class="p-4 information-box">
            <div class="d-flex align-items-center">
                <div class="col-img">
                    <div class="avatar">
                        <asp:Image ID="imgPerfil" runat="server" CssClass="rounded-circle me-3" AlternateText="Foto perfil" />
                    </div>
                </div>
                <div class="col-text">
                    <div>
                        <h4><asp:Label ID="lblNombrePerfil" runat="server" CssClass="fw-bold"></asp:Label>
                            <small> | <asp:Label ID="lblCarrera" runat="server" CssClass="text-muted" /></small>
                        </h4>
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

        <!-- Pestañas -->
        <ul class="nav nav-tabs mt-3 px-3 nav-distribuido">
            <li class="nav-item">
                <a class="nav-link" href="Profile.aspx">Publicaciones</a>
            </li>
            <li class="nav-item">
                <a class="nav-link active" href="Profile-Friends.aspx">Amigos</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="Profile-Events.aspx">Eventos</a>
            </li>
        </ul>

        <!-- Tarjetas de amigos dinámicos -->
        <div class="p-4">
            <div class="row">
                <asp:Repeater ID="rptAmigos" runat="server">
                    <ItemTemplate>
                        <div class="col-md-6">
                            <div class="card card-custom">
                                <img src="../Images/profile-banner-0.jpeg" class="card-img-top" alt="Fondo">
                                <div class="card-body">
                                    <div class="profile">
                                        <img src='<%# Eval("fotoPerfil", "../Images/{0}") %>' class="rounded-circle me-3" alt="Foto perfil" width="60" height="60" />
                                    </div>
                                    <div class="info-perfil">
                                        <h5 class="card-title titulo-nombre"><%# Eval("nombre") %></h5>
                                        <p class="descripcion"><%# Eval("biografia") %></p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
