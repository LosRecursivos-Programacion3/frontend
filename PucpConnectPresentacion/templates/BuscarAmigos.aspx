<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuscarAmigos.aspx.cs" Inherits="PucpConnectPresentacion.BuscarAmigos" MasterPageFile="~/Masters/SectionLayout.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- SweetAlert2 -->
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <div class="container my-4">
        <div class="d-flex justify-content-between mb-3">
            <h2>Buscar amigos</h2>
            <button class="btn btn-match fw-bold px-4">Match</button>
        </div>

        <div class="row g-4">
            <asp:Repeater ID="rptSugeridos" runat="server">
                <ItemTemplate>
                    <div class="col-md-6">
                        <div class="card card-custom">
                            <img src='<%# Eval("fotoPerfil", "../Images/{0}") %>' class="card-img-top" alt="Fondo">
                            <div class="card-body">
                                <div class="profile">
                                    <img src='<%# Eval("fotoPerfil", "../Images/{0}") %>' class="rounded-circle me-3" alt="Foto perfil" />
                                </div>
                                <div class="info-perfil">
                                    <h5 class="card-title titulo-nombre">
                                        <%# Eval("nombre") %>
                                    </h5>
                                    <p class="descripcion"><%# Eval("biografia") %></p>
                                    <br />
                                    <p class="text-muted">
                                        Edad: <%# Eval("edad") %> |
                                        Carrera: <%# Eval("carrera") %> |
                                    </p>
                                    <p class="text-muted"><%# Eval("ubicacion") %></p>

                                    <asp:Button ID="btnSolicitar" runat="server" CssClass="btn btn-primary mt-2"
                                        Text="Enviar solicitud"
                                        CommandArgument='<%# Eval("idAlumno") %>'
                                        OnClick="btnSolicitar_Click"
                                        OnClientClick="return mostrarConfirmacion(this);" />
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

    <script type="text/javascript">
        function mostrarConfirmacion(btn) {
            event.preventDefault(); // Detiene el postback automático

            Swal.fire({
                title: '¿Enviar solicitud?',
                text: "¿Deseas enviar una solicitud de amistad?",
                icon: 'question',
                showCancelButton: true,
                confirmButtonText: 'Sí, enviar',
                cancelButtonText: 'Cancelar'
            }).then((result) => {
                if (result.isConfirmed) {
                    // Ejecuta el postback manualmente
                    __doPostBack(btn.name, '');
                }
            });

            return false; // Siempre detener el postback hasta confirmar
        }
    </script>
</asp:Content>