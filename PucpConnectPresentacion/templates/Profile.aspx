<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Profile.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="PucpConnectPresentacion.Profile" %>
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
                        <img src="../Images/profile-0.jpg" class="rounded-circle me-3" alt="Foto perfil" />
                    </div>
                </div>
                <div class="col-text">
                    <div>
                        <h4 class="mb-2">Heider Sanchez <small class="text-muted"> | Ing. Informática</small></h4>
                        <p class="mb-0">
                            Ingeniero Informático, hago prácticas en la empresa Bankinter, me apasiona desarrollar sistemas web.
                            Aspiro aplicar mis conocimientos en el extranjero, experto en: Java, C#, C, C++, Python, JavaScript, SQL.
                        </p>
                    </div>
                </div>
            <div class="col-btn">
                     <div class="ms-auto">
                         <asp:Button ID="btnConfigurar" runat="server" Text="Configurar Perfil" OnClick="btnConfigurar_Click" CssClass="btn btn-primary" />
                        <asp:Button ID="btnConfigureInterests" runat="server" Text="Configurar Intereses" OnClick="btnConfigureInterests_Click"  CssClass="btn btn-primary" />
                     </div>    
            </div>
        </div>

        <!-- Contenido de página -->
                <!-- Pestañas -->
        <ul class="nav nav-tabs mt-3 px-3 nav-distribuido">
            <li class="nav-item">
                <a class="nav-link active" href="#">Publicaciones</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="Profile-Friends.aspx">Amigos</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="Profile-Events.aspx">Eventos</a>
            </li>
        </ul>

        <!-- Publicaciones -->
        <div class="p-4">
            <div class="card shadow-sm">
                <div class="card-body">
                    <div class="d-flex align-items-center mb-2">
                         <div class="avatar-mini">
                             <img src="../Images/profile-0.jpg" class="rounded-circle me-3" alt="Foto perfil" />
                         </div>
                        <div>
                            <strong>Heider Sanchez</strong><br />
                            <span class="text-muted">Ing. Informática · 20:10 · 29/05/25</span>
                        </div>
                    </div>
                    <p>EMPEZARON LAS INTERFACUS 2025!!</p>
                    <div class="row g-2 mb-3">
                        <img src="../Images/interfacus.jpg" class="img-fluid post-img" alt="Publicación" />
                    </div>
                    <div class="d-flex justify-content-around mt-3 reaction-icons">
                        <div><i class="fa-solid fa-comment"></i> 144</div>
                        <div><i class="fa-solid fa-heart"></i> 130</div>
                        <div><i class="fa-solid fa-share"></i> 40</div>
                    </div>
                </div>
            </div>
            <br />
            <div class="card shadow-sm">
                <div class="card-body">
                    <div class="d-flex align-items-center mb-3">
                         <div class="avatar-mini">
                             <img src="../Images/profile-0.jpg" class="rounded-circle me-3" alt="Foto perfil" />
                         </div>
                        <div>
                            <strong>Heider Sanchez</strong><br />
                            <span class="text-muted">Ing. Informática · 20:10 · 13/04/25</span>
                        </div>
                    </div>
                    <div class="row g-2 mb-3">
                        <img src="../Images/pucp-image.jpg" class="img-fluid post-img" alt="Publicación" />
                    </div>
                    <div class="d-flex justify-content-around mt-3 reaction-icons">
                        <div><i class="fa-solid fa-comment"></i> 346</div>
                        <div><i class="fa-solid fa-heart"></i> 49</div>
                        <div><i class="fa-solid fa-share"></i> 107</div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
