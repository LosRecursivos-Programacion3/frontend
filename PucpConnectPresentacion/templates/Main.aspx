<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainLayout.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="PucpConnectPresentacion.Main" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!-- Publicación 1 (es de prueba) -->
        <div class="card mb-4 shadow-sm">
            <div class="card-body">
                <div class="d-flex align-items-center mb-2">
                    <div class="avatar">
                        <img src="../Images/profile-2.jpg" alt="Imagen publicación" />
                    </div>
                    <div>
                        <strong>Rony Cueva</strong><br />
                        <small class="text-muted">Ing. Informática</small>
                    </div>
                    <div class="ms-auto text-muted small">10:25 02/05/25</div>
                </div>
                <p>Fue una gran experiencia la que viví en aquel festival CES 2023, pude aprender mucho sobre tecnologías que en la actualidad son vitales, lo cual aportó mucho a mi carrera profesional.</p>
                <img src="../Images/feed-1.jpg" class="post-img" alt="Imagen publicación" />
                <div class="d-flex justify-content-around mt-3 reaction-icons">
                    <div><i class="fa-solid fa-comment"></i> 346</div>
                    <div><i class="fa-solid fa-heart"></i> 49</div>
                    <div><i class="fa-solid fa-share"></i> 107</div>
                </div>
            </div>
        </div>

        <!-- Publicación 2 (es de prueba) -->
        <div class="card mb-4 shadow-sm">
            <div class="card-body">
                <div class="d-flex align-items-center mb-2">
                    <div class="avatar">
                        <img src="../Images/profile-1.jpg" alt="Imagen publicación" />
                    </div>
                    <div>
                        <strong>Juan Quiroz</strong><br />
                        <small class="text-muted">Derecho</small>
                    </div>
                    <div class="ms-auto text-muted small">16:23 24/04/25</div>
                </div>
                <p>Actualmente, con el incremento del alumnado en la PUCP, se hace muy complicado el encontrar un sitio de estudio en las bibliotecas. ¿Algún "point" para estudiar tranquilamente?</p>
                <div class="d-flex justify-content-around mt-3 reaction-icons">
                    <div><i class="fa-solid fa-comment"></i> 346</div>
                    <div><i class="fa-solid fa-heart"></i> 49</div>
                    <div><i class="fa-solid fa-share"></i> 107</div>
                </div>
            </div>
        </div>
</asp:Content>

