<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/MainLayout.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="PucpConnectPresentacion.Main" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Label ID="lblSinPublicaciones" runat="server" CssClass="text-muted d-block text-center my-3" Visible="false" Text="No hay publicaciones que mostrar, crea una o añade amigos para ver sus publicaciones."></asp:Label>
        <asp:Repeater ID="rptMainFeed" runat="server">
            <ItemTemplate>
                <div class="card mb-4 shadow-sm">
                    <div class="card-body">
                        <div class="d-flex align-items-center mb-2">
                            <div class="avatar">
                                <img src='<%# Eval("RutaFotoPerfil") %>' alt="Imagen publicación" />
                            </div>
                            <div>
                                <strong><%# Eval("NombreAutor") %></strong><br />
                                <small class="text-muted"><%# Eval("CarreraAutor") %></small>
                            </div>
                            <div class="ms-auto text-muted small"><%# Eval("FechaPublicacion") %></div>
                        </div>
                        <p><%# Eval("Contenido") %></p>

                        <%-- Mostrar la imagen solo si existe --%>
                        <asp:PlaceHolder runat="server" Visible='<%# !string.IsNullOrEmpty(Eval("ImagenPost") as string) %>'>
                            <img src='<%# Eval("ImagenPost") %>' class="post-img" alt="Imagen publicación" />
                        </asp:PlaceHolder>

                        <div class="d-flex justify-content-around mt-3 reaction-icons">
                            <div><i class="fa-solid fa-comment"></i> 0</div>
                            <div><i class="fa-solid fa-heart"></i> 0</div>
                            <div><i class="fa-solid fa-share"></i> 0</div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
</asp:Content>

