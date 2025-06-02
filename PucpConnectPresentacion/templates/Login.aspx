<%@ Page Title="Iniciar sesión" Language="C#" MasterPageFile="~/Masters/LoginLayout.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PucpConnectPresentacion.WebForm1" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <h3 class="mb-4 fw-bold">Iniciar sesión</h3>
        <p class="text-muted">Accede con tu cuenta</p>

        <div class="mb-3">
            <input type="email" class="form-control" placeholder="usuario@pucp.edu.pe" required>
        </div>
        <div class="mb-3">
            <input type="password" class="form-control" placeholder="Contraseña" required>
        </div>
        <div class="d-grid">
            <button type="submit" class="btn btn-primary">Ingresar</button>
        </div>
        <div class="forgot-link mt-3">
            ¿Olvidaste tu contraseña? <a href="#">Recupérala aquí</a>
        </div>
    </form>
</asp:Content>