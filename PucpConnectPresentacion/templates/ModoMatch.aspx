<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MatchLayout.Master" AutoEventWireup="true" CodeBehind="ModoMatch.aspx.cs" Inherits="PucpConnectPresentacion.templates.ModoMatch" %>
<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="server">
    
    <link href="../css/Match.css" rel="stylesheet" />

</asp:Content>

<asp:Content ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <a href="Main.aspx" class="btn-back mb-3"><i class="fa-solid fa-arrow-left"></i> Volver</a>
    <h2 class="mb-4 fw-bold">Modo Match</h2>

    <div class="card card-profile mx-auto p-4 bg-white" style="max-width: 600px;">
        <img src="../Images/ProfileBanner2.jpg" alt="Fondo" class="cover" />
        <asp:Image ID="imgFotoPerfil" runat="server" CssClass="avatar" />

        <h3 class="mt-3 fw-bold"><asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label></h3>

        <p class="text-muted"><asp:Label ID="lblBiografia" runat="server" Text="Bio"></asp:Label></p>
        <p class="text-muted"><asp:Label ID="lblCarrera" runat="server" Text="Carrera"></asp:Label></p>
        <div class="interest-container">
            <asp:Literal ID="litIntereses" runat="server"></asp:Literal>
        </div>

        <div class="match-buttons">
            <asp:LinkButton ID="btnRechazar" runat="server" CssClass="btn btn-danger btn-match" OnClick="btnRechazar_Click" UseSubmitBehavior="false"><i class="fa-solid fa-xmark"></i></asp:LinkButton>

            <asp:LinkButton ID="btnAceptar" runat="server" CssClass="btn btn-success btn-match" OnClick="btnAceptar_Click" UseSubmitBehavior="false"><i class="fa-solid fa-check"></i></asp:LinkButton>
            <div class="text-center mt-3">
                <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-outline-primary fw-bold px-4" Text="Volver a Buscar Amigos" PostBackUrl="BuscarAmigos.aspx" Visible="false" />
            </div>
        </div>
    </div>

    <!-- Modal de Match -->
    <div class="modal fade" id="modalMatch" tabindex="-1" aria-labelledby="modalMatchLabel" aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content text-center p-4">
          <h5 class="modal-title fw-bold mb-3" id="modalMatchLabel">¡Es un Match!</h5>
          <p class="mb-4">Ambos se han dado Match. ¿Qué deseas hacer ahora?</p>
          <div class="d-flex justify-content-center gap-3">
            <asp:Button ID="btnAgregarAmigo" runat="server" CssClass="btn btn-primary" Text="Agregar a Amigos" OnClick="btnAgregarAmigo_Click" />
          </div>
        </div>
      </div>
    </div>
</asp:Content>

