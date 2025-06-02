<%@ Page Title="Historias" Language="C#" MasterPageFile="~/Masters/Profile.Master" AutoEventWireup="true" CodeBehind="Stories.aspx.cs" Inherits="PucpConnectPresentacion.Stories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .stories-container {
            position: relative;
            padding: 2rem;
        }

        .stories-header {
            display: flex;
            align-items: center;
            gap: 1rem;
            margin-bottom: 1rem;
        }

        .stories-header img {
            width: 50px;
            height: 50px;
            object-fit: cover;
            border-radius: 50%;
        }

        .stories-header .info {
            display: flex;
            flex-direction: column;
        }

        .progress-bar-custom {
            height: 6px;
            background-color: #d1d1d1;
            margin-bottom: 2rem;
            border-radius: 10px;
            overflow: hidden;
        }

        .progress-bar-custom .progress {
            height: 100%;
            background-color: #444;
            width: 60%;
        }

        .stories-image-wrapper {
            display: flex;
            justify-content: center;
        }

        .stories-image {
            border-radius: 20px;
            max-width: 100%;
            height: auto;
            box-shadow: 0 0 15px rgba(0, 0, 0, 0.3);
        }

        /* Navegación lateral superpuesta */
        .story-nav {
            position: absolute;
            top: 0;
            bottom: 0;
            width: 15%;
            background: linear-gradient(to right, rgba(0, 0, 0, 0.25), transparent);
            display: flex;
            align-items: center;
            justify-content: center;
            cursor: pointer;
            z-index: 2;
            transition: background 0.3s ease;
        }

        .story-nav:hover {
            background: rgba(0, 0, 0, 0.35);
        }

        .story-nav-left {
            left: -2%; /* Desplazado ligeramente hacia la izquierda */
        }

        .story-nav-right {
            right: 0;
            background: linear-gradient(to left, rgba(0, 0, 0, 0.25), transparent);
        }

        .story-nav i {
            font-size: 2rem;
            color: white;
            opacity: 0.7;
        }

        .story-nav:hover i {
            opacity: 1;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="stories-container">
        <!-- Botones de navegación izquierda/derecha -->
        <div class="story-nav story-nav-left">
            <i class="fas fa-chevron-left"></i>
        </div>
        <div class="story-nav story-nav-right">
            <i class="fas fa-chevron-right"></i>
        </div>
        <div class="story" style="display:block;">
             <!-- Encabezado del usuario -->
             <div class="stories-header">
                 <img src="../Images/profile-2.jpg" alt="Foto de perfil" />
                 <div class="info">
                     <strong>Rony Cueva</strong>
                     <small class="text-muted">Ing. Informática</small>
                 </div>
             </div>

             <!-- Barra de progreso -->
             <div class="progress-bar-custom">
                 <div class="progress"></div>
             </div>

             <!-- Imagen de código (historia) -->
             <div class="stories-image-wrapper">
                 <img src="../Images/story-1.jpg" alt="Historia de código" class="stories-image" />
             </div>
        </div>
        <div class="story" style="display:none;">
             <!-- Encabezado del usuario -->
             <div class="stories-header">
                 <img src="../Images/profile-2.jpg" alt="Foto de perfil" />
                 <div class="info">
                     <strong>Rony Cueva</strong>
                     <small class="text-muted">Ing. Informática</small>
                 </div>
             </div>

             <!-- Barra de progreso -->
             <div class="progress-bar-custom">
                 <div class="progress"></div>
             </div>

             <!-- Imagen de código (historia) -->
             <div class="stories-image-wrapper">
                 <img src="../Images/story-1.jpg" alt="Historia de código" class="stories-image" />
             </div>
        </div>


    </div>
</asp:Content>