<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MatchLayout.Master" AutoEventWireup="true" CodeBehind="ModoMatch.aspx.cs" Inherits="PucpConnectPresentacion.templates.ModoMatch" %>
<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="server">
    
    <link href="../css/Match.css" rel="stylesheet" />

</asp:Content>

<asp:Content ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <button class="btn-back mb-3"><i class="fa-solid fa-arrow-left"></i> Volver</button>

    <h2 class="mb-4 fw-bold">Modo Match</h2>

    <div class="card card-profile mx-auto p-4 bg-white" style="max-width: 600px;">
        <img src="../Images/ProfileBanner2.jpg" alt="Fondo" class="cover" />
        <img src="../Images/profile-4.jpeg" alt="Avatar" class="avatar" />
        <h3 class="mt-3 fw-bold">Miguel Galvez</h3>
        <p class="text-muted">Apasionado del café y el espacio. Disfruto de una buena taza mientras leo sobre el universo</p>

        <div>
            <span class="interest-tag">Arte</span>
            <span class="interest-tag">Viajar</span>
            <span class="interest-tag">Música</span>
            <span class="interest-tag">Lectura</span>
            <span class="interest-tag">Festivales</span>
        </div>

        <div class="match-buttons">
            <button class="btn btn-danger btn-match"><i class="fa-solid fa-xmark"></i></button>
            <button class="btn btn-success btn-match"><i class="fa-solid fa-check"></i></button>
        </div>
    </div>
</asp:Content>

