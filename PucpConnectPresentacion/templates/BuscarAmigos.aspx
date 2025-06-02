<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/SectionLayout.Master" AutoEventWireup="true" CodeBehind="BuscarAmigos.aspx.cs" Inherits="PucpConnectPresentacion.BuscarAmigos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-4">
        <div class="d-flex justify-content-between mb-3">
            <h2>Buscar amigos</h2>
            <button class="btn btn-match fw-bold px-4">Match</button>
        </div>
        <div class="row g-4">
            <%-- Tarjeta 1 --%>
            <div class="col-md-6">
                <div class="card card-custom">
                    <img src="../Images/profile-4.jpeg" class="card-img-top" alt="Fondo 1">
                    <div class="card-body">
                        <div class="profile">
                            <img src="../Images/profile-4.jpeg" class="rounded-circle me-3" alt="Foto perfil" />
                        </div>
                        <div class="info-perfil">
                            <h5 class="card-title titulo-nombre">Rony Cueva <button class="btn btn-primary">Enviar solicitud</button></h5>
                            <p class="descripcion">Busco conectar con personas interesadas en la transformación digital.</p>
                            
                        </div>
                    </div>
                </div>
            </div>

            <%-- Tarjeta 2 --%>
            <div class="col-md-6">
                <div class="card card-custom">
                    <img src="../Images/profile-5.jpg" class="card-img-top" alt="Fondo 1">
                    <div class="card-body">
                        <div class="profile">
                            <img src="../Images/profile-5.jpg" class="rounded-circle me-3" alt="Foto perfil" />
                        </div>
                        <div class="info-perfil">
                            <h5 class="card-title titulo-nombre">David Allasi <button class="btn btn-primary">Enviar solicitud</button></h5>
                            <p class="descripcion">Me encanta aprender cosas nuevas y compartir curiosidades.</p>
                
                        </div>
                    </div>
                </div>
            </div>
            <%-- Tarjeta 3 --%>
            <div class="col-md-6">
                <div class="card card-custom">
                    <img src="../Images/profile-3.jpeg" class="card-img-top" alt="Fondo 1">
                    <div class="card-body">
                        <div class="profile">
                            <img src="../Images/profile-3.jpeg" class="rounded-circle me-3" alt="Foto perfil" />
                        </div>
                        <div class="info-perfil">
                            <h5 class="card-title titulo-nombre">Angeles Salazar <button class="btn btn-primary">Enviar solicitud</button></h5>
                             <p class="descripcion">Apasionada por la fotografía urbana y de paisajes.</p>
                        </div>
                    </div>
                </div>
            </div>

            <%-- Tarjeta 4 --%>
            <div class="col-md-6">
                <div class="card card-custom">
                    <img src="../Images/profile-4.jpeg" class="card-img-top" alt="Fondo 1">
                    <div class="card-body">
                        <div class="profile">
                            <img src="../Images/profile-4.jpeg" class="rounded-circle me-3" alt="Foto perfil" />
                        </div>
                        <div class="info-perfil">
                            <h5 class="card-title titulo-nombre">Miguel Galvez <button class="btn btn-primary">Enviar solicitud</button></h5>
                             <p class="descripcion">Apasionado del café y el espacio. Disfruto de una buena taza mientras leo sobre el universo.</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
