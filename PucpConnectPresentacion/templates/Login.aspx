<%@ Page Title="Iniciar sesión" Language="C#" MasterPageFile="~/Masters/LoginLayout.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PucpConnectPresentacion.WebForm1" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <h3 class="mb-4 fw-bold">Iniciar sesión</h3>
        <p class="text-muted">Accede con tu cuenta</p>

        <div class="mb-3">
            <asp:TextBox ID="TxtEmail" runat="server" type="email" class="form-control" placeholder="usuario@pucp.edu.pe" required></asp:TextBox>
        </div>
        <div class="mb-3">
            <asp:TextBox ID="TxtPassword" runat="server" type="password" class="form-control" placeholder="Contraseña" required></asp:TextBox>
        </div>
        <div class="d-grid">
            <asp:Button ID="BtnLogin" class="btn btn-primary" OnClick="BtnLogin_Click" runat="server" Text="Ingresar" />
        </div>
        <div class="forgot-link mt-3">
            ¿Aún no tienes cuenta? <a href="Register.aspx">Regístrate aquí</a>
        </div>
    </form>
</asp:Content>