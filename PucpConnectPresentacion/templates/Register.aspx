<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/LoginLayout.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PucpConnectPresentacion.templates.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-label { font-weight: bold; }
        .form-control, .form-control-file { margin-bottom: 1rem; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
         <style>
            .registro-form {
                max-width: 1000px;
                margin: auto;
            }
        </style>

        <div class="registro-form">
            <h2 class="mb-4">Crear Usuario</h2>
            <asp:Label ID="LblMensaje" runat="server" ForeColor="Green"></asp:Label>

            <asp:Panel ID="PanelRegistro" runat="server" DefaultButton="BtnRegistrar">
                <div class="row">
                    <!-- Columna izquierda -->
                    <div class="col-md-6">
                        <div class="mb-3">
                            <asp:Label ID="LblNombre" runat="server" Text="Nombre Completo" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="TxtNombre" runat="server" CssClass="form-control" />
                        </div>
                        <div class="mb-3">
                            <asp:Label ID="LblEmail" runat="server" Text="Email" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control" TextMode="Email" />
                        </div>
                        <div class="mb-3">
                            <asp:Label ID="LblPassword" runat="server" Text="Contraseña" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="TxtPassword" runat="server" CssClass="form-control" TextMode="Password" />
                        </div>
                        <div class="mb-3">
                            <asp:Label ID="LblEdad" runat="server" Text="Edad" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="TxtEdad" runat="server" CssClass="form-control" TextMode="Number" />
                        </div>
                    </div>

                    <!-- Columna derecha -->
                    <div class="col-md-6">
                        <div class="mb-3">
                            <asp:Label ID="LblCarrera" runat="server" Text="Carrera" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="TxtCarrera" runat="server" CssClass="form-control" />
                        </div>
                        <div class="mb-3">
                            <asp:Label ID="LblFotoPerfil" runat="server" Text="Foto de Perfil" CssClass="form-label"></asp:Label>
                            <asp:FileUpload ID="FotoPerfilUpload" runat="server" CssClass="form-control" />
                        </div>
                        <div class="mb-3">
                            <asp:Label ID="LblUbicacion" runat="server" Text="Ubicación" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="TxtUbicacion" runat="server" CssClass="form-control" />
                        </div>
                        <div class="mb-3">
                            <asp:Label ID="LblBiografia" runat="server" Text="Biografía" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="TxtBiografia" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
                        </div>
                    </div>
                </div>

                <div class="mt-3">
                    <asp:Button ID="BtnRegistrar" runat="server" Text="Registrarse" CssClass="btn btn-primary w-100" OnClick="BtnRegistrar_Click" />
                </div>
            </asp:Panel>
        </div>
    </form>
</asp:Content>