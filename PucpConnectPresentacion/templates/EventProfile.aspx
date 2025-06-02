<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Profile.Master" AutoEventWireup="true" CodeBehind="EventProfile.aspx.cs" Inherits="PucpConnectPresentacion.templates.EventProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- Contenido principal -->
 <div class="col-md-12 p-0">
         <!-- Cabecera -->
         <div class="banner">
             <img src="../Images/baileton.jpg" alt="Foto perfil" />
         </div>
         <div class="p-4 information-box">
            <div class="row align-items-center">
                <!-- Columna de texto -->
                <div class="col-md-10">
                    <div class="d-flex align-items-center gap-4 mb-2">
                        <h4 class="mb-0">Bailetón Jueves Cultural</h4>
                        <small class="text-muted">Fecha: 15 de mayo de 2025</small>
                    </div>
                    <p class="mb-0">
                        ¡El ritmo se apodera del campus!<br />
                        Ven a mover el cuerpo, liberar el estrés y disfrutar de una tarde llena de música, baile y buena vibra.
                    </p>
                </div>

                <!-- Columna de botón + imagen -->
                <div class="col-md-2 text-center">
                    <img src="../Images/profile-2.jpg" class="mb-2" alt="Ícono baile" style="width: 55px; border-radius:30%;" />
                    <br />
                    <button class="btn-asistir-profile btn btn-primary">
                        <i class="fa-solid fa-circle-check"></i> Asistiré
                    </button>
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
                 <a class="nav-link" href="#">Participantes</a>
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
         </div>
     </div>
</asp:Content>
