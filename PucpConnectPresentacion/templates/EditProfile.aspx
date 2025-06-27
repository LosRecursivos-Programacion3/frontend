<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Profile.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="PucpConnectPresentacion.templates.EditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .card-profile-edit {
            background: white;
            border-radius: 2rem;
            padding: 2rem;
            box-shadow: 0px 4px 12px rgba(0, 0, 0, 0.1);
            max-width: 750px; /* Más ancho */
            margin: 0 auto;    /* Centrado horizontal */
        }

        .form-label {
            font-weight: 600;
        }

        .btn-pill {
            border-radius: 999px;
            padding-left: 1.5rem;
            padding-right: 1.5rem;
        }

        .btn-container {
            display: flex;
            justify-content: center;
            gap: 1rem;
            margin-top: 2rem;
        }

        .header-blue {
            background-color: #042354;
            color: white;
            padding: 1rem 2rem;
            border-top-left-radius: 2rem;
            border-top-right-radius: 2rem;
            font-size: 1.25rem;
            font-weight: bold;
            margin: -2rem -2rem 2rem -2rem;
        }

        /* Eliminamos margen superior del contenedor */
        .edit-container {
            margin-top: 0;
            padding-top: 2rem;
        }
    </style>

    <div class="edit-container">
        <div class="card-profile-edit">
            <div class="header-blue">Editar Perfil</div>

            <asp:ValidationSummary runat="server" CssClass="text-danger mb-3" />

            <asp:Panel ID="pnlForm" runat="server" DefaultButton="btnGuardar">
                <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger d-block mb-3" />

                <div class="mb-3">
                    <label for="txtEmail" class="form-label">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control text-muted" ReadOnly="true" />
                </div>

                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                </div>

                <div class="row mb-3">
                    <div class="col-md-6">
                        <label for="txtEdad" class="form-label">Edad</label>
                        <asp:TextBox ID="txtEdad" runat="server" CssClass="form-control" TextMode="Number" />
                    </div>
                    <div class="col-md-6">
                        <label for="txtCarrera" class="form-label">Carrera</label>
                        <asp:TextBox ID="txtCarrera" runat="server" CssClass="form-control" />
                    </div>
                </div>

                <div class="mb-3">
                    <label for="txtUbicacion" class="form-label">Ubicación</label>
                    <asp:TextBox ID="txtUbicacion" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <label for="txtBiografia" class="form-label">Biografía</label>
                    <asp:TextBox ID="txtBiografia" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
                </div>

                <div class="mb-3">
                    <label for="fuFotoPerfil" class="form-label">Foto de Perfil</label>
                    <asp:FileUpload ID="fuFotoPerfil" runat="server" CssClass="form-control" />
                </div>

                <div class="btn-container">
                    <asp:Button ID="btnEditarIntereses" runat="server" Text="Editar Intereses" CssClass="btn btn-info text-white btn-pill" OnClick="btnEditarIntereses_Click" />
                    <asp:Button ID="btnEditarPassword" runat="server" Text="Editar Contraseña" CssClass="btn btn-info text-white btn-pill" OnClick="btnEditarPassword_Click" />
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary btn-pill" OnClick="btnGuardar_Click" />
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>